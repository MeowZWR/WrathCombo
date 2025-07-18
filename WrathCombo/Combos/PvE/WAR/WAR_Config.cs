using Dalamud.Interface.Colors;
using ECommons.ImGuiMethods;
using ImGuiNET;
using WrathCombo.CustomComboNS.Functions;
using WrathCombo.Data;
using WrathCombo.Extensions;
using WrathCombo.Window.Functions;
using BossAvoidance = WrathCombo.Combos.PvE.All.Enums.BossAvoidance;
using PartyRequirement = WrathCombo.Combos.PvE.All.Enums.PartyRequirement;

namespace WrathCombo.Combos.PvE;

internal partial class WAR
{
    internal static class Config
    {
        public static UserInt
            WAR_Infuriate_Charges = new("WAR_Infuriate_Charges", 0),
            WAR_Infuriate_Range = new("WAR_Infuriate_Range", 0),
            WAR_SurgingRefreshRange = new("WAR_SurgingRefreshRange", 10),
            WAR_EyePath_Refresh = new("WAR_EyePath", 10),
            WAR_ST_Infuriate_Charges = new("WAR_ST_Infuriate_Charges", 0),
            WAR_ST_Infuriate_Gauge = new("WAR_ST_Infuriate_Gauge", 40),
            WAR_ST_FellCleave_Gauge = new("WAR_ST_FellCleave_Gauge", 90),
            WAR_ST_FellCleave_BurstPooling = new("WAR_ST_FellCleave_BurstPooling", 0),
            WAR_ST_Onslaught_Charges = new("WAR_ST_Onslaught_Charges", 0),
            WAR_ST_Onslaught_Movement = new("WAR_ST_Onslaught_Movement", 0),
            WAR_ST_PrimalRend_Movement = new("WAR_ST_PrimalRend_Movement", 0),
            WAR_ST_PrimalRend_EarlyLate = new("WAR_ST_PrimalRend_EarlyLate", 0),
            WAR_ST_Bloodwhetting_Health = new("WAR_ST_BloodwhettingOption", 90),
            WAR_ST_Bloodwhetting_SubOption = new("WAR_ST_Bloodwhetting_SubOpt", 0),
            WAR_ST_Equilibrium_Health = new("WAR_ST_EquilibriumOption", 50),
            WAR_ST_Equilibrium_SubOption = new("WAR_ST_Equilibrium_SubOpt", 0),
            WAR_ST_Rampart_Health = new("WAR_ST_Rampart_Health", 80),
            WAR_ST_Rampart_SubOption = new("WAR_ST_Rampart_SubOption", 0),
            WAR_ST_Thrill_Health = new("WAR_ST_Thrill_Health", 70),
            WAR_ST_Thrill_SubOption = new("WAR_ST_Thrill_SubOpt", 0),
            WAR_ST_Vengeance_Health = new("WAR_ST_Vengeance_Health", 60),
            WAR_ST_Vengeance_SubOption = new("WAR_ST_Vengeance_SubOpt", 0),
            WAR_ST_Holmgang_Health = new("WAR_ST_Holmgang_Health", 30),
            WAR_ST_Holmgang_SubOption = new("WAR_ST_Holmgang_SubOpt", 0),
            WAR_ST_Reprisal_Health = new("WAR_ST_Reprisal_Health", 80),
            WAR_ST_Reprisal_SubOption = new("WAR_ST_Reprisal_SubOpt", 0),
            WAR_ST_ArmsLength_Health = new("WAR_ST_ArmsLength_Health", 80),
            WAR_ST_MitsOptions = new("WAR_ST_MitsOptions", 0),
            WAR_ST_IRStop = new("WAR_ST_IRStop", 0),
            WAR_AoE_Infuriate_Charges = new("WAR_AoE_Infuriate_Charges", 0),
            WAR_AoE_Infuriate_Gauge = new("WAR_AoE_Infuriate_Gauge", 40),
            WAR_AoE_Decimate_Gauge = new("WAR_AoE_Decimate_Gauge", 90),
            WAR_AoE_Decimate_BurstPooling = new("WAR_AoE_Decimate_BurstPooling", 0),
            WAR_AoE_Onslaught_Charges = new("WAR_AoE_Onslaught_Charges", 0),
            WAR_AoE_Onslaught_Movement = new("WAR_AoE_Onslaught_Movement", 0),
            WAR_AoE_PrimalRend_Movement = new("WAR_AoE_PrimalRend_Movement", 0),
            WAR_AoE_PrimalRend_EarlyLate = new("WAR_AoE_PrimalRend_EarlyLate", 0),
            WAR_AoE_OrogenyUpheaval = new("WAR_AoE_OrogenyUpheaval", 0),
            WAR_AoE_Bloodwhetting_Health = new("WAR_AoE_BloodwhettingOption", 90),
            WAR_AoE_Bloodwhetting_SubOption = new("WAR_AoE_Bloodwhetting_SubOpt", 0),
            WAR_AoE_Equilibrium_Health = new("WAR_AoE_EquilibriumOption", 50),
            WAR_AoE_Equilibrium_SubOption = new("WAR_AoE_Equilibrium_SubOpt", 0),
            WAR_AoE_Rampart_Health = new("WAR_AoE_Rampart_Health", 80),
            WAR_AoE_Rampart_SubOption = new("WAR_AoE_Rampart_SubOpt", 0),
            WAR_AoE_Thrill_Health = new("WAR_AoE_Thrill_Health", 80),
            WAR_AoE_Thrill_SubOption = new("WAR_AoE_Thrill_SubOpt", 0),
            WAR_AoE_Vengeance_Health = new("WAR_AoE_Vengeance_Health", 60),
            WAR_AoE_Vengeance_SubOption = new("WAR_AoE_Vengeance_SubOpt", 0),
            WAR_AoE_Holmgang_Health = new("WAR_AoE_Holmgang_Health", 30),
            WAR_AoE_Holmgang_SubOption = new("WAR_AoE_Holmgang_SubOpt", 0),
            WAR_AoE_Reprisal_Health = new("WAR_AoE_Reprisal_Health", 80),
            WAR_AoE_Reprisal_SubOption = new("WAR_AoE_Reprisal_SubOpt", 0),
            WAR_AoE_ArmsLength_Health = new("WAR_AoE_ArmsLength_Health", 80),
            WAR_AoE_MitsOptions = new("WAR_AoE_MitsOptions", 0),
            WAR_AoE_IRStop = new("WAR_AoE_IRStop", 0),
            WAR_VariantCure = new("WAR_VariantCure"),
            WAR_BalanceOpener_Content = new("WAR_BalanceOpener_Content", 1),
            WAR_FC_IRStop = new("WAR_FC_IRStop", 0),
            WAR_FC_Infuriate_Charges = new("WAR_FC_Infuriate_Charges", 0),
            WAR_FC_Infuriate_Gauge = new("WAR_FC_Infuriate_Gauge", 40),
            WAR_FC_Onslaught_Charges = new("WAR_FC_Onslaught_Charges", 0),
            WAR_FC_Onslaught_Movement = new("WAR_FC_Onslaught_Movement", 0),
            WAR_FC_PrimalRend_Movement = new("WAR_FC_PrimalRend_Movement", 0),
            WAR_FC_PrimalRend_EarlyLate = new("WAR_FC_PrimalRend_EarlyLate", 0),
            WAR_Mit_Holmgang_Health = new("WAR_Mit_Holmgang_Health", 30),
            WAR_Mit_Bloodwhetting_Health = new("WAR_Mit_Bloodwhetting_Health", 70),
            WAR_Mit_Equilibrium_Health = new("WAR_Mit_Equilibrium_Health", 45),
            WAR_Mit_ThrillOfBattle_Health = new("WAR_Mit_ThrillOfBattle_Health", 60),
            WAR_Mit_Rampart_Health = new("WAR_Mit_Rampart_Health", 65),
            WAR_Mit_ShakeItOff_PartyRequirement = new("WAR_Mit_ShakeItOff_PartyRequirement", (int)PartyRequirement.Yes),
            WAR_Mit_ArmsLength_Boss = new("WAR_Mit_ArmsLength_Boss", (int)BossAvoidance.On),
            WAR_Mit_ArmsLength_EnemyCount = new("WAR_Mit_ArmsLength_EnemyCount", 0),
            WAR_Mit_Vengeance_Health = new("WAR_Mit_Vengeance_Health", 50),
            WAR_Bozja_LostCure_Health = new("WAR_Bozja_LostCure_Health", 50),
            WAR_Bozja_LostCure2_Health = new("WAR_Bozja_LostCure2_Health", 50),
            WAR_Bozja_LostCure3_Health = new("WAR_Bozja_LostCure3_Health", 50),
            WAR_Bozja_LostCure4_Health = new("WAR_Bozja_LostCure4_Health", 50),
            WAR_Bozja_LostAethershield_Health = new("WAR_Bozja_LostAethershield_Health", 70),
            WAR_Bozja_LostReraise_Health = new("WAR_Bozja_LostReraise_Health", 10);

