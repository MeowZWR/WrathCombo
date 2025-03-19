#region

using ECommons.DalamudServices;
using ECommons.ExcelServices;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WrathCombo.Attributes;
using WrathCombo.Combos;
using WrathCombo.Core;
using WrathCombo.CustomComboNS.Functions;
using WrathCombo.Extensions;
using WrathCombo.Window.Tabs;

#endregion

namespace WrathCombo.Services.IPC;

public class Search(Leasing leasing)
{
    public Task? UpdatePresetCount;
    public CancellationTokenSource Cancel = new();

    /// <summary>
    ///     A shortcut for <see cref="StringComparison.CurrentCultureIgnoreCase" />.
    /// </summary>
    private const StringComparison ToLower =
        StringComparison.CurrentCultureIgnoreCase;

    private readonly Leasing _leasing = leasing;

    #region Aggregations of Leasing Configurations

    /// <summary>
    ///     When <see cref="AllAutoRotationConfigsControlled" /> was last cached.
    /// </summary>
    /// <seealso cref="Leasing.AutoRotationConfigsUpdated" />
    internal DateTime? LastCacheUpdateForAutoRotationConfigs;

    /// <summary>
    ///     Lists all auto-rotation configurations controlled under leases.
    /// </summary>
    internal Dictionary<AutoRotationConfigOption, Dictionary<string, int>>? _allAutoRotationConfigsControlled;
    internal Dictionary<AutoRotationConfigOption, Dictionary<string, int>> AllAutoRotationConfigsControlled
    {
        get
        {
            if (_allAutoRotationConfigsControlled is not null &&
                LastCacheUpdateForAutoRotationConfigs is not null &&
                _leasing.AutoRotationConfigsUpdated ==
                LastCacheUpdateForAutoRotationConfigs)
                return _allAutoRotationConfigsControlled;

            _allAutoRotationConfigsControlled = _leasing.Registrations.Values
                .SelectMany(registration => registration
                    .AutoRotationConfigsControlled
                    .Select(pair => new
                    {
                        pair.Key,
                        registration.PluginName,
                        pair.Value,
                        registration.LastUpdated
                    }))
                .GroupBy(x => x.Key)
                .ToDictionary(
                    g => g.Key,
                    g => g.OrderByDescending(x => x.LastUpdated)
                        .ToDictionary(x => x.PluginName, x => x.Value)
                );

            LastCacheUpdateForAutoRotationConfigs =
                _leasing.AutoRotationConfigsUpdated;
            return _allAutoRotationConfigsControlled;
        }
    }

    /// <summary>
    ///     When <see cref="AllJobsControlled" /> was last cached.
    /// </summary>
    /// <seealso cref="Leasing.JobsUpdated" />
    internal DateTime? LastCacheUpdateForAllJobsControlled;

    /// <summary>
    ///     Lists all jobs controlled under leases.
    /// </summary>
    internal Dictionary<Job, Dictionary<string, bool>>? _allJobsControlled;
    internal Dictionary<Job, Dictionary<string, bool>> AllJobsControlled
    {
        get
        {
            if (_allJobsControlled is not null &&
                LastCacheUpdateForAllJobsControlled is not null &&
                _leasing.JobsUpdated == LastCacheUpdateForAllJobsControlled)
                return _allJobsControlled;

            _allJobsControlled = _leasing.Registrations.Values
                .SelectMany(registration => registration.JobsControlled
                    .Select(pair => new
                    {
                        pair.Key,
                        registration.PluginName,
                        pair.Value,
                        registration.LastUpdated
                    }))
                .GroupBy(x => x.Key)
                .ToDictionary(
                    g => g.Key,
                    g => g.OrderByDescending(x => x.LastUpdated)
                        .ToDictionary(x => x.PluginName, x => x.Value)
                );

            LastCacheUpdateForAllJobsControlled = _leasing.JobsUpdated;
            return _allJobsControlled;
        }
    }

