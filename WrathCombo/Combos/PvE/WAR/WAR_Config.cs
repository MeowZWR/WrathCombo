using Dalamud.Interface.Colors;
using ECommons.ImGuiMethods;
using WrathCombo.CustomComboNS.Functions;
using WrathCombo.Data;
using WrathCombo.Extensions;
using WrathCombo.Window.Functions;
using static WrathCombo.Window.Functions.UserConfig;
using BossAvoidance = WrathCombo.Combos.PvE.All.Enums.BossAvoidance;
using PartyRequirement = WrathCombo.Combos.PvE.All.Enums.PartyRequirement;
namespace WrathCombo.Combos.PvE;

internal partial class WAR
{
    internal static class Config
    {
        internal static void Draw(Preset preset)
        {
            switch (preset)
            {
                #region Combo Mitigations
                case Preset.WAR_ST_Simple:
                    DrawHorizontalRadioButton(WAR_ST_MitsOptions, "Include Simple Mitigations", "Enables the use of mitigations.", 0);
                    DrawHorizontalRadioButton(WAR_ST_MitsOptions, "Exclude Simple Mitigations", "Disables the use of mitigations.", 1);
                    break;

                case Preset.WAR_AoE_Simple:
                    DrawHorizontalRadioButton(WAR_AoE_MitsOptions, "Include Simple Mitigations", "Enables the use of mitigations.", 0);
                    DrawHorizontalRadioButton(WAR_AoE_MitsOptions, "Exclude Simple Mitigations", "Disables the use of mitigations.", 1);
                    break;
                case Preset.WAR_ST_Advanced:
                    DrawHorizontalRadioButton(WAR_ST_Advanced_MitsOptions, "Include Advanced Mitigations", "Enables the use of mitigations.", 0);
                    DrawHorizontalRadioButton(WAR_ST_Advanced_MitsOptions, "Exclude Advanced Mitigations", "Disables the use of mitigations.", 1);
                    break;

                case Preset.WAR_AoE_Advanced:
                    DrawHorizontalRadioButton(WAR_AoE_Advanced_MitsOptions, "Include Advanced Mitigations", "Enables the use of advanced mitigations.", 0);
                    DrawHorizontalRadioButton(WAR_AoE_Advanced_MitsOptions, "Exclude Advanced Mitigations", "Disables the use of mitigations.", 1);
                    break;
                case Preset.WAR_Mitigation_NonBoss:
                    DrawSliderFloat(0, 100, WAR_Mitigation_NonBoss_MitigationThreshold, "Stop using when average health percentage of nearby enemies is below set. \n(Set to 0 to disable this check) ", decimals: 0);
                    break;
                case Preset.WAR_Mitigation_NonBoss_ShakeItOff:
                    DrawSliderInt(1, 100, WAR_Mitigation_NonBoss_ShakeItOff_Health, "Player HP% to use Shake It Off at or below");
                    break;
                case Preset.WAR_Mitigation_NonBoss_Equilibrium:
                    DrawSliderInt(1, 100, WAR_Mitigation_NonBoss_Equilibrium_Health, "Player HP% to use Equilibrium at or below");
                    break;
                case Preset.WAR_Mitigation_NonBoss_Holmgang:
                    DrawSliderInt(1, 100, WAR_Mitigation_NonBoss_Holmgang_Health, "Player HP% to use Holmgang at or below");
                    break;
                
                case Preset.WAR_Mitigation_Boss_Equilibrium:
                    DrawSliderInt(1, 100, WAR_Mitigation_Boss_Equilibrium_Health, "Player HP% to use Equilibrium at or below.");
                    DrawSliderInt(1, 100, WAR_Mitigation_Boss_Tankbuster_Equilibrium_Health, "Player HP% to use Equilibrium at or below when incoming tankbuster is detected.");
                    break;
                
                case Preset.WAR_Mitigation_Boss_RawIntuition_OnCD:
                    DrawDifficultyMultiChoice(WAR_Mitigation_Boss_RawIntuition_OnCD_Difficulty, WAR_Boss_Mit_DifficultyListSet ,
                        "Select which difficulties the ability should be used in:");
                    DrawSliderInt(1, 100, WAR_Mitigation_Boss_RawIntuition_Health, "Player HP% to use Raw Intuition/Bloodwhetting at or below");
                    break;
                
                case Preset.WAR_Mitigation_Boss_RawIntuition_TankBuster:
                    DrawDifficultyMultiChoice(WAR_Mitigation_Boss_RawIntuition_TankBuster_Difficulty, WAR_Boss_Mit_DifficultyListSet ,
                        "Select which difficulties the ability should be used in:");
                    break;
                
                case Preset.WAR_Mitigation_Boss_Rampart:
                    DrawDifficultyMultiChoice(WAR_Mitigation_Boss_Rampart_Difficulty, WAR_Boss_Mit_DifficultyListSet ,
                        "Select which difficulties the ability should be used in:");
                    break;
                
                case Preset.WAR_Mitigation_Boss_Vengeance:
                    DrawDifficultyMultiChoice(WAR_Mitigation_Boss_Vengeance_Difficulty, WAR_Boss_Mit_DifficultyListSet ,
                        "Select which difficulties the ability should be used in:");
                    DrawAdditionalBoolChoice(WAR_Mitigation_Boss_Vengeance_First, "Use Vengeance First", "Uses Vengeance before Rampart");
                    break;
                
                case Preset.WAR_Mitigation_Boss_ThrillOfBattle:
                    DrawDifficultyMultiChoice(WAR_Mitigation_Boss_ThrillOfBattle_Difficulty, WAR_Boss_Mit_DifficultyListSet ,
                        "Select which difficulties the ability should be used in:");
                    DrawSliderFloat(1, 100, WAR_Mitigation_Boss_ThrillOfBattle_Threshold, "Will use Thrill Of Battle as extra tankbuster mitigation if under this HP%", decimals: 0);
                    DrawAdditionalBoolChoice(WAR_Mitigation_Boss_ThrillOfBattle_Align, "Align Thrill Of Battle", "Tries to align Thrill Of Battle with Rampart for tankbusters.");
                    break;
                
                case Preset.WAR_Mitigation_Boss_ShakeItOff:
                    DrawDifficultyMultiChoice(WAR_Mitigation_Boss_ShakeItOff_Difficulty, WAR_Boss_Mit_DifficultyListSet ,
                        "Select which difficulties the ability should be used in:");
                    break;
                    
                case Preset.WAR_Mitigation_Boss_Reprisal:
                    DrawDifficultyMultiChoice(WAR_Mitigation_Boss_Reprisal_Difficulty, WAR_Boss_Mit_DifficultyListSet ,
                        "Select which difficulties the ability should be used in:");
                    break;
                
                
                #endregion
                
                #region Single-Target

                case Preset.WAR_ST_BalanceOpener:
                    DrawBossOnlyChoice(WAR_BalanceOpener_Content);
                    break;

                case Preset.WAR_ST_StormsEye:
                    DrawSliderInt(0, 30, WAR_SurgingRefreshRange,
                        $" Seconds remaining before refreshing {Buffs.SurgingTempest.StatusName()} buff:");
                    break;

                case Preset.WAR_ST_InnerRelease:
                    DrawSliderInt(0, 75, WAR_ST_IRStop,
                        " Stop usage if Target HP% is below set value. To disable this, set value to 0");
                    break;

                case Preset.WAR_ST_Onslaught:
                    DrawHorizontalRadioButton(WAR_ST_Onslaught_Movement,
                        "Stationary Only", "Uses Onslaught only while stationary", 0);
                    DrawHorizontalRadioButton(WAR_ST_Onslaught_Movement,
                        "Any Movement", "Uses Onslaught regardless of any movement conditions.\nNOTE: This could possibly get you killed", 1);
                    ImGui.Spacing();
                    if (WAR_ST_Onslaught_Movement == 0)
                    {
                        ImGui.SetCursorPosX(48);
                        DrawSliderFloat(0, 3, WAR_ST_Onslaught_TimeStill,
                            " Stationary Delay Check (in seconds):", decimals: 1);
                    }
                    ImGui.SetCursorPosX(48);
                    DrawSliderInt(0, 2, WAR_ST_Onslaught_Charges,
                        " How many charges to keep ready?\n (0 = Use All)");
                    ImGui.SetCursorPosX(48);
                    DrawSliderFloat(1, 20, WAR_ST_Onslaught_Distance,
                        " Use when Distance from target is less than or equal to:", decimals: 1);
                    break;

                case Preset.WAR_ST_Infuriate:
                    DrawSliderInt(0, 2, WAR_ST_Infuriate_Charges,
                        " How many charges to keep ready? (0 = Use All)");
                    DrawSliderInt(0, 50, WAR_ST_Infuriate_Gauge,
                        " Use when Beast Gauge is less than or equal to:");
                    break;

                case Preset.WAR_ST_FellCleave:
                    DrawHorizontalRadioButton(WAR_ST_FellCleave_BurstPooling,
                        "Burst Pooling", "Allow Fell Cleave for extra use during burst windows\nNOTE: This ignores the gauge slider below when ready for or already in burst", 0);
                    DrawHorizontalRadioButton(WAR_ST_FellCleave_BurstPooling,
                        "No Burst Pooling", "Forbid Fell Cleave for extra use during burst windows\nNOTE: This fully honors the value set on the gauge slider below", 1);
                    ImGui.Spacing();
                    DrawSliderInt(50, 100, WAR_ST_FellCleave_Gauge,
                        " Minimum Beast Gauge required to spend:");
                    break;

                case Preset.WAR_ST_PrimalRend:
                    DrawHorizontalRadioButton(WAR_ST_PrimalRend_EarlyLate,
                        "Early", "Uses Primal Rend ASAP", 0);
                    DrawHorizontalRadioButton(WAR_ST_PrimalRend_EarlyLate,
                        "Late", "Uses Primal Rend after consumption of all Inner Release stacks", 1);
                    ImGui.NewLine();
                    DrawHorizontalRadioButton(WAR_ST_PrimalRend_Movement,
                        "Stationary Only", "Uses Primal Rend only while stationary", 0);
                    DrawHorizontalRadioButton(WAR_ST_PrimalRend_Movement,
                        "Any Movement", "Uses Primal Rend regardless of any movement conditions.\nNOTE: This could possibly get you killed", 1);
                    ImGui.Spacing();
                    if (WAR_ST_PrimalRend_Movement == 0)
                    {
                        ImGui.SetCursorPosX(48);
                        DrawSliderFloat(0, 3, WAR_ST_PrimalRend_TimeStill,
                            "站立检测延迟（秒）：", decimals: 1);
                    }
                    ImGui.SetCursorPosX(48);
                    DrawSliderFloat(1, 20, WAR_ST_PrimalRend_Distance,
                        "与目标距离小于等于此值时使用：", decimals: 1);
                    break;

                #endregion

                #region AoE

                case Preset.WAR_AoE_Decimate:
                    DrawHorizontalRadioButton(WAR_AoE_Decimate_BurstPooling,
                        "爆发池", "允许在爆发期间额外使用地毁人亡\n注意：爆发期间会无视下方兽魂量条", 0);
                    DrawHorizontalRadioButton(WAR_AoE_Decimate_BurstPooling,
                        "无爆发池", "禁止在爆发期间额外使用地毁人亡\n注意：完全遵循下方兽魂量条设定", 1);
                    ImGui.Spacing();
                    DrawSliderInt(50, 100, WAR_AoE_Decimate_Gauge,
                        "消耗所需最低兽魂：");
                    break;

                case Preset.WAR_AoE_InnerRelease:
                    DrawSliderInt(0, 75, WAR_AoE_IRStop,
                        "目标血量低于设定值时停止使用。\n如需禁用此功能，请设为0");
                    break;


                case Preset.WAR_AoE_Infuriate:
                    DrawSliderInt(0, 2, WAR_AoE_Infuriate_Charges,
                        "保留多少层数？（0 = 全部使用）");
                    DrawSliderInt(0, 50, WAR_AoE_Infuriate_Gauge,
                        "魂量低于等于此值时使用");
                    break;

                case Preset.WAR_AoE_Onslaught:
                    DrawHorizontalRadioButton(WAR_AoE_Onslaught_Movement,
                        "Stationary Only", "Uses Onslaught only while stationary", 0);
                    DrawHorizontalRadioButton(WAR_AoE_Onslaught_Movement,
                        "Any Movement", "Uses Onslaught regardless of any movement conditions.\nNOTE: This could possibly get you killed", 1);
                    ImGui.Spacing();
                    if (WAR_AoE_Onslaught_Movement == 0)
                    {
                        ImGui.SetCursorPosX(48);
                        DrawSliderFloat(0, 3, WAR_AoE_Onslaught_TimeStill,
                            "站立检测延迟（秒）：", decimals: 1);
                    }
                    DrawSliderInt(0, 2, WAR_AoE_Onslaught_Charges,
                        "保留多少层数？（0 = 全部使用）");
                    ImGui.SetCursorPosX(48);
                    DrawSliderFloat(1, 20, WAR_AoE_Onslaught_Distance,
                        "与目标距离小于等于此值时使用：", decimals: 1);
                    break;

                case Preset.WAR_AoE_PrimalRend:
                    DrawHorizontalRadioButton(WAR_AoE_PrimalRend_EarlyLate,
                        "尽早", "尽快使用蛮荒崩裂", 0);
                    DrawHorizontalRadioButton(WAR_AoE_PrimalRend_EarlyLate,
                        "延后", "在消耗完所有蛮荒崩裂层数后再使用蛮荒崩裂", 1);
                    ImGui.NewLine();
                    DrawHorizontalRadioButton(WAR_AoE_PrimalRend_Movement,
                        "仅在站立时", "仅在站立时使用蛮荒崩裂", 0);
                    DrawHorizontalRadioButton(WAR_AoE_PrimalRend_Movement,
                        "任意移动", "无论移动状态均可使用蛮荒崩裂。\n注意：这可能导致你死亡", 1);
                    ImGui.Spacing();
                    if (WAR_AoE_PrimalRend_Movement == 0)
                    {
                        ImGui.SetCursorPosX(48);
                        DrawSliderFloat(0, 3, WAR_AoE_PrimalRend_TimeStill,
                            "站立检测延迟（秒）：", decimals: 1);
                    }
                    ImGui.SetCursorPosX(48);
                    DrawSliderFloat(1, 20, WAR_AoE_PrimalRend_Distance,
                        "与目标距离小于等于此值时使用：", decimals: 1);
                    break;

                case Preset.WAR_AoE_Orogeny:
                    DrawHorizontalRadioButton(WAR_AoE_OrogenyUpheaval,
                        "包含动乱", "若山崩不可用则在AOE循环中启用动乱", 0);
                    DrawHorizontalRadioButton(WAR_AoE_OrogenyUpheaval,
                        "不包含动乱", "在AOE循环中禁用动乱", 1);
                    break;

                #endregion

                #region One-Button Mitigation

                case Preset.WAR_Mit_Holmgang_Max:
                    DrawDifficultyMultiChoice(WAR_Mit_Holmgang_Max_Difficulty, WAR_Mit_Holmgang_Max_DifficultyListSet,
                        "Select what difficulties Holmgang should be used in:");

                    DrawSliderInt(1, 100, WAR_Mit_Holmgang_Health,
                        "Player HP% to be less than or equal to:", 200, SliderIncrements.Fives);
                    break;

                case Preset.WAR_Mit_Bloodwhetting:
                    DrawSliderInt(1, 100, WAR_Mit_Bloodwhetting_Health,
                        "HP% to use at or below", sliderIncrement: SliderIncrements.Ones);

                    DrawPriorityInput(WAR_Mit_Priorities, NumMitigationOptions, 0,
                        "Bloodwhetting Priority:");
                    break;

                case Preset.WAR_Mit_Equilibrium:
                    DrawSliderInt(1, 100, WAR_Mit_Equilibrium_Health,
                        "HP% to use at or below", sliderIncrement: SliderIncrements.Ones);

                    DrawPriorityInput(WAR_Mit_Priorities, NumMitigationOptions, 1,
                        "Equilibrium Priority:");
                    break;

                case Preset.WAR_Mit_Reprisal:
                    DrawPriorityInput(WAR_Mit_Priorities, NumMitigationOptions, 2,
                        "Reprisal Priority:");
                    break;

                case Preset.WAR_Mit_ThrillOfBattle:
                    DrawSliderInt(1, 100, WAR_Mit_ThrillOfBattle_Health,
                        "HP% to use at or below (100 = Disable check)", sliderIncrement: SliderIncrements.Ones);

                    DrawPriorityInput(WAR_Mit_Priorities, NumMitigationOptions, 3,
                        "Thrill Of Battle Priority:");
                    break;

                case Preset.WAR_Mit_Rampart:
                    DrawPriorityInput(WAR_Mit_Priorities, NumMitigationOptions, 4,
                        "Rampart Priority:");
                    break;

                case Preset.WAR_Mit_ShakeItOff:
                    ImGui.Indent();
                    DrawHorizontalRadioButton(WAR_Mit_ShakeItOff_PartyRequirement,
                        "需要队伍", "只有队伍成员数大于等于2时才会使用摆脱。",
                        (int)PartyRequirement.Yes);
                    DrawHorizontalRadioButton(WAR_Mit_ShakeItOff_PartyRequirement,
                        "总是使用", "使用摆脱时不要求有队伍。",
                        (int)PartyRequirement.No);
                    ImGui.Unindent();
                    DrawPriorityInput(WAR_Mit_Priorities, NumMitigationOptions, 5,
                        "摆脱优先级：");
                    break;

                case Preset.WAR_Mit_ArmsLength:
                    ImGui.Indent();
                    DrawHorizontalRadioButton(WAR_Mit_ArmsLength_Boss,
                        "所有敌人", "无论敌人类型均会使用亲疏自行。",
                        (int)BossAvoidance.Off, 125f);
                    DrawHorizontalRadioButton(WAR_Mit_ArmsLength_Boss,
                        "避免Boss", "Boss战时尽量不使用亲疏自行。",
                        (int)BossAvoidance.On, 125f);
                    ImGui.Unindent();
                    DrawSliderInt(0, 5, WAR_Mit_ArmsLength_EnemyCount,
                        "附近需要多少敌人？（0=无要求）");
                    DrawPriorityInput(WAR_Mit_Priorities, NumMitigationOptions, 6, "亲疏自行优先级：");
                    break;

                case Preset.WAR_Mit_Vengeance:
                    DrawPriorityInput(WAR_Mit_Priorities, NumMitigationOptions, 7, "复仇优先级：");
                    break;

                #endregion

                #region Other

                case Preset.WAR_FC_InnerRelease:
                    DrawSliderInt(0, 75, WAR_FC_IRStop,
                        "目标血量低于设定值时停止使用。\n如需禁用此功能，请设为0");
                    break;

                case Preset.WAR_FC_Onslaught:
                    DrawHorizontalRadioButton(WAR_FC_Onslaught_Movement,
                        "仅在站立时", "仅在站立时使用猛攻", 0);
                    DrawHorizontalRadioButton(WAR_FC_Onslaught_Movement,
                        "任意移动", "无论移动状态均可使用猛攻。\n注意：这可能导致你死亡", 1);
                    ImGui.Spacing();
                    if (WAR_FC_Onslaught_Movement == 0)
                    {
                        ImGui.SetCursorPosX(48);
                        DrawSliderFloat(0, 3, WAR_FC_Onslaught_TimeStill,
                            " Stationary Delay Check (in seconds):", decimals: 1);
                    }
                    DrawSliderInt(0, 2, WAR_FC_Onslaught_Charges,
                        " How many charges to keep ready? (0 = Use All)");
                    ImGui.SetCursorPosX(48);
                    DrawSliderFloat(1, 20, WAR_FC_Onslaught_Distance,
                        " Use when Distance from target is less than or equal to:", decimals: 1);
                    break;

                case Preset.WAR_FC_Infuriate:
                    DrawSliderInt(0, 2, WAR_FC_Infuriate_Charges,
                        " How many charges to keep ready? (0 = Use All)");
                    DrawSliderInt(0, 50, WAR_FC_Infuriate_Gauge,
                        " Use when Beast Gauge is less than or equal to:");
                    break;

                case Preset.WAR_FC_PrimalRend:
                    DrawHorizontalRadioButton(WAR_FC_PrimalRend_EarlyLate,
                        "Early", "Uses Primal Rend ASAP", 0);
                    DrawHorizontalRadioButton(WAR_FC_PrimalRend_EarlyLate,
                        "Late", "Uses Primal Rend after consumption of all Inner Release stacks", 1);
                    ImGui.NewLine();
                    DrawHorizontalRadioButton(WAR_FC_PrimalRend_Movement,
                        "Stationary Only", "Uses Primal Rend only while stationary", 0);
                    DrawHorizontalRadioButton(WAR_FC_PrimalRend_Movement,
                        "Any Movement", "Uses Primal Rend regardless of any movement conditions.\nNOTE: This could possibly get you killed", 1);
                    ImGui.Spacing();
                    if (WAR_FC_PrimalRend_Movement == 0)
                    {
                        ImGui.SetCursorPosX(48);
                        DrawSliderFloat(0, 3, WAR_FC_PrimalRend_TimeStill,
                            " Stationary Delay Check (in seconds):", decimals: 1);
                    }
                    ImGui.SetCursorPosX(48);
                    DrawSliderFloat(1, 20, WAR_FC_PrimalRend_Distance,
                        " Use when Distance from target is less than or equal to:", decimals: 1);
                    break;

                

                case Preset.WAR_InfuriateFellCleave:
                    DrawSliderInt(0, 2, WAR_Infuriate_Charges,
                        " How many charges to keep ready? (0 = Use All)");
                    DrawSliderInt(0, 50, WAR_Infuriate_Range,
                        " Use when Beast Gauge is\n less than or equal to:");
                    break;

                case Preset.WAR_EyePath:
                    DrawSliderInt(0, 30, WAR_EyePath_Refresh,
                        $" Seconds remaining before refreshing {Buffs.SurgingTempest.StatusName()} buff:");
                    break;

                case Preset.WAR_RawIntuition_Targeting_TT:
                    ImGui.Indent();
                    ImGuiEx.TextWrapped(ImGuiColors.DalamudGrey,
                        "注意：如果你是副T，并且希望将原初的血气用于自己，建议通过一键减伤功能或你的循环中的减伤选项来实现。\n" +
                        "你也可以在队伍中鼠标悬停自己来使用原初的血气或原初的直觉。\n" +
                        "如果你不这样做，原初的勇猛会替换该连击，并施放到主T身上。\n" +
                        "如果你不使用这些功能来进行个人减伤，建议不要启用此选项。");
                    ImGui.Unindent();
                    break;
                
                case Preset.WAR_ArmsLengthLockout:
                    DrawSliderInt(0, 5, WAR_ArmsLengthLockout_Time, "Time (In Seconds) remaining on Inner Strength to Lock out Arm's Length until.");
                    break;

                    #endregion
            }
        }

