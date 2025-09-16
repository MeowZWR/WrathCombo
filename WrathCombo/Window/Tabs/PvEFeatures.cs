using Dalamud.Interface.Textures.TextureWraps;
using Dalamud.Interface.Utility.Raii;
using ECommons.ExcelServices;
using ECommons.GameHelpers;
using ECommons.ImGuiMethods;
using ECommons.Logging;
using System;
using System.Linq;
using System.Numerics;
using ECommons;
using WrathCombo.Core;
using WrathCombo.Extensions;
using WrathCombo.Services;
using WrathCombo.Window.Functions;
using WrathCombo.Window.MessagesNS;

namespace WrathCombo.Window.Tabs;

internal class PvEFeatures : ConfigWindow
{
    internal static Job? OpenJob;
    internal static int ColCount = 1;
    internal static new void Draw()
    {
        //#if !DEBUG
        if (ActionReplacer.ClassLocked())
        {
            ImGui.TextWrapped("Equip your job stone to re-unlock features.");
            return;
        }
        //#endif

        using (ImRaii.Child("scrolling", new Vector2(ImGui.GetContentRegionAvail().X, ImGui.GetContentRegionAvail().Y), true))
        {
            var indentWidth = 12f.Scale();
            var indentWidth2 = indentWidth + 42f.Scale();
            var iconMaxSize = 34f.Scale();
            var verticalCenteringPadding = (iconMaxSize - ImGui.GetTextLineHeight()) / 2f;

            if (OpenJob is null)
            {
                ImGui.SameLine(indentWidth);
                ImGuiEx.LineCentered(() =>
                {
                    ImGuiEx.TextUnderlined("请在下方选择职业以启用并配置其功能。");
                });

                ColCount = Math.Max(1, (int)(ImGui.GetContentRegionAvail().X / 200f.Scale()));

                using (var tab = ImRaii.Table("PvETable", ColCount))
                {
                    ImGui.TableNextColumn();

                    if (!tab)
                        return;

                    foreach (Job job in groupedPresets.Keys)
                    {
                        string jobName = groupedPresets[job].First().Info.JobName;
                        string abbreviation = groupedPresets[job].First().Info.JobShorthand;
                        string header = string.IsNullOrEmpty(abbreviation) ? jobName : $"{jobName} - {abbreviation}";
                        var id = groupedPresets[job].First().Info.Job;
                        IDalamudTextureWrap? icon = Icons.GetJobIcon(id);
                        ImGuiEx.Spacing(new Vector2(0, 2f.Scale()));
                        using (var disabled = ImRaii.Disabled(DisabledJobsPVE.Any(x => x == id)))
                        {
                            if (ImGui.Selectable($"###{header}", OpenJob == job, ImGuiSelectableFlags.None, new Vector2(0, iconMaxSize)))
                            {
                                OpenJob = job;
                            }
                            ImGui.SameLine(indentWidth);
                            if (icon != null)
                            {
                                var scale = Math.Min(iconMaxSize / icon.Size.X, iconMaxSize / icon.Size.Y);
                                var imgSize = new Vector2(icon.Size.X * scale, icon.Size.Y * scale);
                                var padSize = (iconMaxSize - imgSize.X) / 2f;
                                if (padSize > 0)
                                    ImGui.SetCursorPosX(ImGui.GetCursorPosX() + padSize);
                                ImGui.Image(icon.Handle, imgSize);
                            }
                            else
                            {
                                ImGui.Dummy(new Vector2(iconMaxSize, iconMaxSize));
                            }
                            ImGui.SameLine(indentWidth2);
                            ImGuiEx.Spacing(new Vector2(0, verticalCenteringPadding));
                            ImGui.Text($"{header} {(disabled ? "(因更新已禁用)" : "")}");

                            if (!string.IsNullOrEmpty(abbreviation) &&
                                P.UIHelper.JobControlled(id) is not null)
                            {
                                ImGui.SameLine();
                                P.UIHelper
                                    .ShowIPCControlledIndicatorIfNeeded(id, false, ColCount > 1);
                            }
                        }

                        ImGui.TableNextColumn();
                    }
                }
            }
            else
            {
                var id = groupedPresets[OpenJob.Value].First().Info.Job;
                IDalamudTextureWrap? icon = Icons.GetJobIcon(id);

                using (ImRaii.Child("HeadingTab", new Vector2(ImGui.GetContentRegionAvail().X, iconMaxSize)))
                {
                    if (ImGui.Button("返回", new Vector2(0, 24f.Scale())))
                    {
                        OpenJob = null;
                        return;
                    }
                    ImGui.SameLine();
                    ImGuiEx.LineCentered(() =>
                    {
                        if (icon != null)
                        {
                            var scale = Math.Min(iconMaxSize / icon.Size.X, iconMaxSize / icon.Size.Y);
                            var imgSize = new Vector2(icon.Size.X * scale, icon.Size.Y * scale);
                            var padSize = (iconMaxSize - imgSize.X) / 2f;
                            if (padSize > 0)
                                ImGui.SetCursorPosX(ImGui.GetCursorPosX() + padSize);
                            ImGui.Image(icon.Handle, imgSize);
                        }
                        else
                        {
                            ImGui.Dummy(new Vector2(iconMaxSize, iconMaxSize));
                        }
                        ImGui.SameLine();
                        ImGuiEx.Spacing(new Vector2(0, verticalCenteringPadding-2f.Scale()));
                        ImGuiEx.Text($"{OpenJob.Value.Name()}");
                    });

                    if (P.UIHelper.JobControlled(id) is not null)
                    {
                        ImGui.SameLine();
                        P.UIHelper
                            .ShowIPCControlledIndicatorIfNeeded(id);
                    }

                }

                using (ImRaii.Child("Contents", new Vector2(0)))
                {
                    currentPreset = 1;
                    try
                    {
                        if (ImGui.BeginTabBar($"subTab{OpenJob.Value.Name()}", ImGuiTabBarFlags.Reorderable | ImGuiTabBarFlags.AutoSelectNewTabs))
                        {
                            string mainTabName = OpenJob is Job.ADV ? "职业" : "普通";
                            if (ImGui.BeginTabItem(mainTabName))
                            {
                                DrawHeadingContents(OpenJob.Value);
                                ImGui.EndTabItem();
                            }

                            if (groupedPresets[OpenJob.Value].Any(x => PresetStorage.IsVariant(x.Preset)))
                            {
                                if (ImGui.BeginTabItem("多变迷宫"))
                                {
                                    DrawVariantContents(OpenJob.Value);
                                    ImGui.EndTabItem();
                                }
                            }

                            if (groupedPresets[OpenJob.Value].Any(x => PresetStorage.IsBozja(x.Preset)))
                            {
                                if (ImGui.BeginTabItem("博兹雅"))
                                {
                                    DrawBozjaContents(OpenJob.Value);
                                    ImGui.EndTabItem();
                                }
                            }

                            if (groupedPresets[OpenJob.Value].Any(x => PresetStorage.IsEureka(x.Preset)))
                            {
                                if (ImGui.BeginTabItem("优雷卡"))
                                {
                                    ImGui.EndTabItem();
                                }
                            }

                            if (groupedPresets[OpenJob.Value].Any(x => PresetStorage.IsOccultCrescent(x.Preset)))
                            {
                                if (ImGui.BeginTabItem("新月岛"))
                                {
                                    DrawOccultContents(OpenJob.Value);
                                    ImGui.EndTabItem();
                                }
                            }

                            ImGui.EndTabBar();
                        }
                    }
                    catch (Exception e)
                    {
                        PluginLog.Error($"绘制职业UI时发生错误:\n{e.ToStringFull()}");
                    }

                }
            }

        }
    }

