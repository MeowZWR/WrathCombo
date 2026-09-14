using Dalamud.Interface.Colors;
using ECommons.ImGuiMethods;
using WrathCombo.CustomComboNS.Functions;
using WrathCombo.Extensions;
using WrathCombo.Resources.Localization.JobConfigs;
using WrathCombo.Window.Functions;
using static WrathCombo.Window.Functions.UserConfig;
using static WrathCombo.Window.Text;
namespace WrathCombo.Combos.PvE;

internal partial class OccultCrescent
{
    internal static class Config
    {
        internal static void Draw(Preset preset)
        {
            switch (preset)
            {
                case Preset.Phantom_Freelancer_OccultResuscitation:
                    DrawSliderInt(1, 100, Phantom_Freelancer_Resuscitation_Health,
                        Generics.StopFriendlyHpPercent100, 200);
                    break;

                case Preset.Phantom_Geomancer_Sunbath:
                    DrawSliderInt(1, 100, Phantom_Geomancer_Sunbath_Health,
                        Generics.StopFriendlyHpPercent100, 200);
                    break;

                case Preset.Phantom_Knight_PhantomGuard:
                    DrawSliderInt(1, 100, Phantom_Knight_PhantomGuard_Health,
                        Generics.StopFriendlyHpPercent100, 200);
                    break;
                case Preset.Phantom_Knight_Pray:
                    DrawSliderInt(1, 100, Phantom_Knight_Pray_Health,
                        Generics.StopFriendlyHpPercent100, 200);
                    DrawAdditionalBoolChoice(Phantom_Knight_Pray_KeepUp,
                        Resources.Localization.Content.OccultCrescent.KeepPrayUp,
                        Resources.Localization.Content.OccultCrescent.KeepPrayUpDesc);
                    DrawStatusRefreshSlider();
                    break;
                case Preset.Phantom_Knight_OccultHeal:
                    DrawSliderInt(1, 100, Phantom_Knight_OccultHeal_Health,
                        Generics.StopFriendlyHpPercent100, 200);
                    break;
                case Preset.Phantom_Knight_Pledge:
                    DrawSliderInt(1, 100, Phantom_Knight_Pledge_Health,
                        Generics.StopFriendlyHpPercent100, 200);
                    DrawAdditionalBoolChoice(Phantom_Knight_Pledge_SelfOnly,
                        Generics.SelfOnly,
                        Resources.Localization.Content.OccultCrescent.PledgeSelfOnlyDesc);
                    break;
                case Preset.Phantom_Bard_MightyMarch:
                    DrawSliderInt(1, 100, Phantom_Bard_MightyMarch_Health,
                        Generics.StopFriendlyHpPercent100, 200);
                    break;

                case Preset.Phantom_Monk_OccultChakra:
                    DrawSliderInt(1, 100, Phantom_Monk_OccultChakra_Health,
                        Generics.StopFriendlyHpPercent100, 200);
                    DrawSliderInt(0, 10000, Phantom_Monk_OccultChakra_MP,
                        Generics.MPLessOrEqual, sliderIncrement: SliderIncrements.Hundreds);
                    break;

                case Preset.Phantom_Monk_PhantomKick:
                    DrawSliderInt(1, 15, Phantom_Monk_PhantomKick_Distance,
                        Resources.Localization.Content.OccultCrescent.MaxTargetDistancePhantomKick, 200);
                    break;

                case Preset.Phantom_Oracle_Blessing:
                    DrawSliderInt(1, 100, Phantom_Oracle_Blessing_Health,
                        Resources.Localization.Content.OccultCrescent.BlessingHpThreshold, 200);
                    break;

                case Preset.Phantom_Oracle_PhantomJudgment:
                    DrawSliderInt(1, 100, Phantom_Oracle_Judgment_PartyHP,
                        Resources.Localization.Content.OccultCrescent.JudgmentHealHpThreshold, 200);
                    break;

                case Preset.Phantom_Oracle_Starfall:
                    DrawSliderInt(91, 100, Phantom_Oracle_Starfall_Health,
                        Generics.PlayerHPGreaterOrEqual, 200);
                    break;

                case Preset.Phantom_Oracle_PhantomRejuvenation:
                    DrawSliderInt(1, 100, Phantom_Oracle_PhantomRejuvenation_Health,
                        Generics.StopFriendlyHpPercent100, 200);
                    break;

                case Preset.Phantom_Oracle_Invulnerability:
                    DrawAdditionalBoolChoice(Phantom_Oracle_SaveInvulnForStarfall,
                        Resources.Localization.Content.OccultCrescent.SaveForStarfall,
                        Resources.Localization.Content.OccultCrescent.SaveForStarfallDesc);
                    if (!Phantom_Oracle_SaveInvulnForStarfall)
                    {
                        DrawSliderInt(1, 100, Phantom_Oracle_Invulnerability_Health,
                            Generics.StopFriendlyHpPercent100, 200);
                    }
                    break;

                case Preset.Phantom_Geomancer_Suspend:
                    DrawAdditionalBoolChoice(Phantom_Geomancer_Suspend_InCombat,
                        Resources.Localization.Content.OccultCrescent.InCombat, Resources.Localization.Content.OccultCrescent.InCombatDesc);
                    DrawAdditionalBoolChoice(Phantom_Geomancer_Suspend_OutOfCombat,
                        Resources.Localization.Content.OccultCrescent.OutOfCombat, Resources.Localization.Content.OccultCrescent.OutOfCombatDesc);
                    break;

                case Preset.Phantom_BlackMage_OccultToad:
                    DrawAdditionalBoolChoice(Phantom_BlackMage_OccultToad_RequireAoE,
                        Resources.Localization.Content.OccultCrescent.OnlyAsAoEMit,
                        Resources.Localization.Content.OccultCrescent.OnlyAsAoEMitDesc);
                    break;

                case Preset.Phantom_Monk_Counterstance:
                case Preset.Phantom_Thief_PilferWeapon:
                case Preset.Phantom_Ninja_Smoke:
                case Preset.Phantom_TimeMage_OccultMageMasher:
                case Preset.Phantom_Bard_OffensiveAria:
                case Preset.Phantom_Dancer_QuickStep:
                    DrawStatusRefreshSlider();
                    break;

                case Preset.Phantom_RedMage_OccultLibra_Refresh:
                    DrawSliderInt(1, 60, Phantom_RedMage_OccultLibra_RefreshRemaining,
                        Resources.Localization.Content.OccultCrescent.RefreshOccultLibra,
                        200);
                    break;

                case Preset.Phantom_MysticKnight_BlazingSpellblade:
                    DrawStatusRefreshSlider(
                        Resources.Localization.Content.OccultCrescent.BlazingSpellbladeRefreshNote);
                    break;

                case Preset.Phantom_Ranger_OccultUnicorn:
                    DrawSliderInt(1, 100, Phantom_Ranger_OccultUnicorn_Health,
                        Generics.StopFriendlyHpPercent100, 200);
                    break;

                case Preset.Phantom_Ranger_PhantomAim:
                    DrawSliderInt(1, 100, Phantom_Ranger_PhantomAim_Stop,
                        Generics.PlayerHPGreaterOrEqual, 200);
                    break;

                case Preset.Phantom_Dragoon_OccultJump:
                    DrawHorizontalMultiChoice(Phantom_Dragoon_OccultJumpMovingOrInRanged,
                        Generics.NoMovement,
                        Generics.OnlyUse0WhenNotMoving, 2, 0);

                    DrawHorizontalMultiChoice(Phantom_Dragoon_OccultJumpMovingOrInRanged,
                        Generics.InMeleeRange,
                        Generics.OnlyUse0WhenInMeleeRange, 2, 1);
                    break;

                case Preset.Phantom_Thief_Steal:
                    DrawSliderInt(1, 50, Phantom_Thief_Steal_Health,
                        Generics.PlayerHPGreaterOrEqual, 200);
                    break;

                case Preset.Phantom_Samurai_Zeninage:
                    ImGui.Indent();
                    ImGuiEx.TextWrapped(ImGuiColors.DalamudRed, Resources
                        .Localization.Content.OccultCrescent.Costly);
                    ImGui.Unindent();
                    break;

                case Preset.Phantom_Chemist_OccultPotion:
                    ImGui.Indent();
                    ImGuiEx.TextWrapped(ImGuiColors.DalamudRed, Resources
                        .Localization.Content.OccultCrescent.Costly);
                    ImGui.Unindent();
                    DrawSliderInt(1, 100, Phantom_Chemist_OccultPotion_Health,
                        Generics.StopFriendlyHpPercent100, 200);
                    DrawAdditionalBoolChoice(Phantom_Chemist_OccultPotion_SelfOnly,
                        Generics.SelfOnly, Resources.Localization.Content.OccultCrescent.PotionSelfOnlyDesc);
                    break;

                case Preset.Phantom_Chemist_OccultEther:
                    ImGui.Indent();
                    ImGuiEx.TextWrapped(ImGuiColors.DalamudRed, Resources
                        .Localization.Content.OccultCrescent.Costly);
                    ImGui.Unindent();
                    DrawSliderInt(1, 10000, Phantom_Chemist_OccultEther_MP,
                        Generics.MPLessOrEqual, sliderIncrement: SliderIncrements.Hundreds);
                    DrawAdditionalBoolChoice(Phantom_Chemist_OccultEther_SelfOnly,
                        Generics.SelfOnly, Resources.Localization.Content.OccultCrescent.EtherSelfOnlyDesc);
                    break;

                case Preset.Phantom_Chemist_OccultElixir:
                    ImGui.Indent();
                    ImGuiEx.TextWrapped(ImGuiColors.DalamudRed, Resources.Localization.Content.OccultCrescent.VeryCostly);
                    ImGui.Unindent();
                    DrawSliderInt(1, 100, Phantom_Chemist_OccultElixir_HP,
                        Resources.Localization.Content.OccultCrescent.AveragePartyHPLessOrEqual, 200);
                    DrawAdditionalBoolChoice(Phantom_Chemist_OccultElixir_RequireParty,
                        Resources.Localization.Content.OccultCrescent.AtLeast1PartyMember, "");
                    ImGui.Indent();
                    ImGuiEx.TextWrapped(ImGuiColors.DalamudYellow, Resources.Localization.Content.OccultCrescent.NotAdvised);
                    ImGuiEx.TextWrapped(ImGuiColors.DalamudYellow, Resources.Localization.Content.OccultCrescent.SliderShouldBeLow);
                    ImGui.Unindent();
                    break;

                case Preset.Phantom_TimeMage_OccultComet:
                    DrawAdditionalBoolChoice(Phantom_TimeMage_Comet_RequireSpeed,
                        FormatAndCache(Resources.Localization.Content.OccultCrescent.Requires0Or1ToUse2, Caster.Role.Swiftcast.ActionName(), Buffs.OccultQuick.StatusName(), OccultComet.ActionName()), "");
                    if (Phantom_TimeMage_Comet_RequireSpeed)
                    {
                        ImGui.Indent();
                        DrawAdditionalBoolChoice(
                            Phantom_TimeMage_Comet_UseSpeed,
                            FormatAndCache(Resources.Localization.Content.OccultCrescent.Add0Or1PriorUsing2, Caster.Role.Swiftcast.ActionName(), Buffs.OccultQuick.StatusName(), OccultComet.ActionName()), "");
                        ImGui.Unindent();
                    }
                    break;

                case Preset.Phantom_RestrictToBuff:
                    ImGui.Indent();
                    ImGuiEx.TextWrapped(ImGuiColors.DalamudYellow,
                        Resources.Localization.Content.OccultCrescent.BuffOnlyNotRecommended);
                    ImGuiEx.TextWrapped(ImGuiColors.DalamudRed,
                        Resources.Localization.Content.OccultCrescent.BuffOnlyDont);
                    ImGuiEx.TextWrapped(ImGuiColors.DalamudGrey,
                        Resources.Localization.Content.OccultCrescent.BuffOnlyList);
                    ImGui.Unindent();
                    break;

                case Preset.Phantom_WhiteMage_OccultCureII:
                    DrawSliderInt(1, 100, Phantom_WhiteMage_OccultCureII_Health,
                        Generics.StopFriendlyHpPercent100, 200);
                    break;
                case Preset.Phantom_WhiteMage_OccultCureIII:
                    DrawSliderInt(1, 100, Phantom_WhiteMage_OccultCureIII_Health,
                        Generics.StopFriendlyHpPercent100, 200);
                    break;
                case Preset.Phantom_BlueMage_OccultWhiteWind:
                    DrawSliderInt(1, 100, Phantom_BlueMage_OccultWhiteWind_Health,
                        Generics.StopFriendlyHpPercent100, 200);
                    break;
                case Preset.Phantom_RedMage_OccultCureII:
                    DrawSliderInt(1, 100, Phantom_RedMage_OccultCureII_Health,
                        Generics.StopFriendlyHpPercent100, 200);
                    break;
                case Preset.Phantom_RedMage_OccultCureII_Retarget:
                    DrawAdditionalBoolChoice(Phantom_RedMage_Retarget_OutOfParty, 
                        Resources.Localization.Content.OccultCrescent.RetargetOutOfParty, 
                        Resources.Localization.Content.OccultCrescent.RetargetOutOfPartyDesc);
                    break;
                case Preset.Phantom_Necromancer_DrainTouch:
                    ImGui.Indent();
                    ImGui.Text(Resources.Localization.Content.OccultCrescent.DrainTouchUsage);
                    DrawHorizontalRadioButton(Phantom_Necromancer_DrainTouch_Mode,
                        Resources.Localization.Content.OccultCrescent.DrainTouchDps, Resources.Localization.Content.OccultCrescent.DrainTouchDpsDesc, 0);
                    DrawHorizontalRadioButton(Phantom_Necromancer_DrainTouch_Mode,
                        Resources.Localization.Content.OccultCrescent.DrainTouchHeal, Resources.Localization.Content.OccultCrescent.DrainTouchHealDesc, 1);
                    DrawHorizontalRadioButton(Phantom_Necromancer_DrainTouch_Mode,
                        Resources.Localization.Content.OccultCrescent.DrainTouchEmergency, Resources.Localization.Content.OccultCrescent.DrainTouchEmergencyDesc, 2);
                    ImGui.Unindent();
                    if (Phantom_Necromancer_DrainTouch_Mode == 1)
                    {
                        DrawSliderInt(1, 100, Phantom_Necromancer_DrainTouch_Health,
                            Generics.StopFriendlyHpPercent100, 200);
                    }
                    else if (Phantom_Necromancer_DrainTouch_Mode == 2)
                    {
                        DrawSliderInt(1, 100, Phantom_Necromancer_DrainTouch_EmergencyHealth,
                            Generics.StopFriendlyHpPercent100, 200);
                    }
                    break;

                case Preset.Phantom_Necromancer:
                    ImGui.Indent();
                    ImGui.Text(Resources.Localization.Content.OccultCrescent.NecroSpellsDuringDrain);
                    DrawHorizontalRadioButton(Phantom_Necromancer_SpellDuringDrainTouch,
                        Resources.Localization.Content.OccultCrescent.OnlyWhenInactive,
                        Resources.Localization.Content.OccultCrescent.OnlyWhenInactiveDesc, 0);
                    DrawHorizontalRadioButton(Phantom_Necromancer_SpellDuringDrainTouch,
                        Resources.Localization.Content.OccultCrescent.OnlyWhenActive,
                        Resources.Localization.Content.OccultCrescent.OnlyWhenActiveDesc, 1);
                    DrawHorizontalRadioButton(Phantom_Necromancer_SpellDuringDrainTouch,
                        Resources.Localization.Content.OccultCrescent.Either,
                        Resources.Localization.Content.OccultCrescent.EitherDesc, 2);
                    ImGui.Unindent();
                    break;

                case Preset.Phantom_Gladiator_Defend:
                    DrawAdditionalBoolChoice(Phantom_Gladiator_DefendOnlyAtMaxFervor,
                        Resources.Localization.Content.OccultCrescent.OnlyAt4FinishingFervor,
                        Resources.Localization.Content.OccultCrescent.OnlyAt4FinishingFervorDesc);
                    break;

                case Preset.Phantom_Cannoneer_DarkCannon:
                case Preset.Phantom_Cannoneer_ShockCannon:
                    ImGui.Indent();
                    ImGui.Text(Resources.Localization.Content.OccultCrescent.WhenBothBlindParalysis);
                    DrawHorizontalRadioButton(Phantom_Cannoneer_DarkShockPrefer,
                        Resources.Localization.Content.OccultCrescent.PreferDarkCannon, Resources.Localization.Content.OccultCrescent.Blind, 0);
                    DrawHorizontalRadioButton(Phantom_Cannoneer_DarkShockPrefer,
                        Resources.Localization.Content.OccultCrescent.PreferShockCannon, Resources.Localization.Content.OccultCrescent.Paralysis, 1);
                    ImGui.Text(Resources.Localization.Content.OccultCrescent.WhenNeitherCanApply);
                    DrawHorizontalRadioButton(Phantom_Cannoneer_DarkShockImmunePrefer,
                        Resources.Localization.Content.OccultCrescent.UseDarkCannon, "", 0);
                    DrawHorizontalRadioButton(Phantom_Cannoneer_DarkShockImmunePrefer,
                        Resources.Localization.Content.OccultCrescent.UseShockCannon, "", 1);
                    ImGui.Unindent();
                    break;
            }
        }

