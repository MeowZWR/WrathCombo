using WrathCombo.CustomComboNS.Functions;
using WrathCombo.Extensions;
using WrathCombo.Window.Functions;
using static WrathCombo.Window.Functions.UserConfig;
namespace WrathCombo.Combos.PvE;

internal partial class SMN
{
    internal static class Config
    {
        #region Options
        public static UserInt
            SMN_ST_Simple_Combo_Gapclose = new("SMN_ST_Simple_Combo_Gapclose"),
            SMN_AoE_Simple_Combo_Gapclose = new("SMN_AoE_Simple_Combo_Gapclose"),
            
            SMN_ST_Advanced_Combo_AltMode = new("SMN_ST_Advanced_Combo_AltMode"),
            SMN_ST_Lucid = new("SMN_ST_Lucid", 8000),
            SMN_ST_SwiftcastPhase = new("SMN_SwiftcastPhase", 1),
            SMN_ST_CrimsonCycloneMeleeDistance = new("SMN_ST_CrimsonCycloneMeleeDistance", 25),
            SMN_Opener_SkipSwiftcast = new("SMN_Opener_SkipSwiftcast", 1),

            SMN_AoE_Lucid = new("SMN_AoE_Lucid", 8000),
            SMN_AoE_CrimsonCycloneMeleeDistance = new("SMN_AoE_CrimsonCycloneMeleeDistance", 25),
            SMN_AoE_SwiftcastPhase = new("SMN_AoE_SwiftcastPhase", 1),

            SMN_Balance_Content = new("SMN_Balance_Content", 1);

        public static UserBoolArray
            SMN_ST_Egi_AstralFlow = new("SMN_ST_Egi_AstralFlow"),
            SMN_AoE_Egi_AstralFlow = new("SMN_AoE_Egi_AstralFlow");