    /// <summary>
    ///     When <see cref="AllPresetsControlled" /> was last cached.
    /// </summary>
    /// <seealso cref="Leasing.CombosUpdated" />
    /// <seealso cref="Leasing.OptionsUpdated" />
    internal DateTime? LastCacheUpdateForAllPresetsControlled;

    /// <summary>
    ///     Lists all presets controlled under leases.<br />
    ///     Include both combos and options, but also jobs' options.
    /// </summary>
    internal Dictionary<CustomComboPreset, Dictionary<string, (bool enabled, bool autoMode)>>? _allPresetsControlled;
    internal Dictionary<CustomComboPreset, Dictionary<string, (bool enabled, bool autoMode)>> AllPresetsControlled
    {
        get
        {
            var presetsUpdated = (DateTime)
                (_leasing.CombosUpdated > _leasing
                    .OptionsUpdated
                    ? _leasing.CombosUpdated
                    : _leasing.OptionsUpdated ?? DateTime.MinValue);

            if (_allPresetsControlled is not null &&
                LastCacheUpdateForAllPresetsControlled is not null &&
                presetsUpdated == LastCacheUpdateForAllPresetsControlled)
                return _allPresetsControlled;

            _allPresetsControlled = _leasing.Registrations.Values
                .SelectMany(registration => registration.CombosControlled
                    .Select(pair => new
                    {
                        pair.Key,
                        registration.PluginName,
                        pair.Value.enabled,
                        pair.Value.autoMode,
                        registration.LastUpdated
                    }))
                .GroupBy(x => x.Key)
                .ToDictionary(
                    g => g.Key,
                    g => g.OrderByDescending(x => x.LastUpdated)
                        .ToDictionary(x => x.PluginName,
                            x => (x.enabled, x.autoMode))
                )
                .Concat(
                    _leasing.Registrations.Values
                        .SelectMany(registration => registration.OptionsControlled
                            .Select(pair => new
                            {
                                pair.Key,
                                registration.PluginName,
                                pair.Value,
                                registration.LastUpdated
                            }))
                        .GroupBy(x => x.Key)
                        .ToDictionary(
                            g => g.Key,
                            g => g.OrderByDescending(x => x.LastUpdated)
                                .ToDictionary(x => x.PluginName,
                                    x => (x.Value, false))
                        )
                )
                .DistinctBy(x => x.Key)
                .ToDictionary(pair => pair.Key, pair => pair.Value);

            LastCacheUpdateForAllPresetsControlled = presetsUpdated;
            return _allPresetsControlled;
        }
    }

    #endregion

    #region Presets Information

    #region Cached Preset Info

    /// <summary>
    ///     The path to the configuration file for Wrath Combo.
    /// </summary>
    internal string ConfigFilePath
    {
        get
        {
            var pluginConfig = Svc.PluginInterface.GetPluginConfigDirectory();
            if (Path.EndsInDirectorySeparator(pluginConfig))
                pluginConfig = Path.TrimEndingDirectorySeparator(pluginConfig);
            pluginConfig =
                pluginConfig
                    [..pluginConfig.LastIndexOf(Path.DirectorySeparatorChar)];
            pluginConfig = Path.Combine(pluginConfig, "WrathCombo.json");
            return pluginConfig;
        }
    }

    /// <summary>
    ///     When <see cref="PresetStates" /> was last built.
    /// </summary>
    private DateTime _lastCacheUpdateForPresetStates = DateTime.MinValue;

    /// <summary>
    ///     Recursively finds the root parent of a given CustomComboPreset.
    /// </summary>
    /// <param name="preset">The CustomComboPreset to find the root parent for.</param>
    /// <returns>The root parent CustomComboPreset.</returns>
    public CustomComboPreset GetRootParent(CustomComboPreset preset)
    {
        if (!Attribute.IsDefined(
                typeof(CustomComboPreset).GetField(preset.ToString())!,
                typeof(ParentComboAttribute)))
        {
            return preset;
        }

        var parentAttribute = (ParentComboAttribute)Attribute.GetCustomAttribute(
            typeof(CustomComboPreset).GetField(preset.ToString())!,
            typeof(ParentComboAttribute)
        )!;

        return GetRootParent(parentAttribute.ParentPreset);
    }

