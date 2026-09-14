#region

using Dalamud.Interface.Colors;
using Dalamud.Interface.Utility.Raii;
using ECommons.ImGuiMethods;
using System.Linq;
using System.Numerics;
using WrathCombo.CustomComboNS.Functions;
using WrathCombo.Data;
using WrathCombo.Extensions;
using WrathCombo.Resources.Localization.JobConfigs;
using WrathCombo.Services;
using WrathCombo.Window.Functions;
using static WrathCombo.Window.Functions.UserConfig;
using static WrathCombo.Window.Text;

// ReSharper disable SwitchStatementMissingSomeEnumCasesNoDefault
// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
// ReSharper disable ClassNeverInstantiated.Global

#endregion

namespace WrathCombo.Combos.PvE;

internal partial class DNC
{
    internal static class Config
    {
        /// <summary>
        ///     Draw the Anti-Drift options for the Single-Target Standard Step
        ///     option.
        /// </summary>
        private static void DrawAntiDriftOptions()
        {
            ImGuiEx.Spacing(new Vector2(40, 12));
            ImGui.Text(DNC_Config.AntiDriftOptions);

            #region Show a colored display of the user's current detected GCD

            var color = GCDValue switch
            {
                GCDRange.Perfect => ImGuiColors.HealerGreen,
                GCDRange.NotGood => ImGuiColors.DalamudYellow,
                _ => ImGuiColors.DalamudRed,
            };
            ImGui.SameLine();
            ImGui.Text(DNC_Config.GCDLabel);
            ImGui.SameLine();
            ImGui.TextColored(color, $"{GCD:0.00}");
            ImGui.NewLine();
            #endregion

            var t = ImGui.GetCursorPos();
            var texTrip = DNC_Config.ForcedTripleWeave;
            DrawRadioButton(
                DNC_ST_ADV_AntiDrift, texTrip,
                DNC_Config.ForcedTripleWeaveDesc,
                outputValue: (int)AntiDrift.TripleWeave, descriptionAsTooltip: true);
            var h = ImGui.GetCursorPos();
            var texHold = DNC_Config.HoldBeforeStandardStep;
            DrawRadioButton(
                DNC_ST_ADV_AntiDrift, texHold,
                DNC_Config.HoldBeforeStandardStepDesc,
                outputValue: (int)AntiDrift.Hold, descriptionAsTooltip: true);
            DrawRadioButton(
                DNC_ST_ADV_AntiDrift, DNC_Config.Both,
                DNC_Config.BothDesc,
                outputValue: (int)AntiDrift.Both, descriptionAsTooltip: true);
            DrawRadioButton(
                DNC_ST_ADV_AntiDrift, DNC_Config.None,
                DNC_Config.NoneDesc,
                outputValue: (int)AntiDrift.None, descriptionAsTooltip: true);

            #region Show recommended setting, based on GCD

            // Save the current cursor position
            var pos = ImGui.GetCursorPos();

            // Determine which recommendation text to show
            var rec = DNC_Config.Recommended;
            var recTriple = GCDValue is GCDRange.Perfect ? rec : "";
            var recHold = GCDValue is not GCDRange.Perfect ? rec : "";

            // Set the position of (any) Triple-Weave recommendation text
            var texSize = ImGui.CalcTextSize(texHold);
            ImGui.SetCursorPos(
                t with { X = t.X + texSize.X + 110f.Scale(), Y = t.Y - texSize.Y - 2f.Scale() });
            ImGui.TextColored(ImGuiColors.DalamudGrey, recTriple);

            // Set the position of (any) Hold recommendation text
            ImGui.SetCursorPos(
                h with { X = h.X + texSize.X + 110f.Scale(), Y = h.Y - 2f.Scale() });
            ImGui.TextColored(ImGuiColors.DalamudGrey, recHold);

            // Reset to where the cursor was
            ImGui.SetCursorPos(pos);

            #endregion
        }

        private static void DrawPartnerInfo()
        {
            ImGuiEx.TextWrapped(ImGuiColors.DalamudGrey, DNC_Config.PartnerInfo);
        }

