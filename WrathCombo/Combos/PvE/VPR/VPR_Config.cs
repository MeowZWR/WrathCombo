using WrathCombo.CustomComboNS.Functions;
using WrathCombo.Extensions;
using static WrathCombo.Window.Functions.UserConfig;
namespace WrathCombo.Combos.PvE;

internal partial class VPR
{
    internal static class Config
    {
        internal static void Draw(Preset preset)
        {
            switch (preset)
            {
                case Preset.VPR_ST_Opener:
                    DrawBossOnlyChoice(VPR_Balance_Content);

                    DrawAdditionalBoolChoice(VPR_Opener_ExcludeUF,
                        $"排除{UncoiledFury.ActionName()}", "");
                    break;

                case Preset.VPR_ST_SerpentsIre:
                    DrawHorizontalRadioButton(VPR_ST_SerpentsIre_SubOption,
                        "全部内容", $"无论内容如何均使用{SerpentsIre.ActionName()}。", 0);

                    DrawHorizontalRadioButton(VPR_ST_SerpentsIre_SubOption,
                        "仅限Boss战", $"仅在Boss战中使用{SerpentsIre.ActionName()}。", 1);
                    break;

                case Preset.VPR_ST_Reawaken:
                    DrawSliderInt(0, 100, VPR_ST_ReawakenBossOption,
                        "Bosses Only. Stop using at Enemy HP %.");

                    DrawSliderInt(0, 100, VPR_ST_ReawakenBossAddsOption,
                        "Boss Encounter Non Bosses. Stop using at Enemy HP %.");

                    DrawSliderInt(0, 100, VPR_ST_ReawakenTrashOption,
                        "Non boss encounter. Stop using at Enemy HP %.");

                    DrawSliderInt(0, 5, VPR_ST_ReAwaken_Threshold,
                        $"设置HP百分比阈值，在可用时使用{Reawaken.ActionName()}。（仅限Boss战）");
                    break;

                case Preset.VPR_ST_UncoiledFury:
                    DrawSliderInt(0, 3, VPR_ST_UncoiledFury_HoldCharges,
                        $"预留多少层{UncoiledFury.ActionName()}？（0 = 全部使用）");

                    DrawSliderInt(0, 5, VPR_ST_UncoiledFury_Threshold,
                        $"设置HP百分比阈值，低于该值时全部使用{UncoiledFury.ActionName()}。");
                    break;

                case Preset.VPR_ST_RangedUptime:
                    DrawAdditionalBoolChoice(VPR_ST_RangedUptimeUncoiledFury,
                        $"包含{UncoiledFury.ActionName()}", $"当你处于远程状态且拥有{RattlingCoil.ActionName()}层数时，将{UncoiledFury.ActionName()}加入循环。");
                    break;

                case Preset.VPR_ST_Vicewinder:
                    DrawAdditionalBoolChoice(VPR_TrueNortVicewinder,
                        $"{Role.TrueNorth.ActionName()}选项", "可用时加入真北。\n Respects the manual TN charge.");
                    break;

                case Preset.VPR_TrueNorthDynamic:
                    DrawSliderInt(0, 1, VPR_ManualTN,
                        "How many charges to keep for manual usage.");
                    break;
                
                case Preset.VPR_ST_ComboHeals:
                    DrawSliderInt(0, 100, VPR_ST_SecondWind_Threshold,
                        $"{Role.SecondWind.ActionName()}触发HP百分比阈值");

                    DrawSliderInt(0, 100, VPR_ST_Bloodbath_Threshold,
                        $"{Role.Bloodbath.ActionName()}触发HP百分比阈值");
                    break;

                case Preset.VPR_AoE_UncoiledFury:
                    DrawSliderInt(0, 3, VPR_AoE_UncoiledFury_HoldCharges,
                        $"预留多少层{UncoiledFury.ActionName()}？（0 = 全部使用）");

                    DrawSliderInt(0, 5, VPR_AoE_UncoiledFury_Threshold,
                        $"设置HP百分比阈值，低于该值时全部使用{UncoiledFury.ActionName()}。");
                    break;

                case Preset.VPR_AoE_Reawaken:
                    DrawHorizontalRadioButton(VPR_AoE_Reawaken_SubOption,
                        "在范围内", $"为{Reawaken.ActionName()}添加距离检测，仅在目标在范围内时使用。", 0);

                    DrawHorizontalRadioButton(VPR_AoE_Reawaken_SubOption,
                        "禁用距离检测", $"禁用{Reawaken.ActionName()}的距离检测，即使未选中目标也会使用。", 1);

                    DrawSliderInt(0, 100, VPR_AoE_Reawaken_Usage,
                        $"敌人HP高于该百分比时停止使用{Reawaken.ActionName()}。设为0则不检测。");
                    break;

                case Preset.VPR_AoE_Vicepit:
                    DrawHorizontalRadioButton(VPR_AoE_Vicepit_SubOption,
                        "在范围内", $"为{Vicepit.ActionName()}添加距离检测，仅在目标在范围内时使用。", 0);

                    DrawHorizontalRadioButton(VPR_AoE_Vicepit_SubOption,
                        "禁用距离检测", $"禁用{Vicepit.ActionName()}的距离检测，即使未选中目标也会使用。", 1);
                    break;

                case Preset.VPR_AoE_VicepitCombo:
                    DrawHorizontalRadioButton(VPR_AoE_VicepitCombo_SubOption,
                        "在范围内", $"为{HuntersDen.ActionName()}与{SwiftskinsDen.ActionName()}添加距离检测，仅在目标在范围内时使用。", 0);

                    DrawHorizontalRadioButton(VPR_AoE_VicepitCombo_SubOption,
                        "禁用距离检测", $"禁用{HuntersDen.ActionName()}与{SwiftskinsDen.ActionName()}的距离检测，即使未选中目标也会使用。", 1);
                    break;

                case Preset.VPR_AoE_ComboHeals:
                    DrawSliderInt(0, 100, VPR_AoE_SecondWind_Threshold,
                        $"{Role.SecondWind.ActionName()}触发HP百分比阈值");

                    DrawSliderInt(0, 100, VPR_AoE_Bloodbath_Threshold,
                        $"{Role.Bloodbath.ActionName()}触发HP百分比阈值");
                    break;

                case Preset.VPR_ReawakenLegacy:
                    DrawRadioButton(VPR_ReawakenLegacyButton,
                        $"替换为{Reawaken.ActionName()}", $"将{Reawaken.ActionName()}替换为完整祖灵之牙-祖灵之蛇连击。", 0);

                    DrawRadioButton(VPR_ReawakenLegacyButton,
                        $"替换为{ReavingFangs.ActionName()}", $"将{ReavingFangs.ActionName()}替换为完整祖灵之牙-祖灵之蛇连击。", 1);
                    break;

                case Preset.VPR_Retarget_Slither:
                    DrawAdditionalBoolChoice(VPR_Slither_FieldMouseover,
                        "Add Field Mouseover", "Add Field Mouseover targetting");
                    break;
            }
        }

