using System.Numerics;
using Dalamud.Interface.Colors;
using Dalamud.Interface.Style;
using Dalamud.Interface.Utility.Raii;
using ECommons.ImGuiMethods;
using WrathCombo.CustomComboNS.Functions;
using WrathCombo.Data;
using WrathCombo.Extensions;
using WrathCombo.Resources.Localization.JobConfigs;
using WrathCombo.Window.Functions;
using static WrathCombo.Window.Text;
using static WrathCombo.Window.Functions.UserConfig;
using BossAvoidance = WrathCombo.Combos.PvE.All.Enums.BossAvoidance;
using PartyRequirement = WrathCombo.Combos.PvE.All.Enums.PartyRequirement;
namespace WrathCombo.Combos.PvE;

internal partial class WAR
{
    internal static class Config
    {
        internal static void Draw(Preset preset)
        {
            switch (preset)
            {
                #region Combo Mitigations
                case Preset.WAR_ST_Simple:
                    DrawHorizontalRadioButton(WAR_ST_MitsOptions, Generics.IncludeSimpleMitigations, Generics.EnablesTheUseOfMitigations, 0);
                    DrawHorizontalRadioButton(WAR_ST_MitsOptions, Generics.ExcludeSimpleMitigations, Generics.DisablesTheUseOfMitigations, 1);
                    break;

                case Preset.WAR_AoE_Simple:
                    DrawHorizontalRadioButton(WAR_AoE_MitsOptions, Generics.IncludeSimpleMitigations, Generics.EnablesTheUseOfMitigations, 0);
                    DrawHorizontalRadioButton(WAR_AoE_MitsOptions, Generics.ExcludeSimpleMitigations, Generics.DisablesTheUseOfMitigations, 1);
                    break;

                case Preset.WAR_ST_Advanced:
                    DrawHorizontalRadioButton(WAR_ST_Advanced_MitsOptions, Generics.IncludeAdvancedMitigations , Generics.EnablesTheUseOfMitigations, 0);
                    DrawHorizontalRadioButton(WAR_ST_Advanced_MitsOptions, Generics.ExcludeAdvancedMitigations, Generics.DisablesTheUseOfMitigations, 1);
                    break;

                case Preset.WAR_AoE_Advanced:
                    DrawHorizontalRadioButton(WAR_AoE_Advanced_MitsOptions, Generics.IncludeAdvancedMitigations , Generics.EnablesTheUseOfMitigations, 0);
                    DrawHorizontalRadioButton(WAR_AoE_Advanced_MitsOptions, Generics.ExcludeAdvancedMitigations, Generics.DisablesTheUseOfMitigations, 1);
                    break;

                case Preset.WAR_Mitigation_NonBoss:
                    DrawSliderFloat(0, 100, WAR_Mitigation_NonBoss_MitigationThreshold, Generics.StopBelowAverageEnemyHP, decimals: 0);
                    break;

                case Preset.WAR_Mitigation_NonBoss_ShakeItOff:
                    DrawSliderInt(1, 100, WAR_Mitigation_NonBoss_ShakeItOff_Health, FormatAndCache(Generics.PlayerHPToUseAction, ShakeItOff.ActionName()));
                    break;

                case Preset.WAR_Mitigation_NonBoss_Equilibrium:
                    DrawSliderInt(1, 100, WAR_Mitigation_NonBoss_Equilibrium_Health, FormatAndCache(Generics.PlayerHPToUseAction, Equilibrium.ActionName()));
                    break;

                case Preset.WAR_Mitigation_NonBoss_Holmgang:
                    DrawSliderInt(1, 100, WAR_Mitigation_NonBoss_Holmgang_Health, FormatAndCache(Generics.PlayerHPToUseAction, Holmgang.ActionName()));
                    break;

                case Preset.WAR_Mitigation_Boss_Equilibrium:
                    DrawSliderInt(1, 100, WAR_Mitigation_Boss_Equilibrium_Health, FormatAndCache(Generics.PlayerHPToUseAction, Equilibrium.ActionName()));
                    DrawSliderInt(1, 100, WAR_Mitigation_Boss_Tankbuster_Equilibrium_Health, WAR_Config.EquilibriumTankbusterHp);
                    break;

                case Preset.WAR_Mitigation_Boss_RawIntuition_OnCD:
                    DrawDifficultyMultiChoice(WAR_Mitigation_Boss_RawIntuition_OnCD_Difficulty, WAR_Boss_Mit_DifficultyListSet ,
                        Generics.SelectWhatKindOfContentThisOptionAppliesTo);
                    DrawSliderInt(1, 100, WAR_Mitigation_Boss_RawIntuition_Health, FormatAndCache(Generics.PlayerHPToUseAction, $"{RawIntuition.ActionName()}/{Bloodwhetting.ActionName()}"));
                    break;

                case Preset.WAR_Mitigation_Boss_RawIntuition_TankBuster:
                    DrawDifficultyMultiChoice(WAR_Mitigation_Boss_RawIntuition_TankBuster_Difficulty, WAR_Boss_Mit_DifficultyListSet ,
                        Generics.SelectWhatKindOfContentThisOptionAppliesTo);
                    DrawSliderInt(0, 4, WAR_Mitigation_Boss_RawIntuitionDelay, FormatAndCache(Generics.DelayMit, RawIntuition.ActionName()), sliderIncrement: 1);
                    break;

                case Preset.WAR_Mitigation_Boss_Rampart:
                    DrawDifficultyMultiChoice(WAR_Mitigation_Boss_Rampart_Difficulty, WAR_Boss_Mit_DifficultyListSet ,
                        Generics.SelectWhatKindOfContentThisOptionAppliesTo);
                    break;

                case Preset.WAR_Mitigation_Boss_Vengeance:
                    DrawDifficultyMultiChoice(WAR_Mitigation_Boss_Vengeance_Difficulty, WAR_Boss_Mit_DifficultyListSet ,
                        Generics.SelectWhatKindOfContentThisOptionAppliesTo);
                    DrawAdditionalBoolChoice(WAR_Mitigation_Boss_Vengeance_First, WAR_Config.UseVengeanceFirst, WAR_Config.UseVengeanceFirstDesc);
                    break;

                case Preset.WAR_Mitigation_Boss_ThrillOfBattle:
                    DrawDifficultyMultiChoice(WAR_Mitigation_Boss_ThrillOfBattle_Difficulty, WAR_Boss_Mit_DifficultyListSet ,
                        Generics.SelectWhatKindOfContentThisOptionAppliesTo);
                    DrawSliderFloat(1, 100, WAR_Mitigation_Boss_ThrillOfBattle_Threshold, WAR_Config.ThrillTankbusterHp, decimals: 0);
                    DrawAdditionalBoolChoice(WAR_Mitigation_Boss_ThrillOfBattle_Align, WAR_Config.AlignThrillOfBattle, WAR_Config.AlignThrillOfBattleDesc);
                    break;

                case Preset.WAR_Mitigation_Boss_ShakeItOff:
                    DrawDifficultyMultiChoice(WAR_Mitigation_Boss_ShakeItOff_Difficulty, WAR_Boss_Mit_DifficultyListSet ,
                        Generics.SelectWhatKindOfContentThisOptionAppliesTo);
                    break;

                case Preset.WAR_Mitigation_Boss_Reprisal:
                    DrawDifficultyMultiChoice(WAR_Mitigation_Boss_Reprisal_Difficulty, WAR_Boss_Mit_DifficultyListSet ,
                        Generics.SelectWhatKindOfContentThisOptionAppliesTo);
                    break;
                #endregion

                #region Single-Target
                case Preset.WAR_ST_BalanceOpener:
                    DrawBossOnlyChoice(WAR_BalanceOpener_Content);
                    DrawOpenerPotionChoice(WAR_Opener_Potion);
                    DrawOpenerPrepullBlockChoice(WAR_Opener_PrepullBlock);

                    ImGuiEx.TextUnderlined(FormatAndCache(Generics.ActionSettings, Onslaught.ActionName()));
                    ImGui.Spacing();
                    DrawRadioButton(WAR_ST_BalanceOpener_GapcloserChoice,
                        WAR_Config.UseGapclosers, WAR_Config.UseGapclosersDesc, 1, descriptionAsTooltip: true);
                    DrawRadioButton(WAR_ST_BalanceOpener_GapcloserChoice,
                        WAR_Config.NoGapclosers, WAR_Config.NoGapclosersDesc, 0, descriptionAsTooltip: true);
                    break;

                case Preset.WAR_ST_StormsEye:
                    DrawSliderInt(0, 30, WAR_SurgingRefreshRange,
                        FormatAndCache(WAR_Config.SurgingTempestRefresh, Buffs.SurgingTempest.StatusName()));
                    break;

                case Preset.WAR_ST_InnerRelease:
                    DrawSliderInt(0, 75, WAR_ST_InnerRelease_Threshold,
                        Generics.StopEnemyHpPercent);
                    ImGui.Indent();
                    ImGui.TextColored(ImGuiColors.DalamudYellow, Generics.EnemyTypeCheck);
                    ImGui.NewLine();
                    DrawHorizontalRadioButton(WAR_ST_InnerRelease_Threshold_SubOption,
                        Generics.NonBossEncountersOnly, Generics.HPCheckNonBossEncountersOnly, 0);
                    DrawHorizontalRadioButton(WAR_ST_InnerRelease_Threshold_SubOption,
                        Generics.AllContent, Generics.HPCheckAllContent, 1);
                    ImGui.Unindent();
                    break;

                case Preset.WAR_ST_Onslaught:
                    DrawAdditionalBoolChoice(WAR_ST_Onslaught_ManualPooling, 
                        FormatAndCache(Generics.Align0WithManual1, Onslaught.ActionName(), InnerRelease.ActionName()), "");
                    DrawHorizontalRadioButton(WAR_ST_Onslaught_Movement,
                        Generics.StationaryOnly, FormatAndCache(Generics.UseActionOnlyWhileStationary, Onslaught.ActionName()), 0);
                    DrawHorizontalRadioButton(WAR_ST_Onslaught_Movement,
                        Generics.AnyMovement, FormatAndCache(Generics.Uses0RegardlessOfAnyMovementConditions, Onslaught.ActionName()), 1);
                    ImGui.Spacing();
                    if (WAR_ST_Onslaught_Movement == 0)
                    {
                        ImGui.SetCursorPosX(48);
                        DrawSliderFloat(0, 3, WAR_ST_Onslaught_TimeStill,
                            Generics.StationaryDelayCheck, decimals: 1);
                    }
                    ImGui.SetCursorPosX(48);
                    DrawSliderInt(0, 2, WAR_ST_Onslaught_Charges,
                        Generics.HowManyChargesToKeepReady);
                    ImGui.SetCursorPosX(48);
                    DrawSliderFloat(1, 20, WAR_ST_Onslaught_Distance,
                        Generics.UseWhenDistanceFromTargetIsLessThanOrEqualTo, decimals: 1);
                    break;

                case Preset.WAR_ST_Infuriate:
                    DrawSliderInt(0, 2, WAR_ST_Infuriate_Charges,
                        Generics.HowManyChargesToKeepReady);
                    DrawSliderInt(0, 50, WAR_ST_Infuriate_Gauge,
                        WAR_Config.BeastGaugeLessOrEqual);
                    break;

                case Preset.WAR_ST_FellCleave:
                    DrawAdditionalBoolChoice(WAR_ST_FellCleave_Pooling, WAR_Config.BurstPooling, WAR_Config.BurstPoolingDesc);
                    if (WAR_ST_FellCleave_Pooling)
                    {
                        DrawAdditionalBoolChoice(WAR_ST_FellCleave_Pooling_BossOnly, WAR_Config.PoolBossOnly, WAR_Config.PoolBossOnlyDesc);
                    }
                    if (!WAR_ST_FellCleave_Pooling)
                    {
                        DrawSliderInt(50, 100, WAR_ST_FellCleave_Gauge,
                            WAR_Config.MinBeastGaugeSpend);
                    }
                    break;

                case Preset.WAR_ST_PrimalRend:
                    DrawHorizontalRadioButton(WAR_ST_PrimalRend_EarlyLate,
                        WAR_Config.Early, WAR_Config.EarlyPrimalRend, 0);
                    DrawHorizontalRadioButton(WAR_ST_PrimalRend_EarlyLate,
                        WAR_Config.Late, WAR_Config.LatePrimalRend, 1);
                    ImGui.NewLine();
                    DrawHorizontalRadioButton(WAR_ST_PrimalRend_Movement,
                        Generics.StationaryOnly, FormatAndCache(Generics.UseActionOnlyWhileStationary, PrimalRend.ActionName()), 0);
                    DrawHorizontalRadioButton(WAR_ST_PrimalRend_Movement,
                        Generics.AnyMovement, FormatAndCache(Generics.Uses0RegardlessOfAnyMovementConditions, PrimalRend.ActionName()), 1);
                    ImGui.Spacing();
                    if (WAR_ST_PrimalRend_Movement == 0)
                    {
                        ImGui.SetCursorPosX(48);
                        DrawSliderFloat(0, 3, WAR_ST_PrimalRend_TimeStill,
                            Generics.StationaryDelayCheck, decimals: 1);
                    }
                    ImGui.SetCursorPosX(48);
                    DrawSliderFloat(1, 20, WAR_ST_PrimalRend_Distance,
                        Generics.UseWhenDistanceFromTargetIsLessThanOrEqualTo, decimals: 1);
                    break;
                #endregion

                #region AoE
                case Preset.WAR_AoE_Decimate:
                    DrawAdditionalBoolChoice(WAR_AoE_Decimate_Pooling, WAR_Config.BurstPooling, WAR_Config.BurstPoolingDesc);
                    if (WAR_AoE_Decimate_Pooling)
                    {
                        DrawAdditionalBoolChoice(WAR_AoE_Decimate_Pooling_BossOnly, WAR_Config.PoolBossOnly, WAR_Config.PoolBossOnlyDesc);
                    }
                    if (!WAR_AoE_Decimate_Pooling)
                    {
                        DrawSliderInt(50, 100, WAR_AoE_Decimate_Gauge,
                            WAR_Config.MinBeastGaugeSpend);
                    }
                    DrawAdditionalBoolChoice(WAR_AoE_Decimate_Smart, WAR_Config.SmartSpender, WAR_Config.SmartSpenderDesc);
                    break;

                case Preset.WAR_AoE_InnerRelease:
                    DrawSliderInt(0, 75, WAR_AoE_InnerRelease_Threshold,
                        Generics.StopEnemyHpPercent);
                    ImGui.Indent();
                    ImGui.TextColored(ImGuiColors.DalamudYellow, Generics.EnemyTypeCheck);
                    ImGui.NewLine();
                    DrawHorizontalRadioButton(WAR_AoE_InnerRelease_Threshold_SubOption,
                        Generics.NonBossEncountersOnly, Generics.HPCheckNonBossEncountersOnly, 0);
                    DrawHorizontalRadioButton(WAR_AoE_InnerRelease_Threshold_SubOption,
                        Generics.AllContent, Generics.HPCheckAllContent, 1);
                    ImGui.Unindent();
                    break;

                case Preset.WAR_AoE_Infuriate:
                    DrawSliderInt(0, 2, WAR_AoE_Infuriate_Charges,
                        Generics.HowManyChargesToKeepReady);
                    DrawSliderInt(0, 50, WAR_AoE_Infuriate_Gauge,
                        WAR_Config.GaugeUnderOrEqual);
                    break;

                case Preset.WAR_AoE_Onslaught:
                    DrawAdditionalBoolChoice(WAR_AoE_Onslaught_ManualPooling, 
                        FormatAndCache(Generics.Align0WithManual1, Onslaught.ActionName(), InnerRelease.ActionName()), "");
                    DrawHorizontalRadioButton(WAR_AoE_Onslaught_Movement,
                        Generics.StationaryOnly, FormatAndCache(Generics.UseActionOnlyWhileStationary, Onslaught.ActionName()), 0);
                    DrawHorizontalRadioButton(WAR_AoE_Onslaught_Movement,
                        Generics.AnyMovement, FormatAndCache(Generics.Uses0RegardlessOfAnyMovementConditions, Onslaught.ActionName()), 1);
                    ImGui.Spacing();
                    if (WAR_AoE_Onslaught_Movement == 0)
                    {
                        ImGui.SetCursorPosX(48);
                        DrawSliderFloat(0, 3, WAR_AoE_Onslaught_TimeStill,
                            Generics.StationaryDelayCheck, decimals: 1);
                    }
                    DrawSliderInt(0, 2, WAR_AoE_Onslaught_Charges,
                        Generics.HowManyChargesToKeepReady);
                    ImGui.SetCursorPosX(48);
                    DrawSliderFloat(1, 20, WAR_AoE_Onslaught_Distance,
                        Generics.UseWhenDistanceFromTargetIsLessThanOrEqualTo, decimals: 1);
                    break;

                case Preset.WAR_AoE_PrimalRend:
                    DrawHorizontalRadioButton(WAR_AoE_PrimalRend_EarlyLate,
                        WAR_Config.Early, WAR_Config.EarlyPrimalRend, 0);
                    DrawHorizontalRadioButton(WAR_AoE_PrimalRend_EarlyLate,
                        WAR_Config.Late, WAR_Config.LatePrimalRend, 1);
                    ImGui.NewLine();
                    DrawHorizontalRadioButton(WAR_AoE_PrimalRend_Movement,
                        Generics.StationaryOnly, FormatAndCache(Generics.UseActionOnlyWhileStationary, PrimalRend.ActionName()), 0);
                    DrawHorizontalRadioButton(WAR_AoE_PrimalRend_Movement,
                        Generics.AnyMovement, FormatAndCache(Generics.Uses0RegardlessOfAnyMovementConditions, PrimalRend.ActionName()), 1);
                    ImGui.Spacing();
                    if (WAR_AoE_PrimalRend_Movement == 0)
                    {
                        ImGui.SetCursorPosX(48);
                        DrawSliderFloat(0, 3, WAR_AoE_PrimalRend_TimeStill,
                            Generics.StationaryDelayCheck, decimals: 1);
                    }
                    ImGui.SetCursorPosX(48);
                    DrawSliderFloat(1, 20, WAR_AoE_PrimalRend_Distance,
                        Generics.UseWhenDistanceFromTargetIsLessThanOrEqualTo, decimals: 1);
                    break;
                #endregion

                #region One-Button Mitigation

                case Preset.WAR_Mit_Holmgang_Max:
                    DrawDifficultyMultiChoice(WAR_Mit_Holmgang_Max_Difficulty, WAR_Mit_Holmgang_Max_DifficultyListSet,
                        FormatAndCache(Generics.SelectDifficultyActionIn, Holmgang.ActionName()));

                    DrawSliderInt(1, 100, WAR_Mit_Holmgang_Health,
                        Generics.StopFriendlyHpPercent100, 200, SliderIncrements.Fives);
                    break;

                case Preset.WAR_Mit_Bloodwhetting:
                    DrawSliderInt(1, 100, WAR_Mit_Bloodwhetting_Health,
                        Generics.HPPercentToUseAtOrBelow, sliderIncrement: SliderIncrements.Ones);

                    DrawPriorityInput(WAR_Mit_Priorities, NumMitigationOptions, 0,
                        FormatAndCache(Generics.Action_Priority, Bloodwhetting.ActionName()));
                    break;

                case Preset.WAR_Mit_Equilibrium:
                    DrawSliderInt(1, 100, WAR_Mit_Equilibrium_Health,
                        Generics.HPPercentToUseAtOrBelow, sliderIncrement: SliderIncrements.Ones);

                    DrawPriorityInput(WAR_Mit_Priorities, NumMitigationOptions, 1,
                        FormatAndCache(Generics.Action_Priority, Equilibrium.ActionName()));
                    break;

                case Preset.WAR_Mit_Reprisal:
                    DrawPriorityInput(WAR_Mit_Priorities, NumMitigationOptions, 2,
                        FormatAndCache(Generics.Action_Priority, Role.Reprisal.ActionName()));
                    break;

                case Preset.WAR_Mit_ThrillOfBattle:
                    DrawSliderInt(1, 100, WAR_Mit_ThrillOfBattle_Health,
                        Generics.StopFriendlyHpPercent100, sliderIncrement: SliderIncrements.Ones);

                    DrawPriorityInput(WAR_Mit_Priorities, NumMitigationOptions, 3,
                        FormatAndCache(Generics.Action_Priority, ThrillOfBattle.ActionName()));
                    break;

                case Preset.WAR_Mit_Rampart:
                    DrawPriorityInput(WAR_Mit_Priorities, NumMitigationOptions, 4,
                        FormatAndCache(Generics.Action_Priority, Role.Rampart.ActionName()));
                    break;

                case Preset.WAR_Mit_ShakeItOff:
                    ImGui.Indent();
                    DrawHorizontalRadioButton(WAR_Mit_ShakeItOff_PartyRequirement,
                        Generics.RequirePartyLabel, WAR_Config.RequirePartyShakeItOff,
                        (int)PartyRequirement.Yes);
                    DrawHorizontalRadioButton(WAR_Mit_ShakeItOff_PartyRequirement,
                        Generics.UseAlwaysLabel, WAR_Config.UseAlwaysShakeItOff,
                        (int)PartyRequirement.No);
                    ImGui.Unindent();
                    DrawPriorityInput(WAR_Mit_Priorities, NumMitigationOptions, 5,
                        FormatAndCache(Generics.Action_Priority, ShakeItOff.ActionName()));
                    break;

                case Preset.WAR_Mit_ArmsLength:
                    ImGui.Indent();
                    DrawHorizontalRadioButton(WAR_Mit_ArmsLength_Boss,
                        Generics.AllEnemies, Generics.ArmsLengthRegardless,
                        (int)BossAvoidance.Off, 125f);
                    DrawHorizontalRadioButton(WAR_Mit_ArmsLength_Boss,
                        Generics.AvoidBosses, Generics.ArmsLengthAvoidBosses,
                        (int)BossAvoidance.On, 125f);
                    ImGui.Unindent();
                    DrawSliderInt(0, 5, WAR_Mit_ArmsLength_EnemyCount,
                        Generics.NearbyEnemyCount);
                    DrawPriorityInput(WAR_Mit_Priorities, NumMitigationOptions, 6, FormatAndCache(Generics.Action_Priority, Role.ArmsLength.ActionName()));
                    break;

                case Preset.WAR_Mit_Vengeance:
                    DrawPriorityInput(WAR_Mit_Priorities, NumMitigationOptions, 7, FormatAndCache(Generics.Action_Priority, Vengeance.ActionName()));
                    break;

                #endregion

                #region Other
                case Preset.WAR_FC_InnerRelease:
                    DrawSliderInt(0, 75, WAR_FC_IRStop,
                        WAR_Config.FcIrStopHp);
                    break;

                case Preset.WAR_FC_Onslaught:
                    DrawHorizontalRadioButton(WAR_FC_Onslaught_Movement,
                        Generics.StationaryOnly, FormatAndCache(Generics.UseActionOnlyWhileStationary, Onslaught.ActionName()), 0);
                    DrawHorizontalRadioButton(WAR_FC_Onslaught_Movement,
                        Generics.AnyMovement, FormatAndCache(Generics.Uses0RegardlessOfAnyMovementConditions, Onslaught.ActionName()), 1);
                    ImGui.Spacing();
                    if (WAR_FC_Onslaught_Movement == 0)
                    {
                        ImGui.SetCursorPosX(48);
                        DrawSliderFloat(0, 3, WAR_FC_Onslaught_TimeStill,
                            Generics.StationaryDelayCheck, decimals: 1);
                    }
                    DrawSliderInt(0, 2, WAR_FC_Onslaught_Charges,
                        Generics.HowManyChargesToKeepReady);
                    ImGui.SetCursorPosX(48);
                    DrawSliderFloat(1, 20, WAR_FC_Onslaught_Distance,
                        Generics.UseWhenDistanceFromTargetIsLessThanOrEqualTo, decimals: 1);
                    break;

                case Preset.WAR_FC_Infuriate:
                    DrawSliderInt(0, 2, WAR_FC_Infuriate_Charges,
                        Generics.HowManyChargesToKeepReady);
                    DrawSliderInt(0, 50, WAR_FC_Infuriate_Gauge,
                        WAR_Config.BeastGaugeLessOrEqual);
                    break;

                case Preset.WAR_FC_PrimalRend:
                    DrawHorizontalRadioButton(WAR_FC_PrimalRend_EarlyLate,
                        WAR_Config.Early, WAR_Config.EarlyPrimalRend, 0);
                    DrawHorizontalRadioButton(WAR_FC_PrimalRend_EarlyLate,
                        WAR_Config.Late, WAR_Config.LatePrimalRend, 1);
                    ImGui.NewLine();
                    DrawHorizontalRadioButton(WAR_FC_PrimalRend_Movement,
                        Generics.StationaryOnly, FormatAndCache(Generics.UseActionOnlyWhileStationary, PrimalRend.ActionName()), 0);
                    DrawHorizontalRadioButton(WAR_FC_PrimalRend_Movement,
                        Generics.AnyMovement, FormatAndCache(Generics.Uses0RegardlessOfAnyMovementConditions, PrimalRend.ActionName()), 1);
                    ImGui.Spacing();
                    if (WAR_FC_PrimalRend_Movement == 0)
                    {
                        ImGui.SetCursorPosX(48);
                        DrawSliderFloat(0, 3, WAR_FC_PrimalRend_TimeStill,
                            Generics.StationaryDelayCheck, decimals: 1);
                    }
                    ImGui.SetCursorPosX(48);
                    DrawSliderFloat(1, 20, WAR_FC_PrimalRend_Distance,
                        Generics.UseWhenDistanceFromTargetIsLessThanOrEqualTo, decimals: 1);
                    break;

                case Preset.WAR_InfuriateFellCleave:
                    DrawSliderInt(0, 2, WAR_Infuriate_Charges,
                        Generics.HowManyChargesToKeepReady);
                    DrawSliderInt(0, 50, WAR_Infuriate_Range,
                        WAR_Config.BeastGaugeLessOrEqualMultiline);
                    break;

                case Preset.WAR_EyePath:
                    DrawSliderInt(0, 30, WAR_EyePath_Refresh,
                        FormatAndCache(WAR_Config.SurgingTempestRefresh, Buffs.SurgingTempest.StatusName()));
                    break;

                case Preset.WAR_RawIntuition_Targeting_TT:
                    ImGui.Indent();
                    ImGuiEx.TextWrapped(ImGuiColors.DalamudGrey,
                        WAR_Config.BloodwhettingOfftankNote);
                    ImGui.Unindent();
                    break;

                case Preset.WAR_ArmsLengthLockout:
                    DrawSliderInt(0, 5, WAR_ArmsLengthLockout_Time, WAR_Config.ArmsLengthInnerStrengthLockout);
                    break;
                   
                case Preset.WAR_RetargetTomahawk:
                    DrawAdditionalBoolChoice(WAR_RetargetTomahawk_FieldMO, Generics.Mouseover, FormatAndCache(Generics.MouseoverRetargetHostile, Tomahawk.ActionName()));
                    
                    DrawAdditionalBoolChoice(WAR_RetargetTomahawk_RangeBasedTargeting, Generics.RangeBasedTargeting, Generics.RangeBasedTargetingDesc);
                    
                    if (WAR_RetargetTomahawk_RangeBasedTargeting)
                    {
                        ImGui.Indent();
                        ImGui.NewLine();
                        DrawHorizontalRadioButton(WAR_RetargetTomahawk_SmartTargeting,
                            Generics.FurthestOOR, 
                            FormatAndCache(Generics.FurthestOORRetarget, Tomahawk.ActionName()), 0, 
                            descriptionColor:ImGuiColors.DalamudWhite);
                        DrawHorizontalRadioButton(WAR_RetargetTomahawk_SmartTargeting,
                            Generics.NearestOOR, 
                            FormatAndCache(Generics.NearestOORRetarget, Tomahawk.ActionName()), 1, 
                            descriptionColor:ImGuiColors.DalamudWhite);
                        ImGuiEx.Spacing(new Vector2(0, 5));
                        ImGui.Unindent();
                        
                        ImGui.Indent(10f.Scale());
                        DrawAdditionalBoolChoice(WAR_RetargetTomahawk_SmartTargeting_NotTargetingPlayer, Generics.SmartTargeting, Generics.SmartTargetingNotTargetingPlayer);
                        ImGui.Unindent();
                    }
                    break;
                    
                    #endregion
            }
        }
        #region Variables

