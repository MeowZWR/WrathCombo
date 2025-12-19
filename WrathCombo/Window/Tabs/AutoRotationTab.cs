using Dalamud.Interface.Components;
using Dalamud.Interface.Utility.Raii;
using ECommons;
using ECommons.DalamudServices;
using ECommons.ExcelServices;
using ECommons.ImGuiMethods;
using Lumina.Excel.Sheets;
using System;
using System.Linq;
using WrathCombo.Combos.PvE;
using WrathCombo.Extensions;
using WrathCombo.Services;
using WrathCombo.Services.IPC;
using WrathCombo.Services.IPC_Subscriber;
namespace WrathCombo.Window.Tabs;

internal class AutoRotationTab : ConfigWindow
{
    private static uint _selectedNpc = 0;
    internal static new void Draw()
    {
        ImGui.TextWrapped($"这里可以配置一键输出循环的参数。" +
                          $"带有“自动模式”复选框的功能可以与一键输出循环一起使用。");
        ImGui.Separator();

        var cfg = Service.Configuration.RotationConfig;
        bool changed = false;

        if (P.UIHelper.ShowIPCControlledIndicatorIfNeeded())
            changed |= P.UIHelper.ShowIPCControlledCheckboxIfNeeded(
                "启用一键输出循环", ref cfg.Enabled);
        else
            changed |= ImGui.Checkbox($"启用一键输出循环", ref cfg.Enabled);
        if (P.IPC.GetAutoRotationState())
        {
            var inCombatOnly = (bool)P.IPC.GetAutoRotationConfigState(
                Enum.Parse<AutoRotationConfigOption>("InCombatOnly"))!;
            ImGuiExtensions.Prefix(!inCombatOnly);
            changed |= P.UIHelper.ShowIPCControlledCheckboxIfNeeded(
                "仅在战斗中启用", ref cfg.InCombatOnly, "InCombatOnly");

            if (inCombatOnly)
            {
                ImGuiExtensions.Prefix(false);
                changed |= ImGui.Checkbox($"当连击建议使用自用技能时绕过仅战斗限制", ref cfg.BypassBuffs);
                ImGuiComponents.HelpMarker($"许多职业有可在非战斗中使用的技能，例如 {RPR.Soulsow.ActionName()} 或 {MNK.ForbiddenMeditation.ActionName()}。启用此项后可在非战斗中使用这些技能。");

                ImGuiExtensions.Prefix(false);
                changed |= ImGui.Checkbox($"任务目标时绕过仅战斗限制", ref cfg.BypassQuest);
                ImGuiComponents.HelpMarker("除非你在任务目标范围内，否则在非战斗中禁用自动模式。");

                ImGuiExtensions.Prefix(false);
                changed |= ImGui.Checkbox($"对FATE目标绕过仅战斗限制", ref cfg.BypassFATE);
                ImGuiComponents.HelpMarker("除非你同步到FATE，否则在非战斗中禁用自动模式。");

                ImGuiExtensions.Prefix(true);
                ImGuiEx.SetNextItemWidthScaled(100);
                changed |= ImGui.InputInt("进入战斗后延迟启用一键输出循环（秒）", ref cfg.CombatDelay);

                if (cfg.CombatDelay < 0)
                    cfg.CombatDelay = 0;
            }
        }

        changed |= ImGui.Checkbox("副本中自动启用", ref cfg.EnableInInstance);
        changed |= ImGui.Checkbox("离开副本后自动禁用", ref cfg.DisableAfterInstance);

        if (ImGui.CollapsingHeader("输出设置"))
        {
            ImGuiEx.TextUnderlined($"目标选择模式");

            P.UIHelper.ShowIPCControlledIndicatorIfNeeded("DPSRotationMode");
            changed |= P.UIHelper.ShowIPCControlledComboIfNeeded(
                "###DPSTargetingMode", true, ref cfg.DPSRotationMode,
                ref cfg.HealerRotationMode, "DPSRotationMode");

            ImGuiComponents.HelpMarker("手动 - 所有目标选择由你自己决定。（目标没进战斗也开打）\n" +
                                       "最高最大血量 - 优先选择最大血量最高的敌人。\n" +
                                       "最低最大血量 - 优先选择最大血量最低的敌人。\n" +
                                       "当前血量最高 - 优先当前血量最高的敌人。\n" +
                                       "当前血量最低 - 优先当前血量最低的敌人。\n" +
                                       "防护职业目标 - 优先选择与你队伍中第一个防护职业相同的目标。\n" +
                                       "最近 - 优先选择距离你最近的目标。\n" +
                                       "最远 - 优先选择距离你最远的目标。\n" +
                                       "手动非玩家 - 手动选择非玩家目标。");
            ImGui.Spacing();

            if (cfg.DPSRotationMode == AutoRotation.DPSRotationMode.Manual)
            {
                changed |= ImGui.Checkbox("强制选择最佳AOE目标", ref cfg.DPSSettings.AoEIgnoreManual);

                ImGuiComponents.HelpMarker("其他目标模式下，AOE会自动选择命中目标最多的敌人。手动模式下，只有勾选此项才会自动选择。");
            }

                
            P.UIHelper.ShowIPCControlledIndicatorIfNeeded("DPSAoETargets");
            var input = P.UIHelper.ShowIPCControlledNumberInputIfNeeded(
                "触发AOE输出所需目标数", ref cfg.DPSSettings.DPSAoETargets, "DPSAoETargets");
            if (input)
            {
                changed |= input;
                if (cfg.DPSSettings.DPSAoETargets < 0)
                    cfg.DPSSettings.DPSAoETargets = 0;
            }
            ImGuiComponents.HelpMarker($"关闭此项将禁用AOE输出功能。否则需要有足够数量的目标在AOE技能范围内才会使用。适用于所有三种职能，以及所有造成AOE伤害的功能。");

            ImGuiEx.SetNextItemWidthScaled(100);
            changed |= ImGui.SliderFloat("最大目标距离", ref cfg.DPSSettings.MaxDistance, 1, 30);
            cfg.DPSSettings.MaxDistance =
                Math.Clamp(cfg.DPSSettings.MaxDistance, 1, 30);

            ImGuiComponents.HelpMarker("除手动模式外，所有目标模式查找目标的最大距离。仅允许1到30的数值。");

            P.UIHelper.ShowIPCControlledIndicatorIfNeeded("FATEPriority");
            changed |= P.UIHelper.ShowIPCControlledCheckboxIfNeeded(
                "优先FATE目标", ref cfg.DPSSettings.FATEPriority, "FATEPriority");
            P.UIHelper.ShowIPCControlledIndicatorIfNeeded("QuestPriority");
            changed |= P.UIHelper.ShowIPCControlledCheckboxIfNeeded(
                "优先任务目标", ref cfg.DPSSettings.QuestPriority, "QuestPriority");
            changed |= ImGui.Checkbox($"优先未进入战斗的目标", ref cfg.DPSSettings.PreferNonCombat);

            if (cfg.DPSSettings.PreferNonCombat && changed)
                cfg.DPSSettings.OnlyAttackInCombat = false;

            changed |= P.UIHelper.ShowIPCControlledCheckboxIfNeeded(
                "只攻击已进入战斗的目标", ref cfg.DPSSettings.OnlyAttackInCombat,
                "OnlyAttackInCombat");

            if (cfg.DPSSettings.OnlyAttackInCombat && changed)
                cfg.DPSSettings.PreferNonCombat = false;

            changed |= ImGui.Checkbox("无论技能是否需要都始终选中目标", ref cfg.DPSSettings.AlwaysSelectTarget);

            ImGuiComponents.HelpMarker("通常情况下，一键输出循环只会在下一个技能需要目标时才选中敌人。启用此项后，无论技能是否需要目标都会选中。");

            changed |= ImGui.Checkbox("检测到惩罚时取消目标并停止操作", ref cfg.DPSSettings.UnTargetAndDisableForPenalty);

            ImGuiComponents.HelpMarker("如果检测到玩家身上有Pyretic（或类似加速炸弹等）会导致行动受罚的机制时，将取消当前目标并禁用一键输出循环。");

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
            ImGuiComponents.HelpMarker("这些NPC将被一键输出循环忽略。\n" +
                                       "所有该NPC的实例都不会被自动选中（手动模式仍可选中）。\n" +
                                       "要移除NPC，请在下方选择后点击删除按钮。\n" +
                                       "要添加NPC，请选中目标后输入指令：/wrath ignore");

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
            ImGuiComponents.HelpMarker("手动 - 只有你手动选择目标时才会进行治疗。如果目标未达到下方设定的血量阈值，将跳过治疗优先输出（如果已启用）。\n" +
                                       "当前血量最高 - 优先当前血量百分比最高的队友。\n" +
                                       "当前血量最低 - 优先当前血量百分比最低的队友。");

            P.UIHelper.ShowIPCControlledIndicatorIfNeeded("SingleTargetHPP");
            changed |= P.UIHelper.ShowIPCControlledSliderIfNeeded(
                "单体治疗血量阈值（%）", ref cfg.HealerSettings.SingleTargetHPP, "SingleTargetHPP");

            P.UIHelper.ShowIPCControlledIndicatorIfNeeded("SingleTargetRegenHPP");
            changed |= P.UIHelper.ShowIPCControlledSliderIfNeeded(
                "单体治疗血量阈值（目标有再生/吉星相位）", ref cfg.HealerSettings.SingleTargetRegenHPP, "SingleTargetRegenHPP");
            ImGuiComponents.HelpMarker("通常建议此项低于上方设置。");
                
            P.UIHelper.ShowIPCControlledIndicatorIfNeeded("SingleTargetExcogHPP");
            changed |= P.UIHelper.ShowIPCControlledSliderIfNeeded(
                "单体治疗血量阈值（目标有深谋远虑）", ref cfg.HealerSettings.SingleTargetExcogHPP, "SingleTargetExcogHPP");
            ImGuiComponents.HelpMarker("通常建议此项低于上方设置。");

            P.UIHelper.ShowIPCControlledIndicatorIfNeeded("AoETargetHPP");
            changed |= P.UIHelper.ShowIPCControlledSliderIfNeeded(
                "AOE治疗血量阈值（%）", ref cfg.HealerSettings.AoETargetHPP, "AoETargetHPP");

            var input = ImGuiEx.InputInt(100f.Scale(), "触发AOE治疗所需目标数", ref cfg.HealerSettings.AoEHealTargetCount);
            if (input)
            {
                changed |= input;
                if (cfg.HealerSettings.AoEHealTargetCount < 0)
                    cfg.HealerSettings.AoEHealTargetCount = 0;
            }
            ImGuiComponents.HelpMarker($"关闭此项将禁用AOE治疗功能。否则需要有足够数量的目标在AOE治疗技能范围内才会使用。");
            ImGuiEx.SetNextItemWidthScaled(100);
            changed |= ImGui.InputInt("满足条件后延迟开始治疗（秒）", ref cfg.HealerSettings.HealDelay);

            if (cfg.HealerSettings.HealDelay < 0)
                cfg.HealerSettings.HealDelay = 0;
            ImGuiComponents.HelpMarker("不要设置太高！1-2秒通常就足够模拟自然反应。");

            ImGui.Spacing();

            P.UIHelper.ShowIPCControlledIndicatorIfNeeded("AutoRez");
            changed |= P.UIHelper.ShowIPCControlledCheckboxIfNeeded(
                "自动复活", ref cfg.HealerSettings.AutoRez, "AutoRez");
            ImGuiComponents.HelpMarker($"会尝试复活倒地的队友。适用于 {Job.CNJ.Shorthand()}, {Job.WHM.Shorthand()}, {Job.SCH.Shorthand()}, {Job.AST.Shorthand()}, {Job.SGE.Shorthand()} 以及 {OccultCrescent.ContentName} {Svc.Data.GetExcelSheet<MKDSupportJob>().GetRow(10).Name} {OccultCrescent.Revive.ActionName()}");
            var autoRez = (bool)P.IPC.GetAutoRotationConfigState(AutoRotationConfigOption.AutoRez)!;
            if (autoRez)
            {
                ImGuiExtensions.Prefix(false);
                P.UIHelper.ShowIPCControlledIndicatorIfNeeded("AutoRezOutOfParty");
                changed |= P.UIHelper.ShowIPCControlledCheckboxIfNeeded(
                    "应用于非队伍成员", ref cfg.HealerSettings.AutoRezOutOfParty, "AutoRezOutOfParty");

                ImGuiExtensions.Prefix(false);
                changed |= ImGui.Checkbox("需要迅速咏唱/连击咏唱", ref
                    cfg.HealerSettings.AutoRezRequireSwift);
                ImGuiComponents.HelpMarker(
                    $"需要有{RoleActions.Magic.Swiftcast.ActionName()} " +
                    $"（或{Job.RDM.Shorthand()}的连击咏唱）可用时才会复活队友，以避免硬读条。");

                ImGuiExtensions.Prefix(true);
                P.UIHelper.ShowIPCControlledIndicatorIfNeeded("AutoRezDPSJobs");
                changed |= P.UIHelper.ShowIPCControlledCheckboxIfNeeded(
                    $"应用于{Job.SMN.Shorthand()}和{Job.RDM.Shorthand()}", ref cfg.HealerSettings.AutoRezDPSJobs, "AutoRezDPSJobs");
                ImGuiComponents.HelpMarker($"作为{Job.SMN.Shorthand()}或{Job.RDM.Shorthand()}时也会尝试复活队友。{Job.RDM.Shorthand()}仅在有{RoleActions.Magic.Buffs.Swiftcast.StatusName()}或{RDM.Buffs.Dualcast.StatusName()}时复活。");

                if (cfg.HealerSettings.AutoRezDPSJobs)
                {
                    ImGuiExtensions.Prefix(true);
                    P.UIHelper.ShowIPCControlledIndicatorIfNeeded("AutoRezDPSJobsHealersOnly");
                    changed |= P.UIHelper.ShowIPCControlledCheckboxIfNeeded(
                        $"仅复活治疗职业", ref cfg.HealerSettings.AutoRezDPSJobsHealersOnly, "AutoRezDPSJobsHealersOnly");
                    ImGuiComponents.HelpMarker($"作为{Job.SMN.Shorthand()}或{Job.RDM.Shorthand()}时，仅尝试复活治疗职业和复活职业。");
                }
            }

            P.UIHelper.ShowIPCControlledIndicatorIfNeeded("AutoCleanse");
            changed |= P.UIHelper.ShowIPCControlledCheckboxIfNeeded(
                $"自动{RoleActions.Healer.Esuna.ActionName()}", ref cfg.HealerSettings.AutoCleanse, "AutoCleanse");
            ImGuiComponents.HelpMarker($"会自动{RoleActions.Healer.Esuna.ActionName()}可净化的负面状态（治疗优先）。");

            P.UIHelper.ShowIPCControlledIndicatorIfNeeded("ManageKardia");
            changed |= P.UIHelper.ShowIPCControlledCheckboxIfNeeded(
                $"[贤者] 自动切换心关", ref cfg.HealerSettings.ManageKardia, "ManageKardia");
            ImGuiComponents.HelpMarker($"会将{SGE.Kardia.ActionName()}切换给当前被敌人攻击的队友，若有多个则优先防护职业。");
            if (cfg.HealerSettings.ManageKardia)
            {
                ImGuiExtensions.Prefix(cfg.HealerSettings.ManageKardia);
                changed |= ImGui.Checkbox($"仅在防护职业间切换{SGE.Kardia.ActionName()}", ref cfg.HealerSettings.KardiaTanksOnly);
            }

            changed |= ImGui.Checkbox($"[{Job.WHM.Shorthand()}/{Job.AST.Shorthand()}/{Job.SCH.Shorthand()}/{Job.SGE.Shorthand()}] 战斗外预读持续治疗到焦点目标", ref cfg.HealerSettings.PreEmptiveHoT);
            ImGuiComponents.HelpMarker($"当焦点目标在非战斗状态且距离敌人30y以内时，会自动施加{WHM.Regen.ActionName()}/{AST.AspectedBenefic.ActionName()}/{SGE.EukrasianDiagnosis.ActionName()}/{SCH.Adloquium.ActionName()}。（无视“仅在战斗中启用”设置）");

            P.UIHelper.ShowIPCControlledIndicatorIfNeeded("IncludeNPCs");
            changed |= P.UIHelper.ShowIPCControlledCheckboxIfNeeded("治疗友方NPC", ref cfg.HealerSettings.IncludeNPCs);
            ImGuiComponents.HelpMarker("适用于需要治疗NPC但未直接加入队伍的治疗任务。");

        }

        ImGuiEx.TextUnderlined("高级");
        changed |= ImGui.InputInt("循环间隔（毫秒）", ref cfg.Throttler);
        ImGuiComponents.HelpMarker("一键输出循环内置了节流器，每隔指定毫秒运行一次以优化性能。如果遇到帧率问题可尝试增加此值，但过高可能导致技能延迟，请自行测试。");

        var orbwalker = OrbwalkerIPC.IsEnabled && OrbwalkerIPC.PluginEnabled();
        using (ImRaii.Disabled(!orbwalker))
        {
            P.UIHelper.ShowIPCControlledIndicatorIfNeeded("OrbwalkerIntegration");
            changed |= P.UIHelper.ShowIPCControlledCheckboxIfNeeded(
                "启用Orbwalker集成", ref cfg.OrbwalkerIntegration, "OrbwalkerIntegration");

            ImGuiComponents.HelpMarker($"启用后，一键输出循环在移动时也会使用读条技能，Orbwalker会在施法期间锁定移动。你可能需要在Orbwalker中启用“缓冲首个施法”选项。需要已安装并启用Orbwalker插件。");
        }

        if (changed)
            Service.Configuration.Save();

    }
}