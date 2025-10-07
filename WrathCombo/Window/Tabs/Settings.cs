using Dalamud.Interface.Colors;
using Dalamud.Interface.Components;
using Dalamud.Interface.Utility.Raii;
using ECommons.ExcelServices;
using ECommons.GameHelpers;
using ECommons.ImGuiMethods;
using System;
using System.Linq;
using System.Numerics;
using WrathCombo.CustomComboNS.Functions;
using WrathCombo.Extensions;
using WrathCombo.Services;
using WrathCombo.Window.Functions;
using ECommons.DalamudServices;
using WrathCombo.Resources.Dictionary.Chinese;
namespace WrathCombo.Window.Tabs;

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

            if (ImGui.Checkbox("隐藏子功能选项", ref hideChildren))
            {
                Service.Configuration.HideChildren = hideChildren;
                Service.Configuration.Save();
            }

            ImGuiComponents.HelpMarker("隐藏已禁用功能的子选项。");

            #endregion

            #region Conflicting

            bool hideConflicting = Service.Configuration.HideConflictedCombos;
            if (ImGui.Checkbox("隐藏冲突连击", ref hideConflicting))
            {
                Service.Configuration.HideConflictedCombos = hideConflicting;
                Service.Configuration.Save();
            }

            ImGuiComponents.HelpMarker("隐藏与您已选择的其他连击冲突的连击。");

            #endregion

            #region Shorten DTR bar text

            bool shortDTRText = Service.Configuration.ShortDTRText;

            if (ImGui.Checkbox("简化服务器信息栏文本", ref shortDTRText))
            {
                Service.Configuration.ShortDTRText = shortDTRText;
                Service.Configuration.Save();
            }

            ImGuiComponents.HelpMarker(
                "默认情况下，Wrath Combo 的服务器信息栏会显示自动循环是否开启，" +
                "\n如果开启，则会显示已启用的自动模式连击数量。" +
                "\n最后还会显示是否有其他插件控制该值。" +
                "\n启用此选项后，将不再显示已启用的自动模式连击数量。"
            );

            #endregion

            #region Message of the Day

            bool motd = Service.Configuration.HideMessageOfTheDay;

            if (ImGui.Checkbox("隐藏每日提示", ref motd))
            {
                Service.Configuration.HideMessageOfTheDay = motd;
                Service.Configuration.Save();
            }

            ImGuiComponents.HelpMarker("登录时不在聊天栏显示每日提示信息。");

            #endregion

            #region TargetHelper

            Vector4 colour = Service.Configuration.TargetHighlightColor;
            if (ImGui.ColorEdit4("目标高亮颜色", ref colour, ImGuiColorEditFlags.NoInputs | ImGuiColorEditFlags.AlphaPreview | ImGuiColorEditFlags.AlphaBar))
            {
                Service.Configuration.TargetHighlightColor = colour;
                Service.Configuration.Save();
            }

            ImGuiComponents.HelpMarker("在原生队伍列表中为被特定功能选中的队员绘制高亮框。\n将Alpha设为0可隐藏高亮框。");

            ImGui.SameLine();
            ImGui.TextColored(ImGuiColors.DalamudGrey, $"（目前仅用于 {Job.AST.Name()}）");

            #endregion

            #region Child Borders

            bool childBorders = Service.Configuration.ShowBorderAroundOptionsWithChildren;

            if (ImGui.Checkbox("为带子选项的职业显示边框", ref childBorders))
            {
                Service.Configuration.ShowBorderAroundOptionsWithChildren = childBorders;
                Service.Configuration.Save();
            }

            ImGuiComponents.HelpMarker("切换是否为拥有多个子选项的职业功能显示边框");

            #endregion

            #region Preset IDs

            bool showIDs = Service.Configuration.UIShowPresetIDs;

            if (ImGui.Checkbox("在描述前显示预设ID", ref showIDs))
            {
                Service.Configuration.UIShowPresetIDs = showIDs;
                Service.Configuration.Save();
            }

            ImGuiComponents.HelpMarker("切换是否在描述前显示预设（连击、功能等）ID。\n这些ID可用于如 `/wrath toggle <ID>` 等命令。\n7.3版本前此处显示的数字更短，不是完整ID。");

            #endregion

            #region Search Bar

            bool showSearchBar = Service.Configuration.UIShowSearchBar;

            if (ImGui.Checkbox("在职业页显示搜索栏", ref showSearchBar))
            {
                Service.Configuration.UIShowSearchBar = showSearchBar;
                Service.Configuration.Save();
            }

            ImGuiComponents.HelpMarker("切换是否在所有PvE和PvP职业页顶部显示搜索栏");

            #endregion

            ImGuiEx.Spacing(new Vector2(0, 10));

            #region Open to PvE

            if (ImGui.Checkbox("打开Wrath时默认进入PvE功能页", ref
                Service.Configuration.OpenToPvE))
                Service.Configuration.Save();

            ImGuiComponents.HelpMarker("使用 `/wrath` 命令打开Wrath时，默认进入PvE功能页，而不是上次停留的标签页。" +
                                       "\n等同于每次都使用 `/wrath pve` 命令。");

            #endregion

            #region Open to PvP

            if (ImGui.Checkbox("在PvP区域打开Wrath时默认进入PvP功能页", ref
                Service.Configuration.OpenToPvP))
                Service.Configuration.Save();

            ImGuiComponents.HelpMarker("同上，在PvP区域使用 `/wrath` 命令时，默认进入PvP功能页，而不是上次停留的标签页。" +
                                       "\n类似于使用 `/wrath pvp` 命令。");

            ImGui.SameLine();
            ImGui.TextColored(ImGuiColors.DalamudGrey, "（此项会覆盖上方设置）");

            #endregion

            #region Open to Current Job

            if (ImGui.Checkbox("打开PvE功能页时自动切换到当前职业", ref Service.Configuration.OpenToCurrentJob))
                Service.Configuration.Save();

            ImGuiComponents.HelpMarker("打开Wrath界面时，如果上次停留在PvE页，将自动切换到当前所玩的职业。");

            #endregion

            #region Open to Current Job on Switching

            if (ImGui.Checkbox("切换职业时自动切换到对应PvE功能页", ref Service.Configuration.OpenToCurrentJobOnSwitch))
                Service.Configuration.Save();

            ImGuiComponents.HelpMarker("切换职业时，PvE功能页会自动切换到当前所玩的职业。");

            #endregion

            #endregion

            #region Rotation Behavior Options

            ImGuiEx.Spacing(new Vector2(0, 20));
            ImGuiEx.TextUnderlined("循环行为选项");

            #region Spells while Moving

            if (ImGui.Checkbox("移动时阻止施法", ref Service.Configuration.BlockSpellOnMove))
                Service.Configuration.Save();

            ImGuiComponents.HelpMarker("移动时完全阻止法术释放，会用狂怒剑替换你的技能。\n此设置会覆盖大多数职业的连击专属移动选项。\n\n建议保持关闭，大多数连击已能更优雅地处理移动。\n默认：关闭");

            #endregion

            #region Action Changing

            if (ImGui.Checkbox("技能替换", ref Service.Configuration.ActionChanging))
                Service.Configuration.Save();

            ImGuiComponents.HelpMarker("控制是否由插件拦截并替换技能为连击。\n关闭后，你手动按下的技能将不再受Wrath设置影响。\n\n自动循环无论此设置如何都可用。\n\n可通过 `/wrath combo` 命令控制。\n\n如需在不开启自动循环时使用Wrath，必须保持开启。\n默认：开启");

            #endregion

            #region Performance Mode

            if (Service.Configuration.ActionChanging) {
                ImGui.Indent();
                if (ImGui.Checkbox("性能模式", ref Service.Configuration.PerformanceMode))
                    Service.Configuration.Save();

                ImGuiComponents.HelpMarker("启用此模式后，热键栏上的技能图标将不会被插件替换，但你按下技能时插件依然会在后台正常工作。\n\n如果你遇到性能问题，建议尝试开启此选项。\n默认：关闭");
                ImGui.Unindent();
            }

            #endregion

            #region Queued Action Suppression

            if (ImGui.Checkbox($"队列技能冲突抑制", ref Service.Configuration.SuppressQueuedActions))
                Service.Configuration.Save();

            ImGuiComponents.HelpMarker("启用时：\n当你排队的技能与当前按下的技能不一致时，Wrath会禁用所有其他连击，防止它们误判队列技能。\n- 这样可以避免不同连击因技能重叠而互相冲突。\n- 但会导致每个连击的“被替换技能”在排队时闪烁，仅为视觉效果，不会实际释放。\n\n关闭时：\n连击不会因技能排队而被禁用。\n- 这样可以避免热键栏图标闪烁，仅有此好处。\n- 但可能导致连击间冲突，例如一个连击返回的技能正好是另一个连击的被替换技能。\n我们不会标记或避免此类冲突。\n\n强烈建议保持此设置开启。\n如果不喜欢图标闪烁，建议优先使用性能模式，而不是关闭此项。\n默认：开启");

            ImGui.SameLine();
            ImGuiEx.Spacing(new Vector2(10, 0));
            ImGui.TextColored(ImGuiColors.DalamudGrey, "详细说明：");

            ImGuiComponents.HelpMarker($"启用后，当你排队的技能与当前按下的技能不一致时，会禁用所有其他按钮的功能。这解决了由于游戏处理技能队列方式导致的错误技能释放问题，但会降低热键栏的视觉体验。不建议关闭此项，如果你不喜欢热键栏图标快速变化，可以通过关闭此项或开启性能模式来解决，但请注意关闭后可能导致多个连击互相冲突。\n\n" +
                                       $"详细机制说明：每次使用技能时，流程如下：" +
                                       $"\n1. 如果技能触发GCD（武器技能/法术），且GCD未激活，则立即使用。" +
                                       $"\n2. 否则，如果在“队列窗口”（通常为GCD最后0.5秒）内，则先加入队列再使用。" +
                                       $"\n3. 如果是能力技，只要没有动画锁则立即使用。" +
                                       $"\n4. 否则，立即加入队列，动画锁结束后使用。" +
                                       $"\n\n第1步时，传递给游戏的是原始技能，实际释放时才会被替换。第2步时，队列中依然是原始技能，但执行队列时会把被替换的技能当作原始技能处理。" +
                                       $"\n\n例如：原始技能为治疗，替换为治疗II。第1步时，游戏会把治疗替换为治疗II。第2步时，治疗加入队列，但队列执行时会把它当作治疗II。" +
                                       $"\n\n第3、4步类似，只是发生得更早。" +
                                       $"\n\n如果有一个功能把治疗替换为治疗II，另一个把治疗II替换为再生，且都开启时，流程如下：" +
                                       $"\n\n第1步，治疗被替换为治疗II。你在队列窗口再次按下治疗，治疗加入队列，但队列执行时会当作治疗II。\n结果是本应释放治疗II，却变成了再生，因为我们又把治疗II替换成了再生。" +
                                       $"\n这不是第一个功能的本意，因此是错误技能。" +
                                       $"\n\n我们的解决方法是：当排队技能与当前技能不一致时，禁用所有其他技能替换功能，此设置即控制此行为。");

            #endregion

            #region Throttle

            var len = ImGui.CalcTextSize("毫秒").X;

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
            ImGui.Text($"   -   技能更新频率");


            ImGuiComponents.HelpMarker(
                "此项控制连击技能在热键栏上更新的频率（毫秒）。" +
                "\n默认情况下不限制，始终保持最新技能。" +
                "\n\n如果你有轻微的帧数问题，可以适当提高此值，减少连击检测频率。" +
                "\n这会让连击响应变慢，甚至可能导致GCD卡顿。" +
                "\n数值过高可能导致循环完全失效。" +
                "\n严重的性能问题建议优先使用上方的性能模式。" +
                "\n\n200ms通常能显著改善帧数。" +
                "\n不建议超过500ms。" +
                "\n默认：50");

            #endregion

            #region Movement Check Delay

            ImGui.PushItemWidth(75);
            if (ImGui.InputFloat("###MovementLeeway", ref Service.Configuration.MovementLeeway))
                Service.Configuration.Save();

            ImGui.SameLine();
            ImGui.Text("秒");

            ImGui.SameLine(pos);

            ImGui.Text($"   -   移动判定延迟");

            ImGuiComponents.HelpMarker("许多功能会检测你是否在移动，此项可设置需要持续移动多久才判定为移动。\n这样可以避免短暂的小幅移动影响循环，主要用于法系职业。\n\n建议设置在0~1秒之间。\n默认：0.0");

            #endregion

            #region Opener Failure Timeout

            if (ImGui.InputFloat("###OpenerTimeout", ref Service.Configuration.OpenerTimeout))
                Service.Configuration.Save();

            ImGui.SameLine();
            ImGui.Text("秒");

            ImGui.SameLine(pos);

            ImGui.Text($"   -   起手失败超时");

            ImGuiComponents.HelpMarker("在起手期间，如果距离上次释放技能超过此时间，将判定起手失败并恢复为正常循环。\n\n建议设置小于6秒。\n默认：4.0");

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

            ImGuiComponents.HelpMarker("近战判定距离的偏移量。\n适用于不希望BOSS稍微移动就立刻切换远程技能的情况。\n\n例如，设置为-0.5时，需要比正常距离再靠近0.5亚姆才判定为近战；设置为2时，则要离BOSS再远2亚姆才会触发远程技能。\n\n建议保持为0。\n默认：0.0");
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
            ImGui.Text($"%");
            ImGui.SameLine( pos);
            ImGui.Text($"   -   施法进度打断延迟");

            ImGuiComponents.HelpMarker("打断技能时，等待施法总时间的百分比。\n适用于所有职业的打断技能。\n\n建议低于50%。\n默认：0%");

            #endregion
                
            #region Maximum Weaves

            ImGui.PushItemWidth(75);
            if (ImGui.SliderInt("###MaximumWeaves", ref Service.Configuration.MaximumWeavesPerWindow, 1, 3))
                Service.Configuration.Save();

            ImGui.SameLine();
            ImGui.Text("个");

            ImGui.SameLine(pos);

            ImGui.Text($"   -   最大插入能力技数");

            ImGuiComponents.HelpMarker("控制每个GCD之间允许插入的能力技数量。\n游戏默认是双插，低延迟下也可以三插；如果你网络延迟较高，建议只用单插。\n三插会尽量避免卡GCD，实际触发频率也不高，所以对大部分玩家来说是安全的。\n\n默认：2");

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
                "此项会将所有单体治疗技能重定向到下方的治疗目标堆栈，类似于Redirect或Reaction功能。\n这样用于判断治疗技能触发阈值的目标和实际接受治疗的目标一致。\n\n如果你自定义了治疗目标堆栈，建议开启此项。\n默认：关闭");
            Presets.DrawRetargetedSymbolForSettingsPage();

            bool addNpcs = 
                Service.Configuration.AddOutOfPartyNPCsToRetargeting;

            if (ImGui.Checkbox("将非队伍NPC加入治疗重定向", ref addNpcs))
            {
                Service.Configuration.AddOutOfPartyNPCsToRetargeting = addNpcs;
                Service.Configuration.Save();
            }

            ImGuiComponents.HelpMarker(
                "此项会将不在队伍中的NPC加入治疗技能的重定向逻辑。\n\n" +
                "适用于希望治疗任务NPC等非队友目标的奶妈。\n\n" +
                "这些NPC无法参与基于职业的自定义堆栈（即使NPC看起来像防护职业，也不会被识别为防护职业）。\n\n" +
                "默认：关闭");

            #endregion

            ImGuiEx.Spacing(new Vector2(0, 10));

            #region Current Heal Stack

            ImGui.TextUnformatted("当前治疗目标堆栈：");

            ImGuiComponents.HelpMarker(
                "Wrath会按如下顺序尝试选择治疗目标：\n\n" +
                "如果未开启“重定向治疗技能”，则仅用于判断治疗技能触发阈值的目标。\n" +
                "如果开启，则该目标也会作为实际治疗技能的目标（即使技能本身不检测该目标的血量，例如连击的被替换技能）。");

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
                    healStackText += "UI-鼠标悬停目标" + nextStackItemMarker;
                if (Service.Configuration.UseFieldMouseoverOverridesInDefaultHealStack)
                    healStackText += "地面-鼠标悬停目标" + nextStackItemMarker;
                healStackText += "软目标" + nextStackItemMarker;
                healStackText += "硬目标" + nextStackItemMarker;
                if (Service.Configuration.UseFocusTargetOverrideInDefaultHealStack)
                    healStackText += "焦点目标" + nextStackItemMarker;
                if (Service.Configuration.UseLowestHPOverrideInDefaultHealStack)
                    healStackText += "最低HP%队友" + nextStackItemMarker;
                healStackText += "自己";
            }
            ImGuiEx.Spacing(new Vector2(10, 0));
            ImGuiEx.TextWrapped(ImGuiColors.DalamudGrey, healStackText);

            ImGuiEx.Spacing(new Vector2(0, 10));

            #endregion

            #region Heal Stack Customization Options

            var labelText = "治疗目标堆栈自定义选项";
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
                if (ImGui.Checkbox("添加UI-鼠标悬停目标到默认治疗堆栈", ref useUIMouseoverOverridesInDefaultHealStack))
                {
                    Service.Configuration.UseUIMouseoverOverridesInDefaultHealStack =
                        useUIMouseoverOverridesInDefaultHealStack;
                    Service.Configuration.Save();
                }

                if (useCusHealStack) ImGui.EndDisabled();

                ImGuiComponents.HelpMarker("此选项会将任何UI鼠标悬停目标添加到默认治疗堆栈的顶部，如果你将鼠标悬停在任何队员UI上，将覆盖堆栈的其余部分。\n\n建议键鼠用户并启用重定向治疗动作（或在重定向/反应配置中有UI鼠标悬停目标）时开启。\n默认：关闭");

                #endregion

                #region Default Heal Stack Include: Field MouseOver

                if (useCusHealStack) ImGui.BeginDisabled();

                bool useFieldMouseoverOverridesInDefaultHealStack =
                    Service.Configuration.UseFieldMouseoverOverridesInDefaultHealStack;
                if (ImGui.Checkbox("将场地鼠标悬停目标添加到默认治疗堆栈", ref useFieldMouseoverOverridesInDefaultHealStack))
                {
                    Service.Configuration.UseFieldMouseoverOverridesInDefaultHealStack =
                        useFieldMouseoverOverridesInDefaultHealStack;
                    Service.Configuration.Save();
                }

                if (useCusHealStack) ImGui.EndDisabled();

                ImGuiComponents.HelpMarker("此选项会将任何鼠标悬停目标（如姓名板或角色模型）添加到默认治疗堆栈的顶部，覆盖堆栈的其余部分。\n\n仅建议你经常有意使用场地鼠标悬停选目标时开启。\n默认：关闭");

                #endregion

                #region Default Heal Stack Include: Focus Target

                if (useCusHealStack) ImGui.BeginDisabled();

                bool useFocusTargetOverrideInDefaultHealStack =
                    Service.Configuration.UseFocusTargetOverrideInDefaultHealStack;
                if (ImGui.Checkbox("将专注目标添加到默认治疗堆栈", ref useFocusTargetOverrideInDefaultHealStack))
                {
                    Service.Configuration.UseFocusTargetOverrideInDefaultHealStack =
                        useFocusTargetOverrideInDefaultHealStack;
                    Service.Configuration.Save();
                }

                if (useCusHealStack) ImGui.EndDisabled();

                ImGuiComponents.HelpMarker("此选项会将你的专注目标添加到默认治疗堆栈的软目标和硬目标之后，如果你有存活的专注目标，将覆盖堆栈的其余部分。\n\n默认：关闭");

                #endregion

                #region Default Heal Stack Include: Lowest HP Ally

                if (useCusHealStack) ImGui.BeginDisabled();

                bool useLowestHPOverrideInDefaultHealStack =
                    Service.Configuration.UseLowestHPOverrideInDefaultHealStack;
                if (ImGui.Checkbox("将最低HP%队友添加到默认治疗堆栈", ref useLowestHPOverrideInDefaultHealStack))
                {
                    Service.Configuration.UseLowestHPOverrideInDefaultHealStack =
                        useLowestHPOverrideInDefaultHealStack;
                    Service.Configuration.Save();
                }

                if (useCusHealStack) ImGui.EndDisabled();

                ImGuiComponents.HelpMarker("此选项会将附近HP百分比最低的队友添加到默认治疗堆栈的底部，仅覆盖你自己。\n\n此选项应与上方的“重定向治疗动作”设置一起使用！\n\n默认：关闭");

                if (useCusHealStack) ImGui.BeginDisabled();
                if (useLowestHPOverrideInDefaultHealStack)
                {
                    ImGuiEx.Spacing(new Vector2(30, 0));
                    ImGuiEx.Text(ImGuiColors.DalamudYellow, "建议与上方的“重定向治疗动作”设置一起使用！");
                }
                if (useCusHealStack) ImGui.EndDisabled();

                #endregion

                ImGuiEx.Spacing(new Vector2(5, 5));
                ImGui.TextUnformatted("或");
                ImGuiEx.Spacing(new Vector2(0, 5));

                #region Use Custom Heal Stack

                bool useCustomHealStack = Service.Configuration.UseCustomHealStack;
                if (ImGui.Checkbox("使用自定义治疗堆栈", ref useCustomHealStack))
                {
                    Service.Configuration.UseCustomHealStack = useCustomHealStack;
                    Service.Configuration.Save();
                }

                ImGuiComponents.HelpMarker("如果你希望自定义治疗目标优先级堆栈而不是使用默认堆栈，请选择此项。\n\n如果你没有使用重定向治疗动作设置，建议根据你的重定向/反应配置进行自定义，否则按个人喜好。\n默认：关闭");

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
                        "向下滚动以查看所有项目。\n" +
                        "点击上下按钮可移动列表中的项目。\n" +
                        "点击X按钮可移除列表中的项目。\n\n" +
                        "如果少于4个项目，且全部检查无效，则会回退到自己。\n\n" +
                        "这些目标仅在为友方且在25米范围内时才有效。\n" +
                        "当此堆栈用于复活或康复时，将检查目标是否死亡或有可净化的异常。\n" +
                        "（复活时：堆栈会回退到你的硬目标或任意死亡队员）\n\n" +
                        "默认：专注目标 > 硬目标 > 自己"
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

            ImGui.TextUnformatted("当前复活堆栈：");

            ImGuiComponents.HelpMarker(
                "这是Wrath在尝试选择复活目标时的优先顺序，\n如果启用了任何复活功能的重定向。\n\n你可以在PvE>通用下找到复活功能，\n或在每个拥有复活技能的职业下找到。");

            ImGui.Indent();
            UserConfig.DrawCustomStackManager(
                "CustomRaiseStack",
                ref Service.Configuration.RaiseStack,
                ["Enemy", "Attack", "MissingHP", "Lowest", "Chocobo", "Living"],
                "优先级从上到下排列。\n" +
                "向下滚动以查看所有项目。\n" +
                "点击上下按钮可移动列表中的项目。\n" +
                "点击X按钮可移除列表中的项目。\n\n" +
                "如果少于5个项目，且全部检查无效，则会回退到：\n" +
                "你的硬目标（如果其已死亡），或<任意死亡队员>。\n\n"+
                "这些目标仅在为友方、死亡且在30米范围内时才有效。\n" +
                "默认：任意治疗 > 任意防护职业 > 任意可复活者 > 任意死亡队员",
                true
            );
            ImGui.TextDisabled("（所有目标都会检查是否可被复活）");
            ImGui.Unindent();

            #endregion

            #endregion

            #region Troubleshooting Options

            ImGuiEx.Spacing(new Vector2(0, 20));
            ImGuiEx.TextUnderlined("故障排查 / 分析选项");

            #region Combat Log

            bool showCombatLog = Service.Configuration.EnabledOutputLog;

            if (ImGui.Checkbox("输出日志到聊天", ref showCombatLog))
            {
                Service.Configuration.EnabledOutputLog = showCombatLog;
                Service.Configuration.Save();
            }

            ImGuiComponents.HelpMarker("每次你使用技能时，插件都会将其输出到聊天。");
            #endregion

            #region Opener Log

            if (ImGui.Checkbox($"输出起手状态到聊天", ref Service.Configuration.OutputOpenerLogs))
                Service.Configuration.Save();

            ImGuiComponents.HelpMarker("每当你的职业起手准备好、失败或如预期完成时，都会输出到聊天。");
            #endregion

            #region Debug File

            if (ImGui.Button("生成调试文件"))
            {
                if (Player.Available)
                    DebugFile.MakeDebugFile();
                else
                    DebugFile.MakeDebugFile(allJobs: true);
            }

            ImGuiComponents.HelpMarker("将在桌面生成一个调试文件。\n可用于开发者协助排查问题。\n等同于使用以下命令：/wrath debug");

            #endregion

            #endregion
        }
    }

    #region Custom Heal Stack Manager Methods

    private static bool _unCollapsed;
    private static float _healStackCustomizationHeight = 0;

    #endregion
}