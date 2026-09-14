using ECommons.ImGuiMethods;
using WrathCombo.CustomComboNS.Functions;
using WrathCombo.Extensions;
using WrathCombo.Window.Functions;
using WrathCombo.Resources.Localization.JobConfigs;
using static WrathCombo.Window.Functions.UserConfig;
using static WrathCombo.Window.Text;
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

        public static UserBool
            SMN_Opener_Potion = new("SMN_Opener_Potion"),
            SMN_Opener_PrepullBlock = new("SMN_Opener_PrepullBlock", true);

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
                    DrawHorizontalRadioButton(SMN_ST_Simple_Combo_Gapclose, SMN_Config.SafeModeNoGapclose, SMN_Config.SafeModeNoGapcloseDesc, 0);
                    DrawHorizontalRadioButton(SMN_ST_Simple_Combo_Gapclose, SMN_Config.StandardRotation, SMN_Config.StandardRotationDesc, 1 );
                    break;
                
                case Preset.SMN_AoE_Simple_Combo:
                    DrawHorizontalRadioButton(SMN_AoE_Simple_Combo_Gapclose, SMN_Config.SafeModeNoGapclose, SMN_Config.SafeModeNoGapcloseDesc, 0);
                    DrawHorizontalRadioButton(SMN_AoE_Simple_Combo_Gapclose, SMN_Config.StandardRotation, SMN_Config.StandardRotationDesc, 1 );
                    break;
                    
                case Preset.SMN_ST_Advanced_Combo:
                    DrawRadioButton(SMN_ST_Advanced_Combo_AltMode, SMN_Config.OnRuin123, "", 0);
                    DrawRadioButton(SMN_ST_Advanced_Combo_AltMode, SMN_Config.OnRuin12Only, SMN_Config.OnRuin12OnlyDesc, 1);
                    break;

                case Preset.SMN_ST_Advanced_Combo_Balance_Opener:
                    DrawBossOnlyChoice(SMN_Balance_Content);
                    DrawOpenerPotionChoice(SMN_Opener_Potion);
                    DrawOpenerPrepullBlockChoice(SMN_Opener_PrepullBlock);
                    ImGuiEx.TextUnderlined(SMN_Config.SwiftcastSettings);
                    ImGui.Spacing();
                    DrawRadioButton(SMN_Opener_SkipSwiftcast, SMN_Config.UseSwiftcast,
                        SMN_Config.UseSwiftcastDesc, 1, descriptionAsTooltip: true);
                    DrawRadioButton(SMN_Opener_SkipSwiftcast, SMN_Config.SkipSwiftcast,
                        SMN_Config.SkipSwiftcastDesc, 2, descriptionAsTooltip: true);
                    break;

                case Preset.SMN_ST_Advanced_Combo_Titan:
                    DrawPriorityInput(SMN_ST_Egi_Priority, 3, 0,
                        FormatAndCache(Generics.Action_Priority, SummonTopaz.ActionName()));
                    break;

                case Preset.SMN_ST_Advanced_Combo_Garuda:
                    DrawPriorityInput(SMN_ST_Egi_Priority, 3, 1,
                        FormatAndCache(Generics.Action_Priority, SummonEmerald.ActionName()));
                    break;

                case Preset.SMN_ST_Advanced_Combo_Ifrit:
                    DrawPriorityInput(SMN_ST_Egi_Priority, 3, 2,
                        FormatAndCache(Generics.Action_Priority, SummonRuby.ActionName()));
                    break;

                case Preset.SMN_ST_Advanced_Combo_DemiEgiMenu_SwiftcastEgi:
                    DrawHorizontalRadioButton(SMN_ST_SwiftcastPhase, SMN_Config.Garuda, SMN_Config.SwiftcastsSlipstream, 1);
                    DrawHorizontalRadioButton(SMN_ST_SwiftcastPhase, SMN_Config.Ifrit, SMN_Config.SwiftcastsRubyRuin, 2);
                    DrawHorizontalRadioButton(SMN_ST_SwiftcastPhase, SMN_Config.FlexibleSpsOption,
                        SMN_Config.FlexibleSpsOptionDesc, 3);
                    break;

                case Preset.SMN_ST_Advanced_Combo_Lucid:
                    DrawSliderInt(4000, 9500, SMN_ST_Lucid, Generics.LucidMP, 150,
                        SliderIncrements.Hundreds);
                    break;

                case Preset.SMN_ST_Advanced_Combo_Egi_AstralFlow:
                    DrawHorizontalMultiChoice(SMN_ST_Egi_AstralFlow, SMN_Config.AddMountainBuster, "", 4, 0);
                    DrawHorizontalMultiChoice(SMN_ST_Egi_AstralFlow, SMN_Config.AddCrimsonCyclone, "", 4, 1);
                    DrawHorizontalMultiChoice(SMN_ST_Egi_AstralFlow, SMN_Config.AddCrimsonStrike, "", 4, 3);
                    DrawHorizontalMultiChoice(SMN_ST_Egi_AstralFlow, SMN_Config.AddSlipstream, "", 4, 2);

                    if (SMN_ST_Egi_AstralFlow[1])
                    {
                        DrawSliderInt(0, 25, SMN_ST_CrimsonCycloneMeleeDistance, SMN_Config.MaxRangeCrimsonCyclone);
                    }
                    break;
                #endregion

                #region AoE
                case Preset.SMN_AoE_Advanced_Combo_Titan:
                    DrawPriorityInput(SMN_AoE_Egi_Priority, 3, 0,
                        FormatAndCache(Generics.Action_Priority, SummonTopaz.ActionName()));
                    break;

                case Preset.SMN_AoE_Advanced_Combo_Garuda:
                    DrawPriorityInput(SMN_AoE_Egi_Priority, 3, 1,
                        FormatAndCache(Generics.Action_Priority, SummonEmerald.ActionName()));
                    break;

                case Preset.SMN_AoE_Advanced_Combo_Ifrit:
                    DrawPriorityInput(SMN_AoE_Egi_Priority, 3, 2,
                        FormatAndCache(Generics.Action_Priority, SummonRuby.ActionName()));
                    break;

                case Preset.SMN_AoE_Advanced_Combo_DemiEgiMenu_SwiftcastEgi:
                    DrawHorizontalRadioButton(SMN_AoE_SwiftcastPhase, SMN_Config.Garuda, SMN_Config.SwiftcastsSlipstream, 1);
                    DrawHorizontalRadioButton(SMN_AoE_SwiftcastPhase, SMN_Config.Ifrit, SMN_Config.SwiftcastsRubyRuin, 2);
                    DrawHorizontalRadioButton(SMN_AoE_SwiftcastPhase, SMN_Config.FlexibleSpsOption,
                        SMN_Config.FlexibleSpsOptionDesc, 3);
                    break;

                case Preset.SMN_AoE_Advanced_Combo_Lucid:
                    DrawSliderInt(4000, 9500, SMN_AoE_Lucid, Generics.LucidMP, 150,
                        SliderIncrements.Hundreds);
                    break;

                case Preset.SMN_AoE_Advanced_Combo_Egi_AstralFlow:
                    DrawHorizontalMultiChoice(SMN_AoE_Egi_AstralFlow, SMN_Config.AddMountainBuster, "", 4, 0);
                    DrawHorizontalMultiChoice(SMN_AoE_Egi_AstralFlow, SMN_Config.AddCrimsonCyclone, "", 4, 1);
                    DrawHorizontalMultiChoice(SMN_AoE_Egi_AstralFlow, SMN_Config.AddCrimsonStrike, "", 4, 3);
                    DrawHorizontalMultiChoice(SMN_AoE_Egi_AstralFlow, SMN_Config.AddSlipstream, "", 4, 2);

                    if (SMN_AoE_Egi_AstralFlow[1])
                    {
                        DrawSliderInt(0, 25, SMN_AoE_CrimsonCycloneMeleeDistance, SMN_Config.MaxRangeCrimsonCyclone);
                    }
                    break;
                    #endregion

                #region Standalones
                #endregion
            }
        }
    }
}
