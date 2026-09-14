using Dalamud.Interface.Colors;
using ECommons.ExcelServices;
using ECommons.ImGuiMethods;
using WrathCombo.Extensions;
using WrathCombo.CustomComboNS.Functions;
using WrathCombo.Resources.Localization.JobConfigs;
using static WrathCombo.Extensions.UIntExtensions;
using static WrathCombo.Window.Functions.SliderIncrements;
using static WrathCombo.Window.Functions.UserConfig;
using static WrathCombo.Window.Text;
namespace WrathCombo.Combos.PvE;

internal partial class SCH
{
    internal static class Config
    {
        internal static void Draw(Preset preset)
        {
            switch (preset)
            {
                #region DPS
                case Preset.SCH_ST_ADV_DPS_Balance_Opener:
                    DrawBossOnlyChoice(SCH_ST_DPS_OpenerContent);
                    DrawOpenerPotionChoice(SCH_Opener_Potion);
                    DrawOpenerPrepullBlockChoice(SCH_Opener_PrepullBlock);
                    ImGuiEx.TextUnderlined(Generics.SelectOpener);
                    ImGui.Spacing();
                    DrawRadioButton(SCH_ST_DPS_OpenerOption, SCH_Config.DissipationFirst, SCH_Config.DissipationFirstDesc, 0, descriptionAsTooltip: true);
                    DrawRadioButton(SCH_ST_DPS_OpenerOption, SCH_Config.AetherflowFirst, SCH_Config.AetherflowFirstDesc, 1, descriptionAsTooltip: true);
                    break;

                case Preset.SCH_ST_ADV_DPS:
                    DrawHorizontalRadioButton(SCH_ST_DPS_Adv_Actions, SCH_Config.OnRuinBroils, SCH_Config.OnRuinBroilsDesc, 0,
                        descriptionColor: ImGuiColors.DalamudWhite);
                    DrawHorizontalRadioButton(SCH_ST_DPS_Adv_Actions, SCH_Config.OnBio, SCH_Config.OnBioDesc, 1,
                        descriptionColor: ImGuiColors.DalamudWhite);
                    DrawHorizontalRadioButton(SCH_ST_DPS_Adv_Actions, SCH_Config.OnBroilII, SCH_Config.OnBroilIIDesc, 2,
                        descriptionColor: ImGuiColors.DalamudWhite);
                    break;

                case Preset.SCH_ST_ADV_DPS_Lucid:
                    DrawSliderInt(4000, 9500, SCH_ST_DPS_LucidOption, Generics.LucidMP, 150, Hundreds);
                    break;

                case Preset.SCH_ST_ADV_DPS_Bio:
                    DrawSliderInt(0, 100, SCH_ST_DPS_BioBossOption, Generics.BossOnlyHpPercent);
                    DrawSliderInt(0, 100, SCH_ST_DPS_BioBossAddsOption, Generics.BossEncounterNonBossHpPercent);
                    DrawSliderInt(0, 100, SCH_ST_DPS_BioTrashOption, Generics.NonBossHpPercent);
                    ImGui.Indent();
                    DrawRoundedSliderFloat(0, 4, SCH_ST_DPS_BioUptime_Threshold, Generics.DoTSecondsRemainingZeroDisable, digits: 1);
                    ImGui.Unindent();
                    DrawAdditionalBoolChoice(SCH_ST_ADV_DPS_Bio_TwoTarget, Generics.TwoTargetDotting, Generics.TwoTargetDottingDescription);
                    break;

                case Preset.SCH_ST_ADV_DPS_ChainStrat:

                    DrawSliderInt(0, 100, SCH_ST_DPS_ChainStratagemOption, Generics.StopEnemyHpPercent);

                    ImGui.Indent();

                    ImGui.TextColored(ImGuiColors.DalamudYellow, Generics.EnemyTypeCheck);

                    DrawHorizontalRadioButton(SCH_ST_DPS_ChainStratagemSubOption,
                        Generics.NonBosses, SCH_Config.HpCheckNonBossesDot, 0);

                    DrawHorizontalRadioButton(SCH_ST_DPS_ChainStratagemSubOption,
                        Generics.AllEnemies, Generics.HPCheckAllEnemies, 1);

                    ImGui.Unindent();

                    break;

                case Preset.SCH_ST_ADV_DPS_EnergyDrain:
                    DrawSliderInt(0, 60, SCH_ST_DPS_EnergyDrain, SCH_Config.AetherflowRemainingCd);

                    DrawAdditionalBoolChoice(SCH_ST_DPS_EnergyDrain_Burst,
                        SCH_Config.EnergyDrainBurst, SCH_Config.EnergyDrainBurstDesc);
                    break;

                case Preset.SCH_AoE_ADV_DPS_Lucid:
                    DrawSliderInt(4000, 9500, SCH_AoE_DPS_LucidOption, Generics.LucidMP, 150, Hundreds);
                    break;

                case Preset.SCH_AoE_ADV_DPS_ChainStrat:
                    DrawAdditionalBoolChoice(SCH_AoE_DPS_ChainStratagemBanefulOption,
                        SCH_Config.BanefulOnly, SCH_Config.BanefulOnlyDesc);

                    DrawSliderInt(0, 100, SCH_AoE_DPS_ChainStratagemOption, Generics.StopEnemyHpPercent);

                    ImGui.Indent();

                    ImGui.TextColored(ImGuiColors.DalamudYellow, Generics.EnemyTypeCheck);

                    DrawHorizontalRadioButton(SCH_AoE_DPS_ChainStratagemSubOption,
                        Generics.NonBosses, SCH_Config.HpCheckNonBossesDot, 0);

                    DrawHorizontalRadioButton(SCH_AoE_DPS_ChainStratagemSubOption,
                        Generics.AllEnemies, Generics.HPCheckAllEnemies, 1);

                    ImGui.Unindent();

                    break;

                case Preset.SCH_AoE_ADV_DPS_EnergyDrain:
                    DrawSliderInt(0, 60, SCH_AoE_DPS_EnergyDrain, SCH_Config.AetherflowRemainingCd);

                    DrawAdditionalBoolChoice(SCH_AoE_DPS_EnergyDrain_Burst,
                        SCH_Config.EnergyDrainBurst, SCH_Config.EnergyDrainBurstDesc);
                    break;

                case Preset.SCH_AoE_ADV_DPS_DoT:
                    DrawSliderInt(0, 100, SCH_AoE_ADV_DPS_DoT_HPThreshold, SCH_Config.StopUsingTargetHpAlwaysNever);
                    ImGui.Indent();
                    DrawRoundedSliderFloat(0, 5, SCH_AoE_ADV_DPS_DoT_Reapply, Generics.StopSeconds, digits: 1);
                    ImGui.Unindent();
                    DrawSliderInt(0, 10, SCH_AoE_ADV_DPS_DoT_MaxTargets, Generics.MaxTargetsMultiDot);
                    break;
                #endregion

                #region ST Healing
                case Preset.SCH_ST_Heal:

                    ImGui.Indent();
                    DrawAdditionalBoolChoice(SCH_ST_Heal_IncludeShields, SCH_Config.IncludeShieldsAdvanced, "");
                    ImGui.Unindent();

                    break;

                case Preset.SCH_ST_Heal_Lucid:
                    DrawSliderInt(4000, 9500, SCH_ST_Heal_LucidOption, Generics.LucidMP, 150, Hundreds);
                    break;

                case Preset.SCH_ST_Heal_Lustrate:
                    DrawSliderInt(0, 100, SCH_ST_Heal_LustrateOption, Generics.StopFriendlyHpPercent100);
                    DrawPriorityInput(SCH_ST_Heals_Priority, 12, 0, FormatAndCache(Generics.Action_Priority, Lustrate.ActionName()));
                    break;

                case Preset.SCH_ST_Heal_Excogitation:
                    DrawSliderInt(0, 100, SCH_ST_Heal_ExcogitationOption, Generics.StopFriendlyHpPercent100);
                    DrawAdditionalBoolChoice(SCH_ST_Heal_ExcogitationBossOption, Generics.NotInBossEncounters, Generics.WillNotUseInBossEncounters);
                    DrawAdditionalBoolChoice(SCH_ST_Heal_ExcogitationTankOption, Generics.TanksOnly, Generics.WillOnlyUseOnTanks);
                    DrawPriorityInput(SCH_ST_Heals_Priority, 12, 1, FormatAndCache(Generics.Action_Priority, Excogitation.ActionName()));
                    break;

                case Preset.SCH_ST_Heal_Protraction:
                    DrawSliderInt(0, 100, SCH_ST_Heal_ProtractionOption, Generics.StopFriendlyHpPercent100);
                    DrawAdditionalBoolChoice(SCH_ST_Heal_ProtractionBossOption, Generics.NotInBossEncounters, Generics.WillNotUseInBossEncounters);
                    DrawAdditionalBoolChoice(SCH_ST_Heal_ProtractionTankOption, Generics.TanksOnly, Generics.WillOnlyUseOnTanks);
                    DrawPriorityInput(SCH_ST_Heals_Priority, 12, 2, FormatAndCache(Generics.Action_Priority, Protraction.ActionName()));
                    break;

                case Preset.SCH_ST_Heal_Aetherpact:
                    DrawSliderInt(0, 100, SCH_ST_Heal_AetherpactOption, Generics.StopFriendlyHpPercent100);
                    DrawSliderInt(0, 100, SCH_ST_Heal_AetherpactDissolveOption, SCH_Config.StopUsingAboveHp);
                    DrawSliderInt(10, 100, SCH_ST_Heal_AetherpactFairyGauge, SCH_Config.MinFairyGaugeAetherpact, sliderIncrement: Tens);
                    DrawPriorityInput(SCH_ST_Heals_Priority, 12, 3, FormatAndCache(Generics.Action_Priority, Aetherpact.ActionName()));
                    break;

                case Preset.SCH_ST_Heal_WhisperingDawn:
                    DrawSliderInt(0, 100, SCH_ST_Heal_WhisperingDawnOption, Generics.StopFriendlyHpPercent100);
                    DrawAdditionalBoolChoice(SCH_ST_Heal_WhisperingDawnBossOption, Generics.NotInBossEncounters, Generics.WillNotUseInBossEncounters);
                    DrawPriorityInput(SCH_ST_Heals_Priority, 12, 5, FormatAndCache(Generics.Action_Priority, WhisperingDawn.ActionName()));
                    break;

                case Preset.SCH_ST_Heal_FeyIllumination:
                    DrawSliderInt(0, 100, SCH_ST_Heal_FeyIlluminationOption, Generics.StopFriendlyHpPercent100);
                    DrawAdditionalBoolChoice(SCH_ST_Heal_FeyIlluminationBossOption, Generics.NotInBossEncounters, Generics.WillNotUseInBossEncounters);
                    DrawPriorityInput(SCH_ST_Heals_Priority, 12, 6, FormatAndCache(Generics.Action_Priority, FeyIllumination.ActionName()));
                    break;

                case Preset.SCH_ST_Heal_FeyBlessing:
                    DrawSliderInt(0, 100, SCH_ST_Heal_FeyBlessingOption, Generics.StopFriendlyHpPercent100);
                    DrawAdditionalBoolChoice(SCH_ST_Heal_FeyBlessingBossOption, Generics.NotInBossEncounters, Generics.WillNotUseInBossEncounters);
                    DrawPriorityInput(SCH_ST_Heals_Priority, 12, 7, FormatAndCache(Generics.Action_Priority, FeyBlessing.ActionName()));
                    break;

                case Preset.SCH_ST_Heal_Seraphism:
                    DrawSliderInt(0, 100, SCH_ST_Heal_SeraphismOption, Generics.StopFriendlyHpPercent100);
                    DrawAdditionalBoolChoice(SCH_ST_Heal_SeraphismBossOption, Generics.NotInBossEncounters, Generics.WillNotUseInBossEncounters);
                    DrawPriorityInput(SCH_ST_Heals_Priority, 12, 8, FormatAndCache(Generics.Action_Priority, Seraphism.ActionName()));
                    break;

                case Preset.SCH_ST_Heal_Expedient:
                    DrawSliderInt(0, 100, SCH_ST_Heal_ExpedientOption, Generics.StopFriendlyHpPercent100);
                    DrawAdditionalBoolChoice(SCH_ST_Heal_ExpedientBossOption, Generics.NotInBossEncounters, Generics.WillNotUseInBossEncounters);
                    DrawPriorityInput(SCH_ST_Heals_Priority, 12, 9, FormatAndCache(Generics.Action_Priority, Expedient.ActionName()));
                    break;

                case Preset.SCH_ST_Heal_SummonSeraph:
                    DrawSliderInt(0, 100, SCH_ST_Heal_SummonSeraphOption, Generics.StopFriendlyHpPercent100);
                    DrawAdditionalBoolChoice(SCH_ST_Heal_SummonSeraphBossOption, Generics.NotInBossEncounters, Generics.WillNotUseInBossEncounters);
                    DrawPriorityInput(SCH_ST_Heals_Priority, 12, 10, FormatAndCache(Generics.Action_Priority, SummonSeraph.ActionName()));
                    break;

                case Preset.SCH_ST_Heal_Consolation:
                    DrawSliderInt(0, 100, SCH_ST_Heal_ConsolationOption, Generics.StopFriendlyHpPercent100);
                    DrawAdditionalBoolChoice(SCH_ST_Heal_ConsolationBossOption, Generics.NotInBossEncounters, Generics.WillNotUseInBossEncounters);
                    DrawPriorityInput(SCH_ST_Heals_Priority, 12, 11, FormatAndCache(Generics.Action_Priority, Consolation.ActionName()));
                    break;

                case Preset.SCH_ST_Heal_Adloquium:
                    DrawSliderInt(0, 100, SCH_ST_Heal_AdloquiumOption, Generics.StopFriendlyHpPercent100);
                    DrawHorizontalMultiChoice(SCH_ST_Heal_AldoquimOpts,
                        FormatAndCache(Generics.Job0ShieldCheck, Job.SCH.Name()),
                        FormatAndCache(Generics.Job0ShieldCheckDesc, Job.SCH.Name()), 3, 0
                    );
                    DrawHorizontalMultiChoice(SCH_ST_Heal_AldoquimOpts,
                        FormatAndCache(Generics.Job0ShieldCheck, Job.SGE.Name()),
                        FormatAndCache(Generics.Job0ShieldCheckDesc, Job.SGE.Name()), 3, 1
                    );
                    DrawHorizontalMultiChoice(SCH_ST_Heal_AldoquimOpts, EmergencyTactics.ActionName(), SCH_Config.EmergencyTacticsDesc, 3, 2);

                    if (SCH_ST_Heal_AldoquimOpts[2])
                    {
                        ImGui.Indent();
                        DrawSliderInt(0, 100, SCH_ST_Heal_AdloquiumOption_Emergency, SCH_Config.StartEmergencyTacticsBelowHp);
                        ImGui.Unindent();
                    }

                    DrawPriorityInput(SCH_ST_Heals_Priority, 12, 4, FormatAndCache(Generics.Action_Priority, Adloquium.ActionName()));
                    break;

                case Preset.SCH_ST_Heal_Esuna:
                    DrawSliderInt(0, 100, SCH_ST_Heal_EsunaOption, Generics.StopFriendlyHpPercentZero);
                    break;

                #endregion

                #region AoE Healing
                case Preset.SCH_AoE_Heal_Lucid:
                    DrawSliderInt(4000, 9500, SCH_AoE_Heal_LucidOption, Generics.LucidMP, 150, Hundreds);
                    break;

                case Preset.SCH_AoE_Heal:
                    ImGui.TextUnformatted(SCH_Config.SuccorAlwaysAvailable);
                    ImGui.TextUnformatted(SCH_Config.SuccorPriorityNote);
                    DrawSliderInt(0, 100, SCH_AoE_Heal_SuccorShieldOption, SCH_Config.ShieldCheckPartyPercent, sliderIncrement: 25);
                    DrawPriorityInput(SCH_AoE_Heals_Priority, 8, 7, FormatAndCache(Generics.Action_Priority, Succor.ActionName()));
                    DrawHorizontalMultiChoice(SCH_AoE_Heal_Succor_Options, EmergencyTactics.ActionName(), SCH_Config.EmergencyTacticsBeforeSuccor, 2, 0);
                    DrawHorizontalMultiChoice(SCH_AoE_Heal_Succor_Options, Recitation.ActionName(), SCH_Config.RecitationBuffSuccor, 2, 1);
                    break;

                case Preset.SCH_AoE_Heal_WhisperingDawn:
                    DrawSliderInt(0, 100, SCH_AoE_Heal_WhisperingDawnOption, Generics.StartUsingWhenBelowPartyAverageHPSetTo100ToDisableThisCheck);
                    DrawPriorityInput(SCH_AoE_Heals_Priority, 8, 0, FormatAndCache(Generics.Action_Priority, WhisperingDawn.ActionName()));
                    break;

                case Preset.SCH_AoE_Heal_FeyIllumination:
                    DrawSliderInt(0, 100, SCH_AoE_Heal_FeyIlluminationOption, Generics.StartUsingWhenBelowPartyAverageHPSetTo100ToDisableThisCheck);
                    DrawPriorityInput(SCH_AoE_Heals_Priority, 8, 1, FormatAndCache(Generics.Action_Priority, FeyIllumination.ActionName()));
                    break;

                case Preset.SCH_AoE_Heal_FeyBlessing:
                    DrawSliderInt(0, 100, SCH_AoE_Heal_FeyBlessingOption, Generics.StartUsingWhenBelowPartyAverageHPSetTo100ToDisableThisCheck);
                    DrawPriorityInput(SCH_AoE_Heals_Priority, 8, 2, FormatAndCache(Generics.Action_Priority, FeyBlessing.ActionName()));
                    break;

                case Preset.SCH_AoE_Heal_Consolation:
                    DrawSliderInt(0, 100, SCH_AoE_Heal_ConsolationOption, Generics.StartUsingWhenBelowPartyAverageHPSetTo100ToDisableThisCheck);
                    DrawPriorityInput(SCH_AoE_Heals_Priority, 8, 3, FormatAndCache(Generics.Action_Priority, Consolation.ActionName()));
                    break;

                case Preset.SCH_AoE_Heal_SummonSeraph:
                    DrawSliderInt(0, 100, SCH_AoE_Heal_SummonSeraph, Generics.StartUsingWhenBelowPartyAverageHPSetTo100ToDisableThisCheck);
                    DrawPriorityInput(SCH_AoE_Heals_Priority, 8, 6, FormatAndCache(Generics.Action_Priority, SummonSeraph.ActionName()));
                    break;

                case Preset.SCH_AoE_Heal_Seraphism:
                    DrawSliderInt(0, 100, SCH_AoE_Heal_SeraphismOption, Generics.StartUsingWhenBelowPartyAverageHPSetTo100ToDisableThisCheck);
                    DrawPriorityInput(SCH_AoE_Heals_Priority, 8, 4, FormatAndCache(Generics.Action_Priority, Seraphism.ActionName()));
                    break;

                case Preset.SCH_AoE_Heal_Indomitability:
                    DrawSliderInt(0, 100, SCH_AoE_Heal_IndomitabilityOption, Generics.StartUsingWhenBelowPartyAverageHPSetTo100ToDisableThisCheck);
                    DrawAdditionalBoolChoice(SCH_AoE_Heal_Indomitability_Recitation, FormatAndCache(Generics._0Option, Recitation.ActionName()), SCH_Config.RecitationBuffIndomitability);
                    DrawPriorityInput(SCH_AoE_Heals_Priority, 8, 5, FormatAndCache(Generics.Action_Priority, Indomitability.ActionName()));
                    break;

                case Preset.SCH_AoE_Heal_Aetherflow:
                    DrawAdditionalBoolChoice(SCH_AoE_Heal_Aetherflow_Indomitability,
                        SCH_Config.ReadyOnlyOption, FormatAndCache(SCH_Config.ReadyOnlyDesc, Aetherflow.ActionName()));
                    break;

                case Preset.SCH_AoE_Heal_Dissipation:
                    DrawAdditionalBoolChoice(SCH_AoE_Heal_Dissipation_Indomitability,
                        SCH_Config.ReadyOnlyOption, FormatAndCache(SCH_Config.ReadyOnlyDesc, Dissipation.ActionName()));
                    break;

                #endregion

                #region Standalones
                case Preset.SCH_Dissipation:
                    DrawAdditionalBoolChoice(SCH_Dissipation_WastePrevention, Generics.WastePrevention, 
                        FormatAndCache(Generics.SavageBladeWaste, Dissipation.ActionName(), All.Cease.ActionName()));
                    break;
                    
                case Preset.SCH_Aetherflow:
                    DrawRadioButton(SCH_Aetherflow_Display, SCH_Config.ShowAetherflowEnergyDrainOnly, "", 0);
                    DrawRadioButton(SCH_Aetherflow_Display, SCH_Config.ShowAetherflowAllSkills, "", 1);
                    break;

                case Preset.SCH_Aetherflow_Recite:
                    DrawAdditionalBoolChoice(SCH_Aetherflow_Recite_Excog, FormatAndCache(Generics.On0, Excogitation.ActionName()), "", isConditionalChoice: true);
                    if (SCH_Aetherflow_Recite_Excog)
                    {
                        ImGui.Indent();
                        ImGui.Spacing();
                        DrawRadioButton(SCH_Aetherflow_Recite_ExcogMode, SCH_Config.OutOfAetherflowStacks, "", 0);
                        DrawRadioButton(SCH_Aetherflow_Recite_ExcogMode, SCH_Config.AlwaysWhenAvailable, "", 1);
                        ImGui.Unindent();
                    }

                    DrawAdditionalBoolChoice(SCH_Aetherflow_Recite_Indom, FormatAndCache(Generics.On0, Indomitability.ActionName()), "", isConditionalChoice: true);
                    if (SCH_Aetherflow_Recite_Indom)
                    {
                        ImGui.Indent();
                        ImGui.Spacing();
                        DrawRadioButton(SCH_Aetherflow_Recite_IndomMode, SCH_Config.OutOfAetherflowStacks, "", 0);
                        DrawRadioButton(SCH_Aetherflow_Recite_IndomMode, SCH_Config.AlwaysWhenAvailable, "", 1);
                        ImGui.Unindent();
                    }
                    break;

                case Preset.SCH_Recitation:
                    DrawRadioButton(SCH_Recitation_Mode, Adloquium.ActionName(), "", 0);
                    DrawRadioButton(SCH_Recitation_Mode, Succor.ActionName(), "", 1);
                    DrawRadioButton(SCH_Recitation_Mode, Indomitability.ActionName(), "", 2);
                    DrawRadioButton(SCH_Recitation_Mode, Excogitation.ActionName(), "", 3);
                    break;

                case Preset.SCH_Raidwide_Succor:
                    DrawAdditionalBoolChoice(SCH_Raidwide_Succor_Recitation, FormatAndCache(Generics._0Option, Recitation.ActionName()), SCH_Config.RecitationRaidwideSuccor);
                    break;

                case Preset.SCH_Retarget_SacredSoil:
                    DrawHorizontalMultiChoice(SCH_Retarget_SacredSoilOptions, Generics.EnemyHardTarget, SCH_Config.PlaceUnderEnemyHardTarget, 2, 0);
                    DrawHorizontalMultiChoice(SCH_Retarget_SacredSoilOptions, Generics.AllyHardTarget, SCH_Config.PlaceUnderAllyHardTarget, 2, 1);
                    break;

                case Preset.SCH_Mit_ST:
                    DrawHorizontalMultiChoice(SCH_Mit_STOptions, Recitation.ActionName(), SCH_Config.RecitationBeforeAdlo, 3, 0);
                    DrawHorizontalMultiChoice(SCH_Mit_STOptions, DeploymentTactics.ActionName(), SCH_Config.SpreadAdloCritShield, 3, 1);
                    DrawHorizontalMultiChoice(SCH_Mit_STOptions, Excogitation.ActionName(), FormatAndCache(SCH_Config.UseIfAvailable, Excogitation.ActionName()), 3, 2);
                    break;

                case Preset.SCH_Mit_AoE:
                    DrawHorizontalMultiChoice(SCH_Mit_AoEOptions, FeyIllumination.ActionName(), SCH_Config.FeyIlluminationBeforeSuccor, 4, 0);
                    DrawHorizontalMultiChoice(SCH_Mit_AoEOptions, SCH_Config.CritAdloDeployment, SCH_Config.CritAdloDeploymentDesc, 4, 1);
                    DrawHorizontalMultiChoice(SCH_Mit_AoEOptions, Expedient.ActionName(), FormatAndCache(SCH_Config.UseIfAvailable, Expedient.ActionName()), 4, 2);
                    DrawHorizontalMultiChoice(SCH_Mit_AoEOptions, SCH_Config.SummonSeraphConsolation, SCH_Config.SummonSeraphConsolationDesc, 4, 3);
                    break;

                    #endregion
            }
        }

