#region

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using Dalamud.Configuration;
using Newtonsoft.Json;
using WrathCombo.AutoRotation;
using WrathCombo.Window;
using WrathCombo.Attributes;
using WrathCombo.Window.Functions;
using WrathCombo.Window.Tabs;
using WrathCombo.Combos.PvE;
using WrathCombo.CustomComboNS.Functions;
using static WrathCombo.Attributes.SettingCategory.Category;
using static WrathCombo.CustomComboNS.Functions.CustomComboFunctions;
using Setting = WrathCombo.Attributes.Setting;
using Space = WrathCombo.Attributes.SettingUI_Space;
using Or = WrathCombo.Attributes.SettingUI_Or;
using Retarget = WrathCombo.Attributes.SettingUI_RetargetIcon;

#endregion

// ReSharper disable RedundantDefaultMemberInitializer

namespace WrathCombo.Core;

/// <summary> Plugin configuration. </summary>
[Serializable]
public partial class Configuration : IPluginConfiguration
{
    /// <summary> Gets or sets the configuration version. </summary>
    public int Version { get; set; } = 6;

    #region Settings

    #region UI Settings

    /// Whether to hide the children of a feature if it is disabled. Default: false.
    /// <seealso cref="Presets.DrawPreset"/>
    [SettingCategory(Main_UI_Options)]
    [Setting("隐藏子功能选项",
        "隐藏已禁用功能的子选项。",
        recommendedValue: "用户偏好",
        defaultValue: "关闭")]
    public bool HideChildren = false;

    /// Whether to hide combos which conflict with enabled presets. Default: false.
    /// <seealso cref="Presets.DrawPreset"/>
    /// <seealso cref="PvEFeatures.DrawHeadingContents"/>
    /// <seealso cref="PvPFeatures.DrawHeadingContents"/>
    [SettingCategory(Main_UI_Options)]
    [Setting("隐藏冲突连击",
        "隐藏与您已选择的其他连击冲突的连击。",
        recommendedValue: "用户偏好",
        defaultValue: "关闭")]
    public bool HideConflictedCombos = false;

    /// If the DTR Bar text should be shortened. Default: false.
    /// <seealso cref="WrathCombo.OnFrameworkUpdate"/>
    [SettingCategory(Main_UI_Options)]
    [Setting("简化服务器信息栏文本",
        "将不再显示已启用的自动模式连击数量。\n" +
        "默认情况下，Wrath Combo 的服务器信息栏会显示自动循环是否开启，\n" +
        "如果开启，则会显示已启用的自动模式连击数量。\n" +
        "最后还会显示是否有其他插件控制该值。",
        recommendedValue: "用户偏好",
        defaultValue: "关闭")]
    public bool ShortDTRText = false;

    /// Hides the message of the day. Default: false.
    /// <seealso cref="WrathCombo.PrintLoginMessage"/>
    [SettingCategory(Main_UI_Options)]
    [Setting("隐藏设置和取消设置命令反馈",
        "隐藏 /wrath set 和 /wrath unset 命令的聊天反馈。\n" +
        "(如果命令被IPC覆盖或失败，仍会显示反馈)",
        recommendedValue: "用户偏好",
        defaultValue: "关闭")]
    public bool SuppressSetCommands = false;

    /// Hides the Autorot set message. Default: false.
    /// <seealso cref="WrathCombo.PrintLoginMessage"/>
    [SettingCategory(Main_UI_Options)]
    [Setting("隐藏自动循环命令反馈",
        "隐藏 /wrath auto 命令的聊天反馈。",
        recommendedValue: "用户偏好",
        defaultValue: "关闭")]
    public bool SuppressAutorotCommand = false;

    /// Hides the message of the day. Default: false.
    /// <seealso cref="WrathCombo.PrintLoginMessage"/>
    [SettingCategory(Main_UI_Options)]
    [Setting("隐藏每日提示",
        "登录时不在聊天栏显示每日提示信息。",
        recommendedValue: "用户偏好",
        defaultValue: "关闭")]
    public bool HideMessageOfTheDay = false;

