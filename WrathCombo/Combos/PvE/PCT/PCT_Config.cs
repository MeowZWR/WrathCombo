using Dalamud.Interface.Colors;
using ECommons.ImGuiMethods;
using WrathCombo.CustomComboNS.Functions;
using WrathCombo.Extensions;
using WrathCombo.Resources.Localization.JobConfigs;
using WrathCombo.Window.Functions;
using static WrathCombo.Window.Functions.UserConfig;
using static WrathCombo.Window.Text;
namespace WrathCombo.Combos.PvE;

internal partial class PCT
{
    internal static class Config
    {
        #region Options
        public static UserInt
            CombinedAetherhueChoices = new("CombinedAetherhueChoices", 0),
            PCT_ST_AdvancedMode_BurnBoss = new("PCT_ST_AdvancedMode_BurnBoss"),
            PCT_AoE_AdvancedMode_BurnBoss = new("PCT_AoE_AdvancedMode_BurnBoss"),
            PCT_ST_AdvancedMode_LucidOption = new("PCT_ST_AdvancedMode_LucidOption", 6500),
            PCT_ST_AdvancedMode_HolyinWhiteOption = new("PCT_ST_AdvancedMode_HolyinWhiteOption", 2),
            PCT_AoE_AdvancedMode_HolyinWhiteOption = new("PCT_AoE_AdvancedMode_HolyinWhiteOption", 2),
            PCT_AoE_AdvancedMode_LucidOption = new("PCT_AoE_AdvancedMode_LucidOption", 6500),
            PCT_AoE_AdvancedMode_ScenicMuse_Threshold = new("PCT_AoE_AdvancedMode_ScenicMuse_Threshold", 20),
            PCT_ST_AdvancedMode_ScenicMuse_Threshold = new("PCT_ST_AdvancedMode_ScenicMuse_Threshold", 20),
            PCT_AoE_AdvancedMode_ScenicMuse_SubOption = new("PCT_AoE_AdvancedMode_ScenicMuse_SubOption"),
            PCT_ST_AdvancedMode_ScenicMuse_SubOption = new("PCT_ST_AdvancedMode_ScenicMuse_SubOption"),
            PCT_ST_CreatureStop = new("PCT_ST_CreatureStop", 10),
            PCT_AoE_CreatureStop = new("PCT_AoE_CreatureStop", 10),
            PCT_ST_WeaponStop = new("PCT_ST_WeaponStop", 10),
            PCT_AoE_WeaponStop = new("PCT_AoE_WeaponStop", 10),
            PCT_ST_LandscapeStop = new("PCT_ST_LandscapeStop", 10),
            PCT_AoE_LandscapeStop = new("PCT_AoE_LandscapeStop", 10),
            PCT_Opener_Choice = new("PCT_Opener_Choice", 0),
            PCT_Balance_Content = new("PCT_Balance_Content", 1);

        public static UserBool
            PCT_ST_AdvancedMode_ScenicMuse_MovementOption = new("PCT_ST_AdvancedMode_ScenicMuse_MovementOption"),
            PCT_AoE_AdvancedMode_ScenicMuse_MovementOption = new("PCT_AoE_AdvancedMode_ScenicMuse_MovementOption"),
            CombinedMotifsMog = new("CombinedMotifsMog"),
            CombinedMotifsMadeen = new("CombinedMotifsMadeen"),
            CombinedMotifsWeapon = new("CombinedMotifsWeapon"),
            CombinedMotifsLandscape = new("CombinedMotifsLandscape"),
            PCT_Opener_Potion = new("PCT_Opener_Potion"),
            PCT_Opener_PrepullBlock = new("PCT_Opener_PrepullBlock", true);

        public static UserFloat
            PCT_ST_AdvancedMode_HammerStampCombo_Timing = new("PCT_ST_AdvancedMode_HammerStampCombo_Timing", 30),
            PCT_AoE_AdvancedMode_HammerStampCombo_Timing = new("PCT_AoE_AdvancedMode_HammerStampCombo_Timing", 30);

        #endregion

