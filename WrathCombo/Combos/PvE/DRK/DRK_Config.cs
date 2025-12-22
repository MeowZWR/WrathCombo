#region

using Dalamud.Interface.Colors;
using ECommons.ImGuiMethods;
using System.Numerics;
using WrathCombo.CustomComboNS.Functions;
using WrathCombo.Data;
using WrathCombo.Window.Functions;
using BossAvoidance = WrathCombo.Combos.PvE.All.Enums.BossAvoidance;
using PartyRequirement = WrathCombo.Combos.PvE.All.Enums.PartyRequirement;

// ReSharper disable RedundantArgumentDefaultValue
// ReSharper disable AccessToStaticMemberViaDerivedType
// ReSharper disable once GrammarMistakeInComment
// ReSharper disable SwitchStatementMissingSomeEnumCasesNoDefault
// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
// ReSharper disable ClassNeverInstantiated.Global

#endregion

namespace WrathCombo.Combos.PvE;

internal partial class DRK
{
    /// <summary>
    ///     Configuration options for Dark Knight.<br />
    ///     <see cref="UserInt" />s and GUI for options.
    /// </summary>
    internal static class Config
    {
        internal static void Draw(Preset preset)
        {
            switch (preset)
            {
                #region Simple

                case Preset.DRK_ST_Simple:
                    UserConfig.DrawHorizontalRadioButton(DRK_ST_SimpleMitigation,
                        "Include Mitigations",
                        "Enables the use of mitigations in Simple Mode.",
                        (int)SimpleMitigation.On);

                    UserConfig.DrawHorizontalRadioButton(DRK_ST_SimpleMitigation,
                        "Exclude Mitigations",
                        "Disables the use of mitigations in Simple Mode.",
                        (int)SimpleMitigation.Off);
                    break;

                case Preset.DRK_AoE_Simple:
                    UserConfig.DrawHorizontalRadioButton(DRK_AoE_SimpleMitigation,
                        "Include Mitigations",
                        "Enables the use of mitigations in Simple Mode.",
                        (int)SimpleMitigation.On);

                    UserConfig.DrawHorizontalRadioButton(DRK_AoE_SimpleMitigation,
                        "Exclude Mitigations",
                        "Disables the use of mitigations in Simple Mode.",
                        (int)SimpleMitigation.Off);
                    break;

                #endregion

                #region Adv Single Target

                case Preset.DRK_ST_BalanceOpener:
                    ImGui.Indent();
                    UserConfig.DrawBossOnlyChoice(DRK_ST_OpenerDifficulty);
                    ImGui.Unindent();
                    ImGui.NewLine();
                    ImGui.Indent();
                    ImGui.Text("选择开怪技能:     (悬停查看详细信息)");
                    ImGui.Unindent();
                    ImGui.NewLine();
                    UserConfig.DrawRadioButton(DRK_ST_OpenerAction,
                        "伤残 (标准)",
                        "如果选择，将使用伤残开怪。\n" +
                        "应该在-1.0秒时开始。\n\n" +
                        "The Balance 社区推荐。",
                        outputValue: (int)PullAction.Unmend,
                        descriptionAsTooltip: true);
                    UserConfig.DrawRadioButton(DRK_ST_OpenerAction,
                        "暗影步",
                        "如果选择，将使用暗影步开怪。\n" +
                        "在掠影的蔑视前会额外使用一次重斩。\n" +
                        "应该在-0.7秒时开始。",
                        outputValue: (int)PullAction.Shadowstride,
                        descriptionAsTooltip: true);
                    UserConfig.DrawRadioButton(DRK_ST_OpenerAction,
                        "重斩 (面向或手动开怪)",
                        "如果选择，将不使用任何技能开怪，直接使用重斩。\n" +
                        "在掠影的蔑视前会额外使用一次重斩。\n" +
                        "应该在0.0秒时开始。",
                        outputValue: (int)PullAction.HardSlash,
                        descriptionAsTooltip: true);
                    break;

                case Preset.DRK_ST_CDs:
                    UserConfig.DrawHorizontalRadioButton(
                        DRK_ST_CDsBossRequirement, "所有敌人",
                        "无论敌人类型如何，都会使用冷却技能。",
                        outputValue: (int)BossRequirement.Off, itemWidth: 125f);
                    UserConfig.DrawHorizontalRadioButton(
                        DRK_ST_CDsBossRequirement, "仅Boss战",
                        "仅在Boss战中使用冷却技能。\n" +
                        "（注意：不要100%依赖此选项，SE有时会错误标记敌人类型）",
                        outputValue: (int)BossRequirement.On, itemWidth: 125f);

                    break;

                case Preset.DRK_ST_CD_Delirium:
                    UserConfig.DrawSliderInt(0, 25, DRK_ST_DeliriumThreshold,
                        stopUsingAtDescription,
                        itemWidth: little, sliderIncrement: SliderIncrements.Fives);
                    UserConfig.DrawDifficultyMultiChoice(
                        DRK_ST_DeliriumThresholdDifficulty,
                        DRK_ST_DeliriumThresholdDifficultyListSet
                    );

                    break;

                case Preset.DRK_ST_CD_Shadow:
                    UserConfig.DrawSliderInt(0, 30, DRK_ST_LivingShadowThreshold,
                        stopUsingAtDescription,
                        itemWidth: little, sliderIncrement: SliderIncrements.Fives);
                    UserConfig.DrawDifficultyMultiChoice(
                        DRK_ST_LivingShadowThresholdDifficulty,
                        DRK_ST_LivingShadowThresholdDifficultyListSet
                    );

                    break;

                case Preset.DRK_ST_Sp_BloodOvercap:
                    UserConfig.DrawSliderInt(50, 100, DRK_ST_BloodOvercapThreshold,
                        startUsingAboveDescription,
                        itemWidth: medium, sliderIncrement: SliderIncrements.Fives);
                    break;

                case Preset.DRK_ST_Sp_Edge:
                    UserConfig.DrawSliderInt(0, 3000, DRK_ST_ManaSpenderPooling,
                        "为黑盾保留的魔力值（0 = 全部使用）",
                        itemWidth: biggest,
                        sliderIncrement: SliderIncrements.Thousands);
                    UserConfig.DrawDifficultyMultiChoice(
                        DRK_ST_ManaSpenderPoolingDifficulty,
                        DRK_ST_ManaSpenderPoolingDifficultyListSet
                    );

                    break;

                case Preset.DRK_ST_Sp_ManaOvercap:
                    UserConfig.DrawSliderInt(0, 30, DRK_ST_BurstSoonThreshold,
                        "爆发前多少秒保留（允许溢出）",
                        itemWidth: little, sliderIncrement: SliderIncrements.Fives);

                    break;

                case Preset.DRK_ST_Mitigation:
                    UserConfig.DrawDifficultyMultiChoice(
                        DRK_ST_MitDifficulty,
                        DRK_ST_MitDifficultyListSet,
                        "Select what difficulties mitigation should be used in:"
                    );
                    ImGuiEx.Spacing(new Vector2(0, 15));

                    break;

                case Preset.DRK_ST_Mit_TBN:
                    UserConfig.DrawSliderInt(5, 100, DRK_ST_TBNThreshold,
                        startUsingAtDescriptionPlusDisable,
                        itemWidth: medium, sliderIncrement: SliderIncrements.Fives);

                    ImGui.Indent();
                    UserConfig.DrawHorizontalRadioButton(
                        DRK_ST_TBNBossRestriction, "所有敌人",
                        "Will use The Blackest Night regardless of the type of enemy.",
                        outputValue: (int)BossAvoidance.Off, itemWidth: 125f);
                    UserConfig.DrawHorizontalRadioButton(
                        DRK_ST_TBNBossRestriction, "避开Boss战",
                        "Will try not to use Blackest Night when in a boss fight.\n" +
                        "（注意：不要100%依赖此功能，SE有时会错误标记敌人类型）",
                        outputValue: (int)BossAvoidance.On, itemWidth: 125f);
                    ImGui.Unindent();

                    break;

                case Preset.DRK_ST_Mit_Oblation:
                    UserConfig.DrawSliderInt(10, 100, DRK_ST_Mit_OblationThreshold,
                        startUsingAtDescriptionPlusDisable,
                        itemWidth: medium, sliderIncrement: SliderIncrements.Fives);
                    UserConfig.DrawSliderInt(0, 1, DRK_ST_OblationCharges,
                        chargesToKeepDescription,
                        itemWidth: little, sliderIncrement: SliderIncrements.Ones);

                    break;

                case Preset.DRK_ST_Mit_Missionary:
                    UserConfig.DrawSliderInt(10, 100, DRK_ST_Mit_MissionaryThreshold,
                        startUsingAtDescriptionPlusDisable,
                        itemWidth: medium, sliderIncrement: SliderIncrements.Fives);
                    break;

                case Preset.DRK_ST_Mit_Vigil:
                    UserConfig.DrawSliderInt(5, 100, DRK_ST_ShadowedVigilThreshold,
                        startUsingAtDescriptionPlusDisable,
                        itemWidth: medium, sliderIncrement: SliderIncrements.Fives);

                    break;

                case Preset.DRK_ST_Mit_LivingDead:
                    UserConfig.DrawSliderInt(5, 100, DRK_ST_LivingDeadSelfThreshold,
                        startUsingAtDescriptionPlusDisable,
                        itemWidth: medium, sliderIncrement: SliderIncrements.Fives);
                    UserConfig.DrawSliderInt(0, 10, DRK_ST_LivingDeadTargetThreshold,
                        stopUsingAtDescription,
                        itemWidth: little, sliderIncrement: SliderIncrements.Ones);

                    ImGui.Indent();
                    UserConfig.DrawHorizontalRadioButton(
                        DRK_ST_LivingDeadBossRestriction, "所有敌人",
                        "Will use Living Dead regardless of the type of enemy.",
                        outputValue: (int)BossAvoidance.Off, itemWidth: 125f);
                    UserConfig.DrawHorizontalRadioButton(
                        DRK_ST_LivingDeadBossRestriction, "避开Boss战",
                        "Will try not to use Living Dead when your target is a boss.\n" +
                        "（注意：不要100%依赖此功能，SE有时会错误标记敌人类型）",
                        outputValue: (int)BossAvoidance.On, itemWidth: 125f);
                    ImGui.Unindent();

                    break;

                #endregion

                #region Adv AoE

                case Preset.DRK_AoE_CD_Delirium:
                    UserConfig.DrawSliderInt(0, 60, DRK_AoE_DeliriumThreshold,
                        stopUsingAtDescription,
                        itemWidth: bigger, sliderIncrement: SliderIncrements.Fives);
                    UserConfig.DrawDifficultyMultiChoice(
                        DRK_AoE_DeliriumThresholdDifficulty,
                        DRK_AoE_DeliriumThresholdDifficultyListSet
                    );

                    break;

                case Preset.DRK_AoE_CD_Shadow:
                    UserConfig.DrawSliderInt(0, 60, DRK_AoE_LivingShadowThreshold,
                        stopUsingAtDescription,
                        itemWidth: bigger, sliderIncrement: SliderIncrements.Fives);
                    UserConfig.DrawDifficultyMultiChoice(
                        DRK_AoE_LivingShadowThresholdDifficulty,
                        DRK_AoE_LivingShadowThresholdDifficultyListSet
                    );

                    break;

                case Preset.DRK_AoE_CD_Salt:
                    UserConfig.DrawSliderInt(0, 60, DRK_AoE_SaltThreshold,
                        stopUsingAtDescription,
                        itemWidth: bigger, sliderIncrement: SliderIncrements.Fives);

                    break;

                case Preset.DRK_AoE_CD_Drain:
                    UserConfig.DrawSliderInt(20, 100, DRK_AoE_DrainThreshold,
                        startUsingAtDescriptionPlusDisable,
                        itemWidth: bigger, sliderIncrement: SliderIncrements.Fives);

                    break;

                case Preset.DRK_AoE_Sp_BloodOvercap:
                    UserConfig.DrawSliderInt(50, 100, DRK_AoE_BloodOvercapThreshold,
                        startUsingAboveDescription,
                        itemWidth: medium, sliderIncrement: SliderIncrements.Fives);

                    break;

                case Preset.DRK_AoE_Sp_Flood:
                    UserConfig.DrawSliderInt(0, 3000, DRK_AoE_ManaSpenderPooling,
                        "为TBN保留的魔力值（0 = 全部使用）",
                        itemWidth: biggest,
                        sliderIncrement: SliderIncrements.Thousands);

                    break;

                case Preset.DRK_AoE_Mit_Oblation:
                    UserConfig.DrawSliderInt(10, 100, DRK_AoE_Mit_OblationThreshold,
                        startUsingAtDescriptionPlusDisable,
                        itemWidth: medium, sliderIncrement: SliderIncrements.Fives);
                    UserConfig.DrawSliderInt(0, 1, DRK_AoE_OblationCharges,
                        chargesToKeepDescription,
                        itemWidth: little, sliderIncrement: SliderIncrements.Ones);

                    break;

                case Preset.DRK_AoE_Mit_Reprisal:
                    UserConfig.DrawSliderInt(20, 100, DRK_AoE_Mit_ReprisalThreshold,
                        startUsingAtDescriptionPlusDisable,
                        itemWidth: medium, sliderIncrement: SliderIncrements.Fives);
                    UserConfig.DrawSliderInt(1, 5, DRK_AoE_ReprisalEnemyCount,
                        "# enemies in range",
                        itemWidth: little, sliderIncrement: SliderIncrements.Ones);

                    break;

                case Preset.DRK_AoE_Mit_DarkMind:
                    UserConfig.DrawSliderInt(10, 100, DRK_AoE_Mit_DarkMindThreshold,
                        startUsingAtDescriptionPlusDisable,
                        itemWidth: medium, sliderIncrement: SliderIncrements.Fives);
                    break;

                case Preset.DRK_AoE_Mit_Rampart:
                    UserConfig.DrawSliderInt(10, 100, DRK_AoE_Mit_RampartThreshold,
                        startUsingAtDescriptionPlusDisable,
                        itemWidth: medium, sliderIncrement: SliderIncrements.Fives);

                    break;

                case Preset.DRK_AoE_Mit_ArmsLength:
                    UserConfig.DrawSliderInt(1, 5, DRK_AoE_ArmsLengthEnemyCount,
                        "# enemies in range",
                        itemWidth: little, sliderIncrement: SliderIncrements.Ones);

                    break;

                case Preset.DRK_AoE_Mit_Vigil:
                    UserConfig.DrawSliderInt(5, 100, DRK_AoE_ShadowedVigilThreshold,
                        startUsingAtDescriptionPlusDisable,
                        itemWidth: medium, sliderIncrement: SliderIncrements.Fives);

                    break;

                case Preset.DRK_AoE_Mit_LivingDead:
                    UserConfig.DrawSliderInt(5, 100, DRK_AoE_LivingDeadSelfThreshold,
                        startUsingAtDescriptionPlusDisable,
                        itemWidth: medium, sliderIncrement: SliderIncrements.Fives);
                    UserConfig.DrawSliderInt(0, 40,
                        DRK_AoE_LivingDeadTargetThreshold,
                        stopUsingAtDescription,
                        itemWidth: little, sliderIncrement: SliderIncrements.Tens);

                    break;

                #endregion             

                #region One-Button Mitigation

                case Preset.DRK_Mit_LivingDead_Max:
                    UserConfig.DrawDifficultyMultiChoice(
                        DRK_Mit_EmergencyLivingDead_Difficulty,
                        DRK_Mit_EmergencyLivingDead_DifficultyListSet,
                        "Select what difficulties Emergency Living Dead should be used in:"
                    );

                    UserConfig.DrawSliderInt(1, 100, DRK_Mit_LivingDead_Health,
                        startUsingAtDescription,
                        itemWidth: medium, sliderIncrement: SliderIncrements.Ones);

                    break;

                case Preset.DRK_Mit_TheBlackestNight:
                    UserConfig.DrawPriorityInput(DRK_Mit_Priorities,
                        numberMitigationOptions, 0,
                        "The Blackest Night Priority:");

                    break;

                case Preset.DRK_Mit_Oblation:
                    UserConfig.DrawSliderInt(0, 1, DRK_Mit_Oblation_Charges,
                        "保留多少个充能？（0 = 全部使用）",
                        itemWidth: little, sliderIncrement: SliderIncrements.Ones);

                    UserConfig.DrawPriorityInput(DRK_Mit_Priorities,
                        numberMitigationOptions, 1,
                        "Oblation Priority:");

                    break;

                case Preset.DRK_Mit_Reprisal:
                    UserConfig.DrawPriorityInput(DRK_Mit_Priorities,
                        numberMitigationOptions, 2,
                        "Reprisal Priority:");

                    break;

                case Preset.DRK_Mit_DarkMissionary:
                    ImGui.Indent();
                    UserConfig.DrawHorizontalRadioButton(
                        DRK_Mit_DarkMissionary_PartyRequirement,
                        "需要队伍",
                        "除非有2个或更多队伍成员，否则不会使用暗黑布道。",
                        outputValue: (int)PartyRequirement.Yes, itemWidth: medium);
                    UserConfig.DrawHorizontalRadioButton(
                        DRK_Mit_DarkMissionary_PartyRequirement,
                        "总是使用",
                        "暗黑布道不要求有队伍。",
                        outputValue: (int)PartyRequirement.No, itemWidth: medium);
                    ImGui.Unindent();

                    UserConfig.DrawPriorityInput(DRK_Mit_Priorities,
                        numberMitigationOptions, 3,
                        "暗黑布道优先级：");

                    break;

                case Preset.DRK_Mit_Rampart:
                    UserConfig.DrawPriorityInput(DRK_Mit_Priorities,
                        numberMitigationOptions, 4,
                        "铁壁优先级：");

                    break;

                case Preset.DRK_Mit_DarkMind:
                    UserConfig.DrawPriorityInput(DRK_Mit_Priorities,
                        numberMitigationOptions, 5,
                        "弃暗投明优先级：");

                    break;

                case Preset.DRK_Mit_ArmsLength:
                    ImGui.Indent();
                    UserConfig.DrawHorizontalRadioButton(
                        DRK_Mit_ArmsLength_Boss, "所有敌人",
                        "Will use Arm's Length regardless of the type of enemy.",
                        outputValue: (int)BossAvoidance.Off, itemWidth: 125f);
                    UserConfig.DrawHorizontalRadioButton(
                        DRK_Mit_ArmsLength_Boss, "避开Boss战",
                        "Will try not to use Arm's Length when in a boss fight.",
                        outputValue: (int)BossAvoidance.On, itemWidth: 125f);
                    ImGui.Unindent();

                    UserConfig.DrawSliderInt(0, 5, DRK_Mit_ArmsLength_EnemyCount,
                        "How many enemies should be nearby? (0 = No Requirement)",
                        itemWidth: little, sliderIncrement: SliderIncrements.Ones);

                    UserConfig.DrawPriorityInput(DRK_Mit_Priorities,
                        numberMitigationOptions, 6,
                        "青疏自行优先级：");

                    break;

                case Preset.DRK_Mit_ShadowWall:
                    UserConfig.DrawSliderInt(1, 100, DRK_Mit_ShadowWall_Health,
                        startUsingAtDescriptionPlusDisable,
                        itemWidth: medium, sliderIncrement: SliderIncrements.Ones);

                    UserConfig.DrawPriorityInput(DRK_Mit_Priorities,
                        numberMitigationOptions, 7,
                        "暗影墙 / 暗影卫士优先级：");

                    break;

                #endregion

                #region Standalones

                case Preset.DRK_Retarget_TBN_TT:
                    ImGui.Indent(34f.Scale());
                    ImGuiEx.TextWrapped(ImGuiColors.DalamudGrey,
                        "注意：如果你是副T，并且希望将该技能用于自己，建议通过一键减伤功能或你的循环中的减伤选项来实现。\n" +
                        "否则，该技能会施放到主T身上。\n" +
                        "如果你不使用这些功能来进行个人减伤，建议不要启用此选项。");
                    ImGui.Unindent(34f.Scale());
                    break;

                case Preset.DRK_Retarget_Oblation_TT:
                    ImGui.Indent(34f.Scale());
                    ImGuiEx.TextWrapped(ImGuiColors.DalamudGrey,
                        "注意：如果你是副T，并且希望将该技能用于自己，建议通过一键减伤功能或你的循环中的减伤选项来实现。\n" +
                        "否则，该技能会施放到主T身上。\n" +
                        "如果你不使用这些功能来进行个人减伤，建议不要启用此选项。");
                    ImGui.Unindent(34f.Scale());
                    break;

                    #endregion
            }
        }

