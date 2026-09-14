using Dalamud.Interface.Colors;
using ECommons.ExcelServices;
using WrathCombo.Resources.Localization.UI.Misc;
namespace WrathCombo.Window.MessagesNS;

internal static class Messages
{
    internal static bool PrintBLUMessage(Job job)
    {
        if (job is Job.BLU) //Blue Mage ID
        {
            ImGui.TextColored(ImGuiColors.ParsedPink, MiscUI.BLUNote);
        }

        return true;
    }
}