        internal static void Draw(Preset preset)
        {
            switch (preset)
            {
                #region Single Target
                case Preset.PCT_ST_AdvancedMode:
                    DrawSliderInt(0, 10, PCT_ST_AdvancedMode_BurnBoss, PCT_Config.BurnBossHp);
                    break;

                case Preset.PCT_ST_Advanced_Openers:
                    DrawBossOnlyChoice(PCT_Balance_Content);
                    DrawOpenerPotionChoice(PCT_Opener_Potion);
                    DrawOpenerPrepullBlockChoice(PCT_Opener_PrepullBlock);
                    ImGuiEx.TextUnderlined(Generics.SelectOpener);
                    ImGui.Spacing();
                    DrawRadioButton(PCT_Opener_Choice, FormatAndCache(PCT_Config.SecondGcdStarryMuse, StarryMuse.ActionName()),
                        PCT_Config.OpenerTimeoutNote, 0, descriptionAsTooltip: true);
                    DrawRadioButton(PCT_Opener_Choice, FormatAndCache(PCT_Config.ThirdGcdStarryMuse, StarryMuse.ActionName()),
                        PCT_Config.OpenerTimeoutNote, 1, descriptionAsTooltip: true);
                    break;

                case Preset.PCT_ST_AdvancedMode_LucidDreaming:
                    DrawSliderInt(0, 10000, PCT_ST_AdvancedMode_LucidOption,
                        PCT_Config.AddLucidBelowMp, sliderIncrement: SliderIncrements.Hundreds);
                    break;

                case Preset.PCT_ST_AdvancedMode_ScenicMuse:
                    DrawAdditionalBoolChoice(PCT_ST_AdvancedMode_ScenicMuse_MovementOption, PCT_Config.DontUseIfMoving, PCT_Config.DontUseIfMovingDesc);

                    DrawSliderInt(0, 100, PCT_ST_AdvancedMode_ScenicMuse_Threshold,
                        PCT_Config.StopScenicMuseBelowHp);
                    ImGui.Indent();
                    ImGui.TextColored(ImGuiColors.DalamudYellow, Generics.EnemyTypeCheck);
                    DrawHorizontalRadioButton(PCT_ST_AdvancedMode_ScenicMuse_SubOption,
                        Generics.NonBossEncountersOnly, Generics.HPCheckNonBossEncountersOnly, 0);
                    DrawHorizontalRadioButton(PCT_ST_AdvancedMode_ScenicMuse_SubOption,
                        Generics.AllContent, Generics.HPCheckAllContent, 1);
                    ImGui.Unindent();
                    break;

                case Preset.PCT_AoE_AdvancedMode_ScenicMuse:
                    DrawAdditionalBoolChoice(PCT_AoE_AdvancedMode_ScenicMuse_MovementOption, PCT_Config.DontUseIfMoving, PCT_Config.DontUseIfMovingDesc);

                    DrawSliderInt(0, 100, PCT_AoE_AdvancedMode_ScenicMuse_Threshold,
                        PCT_Config.StopScenicMuseBelowHp);
                    ImGui.Indent();
                    ImGui.TextColored(ImGuiColors.DalamudYellow, Generics.EnemyTypeCheck);
                    DrawHorizontalRadioButton(PCT_AoE_AdvancedMode_ScenicMuse_SubOption,
                        Generics.NonBossEncountersOnly, Generics.HPCheckNonBossEncountersOnly, 0);
                    DrawHorizontalRadioButton(PCT_AoE_AdvancedMode_ScenicMuse_SubOption,
                        Generics.AllContent, Generics.HPCheckAllContent, 1);
                    ImGui.Unindent();
                    break;

                case Preset.PCT_ST_AdvancedMode_HammerStampCombo:
                    DrawSliderFloat(15, 30, PCT_ST_AdvancedMode_HammerStampCombo_Timing, PCT_Config.HammerTimeRemaining, decimals: 0);
                    break;

                case Preset.PCT_ST_AdvancedMode_LandscapeMotif:
                    DrawSliderInt(0, 10, PCT_ST_LandscapeStop, PCT_Config.HealthStopDrawingMotif);
                    break;

                case Preset.PCT_ST_AdvancedMode_CreatureMotif:
                    DrawSliderInt(0, 10, PCT_ST_CreatureStop, PCT_Config.HealthStopDrawingMotif);
                    break;

                case Preset.PCT_ST_AdvancedMode_WeaponMotif:
                    DrawSliderInt(0, 10, PCT_ST_WeaponStop, PCT_Config.HealthStopDrawingMotif);
                    break;

                case Preset.PCT_ST_AdvancedMode_HolyinWhite:
                    DrawSliderInt(0, 5, PCT_ST_AdvancedMode_HolyinWhiteOption,
                        Generics.HowManyChargesToKeepReady);
                    break;

                #endregion

                #region AoE

                case Preset.PCT_AoE_AdvancedMode:
                    DrawSliderInt(0, 10, PCT_AoE_AdvancedMode_BurnBoss, PCT_Config.BurnBossHp);
                    break;

                case Preset.PCT_AoE_AdvancedMode_HolyinWhite:
                    DrawSliderInt(0, 5, PCT_AoE_AdvancedMode_HolyinWhiteOption,
                        Generics.HowManyChargesToKeepReady);
                    break;

                case Preset.PCT_AoE_AdvancedMode_LucidDreaming:
                    DrawSliderInt(0, 10000, PCT_AoE_AdvancedMode_LucidOption,
                        PCT_Config.AddLucidBelowMp, sliderIncrement: SliderIncrements.Hundreds);
                    break;

                case Preset.PCT_AoE_AdvancedMode_HammerStampCombo:
                    DrawSliderFloat(15, 30, PCT_AoE_AdvancedMode_HammerStampCombo_Timing, PCT_Config.HammerTimeRemaining, decimals: 0);
                    break;

                case Preset.PCT_AoE_AdvancedMode_LandscapeMotif:
                    DrawSliderInt(0, 10, PCT_AoE_LandscapeStop, PCT_Config.HealthStopDrawingMotif);
                    break;

                case Preset.PCT_AoE_AdvancedMode_CreatureMotif:
                    DrawSliderInt(0, 10, PCT_AoE_CreatureStop, PCT_Config.HealthStopDrawingMotif);
                    break;

                case Preset.PCT_AoE_AdvancedMode_WeaponMotif:
                    DrawSliderInt(0, 10, PCT_AoE_WeaponStop, PCT_Config.HealthStopDrawingMotif);
                    break;

                #endregion

                #region Standalone
                case Preset.CombinedAetherhues:
                    DrawRadioButton(CombinedAetherhueChoices, PCT_Config.BothSingleTargetAoe,
                        FormatAndCache(PCT_Config.ReplacesBoth0And1, BlizzardinCyan.ActionName(), BlizzardIIinCyan.ActionName()), 0);
                    DrawRadioButton(CombinedAetherhueChoices, PCT_Config.SingleTargetOnly,
                        FormatAndCache(PCT_Config.ReplaceOnly0, BlizzardinCyan.ActionName()), 1);
                    DrawRadioButton(CombinedAetherhueChoices, PCT_Config.AoeOnly,
                        FormatAndCache(PCT_Config.ReplaceOnly0, BlizzardIIinCyan.ActionName()), 2);
                    break;

                case Preset.CombinedMotifs:
                    DrawAdditionalBoolChoice(CombinedMotifsMog, FormatAndCache(PCT_Config.MogFeature, MogoftheAges.ActionName()),
                        FormatAndCache(PCT_Config.AddWhenFullyDrawnOffCd, MogoftheAges.ActionName()));
                    DrawAdditionalBoolChoice(CombinedMotifsMadeen,
                        FormatAndCache(PCT_Config.MogFeature, RetributionoftheMadeen.ActionName()),
                        FormatAndCache(PCT_Config.AddWhenFullyDrawnOffCd, RetributionoftheMadeen.ActionName()));
                    DrawAdditionalBoolChoice(CombinedMotifsWeapon, FormatAndCache(PCT_Config.MogFeature, HammerStamp.ActionName()),
                        FormatAndCache(PCT_Config.AddWhenUnderEffect, HammerStamp.ActionName(), Buffs.HammerTime.StatusName()));
                    DrawAdditionalBoolChoice(CombinedMotifsLandscape, FormatAndCache(PCT_Config.MogFeature, StarPrism.ActionName()),
                        FormatAndCache(PCT_Config.AddWhenUnderEffect, StarPrism.ActionName(), Buffs.Starstruck.StatusName()));
                    break;

                #endregion
            }
        }
    }

}