    /// Whether to draw a box around targeted party members. Default: false.
    /// <seealso cref="TargetHelper"/>
    /// <seealso cref="TargetHighlightColor"/>
    [SettingCategory(Main_UI_Options)]
    [Setting("显示目标高亮框",
        "在原生队员列表中，为部分功能锁定的目标队员绘制高亮框。",
        recommendedValue: "用户偏好",
        defaultValue: "关闭",
        extraText: "(当前仅用于占星和舞者)")]
    public bool ShowTargetHighlight = false;

    /// The color of box to draw around targeted party members. Default: 808080FF.
    /// <seealso cref="ShowTargetHighlight"/>
    /// <seealso cref="TargetHelper"/>
    [SettingParent(nameof(ShowTargetHighlight))]
    [SettingCategory(Main_UI_Options)]
    [Setting("高亮颜色",
        "用于设置队员高亮框的颜色。",
        recommendedValue: "用户偏好",
        defaultValue: "#808080FF",
        type: Setting.Type.Color)]
    public Vector4 TargetHighlightColor =
        new() { W = 1, X = 0.5f, Y = 0.5f, Z = 0.5f };

    /// Whether to draw a box around Presets with children. Default: true.
    /// <seealso cref="Presets.DrawPreset"/>
    /// <seealso cref="InfoBox"/>
    [SettingCategory(Main_UI_Options)]
    [Setting("为带有子功能或选项的连击和功能显示边框",
        "为包含其他功能和选项的连击或功能绘制边框，方便区分。",
        recommendedValue: "用户偏好",
        defaultValue: "开启")]
    public bool ShowBorderAroundOptionsWithChildren = true;

    /// Whether to label Presets with their ID. Default: true.
    /// <seealso cref="Presets.DrawPreset"/>
    [SettingCategory(Main_UI_Options)]
    [Setting("在描述前显示预设ID",
        "切换是否在描述前显示预设（连击、功能等）ID。\n" +
        "这些ID可用于如 `/wrath toggle <ID>` 等命令。\n" +
        "7.3版本前此处显示的数字更短，不是完整ID,无法用于命令。",
        recommendedValue: "开启",
        defaultValue: "开启")]
    public bool UIShowPresetIDs = true;

    /// Whether to show search bars. Default: true.
    /// <seealso cref="FeaturesWindow.DrawSearchBar"/>
    /// <seealso cref="ConfigWindow.Search"/>
    [SettingCategory(Main_UI_Options)]
    [Setting("在职业页显示搜索栏",
        "切换是否在所有PvE和PvP职业页顶部显示搜索栏",
        recommendedValue: "开启",
        defaultValue: "开启")]
    public bool UIShowSearchBar = true;

    #region Future Search Settings

    /// The preferred search behavior. Default: Filter.
    /// <seealso cref="FeaturesWindow.PresetMatchesSearch"/>
    /// <seealso cref="ConfigWindow.Search"/>
    /// <seealso cref="SearchMode"/>
    public SearchMode SearchBehavior = SearchMode.Filter;

    /// The search mode. Default: Filter.
    /// <seealso cref="Configuration.SearchBehavior"/>
    public enum SearchMode
    {
        /// Only shows matching Presets.
        Filter,
        /// Shows all Presets, but highlights matching ones.
        Highlight,
    }

    /// Whether to preserve hierarchy in Filter mode. Default: false.
    /// <seealso cref="Configuration.SearchBehavior"/>
    public bool SearchPreserveHierarchy = false;

    #endregion

    /// Whether, upon opening, it should always go to the PvE tab. Default: false.
    /// <seealso cref="WrathCombo.HandleOpenCommand"/>
    [Space]
    [SettingCategory(Main_UI_Options)]
    [Setting("打开Wrath时默认进入PvE功能页",
        "使用 `/wrath` 命令打开Wrath时，默认进入PvE功能页，而不是上次停留的标签页。" +
        "\n等同于每次都使用 `/wrath pve` 命令。",
        recommendedValue: "用户偏好",
        defaultValue: "关闭")]
    public bool OpenToPvE = false;

