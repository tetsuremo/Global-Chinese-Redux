# 汉化补丁 to 2.0.2 
![进度](https://img.shields.io/badge/进度-99%25-orange?style=flat-square)

除人名外，全文本包括宠物名字。

本汉化版源于我的强迫症：因无法接受直译文本以及默认字体在UI上的粗糙表现，特此制作了这个从翻译到视觉完全优化的汉化补丁。

参考了之前1.13.13汉化版本老哥贴出来的教程。

https://steamcommunity.com/sharedfiles/filedetails/?id=2877972565

---

## 🛠️ 使用到的工具

* **AssetRipper**: [解包/资源溯源](https://github.com/AssetRipper/AssetRipper/releases)
* **Notepad++**: [文本批量编辑](https://notepad-plus-plus.org/)
* **UABEA (Unity Assets Bundle Extractor Avalonia)**: [文本资源导入/导出](https://github.com/nesrak1/UABEA/releases)
* **FontForge**: [字体参数修改与封装](https://fontforge.org/en-US/)
* **Unity 6000.0.58f2**: 资源重新打包

---

## 🛠️ 字体资源清单

为了匹配游戏内部资源链接，全部字体都修改了名字。在保持原版英文风格的同时，所有选定字体均符合 **OFL (SIL Open Font License)** 或类似开源商用协议。

* **FuturaStd-CondensedBold（典迹题幕）**
    * 采用字体：[MonuTitl-0.96CnBd](https://github.com/MY1L/Monu/releases/tag/Titl) (全码区)

* **FuturaStd-CondensedBoldObl（典迹题幕 - 自行修改版）**
    * 采用字体：同上
    * 额外修改： **倾斜 9°**。

* **monofonto（等距更紗黑）**
    * 采用字体：[SarasaMonoSC-Bold](https://github.com/be5invis/Sarasa-Gothic) (全码区)

* **JennaSue (新叶念体)**
    * 采用字体：[新叶念体](https://www.maoken.com/freefonts/701.html) (纯简体)

* **Boogaloo-Regular (字制区喜脉体)**
    * 采用字体：[字制区喜脉体](https://www.maoken.com/freefonts/8918.html) (纯简体)

* **FontdinerSwanky (铁蒺藜体)**
    * 采用字体：[铁蒺藜体](https://github.com/Buernia/Tiejili) (简体 + 日文汉字)

* **AIRSTREA (荊南波波黑 - 自行修改版)**
    * 采用字体：[Kingnam Bobohei](https://github.com/maoken-fonts/KNBobohei) (简体 + 日文汉字)
    * 额外修改：**倾斜 9°** + **宽度缩至 80%**。
	
---

**另外说明：**
在Github链接中，Translation文件夹里有我做好的简体中文翻译、以及原版的txt文件。若想完美匹配繁体版，请注意替换掉上述列表里的四个简体字体（新叶念、字制区喜脉、铁蒺藜、荆南波波黑），并建议将典迹题幕与更纱黑自行更换为对应的TC/繁体版本，否则部分汉字将以简体字形标准显示，或fallback到系统默认字体。