        internal static void Draw(Preset preset)
        {
            switch (preset)
            {
                case Preset.DNC_CustomDanceSteps:
                    ImGui.Indent(35f.Scale());

                    ImGui.PushStyleColor(ImGuiCol.Text, ImGuiColors.DalamudYellow);
                    ImGui.TextWrapped(DNC_Config.NoSupport);
                    ImGui.PopStyleColor();

                    ImGui.PushStyleColor(ImGuiCol.Text, ImGuiColors.DalamudGrey);
                    ImGui.TextWrapped("\n" + DNC_Config.CustomDanceHelp);
                    ImGui.PopStyleColor();

                    int[] actions = Service.Configuration.DancerDanceCompatActionIDs
                        .Select(x => (int)x).ToArray();

                    bool inputChanged = false;
                    ImGuiEx.SetNextItemWidthScaled(50);
                    inputChanged |= ImGui.InputInt(
                        DNC_Config.EmboiteReplacement,
                        ref actions[0], 0);
                    ImGuiEx.SetNextItemWidthScaled(50);
                    inputChanged |= ImGui.InputInt(
                        DNC_Config.EntrechatReplacement,
                        ref actions[1], 0);
                    ImGuiEx.SetNextItemWidthScaled(50);
                    inputChanged |= ImGui.InputInt(
                        DNC_Config.JeteReplacement,
                        ref actions[2], 0);
                    ImGuiEx.SetNextItemWidthScaled(50);
                    inputChanged |= ImGui.InputInt(
                        DNC_Config.PirouetteReplacement,
                        ref actions[3], 0);

                    ImGuiEx.Spacing(new Vector2(0, 12));

                    ImGui.PushStyleColor(ImGuiCol.Text, ImGuiColors.DalamudYellow);
                    ImGui.TextWrapped(DNC_Config.WillLetConflict);
                    ImGui.PopStyleColor();
                    ImGui.PushStyleColor(ImGuiCol.Text, ImGuiColors.DalamudGrey);
                    ImGui.TextWrapped(DNC_Config.DoubleCheckConflicts);
                    ImGui.PopStyleColor();

                    if (inputChanged)
                    {
                        Service.Configuration.DancerDanceCompatActionIDs = actions
                            .Select(x => (uint)x).ToArray();
                        Service.Configuration.Save();
                    }

                    ImGui.Unindent(35f.Scale());
                    ImGui.Spacing();

                    break;

                #region Advanced Single Target UI

                case Preset.DNC_ST_BalanceOpener:
                    DrawBossOnlyChoice(DNC_ST_OpenerDifficulty, DNC_Config.SelectOpenerContent);
                    DrawOpenerPotionChoice(DNC_Opener_Potion);

                    ImGuiEx.TextUnderlined(Generics.SelectOpener);
                    ImGui.Spacing();
                    DrawRadioButton(DNC_ST_OpenerSelection,
                        DNC_Config.Standard15s,
                        DNC_Config.Standard15sDesc,
                        (int)Openers.FifteenSecond, descriptionAsTooltip: true);
                    DrawRadioButton(DNC_ST_OpenerSelection,
                        DNC_Config.Standard7s,
                        DNC_Config.Standard7sDesc,
                        (int)Openers.SevenSecond, descriptionAsTooltip: true);
                    DrawRadioButton(DNC_ST_OpenerSelection,
                        DNC_Config.Technical30s,
                        DNC_Config.Technical30sDesc,
                        (int)Openers.ThirtySecondTech, descriptionAsTooltip: true);
                    DrawRadioButton(DNC_ST_OpenerSelection,
                        DNC_Config.Technical7s,
                        DNC_Config.Technical7sDesc,
                        (int)Openers.SevenPlusSecondTech, descriptionAsTooltip: true);
                    DrawRadioButton(DNC_ST_OpenerSelection,
                        DNC_Config.Technical7sAlt,
                        DNC_Config.Technical7sDesc,
                        (int)Openers.SevenSecondTech, descriptionAsTooltip: true);

                    DrawAdditionalBoolChoice(DNC_ST_OpenerOption_Peloton,
                        FormatAndCache(Generics.Include0, Peloton.ActionName()), "");

                    DrawOpenerPrepullBlockChoice(DNC_Opener_PrepullBlock);

                    break;

                case Preset.DNC_ST_Adv_PartnerAuto:
                    DrawAdditionalBoolChoice(DNC_Partner_FocusOverride,
                        $"{DNC_Config.PrioritizeFocusTarget}##DPFocusOver0",
                        DNC_Config.PrioritizeFocusTargetDescShort,
                        indentDescription: true);

                    break;

                case Preset.DNC_ST_Adv_AutoPartner:
                    ImGui.Indent(29f.Scale());
                    DrawPartnerInfo();
                    ImGui.Unindent(29f.Scale());

                    DrawAdditionalBoolChoice(DNC_Partner_FocusOverride,
                        $"{DNC_Config.PrioritizeFocusTarget}##DPFocusOver1",
                        DNC_Config.PrioritizeFocusTargetDescFull,
                        indentDescription: true);

                    break;

                case Preset.DNC_ST_EspritOvercap:
                    DrawSliderInt(50, 100, DNCEspritThreshold_ST,
                        DNC_Config.Esprit,
                        itemWidth: 150f, sliderIncrement: SliderIncrements.Fives);

                    break;

                case Preset.DNC_ST_Adv_SS:
                    DrawSliderInt(0, 15, DNC_ST_Adv_SSBurstPercent,
                        DNC_Config.TargetHPStopStandardStep,
                        itemWidth: 75f, sliderIncrement: SliderIncrements.Fives);

                    ImGuiEx.Spacing(new Vector2(30, 0));
                    DrawHorizontalRadioButton(
                        DNC_ST_ADV_SS_IncludeSS,
                        DNC_Config.IncludeStandardStep,
                        DNC_Config.IncludeStandardStepDesc,
                        outputValue: (int)IncludeStep.Yes,
                        itemWidth: 125f);
                    DrawHorizontalRadioButton(
                        DNC_ST_ADV_SS_IncludeSS,
                        DNC_Config.ExcludeStandardStep,
                        DNC_Config.ExcludeStandardStepDesc,
                        outputValue: (int)IncludeStep.No,
                        itemWidth: 125f);

                    DrawAntiDriftOptions();

                    break;

                case Preset.DNC_ST_Adv_TS:
                    DrawSliderInt(0, 15, DNC_ST_Adv_TSBurstPercent,
                        DNC_Config.TargetHPStopTechnicalStep,
                        itemWidth: 75f, sliderIncrement: SliderIncrements.Fives);

                    ImGuiEx.Spacing(new Vector2(30, 0));
                    DrawHorizontalRadioButton(
                        DNC_ST_ADV_TS_IncludeTS,
                        DNC_Config.IncludeTechnicalStep,
                        DNC_Config.IncludeTechnicalStepDesc,
                        outputValue: (int)IncludeStep.Yes,
                        itemWidth: 125f);
                    DrawHorizontalRadioButton(
                        DNC_ST_ADV_TS_IncludeTS,
                        DNC_Config.ExcludeTechnicalStep,
                        DNC_Config.ExcludeTechnicalStepDesc,
                        outputValue: (int)IncludeStep.No,
                        itemWidth: 125f);

                    DrawAntiDriftOptions();

                    break;

                case Preset.DNC_ST_Adv_Feathers:
                    DrawSliderInt(0, 5, DNC_ST_Adv_FeatherBurstPercent,
                        DNC_Config.DumpFeathersHP,
                        itemWidth: 75f);

                    break;

                case Preset.DNC_ST_Adv_Tillana:
                    ImGui.Indent();
                    DrawHorizontalRadioButton(
                        DNC_ST_ADV_TillanaUse,
                        DNC_Config.UseTillanaNormally,
                        DNC_Config.UseTillanaNormallyDesc,
                        outputValue: (int)TillanaUsageManner.Normally,
                        itemWidth: 125f);
                    DrawHorizontalRadioButton(
                        DNC_ST_ADV_TillanaUse,
                        DNC_Config.UseNormallyPreventDrops,
                        DNC_Config.UseNormallyPreventDropsDesc,
                        outputValue: (int)TillanaUsageManner.NormallyPreventDrops,
                        itemWidth: 125f);
                    DrawHorizontalRadioButton(
                        DNC_ST_ADV_TillanaUse,
                        DNC_Config.FavorTillanaOverEsprit,
                        DNC_Config.FavorTillanaOverEspritDesc,
                        outputValue: (int)TillanaUsageManner.FavorOverEsprit,
                        itemWidth: 125f);
                    ImGui.Unindent();

                    break;

                case Preset.DNC_ST_Adv_SaberDance:
                    DrawSliderInt(50, 100,
                        DNC_ST_Adv_SaberThreshold,
                        DNC_Config.Esprit,
                        itemWidth: 150f, sliderIncrement: SliderIncrements.Fives);

                    break;

                case Preset.DNC_ST_Adv_PanicHeals:
                    DrawSliderInt(0, 80,
                        DNC_ST_Adv_PanicHealWaltzPercent,
                        DNC_Config.CuringWaltzHP,
                        itemWidth: 200f, sliderIncrement: SliderIncrements.Fives);

                    DrawSliderInt(0, 80, DNC_ST_Adv_PanicHealWindPercent,
                        DNC_Config.SecondWindHP,
                        itemWidth: 200f, sliderIncrement: SliderIncrements.Fives);

                    break;

                #endregion

                #region Advanced AoE UI

                case Preset.DNC_AoE_EspritOvercap:
                    DrawSliderInt(50, 100, DNCEspritThreshold_AoE,
                        DNC_Config.Esprit,
                        itemWidth: 150f, sliderIncrement: SliderIncrements.Fives);

                    break;

                case Preset.DNC_AoE_Adv_SS:
                    DrawSliderInt(0, 60, DNC_AoE_Adv_SSBurstPercent,
                        DNC_Config.TargetHPStopStandardStep,
                        itemWidth: 75f, sliderIncrement: SliderIncrements.Fives);

                    ImGuiEx.Spacing(new Vector2(30, 0));
                    DrawHorizontalRadioButton(
                        DNC_AoE_Adv_SS_IncludeSS,
                        DNC_Config.IncludeStandardStep,
                        DNC_Config.IncludeStandardStepDesc,
                        outputValue: (int)IncludeStep.Yes,
                        itemWidth: 125f);
                    DrawHorizontalRadioButton(
                        DNC_AoE_Adv_SS_IncludeSS,
                        DNC_Config.ExcludeStandardStep,
                        DNC_Config.ExcludeStandardStepDesc,
                        outputValue: (int)IncludeStep.No,
                        itemWidth: 125f);

                    break;

                case Preset.DNC_AoE_Adv_TS:
                    DrawSliderInt(0, 60, DNC_AoE_Adv_TSBurstPercent,
                        DNC_Config.TargetHPStopTechnicalStep,
                        itemWidth: 75f, sliderIncrement: SliderIncrements.Fives);

                    ImGuiEx.Spacing(new Vector2(30, 0));
                    DrawHorizontalRadioButton(
                        DNC_AoE_Adv_TS_IncludeTS,
                        DNC_Config.IncludeTechnicalStep,
                        DNC_Config.IncludeTechnicalStepDesc,
                        outputValue: (int)IncludeStep.Yes,
                        itemWidth: 125f);
                    DrawHorizontalRadioButton(
                        DNC_AoE_Adv_TS_IncludeTS,
                        DNC_Config.ExcludeTechnicalStep,
                        DNC_Config.ExcludeTechnicalStepDesc,
                        outputValue: (int)IncludeStep.No,
                        itemWidth: 125f);

                    break;

                case Preset.DNC_AoE_Adv_SaberDance:
                    DrawSliderInt(50, 100, DNC_AoE_Adv_SaberThreshold,
                        DNC_Config.Esprit,
                        itemWidth: 150f, sliderIncrement: SliderIncrements.Fives);

                    break;

                case Preset.DNC_AoE_Adv_PanicHeals:
                    DrawSliderInt(0, 80,
                        DNC_AoE_Adv_PanicHealWaltzPercent,
                        DNC_Config.CuringWaltzHP,
                        itemWidth: 200f, sliderIncrement: SliderIncrements.Fives);

                    DrawSliderInt(0, 80,
                        DNC_AoE_Adv_PanicHealWindPercent,
                        DNC_Config.SecondWindHP,
                        itemWidth: 200f, sliderIncrement: SliderIncrements.Fives);

                    break;

                #endregion

                case Preset.DNC_DesirablePartner:
                    ImGui.Indent(35f.Scale());
                    DrawPartnerInfo();
                    ImGui.Unindent(35f.Scale());
                    ImGuiEx.Spacing(new Vector2(0, 12));

                    DrawAdditionalBoolChoice(DNC_Partner_FocusOverride,
                        $"{DNC_Config.PrioritizeFocusTarget}##DPFocusOver2",
                        DNC_Config.PrioritizeFocusTargetDescFull,
                        indentDescription: true);

                    ImGuiEx.Spacing(new Vector2(29, 12));
                    ImGui.Text(DNC_Config.PartnerOptimalOptions);
                    ImGui.NewLine();
                    DrawRadioButton(
                        DNC_Partner_ActionToShow, DNC_Config.LetGameDecide,
                        DNC_Config.LetGameDecideDesc,
                        outputValue: (int)PartnerShowAction.Default,
                        descriptionAsTooltip: true);
                    DrawRadioButton(
                        DNC_Partner_ActionToShow, DNC_Config.ClosedPosition,
                        DNC_Config.ClosedPositionDesc,
                        outputValue: (int)PartnerShowAction.ClosedPosition,
                        descriptionAsTooltip: true);
                    DrawRadioButton(
                        DNC_Partner_ActionToShow, DNC_Config.BlockInput,
                        DNC_Config.BlockInputDesc,
                        outputValue: (int)PartnerShowAction.SavageBlade,
                        descriptionAsTooltip: true);

                    break;

            }
        }