        #region Options

        #region DPS

        internal static UserInt
            SCH_ST_DPS_LucidOption = new("SCH_ST_DPS_LucidOption", 6500),
            SCH_AoE_DPS_LucidOption = new("SCH_AoE_LucidOption", 6500),
            SCH_ST_DPS_OpenerOption = new("SCH_ST_DPS_OpenerOption"),
            SCH_ST_DPS_OpenerContent = new("SCH_ST_DPS_OpenerContent", 1),
            SCH_ST_DPS_ChainStratagemOption = new("SCH_ST_DPS_ChainStratagemOption", 10),
            SCH_ST_DPS_BioBossOption = new("SCH_ST_DPS_BioBossOption", 0),
            SCH_ST_DPS_BioBossAddsOption = new("SCH_ST_DPS_BioBossAddsOption", 100),
            SCH_ST_DPS_BioTrashOption = new("SCH_ST_DPS_BioTrashOption", 50),
            SCH_AoE_DPS_ChainStratagemOption = new("SCH_AoE_DPS_ChainStratagemOption", 10),
            SCH_ST_DPS_EnergyDrain = new("SCH_ST_DPS_EnergyDrain", 3),
            SCH_ST_DPS_ChainStratagemSubOption = new("SCH_ST_DPS_ChainStratagemSubOption", 1),
            SCH_AoE_DPS_EnergyDrain = new("SCH_AoE_DPS_EnergyDrain", 3),
            SCH_AoE_DPS_ChainStratagemSubOption = new("SCH_AoE_DPS_ChainStratagemSubOption", 1),
            SCH_AoE_ADV_DPS_DoT_HPThreshold = new("SCH_AoE_ADV_DPS_DoT_HPThreshold", 30),
            SCH_AoE_ADV_DPS_DoT_MaxTargets = new("SCH_AoE_ADV_DPS_DoT_MaxTargets", 4),
            SCH_ST_DPS_Adv_Actions = new("SCH_ST_DPS_Adv_Actions");