    /// Whether, upon opening, it should go to the PvP tab in PvP zones. Default: false.
    /// <seealso cref="WrathCombo.HandleOpenCommand"/>
    [SettingCategory(Main_UI_Options)]
    [Setting("在PvP区域打开Wrath时默认进入PvP功能页",
        "同上，在PvP区域使用 `/wrath` 命令时，默认进入PvP功能页，而不是上次停留的标签页。" +
        "\n类似于使用 `/wrath pvp` 命令。",
        recommendedValue: "用户偏好",
        defaultValue: "关闭")]
    public bool OpenToPvP = false;

    /// Whether the PvE Features tab should open to your current Job. Default: false.
    /// <seealso cref="PvEFeatures.OpenToCurrentJob"/>
    [SettingCategory(Main_UI_Options)]
    [Setting("打开PvE功能页时自动切换到当前职业",
        "打开Wrath界面时，如果上次停留在PvE页，将自动切换到当前所玩的职业。",
        recommendedValue: "用户偏好",
        defaultValue: "关闭")]
    public bool OpenToCurrentJob = false;

    /// Whether the PvE Features tab, upon switching jobs, should open to your new Job. Default: false.
    /// <seealso cref="PvEFeatures.OpenToCurrentJob"/>
    [SettingCategory(Main_UI_Options)]
    [Setting("切换职业时自动切换到对应PvE功能页",
        "切换职业时，PvE功能页会自动切换到当前所玩的职业。",
        recommendedValue: "用户偏好",
        defaultValue: "关闭")]
    public bool OpenToCurrentJobOnSwitch = false;

    #endregion

    #region Rotation Behavior Settings

    /// Whether all Combos should be <see cref="All.SavageBlade"/> when moving. Default: false.
    /// <seealso cref="ActionReplacer.GetAdjustedAction"/>
    [SettingCategory(Rotation_Behavior_Options)]
    [Setting("移动时阻止施法",
        "移动时完全阻止法术释放，会用狂怒剑替换你的技能。\n" +
        "此设置会覆盖大多数职业的连击专属移动选项。",
        recommendedValue: "Off (大部分职业的连击已能更优雅地处理移动)",
        defaultValue: "关闭")]
    public bool BlockSpellOnMove = false;

    /// Whether Hotbars will be walked, and matching actions updated. Default: true.
    /// <seealso cref="SetActionChanging" />
    /// <seealso cref="WrathCombo.HandleComboCommands" />
    [SettingCategory(Rotation_Behavior_Options)]
    [Setting("技能替换",
        "控制是否由插件拦截并替换技能为连击。\n" +
        "关闭后，你手动按下的技能将不再受Wrath设置影响。\n\n" +
        "自动循环无论此设置如何都可用。",
        recommendedValue: "开启（关闭此项相当于禁用Wrath大部分功能）",
        defaultValue: "开启",
        warningMark: "Wrath的设计核心是技能替换功能。\n关闭本项后，仅自动循环能正常工作。\n禁用后可能会影响重定向等功能，出现不可预期的问题。")]
    public bool ActionChanging = true;

    [SettingCategory(Rotation_Behavior_Options)]
    [Setting("自定义手动技能队列窗口期",
    "允许你自定义GCD期间可按键进入队列的时间范围，而不仅限于最后0.3-0.5秒。如果你不习惯连续按键，或在使用自动循环但需要手动介入时非常实用。",
    recommendedValue: "开启",
    defaultValue: "关闭")]
    public bool QueueAdjust = false;

    [SettingParent(nameof(QueueAdjust))]
    [SettingCategory(Rotation_Behavior_Options)]
    [Setting("允许队列时机",
        "当GCD剩余时间达到或少于此值时，允许将技能加入队列。",
        recommendedValue: "1.5-2.5",
        defaultValue: "1.5",
        warningMark: "设置过低或为零会使手动队列变得非常困难。",
        unitLabel: "秒",
        type: Setting.Type.Slider_Float,
        sliderMin: 0f,
        sliderMax: 2.5f)]
    public float QueueAdjustThreshold = 1.5f;

    [SettingCategory(Rotation_Behavior_Options)]
    [Setting("覆盖队列",
        "允许使用另一个技能覆盖当前排队的任何技能。",
        recommendedValue: "开启",
        defaultValue: "关闭")]
    public bool OverwriteQueue = false;

