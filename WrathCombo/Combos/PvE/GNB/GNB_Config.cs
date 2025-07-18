using ImGuiNET;
using WrathCombo.CustomComboNS.Functions;
using WrathCombo.Data;
using WrathCombo.Extensions;
using WrathCombo.Window.Functions;
using BossAvoidance = WrathCombo.Combos.PvE.All.Enums.BossAvoidance;
using PartyRequirement = WrathCombo.Combos.PvE.All.Enums.PartyRequirement;

namespace WrathCombo.Combos.PvE;

internal partial class GNB
{
    internal static class Config
    {
        public static UserInt
            GNB_Opener_StartChoice = new ("GNB_Opener_StartChoice", 0),
            GNB_Opener_NM = new("GNB_Opener_NM", 0),
            GNB_ST_MitsOptions = new("GNB_ST_MitsOptions", 0),
            GNB_ST_Corundum_Health = new("GNB_ST_CorundumOption", 90),
            GNB_ST_Corundum_SubOption = new("GNB_ST_Corundum_Option", 0),
            GNB_ST_Aurora_Health = new("GNB_ST_Aurora_Health", 99),
            GNB_ST_Aurora_Charges = new("GNB_ST_Aurora_Charges", 0),
            GNB_ST_Aurora_SubOption = new("GNB_ST_Aurora_Option", 0),
            GNB_ST_Rampart_Health = new("GNB_ST_Rampart_Health", 80),
            GNB_ST_Rampart_SubOption = new("GNB_ST_Rampart_Option", 0),
            GNB_ST_Camouflage_Health = new("GNB_ST_Camouflage_Health", 70),
            GNB_ST_Camouflage_SubOption = new("GNB_ST_Camouflage_Option", 0),
            GNB_ST_Nebula_Health = new("GNB_ST_Nebula_Health", 60),
            GNB_ST_Nebula_SubOption = new("GNB_ST_Nebula_Option", 0),
            GNB_ST_Superbolide_Health = new("GNB_ST_Superbolide_Health", 30),
            GNB_ST_Superbolide_SubOption = new("GNB_ST_Superbolide_Option", 0),
            GNB_ST_Reprisal_Health = new("GNB_ST_Reprisal_Health", 0),
            GNB_ST_Reprisal_SubOption = new("GNB_ST_Reprisal_Option", 0),
            GNB_ST_ArmsLength_Health = new("GNB_ST_ArmsLength_Health", 0),
            GNB_ST_NoMercyStop = new("GNB_ST_NoMercyStop", 5),
            GNB_ST_NoMercy_SubOption = new("GNB_ST_NoMercy_SubOption", 1),
            GNB_ST_Overcap_Choice = new("GNB_ST_Overcap_Choice", 0),
            GNB_AoE_MitsOptions = new("GNB_AoE_MitsOptions", 0),
            GNB_AoE_Corundum_Health = new("GNB_AoE_CorundumOption", 90),
            GNB_AoE_Corundum_SubOption = new("GNB_AoE_Corundum_Option", 0),
            GNB_AoE_Aurora_Health = new("GNB_AoE_Aurora_Health", 99),
            GNB_AoE_Aurora_Charges = new("GNB_AoE_Aurora_Charges", 0),
            GNB_AoE_Aurora_SubOption = new("GNB_AoE_Aurora_Option", 0),
            GNB_AoE_Rampart_Health = new("GNB_AoE_Rampart_Health", 80),
            GNB_AoE_Rampart_SubOption = new("GNB_AoE_Rampart_Option", 10),
            GNB_AoE_Camouflage_Health = new("GNB_AoE_Camouflage_Health", 80),
            GNB_AoE_Camouflage_SubOption = new("GNB_AoE_Camouflage_Option", 0),
            GNB_AoE_Nebula_Health = new("GNB_AoE_Nebula_Health", 60),
            GNB_AoE_Nebula_SubOption = new("GNB_AoE_Nebula_Option", 0),
            GNB_AoE_Superbolide_Health = new("GNB_AoE_Superbolide_Health", 30),
            GNB_AoE_Superbolide_SubOption = new("GNB_AoE_Superbolide_Option", 0),
            GNB_AoE_Reprisal_Health = new("GNB_AoE_Reprisal_Health", 0),
            GNB_AoE_Reprisal_SubOption = new("GNB_AoE_Reprisal_Option", 0),
            GNB_AoE_ArmsLength_Health = new("GNB_AoE_ArmsLength_Health", 0),
            GNB_AoE_FatedCircle_BurstStrike = new("GNB_AoE_FatedCircle_BurstStrike", 1),
            GNB_AoE_Overcap_Choice = new("GNB_AoE_Overcap_Choice", 0),
            GNB_AoE_NoMercyStop = new("GNB_AoE_NoMercyStop", 5),
            GNB_NM_Features_Weave = new("GNB_NM_Feature_Weave", 0),
            GNB_GF_Features_Choice = new("GNB_GF_Choice", 0),
            GNB_GF_Overcap_Choice = new("GNB_GF_Overcap_Choice", 0),
            GNB_ST_Balance_Content = new("GNB_ST_Balance_Content", 1),
            GNB_Mit_Superbolide_Health = new("GNB_Mit_Superbolide_Health", 30),
            GNB_Mit_Corundum_Health = new("GNB_Mit_Corundum_Health", 60),
            GNB_Mit_Aurora_Charges = new("GNB_Mit_Aurora_Charges", 0),
            GNB_Mit_Aurora_Health = new("GNB_Mit_Aurora_Health", 60),
            GNB_Mit_HeartOfLight_PartyRequirement = new("GNB_Mit_HeartOfLight_PartyRequirement", (int)PartyRequirement.Yes),
            GNB_Mit_Rampart_Health = new("GNB_Mit_Rampart_Health", 65),
            GNB_Mit_ArmsLength_Boss = new("GNB_Mit_ArmsLength_Boss", (int)BossAvoidance.On),
            GNB_Mit_ArmsLength_EnemyCount = new("GNB_Mit_ArmsLength_EnemyCount", 0),
            GNB_Mit_Nebula_Health = new("GNB_Mit_Nebula_Health", 50),
            GNB_VariantCure = new("GNB_VariantCure"),
            GNB_Bozja_LostCure_Health = new("GNB_Bozja_LostCure_Health", 50),
            GNB_Bozja_LostCure2_Health = new("GNB_Bozja_LostCure2_Health", 50),
            GNB_Bozja_LostCure3_Health = new("GNB_Bozja_LostCure3_Health", 50),
            GNB_Bozja_LostCure4_Health = new("GNB_Bozja_LostCure4_Health", 50),
            GNB_Bozja_LostAethershield_Health = new("GNB_Bozja_LostAethershield_Health", 70),
            GNB_Bozja_LostReraise_Health = new("GNB_Bozja_LostReraise_Health", 10);