    private static void DrawVariantContents(Job job)
    {
        foreach (var (preset, info) in groupedPresets[job].Where(x =>
            PresetStorage.IsVariant(x.Preset) &&
            !PresetStorage.ShouldBeHidden(x.Preset)))
        {
            InfoBox presetBox = new() { CurveRadius = 8f, ContentsAction = () => { Presets.DrawPreset(preset, info); } };
            presetBox.Draw();
            ImGuiEx.Spacing(new Vector2(0, 12));
        }
    }

    private static void DrawBozjaContents(Job job)
    {
        foreach (var (preset, info) in groupedPresets[job].Where(x =>
            PresetStorage.IsBozja(x.Preset) &&
            !PresetStorage.ShouldBeHidden(x.Preset)))
        {
            InfoBox presetBox = new() { CurveRadius = 8f, ContentsAction = () => { Presets.DrawPreset(preset, info); } };
            presetBox.Draw();
            ImGuiEx.Spacing(new Vector2(0, 12));
        }
    }

    private static void DrawOccultContents(Job job)
    {
        foreach (var (preset, info) in groupedPresets[job].Where(x =>
            PresetStorage.IsOccultCrescent(x.Preset) &&
            !PresetStorage.ShouldBeHidden(x.Preset)))
        {
            InfoBox presetBox = new() { CurveRadius = 8f, ContentsAction = () => { Presets.DrawPreset(preset, info); } };
            presetBox.Draw();
            ImGuiEx.Spacing(new Vector2(0, 12));
        }
    }

