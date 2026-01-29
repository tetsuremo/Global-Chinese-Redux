using System;
using System.IO;
using UnityEngine;

namespace ChinesePatch
{
    public class FontManager : MonoBehaviour
    {
        public static FontManager Instance;
        private Font fallbackFont;
        private bool isLoaded = false;
        private FontConfig config;

        void Awake()
        {
            Instance = this;
            transform.SetParent(null);
            DontDestroyOnLoad(gameObject);
        }

        public void Init()
        {
            LoadConfig();

            if (!config.Enabled)
            {
                MainPlugin.Log.LogInfo("Font Fallback 功能已根据配置禁用");
                return;
            }

            try
            {
                fallbackFont = Font.CreateDynamicFontFromOSFont(config.FontName, config.OSFontSize);
                if (fallbackFont != null)
                {
                    DontDestroyOnLoad(fallbackFont);
                    isLoaded = true;
                    MainPlugin.Log.LogInfo($"Fallback 系统字体({config.FontName})初始化成功");
                }
            }
            catch (Exception e)
            {
                MainPlugin.Log.LogError($"系统字体挂载失败: {e.Message}");
            }
        }

        private void LoadConfig()
        {
            string configPath = Path.Combine(MainPlugin.PluginFolder, "font_config.json");
            try
            {
                if (File.Exists(configPath))
                {
                    config = JsonUtility.FromJson<FontConfig>(File.ReadAllText(configPath));
                }
                else
                {
                    config = new FontConfig();
                    File.WriteAllText(configPath, JsonUtility.ToJson(config, true));
                }
            }
            catch
            {
                config = new FontConfig();
            }
        }

        private bool isApplying = false;

        public void ProcessTextBeforeDisplay(UILabel label)
        {
            if (label == null || isApplying) return;
        }

        public void ApplyFontToLabel(UILabel label)
        {
            if (label == null || !isLoaded || isApplying) return;

            // 字体检测逻辑保持不变
            if (label.bitmapFont != null && !string.IsNullOrEmpty(label.text))
            {
                bool needsFallback = false;
                foreach (char c in label.text)
                {
                    if (c <= 126 || config.ExcludeChars.Contains(c.ToString())) continue;
                    if (label.bitmapFont.bmFont.GetGlyph(c) == null)
                    {
                        needsFallback = true;
                        break;
                    }
                }

                if (needsFallback && label.trueTypeFont != fallbackFont)
                {
                    isApplying = true;
                    label.trueTypeFont = fallbackFont;
                    if (label.fontSize <= 0) label.fontSize = config.DefaultFontSize;
                    label.MarkAsChanged();
                    isApplying = false;
                }
            }
        }
    }
}