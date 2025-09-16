using Dalamud.Interface.Colors;
using ECommons.ImGuiMethods;
using WrathCombo.CustomComboNS.Functions;
using WrathCombo.Window.Functions;
namespace WrathCombo.Combos.PvE;

internal partial class All
{
    internal static class Config
    {
        public static readonly UserInt ALL_Tank_Reprisal_Threshold =
            new("ALL_Tank_Reprisal_Threshold");
        
        public static readonly UserBoolArray ALL_Healer_RescueRetargetingOptions = new("ALL_Healer_RescueRetargetingOptions");
            

        internal static void Draw(Preset preset)
        {
            switch (preset)
            {
                case Preset.ALL_Tank_Reprisal:
                    UserConfig.DrawSliderInt(0, 9, ALL_Tank_Reprisal_Threshold,
                        "允许其他人雪仇剩余时间\n(0=目标上不能有雪仇效果)");
                    break;
                
                case Preset.ALL_Healer_RescueRetargeting:
                    ImGui.Indent();
                    ImGuiEx.TextWrapped(ImGuiColors.DalamudYellow,"UI鼠标悬停 > 场景鼠标悬停 > 焦点目标 > 软目标 > 硬目标");
                    ImGui.Unindent();
                    UserConfig.DrawHorizontalMultiChoice(ALL_Healer_RescueRetargetingOptions,"场景鼠标悬停", "将场景鼠标悬停添加到优先级集合", 3, 0);
                    UserConfig.DrawHorizontalMultiChoice(ALL_Healer_RescueRetargetingOptions,"焦点目标", "将焦点目标添加到优先级集合", 3, 1);
                    UserConfig.DrawHorizontalMultiChoice(ALL_Healer_RescueRetargetingOptions,"软目标", "将软目标添加到优先级集合", 3, 2);
                    break;
            }
        }
    }
}