        internal static UserBool
            SCH_Opener_Potion = new("SCH_Opener_Potion"),
            SCH_Opener_PrepullBlock = new("SCH_Opener_PrepullBlock", true),
            SCH_ST_ADV_DPS_Bio_TwoTarget = new("SCH_ST_ADV_DPS_Bio_TwoTarget"),
            SCH_ST_DPS_EnergyDrain_Burst = new("SCH_ST_DPS_EnergyDrain_Burst"),
            SCH_AoE_DPS_EnergyDrain_Burst = new("SCH_AoE_DPS_EnergyDrain_Burst"),
            SCH_AoE_DPS_ChainStratagemBanefulOption = new("SCH_AoE_DPS_ChainStratagemBanefulOption"),
            SCH_AoE_Heal_Aetherflow_Indomitability = new("SCH_AoE_Heal_Aetherflow_Indomitability"),
            SCH_AoE_Heal_Dissipation_Indomitability = new("SCH_AoE_Heal_Dissipation_Indomitability"),
            SCH_Raidwide_Succor_Recitation = new("SCH_Raidwide_Succor_Recitation");


        internal static UserFloat
            SCH_ST_DPS_BioUptime_Threshold = new("SCH_ST_DPS_BioUptime_Threshold", 3.0f),
            SCH_AoE_ADV_DPS_DoT_Reapply = new("SCH_AoE_ADV_DPS_DoT_Reapply", 0);