    /// The throttle for how often the hotbar gets walked. Default: 50.
    /// <seealso cref="ActionChanging"/>
    /// <seealso cref="ActionReplacer.GetAdjustedActionDetour"/>
    [SettingCategory(Rotation_Behavior_Options)]
    [Setting("技能更新节流",
        "限制连击功能更新热键栏技能的频率。\n" +
        "50毫秒时限制不大，始终为你提供最新的技能。\n\n" +
        "如果你希望获得一些（相当微小的）FPS提升，可以增加此值以降低连击运行频率。\n" +
        "这会使你的连击响应性降低，甚至可能卡GCD。\n" +
        "设置过高会导致GCD被卡住数秒或完全破坏循环。",
        recommendedValue: "20-200",
        defaultValue: "50",
        unitLabel: "毫秒",
        type: Setting.Type.Number_Int,
        sliderMin: 0,
        sliderMax: 500)]
    public int Throttle = 50;

    /// Delay before recognizing movement. Default: 0.
    /// <seealso cref="CustomComboFunctions.IsMoving"/>
    [SettingCategory(Rotation_Behavior_Options)]
    [Setting("移动判定延迟",
        "许多功能会检测你是否在移动，此项可设置需要持续移动多久才判定为移动。\n" +
        "这样可以避免短暂的小幅移动影响循环，主要用于法系职业。",
        recommendedValue: "0.0-1.0 (超过此值可能会破坏职业的移动选项)",
        defaultValue: "0.0",
        unitLabel: "秒",
        type: Setting.Type.Number_Float,
        sliderMin: 0,
        sliderMax: 10)]
    public float MovementLeeway = 0f;

    /// The timeout for opener failure. Default: 4.
    /// <seealso cref="CustomComboNS.WrathOpener.FullOpener"/>
    [SettingCategory(Rotation_Behavior_Options)]
    [Setting("起手失败超时",
        "控制起手过程中允许的无动作间隔时间，超过此时间将被视为起手失败并恢复正常循环。\n" +
        "对于某些法系职业可能需要增加此值，特别是当起手第一个技能是硬读条时。",
        recommendedValue: "4.0-7.0 (超过此值可能会严重影响起手)",
        defaultValue: "4.0",
        unitLabel: "秒",
        type: Setting.Type.Number_Float,
        sliderMin: 0,
        sliderMax: 20)]
    public float OpenerTimeout = 4f;

    /// The offset of the melee range check. Default: 0.
    /// <seealso cref="InMeleeRange"/>
    [SettingCategory(Rotation_Behavior_Options)]
    [Setting("近战距离偏移",
        "控制判定为近战范围的距离标准。\n" +
        "主要用于那些不希望在Boss稍微移出范围时就切换到远程攻击的玩家。\n" +
        "例如，设置为-0.5会要求你距离目标更近0.5码，\n" +
        "设置为2则允许你距离目标更远2码仍被视为在近战范围内\n" +
        "（近战技能实际无法使用，但会给你一些预警，而不是突然执行次优技能）。",
        recommendedValue: "0",
        defaultValue: "0",
        unitLabel: "码",
        type: Setting.Type.Number_Float,
        sliderMin: -3,
        sliderMax: 30)]
    public float MeleeOffset = 0;

    /// The % through a cast before interrupting. Default: 0.
    /// <seealso cref="CanInterruptEnemy"/>
    /// <seealso cref="CanStunToInterruptEnemy"/>
    [SettingCategory(Rotation_Behavior_Options)]
    [Setting("打断延迟",
        "控制在打断敌人施法前等待的施法时间百分比。\n" +
        "适用于所有职业连击中的所有打断技能（包括用于打断的眩晕技能）。",
        recommendedValue: "低于40 (超过此值会导致许多短读条技能打断失败)",
        defaultValue: "0",
        unitLabel: "施法进度百分比",
        type: Setting.Type.Slider_Int,
        sliderMin: 0,
        sliderMax: 100)]
    public float InterruptDelay = 0;