    /// <summary>
    ///     Cached list of <see cref="CustomComboPreset">Presets</see>, and most of
    ///     their attribute-based information.
    /// </summary>
    internal Dictionary<string, (Job Job, CustomComboPreset ID, CustomComboInfoAttribute Info, bool HasParentCombo, bool IsVariant, string ParentComboName)>? _presets;
    internal Dictionary<string, (Job Job, CustomComboPreset ID, CustomComboInfoAttribute Info, bool HasParentCombo, bool IsVariant, string ParentComboName)> Presets
    {
        get
        {
            return _presets ??= PresetStorage.AllPresets!
                .Cast<CustomComboPreset>()
                .Select(preset => new
                {
                    ID = preset,
                    JobId = (Job)preset.Attributes().CustomComboInfo.JobID,
                    InternalName = preset.ToString(),
                    Info = preset.Attributes().CustomComboInfo!,
                    HasParentCombo = preset.Attributes().Parent != null,
                    IsVariant = preset.Attributes().Variant != null,
                    ParentComboName = preset.Attributes().Parent != null
                        ? GetRootParent(preset).ToString()
                        : string.Empty
                })
                .Where(combo =>
                    !combo.InternalName.EndsWith("any", ToLower))
                .ToDictionary(
                    combo => combo.InternalName,
                    combo => (combo.JobId, combo.ID, combo.Info, combo.HasParentCombo,
                        combo.IsVariant, combo.ParentComboName)
                );
        }
    }

    /// <summary>
    ///     Cached list of <see cref="CustomComboPreset">Presets</see>, and the
    ///     state and Auto-Mode state of each.
    /// </summary>
    /// <remarks>
    ///     Rebuilt if the <see cref="ConfigFilePath">Config File</see> has been
    ///     updated since
    ///     <see cref="_lastCacheUpdateForPresetStates">last cached</see>.
    /// </remarks>
    internal Dictionary<string, Dictionary<ComboStateKeys, bool>>? _presetStates;
    internal Dictionary<string, Dictionary<ComboStateKeys, bool>> PresetStates
    {
        get
        {
            var presetsUpdated = (DateTime)
                (_leasing.CombosUpdated > _leasing
                    .OptionsUpdated
                    ? _leasing.CombosUpdated
                    : _leasing.OptionsUpdated ?? DateTime.MinValue);

            if (!Debug.DebugConfig)
            {
                if (_presetStates != null &&
                    File.GetLastWriteTime(ConfigFilePath) <=
                    _lastCacheUpdateForPresetStates &&
                    presetsUpdated <= _lastCacheUpdateForPresetStates)
                    return _presetStates;
            }
            else
            {
                if (_presetStates != null &&
                    DateTime.Now.AddSeconds(-1) <=
                    _lastCacheUpdateForPresetStates &&
                    presetsUpdated <= _lastCacheUpdateForPresetStates)
                    return _presetStates;
            }

            _presetStates = Presets
                .ToDictionary(
                    preset => preset.Key,
                    preset =>
                    {
                        var isEnabled =
                            CustomComboFunctions.IsEnabled(preset.Value.ID);
                        var ipcAutoMode = _leasing.CheckComboControlled(
                            preset.Value.ID.ToString())?.autoMode ?? false;
                        var isAutoMode =
                            Service.Configuration.AutoActions.TryGetValue(
                                preset.Value.ID, out bool autoMode) &&
                            autoMode && preset.Value.ID.Attributes().AutoAction != null;
                        return new Dictionary<ComboStateKeys, bool>
                        {
                            { ComboStateKeys.Enabled, isEnabled },
                            { ComboStateKeys.AutoMode, isAutoMode || ipcAutoMode }
                        };
                    }
                );
            _lastCacheUpdateForPresetStates = DateTime.Now;
            UpdatePresetCount = Svc.Framework.RunOnTick(() => UpdateActiveJobPresets(), TimeSpan.FromSeconds(1), 0, Cancel.Token);
            return _presetStates;
        }
    }

