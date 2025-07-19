using Dalamud.Interface.Colors;
using ImGuiNET;
using WrathCombo.CustomComboNS.Functions;
using static WrathCombo.Window.Functions.UserConfig;

namespace WrathCombo.Combos.PvE;

internal partial class BRD
{
    internal static class Config
    {
        public static UserInt
            BRD_RagingJawsRenewTime = new("ragingJawsRenewTime"),            
            BRD_STSecondWindThreshold = new("BRD_STSecondWindThreshold"),
            BRD_AoESecondWindThreshold = new("BRD_AoESecondWindThreshold"),
            BRD_VariantCure = new("BRD_VariantCure"),
            BRD_Adv_Opener_Selection = new("BRD_Adv_Opener_Selection", 0),
            BRD_Balance_Content = new("BRD_Balance_Content", 1),
            BRD_Adv_DoT_Threshold = new("BRD_Adv_DoT_Threshold", 1),
            BRD_Adv_DoT_SubOption = new("BRD_Adv_DoT_SubOption", 1),
            BRD_Adv_Buffs_Threshold = new ("BRD_Adv_Buffs_Threshold", 1),
            BRD_Adv_Buffs_SubOption = new ("BRD_Adv_Buffs_SubOption", 1),
            BRD_AoE_Adv_Buffs_Threshold = new("BRD_AoE_Adv_Buffs_Threshold", 1),
            BRD_AoE_Adv_Buffs_SubOption = new("BRD_AoE_Adv_Buffs_SubOption", 1);

        internal static void Draw(CustomComboPreset preset)
        {
            switch (preset)
            {
                case CustomComboPreset.BRD_ST_Adv_Balance_Standard:
                    DrawRadioButton(BRD_Adv_Opener_Selection, "标准起手", "", 0);
                    DrawRadioButton(BRD_Adv_Opener_Selection, "2.48调整标准起手", "", 1);
                    DrawRadioButton(BRD_Adv_Opener_Selection, "2.49舒适标准起手", "", 2);

                    ImGui.Indent();
                    DrawBossOnlyChoice(BRD_Balance_Content);
                    ImGui.Unindent();
                    break;

                case CustomComboPreset.BRD_Adv_RagingJaws:
                    DrawSliderInt(3, 10, BRD_RagingJawsRenewTime,
                        "剩余时间（秒）。推荐5秒，如在光明神窗口外刷新可适当增加");

                    break;

                case CustomComboPreset.BRD_Adv_DoT:

                    DrawSliderInt(0, 100, BRD_Adv_DoT_Threshold,
                        $"目标HP低于该百分比时停止使用持续伤害技能（0% = 总是使用，100% = 从不使用）。");

                    ImGui.Indent();

                    ImGui.TextColored(ImGuiColors.DalamudYellow, "选择HP检查可应用于哪种类型的敌人：");

                    DrawHorizontalRadioButton(BRD_Adv_DoT_SubOption,
                        "仅非Boss敌人", $"仅对非Boss敌人应用HP检查", 0);

                    DrawHorizontalRadioButton(BRD_Adv_DoT_SubOption,
                        "全部内容", $"对所有内容应用HP检查", 1);

                    ImGui.Unindent();

                    break;

                case CustomComboPreset.BRD_Adv_Buffs:

                    DrawSliderInt(0, 100, BRD_Adv_Buffs_Threshold,
                       $"目标HP低于该百分比时停止使用增益（0% = 总是使用，100% = 从不使用）。");

                    ImGui.Indent();

                    ImGui.TextColored(ImGuiColors.DalamudYellow, "选择HP检查可应用于哪种类型的敌人：");

                    DrawHorizontalRadioButton(BRD_Adv_Buffs_SubOption,
                        "仅非Boss敌人", $"仅对非Boss敌人应用HP检查", 0);

                    DrawHorizontalRadioButton(BRD_Adv_Buffs_SubOption,
                        "全部内容", $"对所有内容应用HP检查", 1);

                    ImGui.Unindent();

                    break;

                case CustomComboPreset.BRD_AoE_Adv_Buffs:

                    DrawSliderInt(0, 100, BRD_AoE_Adv_Buffs_Threshold,
                        $"目标HP低于该百分比时停止使用增益（0% = 总是使用，100% = 从不使用）。");

                    ImGui.Indent();

                    ImGui.TextColored(ImGuiColors.DalamudYellow, "选择HP检查可应用于哪种类型的敌人：");

                    DrawHorizontalRadioButton(BRD_AoE_Adv_Buffs_SubOption,
                        "仅非Boss敌人", $"仅对非Boss敌人应用HP检查", 0);

                    DrawHorizontalRadioButton(BRD_AoE_Adv_Buffs_SubOption,
                        "全部内容", $"对所有内容应用HP检查", 1);

                    ImGui.Unindent();

                    break;

                case CustomComboPreset.BRD_ST_SecondWind:
                    DrawSliderInt(0, 100, BRD_STSecondWindThreshold,
                        "低于该HP百分比时使用内丹。");

                    break;

                case CustomComboPreset.BRD_AoE_SecondWind:
                    DrawSliderInt(0, 100, BRD_AoESecondWindThreshold,
                        "低于该HP百分比时使用内丹。");

                    break;

                case CustomComboPreset.BRD_Variant_Cure:
                    DrawSliderInt(1, 100, BRD_VariantCure, "HP%小于等于该值时使用", 200);

                    break;
            }
        }
    }
}