        #region Constants

        /// Number of Mitigation Options
        private const int numberMitigationOptions = 8;

        /// Smallest bar width
        private const float little = 100f;

        /// 2nd smallest bar width
        private const float medium = 150f;

        /// 2nd biggest bar width
        private const float bigger = 175f;

        /// Biggest bar width
        private const float biggest = 200f;

        /// Bar Description for HP% to stop using
        private const string stopUsingAtDescription =
            "目标血量百分比阈值（0 = 总是使用）";

        /// Bar Description for HP% to start using
        private const string startUsingAtDescription =
            "血量百分比阈值（0 = 总是使用）";

        /// Bar Description for HP% to start using plus disable text
        /// <remarks>
        ///     Should only be used if the range of the option goes to <c>100</c>,
        ///     and the option is effectively disabled at <c>100</c>.
        /// </remarks>
        private const string startUsingAtDescriptionPlusDisable =
            "血量百分比阈值（100 = 禁用检查）";

        /// Bar Description for # to start using (above)
        private const string startUsingAboveDescription =
            "# 血量百分比阈值（0 = 总是使用）";

        private const string chargesToKeepDescription =
            "# 充能保留（0 = 全部使用）";

        /// <summary>
        ///     Whether abilities should be restricted to bosses or not.
        /// </summary>
        internal enum BossRequirement
        {
            Off = 1,
            On = 2,
        }