        #region Variables

        public static UserInt
            VPR_Balance_Content = new("VPR_Balance_Content", 1),
            VPR_ST_SerpentsIre_SubOption = new("VPR_ST_SerpentsIre_SubOption", 1),
            VPR_ST_UncoiledFury_HoldCharges = new("VPR_ST_UncoiledFury_HoldCharges", 1),
            VPR_ST_UncoiledFury_Threshold = new("VPR_ST_UncoiledFury_Threshold", 1),
            VPR_ST_ReawakenBossOption = new("VPR_ST_ReawakenBossOption"),
            VPR_ST_ReawakenBossAddsOption = new("VPR_ST_ReawakenBossAddsOption", 10),
            VPR_ST_ReawakenTrashOption = new("VPR_ST_ReawakenTrashOption", 25),
            VPR_ST_ReAwaken_Threshold = new("VPR_ST_ReAwaken_Threshold", 5),
            VPR_ManualTN = new("VPR_ManualTN"),
            VPR_ST_SecondWind_Threshold = new("VPR_ST_SecondWindThreshold", 40),
            VPR_ST_Bloodbath_Threshold = new("VPR_ST_BloodbathThreshold", 30),
            VPR_AoE_UncoiledFury_Threshold = new("VPR_AoE_UncoiledFury_Threshold", 1),
            VPR_AoE_UncoiledFury_HoldCharges = new("VPR_AoE_UncoiledFury_HoldCharges"),
            VPR_AoE_Vicepit_SubOption = new("VPR_AoE_Vicepit_SubOption"),
            VPR_AoE_VicepitCombo_SubOption = new("VPR_AoE_VicepitCombo_SubOption"),
            VPR_AoE_Reawaken_Usage = new("VPR_AoE_Reawaken_Usage", 40),
            VPR_AoE_Reawaken_SubOption = new("VPR_AoE_Reawaken_SubOption"),
            VPR_AoE_SecondWind_Threshold = new("VPR_AoE_SecondWindThreshold", 40),
            VPR_AoE_Bloodbath_Threshold = new("VPR_AoE_BloodbathThreshold", 30),
            VPR_ReawakenLegacyButton = new("VPR_ReawakenLegacyButton");

        public static UserBool
            VPR_Opener_ExcludeUF = new("VPR_Opener_ExcludeUF"),
            VPR_ST_RangedUptimeUncoiledFury = new("VPR_ST_RangedUptimeUncoiledFury"),
            VPR_TrueNortVicewinder = new("VPR_TrueNortVicewinder"),
            VPR_Slither_FieldMouseover = new("VPR_Slither_FieldMouseover");

        #endregion
    }
}
