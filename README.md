<section id="top">
    <p style="text-align:center;" align="center">
        <img align="center" src="/res/plugin/wrathcombo.png" width="250" />
    </p>
    <h1 style="text-align:center;" align="center">Wrath Combo</h1>
    <p style="text-align:center;" align="center">
        将连击和互斥技能整合到单个按键上，以及更多功能。
    </p>
</section>

<!-- Badges -->
<p align="center"> 
<!-- Build & commit activity -->
  <!--no workflow on wrathcombo yet <a href="https://github.com/PunishXIV/WrathCombo/actions/workflows/build.yml" alt="Build">
    <img src="https://img.shields.io/github/actions/workflow/status/PunishXIV/WrathCombo/build.yml?branch=main&style=for-the-badge" /></a>-->
  <a href="https://github.com/PunishXIV/WrathCombo/commits/main" alt="Commits">
    <img src="https://img.shields.io/github/last-commit/PunishXIV/WrathCombo/main?color=00D162&style=for-the-badge" /></a>
   <a href="https://github.com/PunishXIV/WrathCombo/commits/main" alt="Commit Activity">
    <img src="https://img.shields.io/github/commit-activity/m/PunishXIV/WrathCombo?color=00D162&style=for-the-badge" /></a>
  <br> 
<!-- Other -->
  <a href="https://github.com/PunishXIV/WrathCombo/issues" alt="Open Issues">
    <img src="https://img.shields.io/github/issues-raw/PunishXIV/WrathCombo?color=EA9C0A&style=for-the-badge" /></a>
  <a href="https://github.com/PunishXIV/WrathCombo/graphs/contributors" alt="Contributors">
    <img src="https://img.shields.io/github/contributors/PunishXIV/WrathCombo?color=009009&style=for-the-badge" /></a>
<br>
<!-- Version -->
  <a href="https://github.com/PunishXIV/WrathCombo/tags" alt="Release">
    <img src="https://img.shields.io/github/v/tag/PunishXIV/WrathCombo?label=Release&logo=git&logoColor=ffffff&style=for-the-badge" /></a>
<br>
  <a href="https://discord.gg/Zzrcc8kmvy" alt="Discord">
    <img src="https://discordapp.com/api/guilds/1001823907193552978/embed.png?style=banner2" /></a>
</p>

<br><br>

<section id="localization">

## 关于汉化

机翻自用，创建此仓库只为将更新推送给CP。<br>
咸鱼玩家，大部分职业未满级，对输出循环没什么理解。<br>
调用 DeepSeek-V3 API 进行自动翻译，可能并不符合游戏术语。<br>

</section>

<section id="about">

# 关于 Wrath Combo

<p> Wrath Combo 是 <a href="https://goatcorp.github.io/" alt="XIVLauncher">XIVLauncher</a> 的一个插件。<br><br>
    它是 XIVCombo 插件的增强版，提供高度可定制的功能和选项，让用户可以根据需求调整输出循环的复杂度，甚至简化到只需一个按键；适用于 PvE、PvP 等场景。
    <br><br>
    Wrath Combo 会定期更新，以包含新功能并适配《最终幻想14》的最新职业改动。
    <br><br>
    <img src="/res/readme_images/demo.gif" width="450" />
    <br>
    在该演示中，插件被配置为将一个职业的整个循环压缩到单个按键上，
    该按键被反复按下 - 所有执行的动作都显示在时间轴上进行演示。
</p>
</section>

<!-- Installation -->
<section>

# 安装

<img src="/res/readme_images/adding_repo.jpg" width="450" />

在游戏中打开 Dalamud 设置菜单并按照以下步骤操作。
可以通过插件安装器底部的按钮或在聊天中输入 `/xlsettings` 来完成。

1. 在自定义插件仓库下，在底部的空白框中输入 `https://love.puni.sh/ment.json`。
2. 点击"+"按钮。
3. 点击"保存并关闭"按钮。

在游戏中打开 Dalamud 插件安装器菜单并按照以下步骤操作。
可以通过在聊天中输入 `/xlplugins` 来完成。

1. 点击左侧的"所有插件"标签页。
2. 搜索"Wrath Combo"。
3. 点击"安装"按钮。

<p align="right"><a href="#top" alt="返回顶部"><img src=/res/readme_images/arrowhead-up.png width ="25"/></a></p>
</section> <br>

<!-- Features -->
<section>

# 功能特性

