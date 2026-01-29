using HarmonyLib;
using UnityEngine;

namespace ChinesePatch
{
    [HarmonyPatch(typeof(UILabel), "set_text")]
    public class UILabel_SetText_Patch
    {
        // 前置补丁：处理换行符
        static void Prefix(UILabel __instance)
        {
            if (__instance == null || FontManager.Instance == null) return;
            FontManager.Instance.ProcessTextBeforeDisplay(__instance);
        }

        // 后置补丁：处理字体回退
        static void Postfix(UILabel __instance)
        {
            if (__instance == null || FontManager.Instance == null) return;
            FontManager.Instance.ApplyFontToLabel(__instance);
        }
    }

    [HarmonyPatch(typeof(UILabel), "OnStart")]
    public class UILabel_OnStart_Patch
    {
        static void Postfix(UILabel __instance)
        {
            if (__instance == null || FontManager.Instance == null) return;
            // OnStart 时建议两个都跑一遍，确保初始状态正确
            FontManager.Instance.ProcessTextBeforeDisplay(__instance);
            FontManager.Instance.ApplyFontToLabel(__instance);
        }
    }
}