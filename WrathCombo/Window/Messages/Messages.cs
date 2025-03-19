using Dalamud.Interface.Colors;
using ImGuiNET;
using WrathCombo.CustomComboNS.Functions;

namespace WrathCombo.Window.MessagesNS
{
    internal static class Messages
    {
        internal static bool PrintBLUMessage(string jobName)
        {
            if (jobName == CustomComboFunctions.JobIDs.JobIDToName(36)) //Blue Mage ID
            {
                ImGui.TextColored(ImGuiColors.ParsedPink, $"请注意，即使您没有激活所有必需的法术，您仍然可以使用这些功能。\n任何未激活的法术将会被跳过，因此如果某个功能没有按预期工作，\n请尝试激活更多必需的法术。");
            }

            return true;
        }
    }
}