        #region Constants

        public enum Openers
        {
            FifteenSecond,
            SevenSecond,
            ThirtySecondTech,
            SevenPlusSecondTech,
            SevenSecondTech,
        }

        public enum IncludeStep
        {
            No,
            Yes,
        }

        public enum TillanaUsageManner
        {
            Normally = 0,
            NormallyPreventDrops = 2,
            FavorOverEsprit = 1,
        }

        public enum AntiDrift
        {
            None,
            TripleWeave,
            Hold,
            Both,
        }

        #endregion

        #region Options

        #region Advanced Single Target

        /// <summary>
        ///     Difficulty of Opener for Single Target.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: <see cref="ContentCheck.IsInBossOnlyContent" /> <br />
        ///     <b>Options</b>: All Content or
        ///     <see cref="ContentCheck.IsInBossOnlyContent" />
        /// </value>
        /// <seealso cref="Preset.DNC_ST_BalanceOpener" />
        public static readonly UserBoolArray DNC_ST_OpenerDifficulty =
            new("DNC_ST_OpenerDifficulty", [false, true]);

        /// <summary>
        ///     Opener selection for Single Target.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: <see cref="Openers.FifteenSecond" /> <br />
        ///     <b>Options</b>: <see cref="Openers">Openers Enum</see>
        /// </value>
        /// <seealso cref="Preset.DNC_ST_BalanceOpener" />
        public static readonly UserInt DNC_ST_OpenerSelection =
            new("DNC_ST_OpenerSelection", (int)Openers.FifteenSecond);