    /// The maximum allowable weaves between GCDs. Default: 2.
    /// <seealso cref="CanWeave"/>
    /// <seealso cref="CanDelayedWeave"/>
    [SettingCategory(Rotation_Behavior_Options)]
    [Setting("最大插入能力技数",
        "控制每个GCD之间允许插入的能力技数量。\n" +
        "游戏默认是双插，低延迟下也可以三插；如果你网络延迟较高，建议只用单插。\n" +
        "三插会尽量避免卡GCD，实际触发频率也不高，所以对大部分玩家来说是安全的。",
        recommendedValue: "2-3",
        defaultValue: "2",
        unitLabel: "个",
        type: Setting.Type.Slider_Int,
        sliderMin: 1,
        sliderMax: 3)]
    public int MaximumWeavesPerWindow = 2;

    #endregion

    #region Target Settings

    /// Whether to retarget heals to the Heal Stack. Default: false.
    /// <seealso cref="HealRetargeting"/>
    [SettingCategory(Targeting_Options)]
    [Setting("重定向（单体）治疗技能",
        "此项会将所有单体治疗技能重定向到下方的治疗目标堆栈。\n" +
        "类似于Redirect或Reaction的功能。\n" +
        "用于判断治疗技能触发阈值的目标和实际接受治疗的目标一致。",
        recommendedValue: "On (If you customize the Heal Stack AT ALL)",
        defaultValue: "关闭")]
    [Retarget]
    public bool RetargetHealingActionsToStack = false;

    /// Whether to include out-of-party NPCs to retargeting. Default: false.
    /// <seealso cref="GetPartyMembers"/>
    [SettingCategory(Targeting_Options)]
    [Setting("将非队伍NPC加入治疗重定向",
        "此项会将不在队伍中的NPC加入治疗技能的重定向逻辑。\n\n" +
        "适用于希望治疗任务NPC等非队友目标的奶妈。\n\n" +
        "这些NPC无法参与基于职业的自定义堆栈\n" +
        "（即使NPC看起来像防护职业，也不会被识别为防护职业）。",
        recommendedValue: "On (If you use Retargeting at all)",
        defaultValue: "关闭")]
    public bool AddOutOfPartyNPCsToRetargeting = false;

    #region Default+ Heal Stack

    /// Whether to include UI Mouseover in 'default' Heal Stack. Default: false.
    /// <seealso cref="CustomComboNS.SimpleTarget.Stack.GetStack"/>
    [SettingCategory(Targeting_Options)]
    // The spaces make it align better with the raise stack collapsible group
    [SettingCollapsibleGroup("治疗堆栈自定义选项  ")]
    [SettingGroup("defaultPlus", "healStackPlus")]
    [Setting("添加UI-鼠标悬停目标到默认治疗堆栈",
        "此选项会将任何UI鼠标悬停目标添加到默认治疗堆栈的顶部，如果你将鼠标悬停在任何队员UI上，将覆盖堆栈的其余部分。\n\n" +
        "如果你是键鼠用户，并启用了重定向治疗技能（或在Redirect/Reaction插件的配置中有UI鼠标悬停目标），推荐启用此项时。",
        recommendedValue: "用户偏好",
        defaultValue: "关闭")]
    public bool UseUIMouseoverOverridesInDefaultHealStack = false;
    
    /// Whether to include UI Mouseover in 'default' Heal Stack. Default: false.
    /// <seealso cref="CustomComboNS.SimpleTarget.Stack.GetStack"/>
    [SettingCategory(Targeting_Options)]
    [SettingCollapsibleGroup("治疗堆栈自定义选项  ")]
    [SettingGroup("defaultPlus", "healStackPlus")]
    [Setting("添加场地鼠标悬停目标到默认治疗堆栈",
        "此选项会将任何场地鼠标悬停目标添加到默认治疗堆栈的顶部，如果你将鼠标悬停在任何队员上，将覆盖堆栈的其余部分。\n\n" +
        "如果你是键鼠用户，并启用了重定向治疗技能（或在Redirect/Reaction插件的配置中有场地鼠标悬停目标），推荐启用此项。",
        recommendedValue: "用户偏好",
        defaultValue: "关闭")]
    public bool UseFieldMouseoverOverridesInDefaultHealStack = false;
    