        private const int NumMitigationOptions = 8;

        public static UserInt
            //Auto Mitigation
            WAR_ST_MitsOptions = new("WAR_ST_MitsOptions"),
            WAR_AoE_MitsOptions = new("WAR_AoE_MitsOptions"),
            WAR_ST_Advanced_MitsOptions = new("WAR_ST_Advanced_MitsOptions"),
            WAR_AoE_Advanced_MitsOptions = new("WAR_AoE_Advanced_MitsOptions"),
            WAR_Mitigation_NonBoss_ShakeItOff_Health = new("WAR_Mitigation_NonBoss_ShakeItOff_Health", 80),
            WAR_Mitigation_NonBoss_Equilibrium_Health = new("WAR_Mitigation_NonBoss_Equilibrium_Health", 50),
            WAR_Mitigation_NonBoss_Holmgang_Health = new("WAR_Mitigation_NonBoss_Holmgang_Health", 20),
            WAR_Mitigation_Boss_RawIntuition_Health = new("WAR_Mitigation_Boss_RawIntuition_Health", 99),
            WAR_Mitigation_Boss_RawIntuitionDelay = new("WAR_Mitigation_Boss_RawIntuitionDelay"),
            WAR_Mitigation_Boss_Equilibrium_Health = new("WAR_Mitigation_Boss_Equilibrium_Health", 30),
            WAR_Mitigation_Boss_Tankbuster_Equilibrium_Health = new("WAR_Mitigation_Boss_Tankbuster_Equilibrium_Health", 80),