下面您可以找到我们在 Wrath Combo 中提供的一些功能和选项的小示例。<br>
请注意，这只是摘录，并不代表完整的功能集。


  <details><summary>PvE 功能</summary> <br>

 - 许多职业的"简单"（一键）模式
 - 许多职业的"高级"模式，可以根据需要简化
 - 自动循环，根据您的设置自动执行循环
 - 特殊副本（多变迷宫）专用功能
<br><br>
 - 防护职业双重雪仇保护
 - 防护职业打断功能
 - 治疗职业复活功能
 - 魔法远程DPS双重昏乱保护
 - 魔法远程DPS复活功能
 - 近战DPS双重牵制保护
 - 近战DPS真北保护
 - 物理远程DPS双重减伤保护
 - 物理远程DPS打断功能
    
 还有更多功能！

  </details>

  <details><summary>PvP 功能</summary> <br>

 - 所有职业的"爆发模式"攻击功能
 - 紧急治疗
 - 紧急防护
 - 快速净化
 - 防护取消预防
    
 还有更多功能！

  </details>

  <details><summary>其他功能</summary> <br>

- 无人岛冲刺功能
- [园艺/采矿] 优雷卡功能
- [园艺/采矿] 定位与真相功能
- [捕鱼] 抛竿到上钩功能
- [捕鱼] 潜水功能

 还有更多功能！

  </details>

