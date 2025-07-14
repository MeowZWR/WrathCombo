using WrathCombo.CustomComboNS.Functions;
using WrathCombo.Extensions;
using static WrathCombo.Window.Functions.UserConfig;
namespace WrathCombo.Combos.PvE;

internal partial class VPR
{
    internal static class Config
    {
        internal static void Draw(CustomComboPreset preset)
        {
            switch (preset)
            {
                case CustomComboPreset.VPR_ST_Opener:
                    DrawBossOnlyChoice(VPR_Balance_Content);

                    DrawAdditionalBoolChoice(VPR_Opener_ExcludeUF,
                        $"排除{UncoiledFury.ActionName()}", "");
                    break;

                case CustomComboPreset.VPR_ST_SerpentsIre:
                    DrawHorizontalRadioButton(VPR_ST_SerpentsIre_SubOption,
                        "全部内容", $"无论内容如何均使用{SerpentsIre.ActionName()}。", 0);

                    DrawHorizontalRadioButton(VPR_ST_SerpentsIre_SubOption,
                        "仅限Boss战", $"仅在Boss战中使用{SerpentsIre.ActionName()}。", 1);
                    break;

                case CustomComboPreset.VPR_ST_Reawaken:
                    DrawHorizontalRadioButton(VPR_ST_ReAwaken_SubOption,
                        "全部内容", $"无论内容如何均使用{Reawaken.ActionName()}。", 0);

                    DrawHorizontalRadioButton(VPR_ST_ReAwaken_SubOption,
                        "仅限Boss战", $"仅在Boss战中使用{Reawaken.ActionName()}。", 1);

                    DrawSliderInt(0, 5, VPR_ST_ReAwaken_Threshold,
                        $"设置HP百分比阈值，在可用时使用{Reawaken.ActionName()}。（仅限Boss战）");

                    break;

                case CustomComboPreset.VPR_ST_UncoiledFury:
                    DrawSliderInt(0, 3, VPR_ST_UncoiledFury_HoldCharges,
                        $"预留多少层{UncoiledFury.ActionName()}？（0 = 全部使用）");

                    DrawSliderInt(0, 5, VPR_ST_UncoiledFury_Threshold,
                        $"设置HP百分比阈值，低于该值时全部使用{UncoiledFury.ActionName()}。");
                    break;

                case CustomComboPreset.VPR_ST_RangedUptime:
                    DrawAdditionalBoolChoice(VPR_ST_RangedUptimeUncoiledFury,
                        $"Include {UncoiledFury.ActionName()}", "Adds Uncoiled Fury to the rotation when you are out of melee range and have Rattling Coil charges.");
                    break;

                case CustomComboPreset.VPR_ST_Vicewinder:
                    DrawAdditionalBoolChoice(VPR_TrueNortVicewinder,
                        $"{Role.TrueNorth.ActionName()} Option", "Adds True North when available.");
                    break;

                case CustomComboPreset.VPR_ST_ComboHeals:
                    DrawSliderInt(0, 100, VPR_ST_SecondWind_Threshold,
                        $"{Role.SecondWind.ActionName()}触发HP百分比阈值");

                    DrawSliderInt(0, 100, VPR_ST_Bloodbath_Threshold,
                        $"{Role.Bloodbath.ActionName()}触发HP百分比阈值");

                    break;

                case CustomComboPreset.VPR_AoE_UncoiledFury:
                    DrawSliderInt(0, 3, VPR_AoE_UncoiledFury_HoldCharges,
                        $"预留多少层{UncoiledFury.ActionName()}？（0 = 全部使用）");

                    DrawSliderInt(0, 5, VPR_AoE_UncoiledFury_Threshold,
                        $"设置HP百分比阈值，低于该值时全部使用{UncoiledFury.ActionName()}。");

                    break;

                case CustomComboPreset.VPR_AoE_Reawaken:
                    DrawHorizontalRadioButton(VPR_AoE_Reawaken_SubOption,
                        "In range", $"Adds range check for {Reawaken.ActionName()}, so it is used only when in range.", 0);

                    DrawHorizontalRadioButton(VPR_AoE_Reawaken_SubOption,
                        "Disable range check", $"Disables the range check for {Reawaken.ActionName()}, so it will be used even without a target selected.", 1);

                    DrawSliderInt(0, 100, VPR_AoE_Reawaken_Usage,
                        $"敌人HP高于该百分比时停止使用{Reawaken.ActionName()}。设为0则不检测。");
                    break;

                case CustomComboPreset.VPR_AoE_Vicepit:
                    DrawHorizontalRadioButton(VPR_AoE_Vicepit_SubOption,
                        "In range", $"Adds range check for {Vicepit.ActionName()}, so it is used only when in range.", 0);

                    DrawHorizontalRadioButton(VPR_AoE_Vicepit_SubOption,
                        "Disable range check", $"Disables the range check for {Vicepit.ActionName()}, so it will be used even without a target selected.", 1);
                    break;

                case CustomComboPreset.VPR_AoE_VicepitCombo:
                    DrawHorizontalRadioButton(VPR_AoE_VicepitCombo_SubOption,
                        "In range", $"Adds range check for {HuntersDen.ActionName()} and {SwiftskinsDen.ActionName()}, so it is used only when in range.", 0);

                    DrawHorizontalRadioButton(VPR_AoE_VicepitCombo_SubOption,
                        "Disable range check", $"Disables the range check for {HuntersDen.ActionName()} and {SwiftskinsDen.ActionName()}, so it will be used even without a target selected.", 1);
                    break;

                case CustomComboPreset.VPR_AoE_ComboHeals:
                    DrawSliderInt(0, 100, VPR_AoE_SecondWind_Threshold,
                        $"{Role.SecondWind.ActionName()}触发HP百分比阈值");

                    DrawSliderInt(0, 100, VPR_AoE_Bloodbath_Threshold,
                        $"{Role.Bloodbath.ActionName()}触发HP百分比阈值");

                    break;

                case CustomComboPreset.VPR_ReawakenLegacy:
                    DrawRadioButton(VPR_ReawakenLegacyButton,
                        $"替换为{Reawaken.ActionName()}", $"将{Reawaken.ActionName()}替换为完整祖灵之牙-祖灵之蛇连击。", 0);

                    DrawRadioButton(VPR_ReawakenLegacyButton,
                        $"替换为{ReavingFangs.ActionName()}", $"将{ReavingFangs.ActionName()}替换为完整祖灵之牙-祖灵之蛇连击。", 1);

                    break;

                case CustomComboPreset.VPR_Variant_Cure:
                    DrawSliderInt(1, 100, VPR_VariantCure,
                        "触发治疗的HP百分比阈值", 200);

                    break;
            }
        }

