using System;
using Dalamud.Interface.Components;
using Dalamud.Interface.Utility.Raii;
using ECommons;
using ECommons.DalamudServices;
using ECommons.ImGuiMethods;
using ImGuiNET;
using Lumina.Excel.Sheets;
using System.Linq;
using WrathCombo.Combos.PvE;
using WrathCombo.Extensions;
using WrathCombo.Services;
using WrathCombo.Services.IPC;
using WrathCombo.Services.IPC_Subscriber;

namespace WrathCombo.Window.Tabs
{
    internal class AutoRotationTab : ConfigWindow
    {
        private static uint _selectedNpc = 0;
        internal static new void Draw()
        {
            ImGui.TextWrapped($"你可以在此处配置自动循环操作参数。" +
                $"带有“加入自动循环”复选框的功能可用于自动循环。");
            ImGui.Separator();

            var cfg = Service.Configuration.RotationConfig;
            bool changed = false;

            if (P.UIHelper.ShowIPCControlledIndicatorIfNeeded())
                changed |= P.UIHelper.ShowIPCControlledCheckboxIfNeeded(
                    "Enable Auto-Rotation", ref cfg.Enabled);
            else
                changed |= ImGui.Checkbox($"启用自动循环", ref cfg.Enabled);
            if (P.IPC.GetAutoRotationState())
            {
                var inCombatOnly = (bool)P.IPC.GetAutoRotationConfigState(
                    Enum.Parse<AutoRotationConfigOption>("InCombatOnly"))!;
                ImGuiExtensions.Prefix(!inCombatOnly);
                changed |= P.UIHelper.ShowIPCControlledCheckboxIfNeeded(
                    "仅在战斗中", ref cfg.InCombatOnly, "InCombatOnly");

                if (inCombatOnly)
                {
                    ImGuiExtensions.Prefix(false);
                    changed |= ImGui.Checkbox($"对任务目标绕过仅在战斗中的限制", ref cfg.BypassQuest);
                    ImGuiComponents.HelpMarker("在战斗外禁用自动模式，除非你在任务目标的范围内。");

                    ImGuiExtensions.Prefix(false);
                    changed |= ImGui.Checkbox($"对FATE目标绕过仅在战斗中的限制", ref cfg.BypassFATE);
                    ImGuiComponents.HelpMarker("在战斗外禁用自动模式，除非你同步到FATE。");

                    ImGuiExtensions.Prefix(true);
                    ImGuiEx.SetNextItemWidthScaled(100);
                    changed |= ImGui.InputInt("战斗开始后激活自动循环的延迟（秒）", ref cfg.CombatDelay);

                    if (cfg.CombatDelay < 0)
                        cfg.CombatDelay = 0;
                }
            }

            changed |= ImGui.Checkbox("在副本中自动启用", ref cfg.EnableInInstance);
            changed |= ImGui.Checkbox("离开副本后禁用", ref cfg.DisableAfterInstance);

            if (ImGui.CollapsingHeader("伤害设置"))
            {
                ImGuiEx.TextUnderlined($"目标选择模式");

                P.UIHelper.ShowIPCControlledIndicatorIfNeeded("DPSRotationMode");
                changed |= P.UIHelper.ShowIPCControlledComboIfNeeded(
                    "###DPSTargetingMode", true, ref cfg.DPSRotationMode,
                    ref cfg.HealerRotationMode, "DPSRotationMode");

                ImGuiComponents.HelpMarker("Manual - Leaves all targeting decisions to you.\n" +
                    "Highest Max - Prioritises enemies with the highest max HP.\n" +
                    "Lowest Max - Prioritises enemies with the lowest max HP.\n" +
                    "Highest Current - Prioritises the enemy with the highest current HP.\n" +
                    "Lowest Current - Prioritises the enemy with the lowest current HP.\n" +
                    "Tank Target - Prioritises the same target as the first tank in your group.\n" +
                    "Nearest - Prioritises the closest target to you.\n" +
                    "Furthest - Prioritises the furthest target from you.");
                ImGuiComponents.HelpMarker("手动 - 所有目标选择由你决定。\n" +
                    "最高最大生命值 - 优先选择最大生命值最高的敌人。\n" +
                    "最低最大生命值 - 优先选择最大生命值最低的敌人。\n" +
                    "最高当前生命值 - 优先选择当前生命值最高的敌人。\n" +
                    "最低当前生命值 - 优先选择当前生命值最低的敌人。\n" +
                    "坦克目标 - 优先选择与你队伍中第一个坦克相同的目标。\n" +
                    "最近 - 优先选择离你最近的敌人。\n" +
                    "最远 - 优先选择离你最远的敌人。");
                ImGui.Spacing();

                if (cfg.DPSRotationMode == AutoRotation.DPSRotationMode.Manual)
                {
                    changed |= ImGui.Checkbox("强制执行最佳多目标选择", ref cfg.DPSSettings.AoEIgnoreManual);

                    ImGuiComponents.HelpMarker("对于所有其他目标选择模式，AoE 将基于命中目标数量最多的敌人进行选择。在手动模式下，只有勾选此框时才会启用此行为。");
                }

                var input = ImGuiEx.InputInt(100f.Scale(), "需要的目标数量以启用AoE伤害功能", ref cfg.DPSSettings.DPSAoETargets);
                if (input)
                {
                    changed |= input;
                    if (cfg.DPSSettings.DPSAoETargets < 0)
                        cfg.DPSSettings.DPSAoETargets = 0;
                }
                ImGuiComponents.HelpMarker($"禁用此选项将关闭AoE伤害功能。启用则需要在AoE技能攻击范围内的目标数量达到此值时才会使用。此设置适用于所有三种职能，并且适用于任何造成AoE伤害的技能。");

                ImGuiEx.SetNextItemWidthScaled(100);
                changed |= ImGui.SliderFloat("最大目标距离", ref cfg.DPSSettings.MaxDistance, 1, 30);
                cfg.DPSSettings.MaxDistance =
                    Math.Clamp(cfg.DPSSettings.MaxDistance, 1, 30);

                ImGuiComponents.HelpMarker("所有目标选择模式（手动模式除外）搜索目标的最大距离。取值范围仅限1到30。");

                P.UIHelper.ShowIPCControlledIndicatorIfNeeded("FATEPriority");
                changed |= P.UIHelper.ShowIPCControlledCheckboxIfNeeded(
                    "优先选择FATE目标", ref cfg.DPSSettings.FATEPriority, "FATEPriority");
                P.UIHelper.ShowIPCControlledIndicatorIfNeeded("FATEPriority");
                changed |= P.UIHelper.ShowIPCControlledCheckboxIfNeeded(
                    "优先选择任务目标", ref cfg.DPSSettings.QuestPriority, "QuestPriority");
                changed |= ImGui.Checkbox($"优先选择未进入战斗的目标", ref cfg.DPSSettings.PreferNonCombat);

                if (cfg.DPSSettings.PreferNonCombat && changed)
                    cfg.DPSSettings.OnlyAttackInCombat = false;

                changed |= P.UIHelper.ShowIPCControlledCheckboxIfNeeded(
                    "仅攻击已进入战斗的目标", ref cfg.DPSSettings.OnlyAttackInCombat,
                    "OnlyAttackInCombat");

                if (cfg.DPSSettings.OnlyAttackInCombat && changed)
                    cfg.DPSSettings.PreferNonCombat = false;

                changed |= ImGui.Checkbox("无论什么技能，始终选择目标", ref cfg.DPSSettings.AlwaysSelectTarget);

                ImGuiComponents.HelpMarker("通常情况下，自动循环只会在下一个需要目标的技能触发时选择敌人。此选项将改变行为，使其无论技能是否需要目标都会始终选择目标。");


                var npcs = Service.Configuration.IgnoredNPCs.ToList();
                var selected = npcs.FirstOrNull(x => x.Key == _selectedNpc);
                var prev = selected is null ? "" : $"{Svc.Data.Excel.GetSheet<BNpcName>().GetRow(selected.Value.Value).Singular} (ID: {selected.Value.Key})";
                ImGuiEx.TextUnderlined($"忽略的NPC");
                using (var combo = ImRaii.Combo("###Ignore", prev))
                {
                    if (combo)
                    {
                        if (ImGui.Selectable(""))
                        {
                            _selectedNpc = 0;
                        }

                        foreach (var npc in npcs)
                        {
                            var npcData = Svc.Data.Excel
                                .GetSheet<BNpcName>().GetRow(npc.Value);
                            if (ImGui.Selectable($"{npcData.Singular} (ID: {npc.Key})"))
                            {
                                _selectedNpc = npc.Key;
                            }
                        }
                    }
                }
                ImGuiComponents.HelpMarker("这些NPC将被自动循环忽略。\n" +
                                           "此NPC的所有实例都将被排除在自动目标选择之外（手动模式仍然有效）。\n" +
                                           "要从列表中删除NPC，请选择它并点击下方的删除按钮。\n" +
                                           "要将NPC添加到列表中，请选中NPC并使用命令：/wrath ignore");

                if (_selectedNpc > 0)
                {
                    if (ImGui.Button("从忽略列表中删除"))
                    {
                        Service.Configuration.IgnoredNPCs.Remove(_selectedNpc);
                        Service.Configuration.Save();

                        _selectedNpc = 0;
                    }
                }

            }
            ImGui.Spacing();
            if (ImGui.CollapsingHeader("治疗设置"))
            {
                ImGuiEx.TextUnderlined($"治疗目标选择模式");
                P.UIHelper.ShowIPCControlledIndicatorIfNeeded("HealerRotationMode");
                changed |= P.UIHelper.ShowIPCControlledComboIfNeeded(
                    "###HealerTargetingMode", false, ref cfg.DPSRotationMode,
                    ref cfg.HealerRotationMode, "HealerRotationMode");
                ImGuiComponents.HelpMarker("手动模式 - 只有当你手动选择目标时才会进行治疗。如果目标不符合下方治疗阈值条件，将跳过治疗优先进行DPS输出（如果启用了DPS功能）。\n" +
                    "最高当前生命值 - 优先选择当前生命值百分比最高的队员。\n" +
                    "最高当前生命值 - 优先选择当前生命值百分比最低的队员。");

                P.UIHelper.ShowIPCControlledIndicatorIfNeeded("SingleTargetHPP");
                changed |= P.UIHelper.ShowIPCControlledSliderIfNeeded(
                    "单体治疗生命值百分比阈值", ref cfg.HealerSettings.SingleTargetHPP, "SingleTargetHPP");

                P.UIHelper.ShowIPCControlledIndicatorIfNeeded("SingleTargetRegenHPP");
                changed |= P.UIHelper.ShowIPCControlledSliderIfNeeded(
                    "单体治疗生命值百分比阈值（目标有再生/吉星相位）", ref cfg.HealerSettings.SingleTargetRegenHPP, "SingleTargetRegenHPP");
                ImGuiComponents.HelpMarker("通常你希望将此设置为比上面的设置低。");

                P.UIHelper.ShowIPCControlledIndicatorIfNeeded("AoETargetHPP");
                changed |= P.UIHelper.ShowIPCControlledSliderIfNeeded(
                    "群体治疗生命值百分比阈值", ref cfg.HealerSettings.AoETargetHPP, "AoETargetHPP");

                var input = ImGuiEx.InputInt(100f.Scale(), "启用群体治疗功能所需的目标数量", ref cfg.HealerSettings.AoEHealTargetCount);
                if (input)
                {
                    changed |= input;
                    if (cfg.HealerSettings.AoEHealTargetCount < 0)
                        cfg.HealerSettings.AoEHealTargetCount = 0;
                }
                ImGuiComponents.HelpMarker($"禁用此选项将关闭群体治疗功能。启用则需要在群体治疗技能范围内的目标数量达到此值时才会使用。");
                ImGuiEx.SetNextItemWidthScaled(100);
                changed |= ImGui.InputInt("满足上述条件后开始治疗的延迟（秒）", ref cfg.HealerSettings.HealDelay);

                if (cfg.HealerSettings.HealDelay < 0)
                    cfg.HealerSettings.HealDelay = 0;
                ImGuiComponents.HelpMarker("不要设置得太高！通常1-2秒的延迟更像真人反应速度。");

                ImGui.Spacing();

                P.UIHelper.ShowIPCControlledIndicatorIfNeeded("AutoRez");
                changed |= P.UIHelper.ShowIPCControlledCheckboxIfNeeded(
                    "自动复活", ref cfg.HealerSettings.AutoRez, "AutoRez");
                ImGuiComponents.HelpMarker($"将尝试复活死亡的队员。适用于 {WHM.ClassID.JobAbbreviation()}、{WHM.JobID.JobAbbreviation()}、{SCH.JobID.JobAbbreviation()}、{AST.JobID.JobAbbreviation()}、{SGE.JobID.JobAbbreviation()}");
                var autoRez = (bool)P.IPC.GetAutoRotationConfigState(AutoRotationConfigOption.AutoRez)!;
                if (autoRez)
                {
                    ImGuiExtensions.Prefix(false);
                    changed |= ImGui.Checkbox("需要即刻咏唱/双重咏唱", ref
                        cfg.HealerSettings.AutoRezRequireSwift);
                    ImGuiComponents.HelpMarker(
                        $"需要{MagicRole.Swiftcast.ActionName()} " +
                        $"（或赤魔的连续咏唱） " +
                        $"可用来复活队员，以避免硬读条。");

                    ImGuiExtensions.Prefix(true);
                    P.UIHelper.ShowIPCControlledIndicatorIfNeeded("AutoRezDPSJobs");
                    changed |= P.UIHelper.ShowIPCControlledCheckboxIfNeeded(
                        $"适用于 {SMN.JobID.JobAbbreviation()} 和 {RDM.JobID.JobAbbreviation()}", ref cfg.HealerSettings.AutoRezDPSJobs, "AutoRezDPSJobs");
                    ImGuiComponents.HelpMarker($"当作为 {SMN.JobID.JobAbbreviation()} 或 {RDM.JobID.JobAbbreviation()} 时，也会尝试复活队员。{RDM.JobID.JobAbbreviation()} 只有在 {MagicRole.Buffs.Swiftcast.StatusName()} 或 {RDM.Buffs.Dualcast.StatusName()} 激活时才会复活。");
                }

                P.UIHelper.ShowIPCControlledIndicatorIfNeeded("AutoCleanse");
                changed |= P.UIHelper.ShowIPCControlledCheckboxIfNeeded(
                    $"自动使用-{Healer.Esuna.ActionName()}", ref cfg.HealerSettings.AutoCleanse, "AutoCleanse");
                ImGuiComponents.HelpMarker($"将使用 {Healer.Esuna.ActionName()} 清除任何可清除的减益效果（治疗优先）。");

                P.UIHelper.ShowIPCControlledIndicatorIfNeeded("ManageKardia");
                changed |= P.UIHelper.ShowIPCControlledCheckboxIfNeeded(
                    $"[贤者] 自动管理心关", ref cfg.HealerSettings.ManageKardia, "ManageKardia");
                ImGuiComponents.HelpMarker($"将 {SGE.Kardia.ActionName()} 切换到当前被敌人攻击的队员，如果有多人被攻击优先考虑防护职业。");
                if (cfg.HealerSettings.ManageKardia)
                {
                    ImGuiExtensions.Prefix(cfg.HealerSettings.ManageKardia);
                    changed |= ImGui.Checkbox($"仅限于在防护职业间切换 {SGE.Kardia.ActionName()}", ref cfg.HealerSettings.KardiaTanksOnly);
                }

                changed |= ImGui.Checkbox($"[白魔/占星] 预先对焦点目标应用持续治疗", ref cfg.HealerSettings.PreEmptiveHoT);
                ImGuiComponents.HelpMarker($"在战斗外，当你的焦点目标距离敌人30米或更近时，应用[{WHM.Regen.ActionName()}/{AST.AspectedBenefic.ActionName()}]。 （将绕过“仅在战斗中”设置）");

                P.UIHelper.ShowIPCControlledIndicatorIfNeeded("IncludeNPCs");
                changed |= P.UIHelper.ShowIPCControlledCheckboxIfNeeded("治疗友方NPC", ref cfg.HealerSettings.IncludeNPCs);
                ImGuiComponents.HelpMarker("对于需要治疗但未直接加入你队伍的NPC任务很有用。");

            }

            ImGuiEx.TextUnderlined("高级");
            changed |= ImGui.InputInt("节流延迟（毫秒）", ref cfg.Throttler);
            ImGuiComponents.HelpMarker("自动循环内置了一个节流器，每隔一定毫秒数运行一次以提高性能。如果你遇到帧率问题，请尝试增加此值。请注意，这可能会导致卡CD，因此请尝试调整此值。");

            using (ImRaii.Disabled(!OrbwalkerIPC.IsEnabled))
            {
                changed |= ImGui.Checkbox($"启用Orbwalker集成", ref cfg.OrbwalkerIntegration);

                ImGuiComponents.HelpMarker($"这将使自动循环在移动时使用有施法时间的技能，因为Orbwalker将在施法期间锁定移动。");
            }

            if (changed)
                Service.Configuration.Save();

        }
    }
}
