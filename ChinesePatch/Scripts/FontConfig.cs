using System;

namespace ChinesePatch
{
    [Serializable]
    public class FontConfig
    {
        // 是否启用 Fallback 功能
        public bool Enabled = true;
        // 目标字体名称（必须是系统已安装的字体）
        public string FontName = "Microsoft YaHei";
        // 触发 Fallback 后，Label 使用的默认字号
        public int DefaultFontSize = 26;
        // 内部加载系统字体时的采样尺寸（越高越清晰，但内存占用略高）
        public int OSFontSize = 32;
        // 排除检测的字符（如空格、控制符，减少误判）
        public string ExcludeChars = " \t\n\r";
    }
}