        /// <summary>
        ///     Whether to include Peloton in the opener.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: <see langword="true"/><br />
        ///     <b>Options</b>: <see langword="true"/> or <see langword="false"/>
        /// </value>
        /// <seealso cref="Preset.DNC_ST_BalanceOpener" />
        public static readonly UserBool DNC_Opener_Potion =
            new("DNC_Opener_Potion");

        public static readonly UserBool DNC_Opener_PrepullBlock = 
            new("DNC_Opener_PrepullBlock", true);
        public static readonly UserBool DNC_ST_OpenerOption_Peloton =
            new("DNC_ST_OpenerOption_Peloton", true);

        /// <summary>
        ///     Esprit threshold for Single Target.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 50 <br />
        ///     <b>Range</b>: 50 - 100 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Fives" />
        /// </value>
        /// <seealso cref="Preset.DNC_ST_EspritOvercap" />
        public static readonly UserInt DNCEspritThreshold_ST =
            new("DNCEspritThreshold_ST", 50);

        /// <summary>
        ///     Target HP% to use Standard Step above for Single Target.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 0 <br />
        ///     <b>Range</b>: 0 - 15 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Fives" />
        /// </value>
        /// <seealso cref="Preset.DNC_ST_Adv_SS" />
        public static readonly UserInt DNC_ST_Adv_SSBurstPercent =
            new("DNC_ST_Adv_SSBurstPercent", 0);

