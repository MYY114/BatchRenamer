using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BatchRenamer.Core
{
    /// <summary>极简设置存储：%AppData%\BatchRenamer\settings.ini。</summary>
    public static class AppSettings
    {
        private static readonly Dictionary<string, string> Values =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public static string DataDir
        {
            get
            {
                string dir = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BatchRenamer");
                Directory.CreateDirectory(dir);
                return dir;
            }
        }

        private static string SettingsPath
        {
            get { return Path.Combine(DataDir, "settings.ini"); }
        }

        static AppSettings()
        {
            Load();
        }

        public static void Load()
        {
            Values.Clear();
            try
            {
                if (!File.Exists(SettingsPath)) return;
                foreach (string line in File.ReadAllLines(SettingsPath, Encoding.UTF8))
                {
                    int idx = line.IndexOf('=');
                    if (idx <= 0) continue;
                    Values[line.Substring(0, idx).Trim()] = line.Substring(idx + 1);
                }
            }
            catch
            {
            }
        }

        public static void Save()
        {
            try
            {
                var sb = new StringBuilder();
                foreach (var kv in Values) sb.Append(kv.Key).Append('=').AppendLine(kv.Value);
                File.WriteAllText(SettingsPath, sb.ToString(), Encoding.UTF8);
            }
            catch
            {
            }
        }

        public static string GetString(string key, string fallback)
        {
            string v;
            return Values.TryGetValue(key, out v) ? v : fallback;
        }

        public static void Set(string key, string value)
        {
            Values[key] = value ?? string.Empty;
            Save();
        }
    }

    /// <summary>
    /// 最近一次批量重命名的撤销记录：%AppData%\BatchRenamer\last_rename.tsv
    /// 每行 = Base64(原路径) \t Base64(新路径)，重启后仍可撤销。
    /// </summary>
    public static class UndoStore
    {
        private static string FilePath
        {
            get { return Path.Combine(AppSettings.DataDir, "last_rename.tsv"); }
        }

        public static List<string[]> Load()
        {
            var list = new List<string[]>();
            try
            {
                if (!File.Exists(FilePath)) return list;
                foreach (string line in File.ReadAllLines(FilePath, Encoding.UTF8))
                {
                    int idx = line.IndexOf('\t');
                    if (idx <= 0) continue;
                    try
                    {
                        string oldPath = Encoding.UTF8.GetString(Convert.FromBase64String(line.Substring(0, idx)));
                        string newPath = Encoding.UTF8.GetString(Convert.FromBase64String(line.Substring(idx + 1)));
                        list.Add(new[] { oldPath, newPath });
                    }
                    catch (FormatException)
                    {
                    }
                }
            }
            catch
            {
            }
            return list;
        }

        public static void Save(IList<string[]> pairs)
        {
            try
            {
                var sb = new StringBuilder();
                foreach (var p in pairs)
                {
                    sb.Append(Convert.ToBase64String(Encoding.UTF8.GetBytes(p[0]))).Append('\t')
                      .AppendLine(Convert.ToBase64String(Encoding.UTF8.GetBytes(p[1])));
                }
                File.WriteAllText(FilePath, sb.ToString(), Encoding.UTF8);
            }
            catch
            {
            }
        }

        public static void Clear()
        {
            try { if (File.Exists(FilePath)) File.Delete(FilePath); } catch { }
        }
    }
}