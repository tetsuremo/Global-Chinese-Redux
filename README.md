<div align="center">

**简体中文** | [English](README_EN.md)

</div>

# 🎮 辐射：避难所（国际版） TO PC 字体补丁 + 汉化插件
![进度](https://img.shields.io/badge/进度-99%25-orange?style=flat-square) 
![版本](https://img.shields.io/badge/游戏版本-2.1.1-blue?style=flat-square)
![BepInEx](https://img.shields.io/badge/BepInEx-5.4.x-green?style=flat-square)

> 除名字外，全文本汉化。

## 🖼️ 效果预览
| 无补丁版 | 补丁效果 |
|----------|----------|
| ![无字体补丁界面](preview_none.jpg) | ![打字体补丁界面](preview_patch.jpg) |

---

## ✨ 项目起源
源于我的强迫症：无法接受直译文本以及默认字体在UI上的粗糙表现，特此制作了这个从**翻译到视觉完全优化**的汉化补丁。

参考了之前1.13.13汉化版本老哥的[教程](https://steamcommunity.com/sharedfiles/filedetails/?id=2877972565)。

## 📅 版本说明
- **当前版本**: 2.1.1汉化补丁
- **适配游戏**: Fallout Shelter 2.x (Steam/GOG/Xbox PC)
- **维护状态**: 当前版本已基本完成，后续随缘更新
---

## 🚀 快速开始

### 安装步骤
1. **安装 BepInEx**
   - 下载 [BepInEx 5.4.x](https://github.com/BepInEx/BepInEx/releases)
   - 解压到游戏根目录（与 `FalloutShelter.exe` 同级）

2. **安装汉化插件**
   - 下载本项目的 `ChinesePatch.zip`
   - 解压后将 `ChinesePatch` 文件夹复制到 `BepInEx/plugins/`

3. **（可选）安装字体补丁**
   - 下载并运行 `Patch.exe`
   - 程序会自动备份并替换游戏字体文件

4. **启动游戏**
   - 直接运行 `FalloutShelter.exe`
   - 首次启动需要等待BepInEx初始化

---

### 文件结构
BepInEx/plugins/ChinesePatch/  
├── ChinesePatch.dll # 核心插件  
├── font_config.json # 字体配置文件（自动生成）  
└── Translation/ # 翻译文本 

---

## 🛠️ 开发工具链

| 工具 | 用途 | 链接 |
|------|------|------|
| **UABEA** | Unity资源编辑与导出 | [下载](https://github.com/nesrak1/UABEA/releases) |
| **Notepad++** | 文本批量处理 | [官网](https://notepad-plus-plus.org/) |
| **FontForge** | 字体参数修改 | [官网](https://fontforge.org/en-US/) |

---

## 🔤 字体替换方案

所有字体均符合 **OFL (SIL Open Font License)** 或类似开源商用协议，在保持原版风格的同时完美支持中文。

### 主要字体对应表
| 游戏原字体 | 替换字体 | 许可证 | 特点 |
|------------|----------|--------|------|
| **FuturaStd-CondensedBold**<br>（游戏内标题） | [MonuTitl-0.96CnBd](https://github.com/MY1L/Monu) | OFL | 全码区支持，适合标题 |
| **FuturaStd-CondensedBoldObl**<br>（倾斜标题） | MonuTitl + **倾斜9°** | OFL | 保持原版倾斜风格 |
| **monofonto**<br>（等宽文本） | [SarasaMonoSC-Bold](https://github.com/be5invis/Sarasa-Gothic) | OFL | 等宽字体，代码显示佳 |
| **JennaSue**<br>（手写风格） | [新叶念体](https://www.maoken.com/freefonts/701.html) | 免费商用 | 自然手写感 |
| **Boogaloo-Regular**<br>（圆润风格） | [字制区喜脉体](https://www.maoken.com/freefonts/8918.html) | 免费商用 | 可爱圆润 |
| **FontdinerSwanky**<br>（装饰风格） | [铁蒺藜体](https://github.com/Buernia/Tiejili) | OFL | 装饰性强 |
| **AIRSTREA**<br>（特殊标题） | [标小智龙珠体](https://github.com/fontworks-fonts/RocknRoll)<br>+ **倾斜12°** + **缩小78%** | OFL | 特殊效果处理 |

---

## 📂 文件夹说明

`Translation/` 文件夹包含：
- `LanguageSource_<版本号>_Original.txt` - 原版英文文本
- `LanguageSource_<版本号>_Patch.txt` - 完整重新翻译（可用UABEA直接导入回去）
- `PetsCustomizationData_<版本号>_Patch.txt` - 宠物名字翻译（可用UABEA直接导入回去）
- `translations.txt` - 完整最新翻译文本，插件用

`ChinesePatch/` 文件夹：插件源码  
`FontPatch/` 文件夹：字体补丁源码  

### 多语言适配
若想适配**繁体中文**或其他语言：
1. 替换字体为对应语言版本
2. 修改翻译文本

---

## ❓ 常见问题

### Q: 会影响游戏更新吗？
**A:** 不会。翻译是BepInEx外挂方式，不修改游戏文件；游戏更新赛季字体补丁会失效，重新安装即可。

### Q: 用了字体补丁后字体不一致怎么办？
**A:** 用记事本打开\Fallout Shelter\BepInEx\plugins\ChinesePatch\font_config.json，修改"Enabled"为false。

### Q: 如何恢复英文？
**A:** 删除或重命名 `ChinesePatch.dll` 文件即可，若想恢复英文字体，则删掉Fallout Shelter\FalloutShelter_Data\下面的data.unity3d，去掉data.unity3d.bak后缀的.bak。

### Q: 支持Steam/GOG/Xbox版本吗？
**A:** 理论上所有PC版本都支持，只要BepInEx能正常运行。

---

## 📄 许可证

字体文件遵循各自的开源许可证（OFL等）。  
代码部分采用 MIT 许可证。

**免责声明**: 本补丁仅供学习交流使用，请支持正版游戏。
