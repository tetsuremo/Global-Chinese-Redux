using BepInEx;
using HarmonyLib;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ChinesePatch
{
    [BepInPlugin("com.fallout.chinesepatch", "Fallout Shelter Chinese Patch", "0.9.7")]
    public class MainPlugin : BaseUnityPlugin
    {
        public static string PluginFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static Dictionary<string, string> TermTranslations = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        public static BepInEx.Logging.ManualLogSource Log;

        void Awake()
        {
            Log = Logger;
            // 1. 加载外部 TXT 翻译
            LoadTranslations();

            // 2. 挂载管理器 (作为根对象挂载以消除 DontDestroyOnLoad 警告)
            if (gameObject.GetComponent<FontManager>() == null)
                gameObject.AddComponent<FontManager>().Init();

            if (gameObject.GetComponent<MemoryTranslator>() == null)
                gameObject.AddComponent<MemoryTranslator>();

            // 3. 启动 Harmony 补丁
            var harmony = new Harmony("com.fallout.chinesepatch");
            harmony.PatchAll();

            Log.LogInfo(">>> 汉化补丁核心已启动，等待内存翻译注入...");
        }

        private void LoadTranslations()
        {
            // 路径：BepInEx\plugins\ChinesePatch\Translation\translations.txt
            string path = Path.Combine(PluginFolder, "Translation", "translations.txt");
            Log.LogInfo($"正在尝试加载词库: {path}");

            if (!File.Exists(path))
            {
                Log.LogError($"找不到词库文件: {path}");
                return;
            }

            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#")) continue;
                    int idx = line.IndexOf('=');
                    if (idx > 0)
                    {
                        string k = line.Substring(0, idx).Trim();
                        string v = line.Substring(idx + 1).Trim();

                        // 在加载时就处理转义序列
                        v = ProcessEscapeSequences(v);

                        if (!TermTranslations.ContainsKey(k)) TermTranslations.Add(k, v);
                    }
                }
                Log.LogInfo($"词库加载完成，成功载入 {TermTranslations.Count} 个词条");
            }
            catch (Exception e)
            {
                Log.LogError($"读取词库出错: {e.Message}");
            }
        }

        private string ProcessEscapeSequences(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;

            // 处理常见的转义序列
            return text
                .Replace("\\n", "\n")
                .Replace("\\t", "\t")
                .Replace("\\r", "\r");
        }
    }
}