        #region Variables

        private const int NumMitigationOptions = 8;
        public static UserInt
            WAR_ST_MitsOptions = new("WAR_ST_MitsOptions"),
            WAR_AoE_MitsOptions = new("WAR_AoE_MitsOptions"),
            WAR_ST_Advanced_MitsOptions = new("WAR_ST_Advanced_MitsOptions"),
            WAR_AoE_Advanced_MitsOptions = new("WAR_AoE_Advanced_MitsOptions"),
            WAR_Mitigation_NonBoss_ShakeItOff_Health = new("WAR_Mitigation_NonBoss_ShakeItOff_Health", 80),
            WAR_Mitigation_NonBoss_Equilibrium_Health = new("WAR_Mitigation_NonBoss_Equilibrium_Health", 50),
            WAR_Mitigation_NonBoss_Holmgang_Health = new("WAR_Mitigation_NonBoss_Holmgang_Health", 20),
            WAR_Mitigation_Boss_RawIntuition_Health = new("WAR_Mitigation_Boss_RawIntuition_Health", 99),
            WAR_Mitigation_Boss_Equilibrium_Health = new("WAR_Mitigation_Boss_Equilibrium_Health", 30),
            WAR_Mitigation_Boss_Tankbuster_Equilibrium_Health = new("WAR_Mitigation_Boss_Tankbuster_Equilibrium_Health", 80),
            WAR_Infuriate_Charges = new("WAR_Infuriate_Charges"),
            WAR_Infuriate_Range = new("WAR_Infuriate_Range"),
            WAR_SurgingRefreshRange = new("WAR_SurgingRefreshRange", 10),
            WAR_EyePath_Refresh = new("WAR_EyePath", 10),
            WAR_ST_Infuriate_Charges = new("WAR_ST_Infuriate_Charges"),
            WAR_ST_Infuriate_Gauge = new("WAR_ST_Infuriate_Gauge", 40),
            WAR_ST_FellCleave_Gauge = new("WAR_ST_FellCleave_Gauge", 90),
            WAR_ST_FellCleave_BurstPooling = new("WAR_ST_FellCleave_BurstPooling"),
            WAR_ST_Onslaught_Charges = new("WAR_ST_Onslaught_Charges"),
            WAR_ST_Onslaught_Movement = new("WAR_ST_Onslaught_Movement"),
            WAR_ST_PrimalRend_Movement = new("WAR_ST_PrimalRend_Movement"),
            WAR_ST_PrimalRend_EarlyLate = new("WAR_ST_PrimalRend_EarlyLate"),
            