    /// Whether to include Focus Target in 'default' Heal Stack. Default: false.
    /// <seealso cref="CustomComboNS.SimpleTarget.Stack.GetStack"/>
    [SettingCategory(Targeting_Options)]
    [SettingCollapsibleGroup("治疗堆栈自定义选项  ")]
    [SettingGroup("defaultPlus", "healStackPlus")]
    [Setting("将焦点目标添加到默认治疗堆栈",
        "此选项会将你的焦点目标添加到默认治疗堆栈的软目标和硬目标之后，如果你有存活的焦点目标，将覆盖堆栈的其余部分。",
        recommendedValue: "用户偏好",
        defaultValue: "关闭")]
    public bool UseFocusTargetOverrideInDefaultHealStack = false;
    
    /// Whether to include Lowest HP% in 'default' Heal Stack. Default: false.
    /// <seealso cref="CustomComboNS.SimpleTarget.Stack.GetStack"/>
    [SettingCategory(Targeting_Options)]
    [SettingCollapsibleGroup("治疗堆栈自定义选项  ")]
    [SettingGroup("defaultPlus", "healStackPlus")]
    [Setting("将最低HP%队友添加到默认治疗堆栈",
        "此选项会将附近HP百分比最低的队友添加到默认治疗堆栈的底部，仅覆盖你自己。",
        recommendedValue: "用户偏好",
        defaultValue: "关闭",
        warningMark: "与其他默认+选项不同，" +
                     "此选项在大多数其他重定向插件中都不存在。\n" +
                     "此选项应与上方的'重定向治疗技能'设置一起使用！")]
    public bool UseLowestHPOverrideInDefaultHealStack = false;

    #endregion

    #region Custom Heal Stack

    /// Whether to use a Custom Heal Stack. Default: false.
    /// <seealso cref="CustomComboNS.SimpleTarget.Stack.GetStack"/>
    /// <seealso cref="HealRetargeting.RetargetSettingOn"/>
    [Or]
    [SettingCollapsibleGroup("治疗堆栈自定义选项  ")]
    [SettingGroup("custom", "healStackPlus", false)]
    [SettingCategory(Targeting_Options)]
    [Setting("使用自定义治疗堆栈",
        "如果你希望自定义治疗目标优先级堆栈而不是使用默认堆栈，请选择此项。\n\n" +
        "如果你没有使用重定向治疗技能设置，建议根据你的Redirect/Reaction插件配置进行自定义，否则按个人喜好。",
        recommendedValue: "用户偏好",
        defaultValue: "关闭")]
    public bool UseCustomHealStack = false;

    /// The Custom Heal Stack.
    /// <seealso cref="CustomComboNS.SimpleTarget.Stack.GetStack"/>
    /// <seealso cref="HealRetargeting.HealStack"/>
    /// <seealso cref="CustomComboNS.SimpleTarget.Stack.AllyToHeal"/>
    [SettingCollapsibleGroup("治疗堆栈自定义选项  ")]
    [SettingParent(nameof(UseCustomHealStack))]
    [SettingCategory(Targeting_Options)]
    [Setting("自定义治疗堆栈",
        "如果少于4个项目，且全部检查无效，则会回退到自己。\n\n" +
        "仅在目标为友方且在25米范围内时才有效。\n\n" +
        "当此堆栈用于复活或康复时，将检查目标是否死亡或有可净化的异常。\n" +
        "因此，不需要再额外添加诸如 “任意可驱散的友方” 之类的目标条件。",
        recommendedValue: "用户偏好",
        defaultValue: "焦点目标 > 硬目标 > 自己",
        type: Setting.Type.Stack,
        stackStringsToExclude:
        ["Enemy", "Attack", "Dead", "Living"])]
    public string[] CustomHealStack =
    [
        "FocusTarget",
        "HardTarget",
        "Self",
    ];

    #endregion

