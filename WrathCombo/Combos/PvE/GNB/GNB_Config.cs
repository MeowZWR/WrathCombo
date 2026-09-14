using System.Numerics;
using Dalamud.Interface.Colors;
using ECommons.ImGuiMethods;
using WrathCombo.CustomComboNS.Functions;
using WrathCombo.Data;
using WrathCombo.Extensions;
using WrathCombo.Resources.Localization.JobConfigs;
using WrathCombo.Window.Functions;
using static WrathCombo.Window.Functions.UserConfig;
using static WrathCombo.Window.Text;
using BossAvoidance = WrathCombo.Combos.PvE.All.Enums.BossAvoidance;
using PartyRequirement = WrathCombo.Combos.PvE.All.Enums.PartyRequirement;
namespace WrathCombo.Combos.PvE;

internal partial class GNB
{
    internal static class Config
    {
        private const int NumMitigationOptions = 8;
        public static UserInt
            GNB_ST_MitOptions = new("GNB_ST_MitOptions"),
            GNB_AoE_MitOptions = new("GNB_AoE_MitOptions"),
            GNB_ST_Advanced_MitOptions = new("GNB_ST_Advanced_MitOptions"),
            GNB_AoE_Advanced_MitOptions = new("GNB_AoE_Advanced_MitOptions"),
            GNB_Mit_Advanced_NonBoss_SuperBolide_Health = new("GNB_Mit_Advanced_NonBoss_SuperBolide_Health", 20),
            GNB_Mit_Advanced_Boss_Aurora_Health = new("GNB_Mit_Advanced_Boss_Aurora_Health", 99),
            GNB_Mit_Advanced_Boss_HeartOfStone_Health = new("GNB_Mit_Advanced_Boss_HeartOfStone_Health", 80),
            GNB_Mit_Advanced_Boss_HeartOfStoneDelay = new("GNB_Mit_Advanced_Boss_HeartOfStoneDelay"),
            GNB_Opener_NM = new("GNB_Opener_NM"),
            GNB_ST_NM_BossOption = new("GNB_ST_NM_BossOption"),
            GNB_ST_NM_HPOption = new("GNB_ST_NM_HPOption", 25),
            GNB_ST_Overcap_Choice = new("GNB_ST_Overcap_Choice"),
            GNB_ST_HoldLightningShot = new("GNB_ST_HoldLightningShot"),
            GNB_ST_HoldLightningShotInBurst = new("GNB_ST_HoldLightningShotInBurst"),
            GNB_ST_HoldGFCharge = new("GNB_ST_HoldGFCharge", 0),
            GNB_ST_BurstStrike_Setup = new("GNB_ST_BurstStrike_Setup"),
            GNB_AoE_FatedCircle_BurstStrike = new("GNB_AoE_FatedCircle_BurstStrike", 1),
            GNB_AoE_Overcap_Choice = new("GNB_AoE_Overcap_Choice"),
            GNB_AoE_NoMercyStop = new("GNB_AoE_NoMercyStop", 25),
            GNB_AoE_FatedCircle_Setup = new("GNB_AoE_FatedCircle_Setup"),
            GNB_AoE_SonicBreak_EarlyOrLate = new("GNB_AoE_SonicBreak_EarlyOrLate"),
            GNB_BS_DoubleDown_NMOnly = new("GNB_BS_DoubleDown_NMOnly", 0),
            GNB_FC_DoubleDown_NMOnly = new("GNB_FC_DoubleDown_NMOnly", 0),
            GNB_BS_Continuation_Procs = new("GNB_BS_Continuation_Procs", 0),
            GNB_FC_Continuation_Procs = new("GNB_FC_Continuation_Procs", 0),
            GNB_NM_Features_Weave = new("GNB_NM_Feature_Weave"),
            GNB_GF_Features_Choice = new("GNB_GF_Choice"),
            GNB_GF_Overcap_Choice = new("GNB_GF_Overcap_Choice"),
            GNB_GF_BurstStrike_Setup = new("GNB_GF_BurstStrike_Setup"),
            GNB_ST_Balance_Content = new("GNB_ST_Balance_Content", 1),
            GNB_RetargetLightningShot_SmartTargeting =  new("GNB_RetargetLightningShot_SmartTargeting"),
            GNB_Mit_OneButton_Superbolide_Health = new("GNB_Mit_OneButton_Superbolide_Health", 30),
            GNB_Mit_OneButton_Corundum_Health = new("GNB_Mit_OneButton_Corundum_Health", 60),
            GNB_Mit_OneButton_Aurora_Charges = new("GNB_Mit_OneButton_Aurora_Charges"),
            GNB_Mit_OneButton_Aurora_Health = new("GNB_Mit_OneButton_Aurora_Health", 60),
            GNB_Mit_OneButton_HeartOfLight_PartyRequirement = new("GNB_Mit_OneButton_HeartOfLight_PartyRequirement", (int)PartyRequirement.Yes),
            GNB_Mit_OneButton_ArmsLength_Boss = new("GNB_Mit_OneButton_ArmsLength_Boss", (int)BossAvoidance.On),
            GNB_Mit_OneButton_ArmsLength_EnemyCount = new("GNB_Mit_OneButton_ArmsLength_EnemyCount");