            WAR_ST_IRStop = new("WAR_ST_IRStop"),
            WAR_AoE_Infuriate_Charges = new("WAR_AoE_Infuriate_Charges"),
            WAR_AoE_Infuriate_Gauge = new("WAR_AoE_Infuriate_Gauge", 40),
            WAR_AoE_Decimate_Gauge = new("WAR_AoE_Decimate_Gauge", 90),
            WAR_AoE_Decimate_BurstPooling = new("WAR_AoE_Decimate_BurstPooling"),
            WAR_AoE_Onslaught_Charges = new("WAR_AoE_Onslaught_Charges"),
            WAR_AoE_Onslaught_Movement = new("WAR_AoE_Onslaught_Movement"),
            WAR_AoE_PrimalRend_Movement = new("WAR_AoE_PrimalRend_Movement"),
            WAR_AoE_PrimalRend_EarlyLate = new("WAR_AoE_PrimalRend_EarlyLate"),
            WAR_AoE_OrogenyUpheaval = new("WAR_AoE_OrogenyUpheaval"),
            
            WAR_AoE_IRStop = new("WAR_AoE_IRStop"),
            WAR_BalanceOpener_Content = new("WAR_BalanceOpener_Content", 1),
            WAR_FC_IRStop = new("WAR_FC_IRStop"),
            WAR_FC_Infuriate_Charges = new("WAR_FC_Infuriate_Charges"),
            WAR_FC_Infuriate_Gauge = new("WAR_FC_Infuriate_Gauge", 40),
            WAR_FC_Onslaught_Charges = new("WAR_FC_Onslaught_Charges"),
            WAR_FC_Onslaught_Movement = new("WAR_FC_Onslaught_Movement"),
            WAR_FC_PrimalRend_Movement = new("WAR_FC_PrimalRend_Movement"),
            WAR_FC_PrimalRend_EarlyLate = new("WAR_FC_PrimalRend_EarlyLate"),
            WAR_Mit_Holmgang_Health = new("WAR_Mit_Holmgang_Health", 20),
            WAR_Mit_Bloodwhetting_Health = new("WAR_Mit_Bloodwhetting_Health", 70),
            WAR_Mit_Equilibrium_Health = new("WAR_Mit_Equilibrium_Health", 45),
            WAR_Mit_ThrillOfBattle_Health = new("WAR_Mit_ThrillOfBattle_Health", 60),
            WAR_Mit_ShakeItOff_PartyRequirement = new("WAR_Mit_ShakeItOff_PartyRequirement", (int)PartyRequirement.Yes),
            WAR_Mit_ArmsLength_Boss = new("WAR_Mit_ArmsLength_Boss", (int)BossAvoidance.On),
            WAR_Mit_ArmsLength_EnemyCount = new("WAR_Mit_ArmsLength_EnemyCount"),
            WAR_ArmsLengthLockout_Time = new("WAR_ArmsLengthLockout_Time", 3);

