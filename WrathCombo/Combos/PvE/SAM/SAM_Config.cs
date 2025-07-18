using ImGuiNET;
using WrathCombo.CustomComboNS.Functions;
using WrathCombo.Extensions;
using WrathCombo.Window.Functions;
using static WrathCombo.Window.Functions.UserConfig;
namespace WrathCombo.Combos.PvE;

internal partial class SAM
{
    internal static class Config
    {
        internal static void Draw(CustomComboPreset preset)
        {
            switch (preset)
            {
                case CustomComboPreset.SAM_ST_Opener:
                    DrawBossOnlyChoice(SAM_Balance_Content);
                    ImGui.NewLine();
                    DrawSliderInt(0, 13, SAM_Opener_PrePullDelay,
                        $"从首次{MeikyoShisui.ActionName()}到下一步的延迟（秒）\n此延迟通过将你的按钮替换为狂怒剑来强制执行。");
                    break;

                case CustomComboPreset.SAM_ST_CDs_Iaijutsu:
                    DrawHorizontalMultiChoice(SAM_ST_CDs_IaijutsuOption, $"添加{Higanbana.ActionName()}", "根据子选项决定是否使用彼岸花。", 4, 0);
                    DrawHorizontalMultiChoice(SAM_ST_CDs_IaijutsuOption, $"添加{TenkaGoken.ActionName()}", "同步等级低于50级时会使用天下五剑。", 4, 1);
                    DrawHorizontalMultiChoice(SAM_ST_CDs_IaijutsuOption, $"使用{MidareSetsugekka.ActionName()}", "会使用纷乱雪月花与天道雪月花。", 4, 2);
                    DrawHorizontalMultiChoice(SAM_ST_CDs_IaijutsuOption, $"使用{TsubameGaeshi.ActionName()}", "会使用燕回返与天道回返雪月花。", 4, 3);

                    if (SAM_ST_CDs_IaijutsuOption[0])
                    {
                        ImGui.Indent();
                        DrawHorizontalRadioButton(SAM_ST_Higanbana_Suboption,
                            "全部敌人", $"无论目标类型都会使用{Higanbana.ActionName()}。", 0);

                        DrawHorizontalRadioButton(SAM_ST_Higanbana_Suboption,
                            "仅Boss", $"仅在目标为Boss时使用{Higanbana.ActionName()}。", 1);
                        ImGui.Unindent();

                        DrawSliderInt(0, 10, SAM_ST_Higanbana_HP_Threshold,
                            $"目标血量低于该百分比时停止使用{Higanbana.ActionName()}（0% = 总是使用）。");

                        DrawSliderInt(0, 15, SAM_ST_Higanbana_Refresh,
                            $"重新应用{Higanbana.ActionName()}前的剩余秒数。设置为0禁用此检查。");
                    }
                    break;

                case CustomComboPreset.SAM_ST_ComboHeals:
                    DrawSliderInt(0, 100, SAM_STSecondWindThreshold,
                        $"{Role.SecondWind.ActionName()} 血量百分比阈值");

                    DrawSliderInt(0, 100, SAM_STBloodbathThreshold,
                        $"{Role.Bloodbath.ActionName()} 血量百分比阈值");
                    break;

                case CustomComboPreset.SAM_AoE_ComboHeals:
                    DrawSliderInt(0, 100, SAM_AoESecondWindThreshold,
                        $"{Role.SecondWind.ActionName()} 血量百分比阈值");

                    DrawSliderInt(0, 100, SAM_AoEBloodbathThreshold,
                        $"{Role.Bloodbath.ActionName()} 血量百分比阈值");
                    break;

                case CustomComboPreset.SAM_ST_CDs_Senei:
                    DrawAdditionalBoolChoice(SAM_ST_CDs_Guren,
                        "红莲", "未解锁必杀剑·闪影时，加入必杀剑·红莲到循环。");
                    break;

                case CustomComboPreset.SAM_ST_CDs_OgiNamikiri:
                    DrawAdditionalBoolChoice(SAM_ST_CDs_OgiNamikiri_Movement,
                        "移动检测", "站立时加入奥义斩浪与回返斩浪。");
                    break;

                case CustomComboPreset.SAM_ST_Shinten:
                    DrawSliderInt(25, 85, SAM_ST_KenkiOvercapAmount,
                        "单体连段剑气溢出阈值设置");

                    DrawSliderInt(0, 100, SAM_ST_ExecuteThreshold,
                        "不保留剑气的血量百分比阈值");
                    break;

                case CustomComboPreset.SAM_AoE_Kyuten:
                    DrawSliderInt(25, 85, SAM_AoE_KenkiOvercapAmount,
                        "AOE连段剑气溢出阈值设置");
                    break;

                case CustomComboPreset.SAM_ST_GekkoCombo:
                    DrawAdditionalBoolChoice(SAM_Gekko_KenkiOvercap,
                        "剑气溢出保护", "剑气达到设定值时消耗。");

                    if (SAM_Gekko_KenkiOvercap)
                        DrawSliderInt(25, 100, SAM_Gekko_KenkiOvercapAmount,
                            "剑气数值", sliderIncrement: SliderIncrements.Fives);
                    break;

                case CustomComboPreset.SAM_ST_KashaCombo:
                    DrawAdditionalBoolChoice(SAM_Kasha_KenkiOvercap,
                        "剑气溢出保护", "剑气达到设定值时消耗。");

                    if (SAM_Kasha_KenkiOvercap)
                        DrawSliderInt(25, 100, SAM_Kasha_KenkiOvercapAmount,
                            "剑气数值", sliderIncrement: SliderIncrements.Fives);
                    break;

                case CustomComboPreset.SAM_ST_YukikazeCombo:
                    DrawAdditionalBoolChoice(SAM_Yukaze_KenkiOvercap,
                        "剑气溢出保护", "剑气达到设定值时消耗。");

                    if (SAM_Yukaze_KenkiOvercap)
                        DrawSliderInt(25, 100, SAM_Yukaze_KenkiOvercapAmount,
                            "剑气数值", sliderIncrement: SliderIncrements.Fives);
                    break;

                case CustomComboPreset.SAM_AoE_OkaCombo:
                    DrawAdditionalBoolChoice(SAM_Oka_KenkiOvercap,
                        "剑气溢出保护", "剑气达到设定值时消耗。");

                    if (SAM_Oka_KenkiOvercap)
                        DrawSliderInt(25, 100, SAM_Oka_KenkiOvercapAmount,
                            "剑气数值", sliderIncrement: SliderIncrements.Fives);
                    break;

                case CustomComboPreset.SAM_AoE_MangetsuCombo:
                    DrawAdditionalBoolChoice(SAM_Mangetsu_KenkiOvercap,
                        "剑气溢出保护", "剑气达到设定值时消耗。");

                    if (SAM_Mangetsu_KenkiOvercap)
                        DrawSliderInt(25, 100, SAM_Mangetsu_KenkiOvercapAmount,
                            "剑气数值", sliderIncrement: SliderIncrements.Fives);
                    break;

                case CustomComboPreset.SAM_Variant_Cure:
                    DrawSliderInt(1, 100, SAM_VariantCure,
                        "血量百分比小于等于时使用", 200);
                    break;
            }
        }
        #region Variables