        #region Variables

        public static UserInt
            VPR_Balance_Content = new("VPR_Balance_Content", 1),
            VPR_ST_SerpentsIre_SubOption = new("VPR_ST_SerpentsIre_SubOption", 1),
            VPR_ST_UncoiledFury_HoldCharges = new("VPR_ST_UncoiledFury_HoldCharges", 1),
            VPR_ST_UncoiledFury_Threshold = new("VPR_ST_UncoiledFury_Threshold", 1),
            VPR_ST_ReAwaken_SubOption = new("VPR_ST_ReAwaken_SubOption", 0),
            VPR_ST_ReAwaken_Threshold = new("VPR_ST_ReAwaken_Threshold", 1),
            VPR_ST_SecondWind_Threshold = new("VPR_ST_SecondWindThreshold", 40),
            VPR_ST_Bloodbath_Threshold = new("VPR_ST_BloodbathThreshold", 30),
            VPR_AoE_UncoiledFury_Threshold = new("VPR_AoE_UncoiledFury_Threshold", 1),
            VPR_AoE_UncoiledFury_HoldCharges = new("VPR_AoE_UncoiledFury_HoldCharges", 0),
            VPR_AoE_Vicepit_SubOption = new("VPR_AoE_Vicepit_SubOption", 0),
            VPR_AoE_VicepitCombo_SubOption = new("VPR_AoE_VicepitCombo_SubOption", 0),
            VPR_AoE_Reawaken_Usage = new("VPR_AoE_Reawaken_Usage", 20),
            VPR_AoE_Reawaken_SubOption = new("VPR_AoE_Reawaken_SubOption", 0),
            VPR_AoE_SecondWind_Threshold = new("VPR_AoE_SecondWindThreshold", 40),
            VPR_AoE_Bloodbath_Threshold = new("VPR_AoE_BloodbathThreshold", 30),
            VPR_ReawakenLegacyButton = new("VPR_ReawakenLegacyButton", 0),
            VPR_VariantCure = new("VPR_VariantCure", 50);

        public static UserBool
            VPR_Opener_ExcludeUF = new("VPR_Opener_ExcludeUF"),
            VPR_ST_RangedUptimeUncoiledFury = new("VPR_ST_RangedUptimeUncoiledFury"),
            VPR_TrueNortVicewinder = new("VPR_TrueNortVicewinder");

        #endregion
    }
}