        public static UserFloat
            WAR_Mitigation_NonBoss_MitigationThreshold = new("WAR_Mitigation_NonBoss_MitigationThreshold", 20f),
            WAR_Mitigation_Boss_ThrillOfBattle_Threshold = new("WAR_Mitigation_Boss_ThrillOfBattle_Threshold", 20f),
            WAR_ST_Onslaught_Distance = new("WAR_ST_Ons_Distance", 3.0f),
            WAR_ST_PrimalRend_Distance = new("WAR_ST_PR_Distance", 3.0f),
            WAR_AoE_Onslaught_Distance = new("WAR_AoE_Ons_Distance", 3.0f),
            WAR_AoE_PrimalRend_Distance = new("WAR_AoE_PR_Distance", 3.0f),
            WAR_FC_Onslaught_Distance = new("WAR_FC_Ons_Distance", 3.0f),
            WAR_FC_PrimalRend_Distance = new("WAR_FC_PR_Distance", 3.0f),
            WAR_ST_Onslaught_TimeStill = new("WAR_ST_Onslaught_TimeStill"),
            WAR_ST_PrimalRend_TimeStill = new("WAR_ST_PrimalRend_TimeStill"),
            WAR_AoE_Onslaught_TimeStill = new("WAR_AoE_Onslaught_TimeStill"),
            WAR_AoE_PrimalRend_TimeStill = new("WAR_AoE_PrimalRend_TimeStill"),
            WAR_FC_Onslaught_TimeStill = new("WAR_FC_Onslaught_TimeStill"),
            WAR_FC_PrimalRend_TimeStill = new("WAR_FC_PrimalRend_TimeStill");