    /// The Custom Raise Stack.
    /// <seealso cref="CustomComboNS.SimpleTarget.Stack.GetStack"/>
    /// <seealso cref="CustomComboNS.SimpleTarget.Stack.AllyToRaise"/>
    [SettingCollapsibleGroup("复活堆栈自定义选项")]
    [SettingCategory(Targeting_Options)]
    [Setting("自定义复活堆栈",
        "这是Wrath尝试选择复活目标的优先级顺序，\n" +
        "当任何复活功能的重定向功能启用时生效。\n\n" +
        "你可以在PvE>通用设置下找到复活功能，\n" +
        "或在每个拥有复活技能的职业下找到。\n\n" +
        "如果少于5个项目，且全部检查无效，则会回退到：\n" +
        "你的硬目标（如果已死亡），或<任意死亡队员>。\n\n"+
        "这些目标只有在友方、死亡且在30米范围内时才被视为有效。\n",
        recommendedValue: "用户偏好",
        defaultValue: "任意治疗 > 任意坦克 > 任意复活职业 > 任意死亡队员",
        type: Setting.Type.Stack,
        extraText: "(所有目标都会检查是否可被复活)",
        stackStringsToExclude:
        ["Enemy", "Attack", "MissingHP", "Lowest", "Chocobo", "Living"])]
    public string[] RaiseStack =
    [
        "AnyHealer",
        "AnyTank",
        "AnyRaiser",
        "AnyDeadPartyMember",
    ];

    #endregion

    #region Troubleshooting

    /// Whether to output Combo actions to the chatbox.
    /// <seealso cref="Data.ActionWatching.UpdateLastUsedAction"/>
    [SettingCategory(Troubleshooting_Options)]
    [Setting("输出日志到聊天",
        "每次你通过Wrath使用技能时，插件都会将其输出到聊天。",
        recommendedValue: "On (IF trying to report an issue)",
        defaultValue: "关闭")]
    public bool EnabledOutputLog = false;

    /// Whether to output Opener state to the chatbox.
    /// <seealso cref="CustomComboNS.WrathOpener.CurrentState"/>
    [SettingCategory(Troubleshooting_Options)]
    [Setting("输出起手状态到聊天",
        "每当你的职业起手准备好、失败或如预期完成时，都会输出到聊天。",
        recommendedValue: "开启（如果尝试排查起手问题）",
        defaultValue: "关闭")]
    public bool OutputOpenerLogs;

    #endregion

    #endregion

    #region Non-Settings Configurations

    public bool UILeftColumnCollapsed = false;

    public bool ShowHiddenFeatures = false;

    #region EnabledActions

    /// <summary> Gets or sets the collection of enabled combos. </summary>
    [JsonProperty("EnabledActionsV6")]
    public HashSet<Preset> EnabledActions { get; set; } = [];

    #endregion

    #region AutoAction Settings

    public Dictionary<Preset, bool> AutoActions { get; set; } = [];

    public AutoRotationConfig RotationConfig { get; set; } = new();

    public Dictionary<uint, uint> IgnoredNPCs { get; set; } = new();

    #endregion

    #region Job-specific

    /// <summary> Gets active Blue Mage (BLU) spells. </summary>
    public List<uint> ActiveBLUSpells { get; set; } = [];

    /// <summary>
    ///     Gets or sets an array of 4 ability IDs to interact with the
    ///     <see cref="Preset.DNC_CustomDanceSteps" /> combo.
    /// </summary>
    public uint[] DancerDanceCompatActionIDs { get; set; } = [0, 0, 0, 0,];

    #endregion

    #region Popups

    /// <summary>
    ///     Whether the Major Changes window was hidden for a
    ///     specific version.
    /// </summary>
    /// <seealso cref="MajorChangesWindow" />
    public Version HideMajorChangesForVersion =
        System.Version.Parse("0.0.0");

    #endregion

    #region UserConfig Values

    [JsonProperty("CustomFloatValuesV6")]
    internal static Dictionary<string, float>
        CustomFloatValues { get; set; } = [];

    [JsonProperty("CustomIntValuesV6")]
    internal static Dictionary<string, int>
        CustomIntValues { get; set; } = [];

    [JsonProperty("CustomIntArrayValuesV6")]
    internal static Dictionary<string, int[]>
        CustomIntArrayValues { get; set; } = [];

    [JsonProperty("CustomBoolValuesV6")]
    internal static Dictionary<string, bool>
        CustomBoolValues { get; set; } = [];

    [JsonProperty("CustomBoolArrayValuesV6")]
    internal static Dictionary<string, bool[]>
        CustomBoolArrayValues { get; set; } = [];

    #endregion

    public HashSet<(ushort Status, uint BaseId)> StatusBlacklist = [];

    #endregion
}