        #endregion

        #region Healing

        public static UserInt

            SCH_AoE_Heal_LucidOption = new("SCH_AoE_Heal_LucidOption", 8000),
            SCH_AoE_Heal_SuccorShieldOption = new("SCH_AoE_Heal_SuccorShieldCount", 50),
            SCH_AoE_Heal_WhisperingDawnOption = new("SCH_AoE_Heal_WhisperingDawnOption", 80),
            SCH_AoE_Heal_FeyIlluminationOption = new("SCH_AoE_Heal_FeyIlluminationOption", 80),
            SCH_AoE_Heal_ConsolationOption = new("SCH_AoE_Heal_ConsolationOption", 65),
            SCH_AoE_Heal_FeyBlessingOption = new("SCH_AoE_Heal_FeyBlessingOption", 70),
            SCH_AoE_Heal_SeraphismOption = new("SCH_AoE_Heal_SeraphismOption", 50),
            SCH_AoE_Heal_IndomitabilityOption = new("SCH_AoE_Heal_IndomitabilityOption", 60),
            SCH_AoE_Heal_SummonSeraph = new("SCH_AoE_Heal_SummonSeraph", 50),
            SCH_ST_Heal_LucidOption = new("SCH_ST_Heal_LucidOption", 8000),
            SCH_ST_Heal_AdloquiumOption = new("SCH_ST_Heal_AdloquiumOption", 70),
            SCH_ST_Heal_AdloquiumOption_Emergency = new("SCH_ST_Heal_AdloquiumOption_Emergency", 30),
            SCH_ST_Heal_LustrateOption = new("SCH_ST_Heal_LustrateOption", 55),
            SCH_ST_Heal_ExcogitationOption = new("SCH_ST_Heal_ExcogitationOption", 70),
            SCH_ST_Heal_ProtractionOption = new("SCH_ST_Heal_ProtractionOption", 70),
            SCH_ST_Heal_AetherpactOption = new("SCH_ST_Heal_AetherpactOption", 50),
            SCH_ST_Heal_AetherpactDissolveOption = new("SCH_ST_Heal_AetherpactDissolveOption", 90),
            SCH_ST_Heal_AetherpactFairyGauge = new("SCH_ST_Heal_AetherpactFairyGauge", 50),
            SCH_ST_Heal_WhisperingDawnOption = new("SCH_ST_Heal_WhisperingDawnOption", 55),
            SCH_ST_Heal_FeyIlluminationOption = new("SCH_ST_Heal_FeyIlluminationOption", 55),
            SCH_ST_Heal_FeyBlessingOption = new("SCH_ST_Heal_FeyBlessingOption", 55),
            SCH_ST_Heal_SeraphismOption = new("SCH_ST_Heal_SeraphismOption", 45),
            SCH_ST_Heal_ExpedientOption = new("SCH_ST_Heal_ExpedientOption", 50),
            SCH_ST_Heal_SummonSeraphOption = new("SCH_ST_Heal_SummonSeraphOption", 45),
            SCH_ST_Heal_ConsolationOption = new("SCH_ST_Heal_ConsolationOption", 55),
            SCH_ST_Heal_EsunaOption = new("SCH_ST_Heal_EsunaOption", 40);
        public static UserIntArray
            // ST: Protraction → Excog → Lustrate → Aetherpact → Adlo → FeyBless → Dawn → Illum → Consolation → Seraph → Seraphism → Expedient
            SCH_ST_Heals_Priority = new("SCH_ST_Heals_Priority", [3, 2, 1, 4, 5, 7, 8, 6, 11, 12, 10, 9]),
            // AoE: Illum → Dawn → Bless → Indom → Consolation → Seraph → Seraphism → Succor
            SCH_AoE_Heals_Priority = new("SCH_AoE_Heals_Priority", [2, 1, 3, 5, 7, 4, 6, 8]);