        public static UserBool
            WAR_Mitigation_Boss_ThrillOfBattle_Align = new("WAR_Mitigation_Boss_ThrillOfBattle_Align", true),
            WAR_Mitigation_Boss_Vengeance_First = new("WAR_Mitigation_Boss_Vengeance_First", true);

        public static UserIntArray
            WAR_Mit_Priorities = new("WAR_Mit_Priorities");

       public static UserBoolArray
            WAR_Mitigation_Boss_RawIntuition_OnCD_Difficulty = new("WAR_Mitigation_Boss_RawIntuition_Difficulty", [true, false]),
            WAR_Mitigation_Boss_RawIntuition_TankBuster_Difficulty = new("WAR_Mitigation_Boss_RawIntuition_TankBuster_Difficulty", [true, false]),
            WAR_Mitigation_Boss_Rampart_Difficulty = new("WAR_Mitigation_Boss_Rampart_Difficulty", [true, false]),
            WAR_Mitigation_Boss_Vengeance_Difficulty = new("WAR_Mitigation_Boss_Vengeance_Difficulty", [true, false]),
            WAR_Mitigation_Boss_ThrillOfBattle_Difficulty = new("WAR_Mitigation_Boss_ThrillOfBattle_Difficulty", [true, false]),
            WAR_Mitigation_Boss_ShakeItOff_Difficulty = new("WAR_Mitigation_Boss_ShakeItOff_Difficulty", [true, false]),
            WAR_Mitigation_Boss_Reprisal_Difficulty = new("WAR_Mitigation_Boss_Reprisal_Difficulty", [true, false]),
            WAR_Mit_Holmgang_Max_Difficulty = new("WAR_Mit_Holmgang_Max_Difficulty", [true, false]);

        public static readonly ContentCheck.ListSet
            WAR_Mit_Holmgang_Max_DifficultyListSet = ContentCheck.ListSet.CasualVSHard,
            WAR_Boss_Mit_DifficultyListSet = ContentCheck.ListSet.CasualVSHard;

        #endregion
    }
}
