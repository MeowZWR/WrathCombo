using Dalamud.Interface.Colors;
using ECommons.ImGuiMethods;
using WrathCombo.CustomComboNS.Functions;
using WrathCombo.Extensions;
using WrathCombo.Resources.Localization.JobConfigs;
using static WrathCombo.Window.Functions.UserConfig;
namespace WrathCombo.Combos.PvE;

internal partial class BRD
{
    internal static class Config
    {
        #region Options

        public static UserBool
            BRD_AoE_Wardens_Auto = new("BRD_AoE_Wardens_Auto"),
            BRD_ST_Wardens_Auto = new("BRD_ST_Wardens_Auto"),
            BRD_IronJaws_Apex = new("BRD_IronJaws_Apex"),
            BRD_IronJaws_Alternate = new("BRD_IronJaws_Alternate"),
            BRD_Opener_Potion = new("BRD_Opener_Potion"),
            BRD_Opener_PrepullBlock = new("BRD_Opener_PrepullBlock", true);

        public static UserInt
            BRD_RagingJawsRenewTime = new("ragingJawsRenewTime", 5),
            BRD_STSecondWindThreshold = new("BRD_STSecondWindThreshold", 40),
            BRD_AoESecondWindThreshold = new("BRD_AoESecondWindThreshold", 40),
            BRD_Adv_Opener_Selection = new("BRD_Adv_Opener_Selection", 0),
            BRD_Balance_Content = new("BRD_Balance_Content", 1),
            BRD_Adv_DoT_Refresh = new("BRD_Adv_DoT_Refresh", 4),
            BRD_ST_DPS_DotBossOption = new("BRD_ST_DPS_DotBossOption", 0),
            BRD_ST_DPS_DotBossAddsOption = new("BRD_ST_DPS_DotBossAddsOption", 100),
            BRD_ST_DPS_DotTrashOption = new("BRD_ST_DPS_DotTrashOption", 30),
            BRD_Adv_Buffs_Threshold = new("BRD_Adv_Buffs_Threshold", 30),
            BRD_Adv_Buffs_SubOption = new("BRD_Adv_Buffs_SubOption", 0),
            BRD_AoE_Adv_MultidotBossOption = new("BRD_AoE_Adv_MultidotBossOption", 0),
            BRD_AoE_Adv_MultidotBossAddsOption = new("BRD_AoE_Adv_MultidotBossAddsOption", 100),
            BRD_AoE_Adv_MultidotTrashOption = new("BRD_AoE_Adv_MultidotTrashOption", 30),
            BRD_AoE_Adv_Multidot_Refresh = new("BRD_AoE_Adv_Multidot_Refresh", 4),
            BRD_AoE_Adv_Buffs_Threshold = new("BRD_AoE_Adv_Buffs_Threshold", 30),
            BRD_AoE_Adv_Buffs_SubOption = new("BRD_AoE_Adv_Buffs_SubOption", 0);

        public static UserBoolArray
            BRD_AoE_Adv_Buffs_Options = new("BRD_AoE_Adv_Buffs_Options"),
            BRD_Adv_Buffs_Options = new("BRD_Adv_Buffs_Options"),
            BRD_Adv_DoT_Options = new("BRD_Adv_DoT_Options"),
            BRD_StraightShotUpgrade_OGCDs_Options = new("BRD_StraightShotUpgrade_OGCDs_Options"),
            BRD_WideVolleyUpgrade_OGCDs_Options = new("BRD_WideVolleyUpgrade_OGCDs_Options");
        #endregion

