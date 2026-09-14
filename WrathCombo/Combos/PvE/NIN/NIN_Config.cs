using Dalamud.Interface.Colors;
using ECommons.ImGuiMethods;
using WrathCombo.CustomComboNS.Functions;
using WrathCombo.Extensions;
using WrathCombo.Resources.Localization.JobConfigs;
using static WrathCombo.Window.Functions.UserConfig;
using static WrathCombo.Window.Text;
namespace WrathCombo.Combos.PvE;

internal partial class NIN
{
    internal static class Config
    {
        #region Options

        internal static UserInt
            NIN_ST_AdvancedMode_BurnKazematoi = new("NIN_ST_AdvancedMode_BurnKazematoi", 10),
            NIN_ST_AdvancedMode_SecondWindThreshold = new("NIN_ST_AdvancedMode_SecondWindThreshold", 40),
            NIN_ST_AdvancedMode_ShadeShiftThreshold = new("NIN_ST_AdvancedMode_ShadeShiftThreshold", 20),
            NIN_ST_AdvancedMode_BloodbathThreshold = new("NIN_ST_AdvancedMode_BloodbathThreshold", 40),
            NIN_ST_AdvancedMode_Mug_Threshold = new("NIN_ST_AdvancedMode_Mug_Threshold", 40),
            NIN_ST_AdvancedMode_Mug_SubOption = new("NIN_ST_AdvancedMode_Mug_SubOption", 0),
            NIN_ST_AdvancedMode_TrickAttack_Threshold = new("NIN_ST_AdvancedMode_TrickAttack_Threshold", 40),
            NIN_ST_AdvancedMode_TrickAttack_SubOption = new("NIN_ST_AdvancedMode_TrickAttack_SubOption", 0),
            NIN_ST_AdvancedMode_Ninjitsus_Suiton_Setup = new("NIN_ST_AdvancedMode_Ninjitsus_Suiton_Setup", 18),
            NIN_AoE_AdvancedMode_SecondWindThreshold = new("NIN_AoE_AdvancedMode_SecondWindThreshold", 40),
            NIN_AoE_AdvancedMode_Ninjitsus_Huton_Setup = new("NIN_AoE_AdvancedMode_Ninjitsus_Huton_Setup", 18),
            NIN_AoE_AdvancedMode_Ninjitsus_Doton_Threshold = new("NIN_AoE_AdvancedMode_Ninjitsus_Doton_Threshold", 40),
            NIN_AoE_AdvancedMode_ShadeShiftThreshold = new("NIN_AoE_AdvancedMode_ShadeShiftThreshold", 20),
            NIN_AoE_AdvancedMode_BloodbathThreshold = new("NIN_AoE_AdvancedMode_BloodbathThreshold", 40),
            NIN_AoE_AdvancedMode_Mug_Threshold = new("NIN_AoE_AdvancedMode_Mug_Threshold", 40),
            NIN_AoE_AdvancedMode_Mug_SubOption = new("NIN_AoE_AdvancedMode_Mug_SubOption", 0),
            NIN_AoE_AdvancedMode_TrickAttack_Threshold = new("NIN_AoE_AdvancedMode_TrickAttack_Threshold", 40),
            NIN_AoE_AdvancedMode_TrickAttack_SubOption = new("NIN_AoE_AdvancedMode_TrickAttack_SubOption", 0),
            NIN_Adv_Opener_Selection = new("NIN_Adv_Opener_Selection", 0),
            NIN_Balance_Content = new("NIN_Balance_Content", 1),
            NIN_SimpleMudra_Choice = new("NIN_SimpleMudra_Choice", 1);

