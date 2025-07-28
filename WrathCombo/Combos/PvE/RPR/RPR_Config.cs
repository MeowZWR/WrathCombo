using ImGuiNET;
using WrathCombo.CustomComboNS.Functions;
using WrathCombo.Extensions;
using static WrathCombo.Window.Functions.UserConfig;
namespace WrathCombo.Combos.PvE;

internal partial class RPR
{
    internal static class Config
    {
        internal static void Draw(CustomComboPreset preset)
        {
            switch (preset)
            {
                case CustomComboPreset.RPR_ST_Opener:

                    if (DrawHorizontalRadioButton(RPR_Opener_StartChoice,
                        "标准起手", $"使用{Harpe.ActionName()}开始起手", 0))
                    {
                        if (!CustomComboFunctions.InCombat())
                            Opener().OpenerStep = 1;
                    }

                    DrawHorizontalRadioButton(RPR_Opener_StartChoice,
                        "提前起手", $"使用{ShadowOfDeath.ActionName()}开始起手，跳过{Harpe.ActionName()}", 1);

                    ImGui.Spacing();

                    DrawBossOnlyChoice(RPR_Balance_Content);
                    break;

                case CustomComboPreset.RPR_ST_ArcaneCircle:
                    DrawHorizontalRadioButton(RPR_ST_ArcaneCircle_SubOption,
                        "所有内容", $"无论内容如何都使用{ArcaneCircle.ActionName()}", 0);

                    DrawHorizontalRadioButton(RPR_ST_ArcaneCircle_SubOption,
                        "仅Boss战", $"仅在Boss战中使用{ArcaneCircle.ActionName()}", 1);
                    break;

                case CustomComboPreset.RPR_ST_AdvancedMode:
                    DrawHorizontalRadioButton(RPR_Positional, "背面优先",
                        $"第一个位置技：{Gallows.ActionName()}", 0);

                    DrawHorizontalRadioButton(RPR_Positional, "侧面优先",
                        $"第一个位置技：{Gibbet.ActionName()}", 1);
                    break;

                case CustomComboPreset.RPR_ST_SoD:
                    DrawSliderInt(0, 10, RPR_SoDRefreshRange,
                        $"续{ShadowOfDeath.ActionName()}前剩余秒数。\n推荐值为6。");

                    DrawSliderInt(0, 100, RPR_SoDThreshold,
                        $"设置血量百分比阈值，当目标血量低于此值时不会自动施放{ShadowOfDeath.ActionName()}");
                    break;

                case CustomComboPreset.RPR_ST_TrueNorthDynamic:
                    DrawAdditionalBoolChoice(RPR_ST_TrueNorthDynamic_HoldCharge,
                        "为暴食保留真北", "为暴食保留最后一层真北，即使绞决/缢杀位置不正确时也会保留");
                    break;

                case CustomComboPreset.RPR_ST_RangedFiller:
                    DrawAdditionalBoolChoice(RPR_ST_RangedFillerHarvestMoon,
                        "添加收获月", "在近战范围外时添加收获月（如果可用）。不会覆盖团契");
                    break;

                case CustomComboPreset.RPR_AoE_WoD:
                    DrawSliderInt(0, 100, RPR_WoDThreshold,
                        $"设置血量百分比阈值，当目标血量低于此值时不会自动施放{WhorlOfDeath.ActionName()}");
                    break;

                case CustomComboPreset.RPR_ST_ComboHeals:
                    DrawSliderInt(0, 100, RPR_STSecondWindThreshold,
                        $"{Role.SecondWind.ActionName()}血量百分比阈值");

                    DrawSliderInt(0, 100, RPR_STBloodbathThreshold,
                        $"{Role.Bloodbath.ActionName()}血量百分比阈值");
                    break;

                case CustomComboPreset.RPR_AoE_ComboHeals:
                    DrawSliderInt(0, 100, RPR_AoESecondWindThreshold,
                        $"{Role.SecondWind.ActionName()}血量百分比阈值");

                    DrawSliderInt(0, 100, RPR_AoEBloodbathThreshold,
                        $"{Role.Bloodbath.ActionName()}血量百分比阈值");
                    break;

                case CustomComboPreset.RPR_Soulsow:
                    DrawHorizontalMultiChoice(RPR_SoulsowOptions,
                        $"{Harpe.ActionName()}", $"将{Soulsow.ActionName()}添加到{Harpe.ActionName()}",
                        5, 0);

                    DrawHorizontalMultiChoice(RPR_SoulsowOptions,
                        $"{Slice.ActionName()}", $"将{Soulsow.ActionName()}添加到{Slice.ActionName()}",
                        5, 1);

                    DrawHorizontalMultiChoice(RPR_SoulsowOptions,
                        $"{SpinningScythe.ActionName()}", $"将{Soulsow.ActionName()}添加到{SpinningScythe.ActionName()}", 5, 2);

                    DrawHorizontalMultiChoice(RPR_SoulsowOptions,
                        $"{ShadowOfDeath.ActionName()}", $"将{Soulsow.ActionName()}添加到{ShadowOfDeath.ActionName()}", 5, 3);

                    DrawHorizontalMultiChoice(RPR_SoulsowOptions,
                        $"{BloodStalk.ActionName()}", $"将{Soulsow.ActionName()}添加到{BloodStalk.ActionName()}", 5, 4);
                    break;

                case CustomComboPreset.RPR_Variant_Cure:
                    DrawSliderInt(1, 100, RPR_VariantCure,
                        "血量百分比达到或低于此值", 200);
                    break;
            }
        }

        #region Variables

        public static UserInt
            RPR_Positional = new("RPR_Positional", 0),
            RPR_Opener_StartChoice = new("RPR_Opener_StartChoice", 0),
            RPR_Balance_Content = new("RPR_Balance_Content", 1),
            RPR_SoDRefreshRange = new("RPR_SoDRefreshRange", 6),
            RPR_SoDThreshold = new("RPR_SoDThreshold", 0),
            RPR_ST_ArcaneCircle_SubOption = new("RPR_ST_ArcaneCircle_SubOption", 1),
            RPR_STSecondWindThreshold = new("RPR_STSecondWindThreshold", 40),
            RPR_STBloodbathThreshold = new("RPR_STBloodbathThreshold", 30),
            RPR_WoDThreshold = new("RPR_WoDThreshold", 20),
            RPR_AoESecondWindThreshold = new("RPR_AoESecondWindThreshold", 40),
            RPR_AoEBloodbathThreshold = new("RPR_AoEBloodbathThreshold", 30),
            RPR_VariantCure = new("RPRVariantCure", 50);

        public static UserBool
            RPR_ST_TrueNorthDynamic_HoldCharge = new("RPR_ST_TrueNorthDynamic_HoldCharge"),
            RPR_ST_RangedFillerHarvestMoon = new("RPR_ST_RangedFillerHarvestMoon");

        public static UserBoolArray
            RPR_SoulsowOptions = new("RPR_SoulsowOptions");

        #endregion
    }
}