        /// <summary>
        ///     Whether Simple Mode should include mitigation or not.
        /// </summary>
        internal enum SimpleMitigation
        {
            Off,
            On,
        }

        internal enum PullAction
        {
            Unmend,
            Shadowstride,
            HardSlash,
        }

        #endregion

        #region Options

        #region Simple

        /// <summary>
        ///     Simple Mitigation option for Single Target.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: <see cref="SimpleMitigation.On" /> <br />
        ///     <b>Options</b>: <see cref="SimpleMitigation.Off" /> or
        ///     <see cref="SimpleMitigation.On" />
        /// </value>
        /// <seealso cref="Preset.DRK_ST_Simple" />
        public static readonly UserInt DRK_ST_SimpleMitigation =
            new("DRK_ST_SimpleMitigation", (int)SimpleMitigation.On);

        /// <summary>
        ///     Simple Mitigation option for AoE.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: <see cref="SimpleMitigation.On" /> <br />
        ///     <b>Options</b>: <see cref="SimpleMitigation.Off" /> or
        ///     <see cref="SimpleMitigation.On" />
        /// </value>
        /// <seealso cref="Preset.DRK_AoE_Simple" />
        public static readonly UserInt DRK_AoE_SimpleMitigation =
            new("DRK_AoE_SimpleMitigation", (int)SimpleMitigation.On);

