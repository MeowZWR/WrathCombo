using Dalamud.Interface.Colors;
using WrathCombo.CustomComboNS.Functions;
using WrathCombo.Extensions;
using static WrathCombo.Window.Functions.UserConfig;
namespace WrathCombo.Combos.PvE;

internal partial class DRG
{
    internal static class Config
    {
        internal static void Draw(Preset preset)
        {
            switch (preset)
            {
                case Preset.DRG_ST_Opener:
                    DrawHorizontalRadioButton(DRG_SelectedOpener,
                        "标准起手", "使用标准起手",
                        0);

                    DrawHorizontalRadioButton(DRG_SelectedOpener,
                        $"{PiercingTalon.ActionName()}起手", $"使用{PiercingTalon.ActionName()}起手",
                        1);

                    ImGui.NewLine();
                    DrawBossOnlyChoice(DRG_Balance_Content);
                    break;

                case Preset.DRG_ST_BattleLitany:

                    DrawSliderInt(0, 50, DRG_ST_BattleLitanyHPOption,
                        "Stop using at Enemy HP %. Set to Zero to disable this check.");

                    ImGui.Indent();
                    ImGui.TextColored(ImGuiColors.DalamudYellow,
                        "选择需要进行HP检查的敌人类型：");

                    DrawHorizontalRadioButton(DRG_ST_BattleLitanyBossOption,
                        "Non-Bosses", "Only applies the HP check above to non-bosses.", 0);

                    DrawHorizontalRadioButton(DRG_ST_BattleLitanyBossOption,
                        "All Enemies", "Applies the HP check above to all enemies.", 1);

                    ImGui.Unindent();
                    break;

                case Preset.DRG_ST_LanceCharge:

                    DrawSliderInt(0, 50, DRG_ST_LanceChargeHPOption,
                        "Stop using at Enemy HP %. Set to Zero to disable this check.");

                    ImGui.Indent();
                    ImGui.TextColored(ImGuiColors.DalamudYellow,
                        "Select what kind of enemies the HP check should be applied to:");

                    DrawHorizontalRadioButton(DRG_ST_LanceChargeBossOption,
                        "Non-Bosses", "Only applies the HP check above to non-bosses.", 0);

                    DrawHorizontalRadioButton(DRG_ST_LanceChargeBossOption,
                        "All Enemies", "Applies the HP check above to all enemies.", 1);

                    ImGui.Unindent();
                    break;

                case Preset.DRG_ST_HighJump:
                    DrawHorizontalMultiChoice(DRG_ST_JumpMovingOptions,
                        "不移动时", $"仅在不移动时使用{Jump.ActionName()}", 2, 0);

                    DrawHorizontalMultiChoice(DRG_ST_JumpMovingOptions,
                        "近战范围内", $"仅在近战范围内使用{Jump.ActionName()}", 2, 1);
                    break;

                case Preset.DRG_ST_Mirage:
                    DrawAdditionalBoolChoice(DRG_ST_DoubleMirage,
                        "红莲龙血期间爆发幻象冲", "在红莲龙血效果下将幻象冲添加到循环中。\n最佳效果为2.50 GCD。");
                    break;

                case Preset.DRG_ST_Geirskogul:
                    DrawSliderInt(0, 100, DRG_ST_GeirskogulBossOption,
                        "Bosses Only. Stop using at Enemy HP %.");

                    DrawSliderInt(0, 100, DRG_ST_GeirskogulBossAddsOption,
                        "Boss Encounter Non Bosses. Stop using at Enemy HP %.");

                    DrawSliderInt(0, 100, DRG_ST_GeirskogulTrashOption,
                        "Non boss encounter. Stop using at Enemy HP %.");
                    break;

                case Preset.DRG_ST_DragonfireDive:
                    DrawHorizontalMultiChoice(DRG_ST_DragonfireDiveMovingOptions,
                        "不移动时", $"仅在不移动时使用{DragonfireDive.ActionName()}", 2, 0);

                    DrawHorizontalMultiChoice(DRG_ST_DragonfireDiveMovingOptions,
                        "近战范围内", $"仅在近战范围内使用{DragonfireDive.ActionName()}", 2, 1);
                    break;

                case Preset.DRG_ST_Stardiver:
                    DrawHorizontalMultiChoice(DRG_ST_StardiverMovingOptions,
                        "不移动时", $"仅在不移动时使用{Stardiver.ActionName()}", 2, 0);

                    DrawHorizontalMultiChoice(DRG_ST_StardiverMovingOptions,
                        "近战范围内", $"仅在近战范围内使用{Stardiver.ActionName()}", 2, 1);
                    break;

                case Preset.DRG_TrueNorthDynamic:
                    DrawSliderInt(0, 1, DRG_ManualTN,
                        "How many charges to keep for manual usage.");
                    break;

                case Preset.DRG_ST_ComboHeals:
                    DrawSliderInt(0, 100, DRG_ST_SecondWindHPThreshold,
                        $"{Role.SecondWind.ActionName()}血量百分比阈值");

                    DrawSliderInt(0, 100, DRG_ST_BloodbathHPThreshold,
                        $"{Role.Bloodbath.ActionName()}血量百分比阈值");
                    break;

                case Preset.DRG_AoE_BattleLitany:
                    DrawSliderInt(0, 100, DRG_AoE_BattleLitanyHPTreshold,
                        "Stop using when target HP% is at or below (Set to 0 to Disable This Check)");
                    break;

                case Preset.DRG_AoE_LanceCharge:
                    DrawSliderInt(0, 100, DRG_AoE_LanceChargeHPTreshold,
                        "Stop using when target HP% is at or below (Set to 0 to Disable This Check)");
                    break;

                case Preset.DRG_AoE_HighJump:
                    DrawHorizontalMultiChoice(DRG_AoE_JumpMovingOptions,
                        "不移动时", $"仅在不移动时使用{Jump.ActionName()}", 2, 0);

                    DrawHorizontalMultiChoice(DRG_AoE_JumpMovingOptions,
                        "近战范围内", $"仅在近战范围内使用{Jump.ActionName()}", 2, 1);
                    break;

                case Preset.DRG_AoE_DragonfireDive:
                    DrawHorizontalMultiChoice(DRG_AoE_DragonfireDiveMovingOptions,
                        "不移动时", $"仅在不移动时使用{DragonfireDive.ActionName()}", 2, 0);

                    DrawHorizontalMultiChoice(DRG_AoE_DragonfireDiveMovingOptions,
                        "近战范围内", $"仅在近战范围内使用{DragonfireDive.ActionName()}", 2, 1);
                    break;

                case Preset.DRG_AoE_Stardiver:
                    DrawHorizontalMultiChoice(DRG_AoE_StardiverMovingOptions,
                        "不移动时", $"仅在不移动时使用{Stardiver.ActionName()}", 2, 0);

                    DrawHorizontalMultiChoice(DRG_AoE_StardiverMovingOptions,
                        "近战范围内", $"仅在近战范围内使用{Stardiver.ActionName()}", 2, 1);
                    break;

                case Preset.DRG_AoE_ComboHeals:
                    DrawSliderInt(0, 100, DRG_AoE_SecondWindHPThreshold,
                        $"{Role.SecondWind.ActionName()}血量百分比阈值");

                    DrawSliderInt(0, 100, DRG_AoE_BloodbathHPThreshold,
                        $"{Role.Bloodbath.ActionName()}血量百分比阈值");
                    break;

                case Preset.DRG_HeavensThrust:
                    DrawAdditionalBoolChoice(DRG_Heavens_Basic,
                        "添加樱花连击", "当适用时添加樱花连击。");
                    break;
            }
        }