    internal static void DrawHeadingContents(Job job)
    {
        if (!Messages.PrintBLUMessage(job)) return;

        foreach (var (preset, info) in groupedPresets[job].Where(x =>
            !PresetStorage.IsPvP(x.Preset) &&
            !PresetStorage.IsVariant(x.Preset) &&
            !PresetStorage.IsBozja(x.Preset) &&
            !PresetStorage.IsEureka(x.Preset) &&
            !PresetStorage.IsOccultCrescent(x.Preset) &&
            !PresetStorage.ShouldBeHidden(x.Preset)))
        {
            InfoBox presetBox = new() { ContentsOffset = 5f.Scale(), ContentsAction = () => { Presets.DrawPreset(preset, info); } };

            if (Service.Configuration.HideConflictedCombos)
            {
                var conflictOriginals = PresetStorage.GetConflicts(preset); // Presets that are contained within a ConflictedAttribute
                var conflictsSource = PresetStorage.GetAllConflicts();      // Presets with the ConflictedAttribute

                if (conflictsSource.All(x => x != preset) || conflictOriginals.Length == 0)
                {
                    presetBox.Draw();
                    ImGuiEx.Spacing(new Vector2(0, 12));
                    continue;
                }

                if (conflictOriginals.Any(PresetStorage.IsEnabled))
                {
                    if (DateTime.UtcNow - LastPresetDeconflictTime > TimeSpan.FromSeconds(3))
                    {
                        if (Service.Configuration.EnabledActions.Remove(preset))
                        {
                            PluginLog.Debug($"因冲突移除 {preset}");
                            Service.Configuration.Save();
                        }
                        LastPresetDeconflictTime = DateTime.UtcNow;
                    }

                    // Keep removed items in the counter
                    var parent = PresetStorage.GetParent(preset) ?? preset;
                    currentPreset += 1 + Presets.AllChildren(presetChildren[parent]);
                }

                else
                    presetBox.Draw();
            }

            else
            {
                presetBox.Draw();
                ImGuiEx.Spacing(new Vector2(0, 12));
            }
        }
    }

    internal static void OpenToCurrentJob(bool onJobChange)
    {
        if ((!onJobChange || !Service.Configuration.OpenToCurrentJobOnSwitch) &&
            (onJobChange || !Service.Configuration.OpenToCurrentJob ||
             !Player.Available)) return;

        if (onJobChange && !P.ConfigWindow.IsOpen)
            return;

        if (Player.Job.IsDoh())
            return;

        if (Player.Job.IsDol())
        {
            OpenJob = Job.MIN;
            return;
        }

        var job = Player.Job.GetUpgradedJob();
        if (groupedPresets.ContainsKey(job))
            OpenJob = job;
    }
}