        #endregion

        #region Adv Single Target

        /// <summary>
        ///     Content type of Balance Opener for Single Target.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: <see cref="ContentCheck.IsInBossOnlyContent" /> <br />
        ///     <b>Options</b>: All Content or
        ///     <see cref="ContentCheck.IsInBossOnlyContent" />
        /// </value>
        /// <seealso cref="Preset.DRK_ST_BalanceOpener" />
        public static readonly UserBoolArray DRK_ST_OpenerDifficulty =
            new("DRK_ST_OpenerDifficulty", [false, true]);

        /// <summary>
        ///     What action is used to pull, in the opener.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: <see cref="PullAction.Unmend" /> <br />
        ///     <b>Options</b>: <see cref="PullAction">PullAction Enum</see>
        /// </value>
        /// <seealso cref="Preset.DRK_ST_BalanceOpener" />
        public static readonly UserInt DRK_ST_OpenerAction =
            new("DRK_ST_OpenerAction", (int)PullAction.Unmend);

        /// <summary>
        ///     Cooldown Boss Restriction for Single Target.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: <see cref="BossRequirement.Off" /> <br />
        ///     <b>Options</b>: <see cref="BossRequirement">BossRequirement Enum</see>
        /// </value>
        /// <seealso cref="Preset.DRK_ST_CDs" />
        public static readonly UserInt DRK_ST_CDsBossRequirement =
            new("DRK_ST_CDsBossRequirement", (int)BossRequirement.Off);