        public static UserIntArray
            GNB_Mit_Priorities = new("GNB_Mit_Priorities");

        public static UserBoolArray
            GNB_Mit_Superbolide_Difficulty = new("GNB_Mit_Superbolide_Difficulty", [true, false]);

        public static readonly ContentCheck.ListSet GNB_Mit_Superbolide_DifficultyListSet = ContentCheck.ListSet.Halved;

        private const int NumMitigationOptions = 8;

        internal static void Draw(CustomComboPreset preset)
        {
            switch (preset)
            {
                #region Single-Target
                case CustomComboPreset.GNB_ST_Opener:
                    UserConfig.DrawHorizontalRadioButton(GNB_Opener_NM,
                        $"常规{NoMercy.ActionName()}", $"在所有起手中常规使用{NoMercy.ActionName()}", 0);
                    UserConfig.DrawHorizontalRadioButton(GNB_Opener_NM,
                        $"提前{NoMercy.ActionName()}", $"在所有起手中尽早使用{NoMercy.ActionName()}", 1);
                    
                    if (UserConfig.DrawHorizontalRadioButton(GNB_Opener_StartChoice,
                        $"常规起手", $"以{LightningShot.ActionName()}作为起手开始", 0))
                    {
                        if (!CustomComboFunctions.InCombat())
                            Opener().OpenerStep = 1;
                    }    
                    UserConfig.DrawHorizontalRadioButton(GNB_Opener_StartChoice,
                        $"提前起手", $"以{KeenEdge.ActionName()}作为起手，跳过{LightningShot.ActionName()}", 1);
                    
                    UserConfig.DrawBossOnlyChoice(GNB_ST_Balance_Content);
                    break;

                case CustomComboPreset.GNB_ST_NoMercy:
                    UserConfig.DrawHorizontalRadioButton(GNB_ST_NoMercy_SubOption,
                        "全部内容", $"无论内容如何都使用{CustomComboFunctions.GetActionName(NoMercy)}", 0);
                    UserConfig.DrawHorizontalRadioButton(GNB_ST_NoMercy_SubOption,
                        "仅Boss战", $"仅在Boss战中使用{CustomComboFunctions.GetActionName(NoMercy)}", 1);
                    
                    UserConfig.DrawSliderInt(0, 75, GNB_ST_NoMercyStop,
                        " 若目标HP%低于设定值则停止使用。\n  设为0以禁用此功能");
                    break;

                case CustomComboPreset.GNB_ST_BurstStrike:
                    UserConfig.DrawHorizontalRadioButton(GNB_ST_Overcap_Choice,
                        "包含溢出保护", $"包含{BurstStrike.ActionName()}以防止弹药溢出", 0);
                    UserConfig.DrawHorizontalRadioButton(GNB_ST_Overcap_Choice,
                        "不包含溢出保护", $"无论弹药数量如何都不包含{BurstStrike.ActionName()}", 1);
                    break;
                #endregion

                #region AoE
                case CustomComboPreset.GNB_AoE_NoMercy:
                    UserConfig.DrawSliderInt(0, 75, GNB_AoE_NoMercyStop,
                        " 若目标HP%低于设定值则停止使用。\n 设为0以禁用此功能");
                    break;

                case CustomComboPreset.GNB_AoE_FatedCircle:
                    UserConfig.DrawHorizontalRadioButton(GNB_AoE_Overcap_Choice,
                        "包含溢出保护", $"包含{FatedCircle.ActionName()}以防止弹药溢出", 0);
                    UserConfig.DrawHorizontalRadioButton(GNB_AoE_Overcap_Choice,
                        "不包含溢出保护", $"无论弹药数量如何都不包含{FatedCircle.ActionName()}", 1);
                    ImGui.Spacing();
                    UserConfig.DrawHorizontalRadioButton(GNB_AoE_FatedCircle_BurstStrike,
                        "包含爆发击", $"当{FatedCircle.ActionName()}不可用时，改为使用{BurstStrike.ActionName()}", 0);
                    UserConfig.DrawHorizontalRadioButton(GNB_AoE_FatedCircle_BurstStrike,
                        "不包含爆发击", $"当{FatedCircle.ActionName()}不可用时，不使用{BurstStrike.ActionName()}", 1);
                    break;
                #endregion

                #region Mitigations
                case CustomComboPreset.GNB_ST_Corundum:
                    UserConfig.DrawSliderInt(1, 100, GNB_ST_Corundum_Health,
                        "玩家HP%小于等于该值时使用：", 200);
                    UserConfig.DrawHorizontalRadioButton(GNB_ST_Corundum_SubOption,
                        "全部敌人", $"无论目标敌人类型，均使用{HeartOfCorundum.ActionName()}", 0);
                    UserConfig.DrawHorizontalRadioButton(GNB_ST_Corundum_SubOption,
                        "仅Boss", $"仅在目标为Boss时使用{HeartOfCorundum.ActionName()}", 1);
                    break;

                case CustomComboPreset.GNB_AoE_Corundum:
                    UserConfig.DrawSliderInt(1, 100, GNB_AoE_Corundum_Health,
                        "玩家HP%小于等于该值时使用：", 200);
                    UserConfig.DrawHorizontalRadioButton(GNB_AoE_Corundum_SubOption,
                        "全部敌人", $"无论目标敌人类型，均使用{HeartOfCorundum.ActionName()}", 0);
                    UserConfig.DrawHorizontalRadioButton(GNB_AoE_Corundum_SubOption,
                        "仅Boss", $"仅在目标为Boss时使用{HeartOfCorundum.ActionName()}", 1);
                    break;

                case CustomComboPreset.GNB_ST_Aurora:
                    UserConfig.DrawSliderInt(1, 100, GNB_ST_Aurora_Health,
                        "玩家HP%小于等于该值时使用：", 200);
                    UserConfig.DrawSliderInt(0, 1, GNB_ST_Aurora_Charges,
                        "保留多少层数？\n (0 = 全部使用)");
                    UserConfig.DrawHorizontalRadioButton(GNB_ST_Aurora_SubOption,
                        "全部敌人", $"无论目标敌人类型，均使用{Aurora.ActionName()}", 0);
                    UserConfig.DrawHorizontalRadioButton(GNB_ST_Aurora_SubOption,
                        "仅Boss", $"仅在目标为Boss时使用{Aurora.ActionName()}", 1);
                    break;

                case CustomComboPreset.GNB_AoE_Aurora:
                    UserConfig.DrawSliderInt(1, 100, GNB_AoE_Aurora_Health,
                        "玩家HP%小于等于该值时使用：", 200);
                    UserConfig.DrawSliderInt(0, 1, GNB_AoE_Aurora_Charges,
                        "保留多少层数？\n (0 = 全部使用)");
                    UserConfig.DrawHorizontalRadioButton(GNB_AoE_Aurora_SubOption,
                        "全部敌人", $"无论目标敌人类型，均使用{Aurora.ActionName()}", 0);
                    UserConfig.DrawHorizontalRadioButton(GNB_AoE_Aurora_SubOption,
                        "仅Boss", $"仅在目标为Boss时使用{Aurora.ActionName()}", 1);
                    break;

                case CustomComboPreset.GNB_ST_Rampart:
                    UserConfig.DrawSliderInt(1, 100, GNB_ST_Rampart_Health,
                        "玩家HP%小于等于该值时使用：", 200);
                    UserConfig.DrawHorizontalRadioButton(GNB_ST_Rampart_SubOption,
                        "全部敌人", $"无论目标敌人类型，均使用{Role.Rampart.ActionName()}", 0);
                    UserConfig.DrawHorizontalRadioButton(GNB_ST_Rampart_SubOption,
                        "仅Boss", $"仅在目标为Boss时使用{Role.Rampart.ActionName()}", 1);
                    break;

                case CustomComboPreset.GNB_AoE_Rampart:
                    UserConfig.DrawSliderInt(1, 100, GNB_AoE_Rampart_Health,
                        "玩家HP%小于等于该值时使用：", 200);
                    UserConfig.DrawHorizontalRadioButton(GNB_AoE_Rampart_SubOption,
                        "全部敌人", $"无论目标敌人类型，均使用{Role.Rampart.ActionName()}", 0);
                    UserConfig.DrawHorizontalRadioButton(GNB_AoE_Rampart_SubOption,
                        "仅Boss", $"仅在目标为Boss时使用{Role.Rampart.ActionName()}", 1);
                    break;

                case CustomComboPreset.GNB_ST_Camouflage:
                    UserConfig.DrawSliderInt(1, 100, GNB_ST_Camouflage_Health,
                        "玩家HP%小于等于该值时使用：", 200);
                    UserConfig.DrawHorizontalRadioButton(GNB_ST_Camouflage_SubOption,
                        "全部敌人", $"无论目标敌人类型，均使用{Camouflage.ActionName()}", 0);
                    UserConfig.DrawHorizontalRadioButton(GNB_ST_Camouflage_SubOption,
                        "仅Boss", $"仅在目标为Boss时使用{Camouflage.ActionName()}", 1);
                    break;

                case CustomComboPreset.GNB_AoE_Camouflage:
                    UserConfig.DrawSliderInt(1, 100, GNB_AoE_Camouflage_Health,
                        "玩家HP%小于等于该值时使用：", 200);
                    UserConfig.DrawHorizontalRadioButton(GNB_AoE_Camouflage_SubOption,
                        "全部敌人", $"无论目标敌人类型，均使用{Camouflage.ActionName()}", 0);
                    UserConfig.DrawHorizontalRadioButton(GNB_AoE_Camouflage_SubOption,
                        "仅Boss", $"仅在目标为Boss时使用{Camouflage.ActionName()}", 1);
                    break;

                case CustomComboPreset.GNB_ST_Nebula:
                    UserConfig.DrawSliderInt(1, 100, GNB_ST_Nebula_Health,
                        "玩家HP%小于等于该值时使用：", 200);
                    UserConfig.DrawHorizontalRadioButton(GNB_ST_Nebula_SubOption,
                        "全部敌人", $"无论目标敌人类型，均使用{Nebula.ActionName()}", 0);
                    UserConfig.DrawHorizontalRadioButton(GNB_ST_Nebula_SubOption,
                        "仅Boss", $"仅在目标为Boss时使用{Nebula.ActionName()}", 1);
                    break;

                case CustomComboPreset.GNB_AoE_Nebula:
                    UserConfig.DrawSliderInt(1, 100, GNB_AoE_Nebula_Health,
                        "玩家HP%小于等于该值时使用：", 200);
                    UserConfig.DrawHorizontalRadioButton(GNB_AoE_Nebula_SubOption,
                        "全部敌人", $"无论目标敌人类型，均使用{Nebula.ActionName()}", 0);
                    UserConfig.DrawHorizontalRadioButton(GNB_AoE_Nebula_SubOption,
                        "仅Boss", $"仅在目标为Boss时使用{Nebula.ActionName()}", 1);
                    break;

                case CustomComboPreset.GNB_ST_Superbolide:
                    UserConfig.DrawSliderInt(1, 100, GNB_ST_Superbolide_Health,
                        "玩家HP%小于等于该值时使用：", 200);
                    UserConfig.DrawHorizontalRadioButton(GNB_ST_Superbolide_SubOption,
                        "全部敌人", $"无论目标敌人类型，均使用{Superbolide.ActionName()}", 0);
                    UserConfig.DrawHorizontalRadioButton(GNB_ST_Superbolide_SubOption,
                        "仅Boss", $"仅在目标为Boss时使用{Superbolide.ActionName()}", 1);
                    break;

                case CustomComboPreset.GNB_AoE_Superbolide:
                    UserConfig.DrawSliderInt(1, 100, GNB_AoE_Superbolide_Health,
                        "玩家HP%小于等于该值时使用：", 200);
                    UserConfig.DrawHorizontalRadioButton(GNB_AoE_Superbolide_SubOption,
                        "全部敌人", $"无论目标敌人类型，均使用{Superbolide.ActionName()}", 0);
                    UserConfig.DrawHorizontalRadioButton(GNB_AoE_Superbolide_SubOption,
                        "仅Boss", $"仅在目标为Boss时使用{Superbolide.ActionName()}", 1);
                    break;

                case CustomComboPreset.GNB_ST_Reprisal:
                    UserConfig.DrawSliderInt(1, 100, GNB_ST_Reprisal_Health,
                        "玩家HP%小于等于该值时使用：", 200);
                    UserConfig.DrawHorizontalRadioButton(GNB_ST_Reprisal_SubOption,
                        "全部敌人", $"无论目标敌人类型，均使用{Role.Reprisal.ActionName()}", 0);
                    UserConfig.DrawHorizontalRadioButton(GNB_ST_Reprisal_SubOption,
                        "仅Boss", $"仅在目标为Boss时使用{Role.Reprisal.ActionName()}", 1);
                    break;

                case CustomComboPreset.GNB_AoE_Reprisal:
                    UserConfig.DrawSliderInt(1, 100, GNB_AoE_Reprisal_Health,
                        "玩家HP%小于等于该值时使用：", 200);
                    UserConfig.DrawHorizontalRadioButton(GNB_AoE_Reprisal_SubOption,
                        "全部敌人", $"无论目标敌人类型，均使用{Role.Reprisal.ActionName()}", 0);
                    UserConfig.DrawHorizontalRadioButton(GNB_AoE_Reprisal_SubOption,
                        "仅Boss", $"仅在目标为Boss时使用{Role.Reprisal.ActionName()}", 1);
                    break;

                #region One-Button Mitigation

                case CustomComboPreset.GNB_Mit_Superbolide_Max:
                    UserConfig.DrawDifficultyMultiChoice(GNB_Mit_Superbolide_Difficulty, GNB_Mit_Superbolide_DifficultyListSet,
                        "选择在哪些难度下使用超火流星：");
                    UserConfig.DrawSliderInt(1, 100, GNB_Mit_Superbolide_Health, "玩家HP%小于等于该值时使用：", 200, SliderIncrements.Fives);
                    break;

                case CustomComboPreset.GNB_Mit_Corundum:
                    UserConfig.DrawSliderInt(1, 100, GNB_Mit_Corundum_Health,
                        "HP%小于等于该值时使用（100=禁用检测）",
                        sliderIncrement: SliderIncrements.Ones);
                    UserConfig.DrawPriorityInput(GNB_Mit_Priorities, NumMitigationOptions, 0,
                        "刚玉之心优先级：");
                    break;

                case CustomComboPreset.GNB_Mit_Aurora:
                    UserConfig.DrawSliderInt(0, 1, GNB_Mit_Aurora_Charges,
                        "保留多少层数？\n (0 = 全部使用)");
                    UserConfig.DrawSliderInt(1, 100, GNB_Mit_Aurora_Health,
                        "HP%小于等于该值时使用（100=禁用检测）",
                        sliderIncrement: SliderIncrements.Ones);
                    UserConfig.DrawPriorityInput(GNB_Mit_Priorities, NumMitigationOptions, 1,
                        "极光优先级：");
                    break;

                case CustomComboPreset.GNB_Mit_Camouflage:
                    UserConfig.DrawPriorityInput(GNB_Mit_Priorities, NumMitigationOptions, 2,
                        "伪装优先级：");
                    break;

                case CustomComboPreset.GNB_Mit_Reprisal:
                    UserConfig.DrawPriorityInput(GNB_Mit_Priorities, NumMitigationOptions, 3,
                        "雪仇优先级：");
                    break;

                case CustomComboPreset.GNB_Mit_HeartOfLight:
                    ImGui.Indent();
                    UserConfig.DrawHorizontalRadioButton(GNB_Mit_HeartOfLight_PartyRequirement,
                        "需要队伍", "只有队伍人数大于等于2时才会使用光之心。",
                        (int)PartyRequirement.Yes);
                    UserConfig.DrawHorizontalRadioButton(GNB_Mit_HeartOfLight_PartyRequirement,
                        "总是使用", "光之心不要求有队伍。",
                        (int)PartyRequirement.No);
                    ImGui.Unindent();
                    ImGui.NewLine();
                    UserConfig.DrawPriorityInput(GNB_Mit_Priorities, NumMitigationOptions, 4,
                        "光之心优先级：");
                    break;

                case CustomComboPreset.GNB_Mit_Rampart:
                    UserConfig.DrawSliderInt(1, 100, GNB_Mit_Rampart_Health,
                        "HP%小于等于该值时使用（100=禁用检测）",
                        sliderIncrement: SliderIncrements.Ones);
                    UserConfig.DrawPriorityInput(GNB_Mit_Priorities, NumMitigationOptions, 5,
                        "铁壁优先级：");
                    break;

                case CustomComboPreset.GNB_Mit_ArmsLength:
                    ImGui.Indent();
                    UserConfig.DrawHorizontalRadioButton(GNB_Mit_ArmsLength_Boss, 
                        "全部敌人", "无论敌人类型均会使用亲疏自行。",
                        (int)BossAvoidance.Off, 125f);
                    UserConfig.DrawHorizontalRadioButton(
                        GNB_Mit_ArmsLength_Boss, 
                        "避免Boss", "Boss战时尽量不使用亲疏自行。",
                        (int)BossAvoidance.On, 125f);
                    ImGui.Unindent();
                    ImGui.NewLine();
                    UserConfig.DrawSliderInt(0, 3, GNB_Mit_ArmsLength_EnemyCount,
                        "附近需要有多少敌人？（0=无限制）");
                    UserConfig.DrawPriorityInput(GNB_Mit_Priorities, NumMitigationOptions, 6,
                        "亲疏自行优先级：");
                    break;

                case CustomComboPreset.GNB_Mit_Nebula:
                    UserConfig.DrawSliderInt(1, 100, GNB_Mit_Nebula_Health,
                        "HP%小于等于该值时使用（100=禁用检测）",
                        sliderIncrement: SliderIncrements.Ones);
                    UserConfig.DrawPriorityInput(GNB_Mit_Priorities, NumMitigationOptions, 7,
                        "星云优先级：");
                    break;
                #endregion

                #endregion

                #region Other
                case CustomComboPreset.GNB_NM_Features:
                    UserConfig.DrawHorizontalRadioButton(GNB_NM_Features_Weave,
                        "仅插入", "仅在能力技窗口期使用技能（不包括无情）", 0);
                    UserConfig.DrawHorizontalRadioButton(GNB_NM_Features_Weave,
                        "冷却即用", "技能冷却好后立即使用", 1);
                    break;

                case CustomComboPreset.GNB_GF_Features:
                    UserConfig.DrawHorizontalRadioButton(GNB_GF_Features_Choice,
                        "替换碎裂牙", $"在{GnashingFang.ActionName()}时按预期使用此功能", 0);
                    UserConfig.DrawHorizontalRadioButton(GNB_GF_Features_Choice,
                        "替换无情", $"在{NoMercy.ActionName()}时使用此功能\n警告：这会与“无情功能”冲突！", 1);
                    break;

                case CustomComboPreset.GNB_GF_BurstStrike:
                    UserConfig.DrawHorizontalRadioButton(GNB_GF_Overcap_Choice,
                        "包含溢出保护", $"包含{BurstStrike.ActionName()}以防止弹药溢出", 0);
                    UserConfig.DrawHorizontalRadioButton(GNB_GF_Overcap_Choice,
                        "不包含溢出保护", $"无论弹药数量如何都不包含{BurstStrike.ActionName()}", 1);
                    break;

                case CustomComboPreset.GNB_ST_Simple:
                    UserConfig.DrawHorizontalRadioButton(GNB_ST_MitsOptions,
                        "包含减伤", "在简单模式下启用减伤技能。", 0);
                    UserConfig.DrawHorizontalRadioButton(GNB_ST_MitsOptions,
                        "不包含减伤", "在简单模式下禁用减伤技能。", 1);
                    break;

                case CustomComboPreset.GNB_AoE_Simple:
                    UserConfig.DrawHorizontalRadioButton(GNB_AoE_MitsOptions,
                        "包含减伤", "在简单模式下启用减伤技能。", 0);
                    UserConfig.DrawHorizontalRadioButton(GNB_AoE_MitsOptions,
                        "不包含减伤", "在简单模式下禁用减伤技能。", 1);
                    break;

                case CustomComboPreset.GNB_Bozja_LostCure:
                    UserConfig.DrawSliderInt(1, 100, GNB_Bozja_LostCure_Health,
                        "玩家HP%小于等于该值时使用：", 200);
                    break;

                case CustomComboPreset.GNB_Bozja_LostCure2:
                    UserConfig.DrawSliderInt(1, 100, GNB_Bozja_LostCure2_Health,
                        "玩家HP%小于等于该值时使用：", 200);
                    break;

                case CustomComboPreset.GNB_Bozja_LostCure3:
                    UserConfig.DrawSliderInt(1, 100, GNB_Bozja_LostCure3_Health,
                        "玩家HP%小于等于该值时使用：", 200);
                    break;

                case CustomComboPreset.GNB_Bozja_LostCure4:
                    UserConfig.DrawSliderInt(1, 100, GNB_Bozja_LostCure4_Health,
                        "玩家HP%小于等于该值时使用：", 200);
                    break;

                case CustomComboPreset.GNB_Bozja_LostAethershield:
                    UserConfig.DrawSliderInt(1, 100, GNB_Bozja_LostAethershield_Health,
                        "玩家HP%小于等于该值时使用：", 200);
                    break;

                case CustomComboPreset.GNB_Bozja_LostReraise:
                    UserConfig.DrawSliderInt(1, 100, GNB_Bozja_LostReraise_Health,
                        "玩家HP%小于等于该值时使用：", 200);
                    break;

                case CustomComboPreset.GNB_Variant_Cure:
                    UserConfig.DrawSliderInt(1, 100, GNB_VariantCure,
                        "玩家HP%小于等于该值时使用：", 200);
                    break;
                    #endregion
            }
        }
    }
}
