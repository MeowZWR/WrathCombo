using System;
using Dalamud.Interface.Components;
using Dalamud.Interface.Utility.Raii;
using ImGuiNET;
using System.Numerics;
using Dalamud.Interface.Colors;
using ECommons.GameHelpers;
using ECommons.ImGuiMethods;
using WrathCombo.CustomComboNS.Functions;
using WrathCombo.Services;
using WrathCombo.Window.Functions;
using ECommons.DalamudServices;

namespace WrathCombo.Window.Tabs
{
    internal class Settings : ConfigWindow
    {
        internal new static void Draw()
        {
            using (ImRaii.Child("main", new Vector2(0, 0), true))
            {
                ImGui.Text("此选项卡允许您自定义 Wrath Combo 的选项。");

                #region UI Options

                ImGuiEx.Spacing(new Vector2(0, 20));
                ImGuiEx.TextUnderlined("主界面选项");

                #region SubCombos

                var hideChildren = Service.Configuration.HideChildren;

                if (ImGui.Checkbox("隐藏子连击选项", ref hideChildren))
                {
                    Service.Configuration.HideChildren = hideChildren;
                    Service.Configuration.Save();
                }

                ImGuiComponents.HelpMarker("隐藏已禁用功能的子选项。");

                #endregion

                #region Conflicting

                bool hideConflicting = Service.Configuration.HideConflictedCombos;
                if (ImGui.Checkbox("隐藏冲突的连击", ref hideConflicting))
                {
                    Service.Configuration.HideConflictedCombos = hideConflicting;
                    Service.Configuration.Save();
                }

                ImGuiComponents.HelpMarker("隐藏与您选择的连击产生冲突的选项。");

                #endregion

                #region Open to Current Job

                if (ImGui.Checkbox("打开PvE设置面板时自动切换到当前职业设置界面", ref Service.Configuration.OpenToCurrentJob))
                    Service.Configuration.Save();

                ImGuiComponents.HelpMarker("当你切换到Wrath的PVE设置时，将自动打开你当前职业的设置界面。");

                if (ImGui.Checkbox("切换职业时自动切换到当前职业的PvE设置界面", ref Service.Configuration.OpenToCurrentJobOnSwitch))
                    Service.Configuration.Save();

                ImGuiComponents.HelpMarker("当您切换职业时，将自动打开你当前职业的设置界面。");

                #endregion

                #region Shorten DTR bar text

                bool shortDTRText = Service.Configuration.ShortDTRText;

                if (ImGui.Checkbox("缩短服务器信息栏文本", ref shortDTRText))
                {
                    Service.Configuration.ShortDTRText = shortDTRText;
                    Service.Configuration.Save();
                }

                ImGuiComponents.HelpMarker(
                    "默认情况下，Wrath Combo在服务器信息栏会显示自动循环是否开启，" +
                    "\n如果开启自动循环，它将显示您启用了多少个自动循环。" +
                    "\n最后，它还会显示是否有其他插件控制该值。" +
                    "\n启用此选项将隐藏已启用的自动循环数量"
                );

                #endregion

                #region Message of the Day

                bool motd = Service.Configuration.HideMessageOfTheDay;

                if (ImGui.Checkbox("隐藏每日消息", ref motd))
                {
                    Service.Configuration.HideMessageOfTheDay = motd;
                    Service.Configuration.Save();
                }

                ImGuiComponents.HelpMarker("禁用登录时在聊天窗口中显示的每日消息。");

                #endregion

                #region TargetHelper

                Vector4 colour = Service.Configuration.TargetHighlightColor;
                if (ImGui.ColorEdit4("目标高亮颜色", ref colour, ImGuiColorEditFlags.NoInputs | ImGuiColorEditFlags.AlphaPreview | ImGuiColorEditFlags.AlphaBar))
                {
                    Service.Configuration.TargetHighlightColor = colour;
                    Service.Configuration.Save();
                }

                ImGuiComponents.HelpMarker("在游戏原生队伍列表中的队友周围绘制方框（被特定功能选定时生效）\n将透明度设为0可隐藏方框");

                ImGui.SameLine();
                ImGui.TextColored(ImGuiColors.DalamudGrey, $"(当前仅供{CustomComboFunctions.JobIDs.JobIDToName(33)}使用)");

                #endregion

                #endregion

                #region Rotation Behavior Options

                ImGuiEx.Spacing(new Vector2(0, 20));
                ImGuiEx.TextUnderlined("循环行为选项");


                #region Performance Mode

                if (ImGui.Checkbox("性能模式", ref Service.Configuration.PerformanceMode))
                    Service.Configuration.Save();

                ImGuiComponents.HelpMarker("此模式将禁用热键栏上的技能替换，但仍会在后台运行，并在你按下技能时生效。");

                #endregion

                #region Spells while Moving

                if (ImGui.Checkbox("移动时阻止咏唱", ref Service.Configuration.BlockSpellOnMove))
                    Service.Configuration.Save();

                ImGuiComponents.HelpMarker("在移动时阻止咏唱，将技能替换为狂怒剑。\n此选项将优先于大部分职业的特定连击移动选项。");

                #endregion

                #region Action Changing

                if (ImGui.Checkbox("技能替换", ref Service.Configuration.ActionChanging))
                    Service.Configuration.Save();

                ImGuiComponents.HelpMarker("控制是否允许插件拦截并替换技能为连击。\n如果禁用，你手动释放的技能将不再受 Wrath 设定影响。\n\n自动循环不会受到此设置影响。\n\n可通过 /wrath combo 指令控制。");

                #endregion

                #region Throttle

                var len = ImGui.CalcTextSize("咏唱百分比").X;

                ImGui.PushItemWidth(75);
                var throttle = Service.Configuration.Throttle;
                if (ImGui.InputInt("###ActionThrottle",
                        ref throttle, 0, 0))
                {
                    Service.Configuration.Throttle = Math.Clamp(throttle, 0, 1500);
                    Service.Configuration.Save();
                }

                ImGui.SameLine();
                var pos = ImGui.GetCursorPosX() + len;
                ImGui.Text($"毫秒");
                ImGui.SameLine(pos);
                ImGui.Text($"   -   动作更新频率限制");


                ImGuiComponents.HelpMarker(
                    "此设置决定连击系统多久更新一次热键栏中的技能。" +
                    "\n默认情况下不会进行限制，始终在第一时间进行技能替换。" +
                    "\n\n如果你遇到轻微的降帧问题，可以增加此值，使连击更新频率降低。" +
                    "\n但这会降低连击的响应速度，甚至可能影响GCD循环。" +
                    "\n如果值设定的较高，可能会完全破坏你的技能循环。" +
                    "\n如果遇到严重的降帧问题，建议使用性能模式进行优化。" +
                    "\n\n200毫秒可能会对帧数产生一定影响。" +
                    "\n不推荐设置超过500毫秒。" +
                    "\n默认值：50");

                #endregion

                #region Movement Check Delay

                ImGui.PushItemWidth(75);
                if (ImGui.InputFloat("###MovementLeeway", ref Service.Configuration.MovementLeeway))
                    Service.Configuration.Save();

                ImGui.SameLine();
                ImGui.Text("秒");

                ImGui.SameLine(pos);

                ImGui.Text($"   -   移动检测延迟");

                ImGuiComponents.HelpMarker("许多功能会检测你的移动状态来决定使用的技能，此设置允许你设定一个延迟，在移动达到一定时间后才会被识别为移动中。\n这样可以避免小幅度的移动影响你的技能循环，主要适用于施法职业。\n\n建议将该值保持在 0 到 1 秒之间。\n默认值：0.0");

                #endregion

                #region Opener Failure Timeout

                if (ImGui.InputFloat("###OpenerTimeout", ref Service.Configuration.OpenerTimeout))
                    Service.Configuration.Save();

                ImGui.SameLine();
                ImGui.Text("秒");

                ImGui.SameLine(pos);

                ImGui.Text($"   -   起手失败超时");

                ImGuiComponents.HelpMarker("在起手技能循环期间，如果距离你上一个技能已超过此设定时间，系统将判定起手循环失败并恢复常规技能循环。\n\n推荐将此值保持在6以下。\n默认值：4.0");

                #endregion

                #region Melee Offset
                var offset = (float)Service.Configuration.MeleeOffset;

                if (ImGui.InputFloat("###MeleeOffset", ref offset))
                {
                    Service.Configuration.MeleeOffset = (double)offset;
                    Service.Configuration.Save();
                }

                ImGui.SameLine();
                ImGui.Text($"米");
                ImGui.SameLine(pos);

                ImGui.Text($"   -   近战距离偏移");

                ImGuiComponents.HelpMarker("偏移近战检测的距离数值。\n适用于当Boss略微超出近战范围时，不希望立即使用远程攻击的玩家。\n\n示例：\n设为 -0.5 时：需比标准近战距离再接近目标0.5米；\n设为 2 时：需距离目标碰撞箱超出2yalms才会触发远程技能。\n\n推荐保持默认值0。\n默认值：0.0");
                #endregion

                #region Interrupt Delay

                var delay = (int)(Service.Configuration.InterruptDelay * 100d);

                if (ImGui.SliderInt("###InterruptDelay",
                    ref delay, 0, 100))
                {
                    delay = delay.RoundOff(SliderIncrements.Fives);

                    Service.Configuration.InterruptDelay = ((double)delay) / 100d;
                    Service.Configuration.Save();
                }
                ImGui.SameLine();
                ImGui.Text($"咏唱百分比");
                ImGui.SameLine( pos);
                ImGui.Text($"   -   打断延迟");

                ImGuiComponents.HelpMarker("等待打断的咏唱条总时间的百分比。\n适用于所有打断，所有职业的连击。\n\n建议将该值保持在50%以下。\n默认值：0%");

                #endregion

                #endregion

                #region Troubleshooting Options

                ImGuiEx.Spacing(new Vector2(0, 20));
                ImGuiEx.TextUnderlined("故障排查/数据分析选项");

                #region Combat Log

                bool showCombatLog = Service.Configuration.EnabledOutputLog;

                if (ImGui.Checkbox("输出战斗日志到聊天窗", ref showCombatLog))
                {
                    Service.Configuration.EnabledOutputLog = showCombatLog;
                    Service.Configuration.Save();
                }

                ImGuiComponents.HelpMarker("每次使用技能时，插件会将技能信息输出至聊天窗。");
                #endregion

                #region Opener Log

                if (ImGui.Checkbox($"输出起手式状态到聊天窗", ref Service.Configuration.OutputOpenerLogs))
                    Service.Configuration.Save();

                ImGuiComponents.HelpMarker("当职业的起手式准备就绪、失败或按预期完成时，相关信息将输出至聊天窗。");
                #endregion

                #region Debug File

                if (ImGui.Button("生成调试文件"))
                {
                    if (Player.Available)
                        DebugFile.MakeDebugFile();
                    else
                        DebugFile.MakeDebugFile(allJobs:true);
                }

                ImGuiComponents.HelpMarker("将在桌面生成调试文件。\n便于提供给开发者以协助排查问题。\n等同于使用指令：/wrath debug");

                #endregion

                #endregion
            }
        }
    }
}