            //ST Rotation
            WAR_BalanceOpener_Content = new("WAR_BalanceOpener_Content", 1),
            WAR_ST_BalanceOpener_GapcloserChoice = new("WAR_ST_BalanceOpener_GapcloserChoice", 1),
            WAR_ST_InnerRelease_Threshold = new("WAR_ST_InnerRelease_Threshold", 10),
            WAR_ST_InnerRelease_Threshold_SubOption = new("WAR_ST_InnerRelease_Threshold_SubOption"),
            WAR_ST_Infuriate_Charges = new("WAR_ST_Infuriate_Charges"),
            WAR_ST_Infuriate_Gauge = new("WAR_ST_Infuriate_Gauge", 40),
            WAR_ST_Onslaught_Charges = new("WAR_ST_Onslaught_Charges"),
            WAR_ST_Onslaught_Movement = new("WAR_ST_Onslaught_Movement"),
            WAR_ST_FellCleave_Gauge = new("WAR_ST_FellCleave_Gauge", 50),
            WAR_ST_PrimalRend_Movement = new("WAR_ST_PrimalRend_Movement"),
            WAR_ST_PrimalRend_EarlyLate = new("WAR_ST_PrimalRend_EarlyLate"),

            //AoE Rotation
            WAR_AoE_InnerRelease_Threshold = new("WAR_AoE_InnerRelease_Threshold", 10),
            WAR_AoE_InnerRelease_Threshold_SubOption = new("WAR_AoE_InnerRelease_Threshold_SubOption"),
            WAR_AoE_Infuriate_Charges = new("WAR_AoE_Infuriate_Charges"),
            WAR_AoE_Infuriate_Gauge = new("WAR_AoE_Infuriate_Gauge", 40),
            WAR_AoE_Onslaught_Charges = new("WAR_AoE_Onslaught_Charges"),
            WAR_AoE_Onslaught_Movement = new("WAR_AoE_Onslaught_Movement"),
            WAR_AoE_Decimate_Gauge = new("WAR_AoE_Decimate_Gauge", 50),
            WAR_AoE_PrimalRend_Movement = new("WAR_AoE_PrimalRend_Movement"),
            WAR_AoE_PrimalRend_EarlyLate = new("WAR_AoE_PrimalRend_EarlyLate"),