        internal static UserBool
            NIN_Opener_Potion = new("NIN_Opener_Potion"),
            NIN_Opener_PrepullBlock = new("NIN_Opener_PrepullBlock", true),
            NIN_ST_AdvancedMode_Bhavacakra_Pooling = new("Ninki_BhavaPooling"),
            NIN_ST_AdvancedMode_TrueNorth = new("NIN_ST_AdvancedMode_TrueNorth"),
            NIN_ST_AdvancedMode_ShadeShiftRaidwide = new("NIN_ST_AdvancedMode_ShadeShiftRaidwide"),
            NIN_ST_AdvancedMode_ForkedRaiju = new("NIN_ST_AdvancedMode_ForkedRaiju"),
            NIN_ST_AdvancedMode_Ninjitsus_Raiton_Pooling = new("NIN_ST_AdvancedMode_Ninjitsus_Raiton_Pooling"),
            NIN_ST_AdvancedMode_Ninjitsus_Raiton_Uptime = new("NIN_ST_AdvancedMode_Ninjitsus_Raiton_Uptime"),
            NIN_ST_AdvancedMode_TenChiJin_Auto = new("NIN_ST_AdvancedMode_TenChiJin_Auto"),
            NIN_AoE_AdvancedMode_Ninjitsus_Katon_Pooling = new("NIN_AoE_AdvancedMode_Ninjitsus_Katon_Pooling"),
            NIN_AoE_AdvancedMode_Ninjitsus_Katon_Uptime = new("NIN_AoE_AdvancedMode_Ninjitsus_Katon_Uptime"),
            NIN_AoE_AdvancedMode_TenChiJin_Auto = new("NIN_AoE_AdvancedMode_TenChiJin_Auto"),
            NIN_AoE_AdvancedMode_HellfrogMedium_Pooling = new("Ninki_HellfrogPooling"),
            NIN_AoE_AdvancedMode_ShadeShiftRaidwide = new("NIN_AoE_AdvancedMode_ShadeShiftRaidwide"),
            NIN_HideMug_TrickAfterMug = new("NIN_HideMug_TrickAfterMug"),
            NIN_HideMug_ToggleLevelCheck = new("NIN_HideMug_ToggleLevelCheck"),
            NIN_HideMug_Toggle = new("NIN_HideMug_Toggle"),
            NIN_HideMug_Trick = new("NIN_HideMug_Trick"),
            NIN_HideMug_Mug = new("NIN_HideMug_Mug");

        internal static UserBoolArray
            NIN_MudraProtection_Options = new("NIN_MudraProtection_Options");

        internal static UserFloat
            NIN_AoE_AdvancedMode_Ninjitsus_Doton_TimeStill = new("NIN_AoE_AdvancedMode_Ninjitsus_Doton_TimeStill", 3f),
            NIN_AoE_AdvancedMode_TCJ_Doton_Timer = new("NIN_AoE_AdvancedMode_TCJ_Doton_Timer", 3f);

        #endregion