        internal static UserIntArray
            SMN_ST_Egi_Priority = new("SMN_ST_Egi_Priority"),
            SMN_AoE_Egi_Priority = new("SMN_AoE_Egi_Priority");
        #endregion
        internal static void Draw(Preset preset)
        {
            switch (preset)
            {
                #region Single Target
                case Preset.SMN_ST_Simple_Combo:
                    DrawHorizontalRadioButton(SMN_ST_Simple_Combo_Gapclose, "Safe Mode (Will not gap close)", "Will only use Crimson Cyclone when in Melee Range", 0);
                    DrawHorizontalRadioButton(SMN_ST_Simple_Combo_Gapclose, "Standard Rotation", "Will gap close with Crimson Cyclone.", 1 );
                    break;
                
                case Preset.SMN_AoE_Simple_Combo:
                    DrawHorizontalRadioButton(SMN_AoE_Simple_Combo_Gapclose, "Safe Mode (Will not gap close)", "Will only use Crimson Cyclone when in Melee Range", 0);
                    DrawHorizontalRadioButton(SMN_AoE_Simple_Combo_Gapclose, "Standard Rotation", "Will gap close with Crimson Cyclone.", 1 );
                    break;
                    
                case Preset.SMN_ST_Advanced_Combo:
                    DrawRadioButton(SMN_ST_Advanced_Combo_AltMode, "在毁灭、毁坏和毁荡上", "", 0);
                    DrawRadioButton(SMN_ST_Advanced_Combo_AltMode, "仅在毁灭和毁坏上", "替代DPS模式。保持毁荡独立以获得纯DPS。", 1);
                    break;

                case Preset.SMN_ST_Advanced_Combo_Balance_Opener:
                    DrawBossOnlyChoice(SMN_Balance_Content);
                    ImGui.NewLine();
                    DrawHorizontalRadioButton(SMN_Opener_SkipSwiftcast, "使用即刻咏唱",
                        "将在起手式中插入即刻咏唱，确保药水效果覆盖到短GCD技能。", 1);
                    DrawHorizontalRadioButton(SMN_Opener_SkipSwiftcast, "跳过即刻咏唱",
                        "不在起手式中插入即刻咏唱，优先保证高GCD技能覆盖。", 2);
                    break;

                case Preset.SMN_ST_Advanced_Combo_Titan:
                    DrawPriorityInput(SMN_ST_Egi_Priority, 3, 0,
                        $"{SummonTopaz.ActionName()} Priority: ");
                    break;

                case Preset.SMN_ST_Advanced_Combo_Garuda:
                    DrawPriorityInput(SMN_ST_Egi_Priority, 3, 1,
                        $"{SummonEmerald.ActionName()} Priority: ");
                    break;

                case Preset.SMN_ST_Advanced_Combo_Ifrit:
                    DrawPriorityInput(SMN_ST_Egi_Priority, 3, 2,
                        $"{SummonRuby.ActionName()} Priority: ");
                    break;

                case Preset.SMN_ST_Advanced_Combo_DemiEgiMenu_SwiftcastEgi:
                    DrawHorizontalRadioButton(SMN_ST_SwiftcastPhase, "Garuda", "Swiftcasts Slipstream", 1);
                    DrawHorizontalRadioButton(SMN_ST_SwiftcastPhase, "Ifrit", "Swiftcasts Ruby Ruin/Ruby Rite", 2);
                    DrawHorizontalRadioButton(SMN_ST_SwiftcastPhase, "Flexible (SpS) Option",
                        "Swiftcasts the first available Egi when Swiftcast is ready.", 3);
                    break;

                case Preset.SMN_ST_Advanced_Combo_Lucid:
                    DrawSliderInt(4000, 9500, SMN_ST_Lucid, "设置魔力值阈值，当魔力值达到或低于此值时此功能生效。", 150,
                        SliderIncrements.Hundreds);
                    break;

                case Preset.SMN_ST_Advanced_Combo_Egi_AstralFlow:
                    DrawHorizontalMultiChoice(SMN_ST_Egi_AstralFlow, "Add Mountain Buster", "", 4, 0);
                    DrawHorizontalMultiChoice(SMN_ST_Egi_AstralFlow, "Add Crimson Cyclone", "", 4, 1);
                    DrawHorizontalMultiChoice(SMN_ST_Egi_AstralFlow, "Add Crimson Strike", "", 4, 3);
                    DrawHorizontalMultiChoice(SMN_ST_Egi_AstralFlow, "Add Slipstream", "", 4, 2);

                    if (SMN_ST_Egi_AstralFlow[1])
                    {
                        DrawSliderInt(0, 25, SMN_ST_CrimsonCycloneMeleeDistance, " Maximum range to use Crimson Cyclone.");
                    }
                    break;
                #endregion

                #region AoE
                case Preset.SMN_AoE_Advanced_Combo_Titan:
                    DrawPriorityInput(SMN_AoE_Egi_Priority, 3, 0,
                        $"{SummonTopaz.ActionName()} Priority: ");
                    break;

                case Preset.SMN_AoE_Advanced_Combo_Garuda:
                    DrawPriorityInput(SMN_AoE_Egi_Priority, 3, 1,
                        $"{SummonEmerald.ActionName()} Priority: ");
                    break;

                case Preset.SMN_AoE_Advanced_Combo_Ifrit:
                    DrawPriorityInput(SMN_AoE_Egi_Priority, 3, 2,
                        $"{SummonRuby.ActionName()} Priority: ");
                    break;

                case Preset.SMN_AoE_Advanced_Combo_DemiEgiMenu_SwiftcastEgi:
                    DrawHorizontalRadioButton(SMN_AoE_SwiftcastPhase, "Garuda", "Swiftcasts Slipstream", 1);
                    DrawHorizontalRadioButton(SMN_AoE_SwiftcastPhase, "Ifrit", "Swiftcasts Ruby Ruin/Ruby Rite", 2);
                    DrawHorizontalRadioButton(SMN_AoE_SwiftcastPhase, "Flexible (SpS) Option",
                        "Swiftcasts the first available Egi when Swiftcast is ready.", 3);
                    break;

                case Preset.SMN_AoE_Advanced_Combo_Lucid:
                    DrawSliderInt(4000, 9500, SMN_AoE_Lucid, "Set value for your MP to be at or under for this feature to take effect.", 150,
                        SliderIncrements.Hundreds);
                    break;

                case Preset.SMN_AoE_Advanced_Combo_Egi_AstralFlow:
                    DrawHorizontalMultiChoice(SMN_AoE_Egi_AstralFlow, "Add Mountain Buster", "", 4, 0);
                    DrawHorizontalMultiChoice(SMN_AoE_Egi_AstralFlow, "Add Crimson Cyclone", "", 4, 1);
                    DrawHorizontalMultiChoice(SMN_AoE_Egi_AstralFlow, "Add Crimson Strike", "", 4, 3);
                    DrawHorizontalMultiChoice(SMN_AoE_Egi_AstralFlow, "Add Slipstream", "", 4, 2);

                    if (SMN_AoE_Egi_AstralFlow[1])
                    {
                        DrawSliderInt(0, 25, SMN_AoE_CrimsonCycloneMeleeDistance, " Maximum range to use Crimson Cyclone.");
                    }
                    break;
                    #endregion

                #region Standalones
                #endregion
            }
        }
    }
}