            //Standalone Configs
            WAR_Infuriate_Charges = new("WAR_Infuriate_Charges"),
            WAR_Infuriate_Range = new("WAR_Infuriate_Range"),
            WAR_SurgingRefreshRange = new("WAR_SurgingRefreshRange", 10),
            WAR_EyePath_Refresh = new("WAR_EyePath", 10),
            WAR_FC_IRStop = new("WAR_FC_IRStop"),
            WAR_FC_Infuriate_Charges = new("WAR_FC_Infuriate_Charges"),
            WAR_FC_Infuriate_Gauge = new("WAR_FC_Infuriate_Gauge", 40),
            WAR_FC_Onslaught_Charges = new("WAR_FC_Onslaught_Charges"),
            WAR_FC_Onslaught_Movement = new("WAR_FC_Onslaught_Movement"),
            WAR_FC_PrimalRend_Movement = new("WAR_FC_PrimalRend_Movement"),
            WAR_FC_PrimalRend_EarlyLate = new("WAR_FC_PrimalRend_EarlyLate"),
            WAR_ArmsLengthLockout_Time = new("WAR_ArmsLengthLockout_Time", 3),
            WAR_RetargetTomahawk_SmartTargeting = new("WAR_RetargetTomahawk_SmartTargeting"),

            //One Button Mitigation
            WAR_Mit_Holmgang_Health = new("WAR_Mit_Holmgang_Health", 20),
            WAR_Mit_Bloodwhetting_Health = new("WAR_Mit_Bloodwhetting_Health", 70),
            WAR_Mit_Equilibrium_Health = new("WAR_Mit_Equilibrium_Health", 45),
            WAR_Mit_ThrillOfBattle_Health = new("WAR_Mit_ThrillOfBattle_Health", 60),
            WAR_Mit_ShakeItOff_PartyRequirement = new("WAR_Mit_ShakeItOff_PartyRequirement", (int)PartyRequirement.Yes),
            WAR_Mit_ArmsLength_Boss = new("WAR_Mit_ArmsLength_Boss", (int)BossAvoidance.On),
            WAR_Mit_ArmsLength_EnemyCount = new("WAR_Mit_ArmsLength_EnemyCount");