        /// <summary>
        ///     Include Standard Step in rotation for Single Target.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: <see cref="IncludeStep.Yes" /> <br />
        ///     <b>Options</b>: <see cref="IncludeStep">IncludeStep Enum</see>
        /// </value>
        /// <seealso cref="Preset.DNC_ST_Adv_SS" />
        public static readonly UserInt DNC_ST_ADV_SS_IncludeSS =
            new("DNC_ST_ADV_SS_IncludeSS", (int)IncludeStep.Yes);

        /// <summary>
        ///     Anti-Drift choice for Single Target.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: <see cref="AntiDrift.TripleWeave" /> <br />
        ///     <b>Options</b>: <see cref="AntiDrift">AntiDrift Enum</see>
        /// </value>
        /// <seealso cref="Preset.DNC_ST_Adv_SS" />
        public static readonly UserInt DNC_ST_ADV_AntiDrift =
            new("DNC_ST_ADV_AntiDrift", (int)AntiDrift.TripleWeave);

        /// <summary>
        ///     Include Technical Step in rotation for Single Target.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: <see cref="IncludeStep.Yes" /> <br />
        ///     <b>Options</b>: <see cref="IncludeStep">IncludeStep Enum</see>
        /// </value>
        /// <seealso cref="Preset.DNC_ST_Adv_TS" />
        public static readonly UserInt DNC_ST_ADV_TS_IncludeTS =
            new("DNC_ST_ADV_TS_IncludeTS", (int)IncludeStep.Yes);

