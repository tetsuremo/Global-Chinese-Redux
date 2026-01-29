using UnityEngine;
using I2.Loc;

namespace ChinesePatch
{
    public class MemoryTranslator : MonoBehaviour
    {
        private float scanInterval = 3f;
        private float lastScanTime = 0f;

        void Update()
        {
            if (Time.time - lastScanTime > scanInterval)
            {
                lastScanTime = Time.time;
                DoTranslationWork();
            }
        }

        void DoTranslationWork()
        {
            bool hasChanged = false;

            // 扫描所有已加载的语言源
            if (LocalizationManager.Sources != null)
                foreach (var source in LocalizationManager.Sources)
                    if (ApplyToSource(source)) hasChanged = true;

            // 扫描内存中潜在的其他源
            var allSources = Resources.FindObjectsOfTypeAll<LanguageSource>();
            foreach (var s in allSources)
                if (ApplyToSource(s)) hasChanged = true;

            // 新增：直接扫描场景中所有的UILabel
            var allLabels = Resources.FindObjectsOfTypeAll<UILabel>();
            foreach (var label in allLabels)
            {
                if (label == null || string.IsNullOrEmpty(label.text)) continue;

                // 尝试直接翻译UILabel上的文本
                if (MainPlugin.TermTranslations.TryGetValue(label.text, out string cnText))
                {
                    label.text = cnText;
                    hasChanged = true;
                }
                // 尝试去除特殊字符后翻译
                else
                {
                    string key = label.text.Trim();
                    if (MainPlugin.TermTranslations.TryGetValue(key, out cnText))
                    {
                        label.text = cnText;
                        hasChanged = true;
                    }
                }
            }

            if (hasChanged)
            {
                foreach (var label in Resources.FindObjectsOfTypeAll<UILabel>())
                {
                    label.MarkAsChanged();
                    if (FontManager.Instance != null)
                        FontManager.Instance.ApplyFontToLabel(label);
                }
            }
        }

        bool ApplyToSource(LanguageSource source)
        {
            if (source == null || source.mTerms == null) return false;
            bool changed = false;
            foreach (var termData in source.mTerms)
            {
                if (MainPlugin.TermTranslations.TryGetValue(termData.Term, out string cnText))
                {
                    // 修改第一语言列（通常是补丁生效的那一列）
                    if (termData.Languages != null && termData.Languages.Length > 0 && termData.Languages[0] != cnText)
                    {
                        termData.Languages[0] = cnText;
                        changed = true;
                    }
                }
            }
            return changed;
        }
    }
}