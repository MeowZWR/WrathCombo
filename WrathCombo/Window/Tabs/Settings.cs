using System;
using System.Linq;
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
using WrathCombo.Resources.Dictionary.Chinese;

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

                ImGuiEx.Spacing(new Vector2(0, 10));

                #region Open to PvE

                if (ImGui.Checkbox("Open Wrath to the PvE Features tab", ref
                        Service.Configuration.OpenToPvE))
                    Service.Configuration.Save();

                ImGuiComponents.HelpMarker("When you open Wrath with `/wrath`, it will open to the PvE Features tab, instead of the last tab you were on." +
                                           "\nSame as always using the `/wrath pve` command to open Wrath.");

                #endregion

                #region Open to PvP

                if (ImGui.Checkbox("Open Wrath to the PvP Features tab in PvP areas", ref
                        Service.Configuration.OpenToPvP))
                    Service.Configuration.Save();

                ImGuiComponents.HelpMarker("Same as above, when you open Wrath with `/wrath`, it will open to the PvP Features tab, instead of the last tab you were on, when in a PvP area." +
                                           "\nSimilar to using the `/wrath pvp` command to open Wrath.");

                ImGui.SameLine();
                ImGui.TextColored(ImGuiColors.DalamudGrey, $"(Will override the option above)");

                #endregion

                #region Open to Current Job

                if (ImGui.Checkbox("Open PvE Features UI to Current Job on Opening", ref Service.Configuration.OpenToCurrentJob))
                    Service.Configuration.Save();

                ImGuiComponents.HelpMarker("When you open Wrath's UI, if your last tab was PvE, it will automatically open to the job you are currently playing.");

                #endregion

                #region Open to Current Job on Switching

                if (ImGui.Checkbox("Open PvE Features UI to Current Job on Switching Jobs", ref Service.Configuration.OpenToCurrentJobOnSwitch))
                    Service.Configuration.Save();

                ImGuiComponents.HelpMarker("When you switch jobs, it will automatically switch the PvE Features tab to the job you are currently playing.");

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

                #region Queued Action Suppression

                if (ImGui.Checkbox($"Queued Action Suppression", ref Service.Configuration.SuppressQueuedActions))
                    Service.Configuration.Save();

                ImGuiComponents.HelpMarker("While Enabled:\nWhenever you queue an action that is not the same as the button you are pressing, Wrath will disable every other Combo, preventing them from thinking the queued action should trigger them.\n- This prevents combos from conflicting with each other, just because of overlap in actions that combos return and actions that combos replace.\n- This does however cause the Replaced Action for each combo to 'flash' through as actions are queued.\nThat 'flashed' action won't go through, it is only visual.\n\nWhile Disabled:\nCombos will not be disabled when actions are queued from a combo.\n- This prevents your hotbars 'flashing', that is the only benefit.\n- This does however allow Combos to conflict with each other, if one combo returns an action that another combo has as its Replaced Action.\nWe do NOT mark these types of conflicts, and we do NOT try to avoid them as we add new features.\n\nIt is STRONGLY recommended to keep this setting On.\nIf the 'flashing' bothers you it is MUCH more advised to use Performance Mode,\ninstead of turning this off.\nDefault: On");

                ImGui.SameLine();
                ImGuiEx.Spacing(new Vector2(10, 0));
                ImGui.TextColored(ImGuiColors.DalamudGrey, "read more:");

                ImGuiComponents.HelpMarker($"With this enabled, whenever you queue an action that is not the same as the button you are pressing, it will disable every other button's feature from running. This resolves a number of issues where incorrect actions are performed due to how the game processes queued actions, however the visual experience on your hotbars is degraded. This is not recommended to be disabled, however if you feel uncomfortable with hotbar icons changing quickly this is one way to resolve it (or use Performance Mode) but be aware that this may introduce unintended side effects to combos if you have a lot enabled for a job." +
                    $"\n\n" +
                    $"For a more complicated explanation, whenever an action is used, the following happens:" +
                    $"\n1. If the action invokes the GCD (Weaponskills & Spells), if the GCD currently isn't active it will use it right away." +
                    $"\n2. Otherwise, if you're within the \"Queue Window\" (normally the last 0.5s of the GCD), it gets added to the queue before it is used." +
                    $"\n3. If the action is an Ability, as long as there's no animation lock currently happening it will execute right away." +
                    $"\n4. Otherwise, it is added to the queue immediately and then used when the animation lock is finished." +
                    $"\n\nFor step 1, the action being passed to the game is the original, unmodified action, which is then converted at use time. At step 2, things get messy as the queued action still remains the unmodified action, but when the queue is executed it treats it as if the modified action *is* the unmodified action." +
                    $"\n\nE.g. Original action Cure, modified action Cure II. At step 1, the game is okay to convert Cure to Cure II because that is what we're telling it to do. However, when Cure is passed to the queue, it treats it as if the unmodified action is Cure II." +
                    $"\n\nThis is similar for steps 3 & 4, except it can just happen earlier." +
                    $"\n\nHow this impacts us is if using the example before, we have a feature replacing Cure with Cure II, and another replacing Cure II with Regen and you enable both, the following happens:" +
                    $"\n\nStep 1, Cure is passed to the game, is converted to Cure II.\nYou press Cure again at the Queue Window, Cure is passed to the queue, however the queue when it goes to execute will treat it as Cure II.\nResult is instead of Cure II being executed, it's Regen, because we've told it to modify Cure II to Regen." +
                    $"\nThis was not part of the first feature, therefore an incorrect action." +
                    $"\n\nOur workaround for this is to disable all other actions being replaced if they don't match the queued action, which this setting controls.");

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

                #region Targeting Options

                ImGuiEx.Spacing(new Vector2(0, 20));
                ImGuiEx.TextUnderlined("Targeting Options");

                var useCusHealStack = Service.Configuration.UseCustomHealStack;

                #region Retarget ST Healing Actions

                bool retargetHealingActions =
                    Service.Configuration.RetargetHealingActionsToStack;
                if (ImGui.Checkbox("Retarget (Single Target) Healing Actions", ref retargetHealingActions))
                {
                    Service.Configuration.RetargetHealingActionsToStack =
                        retargetHealingActions;
                    Service.Configuration.Save();
                }

                ImGuiComponents.HelpMarker(
                    "This will retarget all single target healing actions to the Heal Stack as shown below,\nsimilarly to how Redirect or Reaction would.\nThis ensures that the target used to check HP% threshold logic for healing actions is the same target that will receive that heal.\n\nIt is recommended to enable this if you customize the Heal Stack at all.\nDefault: Off");
                Presets.DrawRetargetedSymbolForSettingsPage();

                #endregion

                ImGuiEx.Spacing(new Vector2(0, 10));

                #region Current Heal Stack

                ImGui.TextUnformatted("Current Heal Stack:");

                ImGuiComponents.HelpMarker(
                    "This is the order in which Wrath will try to select a healing target.\n\n" +
                    "If the 'Retarget Healing Actions' option is disabled, that is just the target that will be used for checking the HP threshold to trigger different healing actions to show up in their rotations.\n" +
                    "If the 'Retarget Healing Actions' option is enabled, that target is also the one that healing actions will be targeted onto (even when the action does not first check the HP of that target, like the combo's Replaced Action, for example).");

                var healStackText = "";
                var nextStackItemMarker = "   >   ";
                if (useCusHealStack)
                {
                    foreach (var item in Service.Configuration.CustomHealStack
                                 .Select((value, index) => new { value, index }))
                    {
                        healStackText += UserConfig.TargetDisplayNameFromPropertyName(item.value);
                        if (item.index < Service.Configuration.CustomHealStack.Length - 1)
                            healStackText += nextStackItemMarker;
                    }
                }
                else
                {
                    if (Service.Configuration.UseUIMouseoverOverridesInDefaultHealStack)
                        healStackText += "UI-MouseOver Target" + nextStackItemMarker;
                    if (Service.Configuration.UseFieldMouseoverOverridesInDefaultHealStack)
                        healStackText += "Field-MouseOver Target" + nextStackItemMarker;
                    healStackText += "Soft Target" + nextStackItemMarker;
                    healStackText += "Hard Target" + nextStackItemMarker;
                    if (Service.Configuration.UseFocusTargetOverrideInDefaultHealStack)
                        healStackText += "Focus Target" + nextStackItemMarker;
                    if (Service.Configuration.UseLowestHPOverrideInDefaultHealStack)
                        healStackText += "Lowest HP% Ally" + nextStackItemMarker;
                    healStackText += "Self";
                }
                ImGuiEx.Spacing(new Vector2(10, 0));
                ImGuiEx.TextWrapped(ImGuiColors.DalamudGrey, healStackText);

                ImGuiEx.Spacing(new Vector2(0, 10));

                #endregion

                #region Heal Stack Customization Options

                var labelText = "Heal Stack Customization Options";
                // Nest the Collapse into a Child of varying size, to be able to limit its width
                var dynamicHeight = _unCollapsed
                    ? _healStackCustomizationHeight
                    : ImGui.CalcTextSize("I").Y + 5f.Scale();
                ImGui.BeginChild("##HealStackCustomization",
                    new Vector2(ImGui.CalcTextSize(labelText).X * 2.2f, dynamicHeight),
                    false,
                    ImGuiWindowFlags.NoScrollbar);

                // Collapsing Header for the Heal Stack Customization Options
                _unCollapsed = ImGui.CollapsingHeader(labelText,
                    ImGuiTreeNodeFlags.SpanAvailWidth);
                var collapsibleHeight = ImGui.GetItemRectSize().Y;
                if (_unCollapsed)
                {
                    ImGui.BeginGroup();

                    #region Default Heal Stack Include: UI MouseOver

                    if (useCusHealStack) ImGui.BeginDisabled();

                    bool useUIMouseoverOverridesInDefaultHealStack =
                        Service.Configuration.UseUIMouseoverOverridesInDefaultHealStack;
                    if (ImGui.Checkbox("Add UI MouseOver to the Default Healing Stack", ref useUIMouseoverOverridesInDefaultHealStack))
                    {
                        Service.Configuration.UseUIMouseoverOverridesInDefaultHealStack =
                            useUIMouseoverOverridesInDefaultHealStack;
                        Service.Configuration.Save();
                    }

                    if (useCusHealStack) ImGui.EndDisabled();

                    ImGuiComponents.HelpMarker("This will add any UI MouseOver targets to the top of the Default Heal Stack, overriding the rest of the stack if you are mousing over any party member UI.\n\nIt is recommended to enable this if you are a keyboard+mouse user and enable Retarget Healing Actions (or have UI MouseOver targets in your Redirect/Reaction configuration).\nDefault: Off");

                    #endregion

                    #region Default Heal Stack Include: Field MouseOver

                    if (useCusHealStack) ImGui.BeginDisabled();

                    bool useFieldMouseoverOverridesInDefaultHealStack =
                        Service.Configuration.UseFieldMouseoverOverridesInDefaultHealStack;
                    if (ImGui.Checkbox("Add Field MouseOver to the Default Healing Stack", ref useFieldMouseoverOverridesInDefaultHealStack))
                    {
                        Service.Configuration.UseFieldMouseoverOverridesInDefaultHealStack =
                            useFieldMouseoverOverridesInDefaultHealStack;
                        Service.Configuration.Save();
                    }

                    if (useCusHealStack) ImGui.EndDisabled();

                    ImGuiComponents.HelpMarker("This will add any MouseOver targets to the top of the Default Heal Stack, overriding the rest of the stack if you are mousing over any nameplate UI or character model.\n\nIt is recommended to enable this only if you regularly intentionally use field mouseover targeting already.\nDefault: Off");

                    #endregion

                    #region Default Heal Stack Include: Focus Target

                    if (useCusHealStack) ImGui.BeginDisabled();

                    bool useFocusTargetOverrideInDefaultHealStack =
                        Service.Configuration.UseFocusTargetOverrideInDefaultHealStack;
                    if (ImGui.Checkbox("Add Focus Target to the Default Healing Stack", ref useFocusTargetOverrideInDefaultHealStack))
                    {
                        Service.Configuration.UseFocusTargetOverrideInDefaultHealStack =
                            useFocusTargetOverrideInDefaultHealStack;
                        Service.Configuration.Save();
                    }

                    if (useCusHealStack) ImGui.EndDisabled();

                    ImGuiComponents.HelpMarker("This will add your focus target under your hard and soft targets in the Default Heal Stack, overriding the rest of the stack if you have a living focus target.\n\nDefault: Off");

                    #endregion

                    #region Default Heal Stack Include: Lowest HP Ally

                    if (useCusHealStack) ImGui.BeginDisabled();

                    bool useLowestHPOverrideInDefaultHealStack =
                        Service.Configuration.UseLowestHPOverrideInDefaultHealStack;
                    if (ImGui.Checkbox("Add Lowest HP% Ally to the Default Healing Stack", ref useLowestHPOverrideInDefaultHealStack))
                    {
                        Service.Configuration.UseLowestHPOverrideInDefaultHealStack =
                            useLowestHPOverrideInDefaultHealStack;
                        Service.Configuration.Save();
                    }

                    if (useCusHealStack) ImGui.EndDisabled();

                    ImGuiComponents.HelpMarker("This will add a nearby party member with the lowest HP% to bottom of the Default Heal Stack, overriding only yourself.\n\nTHIS SHOULD BE USED WITH THE 'RETARGET HEALING ACTIONS' SETTING!\n\nDefault: Off");

                    if (useCusHealStack) ImGui.BeginDisabled();
                    if (useLowestHPOverrideInDefaultHealStack)
                    {
                        ImGuiEx.Spacing(new Vector2(30, 0));
                        ImGuiEx.Text(ImGuiColors.DalamudYellow, "This should be used with the 'Retarget Healing Actions' setting above!");
                    }
                    if (useCusHealStack) ImGui.EndDisabled();

                    #endregion

                    ImGuiEx.Spacing(new Vector2(5, 5));
                    ImGui.TextUnformatted("Or");
                    ImGuiEx.Spacing(new Vector2(0, 5));

                    #region Use Custom Heal Stack

                    bool useCustomHealStack = Service.Configuration.UseCustomHealStack;
                    if (ImGui.Checkbox("Use a Custom Heal Stack Instead", ref useCustomHealStack))
                    {
                        Service.Configuration.UseCustomHealStack = useCustomHealStack;
                        Service.Configuration.Save();
                    }

                    ImGuiComponents.HelpMarker("Select this if you would rather make your own stack of target priorities for Heal Targets instead of using our default stack.\n\nIt is recommended to use this to align with your Redirect/Reaction configuration if you're not using the Retarget Healing Actions setup; otherwise it is preference.\nDefault: Off");

                    #endregion

                    #region Custom Heal Stack Manager

                    if (Service.Configuration.UseCustomHealStack)
                    {
                        ImGui.Indent();
                        UserConfig.DrawCustomStackManager(
                            "CustomHealStack",
                            ref Service.Configuration.CustomHealStack,
                            ["Enemy", "Attack", "Dead", "Living"],
                            "The priority goes from top to bottom.\n" +
                            "Scroll down to see all of your items.\n" +
                            "Click the Up and Down buttons to move items in the list.\n" +
                            "Click the X button to remove an item from the list.\n\n" +
                            "If there are fewer than 4 items, and all return nothing when checked, will fall back to Self.\n\n" +
                            "These targets will only be considered valid if they are friendly and within 25y.\n" +
                            "These targets will be checked for being Dead or having a Cleansable Debuff\n" +
                            "when this Stack is applied to Raises or Esuna, respectively.\n" +
                            "(For Raises: the Stack will fall back to your Hard Target or any Dead Party Member)\n\n" +
                            "Default: Focus Target > Hard Target > Self"
                        );
                        ImGui.Unindent();
                    }

                    #endregion

                    ImGui.EndGroup();

                    // Get the max height of the section above
                    _healStackCustomizationHeight =
                        ImGui.GetItemRectSize().Y + collapsibleHeight + 5f.Scale();
                }

                ImGui.EndChild();

                if (_unCollapsed)
                    ImGuiEx.Spacing(new Vector2(0, 10));

                #endregion

                ImGuiEx.Spacing(new Vector2(0, 10));

                #region Raise Stack Manager

                ImGui.TextUnformatted("Current Raise Stack:");

                ImGuiComponents.HelpMarker(
                    "This is the order in which Wrath will try to select a " +
                    "target to Raise,\nif Retargeting of any Raise Feature is enabled.\n\n" +
                    "You can find Raise Features under PvE>General,\n" +
                    "or under each caster that has a Raise.");

                ImGui.Indent();
                UserConfig.DrawCustomStackManager(
                    "CustomRaiseStack",
                    ref Service.Configuration.RaiseStack,
                    ["Enemy", "Attack", "MissingHP", "Lowest", "Chocobo", "Living"],
                    "The priority goes from top to bottom.\n" +
                    "Scroll down to see all of your items.\n" +
                    "Click the Up and Down buttons to move items in the list.\n" +
                    "Click the X button to remove an item from the list.\n\n" +
                    "If there are fewer than 5 items, and all return nothing when checked, will fall back to:\n" +
                    "your Hard Target if they're dead, or <Any Dead Party Member>.\n\n"+
                    "These targets will only be considered valid if they are friendly, dead, and within 30y.\n" +
                    "Default: Any Healer > Any Tank > Any Raiser > Any Dead Party Member",
                    true
                );
                ImGui.TextDisabled("(all targets are checked for rezz-ability)");
                ImGui.Unindent();

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
                        DebugFile.MakeDebugFile(allJobs: true);
                }

                ImGuiComponents.HelpMarker("将在桌面生成调试文件。\n便于提供给开发者以协助排查问题。\n等同于使用指令：/wrath debug");

                #endregion

                #if DEBUG
                // 在生成调试文件按钮下方添加
                if (ImGui.Button("生成键值对调试文件"))
                {
                    DictionaryDebugger.ExportDebugFile();
                }
                ImGuiComponents.HelpMarker("将在桌面生成中文翻译键值对调试文件。\n包含未被替换的英文文本和未被使用的键值对词典。");
                #endif

                #endregion
            }
        }

        #region Custom Heal Stack Manager Methods

        private static bool _unCollapsed;
        private static float _healStackCustomizationHeight = 0;

        #endregion
    }
}