        /// <summary>
        ///     Target HP% to use Technical Step above for Single Target.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 0 <br />
        ///     <b>Range</b>: 0 - 15 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Fives" />
        /// </value>
        /// <seealso cref="Preset.DNC_ST_Adv_TS" />
        public static readonly UserInt DNC_ST_Adv_TSBurstPercent =
            new("DNC_ST_Adv_TSBurstPercent", 0);

        /// <summary>
        ///     Target HP% to dump all pooled feathers below for Single Target.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 0 <br />
        ///     <b>Range</b>: 0 - 5 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Ones" />
        /// </value>
        /// <seealso cref="Preset.DNC_ST_Adv_Feathers" />
        public static readonly UserInt DNC_ST_Adv_FeatherBurstPercent =
            new("DNC_ST_Adv_FeatherBurstPercent", 0);

        /// <summary>
        ///     Tillana drift protection for Single Target.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: <see cref="TillanaUsageManner.Normally" /> <br />
        ///     <b>Options</b>: <see cref="TillanaUsageManner" /> Enum.
        /// </value>
        /// <seealso cref="Preset.DNC_ST_Adv_Tillana" />
        public static readonly UserInt DNC_ST_ADV_TillanaUse =
            new("DNC_ST_ADV_TillanaUse", (int)TillanaUsageManner.Normally);

        /// <summary>
        ///     Esprit threshold for Saber Dance in Single Target.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 50 <br />
        ///     <b>Range</b>: 50 - 100 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Fives" />
        /// </value>
        /// <seealso cref="Preset.DNC_ST_Adv_SaberDance" />
        public static readonly UserInt DNC_ST_Adv_SaberThreshold =
            new("DNC_ST_Adv_SaberThreshold", 50);

        /// <summary>
        ///     Player HP% threshold for Curing Waltz in Single Target.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 30 <br />
        ///     <b>Range</b>: 0 - 80 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Fives" />
        /// </value>
        /// <seealso cref="Preset.DNC_ST_Adv_PanicHeals" />
        public static readonly UserInt DNC_ST_Adv_PanicHealWaltzPercent =
            new("DNC_ST_Adv_PanicHealWaltzPercent", 30);

        /// <summary>
        ///     Player HP% threshold for Second Wind in Single Target.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 20 <br />
        ///     <b>Range</b>: 0 - 80 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Fives" />
        /// </value>
        /// <seealso cref="Preset.DNC_ST_Adv_PanicHeals" />
        public static readonly UserInt DNC_ST_Adv_PanicHealWindPercent =
            new("DNC_ST_Adv_PanicHealWindPercent", 20);

        #endregion

        #region Advanced AoE

        /// <summary>
        ///     Esprit threshold for AoE.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 50 <br />
        ///     <b>Range</b>: 50 - 100 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Fives" />
        /// </value>
        /// <seealso cref="Preset.DNC_AoE_EspritOvercap" />
        public static readonly UserInt DNCEspritThreshold_AoE =
            new("DNCEspritThreshold_AoE", 50);