        public static UserBool
            SCH_ST_Heal_IncludeShields = new("SCH_ST_Heal_IncludeShields"),
            SCH_ST_Heal_WhisperingDawnBossOption = new("SCH_ST_Heal_WhisperingDawnBossOption", true),
            SCH_ST_Heal_FeyIlluminationBossOption = new("SCH_ST_Heal_FeyIlluminationBossOption", true),
            SCH_ST_Heal_FeyBlessingBossOption = new("SCH_ST_Heal_FeyBlessingBossOption", true),
            SCH_ST_Heal_ExcogitationBossOption = new("SCH_ST_Heal_ExcogitationBossOption"),
            SCH_ST_Heal_ExcogitationTankOption = new("SCH_ST_Heal_ExcogitationTankOption", true),
            SCH_ST_Heal_ProtractionBossOption = new("SCH_ST_Heal_ProtractionBossOption"),
            SCH_ST_Heal_ProtractionTankOption = new("SCH_ST_Heal_ProtractionTankOption", true),
            SCH_ST_Heal_SeraphismBossOption = new("SCH_ST_Heal_SeraphismBossOption", true),
            SCH_ST_Heal_ExpedientBossOption = new("SCH_ST_Heal_ExpedientBossOption", true),
            SCH_ST_Heal_SummonSeraphBossOption = new("SCH_ST_Heal_SummonSeraphBossOption", true),
            SCH_ST_Heal_ConsolationBossOption = new("SCH_ST_Heal_ConsolationBossOption", true),
            SCH_AoE_Heal_Indomitability_Recitation = new("SCH_AoE_Heal_Indomitability_Recitation");