        internal static void Draw(Preset preset)
        {
            switch (preset)
            {
                #region ST

                case Preset.NIN_ST_AdvancedMode:
                    DrawAdditionalBoolChoice(NIN_ST_AdvancedMode_TrueNorth, NIN_Config.DynamicTrueNorth,
                        NIN_Config.DynamicTrueNorthDesc);
                    DrawSliderInt(0, 10, NIN_ST_AdvancedMode_BurnKazematoi, FormatAndCache(NIN_Config.BurnKazematoi, AeolianEdge.ActionName()));
                    break;

                case Preset.NIN_ST_AdvancedMode_BalanceOpener:
                    DrawBossOnlyChoice(NIN_Balance_Content);
                    DrawOpenerPotionChoice(NIN_Opener_Potion);
                    DrawOpenerPrepullBlockChoice(NIN_Opener_PrepullBlock);
                    ImGuiEx.TextUnderlined(Generics.SelectOpener);
                    ImGui.Spacing();
                    DrawRadioButton(NIN_Adv_Opener_Selection, FormatAndCache(NIN_Config.StandardOpener4thGcd, KunaisBane.ActionName()), "", 0, descriptionAsTooltip: true);
                    DrawRadioButton(NIN_Adv_Opener_Selection, FormatAndCache(NIN_Config.StandardOpener3rdGcd, Dokumori.ActionName()), "", 1, descriptionAsTooltip: true);
                    DrawRadioButton(NIN_Adv_Opener_Selection, FormatAndCache(NIN_Config.StandardOpener3rdGcd, KunaisBane.ActionName()), "", 2, descriptionAsTooltip: true);
                    DrawRadioButton(NIN_Adv_Opener_Selection, NIN_Config.BuffRush, "", 3, descriptionAsTooltip: true);
                    break;

                case Preset.NIN_ST_AdvancedMode_Mug:
                    DrawSliderInt(0, 100, NIN_ST_AdvancedMode_Mug_Threshold,
                        NIN_Config.StopUsingBelowHp);
                    ImGui.Indent();
                    ImGui.TextColored(ImGuiColors.DalamudYellow, Generics.EnemyTypeCheck);
                    DrawHorizontalRadioButton(NIN_ST_AdvancedMode_Mug_SubOption,
                        Generics.NonBossEncountersOnly, Generics.HPCheckNonBossEncountersOnly, 0);
                    DrawHorizontalRadioButton(NIN_ST_AdvancedMode_Mug_SubOption,
                        Generics.AllContent, Generics.HPCheckAllContent, 1);
                    ImGui.Unindent();
                    break;

                case Preset.NIN_ST_AdvancedMode_TrickAttack:
                    DrawSliderInt(0, 100, NIN_ST_AdvancedMode_TrickAttack_Threshold,
                        NIN_Config.StopUsingBelowHp);
                    ImGui.Indent();
                    ImGui.TextColored(ImGuiColors.DalamudYellow, Generics.EnemyTypeCheck);
                    DrawHorizontalRadioButton(NIN_ST_AdvancedMode_TrickAttack_SubOption,
                        Generics.NonBossEncountersOnly, Generics.HPCheckNonBossEncountersOnly, 0);
                    DrawHorizontalRadioButton(NIN_ST_AdvancedMode_TrickAttack_SubOption,
                        Generics.AllContent, Generics.HPCheckAllContent, 1);
                    ImGui.Unindent();
                    break;

                case Preset.NIN_ST_AdvancedMode_Ninjitsus_Raiton:
                    DrawAdditionalBoolChoice(NIN_ST_AdvancedMode_Ninjitsus_Raiton_Pooling, NIN_Config.RaitonPooling,
                        NIN_Config.TrickWindowPooling);
                    DrawAdditionalBoolChoice(NIN_ST_AdvancedMode_Ninjitsus_Raiton_Uptime, NIN_Config.RaitonUptime,
                        NIN_Config.RaitonUptimeDesc);
                    break;

                case Preset.NIN_ST_AdvancedMode_Ninjitsus_Suiton:
                    DrawSliderInt(0, 21, NIN_ST_AdvancedMode_Ninjitsus_Suiton_Setup,
                        NIN_Config.SuitonSetup);
                    break;

                case Preset.NIN_ST_AdvancedMode_TenChiJin:
                    DrawAdditionalBoolChoice(NIN_ST_AdvancedMode_TenChiJin_Auto, NIN_Config.AutoTcj, NIN_Config.AutoTcjStDesc);
                    break;

                case Preset.NIN_ST_AdvancedMode_Bhavacakra:
                    DrawAdditionalBoolChoice(NIN_ST_AdvancedMode_Bhavacakra_Pooling, NIN_Config.BhavacakraPooling, NIN_Config.NinkiPoolingDesc);
                    break;

                case Preset.NIN_ST_AdvancedMode_Raiju:
                    DrawAdditionalBoolChoice(NIN_ST_AdvancedMode_ForkedRaiju, NIN_Config.ForkedRaiju, NIN_Config.ForkedRaijuDesc);
                    break;

                case Preset.NIN_ST_AdvancedMode_SecondWind:
                    DrawSliderInt(0, 100, NIN_ST_AdvancedMode_SecondWindThreshold,
                        FormatAndCache(NIN_Config.HpThresholdFor, Role.SecondWind.ActionName()));
                    break;

                case Preset.NIN_ST_AdvancedMode_ShadeShift:
                    DrawSliderInt(0, 100, NIN_ST_AdvancedMode_ShadeShiftThreshold,
                        FormatAndCache(NIN_Config.HpThresholdFor, ShadeShift.ActionName()));
                    DrawAdditionalBoolChoice(NIN_ST_AdvancedMode_ShadeShiftRaidwide, NIN_Config.RaidwideOption, NIN_Config.ShadeShiftRaidwideDesc);
                    break;

                case Preset.NIN_ST_AdvancedMode_Bloodbath:
                    DrawSliderInt(0, 100, NIN_ST_AdvancedMode_BloodbathThreshold,
                        FormatAndCache(NIN_Config.HpThresholdFor, Role.Bloodbath.ActionName()));
                    break;

                #endregion

                #region AoE

                case Preset.NIN_AoE_AdvancedMode_Ninjitsus_Katon:
                    DrawAdditionalBoolChoice(NIN_AoE_AdvancedMode_Ninjitsus_Katon_Pooling, NIN_Config.KatonPooling,
                        NIN_Config.TrickWindowPooling);
                    DrawAdditionalBoolChoice(NIN_AoE_AdvancedMode_Ninjitsus_Katon_Uptime, NIN_Config.KatonUptime,
                        NIN_Config.KatonUptimeDesc);
                    break;
                case Preset.NIN_AoE_AdvancedMode_Ninjitsus_Huton:
                    DrawSliderInt(0, 21, NIN_AoE_AdvancedMode_Ninjitsus_Huton_Setup,
                        NIN_Config.HutonSetup);
                    break;

                case Preset.NIN_AoE_AdvancedMode_Ninjitsus_Doton:
                    DrawSliderInt(0, 100, NIN_AoE_AdvancedMode_Ninjitsus_Doton_Threshold,
                        NIN_Config.DotonMaxHp);
                    ImGui.Indent();
                    DrawSliderFloat(0, 3, NIN_AoE_AdvancedMode_Ninjitsus_Doton_TimeStill, NIN_Config.DotonTimeStill, decimals: 1);
                    ImGui.Unindent();
                    break;

                case Preset.NIN_AoE_AdvancedMode_Mug:
                    DrawSliderInt(0, 100, NIN_AoE_AdvancedMode_Mug_Threshold,
                        NIN_Config.StopUsingBelowHp);
                    ImGui.Indent();
                    ImGui.TextColored(ImGuiColors.DalamudYellow, Generics.EnemyTypeCheck);
                    DrawHorizontalRadioButton(NIN_AoE_AdvancedMode_Mug_SubOption,
                        Generics.NonBossEncountersOnly, Generics.HPCheckNonBossEncountersOnly, 0);
                    DrawHorizontalRadioButton(NIN_AoE_AdvancedMode_Mug_SubOption,
                        Generics.AllContent, Generics.HPCheckAllContent, 1);
                    ImGui.Unindent();
                    break;

                case Preset.NIN_AoE_AdvancedMode_TrickAttack:
                    DrawSliderInt(0, 100, NIN_AoE_AdvancedMode_TrickAttack_Threshold,
                        NIN_Config.StopUsingBelowHp);
                    ImGui.Indent();
                    ImGui.TextColored(ImGuiColors.DalamudYellow, Generics.EnemyTypeCheck);
                    DrawHorizontalRadioButton(NIN_AoE_AdvancedMode_TrickAttack_SubOption,
                        Generics.NonBossEncountersOnly, Generics.HPCheckNonBossEncountersOnly, 0);
                    DrawHorizontalRadioButton(NIN_AoE_AdvancedMode_TrickAttack_SubOption,
                        Generics.AllContent, Generics.HPCheckAllContent, 1);
                    ImGui.Unindent();
                    break;


                case Preset.NIN_AoE_AdvancedMode_TenChiJin:
                    DrawAdditionalBoolChoice(NIN_AoE_AdvancedMode_TenChiJin_Auto, NIN_Config.AutoTcj,
                        FormatAndCache(NIN_Config.AutoTcjAoeDesc,
                            Doton.ActionName(), NIN_AoE_AdvancedMode_TCJ_Doton_Timer.Value,
                            FumaShuriken.ActionName(), Katon.ActionName(), Raiton.ActionName(), Suiton.ActionName()));

                    if (NIN_AoE_AdvancedMode_TenChiJin_Auto)
                    {
                        DrawSliderFloat(1, 17, NIN_AoE_AdvancedMode_TCJ_Doton_Timer, NIN_Config.DotonRemainingTimer, decimals: 1);
                    }
                    break;

                case Preset.NIN_AoE_AdvancedMode_SecondWind:
                    DrawSliderInt(0, 100, NIN_AoE_AdvancedMode_SecondWindThreshold, FormatAndCache(NIN_Config.HpThresholdFor, Role.SecondWind.ActionName()));
                    break;

                case Preset.NIN_AoE_AdvancedMode_ShadeShift:
                    DrawSliderInt(0, 100, NIN_AoE_AdvancedMode_ShadeShiftThreshold, FormatAndCache(NIN_Config.HpThresholdFor, ShadeShift.ActionName()));
                    DrawAdditionalBoolChoice(NIN_AoE_AdvancedMode_ShadeShiftRaidwide, NIN_Config.RaidwideOption, NIN_Config.ShadeShiftRaidwideDesc);
                    break;

                case Preset.NIN_AoE_AdvancedMode_Bloodbath:
                    DrawSliderInt(0, 100, NIN_AoE_AdvancedMode_BloodbathThreshold, FormatAndCache(NIN_Config.HpThresholdFor, Role.Bloodbath.ActionName()));
                    break;

                case Preset.NIN_AoE_AdvancedMode_HellfrogMedium:
                    DrawAdditionalBoolChoice(NIN_AoE_AdvancedMode_HellfrogMedium_Pooling, NIN_Config.HellfrogPooling, NIN_Config.NinkiPoolingDesc);
                    break;

                #endregion

                #region Standalone

                case Preset.NIN_Simple_Mudras:
                    DrawRadioButton(NIN_SimpleMudra_Choice, NIN_Config.MudraPathSet1,
                        FormatAndCache(NIN_Config.MudraPathSet1Desc,
                            Ten.ActionName(), FumaShuriken.ActionName(), Raiton.ActionName(), HyoshoRanryu.ActionName(),
                            Suiton.ActionName(), Doton.ActionName(), Kassatsu.ActionName(), Chi.ActionName(),
                            Hyoton.ActionName(), Huton.ActionName(), Jin.ActionName(), Katon.ActionName(),
                            GokaMekkyaku.ActionName()),
                        1);
                    DrawRadioButton(NIN_SimpleMudra_Choice, NIN_Config.MudraPathSet2,
                        FormatAndCache(NIN_Config.MudraPathSet2Desc,
                            Ten.ActionName(), FumaShuriken.ActionName(), Hyoton.ActionName(), HyoshoRanryu.ActionName(),
                            Doton.ActionName(), Chi.ActionName(), Katon.ActionName(), Suiton.ActionName(),
                            Jin.ActionName(), Raiton.ActionName(), GokaMekkyaku.ActionName(), Huton.ActionName(),
                            Kassatsu.ActionName()),
                        2);
                    break;


                case Preset.NIN_HideMug:
                    DrawAdditionalBoolChoice(NIN_HideMug_Mug, Mug.ActionName(), NIN_Config.MugInCombat);
                    DrawAdditionalBoolChoice(NIN_HideMug_Toggle, NIN_Config.HideQuickToggle, NIN_Config.HideQuickToggleDesc);
                    ImGui.Indent();
                    if (NIN_HideMug_Toggle)
                    {
                        DrawAdditionalBoolChoice(NIN_HideMug_ToggleLevelCheck, NIN_Config.LevelCheck, NIN_Config.LevelCheckDesc);
                    }
                    ImGui.Unindent();
                    DrawAdditionalBoolChoice(NIN_HideMug_Trick, FormatAndCache(Generics.Add0, TrickAttack.ActionName()), NIN_Config.AddTrickAttackDesc);
                    ImGui.Indent();
                    if (NIN_HideMug_Trick && NIN_HideMug_Mug)
                    {
                        DrawAdditionalBoolChoice(NIN_HideMug_TrickAfterMug, NIN_Config.MugFirst, NIN_Config.MugFirstDesc);
                    }
                    ImGui.Unindent();
                    break;


                case Preset.NIN_MudraProtection:
                    DrawHorizontalMultiChoice(NIN_MudraProtection_Options, ShadeShift.ActionName(), NIN_Config.BlocksInputMudra, 6, 0);
                    DrawHorizontalMultiChoice(NIN_MudraProtection_Options, Shukuchi.ActionName(), NIN_Config.BlocksInputMudra, 6, 1);
                    DrawHorizontalMultiChoice(NIN_MudraProtection_Options, Role.Feint.ActionName(), NIN_Config.BlocksInputMudraOrFeint, 6, 2);
                    DrawHorizontalMultiChoice(NIN_MudraProtection_Options, Role.Bloodbath.ActionName(), NIN_Config.BlocksInputMudra, 6, 3);
                    DrawHorizontalMultiChoice(NIN_MudraProtection_Options, Role.SecondWind.ActionName(), NIN_Config.BlocksInputMudra, 6, 4);
                    DrawHorizontalMultiChoice(NIN_MudraProtection_Options, Role.LegSweep.ActionName(), NIN_Config.BlocksInputMudra, 6, 5);
                    break;

                #endregion

            }
        }
    }
}