        public static UserFloat
            WAR_Mitigation_NonBoss_MitigationThreshold = new("WAR_Mitigation_NonBoss_MitigationThreshold", 20f),
            WAR_Mitigation_Boss_ThrillOfBattle_Threshold = new("WAR_Mitigation_Boss_ThrillOfBattle_Threshold", 20f),

            WAR_ST_Onslaught_Distance = new("WAR_ST_Ons_Distance", 3.0f),
            WAR_ST_PrimalRend_Distance = new("WAR_ST_PR_Distance", 3.0f),
            WAR_ST_Onslaught_TimeStill = new("WAR_ST_Onslaught_TimeStill"),
            WAR_ST_PrimalRend_TimeStill = new("WAR_ST_PrimalRend_TimeStill"),

            WAR_AoE_Onslaught_Distance = new("WAR_AoE_Ons_Distance", 3.0f),
            WAR_AoE_PrimalRend_Distance = new("WAR_AoE_PR_Distance", 3.0f),
            WAR_AoE_Onslaught_TimeStill = new("WAR_AoE_Onslaught_TimeStill"),
            WAR_AoE_PrimalRend_TimeStill = new("WAR_AoE_PrimalRend_TimeStill"),

            WAR_FC_Onslaught_Distance = new("WAR_FC_Ons_Distance", 3.0f),
            WAR_FC_PrimalRend_Distance = new("WAR_FC_PR_Distance", 3.0f),
            WAR_FC_Onslaught_TimeStill = new("WAR_FC_Onslaught_TimeStill"),
            WAR_FC_PrimalRend_TimeStill = new("WAR_FC_PrimalRend_TimeStill");