    internal void UpdateActiveJobPresets()
    {
        ActiveJobPresets = Window.Functions.Presets.GetJobAutorots.Count;
    }

    internal int ActiveJobPresets = 0;

    #endregion

    #region Combo Information

    /// <summary>
    ///     The names of each combo.
    /// </summary>
    /// <value>
    ///     Job -> <c>list</c> of combo internal names.
    /// </value>
    internal Dictionary<Job, List<string>> ComboNamesByJob =>
        Presets
            .Where(preset =>
                preset.Value is { IsVariant: false, HasParentCombo: false } &&
                !preset.Key.Contains("pvp", ToLower))
            .GroupBy(preset => preset.Value.Job)
            .ToDictionary(
                g => g.Key,
                g => g.Select(preset => preset.Key).ToList()
            );

    /// <summary>
    ///     The states of each combo.
    /// </summary>
    /// <value>
    ///     Job -> Internal Name ->
    ///     <see cref="ComboStateKeys">State Key</see> -><br />
    ///     <c>bool</c> - Whether the state is enabled or not.
    /// </value>
    internal Dictionary<Job, Dictionary<string, Dictionary<ComboStateKeys, bool>>> ComboStatesByJob =>
        ComboNamesByJob
            .ToDictionary(
                job => job.Key,
                job => job.Value
                    .ToDictionary(
                        combo => combo,
                        combo => PresetStates[combo]
                    )
            );

    /// <summary>
    ///     When <see cref="ComboStatesByJobCategorized" /> was last built.
    /// </summary>
    private DateTime _lastCacheUpdateForComboStatesByJobCategorized =
        DateTime.MinValue;

    /// <summary>
    ///     The states of each combo, but heavily categorized.
    /// </summary>
    /// <value>
    ///     Job -> <see cref="ComboTargetTypeKeys">Target Key</see> ->
    ///     <see cref="ComboSimplicityLevelKeys">Simplicity Key</see> ->
    ///     Internal Name ->
    ///     <see cref="ComboStateKeys">State Key</see> -><br />
    ///     <c>bool</c> - Whether the state is enabled or not.
    /// </value>
    internal Dictionary<Job, Dictionary<ComboTargetTypeKeys, Dictionary<ComboSimplicityLevelKeys, Dictionary<string, Dictionary<ComboStateKeys, bool>>>>>? _comboStatesByJobCategorized;
    internal Dictionary<Job, Dictionary<ComboTargetTypeKeys, Dictionary<ComboSimplicityLevelKeys, Dictionary<string, Dictionary<ComboStateKeys, bool>>>>> ComboStatesByJobCategorized
    {
        get
        {
            if (File.GetLastWriteTime(ConfigFilePath) <=
                _lastCacheUpdateForComboStatesByJobCategorized)
                return _comboStatesByJobCategorized ?? [];

            Task.Run(() =>
            {
                _comboStatesByJobCategorized = Presets
                    .Where(preset =>
                        preset.Value is
                        { IsVariant: false, HasParentCombo: false } &&
                        !preset.Key.Contains("pvp", ToLower))
                    .SelectMany(preset => new[]
                    {
                        new
                        {
                            Job = (Job)preset.Value.Info.JobID,
                            Combo = preset.Key,
                            preset.Value.Info
                        }
                    })
                    .GroupBy(x => x.Job)
                    .ToDictionary(
                        g => g.Key,
                        g => g.GroupBy(x =>
                                x.Info.Name.Contains("heals - single", ToLower) ?
                                    ComboTargetTypeKeys.HealST :
                                    x.Info.Name.Contains("heals - aoe", ToLower) ?
                                        ComboTargetTypeKeys.HealMT :
                                        x.Info.Name.Contains("- aoe", ToLower) ||
                                        x.Info.Name.Contains("aoe dps feature",
                                            ToLower) ?
                                            ComboTargetTypeKeys.MultiTarget :
                                            x.Info.Name.Contains("- single target",
                                                ToLower) ||
                                            x.Info.Name.Contains(
                                                "single target dps feature",
                                                ToLower) ?
                                                ComboTargetTypeKeys.SingleTarget :
                                                ComboTargetTypeKeys.Other
                            )
                            .ToDictionary(
                                g2 => g2.Key,
                                g2 => g2.GroupBy(x =>
                                        x.Info.Name.Contains("advanced mode -",
                                            ToLower) ||
                                        x.Info.Name.Contains("dps feature",
                                            ToLower) ?
                                            ComboSimplicityLevelKeys.Advanced :
                                            x.Info.Name.Contains("simple mode -",
                                                ToLower) ?
                                                ComboSimplicityLevelKeys.Simple :
                                                ComboSimplicityLevelKeys.Other
                                    )
                                    .ToDictionary(
                                        g3 => g3.Key,
                                        g3 => g3.ToDictionary(
                                            x => x.Combo,
                                            x => ComboStatesByJob[x.Job][x.Combo]
                                        )
                                    )
                            )
                    );
                _lastCacheUpdateForComboStatesByJobCategorized = DateTime.Now;
            });

            return _comboStatesByJobCategorized ?? [];
        }
    }

