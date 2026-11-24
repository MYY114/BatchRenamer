using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BatchRenamer.Core
{
    public enum RenameMode
    {
        Replace = 0,
        Affix = 1,
        Number = 2,
        Regex = 3,
        Case = 4
    }

    public sealed class RenameRule
    {
        public RenameMode Mode;
        public string Find = string.Empty;
        public string ReplaceWith = string.Empty;
        public bool IgnoreCase;
        public string Prefix = string.Empty;
        public string Suffix = string.Empty;
        public string BaseName = "file";
        public int Start = 1;
        public int Digits = 3;
        public bool KeepExtension = true;
        public string Pattern = string.Empty;
        public string RegexReplace = string.Empty;
        public int CaseOption; // 0=大写 1=小写 2=首字母大写
    }

    public sealed class RenameItem
    {
        public const string StatusOk = "OK";
        public string OldName;
        public string NewName;
        public string OldFull;
        public string NewFull;
        public string Status;

        public bool CanApply { get { return Status == StatusOk; } }
    }

    /// <summary>预览构建 + 两阶段安全改名 + 撤销。</summary>
    public static class RenameEngine
    {
        public static List<RenameItem> BuildPreview(IList<string> fullPaths, RenameRule rule)
        {
            var items = new List<RenameItem>();
            char[] invalidChars = Path.GetInvalidFileNameChars();
            var sourceSet = new HashSet<string>(fullPaths, StringComparer.OrdinalIgnoreCase);

            Regex regex = null;
            bool regexBroken = false;
            if (rule.Mode == RenameMode.Regex && !string.IsNullOrEmpty(rule.Pattern))
            {
                try { regex = new Regex(rule.Pattern); }
                catch (ArgumentException) { regexBroken = true; }
            }

            for (int i = 0; i < fullPaths.Count; i++)
            {
                string full = fullPaths[i];
                string oldName = Path.GetFileName(full);
                string ext = Path.GetExtension(full);
                string baseName = Path.GetFileNameWithoutExtension(full);

                var item = new RenameItem
                {
                    OldName = oldName,
                    OldFull = full,
                    NewName = oldName,
                    NewFull = full,
                    Status = RenameItem.StatusOk
                };

                if (regexBroken)
                {
                    item.Status = "正则错误";
                    items.Add(item);
                    continue;
                }

                string newBase;
                try
                {
                    newBase = Transform(baseName, rule, i, regex);
                }
                catch (ArgumentException)
                {
                    item.Status = "正则错误";
                    items.Add(item);
                    continue;
                }

                string newName = (rule.Mode == RenameMode.Number && !rule.KeepExtension)
                    ? newBase
                    : newBase + ext;

                item.NewName = newName;
                item.NewFull = Path.Combine(Path.GetDirectoryName(full) ?? string.Empty, newName);

                if (string.IsNullOrEmpty(newName))
                    item.Status = "空名称";
                else if (newName.IndexOfAny(invalidChars) >= 0)
                    item.Status = "非法字符";
                else if (string.Equals(newName, oldName, StringComparison.Ordinal))
                    item.Status = "无变化";

                items.Add(item);
            }

            var nameCount = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            foreach (var it in items)
            {
                int c;
                nameCount.TryGetValue(it.NewName, out c);
                nameCount[it.NewName] = c + 1;
            }
            var movingSources = new HashSet<string>(
                items.Where(x => x.Status == RenameItem.StatusOk).Select(x => x.OldFull),
                StringComparer.OrdinalIgnoreCase);

            foreach (var it in items)
            {
                if (it.Status != RenameItem.StatusOk) continue;
                if (nameCount[it.NewName] > 1)
                    it.Status = "冲突";
                else if (File.Exists(it.NewFull) && !movingSources.Contains(it.NewFull))
                    it.Status = "已存在";
            }
            return items;
        }

        private static string Transform(string baseName, RenameRule r, int index, Regex regex)
        {
            switch (r.Mode)
            {
                case RenameMode.Replace:
                    return LiteralReplace(baseName, r.Find, r.ReplaceWith ?? string.Empty, r.IgnoreCase);
                case RenameMode.Affix:
                    return (r.Prefix ?? string.Empty) + baseName + (r.Suffix ?? string.Empty);
                case RenameMode.Number:
                    string bn = string.IsNullOrEmpty(r.BaseName) ? "file" : r.BaseName;
                    int digits = Math.Max(1, Math.Min(8, r.Digits));
                    return bn + (r.Start + index).ToString("D" + digits, CultureInfo.InvariantCulture);
                case RenameMode.Regex:
                    return regex == null ? baseName : regex.Replace(baseName, r.RegexReplace ?? string.Empty);
                case RenameMode.Case:
                    if (r.CaseOption == 0) return baseName.ToUpperInvariant();
                    if (r.CaseOption == 1) return baseName.ToLowerInvariant();
                    return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(baseName.ToLowerInvariant());
                default:
                    return baseName;
            }
        }

        private static string LiteralReplace(string s, string find, string replacement, bool ignoreCase)
        {
            if (string.IsNullOrEmpty(find)) return s;
            var cmp = ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
            var sb = new StringBuilder();
            int i = 0;
            while (true)
            {
                int j = s.IndexOf(find, i, cmp);
                if (j < 0)
                {
                    sb.Append(s.Substring(i));
                    break;
                }
                sb.Append(s.Substring(i, j - i));
                sb.Append(replacement);
                i = j + find.Length;
            }
            return sb.ToString();
        }

        /// <summary>执行重命名，返回成功项 (原路径, 新路径)。失败自动回滚并给出 error。</summary>
        public static List<string[]> Apply(IList<RenameItem> items, out string error)
        {
            var moves = new List<string[]>();
            foreach (var it in items)
            {
                if (!it.CanApply) continue;
                if (!File.Exists(it.OldFull)) continue;
                bool caseOnly = string.Equals(it.OldFull, it.NewFull, StringComparison.OrdinalIgnoreCase);
                if (File.Exists(it.NewFull) && !caseOnly) continue;
                moves.Add(new[] { it.OldFull, it.NewFull });
            }
            if (TwoPhaseMove(moves, out error)) return moves;
            return new List<string[]>();
        }

        public static bool Undo(IList<string[]> pairs, out string error)
        {
            error = null;
            foreach (var p in pairs)
            {
                if (!File.Exists(p[1]))
                {
                    error = "文件不存在：" + p[1];
                    return false;
                }
                bool caseOnly = string.Equals(p[0], p[1], StringComparison.OrdinalIgnoreCase);
                if (File.Exists(p[0]) && !caseOnly)
                {
                    error = "原文件名已被占用：" + p[0];
                    return false;
                }
            }
            var reverse = pairs.Select(p => new[] { p[1], p[0] }).ToList();
            return TwoPhaseMove(reverse, out error);
        }

        /// <summary>两阶段改名：先全部临时名，再目标名；支持 A↔B 互换，失败自动回滚。</summary>
        private static bool TwoPhaseMove(List<string[]> moves, out string error)
        {
            error = null;
            var temps = new List<string[]>();
            try
            {
                foreach (var m in moves)
                {
                    string dir = Path.GetDirectoryName(m[0]) ?? string.Empty;
                    string temp = Path.Combine(dir, "__renamer_tmp_" + Guid.NewGuid().ToString("N") + ".tmp");
                    File.Move(m[0], temp);
                    temps.Add(new[] { m[0], temp, m[1] });
                }
                foreach (var t in temps)
                {
                    File.Move(t[1], t[2]);
                    t[1] = null;
                }
                return true;
            }
            catch (Exception ex)
            {
                foreach (var t in temps)
                {
                    try
                    {
                        if (t[1] != null && File.Exists(t[1]) && !File.Exists(t[0]))
                            File.Move(t[1], t[0]);
                        else if (File.Exists(t[2]) && !File.Exists(t[0]))
                            File.Move(t[2], t[0]);
                    }
                    catch
                    {
                    }
                }
                error = ex.Message;
                return false;
            }
        }
    }
}