        public static UserBoolArray
            SCH_ST_Heal_AldoquimOpts = new("SCH_ST_Heal_AldoquimOpts", [true, true, true]),
            SCH_AoE_Heal_Succor_Options = new("SCH_AoE_Heal_Succor_Options", [true, false]);

        #endregion

        #region Standalones

        internal static UserBool
            SCH_Dissipation_WastePrevention = new("SCH_Dissipation_WastePrevention"),
            SCH_Aetherflow_Recite_Indom = new("SCH_Aetherflow_Recite_Indom"),
            SCH_Aetherflow_Recite_Excog = new("SCH_Aetherflow_Recite_Excog");
        internal static UserInt
            SCH_Aetherflow_Display = new("SCH_Aetherflow_Display"),
            SCH_Aetherflow_Recite_ExcogMode = new("SCH_Aetherflow_Recite_ExcogMode"),
            SCH_Aetherflow_Recite_IndomMode = new("SCH_Aetherflow_Recite_IndomMode"),
            SCH_Recitation_Mode = new("SCH_Recitation_Mode");

        internal static UserBoolArray
            SCH_Retarget_SacredSoilOptions = new("SCH_Retarget_SacredSoilOptions"),
            SCH_Mit_STOptions = new("SCH_Mit_STOptions"),
            SCH_Mit_AoEOptions = new("SCH_Mit_AoEOptions");

        #endregion

        #endregion

    }
}