        /// <summary>
        ///     Target HP% to use Delirium above for Single Target.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 0<br />
        ///     <b>Range</b>: 0 - 25 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Fives" />
        /// </value>
        /// <seealso cref="Preset.DRK_ST_CD_Delirium" />
        public static readonly UserInt DRK_ST_DeliriumThreshold =
            new("DRK_ST_DeliriumThreshold", 0);

        /// <summary>
        ///     Difficulty of Delirium Threshold for Single Target.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: <see cref="ContentCheck.BottomHalfContent" /> <br />
        ///     <b>Options</b>: <see cref="ContentCheck.BottomHalfContent" />
        ///     and/or <see cref="ContentCheck.TopHalfContent" />
        /// </value>
        /// <seealso cref="DRK_ST_DeliriumThreshold" />
        public static readonly UserBoolArray DRK_ST_DeliriumThresholdDifficulty =
            new("DRK_ST_DeliriumThresholdDifficulty", [true, false]);

        /// <summary>
        ///     What Difficulty List Set
        ///     <see cref="DRK_ST_DeliriumThresholdDifficulty" /> is set to.
        /// </summary>
        /// <seealso cref="DRK_ST_DeliriumThresholdDifficulty" />
        public static readonly ContentCheck.ListSet
            DRK_ST_DeliriumThresholdDifficultyListSet =
                ContentCheck.ListSet.Halved;

        /// <summary>
        ///     Target HP% to use Living Shadow above for Single Target.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 5 <br />
        ///     <b>Range</b>: 0 - 30 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Fives" />
        /// </value>
        /// <seealso cref="Preset.DRK_ST_CD_Shadow" />
        public static readonly UserInt DRK_ST_LivingShadowThreshold =
            new("DRK_ST_LivingShadowThreshold", 5);

        /// <summary>
        ///     Difficulty of Living Shadow Threshold for Single Target.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: <see cref="ContentCheck.BottomHalfContent" /> <br />
        ///     <b>Options</b>: <see cref="ContentCheck.BottomHalfContent" />
        ///     and/or <see cref="ContentCheck.TopHalfContent" />
        /// </value>
        /// <seealso cref="DRK_ST_LivingShadowThreshold" />
        public static readonly UserBoolArray DRK_ST_LivingShadowThresholdDifficulty =
            new("DRK_ST_LivingShadowThresholdDifficulty", [true, false]);

        /// <summary>
        ///     What Difficulty List Set
        ///     <see cref="DRK_ST_LivingShadowThresholdDifficulty" /> is set to.
        /// </summary>
        public static readonly ContentCheck.ListSet
            DRK_ST_LivingShadowThresholdDifficultyListSet =
                ContentCheck.ListSet.Halved;

        /// <summary>
        ///     Target HP% to use Blood Overcap above for Single Target.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 90<br />
        ///     <b>Range</b>: 50 - 100 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Fives" />
        /// </value>
        /// <seealso cref="Preset.DRK_ST_Sp_BloodOvercap" />
        public static readonly UserInt DRK_ST_BloodOvercapThreshold =
            new("DRK_ST_BloodOvercapThreshold", 90);

        /// <summary>
        ///     How much mana to save for TBN.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 3000 <br />
        ///     <b>Range</b>: 0 - 3000 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Thousands" />
        /// </value>
        /// <seealso cref="Preset.DRK_ST_Sp_Edge" />
        public static readonly UserInt DRK_ST_ManaSpenderPooling =
            new("DRK_ST_ManaSpenderPooling", 3000);

        /// <summary>
        ///     Number of seconds before burst that high mana will be allowed within,
        ///     and attempts to save Dark Arts will start working in.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 18<br />
        ///     <b>Range</b>: 0 - 45 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Fives" />
        /// </value>
        /// <seealso cref="Preset.DRK_ST_Sp_ManaOvercap" />
        public static readonly UserInt DRK_ST_BurstSoonThreshold =
            new("DRK_ST_BurstSoonThreshold", 18);

        /// <summary>
        ///     Difficulty of Mana Spender Pooling for Single Target.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: <see cref="ContentCheck.BottomHalfContent" /> <br />
        ///     <b>Options</b>: <see cref="ContentCheck.BottomHalfContent" />
        ///     and/or <see cref="ContentCheck.TopHalfContent" />
        /// </value>
        /// <seealso cref="DRK_ST_ManaSpenderPooling" />
        public static readonly UserBoolArray DRK_ST_ManaSpenderPoolingDifficulty =
            new("DRK_ST_ManaSpenderPoolingDifficulty", [false, true]);