要体验我们提供的完整功能集，请<a href="#installation" alt="安装">安装</a>插件或访问 [Discord](https://discord.gg/Zzrcc8kmvy) 服务器获取更多信息。

<p align="right"><a href="#top" alt="返回顶部"><img src=/res/readme_images/arrowhead-up.png width ="25"/></a></p>

## 与其他插件配合使用

### [Orbwalker](https://puni.sh/plugin/Orbwalker)

Wrath Combo 可以使用 Orbwalker 在自动循环模式下停止玩家移动，而不需要玩家在选择施法前手动停止移动。

1. 打开 Wrath Combo 的自动循环设置：`/wrath autosettings`。
2. 勾选"启用 Orbwalker 集成"。
3. 打开 Orbwalker 并确认您的设置：`/orbwalker`。

### [AutoDuty](https://github.com/ffxivcode/AutoDuty)

Wrath Combo 可以作为 AutoDuty 的循环引擎，使得 Wrath Combo 的自动循环将在副本中使用。
要启用此功能：
1. 打开 AutoDuty 的配置窗口：`/autoduty cfg`。
2. 展开"副本配置设置"部分。
3. 启用"自动管理循环插件状态"。
4. （同时勾选"> Wrath 配置选项 <" -> "为自动循环自动设置职业"）\
   （如果您已经设置好职业，可以跳过此步骤）

### [Questionable](https://git.carvel.li/liza/Questionable)

Wrath Combo 可以作为 Questionable 的战斗模块，使得 Wrath Combo 的自动循环将在任务期间使用。
要启用此功能：
1. 打开 Questionable 的设置窗口：`/qst config`。
2. 转到"常规"标签页。
3. 选择"Wrath Combo"作为"首选战斗模块"。

> 默认情况下，上述两个插件将确保 Wrath 中的连击已设置好，
并且如果连击未设置，将锁定这些连击下的所有设置为 `开启`，
以确保循环能够运行。

  <p align="right"><a href="#top" alt="返回顶部"><img src=/res/readme_images/arrowhead-up.png width ="25"/></a></p>
</section> 

<!-- Commands -->
<section>

# 命令

| **聊天命令**                           | **功能**                                                                                                                                                                   |
|:---------------------------------------|:---------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| `/wrath`                               | 切换主插件窗口，您可以在其中启用/禁用功能、访问设置等。                                                                                                                       |
| `/wrath pve`                           | 打开主插件窗口，转到PvE标签页。                                                                                                                                            |
| `/wrath pvp`                           | 打开主插件窗口，转到PvP标签页。                                                                                                                                            |
| `/wrath settings`                      | 打开主插件窗口，转到设置标签页。                                                                                                                                           |
| `/wrath autosettings`                  | 打开主插件窗口，转到自动循环标签页。                                                                                                                                       |
| `/wrath <X>`                           | 打开主插件窗口，转到特定职业的PvE功能。<br>将 `<X>` 替换为职业缩写。                                                                                                       |
| `/wrath auto`                          | 切换自动循环**开启**或**关闭**。                                                                                                                                         |
| `/wrath auto <X>`                      | 将自动循环设置为特定状态。<br>将 `<X>` 替换为 `on`、`off` 或 `toggle`。                                                                                                  |
| `/wrath auto target <X> <Y>`           | 设置自动循环目标模式。<br>将 `<X>` 替换为 `damage` 或 `healer`。<br>对于伤害，`<Y>` 可以是：`manual`、`highest_max`、`lowest_max`、`highest_current`、`lowest_current`、`tank_target`、`nearest`、`furthest`。<br>对于治疗，`<Y>` 可以是：`manual`、`highest_current`、`lowest_current`。                |
| `/wrath combo`                         | 切换动作替换**开启**或**关闭**。<br>关闭时，动作不会被插件的连击替换。自动循环仍将工作。                                                                               |
| `/wrath combo <X>`                     | 将动作替换设置为特定状态。<br>将 `<X>` 替换为 `on`、`off` 或 `toggle`。                                                                                                  |
| `/wrath ignore`                        | 将目标NPC及其所有实例添加到自动循环自动目标的忽略列表中。<br>在自动循环标签页中管理此列表。                                                                              |
| `/wrath toggle <X>`                    | 切换特定功能或选项**开启**或**关闭**。在战斗中不起作用。<br>将 `<X>` 替换为其内部名称（或ID）。                                                                        |
| `/wrath set <X>`                       | 将特定功能/选项**开启**。在战斗中不起作用。<br>将 `<X>` 替换为其内部名称（或ID）。                                                                                     |
| `/wrath unset <X>`                     | 将特定功能/选项**关闭**。在战斗中不起作用。<br>将 `<X>` 替换为其内部名称（或ID）。                                                                                     |
| `/wrath unsetall`                      | 一次性将所有功能和选项**关闭**。                                                                                                                                         |
| `/wrath list ...`                      | 根据过滤参数将功能的内部名称列表打印到游戏聊天中。<br>需要附加过滤器。见下文。                                                                                           |
| `/wrath list set`<br/>`/wrath enabled` | 将所有当前启用的功能和选项列表打印到游戏聊天中。                                                                                                                         |
| `/wrath list unset`                    | 将所有当前禁用的功能和选项列表打印到游戏聊天中。                                                                                                                         |
| `/wrath list all`                      | 将每个功能和选项列表打印到游戏聊天中，无论状态如何。                                                                                                                     |
| `/wrath list ... <X>`                  | 所有列表命令也可以可选地接受职业参数，将列表筛选到特定职业。<br>将 `<X>` 替换为职业缩写。                                                                             |
| `/wrath opener`                        | 输出你当前的起手状态到聊天信息。                                                                                                                                   |
| `/wrath debug`                         | 输出调试文件到桌面，仅包含您当前职业的相关功能/选项。<br>发送给开发者，帮助修复错误。完全匿名。                                                                       |
| `/wrath debug <X>`                     | 输出仅包含职业相关功能/选项的调试文件。<br>将 `<X>` 替换为职业缩写。                                                                                                   |
| `/wrath debug all`                     | 输出包含所有功能/选项的调试文件。                                                                                                                                       |

<p align="right"><a href="#top" alt="返回顶部"><img src=/res/readme_images/arrowhead-up.png width ="25"/></a></p>
</section>

<!-- Contributing -->
<section>

# 贡献

我们始终欢迎对项目的贡献 - 请随时在 GitHub 上提交[拉取请求](https://github.com/PunishXIV/WrathCombo/pulls)，但最好在 [Discord](https://discord.gg/Zzrcc8kmvy) 服务器上与我们联系，这样我们可以相互交流，进行必要的更改并审查您的提交！

您还可以在[贡献信息](CONTRIBUTING.md)和[可用指南](CONTRIBUTING.md#guides-on-using-specific-parts-of-wrath)中找到入门帮助。

   <p align="right"><a href="#top" alt="返回顶部"><img src=/res/readme_images/arrowhead-up.png width ="25"/></a></p>
</section>

<br><br>

<!-- Attribution -->
<div align="center">
  <a href="https://puni.sh/" alt="Puni.sh">
    <img src="https://github.com/PunishXIV/AutoHook/assets/13919114/a8a977d6-457b-4e43-8256-ca298abd9009" /></a>
<br>
  <a href="https://discord.gg/Zzrcc8kmvy" alt="Discord">
    <img src="https://discordapp.com/api/guilds/1001823907193552978/embed.png?style=banner2" /></a>
</div>
