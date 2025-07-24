using Dalamud.Interface.Colors;
using ImGuiNET;
using WrathCombo.CustomComboNS.Functions;
using WrathCombo.Extensions;
using static WrathCombo.Window.Functions.UserConfig;
namespace WrathCombo.Combos.PvE;

internal partial class BLM
{
    internal static class Config
    {
        internal static void Draw(CustomComboPreset preset)
        {
            switch (preset)
            {
                case CustomComboPreset.BLM_ST_Opener:
                    DrawHorizontalRadioButton(BLM_SelectedOpener,
                        "标准起手", "使用标准起手",
                        0);

                    DrawHorizontalRadioButton(BLM_SelectedOpener,
                        $"{Flare.ActionName()}起手", $"使用{Flare.ActionName()}起手",
                        1);

                    DrawBossOnlyChoice(BLM_Balance_Content);
                    break;

                case CustomComboPreset.BLM_ST_LeyLines:
                    DrawSliderInt(0, 1, BLM_ST_LeyLinesCharges,
                        $"保留{LeyLines.ActionName()}的充能数");
                    break;

                case CustomComboPreset.BLM_ST_Movement:
                    DrawHorizontalMultiChoice(BLM_ST_MovementOption,
                        $"使用{Triplecast.ActionName()}", "", 4, 0);

                    DrawPriorityInput(BLM_ST_Movement_Priority,
                        4, 0, $"{Triplecast.ActionName()}优先级：");

                    DrawHorizontalMultiChoice(BLM_ST_MovementOption,
                        $"使用{Paradox.ActionName()}", "", 4, 1);

                    DrawPriorityInput(BLM_ST_Movement_Priority,
                        4, 1, $"{Paradox.ActionName()}优先级：");

                    DrawHorizontalMultiChoice(BLM_ST_MovementOption,
                        $"使用{Role.Swiftcast.ActionName()}", "", 4, 2);

                    DrawPriorityInput(BLM_ST_Movement_Priority,
                        4, 2, $"{Role.Swiftcast.ActionName()}优先级：");

                    DrawHorizontalMultiChoice(BLM_ST_MovementOption,
                        $"使用{Foul.ActionName()} / {Xenoglossy.ActionName()}", "", 4, 3);

                    DrawPriorityInput(BLM_ST_Movement_Priority,
                        4, 3, $"{Xenoglossy.ActionName()}优先级：");
                    break;

                case CustomComboPreset.BLM_ST_UsePolyglot:
                    if (DrawSliderInt(0, 3, BLM_ST_Polyglot_Save,
                        "手动保留异言充能数"))
                        if (BLM_ST_Polyglot_Movement > 3 - BLM_ST_Polyglot_Save)
                            BLM_ST_Polyglot_Movement.Value = 3 - BLM_ST_Polyglot_Save;

                    if (DrawSliderInt(0, 3, BLM_ST_Polyglot_Movement,
                        "为移动保留异言充能数"))
                        if (BLM_ST_Polyglot_Save > 3 - BLM_ST_Polyglot_Movement)
                            BLM_ST_Polyglot_Save.Value = 3 - BLM_ST_Polyglot_Movement;
                    break;

                case CustomComboPreset.BLM_ST_Triplecast:
                    DrawHorizontalRadioButton(BLM_ST_Triplecast_SubOption,
                        "总是使用", "始终使用三连咏唱", 0);

                    DrawHorizontalRadioButton(BLM_ST_Triplecast_SubOption,
                        "黑魔纹时不使用", "处于黑魔纹效果下时不使用三连咏唱。\n推荐此选项。", 1);

                    if (BLM_ST_MovementOption[0])
                        DrawSliderInt(1, 2, BLM_ST_Triplecast_Movement,
                            "为移动保留三连咏唱充能数");
                    break;


                case CustomComboPreset.BLM_ST_Thunder:

                    DrawSliderInt(0, 50, BLM_ST_ThunderOption,
                        "敌人HP低于此百分比时停止使用。设为0禁用此检查。");

                    ImGui.Indent();

                    ImGui.TextColored(ImGuiColors.DalamudYellow,
                        "请选择HP检测应应用于哪些类型的敌人：");

                    DrawHorizontalRadioButton(BLM_ST_Thunder_SubOption,
                        "非Boss", "仅对非Boss敌人应用上述HP检测。\n只在不是Boss时提前停止DoT。", 0);

                    DrawHorizontalRadioButton(BLM_ST_Thunder_SubOption,
                        "全部敌人", "对所有敌人应用上述HP检测。", 1);

                    DrawSliderInt(0, 5, BLM_ST_ThunderUptime_Threshold,
                        "剩余多少秒应用DoT。设置为零禁用此检测。");

                    ImGui.Unindent();
                    break;

                case CustomComboPreset.BLM_ST_Manaward:
                    DrawSliderInt(0, 100, BLM_ST_Manaward_Threshold,
                        $"{Manaward.ActionName()}触发HP百分比阈值");
                    break;

                case CustomComboPreset.BLM_AoE_LeyLines:
                    DrawSliderInt(0, 1, BLM_AoE_LeyLinesCharges,
                        $"保留{LeyLines.ActionName()}的充能数（0为全部使用）");
                    break;

                case CustomComboPreset.BLM_AoE_Triplecast:
                    DrawSliderInt(0, 1, BLM_AoE_Triplecast_HoldCharges,
                        $"保留{Triplecast.ActionName()}的充能数（0为全部使用）");
                    break;

                case CustomComboPreset.BLM_AoE_Thunder:
                    DrawSliderInt(0, 50, BLM_AoE_ThunderHP,
                        $"目标HP低于此百分比时停止使用{Thunder2.ActionName()}（设为0禁用此检查）");
                    break;

                case CustomComboPreset.BLM_Variant_Cure:
                    DrawSliderInt(1, 100, BLM_VariantCure,
                        "HP%低于或等于此值时使用", 200);
                    break;

                case CustomComboPreset.BLM_Blizzard1to3:
                    DrawRadioButton(BLM_B1to3,
                        $"替换{Blizzard.ActionName()}", $"在未处于灵极冰3层时将{Blizzard.ActionName()}替换为{Blizzard3.ActionName()}", 0);

                    DrawRadioButton(BLM_B1to3,
                        $"替换{Blizzard3.ActionName()}", $"在灵极冰3层时将{Blizzard3.ActionName()}替换为{Blizzard.ActionName()}", 1);
                    break;

                case CustomComboPreset.BLM_Fire1to3:
                    DrawRadioButton(BLM_F1to3,
                        $"替换{Fire.ActionName()}", $"在未处于星极火3层或未战斗时将{Fire.ActionName()}替换为{Fire3.ActionName()}", 0);

                    DrawRadioButton(BLM_F1to3,
                        $"替换{Fire3.ActionName()}", $"在星极火3层时将{Fire3.ActionName()}替换为{Fire.ActionName()}", 1);
                    break;
            }
        }