        public static UserFloat
            WAR_ST_Onslaught_Distance = new("WAR_ST_Ons_Distance", 3.0f),
            WAR_ST_PrimalRend_Distance = new("WAR_ST_PR_Distance", 3.0f),
            WAR_AoE_Onslaught_Distance = new("WAR_AoE_Ons_Distance", 3.0f),
            WAR_AoE_PrimalRend_Distance = new("WAR_AoE_PR_Distance", 3.0f),
            WAR_FC_Onslaught_Distance = new("WAR_FC_Ons_Distance", 3.0f),
            WAR_FC_PrimalRend_Distance = new("WAR_FC_PR_Distance", 3.0f),
            WAR_ST_Onslaught_TimeStill = new("WAR_ST_Onslaught_TimeStill", 0),
            WAR_ST_PrimalRend_TimeStill = new("WAR_ST_PrimalRend_TimeStill", 0),
            WAR_AoE_Onslaught_TimeStill = new("WAR_AoE_Onslaught_TimeStill", 0),
            WAR_AoE_PrimalRend_TimeStill = new("WAR_AoE_PrimalRend_TimeStill", 0),
            WAR_FC_Onslaught_TimeStill = new("WAR_FC_Onslaught_TimeStill", 0),
            WAR_FC_PrimalRend_TimeStill = new("WAR_FC_PrimalRend_TimeStill", 0);