        public static UserBool
            WAR_Opener_Potion = new("WAR_Opener_Potion"),
            WAR_Opener_PrepullBlock = new("WAR_Opener_PrepullBlock", true),
            WAR_Mitigation_Boss_ThrillOfBattle_Align = new("WAR_Mitigation_Boss_ThrillOfBattle_Align", true),
            WAR_Mitigation_Boss_Vengeance_First = new("WAR_Mitigation_Boss_Vengeance_First", true),

            WAR_ST_FellCleave_Pooling = new("WAR_ST_FellCleave_Pooling"),
            WAR_ST_FellCleave_Pooling_BossOnly = new("WAR_ST_FellCleave_Pooling_BossOnly"),
            WAR_ST_Onslaught_ManualPooling = new("WAR_ST_Onslaught_ManualPooling"),

            WAR_AoE_Decimate_Pooling = new("WAR_AoE_Decimate_Pooling"),
            WAR_AoE_Decimate_Pooling_BossOnly = new("WAR_AoE_Decimate_Pooling_BossOnly"),
            WAR_AoE_Decimate_Smart = new("WAR_AoE_Decimate_Smart"),
            WAR_AoE_Onslaught_ManualPooling = new("WAR_AoE_Onslaught_ManualPooling"),

            WAR_RetargetTomahawk_FieldMO = new("WAR_RetargetTomahawk_FieldMO"),
            WAR_RetargetTomahawk_RangeBasedTargeting = new("WAR_RetargetTomahawk_RangeBasedTargeting"),
            WAR_RetargetTomahawk_SmartTargeting_NotTargetingPlayer = new("WAR_RetargetTomahawk_SmartTargeting_NotTargetingPlayer");
        public static UserIntArray
            WAR_Mit_Priorities = new("WAR_Mit_Priorities");

