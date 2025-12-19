#region

using Dalamud.Interface;
using Dalamud.Interface.Colors;
using Dalamud.Interface.Components;
using Dalamud.Interface.Utility;
using Dalamud.Interface.Utility.Raii;
using ECommons.DalamudServices;
using ECommons.ImGuiMethods;
using ECommons.Logging;
using FFXIVClientStructs.FFXIV.Common.Math;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using WrathCombo.Core;
using static WrathCombo.CustomComboNS.Functions.CustomComboFunctions;
using WrathCombo.Services;
using Vector4 = System.Numerics.Vector4;

#endregion

namespace WrathCombo.Window;

internal class MajorChangesWindow : Dalamud.Interface.Windowing.Window
{
    /// <summary>
    ///     Create a major changes window, with some settings about it.
    /// </summary>
    public MajorChangesWindow() : base("Wrath Combo | 新变更")
    {
        PluginLog.Debug(
            "MajorChangesWindow: " +
            $"IsVersionProblematic: {DoesVersionHaveChange}, " +
            $"IsSuggestionHiddenForThisVersion: {IsPopupHiddenForThisVersion}, " +
            $"WasUsingOldNINJitsuOptions: {WasUsingOldNINConfigs}"
        );
        if (DoesVersionHaveChange &&
            !IsPopupHiddenForThisVersion)
            IsOpen = true;

        BringToFront();

        Flags = ImGuiWindowFlags.AlwaysAutoResize;
    }

    /// <summary>
    ///     Draw the settings change suggestion window.
    /// </summary>
    public override void Draw()
    {
        PadOutMinimumWidthFor("Wrath Combo | 新变更");

        /*ImGuiEx.Spacing(new System.Numerics.Vector2(0, 10));
        ImGui.Separator();
        ImGuiEx.Spacing(new System.Numerics.Vector2(0, 10));*/

        #region NIN

        ImGuiEx.TextUnderlined("忍者忍术相关设置已重新构建");
        if (WasUsingOldNINConfigs)
            ImGuiEx.Text(ImGuiColors.DalamudYellow,
                "您正在使用这些选项之一！请仔细阅读！");
        ImGuiEx.Text(
            "忍者的忍术相关设置现在各自成为独立的功能，\n" +
            "而不再是忍术选项下的复选框。\n" +
            "如果您正在使用这些选项之一，则需要重新设置这些新设置。\n\n" +
            "您可以在以下位置找到这些已移动的设置：\n" +
            "PvE功能 > 忍者 > 单体目标和范围攻击高级 > 忍术选项");
        ImGui.NewLine();
        if (ImGui.Button("> 打开忍者配置##majorSettings2"))
            P.HandleOpenCommand(["NIN"], forceOpen: true);
        ImGui.SameLine();
        ImGui.Text("（然后搜索\"Ninjitsu\"即可）");

        #endregion

        #region Close and Do not Show again

        ImGuiEx.Spacing(new System.Numerics.Vector2(0, 20));
        ImGui.Separator();
        ImGuiHelpers.CenterCursorFor(
            ImGuiHelpers.GetButtonSize("关闭且不再显示").X
            //+ ImGui.GetStyle().ItemSpacing.X * 2
        );
        if (ImGui.Button("关闭且不再显示"))
        {
            Service.Configuration.HideMajorChangesForVersion = Version;
            Service.Configuration.Save();
            IsOpen = false;
        }

        #endregion

        if (_centeredWindow < 5)
            CenterWindow();
    }

    #region Minimum Width

    private void PadOutMinimumWidthFor(string windowName)
    {
        using (ImRaii.PushColor(ImGuiCol.Text, new Vector4(0)))
        {
            using (ImRaii.PushFont(UiBuilder.IconFont))
            {
                ImGui.Text(FontAwesomeIcon.CaretDown.ToIconString());
            }

            ImGui.SameLine();
            ImGui.Text(windowName);
            ImGui.SameLine();
            using (ImRaii.PushFont(UiBuilder.IconFont))
            {
                ImGui.Text(FontAwesomeIcon.Bars.ToIconString());
            }

            ImGui.SameLine();
            using (ImRaii.PushFont(UiBuilder.IconFont))
            {
                ImGui.Text(FontAwesomeIcon.Times.ToIconString());
            }
        }
    }