        private static void DrawStatusRefreshSlider(string extraNote = "")
        {
            DrawSliderInt(0, 15, Phantom_StatusRefresh_Remaining,
                Resources.Localization.Content.OccultCrescent.StatusRefreshSlider,
                200);
            if (extraNote.Length > 0)
                ImGui.TextWrapped(extraNote);
        }

        #region Variables

        public static UserInt
            Phantom_Freelancer_Resuscitation_Health = new("Phantom_Freelancer_Resuscitation_Health", 50),
            Phantom_Geomancer_Sunbath_Health = new("Phantom_Geomancer_Sunbath_Health", 50),
            Phantom_Knight_PhantomGuard_Health = new("Phantom_Knight_PhantomGuard_Health", 50),
            Phantom_Knight_Pray_Health = new("Phantom_Knight_Pray_Health", 50),
            Phantom_Knight_OccultHeal_Health = new("Phantom_Knight_OccultHeal_Health", 50),
            Phantom_Knight_Pledge_Health = new("Phantom_Knight_Pledge_Health", 50),
            Phantom_Bard_MightyMarch_Health = new("Phantom_Bard_MightyMarch_Health", 50),
            Phantom_Monk_OccultChakra_Health = new("Phantom_Monk_OccultChakra_Health", 29),
            Phantom_Monk_OccultChakra_MP = new("Phantom_Monk_OccultChakra_MP", 3000),
            Phantom_Monk_PhantomKick_Distance = new("Phantom_Monk_PhantomKick_Distance", 5),
            Phantom_Chemist_OccultPotion_Health = new("Phantom_Chemist_OccultPotion_Health", 50),
            Phantom_Chemist_OccultEther_MP = new("Phantom_Chemist_OccultEther_MP", 2000),
            Phantom_Chemist_OccultElixir_HP = new("Phantom_Chemist_OccultElixir_HP", 25),
            Phantom_Oracle_Blessing_Health = new("Phantom_Oracle_Blessing_Health", 50),
            Phantom_Oracle_Judgment_PartyHP = new("Phantom_Oracle_Judgment_PartyHP", 70),
            Phantom_Oracle_Starfall_Health = new("Phantom_Oracle_Starfall_Health", 100),
            Phantom_Oracle_PhantomRejuvenation_Health = new("Phantom_Oracle_PhantomRejuvenation_Health", 50),
            Phantom_Oracle_Invulnerability_Health = new("Phantom_Oracle_Invulnerability_Health", 30),
            Phantom_Ranger_OccultUnicorn_Health = new("Phantom_Ranger_OccultUnicorn_Health", 50),
            Phantom_Ranger_PhantomAim_Stop = new("Phantom_Ranger_PhantomAim_Stop", 30),
            Phantom_Thief_Steal_Health = new("Phantom_Thief_Steal_Health", 10),
            Phantom_WhiteMage_OccultCureII_Health = new("Phantom_WhiteMage_OccultCureII_Health", 50),
            Phantom_WhiteMage_OccultCureIII_Health = new("Phantom_WhiteMage_OccultCureIII_Health", 40),
            Phantom_BlueMage_OccultWhiteWind_Health = new("Phantom_BlueMage_OccultWhiteWind_Health", 50),
            Phantom_RedMage_OccultCureII_Health = new("Phantom_RedMage_OccultCureII_Health", 50),
            Phantom_Necromancer_DrainTouch_Health = new("Phantom_Necromancer_DrainTouch_Health", 50),
            Phantom_Necromancer_DrainTouch_EmergencyHealth = new("Phantom_Necromancer_DrainTouch_EmergencyHealth", 25),
            Phantom_Necromancer_DrainTouch_Mode = new("Phantom_Necromancer_DrainTouch_Mode", 0),
            Phantom_Necromancer_SpellDuringDrainTouch = new("Phantom_Necromancer_SpellDuringDrainTouch", 0),
            Phantom_Cannoneer_DarkShockPrefer = new("Phantom_Cannoneer_DarkShockPrefer", 0),
            Phantom_Cannoneer_DarkShockImmunePrefer = new("Phantom_Cannoneer_DarkShockImmunePrefer", 0),
            Phantom_StatusRefresh_Remaining = new("Phantom_StatusRefresh_Remaining", 5),
            Phantom_RedMage_OccultLibra_RefreshRemaining = new("Phantom_RedMage_OccultLibra_RefreshRemaining", 30);