       public static UserBoolArray
            WAR_Mitigation_Boss_RawIntuition_OnCD_Difficulty = new("WAR_Mitigation_Boss_RawIntuition_Difficulty", [true, false]),
            WAR_Mitigation_Boss_RawIntuition_TankBuster_Difficulty = new("WAR_Mitigation_Boss_RawIntuition_TankBuster_Difficulty", [true, false]),
            WAR_Mitigation_Boss_Rampart_Difficulty = new("WAR_Mitigation_Boss_Rampart_Difficulty", [true, false]),
            WAR_Mitigation_Boss_Vengeance_Difficulty = new("WAR_Mitigation_Boss_Vengeance_Difficulty", [true, false]),
            WAR_Mitigation_Boss_ThrillOfBattle_Difficulty = new("WAR_Mitigation_Boss_ThrillOfBattle_Difficulty", [true, false]),
            WAR_Mitigation_Boss_ShakeItOff_Difficulty = new("WAR_Mitigation_Boss_ShakeItOff_Difficulty", [true, false]),
            WAR_Mitigation_Boss_Reprisal_Difficulty = new("WAR_Mitigation_Boss_Reprisal_Difficulty", [true, false]),
            WAR_Mit_Holmgang_Max_Difficulty = new("WAR_Mit_Holmgang_Max_Difficulty", [true, false]);

        public static readonly ContentCheck.ListSet
            WAR_Mit_Holmgang_Max_DifficultyListSet = ContentCheck.ListSet.CasualVSHard,
            WAR_Boss_Mit_DifficultyListSet = ContentCheck.ListSet.CasualVSHard;
        #endregion
    }
}