        public static UserIntArray
            WAR_Mit_Priorities = new("WAR_Mit_Priorities");

        public static UserBoolArray
            WAR_Mit_Holmgang_Difficulty = new("WAR_Mit_Holmgang_Difficulty", [true, false]);

        public static readonly ContentCheck.ListSet WAR_Mit_Holmgang_DifficultyListSet = ContentCheck.ListSet.Halved;

        private const int NumMitigationOptions = 8;

        internal static void Draw(CustomComboPreset preset)
        {
            switch (preset)
            {
                #region Single-Target
                case CustomComboPreset.WAR_ST_BalanceOpener:
                    UserConfig.DrawBossOnlyChoice(WAR_BalanceOpener_Content);
                    break;

                case CustomComboPreset.WAR_ST_StormsEye:
                    UserConfig.DrawSliderInt(0, 30, WAR_SurgingRefreshRange,
                        $" 刷新{Buffs.SurgingTempest.StatusName()}增益前的剩余秒数：");
                    break;

                case CustomComboPreset.WAR_ST_InnerRelease:
                    UserConfig.DrawSliderInt(0, 75, WAR_ST_IRStop,
                        "目标血量低于设定值时停止使用。\n如需禁用此功能，请设为0");
                    break;

                case CustomComboPreset.WAR_ST_Onslaught:
                    UserConfig.DrawHorizontalRadioButton(WAR_ST_Onslaught_Movement,
                            "仅在站立时", "仅在站立时使用猛攻", 0);
                    UserConfig.DrawHorizontalRadioButton(WAR_ST_Onslaught_Movement,
                            "任意移动", "无论移动状态均可使用猛攻。\n注意：这可能导致你死亡", 1);
                    ImGui.Spacing();
                    if (WAR_ST_Onslaught_Movement == 0)
                    {
                        ImGui.SetCursorPosX(48);
                        UserConfig.DrawSliderFloat(0, 3, WAR_ST_Onslaught_TimeStill,
                            "站立检测延迟（秒）：", decimals: 1);
                    }
                    ImGui.SetCursorPosX(48);
                    UserConfig.DrawSliderInt(0, 2, WAR_ST_Onslaught_Charges,
                        "保留多少层数？\n（0 = 全部使用）");
                    ImGui.SetCursorPosX(48);
                    UserConfig.DrawSliderFloat(1, 20, WAR_ST_Onslaught_Distance,
                        "与目标距离小于等于此值时使用：", decimals: 1);
                    break;

                case CustomComboPreset.WAR_ST_Infuriate:
                    UserConfig.DrawSliderInt(0, 2, WAR_ST_Infuriate_Charges,
                        "保留多少层数？\n（0 = 全部使用）");
                    UserConfig.DrawSliderInt(0, 50, WAR_ST_Infuriate_Gauge,
                        "兽魂低于等于此值时使用：");
                    break;

                case CustomComboPreset.WAR_ST_FellCleave:
                    UserConfig.DrawHorizontalRadioButton(WAR_ST_FellCleave_BurstPooling,
                        "爆发池", "允许在爆发期间额外使用裂石飞环\n注意：爆发期间会无视下方的兽魂量条", 0);
                    UserConfig.DrawHorizontalRadioButton(WAR_ST_FellCleave_BurstPooling,
                        "无爆发池", "禁止在爆发期间额外使用裂石飞环\n注意：完全遵循下方兽魂量条设定", 1);
                    ImGui.Spacing();
                    UserConfig.DrawSliderInt(50, 100, WAR_ST_FellCleave_Gauge,
                        "消耗所需最低兽魂：");
                    break;

                case CustomComboPreset.WAR_ST_PrimalRend:
                    UserConfig.DrawHorizontalRadioButton(WAR_ST_PrimalRend_EarlyLate,
                        "尽早", "尽快使用蛮荒崩裂", 0);
                    UserConfig.DrawHorizontalRadioButton(WAR_ST_PrimalRend_EarlyLate,
                        "延后", "在消耗完所有原初的解放层数后再使用蛮荒崩裂", 1);
                    ImGui.NewLine();
                    UserConfig.DrawHorizontalRadioButton(WAR_ST_PrimalRend_Movement,
                        "仅在站立时", "仅在站立时使用蛮荒崩裂", 0);
                    UserConfig.DrawHorizontalRadioButton(WAR_ST_PrimalRend_Movement,
                        "任意移动", "无论移动状态均可使用蛮荒崩裂。\n注意：这可能导致你死亡", 1);
                    ImGui.Spacing();
                    if (WAR_ST_PrimalRend_Movement == 0)
                    {
                        ImGui.SetCursorPosX(48);
                        UserConfig.DrawSliderFloat(0, 3, WAR_ST_PrimalRend_TimeStill,
                            "站立检测延迟（秒）：", decimals: 1);
                    }
                    ImGui.SetCursorPosX(48);
                    UserConfig.DrawSliderFloat(1, 20, WAR_ST_PrimalRend_Distance,
                        "与目标距离小于等于此值时使用：", decimals: 1);
                    break;
                #endregion

                #region AoE
                case CustomComboPreset.WAR_AoE_Decimate:
                    UserConfig.DrawHorizontalRadioButton(WAR_AoE_Decimate_BurstPooling,
                        "爆发池", "允许在爆发期间额外使用地毁人亡\n注意：爆发期间会无视下方兽魂量条", 0);
                    UserConfig.DrawHorizontalRadioButton(WAR_AoE_Decimate_BurstPooling,
                        "无爆发池", "禁止在爆发期间额外使用地毁人亡\n注意：完全遵循下方兽魂量条设定", 1);
                    ImGui.Spacing();
                    UserConfig.DrawSliderInt(50, 100, WAR_AoE_Decimate_Gauge,
                        "消耗所需最低兽魂：");
                    break;

                case CustomComboPreset.WAR_AoE_InnerRelease:
                    UserConfig.DrawSliderInt(0, 75, WAR_AoE_IRStop,
                        "目标血量低于设定值时停止使用。\n如需禁用此功能，请设为0");
                    break;


                case CustomComboPreset.WAR_AoE_Infuriate:
                    UserConfig.DrawSliderInt(0, 2, WAR_AoE_Infuriate_Charges,
                        "保留多少层数？\n（0 = 全部使用）");
                    UserConfig.DrawSliderInt(0, 50, WAR_AoE_Infuriate_Gauge,
                        "魂量低于等于此值时使用");
                    break;

                case CustomComboPreset.WAR_AoE_Onslaught:
                    UserConfig.DrawHorizontalRadioButton(WAR_AoE_Onslaught_Movement,
                            "仅在站立时", "仅在站立时使用猛攻", 0);
                    UserConfig.DrawHorizontalRadioButton(WAR_AoE_Onslaught_Movement,
                            "任意移动", "无论移动状态均可使用猛攻。\n注意：这可能导致你死亡", 1);
                    ImGui.Spacing();
                    if (WAR_AoE_Onslaught_Movement == 0) 
                    {
                        ImGui.SetCursorPosX(48);
                        UserConfig.DrawSliderFloat(0, 3, WAR_AoE_Onslaught_TimeStill,
                            "站立检测延迟（秒）：", decimals: 1);
                    }
                    UserConfig.DrawSliderInt(0, 2, WAR_AoE_Onslaught_Charges,
                        "保留多少层数？\n（0 = 全部使用）");
                    ImGui.SetCursorPosX(48);
                    UserConfig.DrawSliderFloat(1, 20, WAR_AoE_Onslaught_Distance,
                        "与目标距离小于等于此值时使用：", decimals: 1);
                    break;

                case CustomComboPreset.WAR_AoE_PrimalRend:
                    UserConfig.DrawHorizontalRadioButton(WAR_AoE_PrimalRend_EarlyLate,
                        "尽早", "尽快使用蛮荒崩裂", 0);
                    UserConfig.DrawHorizontalRadioButton(WAR_AoE_PrimalRend_EarlyLate,
                        "延后", "在消耗完所有蛮荒崩裂层数后再使用蛮荒崩裂", 1);
                    ImGui.NewLine();
                    UserConfig.DrawHorizontalRadioButton(WAR_AoE_PrimalRend_Movement,
                        "仅在站立时", "仅在站立时使用蛮荒崩裂", 0);
                    UserConfig.DrawHorizontalRadioButton(WAR_AoE_PrimalRend_Movement,
                        "任意移动", "无论移动状态均可使用蛮荒崩裂。\n注意：这可能导致你死亡", 1);
                    ImGui.Spacing();
                    if (WAR_AoE_PrimalRend_Movement == 0)
                    {
                        ImGui.SetCursorPosX(48);
                        UserConfig.DrawSliderFloat(0, 3, WAR_AoE_PrimalRend_TimeStill,
                            "站立检测延迟（秒）：", decimals: 1);
                    }
                    ImGui.SetCursorPosX(48);
                    UserConfig.DrawSliderFloat(1, 20, WAR_AoE_PrimalRend_Distance,
                        "与目标距离小于等于此值时使用：", decimals: 1);
                    break;

                case CustomComboPreset.WAR_AoE_Orogeny:
                    UserConfig.DrawHorizontalRadioButton(WAR_AoE_OrogenyUpheaval,
                        "包含动乱", "若山崩不可用则在AOE循环中启用动乱", 0);
                    UserConfig.DrawHorizontalRadioButton(WAR_AoE_OrogenyUpheaval,
                        "不包含动乱", "在AOE循环中禁用动乱", 1);
                    break;
                #endregion

                #region Mitigations
                case CustomComboPreset.WAR_ST_Bloodwhetting:
                    UserConfig.DrawSliderInt(1, 100, WAR_ST_Bloodwhetting_Health,
                        "玩家血量低于等于此值时使用：", 200);
                    UserConfig.DrawHorizontalRadioButton(WAR_ST_Bloodwhetting_SubOption,
                        "所有敌人", $"无论目标类型均使用{Bloodwhetting.ActionName()}", 0);
                    UserConfig.DrawHorizontalRadioButton(WAR_ST_Bloodwhetting_SubOption,
                        "仅Boss", $"仅在目标为Boss时使用{Bloodwhetting.ActionName()}", 1);
                    break;

                case CustomComboPreset.WAR_AoE_Bloodwhetting:
                    UserConfig.DrawSliderInt(1, 100, WAR_AoE_Bloodwhetting_Health,
                        "玩家血量低于等于此值时使用：", 200);
                    UserConfig.DrawHorizontalRadioButton(WAR_AoE_Bloodwhetting_SubOption,
                        "所有敌人", $"无论目标类型均使用{Bloodwhetting.ActionName()}", 0);
                    UserConfig.DrawHorizontalRadioButton(WAR_AoE_Bloodwhetting_SubOption,
                        "仅Boss", $"仅在目标为Boss时使用{Bloodwhetting.ActionName()}", 1);
                    break;

                case CustomComboPreset.WAR_ST_Equilibrium:
                    UserConfig.DrawSliderInt(1, 100, WAR_ST_Equilibrium_Health,
                        "玩家血量低于等于此值时使用：", 200);
                    UserConfig.DrawHorizontalRadioButton(WAR_ST_Equilibrium_SubOption,
                        "所有敌人", $"无论目标类型均使用{Equilibrium.ActionName()}", 0);
                    UserConfig.DrawHorizontalRadioButton(WAR_ST_Equilibrium_SubOption,
                        "仅Boss", $"仅在目标为Boss时使用{Equilibrium.ActionName()}", 1);
                    break;

                case CustomComboPreset.WAR_AoE_Equilibrium:
                    UserConfig.DrawSliderInt(1, 100, WAR_AoE_Equilibrium_Health,
                        "玩家血量低于等于此值时使用：", 200);
                    UserConfig.DrawHorizontalRadioButton(WAR_AoE_Equilibrium_SubOption,
                        "所有敌人", $"无论目标类型均使用{Equilibrium.ActionName()}", 0);
                    UserConfig.DrawHorizontalRadioButton(WAR_AoE_Equilibrium_SubOption,
                        "仅Boss", $"仅在目标为Boss时使用{Equilibrium.ActionName()}", 1);
                    break;

                case CustomComboPreset.WAR_ST_Rampart:
                    UserConfig.DrawSliderInt(1, 100, WAR_ST_Rampart_Health,
                        "玩家血量低于等于此值时使用：", 200);
                    UserConfig.DrawHorizontalRadioButton(WAR_ST_Rampart_SubOption,
                        "所有敌人", $"无论目标类型均使用{Role.Rampart.ActionName()}", 0);
                    UserConfig.DrawHorizontalRadioButton(WAR_ST_Rampart_SubOption,
                        "仅Boss", $"仅在目标为Boss时使用{Role.Rampart.ActionName()}", 1);
                    break;

                case CustomComboPreset.WAR_AoE_Rampart:
                    UserConfig.DrawSliderInt(1, 100, WAR_AoE_Rampart_Health,
                        "玩家血量低于等于此值时使用：", 200);
                    UserConfig.DrawHorizontalRadioButton(WAR_AoE_Rampart_SubOption,
                        "所有敌人", $"无论目标类型均使用{Role.Rampart.ActionName()}", 0);
                    UserConfig.DrawHorizontalRadioButton(WAR_AoE_Rampart_SubOption,
                        "仅Boss", $"仅在目标为Boss时使用{Role.Rampart.ActionName()}", 1);
                    break;

                case CustomComboPreset.WAR_ST_Thrill:
                    UserConfig.DrawSliderInt(1, 100, WAR_ST_Thrill_Health,
                        "玩家血量低于等于此值时使用：", 200);
                    UserConfig.DrawHorizontalRadioButton(WAR_ST_Thrill_SubOption,
                        "所有敌人", $"无论目标类型均使用{ThrillOfBattle.ActionName()}", 0);
                    UserConfig.DrawHorizontalRadioButton(WAR_ST_Thrill_SubOption,
                        "仅Boss", $"仅在目标为Boss时使用{ThrillOfBattle.ActionName()}", 1);
                    break;

                case CustomComboPreset.WAR_AoE_Thrill:
                    UserConfig.DrawSliderInt(1, 100, WAR_AoE_Thrill_Health,
                        "玩家血量低于等于此值时使用：", 200);
                    UserConfig.DrawHorizontalRadioButton(WAR_AoE_Thrill_SubOption,
                        "所有敌人", $"无论目标类型均使用{ThrillOfBattle.ActionName()}", 0);
                    UserConfig.DrawHorizontalRadioButton(WAR_AoE_Thrill_SubOption,
                        "仅Boss", $"仅在目标为Boss时使用{ThrillOfBattle.ActionName()}", 1);
                    break;

                case CustomComboPreset.WAR_ST_Vengeance:
                    UserConfig.DrawSliderInt(1, 100, WAR_ST_Vengeance_Health,
                        "玩家血量低于等于此值时使用：", 200);
                    UserConfig.DrawHorizontalRadioButton(WAR_ST_Vengeance_SubOption,
                        "所有敌人", $"无论目标类型均使用{Vengeance.ActionName()}", 0);
                    UserConfig.DrawHorizontalRadioButton(WAR_ST_Vengeance_SubOption,
                        "仅Boss", $"仅在目标为Boss时使用{Vengeance.ActionName()}", 1);
                    break;

                case CustomComboPreset.WAR_AoE_Vengeance:
                    UserConfig.DrawSliderInt(1, 100, WAR_AoE_Vengeance_Health,
                        "玩家血量低于等于此值时使用：", 200);
                    UserConfig.DrawHorizontalRadioButton(WAR_AoE_Vengeance_SubOption,
                        "所有敌人", $"无论目标类型均使用{Vengeance.ActionName()}", 0);
                    UserConfig.DrawHorizontalRadioButton(WAR_AoE_Vengeance_SubOption,
                        "仅Boss", $"仅在目标为Boss时使用{Vengeance.ActionName()}", 1);
                    break;

                case CustomComboPreset.WAR_ST_Holmgang:
                    UserConfig.DrawSliderInt(1, 100, WAR_ST_Holmgang_Health,
                        "玩家血量低于等于此值时使用：", 200);
                    UserConfig.DrawHorizontalRadioButton(WAR_ST_Holmgang_SubOption,
                        "所有敌人", $"无论目标类型均使用{Holmgang.ActionName()}", 0);
                    UserConfig.DrawHorizontalRadioButton(WAR_ST_Holmgang_SubOption,
                        "仅Boss", $"仅在目标为Boss时使用{Holmgang.ActionName()}", 1);
                    break;

                case CustomComboPreset.WAR_AoE_Holmgang:
                    UserConfig.DrawSliderInt(1, 100, WAR_AoE_Holmgang_Health,
                        "玩家血量低于等于此值时使用：", 200);
                    UserConfig.DrawHorizontalRadioButton(WAR_AoE_Holmgang_SubOption,
                        "所有敌人", $"无论目标类型均使用{Holmgang.ActionName()}", 0);
                    UserConfig.DrawHorizontalRadioButton(WAR_AoE_Holmgang_SubOption,
                        "仅Boss", $"仅在目标为Boss时使用{Holmgang.ActionName()}", 1);
                    break;

                case CustomComboPreset.WAR_ST_Reprisal:
                    UserConfig.DrawSliderInt(1, 100, WAR_ST_Reprisal_Health,
                        "玩家血量低于等于此值时使用：", 200);
                    UserConfig.DrawHorizontalRadioButton(WAR_ST_Reprisal_SubOption,
                        "所有敌人", $"无论目标类型均使用{Role.Reprisal.ActionName()}", 0);
                    UserConfig.DrawHorizontalRadioButton(WAR_ST_Reprisal_SubOption,
                        "仅Boss", $"仅在目标为Boss时使用{Role.Reprisal.ActionName()}", 1);
                    break;

                case CustomComboPreset.WAR_AoE_Reprisal:
                    UserConfig.DrawSliderInt(1, 100, WAR_AoE_Reprisal_Health,
                        "玩家血量低于等于此值时使用：", 200);
                    UserConfig.DrawHorizontalRadioButton(WAR_AoE_Reprisal_SubOption,
                        "所有敌人", $"无论目标类型均使用{Role.Reprisal.ActionName()}", 0);
                    UserConfig.DrawHorizontalRadioButton(WAR_AoE_Reprisal_SubOption,
                        "仅Boss", $"仅在目标为Boss时使用{Role.Reprisal.ActionName()}", 1);
                    break;

                #region One-Button Mitigation

                case CustomComboPreset.WAR_Mit_Holmgang_Max:
                    UserConfig.DrawDifficultyMultiChoice(WAR_Mit_Holmgang_Difficulty, WAR_Mit_Holmgang_DifficultyListSet,
                        "选择要在哪些难度下使用死斗：");

                    UserConfig.DrawSliderInt(1, 100, WAR_Mit_Holmgang_Health,
                        "玩家血量低于等于此值时使用：", 200, SliderIncrements.Fives);
                    break;

                case CustomComboPreset.WAR_Mit_Bloodwhetting:
                    UserConfig.DrawSliderInt(1, 100, WAR_Mit_Bloodwhetting_Health,
                        "血量低于等于此值时使用", sliderIncrement: SliderIncrements.Ones);

                    UserConfig.DrawPriorityInput(WAR_Mit_Priorities, NumMitigationOptions, 0,
                        "原初的血气优先级：");
                    break;

                case CustomComboPreset.WAR_Mit_Equilibrium:
                    UserConfig.DrawSliderInt(1, 100, WAR_Mit_Equilibrium_Health,
                        "血量低于等于此值时使用", sliderIncrement: SliderIncrements.Ones);

                    UserConfig.DrawPriorityInput(WAR_Mit_Priorities, NumMitigationOptions, 1,
                        "战栗优先级：");
                    break;

                case CustomComboPreset.WAR_Mit_Reprisal:
                    UserConfig.DrawPriorityInput(WAR_Mit_Priorities, NumMitigationOptions, 2,
                        "死斗优先级：");
                    break;

                case CustomComboPreset.WAR_Mit_ThrillOfBattle:
                    UserConfig.DrawSliderInt(1, 100, WAR_Mit_ThrillOfBattle_Health,
                        "血量低于等于此值时使用（100=禁用检测）", sliderIncrement: SliderIncrements.Ones);

                    UserConfig.DrawPriorityInput(WAR_Mit_Priorities, NumMitigationOptions, 3,
                        "战栗优先级：");
                    break;

                case CustomComboPreset.WAR_Mit_Rampart:
                    UserConfig.DrawSliderInt(1, 100, WAR_Mit_Rampart_Health,
                        "血量低于等于此值时使用（100=禁用检测）", sliderIncrement: SliderIncrements.Ones);

                    UserConfig.DrawPriorityInput(WAR_Mit_Priorities, NumMitigationOptions, 4,
                        "铁壁优先级：");
                    break;

                case CustomComboPreset.WAR_Mit_ShakeItOff:
                    ImGui.Indent();
                    UserConfig.DrawHorizontalRadioButton(WAR_Mit_ShakeItOff_PartyRequirement,
                        "需要队伍", "只有队伍成员数大于等于2时才会使用摆脱。",
                        outputValue: (int)PartyRequirement.Yes);
                    UserConfig.DrawHorizontalRadioButton(WAR_Mit_ShakeItOff_PartyRequirement,
                        "总是使用", "使用摆脱时不要求有队伍。",
                        outputValue: (int)PartyRequirement.No);
                    ImGui.Unindent();

                    ImGui.NewLine();
                    UserConfig.DrawPriorityInput(WAR_Mit_Priorities, NumMitigationOptions, 5,
                        "摆脱优先级：");
                    break;

                case CustomComboPreset.WAR_Mit_ArmsLength:
                    ImGui.Indent();
                    UserConfig.DrawHorizontalRadioButton(WAR_Mit_ArmsLength_Boss,
                        "所有敌人", "无论敌人类型均会使用亲疏自行。",
                        outputValue: (int)BossAvoidance.Off, itemWidth: 125f);
                    UserConfig.DrawHorizontalRadioButton(WAR_Mit_ArmsLength_Boss,
                        "避免Boss", "Boss战时尽量不使用亲疏自行。",
                        outputValue: (int)BossAvoidance.On, itemWidth: 125f);
                    ImGui.Unindent();
                    ImGui.NewLine();
                    UserConfig.DrawSliderInt(0, 3, WAR_Mit_ArmsLength_EnemyCount,
                        "附近需要多少敌人？（0=无要求）");
                    UserConfig.DrawPriorityInput(WAR_Mit_Priorities, NumMitigationOptions, 6, "亲疏自行优先级：");
                    break;

                case CustomComboPreset.WAR_Mit_Vengeance:
                    UserConfig.DrawSliderInt(1, 100, WAR_Mit_Vengeance_Health,
                        "血量低于等于此值时使用（100=禁用检测）",
                        sliderIncrement: SliderIncrements.Ones);
                    UserConfig.DrawPriorityInput(WAR_Mit_Priorities, NumMitigationOptions, 7, "复仇优先级：");
                    break;
                #endregion

                #endregion

                #region Other
                case CustomComboPreset.WAR_FC_InnerRelease:
                    UserConfig.DrawSliderInt(0, 75, WAR_FC_IRStop,
                        "目标血量低于设定值时停止使用。\n如需禁用此功能，请设为0");
                    break;

                case CustomComboPreset.WAR_FC_Onslaught:
                    UserConfig.DrawHorizontalRadioButton(WAR_FC_Onslaught_Movement,
                        "仅在站立时", "仅在站立时使用猛攻", 0);
                    UserConfig.DrawHorizontalRadioButton(WAR_FC_Onslaught_Movement,
                        "任意移动", "无论移动状态均可使用猛攻。\n注意：这可能导致你死亡", 1);
                    ImGui.Spacing();
                    if (WAR_FC_Onslaught_Movement == 0)
                    {
                        ImGui.SetCursorPosX(48);
                        UserConfig.DrawSliderFloat(0, 3, WAR_FC_Onslaught_TimeStill,
                            "站立检测延迟（秒）：", decimals: 1);
                    }
                    UserConfig.DrawSliderInt(0, 2, WAR_FC_Onslaught_Charges,
                        "保留多少层数？\n（0 = 全部使用）");
                    ImGui.SetCursorPosX(48);
                    UserConfig.DrawSliderFloat(1, 20, WAR_FC_Onslaught_Distance,
                        "与目标距离小于等于此值时使用：", decimals: 1);
                    break;

                case CustomComboPreset.WAR_FC_Infuriate:
                    UserConfig.DrawSliderInt(0, 2, WAR_FC_Infuriate_Charges,
                        "保留多少层数？\n（0 = 全部使用）");
                    UserConfig.DrawSliderInt(0, 50, WAR_FC_Infuriate_Gauge,
                        "兽魂低于等于此值时使用：");
                    break;

                case CustomComboPreset.WAR_FC_PrimalRend:
                    UserConfig.DrawHorizontalRadioButton(WAR_FC_PrimalRend_EarlyLate,
                        "尽早", "尽快使用原初的解放", 0);
                    UserConfig.DrawHorizontalRadioButton(WAR_FC_PrimalRend_EarlyLate,
                        "延后", "在消耗完所有原初的解放层数后再使用原初的解放", 1);
                    ImGui.NewLine();
                    UserConfig.DrawHorizontalRadioButton(WAR_FC_PrimalRend_Movement,
                        "仅在站立时", "仅在站立时使用原初的解放", 0);
                    UserConfig.DrawHorizontalRadioButton(WAR_FC_PrimalRend_Movement,
                        "任意移动", "无论移动状态均可使用原初的解放。\n注意：这可能导致你死亡", 1);
                    ImGui.Spacing();
                    if (WAR_FC_PrimalRend_Movement == 0)
                    {
                        ImGui.SetCursorPosX(48);
                        UserConfig.DrawSliderFloat(0, 3, WAR_FC_PrimalRend_TimeStill,
                            "站立检测延迟（秒）：", decimals: 1);
                    }
                    ImGui.SetCursorPosX(48);
                    UserConfig.DrawSliderFloat(1, 20, WAR_FC_PrimalRend_Distance,
                        "与目标距离小于等于此值时使用：", decimals: 1);
                    break;

                case CustomComboPreset.WAR_ST_Simple:
                    UserConfig.DrawHorizontalRadioButton(WAR_ST_MitsOptions,
                        "包含减伤", "在简易模式下启用减伤技能。", 0);
                    UserConfig.DrawHorizontalRadioButton(WAR_ST_MitsOptions,
                        "不包含减伤", "在简易模式下禁用减伤技能。", 1);
                    break;

                case CustomComboPreset.WAR_AoE_Simple:
                    UserConfig.DrawHorizontalRadioButton(WAR_AoE_MitsOptions,
                        "包含减伤", "在简易模式下启用减伤技能。", 0);
                    UserConfig.DrawHorizontalRadioButton(WAR_AoE_MitsOptions,
                        "不包含减伤", "在简易模式下禁用减伤技能。", 1);
                    break;

                case CustomComboPreset.WAR_InfuriateFellCleave:
                    UserConfig.DrawSliderInt(0, 2, WAR_Infuriate_Charges,
                        "保留多少层数？\n（0 = 全部使用）");
                    UserConfig.DrawSliderInt(0, 50, WAR_Infuriate_Range,
                        "兽魂低于等于此值时使用：");
                    break;

                case CustomComboPreset.WAR_EyePath:
                    UserConfig.DrawSliderInt(0, 30, WAR_EyePath_Refresh,
                        $" 刷新{Buffs.SurgingTempest.StatusName()}增益前的剩余秒数：");
                    break;

                case CustomComboPreset.WAR_Variant_Cure:
                    UserConfig.DrawSliderInt(1, 100, WAR_VariantCure,
                        "玩家血量低于等于此值时使用：", 200);
                    break;

                case CustomComboPreset.WAR_RawIntuition_Targeting_TT:
                    ImGui.Indent();
                    ImGuiEx.TextWrapped(ImGuiColors.DalamudGrey,
                        "注意：如果你是副T，并且希望将原初的血气用于自己，建议通过一键减伤功能或你的循环中的减伤选项来实现。\n" +
                        "你也可以在队伍中鼠标悬停自己来使用原初的血气或原初的直觉。\n" +
                        "如果你不这样做，原初的勇猛会替换该连击，并施放到主T身上。\n" +
                        "如果你不使用这些功能来进行个人减伤，建议不要启用此选项。");
                    ImGui.Unindent();
                    break;
                    #endregion
            }
        }
    }
}