        /// <summary>
        ///     What Difficulty List Set
        ///     <see cref="DRK_ST_ManaSpenderPoolingDifficulty" /> is set to.
        /// </summary>
        /// <seealso cref="DRK_ST_ManaSpenderPoolingDifficulty" />
        public static readonly ContentCheck.ListSet
            DRK_ST_ManaSpenderPoolingDifficultyListSet =
                ContentCheck.ListSet.Halved;

        #region In-Rotation Mitigation

        /// <summary>
        ///     Difficulty of Mitigation for Single Target.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: <see cref="ContentCheck.BottomHalfContent" /> <br />
        ///     <b>Options</b>: <see cref="ContentCheck.BottomHalfContent" />
        ///     and/or <see cref="ContentCheck.TopHalfContent" />
        /// </value>
        /// <seealso cref="Preset.DRK_ST_Mitigation" />
        public static readonly UserBoolArray DRK_ST_MitDifficulty =
            new("DRK_ST_MitDifficulty", [true, false]);

        /// <summary>
        ///     What Difficulty List Set
        ///     <see cref="DRK_ST_MitDifficulty" /> is set to.
        /// </summary>
        /// <seealso cref="DRK_ST_MitDifficulty" />
        public static readonly ContentCheck.ListSet
            DRK_ST_MitDifficultyListSet =
                ContentCheck.ListSet.Halved;

        /// <summary>
        ///     Self HP% to use TBN below for Single Target.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 35 <br />
        ///     <b>Range</b>: 5 - 100 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Fives" />
        /// </value>
        /// <seealso cref="Preset.DRK_ST_Mit_TBN" />
        public static readonly UserInt DRK_ST_TBNThreshold =
            new("DRK_ST_TBNThreshold", 35);

        /// <summary>
        ///     TBN Boss Restriction for Single Target.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: <see cref="BossAvoidance.Off" /> <br />
        ///     <b>Options</b>: <see cref="BossAvoidance">BossAvoidance Enum</see>
        /// </value>
        /// <seealso cref="Preset.DRK_ST_Mit_TBN" />
        public static readonly UserInt DRK_ST_TBNBossRestriction =
            new("DRK_ST_TBNBossRestriction", (int)BossAvoidance.Off);

        /// <summary>
        ///     The number of Oblation charges to keep for manual use.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 0 <br />
        ///     <b>Range</b>: 0 - 1 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Ones" />
        /// </value>
        /// <seealso cref="Preset.DRK_ST_Mit_Oblation" />
        public static readonly UserInt DRK_ST_OblationCharges =
            new("DRK_ST_OblationCharges", 0);

        /// <summary>
        ///     Self HP% to use Oblation below for Single Target.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 85 <br />
        ///     <b>Range</b>: 10 - 100 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Fives" />
        /// </value>
        /// <seealso cref="Preset.DRK_ST_Mit_Oblation" />
        public static readonly UserInt DRK_ST_Mit_OblationThreshold =
            new("DRK_ST_Mit_OblationThreshold", 85);

        /// <summary>
        ///     Self HP% to use Dark Missionary below for Single Target.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 100 <br />
        ///     <b>Range</b>: 10 - 100 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Fives" />
        /// </value>
        /// <seealso cref="Preset.DRK_ST_Mit_Missionary" />
        public static readonly UserInt DRK_ST_Mit_MissionaryThreshold =
            new("DRK_ST_Mit_MissionaryThreshold", 100);

        /// <summary>
        ///     Self HP% to use Shadowed Vigil below for Single Target.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 50 <br />
        ///     <b>Range</b>: 5 - 100 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Fives" />
        /// </value>
        /// <seealso cref="Preset.DRK_ST_Mit_Vigil" />
        public static readonly UserInt DRK_ST_ShadowedVigilThreshold =
            new("DRK_ST_ShadowedVigilThreshold", 50);

        /// <summary>
        ///     Self HP% to use Living Dead below for Single Target.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 15 <br />
        ///     <b>Range</b>: 5 - 100 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Fives" />
        /// </value>
        /// <seealso cref="Preset.DRK_ST_Mit_LivingDead" />
        public static readonly UserInt DRK_ST_LivingDeadSelfThreshold =
            new("DRK_ST_LivingDeadSelfThreshold", 15);

        /// <summary>
        ///     Target HP% to use Living Dead above for Single Target.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 1 <br />
        ///     <b>Range</b>: 0 - 10 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Ones" />
        /// </value>
        /// <seealso cref="Preset.DRK_ST_Mit_LivingDead" />
        public static readonly UserInt DRK_ST_LivingDeadTargetThreshold =
            new("DRK_ST_LivingDeadTargetThreshold", 1);

        /// <summary>
        ///     Living Dead Boss Restriction for Single Target.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: <see cref="BossAvoidance.On" /> <br />
        ///     <b>Options</b>: <see cref="BossAvoidance">BossAvoidance Enum</see>
        /// </value>
        /// <seealso cref="Preset.DRK_ST_Mit_LivingDead" />
        public static readonly UserInt DRK_ST_LivingDeadBossRestriction =
            new("DRK_ST_LivingDeadBossRestriction", (int)BossAvoidance.On);

        #endregion

        #endregion

        #region Adv AoE

        /// <summary>
        ///     Target HP% to use Delirium above for AoE.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 25 <br />
        ///     <b>Range</b>: 0 - 60 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Fives" />
        /// </value>
        /// <seealso cref="Preset.DRK_AoE_CD_Delirium" />
        public static readonly UserInt DRK_AoE_DeliriumThreshold =
            new("DRK_AoE_DeliriumThreshold", 25);