        public static UserBool
            Phantom_Chemist_OccultElixir_RequireParty = new("Phantom_Chemist_OccultElixir_RequireParty", true),
            Phantom_Chemist_OccultPotion_SelfOnly = new("Phantom_Chemist_OccultPotion_SelfOnly", true),
            Phantom_Chemist_OccultEther_SelfOnly = new("Phantom_Chemist_OccultEther_SelfOnly", true),
            Phantom_TimeMage_Comet_RequireSpeed = new("Phantom_TimeMage_Comet_RequireSpeed", true),
            Phantom_TimeMage_Comet_UseSpeed = new("Phantom_TimeMage_Comet_UseSpeed", true),
            Phantom_Oracle_SaveInvulnForStarfall = new("Phantom_Oracle_SaveInvulnForStarfall", true),
            Phantom_Gladiator_DefendOnlyAtMaxFervor = new("Phantom_Gladiator_DefendOnlyAtMaxFervor", false),
            Phantom_Knight_Pray_KeepUp = new("Phantom_Knight_Pray_KeepUp", true),
            Phantom_Knight_Pledge_SelfOnly = new("Phantom_Knight_Pledge_SelfOnly", false),
            Phantom_Geomancer_Suspend_InCombat = new("Phantom_Geomancer_Suspend_InCombat", false),
            Phantom_Geomancer_Suspend_OutOfCombat = new("Phantom_Geomancer_Suspend_OutOfCombat", false),
            Phantom_RedMage_Retarget_OutOfParty = new("Phantom_RedMage_Retarget_OutOfParty", false),
            Phantom_BlackMage_OccultToad_RequireAoE = new("Phantom_BlackMage_OccultToad_RequireAoE", true);

        public static UserBoolArray
            Phantom_Dragoon_OccultJumpMovingOrInRanged = new("Phantom_Dragoon_OccultJumpMovingOrInRanged", [true, true]);

        #endregion
    }
}