        #region Variables

        public static UserInt
            DRG_SelectedOpener = new("DRG_SelectedOpener"),
            DRG_Balance_Content = new("DRG_Balance_Content", 1),
            DRG_ST_BattleLitanyHPOption = new("DRG_ST_BattleLitanyHPOption", 25),
            DRG_ST_BattleLitanyBossOption = new("DRG_ST_BattleLitanyBossOption"),
            DRG_ST_LanceChargeHPOption = new("DRG_ST_LanceChargeHPOption", 25),
            DRG_ST_LanceChargeBossOption = new("DRG_ST_LanceChargeBossOption"),
            DRG_ST_GeirskogulBossOption = new("DRG_ST_GeirskogulBossOption"),
            DRG_ST_GeirskogulBossAddsOption = new("DRG_ST_GeirskogulBossAddsOption", 10),
            DRG_ST_GeirskogulTrashOption = new("DRG_ST_GeirskogulTrashOption", 25),
            DRG_ManualTN = new("DRG_ManualTN"),
            DRG_ST_SecondWindHPThreshold = new("DRG_STSecondWindThreshold", 40),
            DRG_ST_BloodbathHPThreshold = new("DRG_STBloodbathThreshold", 30),
            DRG_AoE_BattleLitanyHPTreshold = new("DRG_AoE_BattleLitanyHPTreshold", 25),
            DRG_AoE_LanceChargeHPTreshold = new("DRG_AoE_LanceChargeHPTreshold", 25),
            DRG_AoE_SecondWindHPThreshold = new("DRG_AoE_SecondWindThreshold", 40),
            DRG_AoE_BloodbathHPThreshold = new("DRG_AoE_BloodbathThreshold", 30);

        public static UserBool
            DRG_ST_DoubleMirage = new("DRG_ST_DoubleMirage"),
            DRG_Heavens_Basic = new("DRG_Heavens_Basic");

        public static UserBoolArray
            DRG_ST_JumpMovingOptions = new("DRG_ST_Jump_Options"),
            DRG_ST_DragonfireDiveMovingOptions = new("DRG_ST_DragonfireDive_Options"),
            DRG_ST_StardiverMovingOptions = new("DRG_ST_Stardiver_Options"),
            DRG_AoE_JumpMovingOptions = new("DRG_AoE_Jump_Options"),
            DRG_AoE_DragonfireDiveMovingOptions = new("DRG_AoE_DragonfireDive_Options"),
            DRG_AoE_StardiverMovingOptions = new("DRG_AoE_Stardiver_Options");

        #endregion
    }
}