        /// <summary>
        ///     Difficulty of Delirium Threshold for AoE.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: <see cref="ContentCheck.BottomHalfContent" /> <br />
        ///     <b>Options</b>: <see cref="ContentCheck.BottomHalfContent" />
        ///     and/or <see cref="ContentCheck.TopHalfContent" />
        /// </value>
        /// <seealso cref="DRK_AoE_DeliriumThreshold" />
        public static readonly UserBoolArray DRK_AoE_DeliriumThresholdDifficulty =
            new("DRK_AoE_DeliriumThresholdDifficulty", [true, false]);

        /// <summary>
        ///     What Difficulty List Set
        ///     <see cref="DRK_AoE_DeliriumThresholdDifficulty" /> is set to.
        /// </summary>
        /// <seealso cref="DRK_AoE_DeliriumThresholdDifficulty" />
        public static readonly ContentCheck.ListSet
            DRK_AoE_DeliriumThresholdDifficultyListSet =
                ContentCheck.ListSet.Halved;

        /// <summary>
        ///     Target HP% to use Living Shadow above for AoE.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 40 <br />
        ///     <b>Range</b>: 0 - 60 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Fives" />
        /// </value>
        /// <seealso cref="Preset.DRK_AoE_CD_Shadow" />
        public static readonly UserInt DRK_AoE_LivingShadowThreshold =
            new("DRK_AoE_LivingShadowThreshold", 40);

        /// <summary>
        ///     Difficulty of Living Shadow Threshold for AoE.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: <see cref="ContentCheck.BottomHalfContent" /> <br />
        ///     <b>Options</b>: <see cref="ContentCheck.BottomHalfContent" />
        ///     and/or <see cref="ContentCheck.TopHalfContent" />
        /// </value>
        /// <seealso cref="DRK_AoE_LivingShadowThreshold" />
        public static readonly UserBoolArray
            DRK_AoE_LivingShadowThresholdDifficulty =
                new("DRK_AoE_LivingShadowThresholdDifficulty", [true, false]);

        /// <summary>
        ///     What Difficulty List Set
        ///     <see cref="DRK_AoE_LivingShadowThresholdDifficulty" /> is set to.
        /// </summary>
        /// <seealso cref="DRK_AoE_LivingShadowThresholdDifficulty" />
        public static readonly ContentCheck.ListSet
            DRK_AoE_LivingShadowThresholdDifficultyListSet =
                ContentCheck.ListSet.Halved;

        /// <summary>
        ///     Target HP% to use Salted Earth above for AoE.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 30 <br />
        ///     <b>Range</b>: 0 - 60 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Fives" />
        /// </value>
        /// <seealso cref="Preset.DRK_AoE_CD_Salt" />
        public static readonly UserInt DRK_AoE_SaltThreshold =
            new("DRK_AoE_SaltThreshold", 30);

        /// <summary>
        ///     Target HP% to use Drain above for AoE.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 20 <br />
        ///     <b>Range</b>: 20 - 100 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Fives" />
        /// </value>
        /// <seealso cref="Preset.DRK_AoE_CD_Drain" />
        public static readonly UserInt DRK_AoE_DrainThreshold =
            new("DRK_AoE_DrainThreshold", 60);

        /// <summary>
        ///     Target HP% to use Blood Overcap above for AoE.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 90<br />
        ///     <b>Range</b>: 50 - 100 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Fives" />
        /// </value>
        /// <seealso cref="Preset.DRK_AoE_Sp_BloodOvercap" />
        public static readonly UserInt DRK_AoE_BloodOvercapThreshold =
            new("DRK_AoE_BloodOvercapThreshold", 90);

        /// <summary>
        ///     How much mana to save for TBN in AoE.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 0 <br />
        ///     <b>Range</b>: 0 - 3000 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Thousands" />
        /// </value>
        /// <seealso cref="Preset.DRK_AoE_Sp_Flood" />
        public static readonly UserInt DRK_AoE_ManaSpenderPooling =
            new("DRK_AoE_ManaSpenderPooling", 0);

        /// <summary>
        ///     The number of Oblation charges to keep for manual use in AoE.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 0 <br />
        ///     <b>Range</b>: 0 - 1 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Ones" />
        /// </value>
        /// <seealso cref="Preset.DRK_AoE_Mit_Oblation" />
        public static readonly UserInt DRK_AoE_OblationCharges =
            new("DRK_AoE_OblationCharges", 0);

        /// <summary>
        ///     Self HP% to use Oblation below for AoE.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 85 <br />
        ///     <b>Range</b>: 10 - 100 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Fives" />
        /// </value>
        /// <seealso cref="Preset.DRK_AoE_Mit_Oblation" />
        public static readonly UserInt DRK_AoE_Mit_OblationThreshold =
            new("DRK_AoE_Mit_OblationThreshold", 85);

        /// <summary>
        ///     Number of enemies required to be in range before Reprisal is used.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 3 <br />
        ///     <b>Range</b>: 1 - 10 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Ones" />
        /// </value>
        /// <seealso cref="Preset.DRK_AoE_Mit_Reprisal" />
        public static readonly UserInt DRK_AoE_ReprisalEnemyCount =
            new("DRK_AoE_ReprisalEnemyCount", 3);

        /// <summary>
        ///     Self HP% to use Dark Mind below for AoE.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 75 <br />
        ///     <b>Range</b>: 10 - 100 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Fives" />
        /// </value>
        /// <seealso cref="Preset.DRK_AoE_Mit_DarkMind" />
        public static readonly UserInt DRK_AoE_Mit_DarkMindThreshold =
            new("DRK_AoE_Mit_DarkMindThreshold", 75);

        /// <summary>
        ///     Self HP% to use Rampart below for AoE.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 50 <br />
        ///     <b>Range</b>: 10 - 100 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Fives" />
        /// </value>
        /// <seealso cref="Preset.DRK_AoE_Mit_Rampart" />
        public static readonly UserInt DRK_AoE_Mit_RampartThreshold =
            new("DRK_AoE_Mit_RampartThreshold", 50);