    #endregion

    #region Options Information

    /// <summary>
    ///     The names of each option.
    /// </summary>
    /// <value>
    ///     Job -> Parent Combo Internal Name ->
    ///     <c>list</c> of option internal names.
    /// </value>
    internal Dictionary<Job, Dictionary<string, List<string>>> OptionNamesByJob =>
        Presets
            .Where(preset =>
                preset.Value is { IsVariant: false, HasParentCombo: true } &&
                !preset.Key.Contains("pvp", ToLower))
            .GroupBy(preset => preset.Value.Job)
            .ToDictionary(
                g => g.Key,
                g => g.GroupBy(preset => preset.Value.ParentComboName)
                    .ToDictionary(
                        g2 => g2.Key,
                        g2 => g2.Select(preset => preset.Key).ToList()
                    )
            );

    /// <summary>
    ///     The states of each option.
    /// </summary>
    /// <value>
    ///     Job -> Parent Combo Internal Name -> Option Internal Name ->
    ///     State Key (really just <see cref="ComboStateKeys.Enabled" />) ->
    ///     <c>bool</c> - Whether the option is enabled or not.
    /// </value>
    internal Dictionary<Job, Dictionary<string, Dictionary<string, Dictionary<ComboStateKeys, bool>>>> OptionStatesByJob =>
        OptionNamesByJob
            .ToDictionary(
                job => job.Key,
                job => job.Value
                    .ToDictionary(
                        parentCombo => parentCombo.Key,
                        parentCombo => parentCombo.Value
                            .ToDictionary(
                                option => option,
                                option => new Dictionary<ComboStateKeys, bool>
                                {
                                    {
                                        ComboStateKeys.Enabled,
                                        PresetStates[option][ComboStateKeys.Enabled]
                                    }
                                }
                            )
                    )
            );

    #endregion

    /// <summary>
    ///     A wrapper for <see cref="Core.PluginConfiguration.AutoActions" /> with
    ///     IPC settings on top.
    /// </summary>
    internal Dictionary<CustomComboPreset, bool> AutoActions =>
        PresetStates
            .ToDictionary(
                preset => Enum.Parse<CustomComboPreset>(preset.Key),
                preset => preset.Value[ComboStateKeys.AutoMode]
            );

    /// <summary>
    ///     A wrapper for <see cref="Core.PluginConfiguration.EnabledActions" /> with
    ///     IPC settings on top.
    /// </summary>
    internal HashSet<CustomComboPreset> EnabledActions =>
        PresetStates
            .Where(preset => preset.Value[ComboStateKeys.Enabled])
            .Select(preset => Enum.Parse<CustomComboPreset>(preset.Key))
            .ToHashSet();

    #endregion
}