        public static UserFloat
            GNB_Mit_Advanced_Boss_Camouflage_Threshold = new("GNB_Mit_Advanced_Boss_Camouflage_Threshold", 80f),
            GNB_Mit_Advanced_NonBoss_MitigationThreshold = new("GNB_Mit_Advanced_NonBoss_MitigationThreshold", 20f);

        public static UserBool
            GNB_Opener_Potion = new("GNB_Opener_Potion"),
            GNB_Opener_PrepullBlock = new("GNB_Opener_PrepullBlock", true),
            GNB_Mit_Advanced_Boss_Camouflage_Align = new("GNB_Mit_Advanced_Boss_Camouflage_Align", true),
            GNB_Mit_Advanced_Boss_Nebula_First = new("GNB_Mit_Advanced_Boss_Nebula_First", true),
            GNB_RetargetLightningShot_FieldMO = new("GNB_RetargetLightningShot_FieldMO"),
            GNB_RetargetLightningShot_RangeBasedTargeting = new("GNB_RetargetLightningShot_RangeBasedTargeting"),
            GNB_RetargetLightningShot_SmartTargeting_NotTargetingPlayer = new("GNB_RetargetLightningShot_SmartTargeting_NotTargetingPlayer");

        public static UserIntArray
            GNB_Mit_OneButton_Priorities = new("GNB_Mit_OneButton_Priorities");

        public static UserBoolArray
            GNB_Mit_Advanced_Boss_HeartOfStone_OnCD_Difficulty = new("GNB_Mit_Advanced_Boss_HeartOfStone_OnCD_Difficulty", [true, false]),
            GNB_Mit_Advanced_Boss_HeartOfStone_TankBuster_Difficulty = new("GNB_Mit_Advanced_Boss_HeartOfStone_TankBuster_Difficulty", [true, false]),
            GNB_Mit_Advanced_Boss_Rampart_Difficulty = new("GNB_Mit_Advanced_Boss_Rampart_Difficulty", [true, false]),
            GNB_Mit_Advanced_Boss_Nebula_Difficulty = new("GNB_Mit_Advanced_Boss_Nebula_Difficulty", [true, false]),
            GNB_Mit_Advanced_Boss_Camouflage_Difficulty = new("GNB_Mit_Advanced_Boss_Camouflage_Difficulty", [true, false]),
            GNB_Mit_Advanced_Boss_HeartOfLight_Difficulty = new("GNB_Mit_Advanced_Boss_HeartOfLight_Difficulty", [true, false]),
            GNB_Mit_Advanced_Boss_Reprisal_Difficulty = new("GNB_Mit_Advanced_Boss_Reprisal_Difficulty", [true, false]),
            GNB_Mit_OneButton_Superbolide_Difficulty = new("GNB_Mit_OneButton_Superbolide_Difficulty", [true, false]);

        public static readonly ContentCheck.ListSet
            GNB_Boss_Mit_DifficultyListSet = ContentCheck.ListSet.CasualVSHard,
            GNB_Mit_OneButton_Superbolide_DifficultyListSet = ContentCheck.ListSet.CasualVSHard;