        /// <summary>
        ///     Self HP\% to use Reprisal below for AoE.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 80 <br />
        ///     <b>Range</b>: 20 - 100 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Fives" />
        /// </value>
        /// <seealso cref="Preset.DRK_AoE_Mit_Reprisal" />
        public static readonly UserInt DRK_AoE_Mit_ReprisalThreshold =
            new("DRK_AoE_Mit_ReprisalThreshold", 80);

        /// <summary>
        ///     Number of enemies required to be in range before Arm's Length is used.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 3 <br />
        ///     <b>Range</b>: 1 - 10 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Ones" />
        /// </value>
        /// <seealso cref="Preset.DRK_AoE_Mit_ArmsLength" />
        public static readonly UserInt DRK_AoE_ArmsLengthEnemyCount =
            new("DRK_AoE_ArmsLengthEnemyCount", 3);

        /// <summary>
        ///     Self HP% to use Shadowed Vigil below for AoE.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 55 <br />
        ///     <b>Range</b>: 5 - 100 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Fives" />
        /// </value>
        /// <seealso cref="Preset.DRK_AoE_Mit_Vigil" />
        public static readonly UserInt DRK_AoE_ShadowedVigilThreshold =
            new("DRK_AoE_ShadowedVigilThreshold", 50);

        /// <summary>
        ///     Self HP% to use Living Dead below for AoE.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 20 <br />
        ///     <b>Range</b>: 5 - 100 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Fives" />
        /// </value>
        /// <seealso cref="Preset.DRK_AoE_Mit_LivingDead" />
        public static readonly UserInt DRK_AoE_LivingDeadSelfThreshold =
            new("DRK_AoE_LivingDeadSelfThreshold", 20);

        /// <summary>
        ///     Target HP% to use Living Dead above for AoE.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 15 <br />
        ///     <b>Range</b>: 0 - 40 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Tens" />
        /// </value>
        /// <seealso cref="Preset.DRK_AoE_Mit_LivingDead" />
        public static readonly UserInt DRK_AoE_LivingDeadTargetThreshold =
            new("DRK_AoE_LivingDeadTargetThreshold", 15);

        #endregion

        #region One-Button Mitigation

        /// <summary>
        ///     Difficulty of Emergency Living Dead for Mitigation.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: <see cref="ContentCheck.BottomHalfContent" /> <br />
        ///     <b>Options</b>: <see cref="ContentCheck.BottomHalfContent" />
        ///     and/or <see cref="ContentCheck.TopHalfContent" />
        /// </value>
        /// <seealso cref="Preset.DRK_Mit_LivingDead_Max" />
        public static readonly UserBoolArray
            DRK_Mit_EmergencyLivingDead_Difficulty =
                new("DRK_Mit_EmergencyLivingDead_Difficulty", [true, false]);

        /// <summary>
        ///     What Difficulty List Set
        ///     <see cref="DRK_Mit_EmergencyLivingDead_Difficulty" /> is set to.
        /// </summary>
        /// <seealso cref="Preset.DRK_Mit_LivingDead_Max" />
        public static readonly ContentCheck.ListSet
            DRK_Mit_EmergencyLivingDead_DifficultyListSet =
                ContentCheck.ListSet.Halved;

        /// <summary>
        ///     Self HP% to use Living Dead below in the Mitigation Rotation.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 20 <br />
        ///     <b>Range</b>: 5 - 30 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Fives" />
        /// </value>
        /// <seealso cref="Preset.DRK_Mit_LivingDead_Max" />
        public static UserInt DRK_Mit_LivingDead_Health =
            new("DRK_Mit_LivingDead_Health", 20);

        /// <summary>
        ///     Mitigation Ability Priority List.
        /// </summary>
        public static readonly UserIntArray
            DRK_Mit_Priorities =
                new("DRK_Mit_Priorities");

        /// <summary>
        ///     Party requirement for using Dark Missionary in the Mitigation Rotation.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: <see cref="PartyRequirement.Yes" /> <br />
        ///     <b>Options</b>: <see cref="PartyRequirement">PartyRequirement Enum</see>
        /// </value>
        public static readonly UserInt
            DRK_Mit_DarkMissionary_PartyRequirement =
                new("DRK_Mit_DarkMissionary_PartyRequirement",
                    (int)PartyRequirement.Yes);

        /// <summary>
        ///     Arm's Length Boss Restriction for Mitigation.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: <see cref="BossAvoidance.On" /> <br />
        ///     <b>Options</b>: <see cref="BossAvoidance">BossAvoidance Enum</see>
        /// </value>
        /// <seealso cref="Preset.DRK_Mit_ArmsLength" />
        public static readonly UserInt DRK_Mit_ArmsLength_Boss =
            new("DRK_Mit_ArmsLength_Boss", (int)BossAvoidance.On);

        /// <summary>
        ///     The number of enemies to be nearby for Arm's Length.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 0 <br />
        ///     <b>Range</b>: 0 - 3 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Ones" />
        /// </value>
        /// <seealso cref="Preset.DRK_Mit_ArmsLength" />
        public static UserInt DRK_Mit_ArmsLength_EnemyCount =
            new("DRK_Mit_ArmsLength_EnemyCount", 0);

        /// <summary>
        ///     Self HP% to use Shadow Wall below in the Mitigation Rotation.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 45 <br />
        ///     <b>Range</b>: 30 - 100 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Fives" />
        /// </value>
        /// <seealso cref="Preset.DRK_Mit_ShadowWall" />
        public static UserInt DRK_Mit_ShadowWall_Health =
            new("DRK_Mit_ShadowWall_Health", 45);

        /// <summary>
        ///     The number of Oblation charges to keep for manual use.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 0 <br />
        ///     <b>Range</b>: 0 - 1 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Ones" />
        /// </value>
        /// <seealso cref="Preset.DRK_Mit_Oblation" />
        public static UserInt DRK_Mit_Oblation_Charges =
            new("DRK_Mit_Oblation_Charges", 0);

        #endregion

        #endregion
    }
}
