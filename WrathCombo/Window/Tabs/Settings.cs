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

                if (ImGui.Checkbox("打开Wrath时默认进入PvE功能页", ref
                        Service.Configuration.OpenToPvE))
                    Service.Configuration.Save();

                ImGuiComponents.HelpMarker("当你使用 `/wrath` 指令打开Wrath时，将默认进入PvE功能页，而不是上次关闭时所在的标签页。" +
                                           "\n等同于每次都使用 `/wrath pve` 指令打开Wrath。");

                #endregion

                #region Open to PvP

                if (ImGui.Checkbox("在PvP区域打开Wrath时默认进入PvP功能页", ref
                        Service.Configuration.OpenToPvP))
                    Service.Configuration.Save();

                ImGuiComponents.HelpMarker("同上，当你在PvP区域使用 `/wrath` 指令打开Wrath时，将默认进入PvP功能页，而不是上次关闭时所在的标签页。" +
                                           "\n类似于使用 `/wrath pvp` 指令打开Wrath。");

                ImGui.SameLine();
                ImGui.TextColored(ImGuiColors.DalamudGrey, $"(此选项会覆盖上方设置)");

                #endregion

                #region Open to Current Job

                if (ImGui.Checkbox("打开PvE功能页时自动切换到当前职业", ref Service.Configuration.OpenToCurrentJob))
                    Service.Configuration.Save();

                ImGuiComponents.HelpMarker("当你打开Wrath的界面时，如果上次所在标签页为PvE，将自动切换到你当前所玩的职业。");

                #endregion

                #region Open to Current Job on Switching

                if (ImGui.Checkbox("切换职业时自动切换PvE功能页到当前职业", ref Service.Configuration.OpenToCurrentJobOnSwitch))
                    Service.Configuration.Save();

                ImGuiComponents.HelpMarker("当你切换职业时，PvE功能页会自动切换到你当前所玩的职业。");

                #endregion

                #endregion

                #region Rotation Behavior Options

                ImGuiEx.Spacing(new Vector2(0, 20));
                ImGuiEx.TextUnderlined("循环行为选项");

                #region Spells while Moving

                if (ImGui.Checkbox("移动时阻止咏唱", ref Service.Configuration.BlockSpellOnMove))
                    Service.Configuration.Save();

                ImGuiComponents.HelpMarker("在移动时阻止咏唱，将技能替换为狂怒剑。\n此选项将优先于大部分职业的特定连击移动选项。\n\n推荐保持关闭，as most combos already handle this more gracefully.\n默认关闭");

                #endregion

                #region Action Changing

                if (ImGui.Checkbox("技能替换", ref Service.Configuration.ActionChanging))
                    Service.Configuration.Save();

                ImGuiComponents.HelpMarker("控制是否允许插件拦截并替换技能为连击。\n如果禁用，你手动释放的技能将不再受 Wrath 设定影响。\n\n自动循环不会受到此设置影响。\n\n可通过 /wrath combo 指令控制。");

                #endregion

                #region Performance Mode

                if (Service.Configuration.ActionChanging) {
                    ImGui.Indent();
                    if (ImGui.Checkbox("性能模式", ref Service.Configuration.PerformanceMode))
                        Service.Configuration.Save();

                    ImGuiComponents.HelpMarker("此模式将禁用热键栏上的技能替换，但仍会在后台运行，并在你按下技能时生效。\n\n有性能问题时建议开启。\n默认关闭。");
                    ImGui.Unindent();
                }

                #endregion

                #region Queued Action Suppression

                if (ImGui.Checkbox($"技能队列抑制", ref Service.Configuration.SuppressQueuedActions))
                    Service.Configuration.Save();

                ImGuiComponents.HelpMarker("启用时：\n当你队列的技能与当前按下的按钮不一致时，Wrath会禁用所有其他连击，防止它们误判队列应触发的技能。\n- 这可以避免连击之间因动作重叠而产生冲突（即连击返回的动作与被替换的动作重叠时）\n- 但这会导致每个连击的“被替换技能”在队列时会在热键栏上‘闪烁’。\n这种‘闪烁’仅为视觉效果，实际不会释放。\n\n禁用时：\n当技能由连击队列时，不会禁用其他连击。\n- 这样可以避免热键栏‘闪烁’，仅有此好处。\n- 但这会导致连击间可能发生冲突，比如一个连击返回的技能正好是另一个连击的被替换技能。\n我们不会标记此类冲突，也不会在添加新功能时主动避免。\n\n强烈建议保持此设置开启。\n如果你不喜欢‘闪烁’，更推荐使用性能模式，而不是关闭此选项。\n默认：开启");

                ImGui.SameLine();
                ImGuiEx.Spacing(new Vector2(10, 0));
                ImGui.TextColored(ImGuiColors.DalamudGrey, "了解更多：");

                ImGuiComponents.HelpMarker($"启用后，每当你队列的技能与当前按下的按钮不一致时，会禁用所有其他按钮的功能。这解决了由于游戏处理技能队列方式导致的错误技能问题，但会降低热键栏的视觉体验。不建议关闭此选项，如果你不喜欢热键栏图标快速变化，可以通过此方式解决（或使用性能模式），但请注意如果你为某职业启用了大量连击，可能会引入连击间的副作用。" +
                    $"\n\n" +
                    $"更详细的解释：每当使用技能时，流程如下：" +
                    $"\n1. 如果技能触发GCD（武器技能&法术），且GCD未激活，则立即使用。" +
                    $"\n2. 否则，如果处于“队列窗口”（通常为GCD最后0.5秒），技能会在使用前加入队列。" +
                    $"\n3. 如果是能力技，只要没有动画锁，会立即执行。" +
                    $"\n4. 否则，会立即加入队列，动画锁结束后执行。" +
                    $"\n\n第1步，传递给游戏的是原始技能，使用时才会被替换。第2步较为复杂，队列中的技能仍是原始技能，但队列执行时会把被替换的技能当作原始技能处理。" +
                    $"\n\n例如：原始技能为治疗，替换为治疗II。第1步，游戏会把治疗替换为治疗II。第2步，治疗加入队列，队列执行时会把未替换的技能当作治疗II。" +
                    $"\n\n第3、4步类似，只是发生得更早。" +
                    $"\n\n这对我们影响是：假如有一个功能把治疗替换为治疗II，另一个把治疗II替换为再生，且你都启用时，流程如下：" +
                    $"\n\n第1步，治疗传递给游戏，被替换为治疗II。\n你在队列窗口再次按下治疗，治疗加入队列，队列执行时会把它当作治疗II。\n结果不是释放治疗II，而是再生，因为我们设置了把治疗II替换为再生。" +
                    $"\n这不是第一个功能的本意，因此是错误技能。" +
                    $"\n\n我们的解决办法是：如果队列技能与被替换技能不一致，就禁用所有其他被替换技能的连击，此设置即控制此行为。");

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
                
                #region Maximum Weaves

                ImGui.PushItemWidth(75);
                if (ImGui.InputInt("###MaximumWeaves", ref Service.Configuration.MaximumWeavesPerWindow))
                    Service.Configuration.Save();

                ImGui.SameLine();
                ImGui.Text("oGCDs");

                ImGui.SameLine(pos);

                ImGui.Text($"   -   Maximum number of Weaves");

                ImGuiComponents.HelpMarker("This controls how many oGCDs are allowed between GCDs.\nThe sort of 'default' for the game is double weaving, but triple weaving is completely possible to do with low enough latency (of every kind); but if you struggle with latency of some sort, single weaving may even be a good answer for you.\nTriple weaving is already done in a manner where we try to avoid clipping GCDs, and as such doesn't happen particularly often even if you do have good latency, so it is a safe option as far as parses/etc goes.\n\nDefault: 2");

                #endregion

                #endregion

                #region Targeting Options

                ImGuiEx.Spacing(new Vector2(0, 20));
                ImGuiEx.TextUnderlined("目标选择选项");

                var useCusHealStack = Service.Configuration.UseCustomHealStack;

                #region Retarget ST Healing Actions

                bool retargetHealingActions =
                    Service.Configuration.RetargetHealingActionsToStack;
                if (ImGui.Checkbox("重定向（单体）治疗技能", ref retargetHealingActions))
                {
                    Service.Configuration.RetargetHealingActionsToStack =
                        retargetHealingActions;
                    Service.Configuration.Save();
                }

                ImGuiComponents.HelpMarker(
                    "此选项会将所有单体治疗技能重定向至下方显示的治疗目标队列（Heal Stack），类似于重定向（Redirect）或反应（Reaction）的机制。\n这样可以确保用于判断治疗技能HP%阈值逻辑的目标与实际接受治疗的目标一致。\n\n如果你自定义了治疗目标队列，建议开启此选项。\n默认：关闭");
                Presets.DrawRetargetedSymbolForSettingsPage();

                bool addNpcs = 
                    Service.Configuration.AddOutOfPartyNPCsToRetargeting;

                if (ImGui.Checkbox("Add Out of Party NPCs to Retargeting", ref addNpcs))
                {
                    Service.Configuration.AddOutOfPartyNPCsToRetargeting = addNpcs;
                    Service.Configuration.Save();
                }

                ImGuiComponents.HelpMarker(
                    "This will add any NPCs that are not in your party to the retargeting logic for healing actions.\n\n" +
                    "This is useful for healers who want to be able to target NPCs that are not in their party, such as quest NPCs.\n\n" +
                    "These NPCs will not work with any role based custom stacks (even if an NPC looks like a tank, they're not classed as one)\n\n" +
                    "Default: Off");

                #endregion

                ImGuiEx.Spacing(new Vector2(0, 10));

                #region Current Heal Stack

                ImGui.TextUnformatted("当前治疗目标队列：");

                ImGuiComponents.HelpMarker(
                    "这是Wrath尝试选择治疗目标的顺序。\n\n" +
                    "如果未启用“重定向治疗技能”选项，则此目标仅用于判断各类治疗技能在轮换中出现的HP阈值。\n" +
                    "如果启用了“重定向治疗技能”选项，则该目标也会成为实际施放治疗技能的对象（即使某些技能本身不会先检测该目标的HP，例如连击中的替换技能等）。");

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
                        healStackText += "UI鼠标悬停目标" + nextStackItemMarker;
                    if (Service.Configuration.UseFieldMouseoverOverridesInDefaultHealStack)
                        healStackText += "场地鼠标悬停目标" + nextStackItemMarker;
                    healStackText += "软锁目标" + nextStackItemMarker;
                    healStackText += "硬锁目标" + nextStackItemMarker;
                    if (Service.Configuration.UseFocusTargetOverrideInDefaultHealStack)
                        healStackText += "焦点目标" + nextStackItemMarker;
                    if (Service.Configuration.UseLowestHPOverrideInDefaultHealStack)
                        healStackText += "最低血量队友" + nextStackItemMarker;
                    healStackText += "自己";
                }
                ImGuiEx.Spacing(new Vector2(10, 0));
                ImGuiEx.TextWrapped(ImGuiColors.DalamudGrey, healStackText);

                ImGuiEx.Spacing(new Vector2(0, 10));

                #endregion

                #region Heal Stack Customization Options

                var labelText = "治疗目标队列自定义选项";
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
                    if (ImGui.Checkbox("将UI鼠标悬停目标加入默认治疗队列", ref useUIMouseoverOverridesInDefaultHealStack))
                    {
                        Service.Configuration.UseUIMouseoverOverridesInDefaultHealStack =
                            useUIMouseoverOverridesInDefaultHealStack;
                        Service.Configuration.Save();
                    }

                    if (useCusHealStack) ImGui.EndDisabled();

                    ImGuiComponents.HelpMarker("此选项会将任何UI鼠标悬停目标（如队员列表悬停）加入默认治疗队列的最顶端，优先级高于队列中其他目标。\n\n推荐键鼠用户并启用“重定向治疗技能”时开启，或在重定向/反应配置中有UI鼠标悬停目标时开启。\n默认：关闭");

                    #endregion

                    #region Default Heal Stack Include: Field MouseOver

                    if (useCusHealStack) ImGui.BeginDisabled();

                    bool useFieldMouseoverOverridesInDefaultHealStack =
                        Service.Configuration.UseFieldMouseoverOverridesInDefaultHealStack;
                    if (ImGui.Checkbox("将场地鼠标悬停目标加入默认治疗队列", ref useFieldMouseoverOverridesInDefaultHealStack))
                    {
                        Service.Configuration.UseFieldMouseoverOverridesInDefaultHealStack =
                            useFieldMouseoverOverridesInDefaultHealStack;
                        Service.Configuration.Save();
                    }

                    if (useCusHealStack) ImGui.EndDisabled();

                    ImGuiComponents.HelpMarker("此选项会将任何场地鼠标悬停目标（如角色模型、姓名板悬停）加入默认治疗队列的最顶端，优先级高于队列中其他目标。\n\n仅建议你经常主动使用场地悬停时开启。\n默认：关闭");

                    #endregion

                    #region Default Heal Stack Include: Focus Target

                    if (useCusHealStack) ImGui.BeginDisabled();

                    bool useFocusTargetOverrideInDefaultHealStack =
                        Service.Configuration.UseFocusTargetOverrideInDefaultHealStack;
                    if (ImGui.Checkbox("将焦点目标加入默认治疗队列", ref useFocusTargetOverrideInDefaultHealStack))
                    {
                        Service.Configuration.UseFocusTargetOverrideInDefaultHealStack =
                            useFocusTargetOverrideInDefaultHealStack;
                        Service.Configuration.Save();
                    }

                    if (useCusHealStack) ImGui.EndDisabled();

                    ImGuiComponents.HelpMarker("此选项会将你的焦点目标插入到软锁和硬锁目标之后，优先级高于后续目标（如自身）。仅在焦点目标存活时生效。\n\n默认：关闭");

                    #endregion

                    #region Default Heal Stack Include: Lowest HP Ally

                    if (useCusHealStack) ImGui.BeginDisabled();

                    bool useLowestHPOverrideInDefaultHealStack =
                        Service.Configuration.UseLowestHPOverrideInDefaultHealStack;
                    if (ImGui.Checkbox("将最低HP%队友加入默认治疗队列", ref useLowestHPOverrideInDefaultHealStack))
                    {
                        Service.Configuration.UseLowestHPOverrideInDefaultHealStack =
                            useLowestHPOverrideInDefaultHealStack;
                        Service.Configuration.Save();
                    }

                    if (useCusHealStack) ImGui.EndDisabled();

                    ImGuiComponents.HelpMarker("此选项会将附近HP%最低的队友插入到默认治疗队列的底部，仅会覆盖自身。\n\n建议与上方“重定向治疗技能”选项配合使用！\n\n默认：关闭");

                    if (useCusHealStack) ImGui.BeginDisabled();
                    if (useLowestHPOverrideInDefaultHealStack)
                    {
                        ImGuiEx.Spacing(new Vector2(30, 0));
                        ImGuiEx.Text(ImGuiColors.DalamudYellow, "建议与上方“重定向治疗技能”选项配合使用！");
                    }
                    if (useCusHealStack) ImGui.EndDisabled();

                    #endregion

                    ImGuiEx.Spacing(new Vector2(5, 5));
                    ImGui.TextUnformatted("或");
                    ImGuiEx.Spacing(new Vector2(0, 5));

                    #region Use Custom Heal Stack

                    bool useCustomHealStack = Service.Configuration.UseCustomHealStack;
                    if (ImGui.Checkbox("使用自定义治疗目标队列", ref useCustomHealStack))
                    {
                        Service.Configuration.UseCustomHealStack = useCustomHealStack;
                        Service.Configuration.Save();
                    }

                    ImGuiComponents.HelpMarker("选择此项可自定义治疗目标优先级队列，替代默认队列。\n\n如果你未使用“重定向治疗技能”方案，建议根据你的重定向/反应配置自定义队列，否则按个人偏好设置。\n默认：关闭");

                    #endregion

                    #region Custom Heal Stack Manager

                    if (Service.Configuration.UseCustomHealStack)
                    {
                        ImGui.Indent();
                        UserConfig.DrawCustomStackManager(
                            "CustomHealStack",
                            ref Service.Configuration.CustomHealStack,
                            ["Enemy", "Attack", "Dead", "Living"],
                            "优先级从上到下排列。\n" +
                            "向下滚动可查看所有项目。\n" +
                            "点击上下按钮可调整顺序。\n" +
                            "点击X按钮可移除项目。\n\n" +
                            "若少于4项且全部无效，则会回退为自身。\n\n" +
                            "这些目标仅在为友方且25米内时有效。\n" +
                            "应用于复活或驱散时，会额外检查目标是否死亡或有可驱散的减益。\n" +
                            "（复活时：若队列无效则回退为硬锁目标或任意死亡队员）\n\n" +
                            "默认：焦点目标 > 硬锁目标 > 自身"
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

                ImGui.TextUnformatted("当前复活目标队列：");

                ImGuiComponents.HelpMarker(
                    "这是Wrath在尝试复活目标时的优先顺序，\n当启用任意复活重定向功能时生效。\n\n" +
                    "你可以在PvE>通用，或各拥有复活技能的职业页面找到相关设置。");

                ImGui.Indent();
                UserConfig.DrawCustomStackManager(
                    "CustomRaiseStack",
                    ref Service.Configuration.RaiseStack,
                    ["Enemy", "Attack", "MissingHP", "Lowest", "Chocobo", "Living"],
                    "优先级从上到下排列。\n" +
                    "向下滚动可查看所有项目。\n" +
                    "点击上下按钮可调整顺序。\n" +
                    "点击X按钮可移除项目。\n\n" +
                    "若少于5项且全部无效，则会回退为：\n" +
                    "你的硬锁目标（若其已死亡），或任意死亡队员。\n\n"+
                    "这些目标仅在为友方、死亡且30米内时有效。\n" +
                    "默认：任意治疗 > 任意坦克 > 任意可复活者 > 任意死亡队员",
                    true
                );
                ImGui.TextDisabled("（所有目标均会检查是否可被复活）");
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