        internal static void Draw(Preset preset)
        {
            switch (preset)
            {
                #region Combo Mitigations

                case Preset.GNB_ST_Simple:
                    DrawHorizontalRadioButton(GNB_ST_MitOptions, Generics.IncludeSimpleMitigations, Generics.EnablesTheUseOfMitigations, 0);
                    DrawHorizontalRadioButton(GNB_ST_MitOptions, Generics.ExcludeSimpleMitigations, Generics.DisablesTheUseOfMitigations, 1);
                    break;

                case Preset.GNB_AoE_Simple:
                    DrawHorizontalRadioButton(GNB_AoE_MitOptions, Generics.IncludeSimpleMitigations, Generics.EnablesTheUseOfMitigations, 0);
                    DrawHorizontalRadioButton(GNB_AoE_MitOptions, Generics.ExcludeSimpleMitigations, Generics.DisablesTheUseOfMitigations, 1);
                    break;

                case Preset.GNB_ST_Advanced:
                    DrawHorizontalRadioButton(GNB_ST_Advanced_MitOptions, Generics.IncludeAdvancedMitigations , Generics.EnablesTheUseOfMitigations, 0);
                    DrawHorizontalRadioButton(GNB_ST_Advanced_MitOptions, Generics.ExcludeAdvancedMitigations, Generics.DisablesTheUseOfMitigations, 1);
                    break;

                case Preset.GNB_AoE_Advanced:
                    DrawHorizontalRadioButton(GNB_AoE_Advanced_MitOptions, Generics.IncludeAdvancedMitigations , Generics.EnablesTheUseOfMitigations, 0);
                    DrawHorizontalRadioButton(GNB_AoE_Advanced_MitOptions, Generics.ExcludeAdvancedMitigations, Generics.DisablesTheUseOfMitigations, 1);
                    break;

                case Preset.GNB_Mit_Advanced_NonBoss:
                    DrawSliderFloat(0, 100, GNB_Mit_Advanced_NonBoss_MitigationThreshold, Generics.StopBelowAverageEnemyHP, decimals: 0);
                    break;

                case Preset.GNB_Mit_Advanced_NonBoss_SuperBolideEmergency:
                    DrawSliderInt(1, 100, GNB_Mit_Advanced_NonBoss_SuperBolide_Health, FormatAndCache(Generics.PlayerHPToUseAction, Superbolide.ActionName()));
                    break;

                case Preset.GNB_Mit_Advanced_Boss_Aurora:
                    DrawSliderInt(1, 100, GNB_Mit_Advanced_Boss_Aurora_Health, FormatAndCache(Generics.PlayerHPToUseAction, Aurora.ActionName()));
                    break;

                case Preset.GNB_Mit_Advanced_Boss_HeartOfStone_OnCD:
                    DrawDifficultyMultiChoice(GNB_Mit_Advanced_Boss_HeartOfStone_OnCD_Difficulty, GNB_Boss_Mit_DifficultyListSet,
                        Generics.SelectWhatKindOfContentThisOptionAppliesTo);
                    DrawSliderInt(1, 100, GNB_Mit_Advanced_Boss_HeartOfStone_Health, FormatAndCache(Generics.PlayerHPToUseAction, $"{HeartOfStone.ActionName()} / {HeartOfCorundum.ActionName()}"));
                    break;

                case Preset.GNB_Mit_Advanced_Boss_HeartOfStone_TankBuster:
                    DrawDifficultyMultiChoice(GNB_Mit_Advanced_Boss_HeartOfStone_TankBuster_Difficulty, GNB_Boss_Mit_DifficultyListSet,
                        Generics.SelectWhatKindOfContentThisOptionAppliesTo);
                    DrawSliderInt(0, 4, GNB_Mit_Advanced_Boss_HeartOfStoneDelay, FormatAndCache(Generics.DelayMit, HeartOfStone.ActionName()), sliderIncrement: 1);
                    break;

                case Preset.GNB_Mit_Advanced_Boss_Rampart:
                    DrawDifficultyMultiChoice(GNB_Mit_Advanced_Boss_Rampart_Difficulty, GNB_Boss_Mit_DifficultyListSet,
                        Generics.SelectWhatKindOfContentThisOptionAppliesTo);
                    break;

                case Preset.GNB_Mit_Advanced_Boss_Nebula:
                    DrawDifficultyMultiChoice(GNB_Mit_Advanced_Boss_Nebula_Difficulty, GNB_Boss_Mit_DifficultyListSet,
                        Generics.SelectWhatKindOfContentThisOptionAppliesTo);
                    DrawAdditionalBoolChoice(GNB_Mit_Advanced_Boss_Nebula_First, GNB_Config.UseNebulaFirst, GNB_Config.UseNebulaFirstDesc);
                    break;

                case Preset.GNB_Mit_Advanced_Boss_Camouflage:
                    DrawDifficultyMultiChoice(GNB_Mit_Advanced_Boss_Camouflage_Difficulty, GNB_Boss_Mit_DifficultyListSet,
                        Generics.SelectWhatKindOfContentThisOptionAppliesTo);
                    DrawSliderFloat(1, 100, GNB_Mit_Advanced_Boss_Camouflage_Threshold, GNB_Config.CamouflageHP, decimals: 0);
                    DrawAdditionalBoolChoice(GNB_Mit_Advanced_Boss_Camouflage_Align, GNB_Config.AlignCamouflage, GNB_Config.AlignCamouflageDesc);
                    break;

                case Preset.GNB_Mit_Advanced_Boss_HeartOfLight:
                    DrawDifficultyMultiChoice(GNB_Mit_Advanced_Boss_HeartOfLight_Difficulty, GNB_Boss_Mit_DifficultyListSet,
                        Generics.SelectWhatKindOfContentThisOptionAppliesTo);
                    break;

                case Preset.GNB_Mit_Advanced_Boss_Reprisal:
                    DrawDifficultyMultiChoice(GNB_Mit_Advanced_Boss_Reprisal_Difficulty, GNB_Boss_Mit_DifficultyListSet,
                        Generics.SelectWhatKindOfContentThisOptionAppliesTo);
                    break;

                #endregion

                #region Single-Target

                case Preset.GNB_ST_Opener:
                    DrawBossOnlyChoice(GNB_ST_Balance_Content);
                    DrawOpenerPotionChoice(GNB_Opener_Potion);
                    DrawOpenerPrepullBlockChoice(GNB_Opener_PrepullBlock);
                    ImGuiEx.TextUnderlined(FormatAndCache(Generics.ActionSettings, NoMercy.ActionName()));
                    ImGui.Spacing();
                    DrawRadioButton(GNB_Opener_NM,
                        FormatAndCache(GNB_Config.NormalAction, NoMercy.ActionName()), FormatAndCache(GNB_Config.NormalActionOpenerDesc, NoMercy.ActionName()), 0, descriptionAsTooltip: true);
                    DrawRadioButton(GNB_Opener_NM,
                        FormatAndCache(GNB_Config.EarlyAction, NoMercy.ActionName()), FormatAndCache(GNB_Config.EarlyActionOpenerDesc, NoMercy.ActionName()), 1, descriptionAsTooltip: true);
                    break;

                case Preset.GNB_ST_NoMercy:
                    DrawSliderInt(0, 50, GNB_ST_NM_HPOption,
                        Generics.StopEnemyHpPercent);

                    ImGui.Indent();
                    ImGui.TextColored(ImGuiColors.DalamudYellow,
                        Generics.EnemyTypeCheck);

                    DrawHorizontalRadioButton(GNB_ST_NM_BossOption,
                        Generics.NonBosses, Generics.HPCheckNonBosses, 0);

                    DrawHorizontalRadioButton(GNB_ST_NM_BossOption,
                        Generics.AllEnemies, Generics.HPCheckAllEnemies, 1);
                    ImGui.Unindent();
                    break;

                case Preset.GNB_ST_BurstStrike:
                    DrawHorizontalRadioButton(GNB_ST_Overcap_Choice,
                        GNB_Config.IncludeOvercapProtection, FormatAndCache(GNB_Config.IncludeOvercapProtectionDesc, BurstStrike.ActionName()), 0);
                    DrawHorizontalRadioButton(GNB_ST_Overcap_Choice,
                        GNB_Config.ExcludeOvercapProtection, FormatAndCache(GNB_Config.ExcludeOvercapProtectionDesc, BurstStrike.ActionName()), 1);
                    ImGui.Spacing();
                    DrawHorizontalRadioButton(GNB_ST_BurstStrike_Setup,
                        FormatAndCache(GNB_Config.PrecedeAction, NoMercy.ActionName()), FormatAndCache(GNB_Config.PrecedeActionDesc, NoMercy.ActionName(), BurstStrike.ActionName(), Hypervelocity.ActionName(), "BS->NM->HV"), 0);
                    DrawHorizontalRadioButton(GNB_ST_BurstStrike_Setup,
                        FormatAndCache(GNB_Config.DontPrecedeAction, NoMercy.ActionName()), FormatAndCache(GNB_Config.DontPrecedeActionDesc, NoMercy.ActionName(), BurstStrike.ActionName()), 1);
                    break;

                case Preset.GNB_ST_GnashingFang:
                    DrawHorizontalRadioButton(GNB_ST_HoldGFCharge,
                        GNB_Config.HoldForBurst, FormatAndCache(GNB_Config.HoldOneChargeForBurstDesc, GnashingFang.ActionName(), NoMercy.ActionName()), 0);
                    DrawHorizontalRadioButton(GNB_ST_HoldGFCharge,
                        GNB_Config.DontHoldForBurst, FormatAndCache(GNB_Config.DontHoldChargesForBurstDesc, GnashingFang.ActionName(), NoMercy.ActionName()), 1);
                    break;

                case Preset.GNB_ST_RangedUptime:
                    DrawHorizontalRadioButton(GNB_ST_HoldLightningShot,
                        FormatAndCache(GNB_Config.HoldForAction, Continuation.ActionName()), FormatAndCache(GNB_Config.HoldForProcsDesc, LightningShot.ActionName(), Continuation.ActionName()), 1);
                    DrawHorizontalRadioButton(GNB_ST_HoldLightningShot,
                        FormatAndCache(GNB_Config.DontHoldForAction, Continuation.ActionName()), FormatAndCache(GNB_Config.DontHoldForProcsDesc, LightningShot.ActionName(), Continuation.ActionName()), 0);
                    ImGui.Spacing();
                    DrawHorizontalRadioButton(GNB_ST_HoldLightningShotInBurst,
                        FormatAndCache(GNB_Config.HoldUnder, NoMercy.ActionName()), FormatAndCache(GNB_Config.HoldUnderBuffDesc, LightningShot.ActionName(), NoMercy.ActionName()), 1);
                    DrawHorizontalRadioButton(GNB_ST_HoldLightningShotInBurst,
                        FormatAndCache(GNB_Config.DontHoldUnder, NoMercy.ActionName()), FormatAndCache(GNB_Config.DontHoldUnderBuffDesc, LightningShot.ActionName(), NoMercy.ActionName()), 0);

                    break;

                #endregion

                #region AoE

                case Preset.GNB_AoE_NoMercy:
                    DrawSliderInt(0, 75, GNB_AoE_NoMercyStop,
                        GNB_Config.AoENoMercyStop);
                    break;

                case Preset.GNB_AoE_FatedCircle:
                    DrawHorizontalRadioButton(GNB_AoE_Overcap_Choice,
                        GNB_Config.IncludeOvercapProtection, FormatAndCache(GNB_Config.IncludeOvercapProtectionDesc, FatedCircle.ActionName()), 0);
                    DrawHorizontalRadioButton(GNB_AoE_Overcap_Choice,
                        GNB_Config.ExcludeOvercapProtection, FormatAndCache(GNB_Config.ExcludeOvercapProtectionDesc, FatedCircle.ActionName()), 1);
                    ImGui.Spacing();
                    DrawHorizontalRadioButton(GNB_AoE_FatedCircle_BurstStrike,
                        GNB_Config.IncludeBurstStrike, FormatAndCache(GNB_Config.IncludeBurstStrikeDesc, BurstStrike.ActionName(), FatedCircle.ActionName()), 0);
                    DrawHorizontalRadioButton(GNB_AoE_FatedCircle_BurstStrike,
                        GNB_Config.ExcludeBurstStrike, FormatAndCache(GNB_Config.ExcludeBurstStrikeDesc, BurstStrike.ActionName(), FatedCircle.ActionName()), 1);
                    ImGui.Spacing();
                    DrawHorizontalRadioButton(GNB_AoE_FatedCircle_Setup,
                        FormatAndCache(GNB_Config.PrecedeAction, NoMercy.ActionName()), FormatAndCache(GNB_Config.PrecedeActionDesc, NoMercy.ActionName(), FatedCircle.ActionName(), FatedBrand.ActionName(), "FC->NM->FB"), 0);
                    DrawHorizontalRadioButton(GNB_AoE_FatedCircle_Setup,
                        FormatAndCache(GNB_Config.DontPrecedeAction, NoMercy.ActionName()), FormatAndCache(GNB_Config.DontPrecedeActionDesc, NoMercy.ActionName(), FatedCircle.ActionName()), 1);
                    break;

                case Preset.GNB_AoE_SonicBreak:
                    DrawHorizontalRadioButton(GNB_AoE_SonicBreak_EarlyOrLate,
                        GNB_Config.NormalUsage, FormatAndCache(GNB_Config.NormalUsageDesc, SonicBreak.ActionName()), 0);
                    DrawHorizontalRadioButton(GNB_AoE_SonicBreak_EarlyOrLate,
                        GNB_Config.LateUsage, FormatAndCache(GNB_Config.LateUsageDesc, SonicBreak.ActionName()), 1);
                    break;

                #endregion

                #region One-Button Mitigation

                case Preset.GNB_Mit_OneButton_Superbolide_Max:
                    DrawDifficultyMultiChoice(GNB_Mit_OneButton_Superbolide_Difficulty, GNB_Mit_OneButton_Superbolide_DifficultyListSet,
                        FormatAndCache(Generics.SelectDifficultyActionIn, Superbolide.ActionName()));
                    DrawSliderInt(1, 100, GNB_Mit_OneButton_Superbolide_Health, Generics.StopFriendlyHpPercent100, 200, SliderIncrements.Fives);
                    break;

                case Preset.GNB_Mit_OneButton_Corundum:
                    DrawSliderInt(1, 100, GNB_Mit_OneButton_Corundum_Health,
                        Generics.StopFriendlyHpPercent100,
                        sliderIncrement: SliderIncrements.Ones);
                    DrawPriorityInput(GNB_Mit_OneButton_Priorities, NumMitigationOptions, 0,
                        FormatAndCache(Generics.Action_Priority, HeartOfCorundum.ActionName()));
                    break;

                case Preset.GNB_Mit_OneButton_Aurora:
                    DrawSliderInt(0, 1, GNB_Mit_OneButton_Aurora_Charges,
                        Generics.HowManyChargesToKeepReady);
                    DrawSliderInt(1, 100, GNB_Mit_OneButton_Aurora_Health,
                        Generics.StopFriendlyHpPercent100,
                        sliderIncrement: SliderIncrements.Ones);
                    DrawPriorityInput(GNB_Mit_OneButton_Priorities, NumMitigationOptions, 1,
                        FormatAndCache(Generics.Action_Priority, Aurora.ActionName()));
                    break;

                case Preset.GNB_Mit_OneButton_Camouflage:
                    DrawPriorityInput(GNB_Mit_OneButton_Priorities, NumMitigationOptions, 2,
                        FormatAndCache(Generics.Action_Priority, Camouflage.ActionName()));
                    break;

                case Preset.GNB_Mit_OneButton_Reprisal:
                    DrawPriorityInput(GNB_Mit_OneButton_Priorities, NumMitigationOptions, 3,
                        FormatAndCache(Generics.Action_Priority, Role.Reprisal.ActionName()));
                    break;

                case Preset.GNB_Mit_OneButton_HeartOfLight:
                    ImGui.Indent();
                    DrawHorizontalRadioButton(GNB_Mit_OneButton_HeartOfLight_PartyRequirement,
                        Generics.RequirePartyLabel, GNB_Config.HeartOfLightRequirePartyDesc,
                        (int)PartyRequirement.Yes);
                    DrawHorizontalRadioButton(GNB_Mit_OneButton_HeartOfLight_PartyRequirement,
                        Generics.UseAlwaysLabel, GNB_Config.HeartOfLightUseAlwaysDesc,
                        (int)PartyRequirement.No);
                    ImGui.Unindent();
                    DrawPriorityInput(GNB_Mit_OneButton_Priorities, NumMitigationOptions, 4,
                        FormatAndCache(Generics.Action_Priority, HeartOfLight.ActionName()));
                    break;

                case Preset.GNB_Mit_OneButton_Rampart:
                    DrawPriorityInput(GNB_Mit_OneButton_Priorities, NumMitigationOptions, 5,
                        FormatAndCache(Generics.Action_Priority, Role.Rampart.ActionName()));
                    break;

                case Preset.GNB_Mit_OneButton_ArmsLength:
                    ImGui.Indent();
                    DrawHorizontalRadioButton(GNB_Mit_OneButton_ArmsLength_Boss,
                        Generics.AllEnemies, Generics.ArmsLengthRegardless,
                        (int)BossAvoidance.Off, 125f);
                    DrawHorizontalRadioButton(
                        GNB_Mit_OneButton_ArmsLength_Boss,
                        Generics.AvoidBosses, Generics.ArmsLengthAvoidBosses,
                        (int)BossAvoidance.On, 125f);
                    ImGui.Unindent();
                    DrawSliderInt(0, 5, GNB_Mit_OneButton_ArmsLength_EnemyCount,
                        Generics.NearbyEnemyCount);
                    DrawPriorityInput(GNB_Mit_OneButton_Priorities, NumMitigationOptions, 6,
                        FormatAndCache(Generics.Action_Priority, Role.ArmsLength.ActionName()));
                    break;

                case Preset.GNB_Mit_OneButton_Nebula:
                    DrawPriorityInput(GNB_Mit_OneButton_Priorities, NumMitigationOptions, 7,
                        FormatAndCache(Generics.Action_Priority, Nebula.ActionName()));
                    break;

                #endregion

                #region Other

                case Preset.GNB_NM_Features:
                    DrawHorizontalRadioButton(GNB_NM_Features_Weave,
                        GNB_Config.WeaveOnly, GNB_Config.WeaveOnlyDesc, 0);
                    DrawHorizontalRadioButton(GNB_NM_Features_Weave,
                        GNB_Config.OnCooldown, GNB_Config.OnCooldownDesc, 1);
                    break;

                case Preset.GNB_GF_Features:
                    DrawHorizontalRadioButton(GNB_GF_Features_Choice,
                        GNB_Config.ReplaceGnashingFang, FormatAndCache(GNB_Config.ReplaceGnashingFangDesc, GnashingFang.ActionName()), 0);
                    DrawHorizontalRadioButton(GNB_GF_Features_Choice,
                        GNB_Config.ReplaceNoMercy, FormatAndCache(GNB_Config.ReplaceNoMercyDesc, NoMercy.ActionName()), 1);
                    break;

                case Preset.GNB_GF_BurstStrike:
                    DrawHorizontalRadioButton(GNB_GF_Overcap_Choice,
                        GNB_Config.IncludeOvercapProtection, FormatAndCache(GNB_Config.IncludeOvercapProtectionDesc, BurstStrike.ActionName()), 0);
                    DrawHorizontalRadioButton(GNB_GF_Overcap_Choice,
                        GNB_Config.ExcludeOvercapProtection, FormatAndCache(GNB_Config.ExcludeOvercapProtectionDesc, BurstStrike.ActionName()), 1);
                    ImGui.Spacing();
                    DrawHorizontalRadioButton(GNB_GF_BurstStrike_Setup,
                        FormatAndCache(GNB_Config.PrecedeAction, NoMercy.ActionName()), FormatAndCache(GNB_Config.PrecedeActionDesc, NoMercy.ActionName(), BurstStrike.ActionName(), Hypervelocity.ActionName(), "BS->NM->HV"), 0);
                    DrawHorizontalRadioButton(GNB_GF_BurstStrike_Setup,
                        FormatAndCache(GNB_Config.DontPrecedeAction, NoMercy.ActionName()), FormatAndCache(GNB_Config.DontPrecedeActionDesc, NoMercy.ActionName(), BurstStrike.ActionName()), 1);
                    break;

                case Preset.GNB_FC_DoubleDown:
                    DrawHorizontalRadioButton(GNB_FC_DoubleDown_NMOnly,
                        GNB_Config.HoldForBurst, FormatAndCache(GNB_Config.HoldUntilBuffedDesc, DoubleDown.ActionName(), NoMercy.ActionName()), 0);
                    DrawHorizontalRadioButton(GNB_FC_DoubleDown_NMOnly,
                        GNB_Config.DontHoldForBurst, FormatAndCache(GNB_Config.UseRegardlessOfBuffDesc, DoubleDown.ActionName(), NoMercy.ActionName()), 1);
                    break;

                case Preset.GNB_BS_DoubleDown:
                    DrawHorizontalRadioButton(GNB_BS_DoubleDown_NMOnly,
                        GNB_Config.HoldForBurst, FormatAndCache(GNB_Config.HoldUntilBuffedDesc, DoubleDown.ActionName(), NoMercy.ActionName()), 0);
                    DrawHorizontalRadioButton(GNB_BS_DoubleDown_NMOnly,
                        GNB_Config.DontHoldForBurst, FormatAndCache(GNB_Config.UseRegardlessOfBuffDesc, DoubleDown.ActionName(), NoMercy.ActionName()), 1);
                    break;

                case Preset.GNB_BS_Continuation:
                    DrawHorizontalRadioButton(GNB_BS_Continuation_Procs,
                        GNB_Config.AllProcs, FormatAndCache(GNB_Config.AllProcsDesc, Continuation.ActionName()), 0);
                    DrawHorizontalRadioButton(GNB_BS_Continuation_Procs,
                        GNB_Config.OnlyHypervelocity, FormatAndCache(GNB_Config.OnlyProcDesc, Hypervelocity.ActionName(), Continuation.ActionName()), 1);
                    break;

                case Preset.GNB_FC_Continuation:
                    DrawHorizontalRadioButton(GNB_FC_Continuation_Procs,
                        GNB_Config.AllProcs, FormatAndCache(GNB_Config.AllProcsDesc, Continuation.ActionName()), 0);
                    DrawHorizontalRadioButton(GNB_FC_Continuation_Procs,
                        GNB_Config.OnlyFatedBrand, FormatAndCache(GNB_Config.OnlyProcDesc, FatedBrand.ActionName(), Continuation.ActionName()), 1);
                    break;
                
                case Preset.GNB_RetargetLightningShot:
                    DrawAdditionalBoolChoice(GNB_RetargetLightningShot_FieldMO, Generics.Mouseover, FormatAndCache(Generics.MouseoverRetargetHostile, LightningShot.ActionName()));
                    
                    DrawAdditionalBoolChoice(GNB_RetargetLightningShot_RangeBasedTargeting, Generics.RangeBasedTargeting, Generics.RangeBasedTargetingDesc);
                    
                    if (GNB_RetargetLightningShot_RangeBasedTargeting)
                    {
                        ImGui.Indent();
                        ImGui.NewLine();
                        DrawHorizontalRadioButton(GNB_RetargetLightningShot_SmartTargeting,
                            Generics.FurthestOOR, 
                            FormatAndCache(Generics.FurthestOORRetarget, LightningShot.ActionName()), 0, 
                            descriptionColor:ImGuiColors.DalamudWhite);
                        DrawHorizontalRadioButton(GNB_RetargetLightningShot_SmartTargeting,
                            Generics.NearestOOR, 
                            FormatAndCache(Generics.NearestOORRetarget, LightningShot.ActionName()), 1, 
                            descriptionColor:ImGuiColors.DalamudWhite);
                        ImGuiEx.Spacing(new Vector2(0, 5));
                        ImGui.Unindent();
                        
                        ImGui.Indent(10f.Scale());
                        DrawAdditionalBoolChoice(GNB_RetargetLightningShot_SmartTargeting_NotTargetingPlayer, Generics.SmartTargeting, Generics.SmartTargetingNotTargetingPlayer);
                        ImGui.Unindent();
                    }
                    break;
                    
                    #endregion
            }
        }
    }
}