    #endregion

    #region Version Checking

    /// <summary>
    ///     The current plugin version.
    /// </summary>
    private static readonly Version Version =
        Svc.PluginInterface.Manifest.AssemblyVersion;

    /// <summary>
    ///     The version where the problem was introduced.
    /// </summary>
    private static readonly Version VersionWhereChangeIntroduced =
        new(1, 0, 2, 24);

    /// <summary>
    ///     Whether the current version is problematic.
    /// </summary>
    /// <remarks>No need to update this value to re-use this window.</remarks>
    private static readonly bool DoesVersionHaveChange =
        Version >= VersionWhereChangeIntroduced;

    /// <summary>
    ///     Whether the suggestion should be hidden for this version.
    /// </summary>
    private static readonly bool IsPopupHiddenForThisVersion =
        Service.Configuration.HideMajorChangesForVersion >= VersionWhereChangeIntroduced;

    #endregion

    #region Specific Info to Display for Update

    private static bool _getConfigValue(string config) =>
        Configuration.GetCustomBoolArrayValue(config) != Array.Empty<bool>() ||
        Configuration.GetCustomIntValue(config) > 0;

    /// <summary>
    ///     If the user was using MNK's old Burst Configs
    /// </summary>
    private static bool WasUsingOldNINConfigs =>
        _getConfigValue("NIN_ST_AdvancedMode_TenChiJin_Options") ||
        _getConfigValue("NIN_ST_AdvancedMode_Ninjitsus_Options") ||
        _getConfigValue("NIN_AoE_AdvancedMode_TenChiJin_Options") ||
        _getConfigValue("NIN_AoE_AdvancedMode_Ninjitsus_Options") ||
        _getConfigValue("NIN_AoE_AdvancedMode_Doton_Threshold") ||
        _getConfigValue("NIN_AoE_AdvancedMode_HutonSetup") ||
        _getConfigValue("NIN_ST_AdvancedMode_Raiton_Options") ||
        _getConfigValue("NIN_AoE_AdvancedMode_Katon_Options") ||
        _getConfigValue("NIN_AoE_AdvancedMode_Doton_TimeStill") ||
        _getConfigValue("NIN_ST_AdvancedMode_SuitonSetup");

    #endregion

    #region Window Centering

    private static int _centeredWindow;

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool GetWindowRect(HandleRef hWnd, out Rect lpRect);

    [StructLayout(LayoutKind.Sequential)]
    private struct Rect
    {
        public int Left; // x position of upper-left corner
        public int Top; // y position of upper-left corner
        public int Right; // x position of lower-right corner
        public int Bottom; // y position of lower-right corner
        public Vector2 Position => new Vector2(Left, Top);
        public Vector2 Size => new Vector2(Right - Left, Bottom - Top);
    }

    /// <summary>
    ///     Centers the GUI window to the game window.
    /// </summary>
    private void CenterWindow()
    {
        // Get the pointer to the window handle.
        var hWnd = IntPtr.Zero;
        foreach (var pList in Process.GetProcesses())
            if (pList.ProcessName is "ffxiv_dx11" or "ffxiv")
                hWnd = pList.MainWindowHandle;

        // If failing to get the handle then abort.
        if (hWnd == IntPtr.Zero)
            return;

        // Get the game window rectangle
        GetWindowRect(new HandleRef(null, hWnd), out var rGameWindow);

        // Get the size of the current window.
        var vThisSize = ImGui.GetWindowSize();

        // Set the position.
        var centeredPosition = rGameWindow.Position + new Vector2(
            rGameWindow.Size.X / 2 - vThisSize.X / 2,
            rGameWindow.Size.Y / 2 - vThisSize.Y / 2);
        ImGui.SetWindowPos(centeredPosition);
        Position = centeredPosition;
        PositionCondition = ImGuiCond.Once;

        _centeredWindow++;
    }

    #endregion
}
