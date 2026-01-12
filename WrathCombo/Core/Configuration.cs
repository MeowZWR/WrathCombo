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
        recommendedValue: "Preference",
        defaultValue: "Off")]
    public bool HideChildren = false;

    /// Whether to hide combos which conflict with enabled presets. Default: false.
    /// <seealso cref="Presets.DrawPreset"/>
    /// <seealso cref="PvEFeatures.DrawHeadingContents"/>
    /// <seealso cref="PvPFeatures.DrawHeadingContents"/>
    [SettingCategory(Main_UI_Options)]
    [Setting("隐藏冲突连击",
        "隐藏与您已选择的其他连击冲突的连击。",
        recommendedValue: "Preference",
        defaultValue: "Off")]
    public bool HideConflictedCombos = false;

    /// If the DTR Bar text should be shortened. Default: false.
    /// <seealso cref="WrathCombo.OnFrameworkUpdate"/>
    [SettingCategory(Main_UI_Options)]
    [Setting("简化服务器信息栏文本",
        "将不再显示已启用的自动模式连击数量。\n" +
        "默认情况下，Wrath Combo 的服务器信息栏会显示自动循环是否开启，\n" +
        "如果开启，则会显示已启用的自动模式连击数量。\n" +
        "最后还会显示是否有其他插件控制该值。",
        recommendedValue: "Preference",
        defaultValue: "Off")]
    public bool ShortDTRText = false;

    /// Hides the message of the day. Default: false.
    /// <seealso cref="WrathCombo.PrintLoginMessage"/>
    [SettingCategory(Main_UI_Options)]
    [Setting("隐藏设置和取消设置命令反馈",
        "隐藏 /wrath set 和 /wrath unset 命令的聊天反馈。\n" +
        "(如果命令被IPC覆盖或失败，仍会显示反馈)",
        recommendedValue: "Preference",
        defaultValue: "Off")]
    public bool SuppressSetCommands = false;

    /// Hides the Autorot set message. Default: false.
    /// <seealso cref="WrathCombo.PrintLoginMessage"/>
    [SettingCategory(Main_UI_Options)]
    [Setting("Suppress Auto-Rotation commands feedback",
        "Will hide chat feedback for /wrath auto commands",
        recommendedValue: "Preference",
        defaultValue: "Off")]
    public bool SuppressAutorotCommand = false;

    /// Hides the message of the day. Default: false.
    /// <seealso cref="WrathCombo.PrintLoginMessage"/>
    [SettingCategory(Main_UI_Options)]
    [Setting("隐藏每日提示",
        "登录时不在聊天栏显示每日提示信息。",
        recommendedValue: "Preference",
        defaultValue: "Off")]
    public bool HideMessageOfTheDay = false;

    /// Whether to draw a box around targeted party members. Default: false.
    /// <seealso cref="TargetHelper"/>
    /// <seealso cref="TargetHighlightColor"/>
    [SettingCategory(Main_UI_Options)]
    [Setting("显示目标高亮框",
        "在原生队员列表中，为部分功能锁定的目标队员绘制高亮框。",
        recommendedValue: "Preference",
        defaultValue: "Off",
        extraText: "(当前仅用于占星和舞者)")]
    public bool ShowTargetHighlight = false;

    /// The color of box to draw around targeted party members. Default: 808080FF.
    /// <seealso cref="ShowTargetHighlight"/>
    /// <seealso cref="TargetHelper"/>
    [SettingParent(nameof(ShowTargetHighlight))]
    [SettingCategory(Main_UI_Options)]
    [Setting("高亮颜色",
        "用于设置队员高亮框的颜色。",
        recommendedValue: "Preference",
        defaultValue: "#808080FF",
        type: Setting.Type.Color)]
    public Vector4 TargetHighlightColor =
        new() { W = 1, X = 0.5f, Y = 0.5f, Z = 0.5f };

    /// Whether to draw a box around Presets with children. Default: true.
    /// <seealso cref="Presets.DrawPreset"/>
    /// <seealso cref="InfoBox"/>
    [SettingCategory(Main_UI_Options)]
    [Setting("Show Borders around Combos and Features with Options",
        "Will draw a border around Combos and Features that have Features and Options of their own.",
        recommendedValue: "Preference",
        defaultValue: "On")]
    public bool ShowBorderAroundOptionsWithChildren = true;

    /// Whether to label Presets with their ID. Default: true.
    /// <seealso cref="Presets.DrawPreset"/>
    [SettingCategory(Main_UI_Options)]
    [Setting("在描述前显示预设ID",
        "切换是否在描述前显示预设（连击、功能等）ID。\n" +
        "这些ID可用于如 `/wrath toggle <ID>` 等命令。\n" +
        "7.3版本前此处显示的数字更短，不是完整ID,无法用于命令。",
        recommendedValue: "On",
        defaultValue: "On")]
    public bool UIShowPresetIDs = true;

    /// Whether to show search bars. Default: true.
    /// <seealso cref="FeaturesWindow.DrawSearchBar"/>
    /// <seealso cref="ConfigWindow.Search"/>
    [SettingCategory(Main_UI_Options)]
    [Setting("在职业页显示搜索栏",
        "切换是否在所有PvE和PvP职业页顶部显示搜索栏",
        recommendedValue: "On",
        defaultValue: "On")]
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
        recommendedValue: "Preference",
        defaultValue: "Off")]
    public bool OpenToPvE = false;

    /// Whether, upon opening, it should go to the PvP tab in PvP zones. Default: false.
    /// <seealso cref="WrathCombo.HandleOpenCommand"/>
    [SettingCategory(Main_UI_Options)]
    [Setting("在PvP区域打开Wrath时默认进入PvP功能页",
        "同上，在PvP区域使用 `/wrath` 命令时，默认进入PvP功能页，而不是上次停留的标签页。" +
        "\n类似于使用 `/wrath pvp` 命令。",
        recommendedValue: "Preference",
        defaultValue: "Off")]
    public bool OpenToPvP = false;

    /// Whether the PvE Features tab should open to your current Job. Default: false.
    /// <seealso cref="PvEFeatures.OpenToCurrentJob"/>
    [SettingCategory(Main_UI_Options)]
    [Setting("打开PvE功能页时自动切换到当前职业",
        "打开Wrath界面时，如果上次停留在PvE页，将自动切换到当前所玩的职业。",
        recommendedValue: "Preference",
        defaultValue: "Off")]
    public bool OpenToCurrentJob = false;

    /// Whether the PvE Features tab, upon switching jobs, should open to your new Job. Default: false.
    /// <seealso cref="PvEFeatures.OpenToCurrentJob"/>
    [SettingCategory(Main_UI_Options)]
    [Setting("切换职业时自动切换到对应PvE功能页",
        "切换职业时，PvE功能页会自动切换到当前所玩的职业。",
        recommendedValue: "Preference",
        defaultValue: "Off")]
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
        defaultValue: "Off")]
    public bool BlockSpellOnMove = false;

    /// Whether Hotbars will be walked, and matching actions updated. Default: true.
    /// <seealso cref="SetActionChanging" />
    /// <seealso cref="WrathCombo.HandleComboCommands" />
    [SettingCategory(Rotation_Behavior_Options)]
    [Setting("技能替换",
        "控制是否由插件拦截并替换技能为连击。\n" +
        "关闭后，你手动按下的技能将不再受Wrath设置影响。\n\n" +
        "自动循环无论此设置如何都可用。",
        recommendedValue: "On (This is essentially turning OFF most of Wrath)",
        defaultValue: "On",
        warningMark: "Wrath is largely designed with Action Replacing in mind.\n" +
                     "Only Auto-Rotation will work if this is disabled.\n" +
                     "Disabling it may also lead to unexpected behavior, such as " +
                     "regarding Retargeting.")]
    public bool ActionChanging = true;

    /// Whether to suppress other combos when an action is queued. Default: true.
    /// <seealso cref="CustomComboNS.CustomCombo.TryInvoke"/>
    [SettingCategory(Rotation_Behavior_Options)]
    [Setting("Queued Action Suppression",
        "While Enabled:\n" +
        "When an action is Queued that is not the same as the button on the Hotbar, Wrath will disable every other Combo, preventing them from thinking the Queued action should trigger them.\n" +
        "- This prevents combos from conflicting with each other, with overlap in actions that combos return and actions that combos replace.\n" +
        "- This does however cause the Replaced Action for each combo to 'flash' through during Suppression.\n" +
        "That 'flashed' hotbar action won't go through, it is only visual.\n\n" +
        "While Disabled:\n" +
        "Combos will not be disabled when actions are queued from a combo.\n" +
        "- This prevents your hotbars 'flashing', that is the only real benefit.\n" +
        "- This does however allow Combos to conflict with each other, if one combo returns an action that another combo has as its Replaced Action.\n" +
        "We do NOT mark these types of conflicts, and we do NOT try to avoid them as we add new features",
        recommendedValue: "On (NO SUPPORT if off)",
        defaultValue: "On",
        extraHelpMark: "With this enabled, whenever you queue an action that is not the same as the button you are pressing, it will disable every other button's feature from running. " +
                       "This resolves a number of issues where incorrect actions are performed due to how the game processes queued actions, however the visual experience on your hotbars is degraded. " +
                       "This is not recommended to be disabled, however if you feel uncomfortable with hotbar icons changing quickly this is one way to resolve it but be aware that this may introduce unintended side effects to combos if you have a lot enabled for a job.\n\n" +
                       "For a more complicated explanation, whenever an action is used, the following happens:\n" +
                       "1. If the action invokes the GCD (Weaponskills & Spells), if the GCD currently isn't active it will use it right away.\n" +
                       "2. Otherwise, if you're within the \"Queue Window\" (normally the last 0.5s of the GCD), it gets added to the queue before it is used.\n" +
                       "3. If the action is an Ability, as long as there's no animation lock currently happening it will execute right away.\n" +
                       "4. Otherwise, it is added to the queue immediately and then used when the animation lock is finished.\n\n" +
                       "For step 1, the action being passed to the game is the original, unmodified action, which is then converted at use time. " +
                       "At step 2, things get messy as the queued action still remains the unmodified action, but when the queue is executed it treats it as if the modified action *is* the unmodified action.\n\n" +
                       "E.g. Original action Cure, modified action Cure II. At step 1, the game is okay to convert Cure to Cure II because that is what we're telling it to do. However, when Cure is passed to the queue, it treats it as if the unmodified action is Cure II.\n\n" +
                       "This is similar for steps 3 & 4, except it can just happen earlier.\n\n" +
                       "How this impacts us is if using the example before, we have a feature replacing Cure with Cure II, " +
                       "and another replacing Cure II with Regen and you enable both, the following happens:\n\n" +
                       "Step 1, Cure is passed to the game, is converted to Cure II.\n" +
                       "You press Cure again at the Queue Window, Cure is passed to the queue, however the queue when it goes to execute will treat it as Cure II.\n" +
                       "Result is instead of Cure II being executed, it's Regen, because we've told it to modify Cure II to Regen.\n" +
                       "This was not part of the first Feature, but rather the result of a Feature replacing an action you did not even press, therefore an incorrect action.\n\n" +
                       "Our workaround for this is to disable all other actions being replaced if they don't match the queued action, which this setting controls.",
        warningMark: "Wrath is entirely designed with Queued Action Suppression in mind.\n" +
                     "Disabling it WILL lead to unexpected behavior, which we DO NOT support.")]
    public bool SuppressQueuedActions = true;

    [SettingCategory(Rotation_Behavior_Options)]
    [Setting("Custom Manual Queue Window",
    "Allows you to adjust your queue window to any time during the GCD rather than just within the last 0.3-0.5s. Useful if you're not mashing " +
    "the key or using Auto-Rotation and wish to manually intervene.",
    recommendedValue: "On",
    defaultValue: "Off")]
    public bool QueueAdjust = false;

    [SettingParent(nameof(QueueAdjust))]
    [SettingCategory(Rotation_Behavior_Options)]
    [Setting("Allow Queueing At",
        "Will allow you to queue when the GCD is at this time or less.",
        recommendedValue: "1.5-2.5",
        defaultValue: "1.5",
        warningMark: "Setting this too low or to zero will make it really hard to manually queue.",
        unitLabel: "seconds",
        type: Setting.Type.Slider_Float,
        sliderMin: 0f,
        sliderMax: 2.5f)]
    public float QueueAdjustThreshold = 1.5f;

    /// The throttle for how often the hotbar gets walked. Default: 50.
    /// <seealso cref="ActionChanging"/>
    /// <seealso cref="ActionReplacer.GetAdjustedActionDetour"/>
    [SettingCategory(Rotation_Behavior_Options)]
    [Setting("Action Updater Throttle",
        "Will restrict how often Combos will update the Action on your Hotbar.\n" +
        "At 50ms it's not really restrictive, always giving you an up to date action.\n\n" +
        "If you are looking for some (fairly minor) FPS gains then you can increase this value to make Combos run less often.\n" +
        "This makes your combos less responsive, and perhaps even clips GCDs.\n" +
        "At high values this will clip your GCDs by several seconds or break your rotation altogether.",
        recommendedValue: "20-200",
        defaultValue: "50",
        unitLabel: "milliseconds",
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
        recommendedValue: "0.0-1.0 (Above that gets into the territory of breaking any Movement Options in your Job)",
        defaultValue: "0.0",
        unitLabel: "秒",
        type: Setting.Type.Number_Float,
        sliderMin: 0,
        sliderMax: 10)]
    public float MovementLeeway = 0f;

    /// The timeout for opener failure. Default: 4.
    /// <seealso cref="CustomComboNS.WrathOpener.FullOpener"/>
    [SettingCategory(Rotation_Behavior_Options)]
    [Setting("Opener Failure Timeout",
        "Controls how long of a gap with no action is allowed in an Opener, before it is considered failed and normal rotation is resumed.\n" +
        "Can be necessary for some casters to increase, particularly when the first action of an Opener is a hard-cast.",
        recommendedValue: "4.0-7.0 (Above that can really screw Openers)",
        defaultValue: "4.0",
        unitLabel: "秒",
        type: Setting.Type.Number_Float,
        sliderMin: 0,
        sliderMax: 20)]
    public float OpenerTimeout = 4f;

    /// The offset of the melee range check. Default: 0.
    /// <seealso cref="InMeleeRange"/>
    [SettingCategory(Rotation_Behavior_Options)]
    [Setting("Melee Distance Offset",
        "Controls what is considered to be in melee range.\n" +
        "Mainly for those who don't want to switch to ranged attacks if the boss walks slightly outside of range.\n" +
        "For example a value of -0.5 would make you have to be 0.5 yalms closer to the target,\n" +
        "or a value of 2 would allow you to be 2 yalms further away and still be considered in melee range\n" +
        "(melee actions wouldn't work, but it would give you some warning instead of just suddenly doing less optimal actions).",
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
    [Setting("Interrupt Delay",
        "Controls the percentage of a total cast time to wait before interrupting enemy casts.\n" +
        "Applies to all interrupts (including stuns used to interrupt) in every Job's Combos.",
        recommendedValue: "below 40 (Above that and you start failing to interrupt many short casts)",
        defaultValue: "0",
        unitLabel: "% of cast",
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
        defaultValue: "Off")]
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
        defaultValue: "Off")]
    public bool AddOutOfPartyNPCsToRetargeting = false;

    #region Default+ Heal Stack

    /// Whether to include UI Mouseover in 'default' Heal Stack. Default: false.
    /// <seealso cref="CustomComboNS.SimpleTarget.Stack.GetStack"/>
    [SettingCategory(Targeting_Options)]
    // The spaces make it align better with the raise stack collapsible group
    [SettingCollapsibleGroup("Heal Stack Customization Options  ")]
    [SettingGroup("defaultPlus", "healStackPlus")]
    [Setting("添加UI-鼠标悬停目标到默认治疗堆栈",
        "此选项会将任何UI鼠标悬停目标添加到默认治疗堆栈的顶部，如果你将鼠标悬停在任何队员UI上，将覆盖堆栈的其余部分。\n\n" +
        "如果你是键鼠用户，并启用了重定向治疗技能（或在Redirect/Reaction插件的配置中有UI鼠标悬停目标），推荐启用此项时。",
        recommendedValue: "Preference",
        defaultValue: "Off")]
    public bool UseUIMouseoverOverridesInDefaultHealStack = false;
    
    /// Whether to include UI Mouseover in 'default' Heal Stack. Default: false.
    /// <seealso cref="CustomComboNS.SimpleTarget.Stack.GetStack"/>
    [SettingCategory(Targeting_Options)]
    [SettingCollapsibleGroup("Heal Stack Customization Options  ")]
    [SettingGroup("defaultPlus", "healStackPlus")]
    [Setting("Add Field MouseOver to the Default Healing Stack",
        "Will add any MouseOver targets to the top of the Default Heal Stack, overriding the rest of the stack if you are mousing over any party member UI.\n\n" +
        "It is recommended to enable this if you are a keyboard+mouse user and enable Retarget Healing Actions (or have UI MouseOver targets in your Redirect/Reaction configuration).",
        recommendedValue: "Preference",
        defaultValue: "Off")]
    public bool UseFieldMouseoverOverridesInDefaultHealStack = false;
    
    /// Whether to include Focus Target in 'default' Heal Stack. Default: false.
    /// <seealso cref="CustomComboNS.SimpleTarget.Stack.GetStack"/>
    [SettingCategory(Targeting_Options)]
    [SettingCollapsibleGroup("Heal Stack Customization Options  ")]
    [SettingGroup("defaultPlus", "healStackPlus")]
    [Setting("将焦点目标添加到默认治疗堆栈",
        "此选项会将你的焦点目标添加到默认治疗堆栈的软目标和硬目标之后，如果你有存活的焦点目标，将覆盖堆栈的其余部分。",
        recommendedValue: "Preference",
        defaultValue: "Off")]
    public bool UseFocusTargetOverrideInDefaultHealStack = false;
    
    /// Whether to include Lowest HP% in 'default' Heal Stack. Default: false.
    /// <seealso cref="CustomComboNS.SimpleTarget.Stack.GetStack"/>
    [SettingCategory(Targeting_Options)]
    [SettingCollapsibleGroup("Heal Stack Customization Options  ")]
    [SettingGroup("defaultPlus", "healStackPlus")]
    [Setting("将最低HP%队友添加到默认治疗堆栈",
        "此选项会将附近HP百分比最低的队友添加到默认治疗堆栈的底部，仅覆盖你自己。",
        recommendedValue: "Preference",
        defaultValue: "Off",
        warningMark: "Unlike the other Default+ Options, " +
                     "this one is not an option in most other Retargeting Plugins.\n" +
                     "THIS SHOULD BE USED WITH THE 'RETARGET HEALING ACTIONS' SETTING ABOVE!")]
    public bool UseLowestHPOverrideInDefaultHealStack = false;

    #endregion

    #region Custom Heal Stack

    /// Whether to use a Custom Heal Stack. Default: false.
    /// <seealso cref="CustomComboNS.SimpleTarget.Stack.GetStack"/>
    /// <seealso cref="HealRetargeting.RetargetSettingOn"/>
    [Or]
    [SettingCollapsibleGroup("Heal Stack Customization Options  ")]
    [SettingGroup("custom", "healStackPlus", false)]
    [SettingCategory(Targeting_Options)]
    [Setting("使用自定义治疗堆栈",
        "如果你希望自定义治疗目标优先级堆栈而不是使用默认堆栈，请选择此项。\n\n" +
        "如果你没有使用重定向治疗技能设置，建议根据你的Redirect/Reaction插件配置进行自定义，否则按个人喜好。",
        recommendedValue: "Preference",
        defaultValue: "Off")]
    public bool UseCustomHealStack = false;

    /// The Custom Heal Stack.
    /// <seealso cref="CustomComboNS.SimpleTarget.Stack.GetStack"/>
    /// <seealso cref="HealRetargeting.HealStack"/>
    /// <seealso cref="CustomComboNS.SimpleTarget.Stack.AllyToHeal"/>
    [SettingCollapsibleGroup("Heal Stack Customization Options  ")]
    [SettingParent(nameof(UseCustomHealStack))]
    [SettingCategory(Targeting_Options)]
    [Setting("自定义治疗堆栈",
        "如果少于4个项目，且全部检查无效，则会回退到自己。\n\n" +
        "仅在目标为友方且在25米范围内时才有效。\n\n" +
        "当此堆栈用于复活或康复时，将检查目标是否死亡或有可净化的异常。\n" +
        "因此，不需要再额外添加诸如 “任意可驱散的友方” 之类的目标条件。",
        recommendedValue: "Preference",
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
    [SettingCollapsibleGroup("Raise Stack Customization Options")]
    [SettingCategory(Targeting_Options)]
    [Setting("Custom Raise Stack",
        "This is the order in which Wrath will try to select a " +
        "target to Raise,\nif Retargeting of any Raise Feature is enabled.\n\n" +
        "You can find Raise Features under PvE>General,\n" +
        "or under each caster that has a Raise.\n\n" +
        "If there are fewer than 5 items, and all return nothing when checked, will fall back to:\n" +
        "your Hard Target if they're dead, or <Any Dead Party Member>.\n\n"+
        "These targets will only be considered valid if they are friendly, dead, and within 30y.\n",
        recommendedValue: "Preference",
        defaultValue: "Any Healer > Any Tank > Any Raiser > Any Dead Party Member",
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
        defaultValue: "Off")]
    public bool EnabledOutputLog = false;

    /// Whether to output Opener state to the chatbox.
    /// <seealso cref="CustomComboNS.WrathOpener.CurrentState"/>
    [SettingCategory(Troubleshooting_Options)]
    [Setting("输出起手状态到聊天",
        "每当你的职业起手准备好、失败或如预期完成时，都会输出到聊天。",
        recommendedValue: "On (IF trying to troubleshoot an Opener)",
        defaultValue: "Off")]
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