        public static UserInt
            SAM_Balance_Content = new("SAM_Balance_Content", 1),
            SAM_Opener_PrePullDelay = new("SAM_Opener_PrePullDelay", 13),
            SAM_ST_KenkiOvercapAmount = new("SAM_ST_KenkiOvercapAmount", 65),
            SAM_ST_Higanbana_Suboption = new("SAM_ST_Higanbana_Suboption", 1),
            SAM_ST_Higanbana_HP_Threshold = new("SAM_ST_Higanbana_HP_Threshold", 0),
            SAM_ST_Higanbana_Refresh = new("SAM_ST_Higanbana_Refresh", 15),
            SAM_ST_ExecuteThreshold = new("SAM_ST_ExecuteThreshold", 1),
            SAM_STSecondWindThreshold = new("SAM_STSecondWindThreshold", 40),
            SAM_STBloodbathThreshold = new("SAM_STBloodbathThreshold", 30),
            SAM_AoE_KenkiOvercapAmount = new("SAM_AoE_KenkiOvercapAmount", 50),
            SAM_AoESecondWindThreshold = new("SAM_AoESecondWindThreshold", 40),
            SAM_AoEBloodbathThreshold = new("SAM_AoEBloodbathThreshold", 30),
            SAM_Gekko_KenkiOvercapAmount = new("SAM_Gekko_KenkiOvercapAmount", 65),
            SAM_Kasha_KenkiOvercapAmount = new("SAM_Kasha_KenkiOvercapAmount", 65),
            SAM_Yukaze_KenkiOvercapAmount = new("SAM_Yukaze_KenkiOvercapAmount", 65),
            SAM_Oka_KenkiOvercapAmount = new("SAM_Oka_KenkiOvercapAmount", 50),
            SAM_Mangetsu_KenkiOvercapAmount = new("SAM_Mangetsu_KenkiOvercapAmount", 50),
            SAM_VariantCure = new("SAM_VariantCure", 50);

        public static UserBool
            SAM_Gekko_KenkiOvercap = new("SAM_Gekko_KenkiOvercap"),
            SAM_Kasha_KenkiOvercap = new("SAM_Kasha_KenkiOvercap"),
            SAM_Yukaze_KenkiOvercap = new("SAM_Yukaze_KenkiOvercap"),
            SAM_ST_CDs_Guren = new("SAM_ST_CDs_Guren"),
            SAM_ST_CDs_OgiNamikiri_Movement = new("SAM_ST_CDs_OgiNamikiri_Movement"),
            SAM_Oka_KenkiOvercap = new("SAM_Oka_KenkiOvercap"),
            SAM_Mangetsu_KenkiOvercap = new("SAM_Mangetsu_KenkiOvercap");

        public static UserBoolArray
            SAM_ST_CDs_IaijutsuOption = new("SAM_ST_CDs_IaijutsuOption");

        #endregion
    }
}