        #region Variables

        public static UserInt
            BLM_SelectedOpener = new("BLM_SelectedOpener", 0),
            BLM_Balance_Content = new("BLM_Balance_Content", 1),
            BLM_ST_LeyLinesCharges = new("BLM_ST_LeyLinesCharges", 1),
            BLM_ST_ThunderOption = new("BLM_ST_ThunderOption", 10),
            BLM_ST_Thunder_SubOption = new("BLM_ST_Thunder_SubOption", 0),
            BLM_ST_Triplecast_SubOption = new("BLM_ST_Triplecast_SubOption", 1),
            BLM_ST_ThunderUptime_Threshold = new("BLM_ST_ThunderUptime_Threshold", 5),
            BLM_ST_Triplecast_Movement = new("BLM_ST_Triplecast_Movement", 1),
            BLM_ST_Polyglot_Movement = new("BLM_ST_Polyglot_Movement", 1),
            BLM_ST_Polyglot_Save = new("BLM_ST_Polyglot_Save", 0),
            BLM_ST_Manaward_Threshold = new("BLM_ST_Manaward_Threshold", 40),
            BLM_AoE_Triplecast_HoldCharges = new("BLM_AoE_Triplecast_HoldCharges", 0),
            BLM_AoE_LeyLinesCharges = new("BLM_AoE_LeyLinesCharges", 1),
            BLM_AoE_ThunderHP = new("BLM_AoE_ThunderHP", 20),
            BLM_VariantCure = new("BLM_VariantCure", 50),
            BLM_B1to3 = new("BLM_B1to3", 0),
            BLM_F1to3 = new("BLM_F1to3", 0);

        public static UserBoolArray
            BLM_ST_MovementOption = new("BLM_ST_MovementOption");

        public static UserIntArray
            BLM_ST_Movement_Priority = new("BLM_ST_Movement_Priority");

        #endregion
    }
}