        /// <summary>
        ///     Target HP% to use Standard Step above for AoE.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 40 <br />
        ///     <b>Range</b>: 0 - 60 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Fives" />
        /// </value>
        /// <seealso cref="Preset.DNC_AoE_Adv_SS" />
        public static readonly UserInt DNC_AoE_Adv_SSBurstPercent =
            new("DNC_AoE_Adv_SSBurstPercent", 40);

        /// <summary>
        ///     Include Standard Step in rotation for AoE.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: <see cref="IncludeStep.Yes" /> <br />
        ///     <b>Options</b>: <see cref="IncludeStep">IncludeStep Enum</see>
        /// </value>
        /// <seealso cref="Preset.DNC_AoE_Adv_SS" />
        public static readonly UserInt DNC_AoE_Adv_SS_IncludeSS =
            new("DNC_AoE_Adv_SS_IncludeSS", (int)IncludeStep.Yes);

        /// <summary>
        ///     Target HP% to use Technical Step above for AoE.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 40 <br />
        ///     <b>Range</b>: 0 - 60 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Fives" />
        /// </value>
        /// <seealso cref="Preset.DNC_AoE_Adv_TS" />
        public static readonly UserInt DNC_AoE_Adv_TSBurstPercent =
            new("DNC_AoE_Adv_TSBurstPercent", 40);

        /// <summary>
        ///     Include Technical Step in rotation for AoE.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: <see cref="IncludeStep.Yes" /> <br />
        ///     <b>Options</b>: <see cref="IncludeStep">IncludeStep Enum</see>
        /// </value>
        /// <seealso cref="Preset.DNC_AoE_Adv_TS" />
        public static readonly UserInt DNC_AoE_Adv_TS_IncludeTS =
            new("DNC_AoE_Adv_TS_IncludeTS", (int)IncludeStep.Yes);

        /// <summary>
        ///     Esprit threshold for Saber Dance in AoE.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 50 <br />
        ///     <b>Range</b>: 50 - 100 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Fives" />
        /// </value>
        /// <seealso cref="Preset.DNC_AoE_Adv_SaberDance" />
        public static readonly UserInt DNC_AoE_Adv_SaberThreshold =
            new("DNC_AoE_Adv_SaberThreshold", 50);

        /// <summary>
        ///     Player HP% threshold for Curing Waltz in AoE.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 30 <br />
        ///     <b>Range</b>: 0 - 80 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Fives" />
        /// </value>
        /// <seealso cref="Preset.DNC_AoE_Adv_PanicHeals" />
        public static readonly UserInt DNC_AoE_Adv_PanicHealWaltzPercent =
            new("DNC_AoE_Adv_PanicHealWaltzPercent", 30);

        /// <summary>
        ///     Player HP% threshold for Second Wind in AoE.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: 20 <br />
        ///     <b>Range</b>: 0 - 80 <br />
        ///     <b>Step</b>: <see cref="SliderIncrements.Fives" />
        /// </value>
        /// <seealso cref="Preset.DNC_AoE_Adv_PanicHeals" />
        public static readonly UserInt DNC_AoE_Adv_PanicHealWindPercent =
            new("DNC_AoE_Adv_PanicHealWindPercent", 20);

        #endregion

        #region Smaller Features

        /// <summary>
        ///     Whether the Focus Target should override the desired partner, while
        ///     still valid.
        /// </summary>
        /// <value>
        ///     <b>Default</b>: false
        /// </value>
        /// <seealso cref="Preset.DNC_DesirablePartner" />
        public static readonly UserBool DNC_Partner_FocusOverride =
            new("DNC_Partner_FocusOverride", false);

        public enum PartnerShowAction
        {
            Default,
            ClosedPosition,
            SavageBlade,
        }

        /// <summary>
        ///     What action should be shown on the hotbar when the current dance
        ///     partner is considered optimal.
        /// </summary>
        /// <value>
        ///     Default: 0 <br />
        ///     Options: <see cref="PartnerShowAction" /> Enum
        /// </value>
        public static readonly UserInt DNC_Partner_ActionToShow =
            new("DNC_Partner_ActionToShow", (int)PartnerShowAction.Default);

        #endregion

        #endregion
    }
}