        internal static void Draw(Preset preset)
        {
            switch (preset)
            {
                #region Single Target
                case Preset.BRD_ST_Adv_Balance_Standard:
                    DrawBossOnlyChoice(BRD_Balance_Content);
                    DrawOpenerPotionChoice(BRD_Opener_Potion);
                    DrawOpenerPrepullBlockChoice(BRD_Opener_PrepullBlock);
                    ImGuiEx.TextUnderlined(Generics.SelectOpener);
                    ImGui.Spacing();
                    DrawRadioButton(BRD_Adv_Opener_Selection, Generics.StandardOpener, "", 0, descriptionAsTooltip: true);
                    DrawRadioButton(BRD_Adv_Opener_Selection, BRD_Config.Adjusted248Opener, "", 1, descriptionAsTooltip: true);
                    DrawRadioButton(BRD_Adv_Opener_Selection, BRD_Config.Standard249Comfy, "", 2, descriptionAsTooltip: true);
                    DrawRadioButton(BRD_Adv_Opener_Selection, Generics.EarlyBuffWindowOpener, Generics.EarlyBuffWindowOpenerDesc, 3, descriptionAsTooltip: true);
                    break;

                case Preset.BRD_Adv_DoT:
                    DrawSliderInt(0, 100, BRD_ST_DPS_DotBossOption, Generics.BossOnlyHpPercent);
                    DrawSliderInt(0, 100, BRD_ST_DPS_DotBossAddsOption, Generics.BossEncounterNonBossHpPercent);
                    DrawSliderInt(0, 100, BRD_ST_DPS_DotTrashOption, Generics.NonBossHpPercent);
                    DrawSliderInt(3, 10, BRD_Adv_DoT_Refresh, BRD_Config.RenewTimeForDots);
                    DrawHorizontalMultiChoice(BRD_Adv_DoT_Options, BRD_Config.IronJawsOption, BRD_Config.IronJawsOptionDesc, 4, 0);
                    DrawHorizontalMultiChoice(BRD_Adv_DoT_Options, BRD_Config.DotApplicationOption, BRD_Config.DotApplicationOptionDesc, 4, 1);
                    DrawHorizontalMultiChoice(BRD_Adv_DoT_Options, BRD_Config.RagingJawsOption, BRD_Config.RagingJawsOptionDesc, 4, 2);
                    DrawHorizontalMultiChoice(BRD_Adv_DoT_Options, BRD_Config.MultiDotOption, BRD_Config.MultiDotOptionDesc, 4, 3);

                    if (BRD_Adv_DoT_Options[2])
                    {
                        DrawSliderInt(3, 10, BRD_RagingJawsRenewTime, BRD_Config.RagingJawsRenewTime);
                    }
                    break;

                case Preset.BRD_Adv_Buffs:
                    DrawSliderInt(0, 100, BRD_Adv_Buffs_Threshold,
                       BRD_Config.StopBuffsBelowHp);
                    ImGui.Indent();
                    ImGui.TextColored(ImGuiColors.DalamudYellow, Generics.EnemyTypeCheck);
                    DrawHorizontalRadioButton(BRD_Adv_Buffs_SubOption,
                        Generics.NonBossEncountersOnly, Generics.HPCheckNonBossEncountersOnly, 0);
                    DrawHorizontalRadioButton(BRD_Adv_Buffs_SubOption,
                        Generics.AllContent, Generics.HPCheckAllContent, 1);
                    ImGui.Unindent();
                    DrawHorizontalMultiChoice(BRD_Adv_Buffs_Options, BRD_Config.RagingStrikesOption, BRD_Config.AddsRagingStrikes, 4, 0);
                    DrawHorizontalMultiChoice(BRD_Adv_Buffs_Options, BRD_Config.BattlevoiceOption, BRD_Config.AddsBattleVoice, 4, 1);
                    DrawHorizontalMultiChoice(BRD_Adv_Buffs_Options, BRD_Config.BarrageOption, BRD_Config.AddsBarrage, 4, 2);
                    DrawHorizontalMultiChoice(BRD_Adv_Buffs_Options, BRD_Config.RadiantFinaleOption, BRD_Config.AddsRadiantFinale, 4, 3);
                    break;

                case Preset.BRD_ST_SecondWind:
                    DrawSliderInt(0, 100, BRD_STSecondWindThreshold,
                        BRD_Config.SecondWindHpThreshold);
                    break;

                case Preset.BRD_ST_Wardens:
                    DrawAdditionalBoolChoice(BRD_ST_Wardens_Auto, BRD_Config.PartyCleanseOption, BRD_Config.PartyCleanseOptionDesc);
                    break;
                #endregion

                #region AOE
                case Preset.BRD_AoE_Adv_Buffs:
                    DrawSliderInt(0, 100, BRD_AoE_Adv_Buffs_Threshold,
                        BRD_Config.StopBuffsBelowHpAoE);
                    ImGui.Indent();
                    ImGui.TextColored(ImGuiColors.DalamudYellow, Generics.EnemyTypeCheck);
                    DrawHorizontalRadioButton(BRD_AoE_Adv_Buffs_SubOption,
                        Generics.NonBossEncountersOnly, Generics.HPCheckNonBossEncountersOnly, 0);
                    DrawHorizontalRadioButton(BRD_AoE_Adv_Buffs_SubOption,
                        Generics.AllContent, Generics.HPCheckAllContent, 1);
                    ImGui.Unindent();
                    DrawHorizontalMultiChoice(BRD_AoE_Adv_Buffs_Options, BRD_Config.RagingStrikesOption, BRD_Config.AddsRagingStrikes, 4, 0);
                    DrawHorizontalMultiChoice(BRD_AoE_Adv_Buffs_Options, BRD_Config.BattlevoiceOption, BRD_Config.AddsBattleVoice, 4, 1);
                    DrawHorizontalMultiChoice(BRD_AoE_Adv_Buffs_Options, BRD_Config.BarrageOption, BRD_Config.AddsBarrage, 4, 2);
                    DrawHorizontalMultiChoice(BRD_AoE_Adv_Buffs_Options, BRD_Config.RadiantFinaleOption, BRD_Config.AddsRadiantFinale, 4, 3);
                    break;

                case Preset.BRD_AoE_SecondWind:
                    DrawSliderInt(0, 100, BRD_AoESecondWindThreshold,
                        BRD_Config.SecondWindHpThreshold);
                    break;

                case Preset.BRD_AoE_Adv_Multidot:
                    DrawSliderInt(0, 100, BRD_AoE_Adv_MultidotBossOption, Generics.BossOnlyHpPercent);
                    DrawSliderInt(0, 100, BRD_AoE_Adv_MultidotBossAddsOption, Generics.BossEncounterNonBossHpPercent);
                    DrawSliderInt(0, 100, BRD_AoE_Adv_MultidotTrashOption, Generics.NonBossHpPercent);
                    DrawSliderInt(3, 10, BRD_AoE_Adv_Multidot_Refresh, BRD_Config.RenewTimeForDots);
                    break;

                case Preset.BRD_AoE_Wardens:
                    DrawAdditionalBoolChoice(BRD_AoE_Wardens_Auto, BRD_Config.PartyCleanseOption, BRD_Config.PartyCleanseOptionDesc);
                    break;
                #endregion

                #region Standalone
                case Preset.BRD_StraightShotUpgrade_OGCDs:
                    DrawHorizontalMultiChoice(BRD_StraightShotUpgrade_OGCDs_Options, EmpyrealArrow.ActionName(), BRD_Config.AddsEmpyrealArrow, 4, 0);
                    DrawHorizontalMultiChoice(BRD_StraightShotUpgrade_OGCDs_Options, PitchPerfect.ActionName(), BRD_Config.AddsPitchPerfect, 4, 1);
                    DrawHorizontalMultiChoice(BRD_StraightShotUpgrade_OGCDs_Options, Bloodletter.ActionName(), BRD_Config.AddsBloodletterMaxCharges, 4, 2);
                    DrawHorizontalMultiChoice(BRD_StraightShotUpgrade_OGCDs_Options, Sidewinder.ActionName(), BRD_Config.AddsSidewinder, 4, 3);
                    break;

                case Preset.BRD_WideVolleyUpgrade_OGCDs:
                    DrawHorizontalMultiChoice(BRD_WideVolleyUpgrade_OGCDs_Options, EmpyrealArrow.ActionName(), BRD_Config.AddsEmpyrealArrow, 4, 0);
                    DrawHorizontalMultiChoice(BRD_WideVolleyUpgrade_OGCDs_Options, PitchPerfect.ActionName(), BRD_Config.AddsPitchPerfect, 4, 1);
                    DrawHorizontalMultiChoice(BRD_WideVolleyUpgrade_OGCDs_Options, RainOfDeath.ActionName(), BRD_Config.AddsRainOfDeath, 4, 2);
                    DrawHorizontalMultiChoice(BRD_WideVolleyUpgrade_OGCDs_Options, Sidewinder.ActionName(), BRD_Config.AddsSidewinder, 4, 3);
                    break;

                case Preset.BRD_IronJaws:
                    DrawAdditionalBoolChoice(BRD_IronJaws_Alternate, BRD_Config.IronJawsAlternate, BRD_Config.IronJawsAlternateDesc, 0);
                    DrawAdditionalBoolChoice(BRD_IronJaws_Apex, BRD_Config.ApexOption, BRD_Config.ApexOptionDesc, 0);
                    break;

                #endregion
            }
        }
    }
}
