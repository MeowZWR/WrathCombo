﻿using System;
using System.Collections.Generic;
using WrathCombo.Combos.PvE;
using WrathCombo.Combos.PvP;
using WrathCombo.Extensions;

namespace WrathCombo.Resources.Dictionary.Chinese.Description
{
    public static class WHMDesc
    {
        public static IEnumerable<KeyValuePair<string, string>> GetDescriptions()
        {
            return
            [
                // Generated by the String Extraction and Translation Tool  
                // Model: DeepSeek v3  
                // Temperature: 0.1  
                // Generation Time: 2025-03-13 18:14:55  
                #region WHM                                
                KeyValuePair.Create("Advanced Action", "高级技能"),
                KeyValuePair.Create("Change how actions are handled", "更改技能的处理方式"),
                KeyValuePair.Create("Balance Opener (Level 92)", "平衡起手式（等级92）"),
                KeyValuePair.Create("Adds a Swiftcast->Holy at the beginning of your AoE rotation.", "在AoE循环开始时添加一个Swiftcast->Holy。"),
                KeyValuePair.Create("Swift Holy Pull 'Opener' Option", "即刻神圣起手"),
                KeyValuePair.Create("Requires you to already be in combat, to have stopped moving, and to not have used Assize yet.", "需要你已经进入战斗状态，停止移动，并且尚未使用Assize。"),
                KeyValuePair.Create("Collection of cooldowns and spell features on Glare/Stone.", "收集Glare/Stone的冷却时间和技能特性。"),
                KeyValuePair.Create("Adds Aero/Dia to the single target combo if the debuff is not present on current target, or is about to expire.", "如果当前目标没有Aero/Dia的减益效果，或者即将消失，则在单体连击中添加Aero/Dia。"),
                KeyValuePair.Create("Adds Assize to the single target combo.", "在单体连击中添加Assize。"),
                KeyValuePair.Create("Adds Glare IV to the single target combo when under Sacred Sight", "在Sacred Sight状态下，在单体连击中添加Glare IV。"),
                KeyValuePair.Create("Adds Afflatus Misery to the single target combo when it is ready to be used.", "当Afflatus Misery准备就绪时，在单体连击中添加Afflatus Misery。"),
                KeyValuePair.Create("Adds Afflatus Rapture to the single target combo when at three Lilies.", "当拥有三个血百合时，在单体连击中添加Afflatus Rapture。"),
                KeyValuePair.Create("Adds Presence of Mind to the single target combo.", "在单体连击中添加Presence of Mind。"),
                KeyValuePair.Create("Adds Lucid Dreaming to the single target combo when below set MP value.", "当魔力值低于设定值时，在单体连击中添加Lucid Dreaming。"),
                KeyValuePair.Create("Collection of cooldowns and spell features on Holy/Holy III.", "收集Holy/Holy III的冷却时间和技能特性。"),
                KeyValuePair.Create("Adds Assize to the AoE combo.", "在AoE连击中添加Assize。"),
                KeyValuePair.Create("Adds Glare IV to the AoE combo when under Sacred Sight", "在Sacred Sight状态下，在AoE连击中添加Glare IV。"),
                KeyValuePair.Create("Adds Afflatus Misery to the AoE combo when it is ready to be used.", "当Afflatus Misery准备就绪时，在AoE连击中添加Afflatus Misery。"),
                KeyValuePair.Create("Adds Afflatus Rapture to the AoE combo when at three Lilies.", "当拥有三个血百合时，在AoE连击中添加Afflatus Rapture。"),
                KeyValuePair.Create("Adds Presence of Mind to the AoE combo, this will delay your GCD by default.", "在AoE连击中添加Presence of Mind，默认情况下会延迟你的GCD。"),
                KeyValuePair.Create("Adds Lucid Dreaming to the AoE combo when below the set MP value if you are moving or it can be weaved without GCD delay.", "当MP低于设定值时，如果你在移动或可以在不延迟GCD的情况下插入，则在AoE连击中添加Lucid Dreaming。"),
                KeyValuePair.Create("Replaces Afflatus Solace with Afflatus Misery when it is ready to be used.", "当Afflatus Misery准备就绪时，用Afflatus Misery替换Afflatus Solace。"),
                KeyValuePair.Create("Replaces Afflatus Rapture with Afflatus Misery when it is ready to be used.", "当Afflatus Misery准备就绪时，用Afflatus Misery替换Afflatus Rapture。"),
                KeyValuePair.Create("Replaces Medica with a one button AoE healing setup.", "用一个按钮的AoE治疗设置替换Medica。"),
                KeyValuePair.Create("Uses Afflatus Rapture when available.", "当Afflatus Rapture可用时使用。"),
                KeyValuePair.Create("Uses Afflatus Misery when available.", "当Afflatus Misery可用时使用。"),
                KeyValuePair.Create("Uses Thin Air when available.", "当Thin Air可用时使用。"),
                KeyValuePair.Create("Replaces Medica with Cure III when available.", "当Cure III可用时，用Cure III替换Medica。"),
                KeyValuePair.Create("Uses Assize when available.", "当Assize可用时使用。"),
                KeyValuePair.Create("Uses Plenary Indulgence when available.", "当Plenary Indulgence可用时使用。"),
                KeyValuePair.Create("Uses Lucid Dreaming when available.", "当Lucid Dreaming可用时使用。"),
                KeyValuePair.Create("Uses Divine Caress when Divine Grace from Temperance is active.", "当节制的Divine Caress预备激活时使用Divine Caress。"),
                KeyValuePair.Create("Replaces Cure with a one button single target healing setup.", "用一个按钮的单体治疗设置替换Cure。"),
                KeyValuePair.Create("Applies Regen to the target if missing.", "如果目标缺少Regen，则应用Regen。"),
                KeyValuePair.Create("Uses Benediction when target is below HP threshold.", "当目标HP低于阈值时使用Benediction。"),
                KeyValuePair.Create("Uses Afflatus Solace when available.", "当Afflatus Solace可用时使用。"),
                KeyValuePair.Create("Uses Tetragrammaton when available.", "当Tetragrammaton可用时使用。"),
                KeyValuePair.Create("Uses Divine Benison when available.", "当Divine Benison可用时使用。"),
                KeyValuePair.Create("Uses Aquaveil when available.", "当Aquaveil可用时使用。"),
                KeyValuePair.Create("Applies Esuna to your target if there is a cleansable debuff.", "如果目标有可清除的减益效果，则对目标使用Esuna。"),
                KeyValuePair.Create("Changes Cure II to Cure when synced below Lv.30.", "当同步到30级以下时，将Cure II更改为Cure。"),
                KeyValuePair.Create("Changes Swiftcast to Raise.", "将Swiftcast更改为Raise。"),
                KeyValuePair.Create("Adds Thin Air to the Global Raise Feature/Alternative Raise Feature.", "将Thin Air添加到全局复活功能/备用复活功能。"),
                KeyValuePair.Create("Use Variant Rampart on cooldown.", "冷却即用Variant Rampart。"),
                KeyValuePair.Create("Turns Glare into an all-in-one damage button.", "将Glare变成一个全能伤害按钮。"),
                KeyValuePair.Create("Adds Afflatus Misery to Burst Mode.", "将Afflatus Misery添加到爆发模式。"),
                KeyValuePair.Create("Adds Miracle of Nature to Burst Mode.", "将Miracle of Nature添加到爆发模式。"),
                KeyValuePair.Create("Adds Seraph Strike to Burst Mode.", "将Seraph Strike添加到爆发模式。"),
                KeyValuePair.Create("Adds Afflatus Purgation (Limit Break) to Burst Mode.", "将Afflatus Purgation（极限技）添加到爆发模式。"),
                KeyValuePair.Create("Adds the below options onto Cure II.", "将以下选项添加到Cure II。"),
                KeyValuePair.Create("Adds Cure III to Cure II when available.", "当Cure III可用时，将其添加到Cure II。"),
                KeyValuePair.Create("Adds Aquaviel to Cure II when available.", "当Aquaveil可用时，将其添加到Cure II。"),
                KeyValuePair.Create("Uses Medica II when current target doesn't have Medica II buff.", "当当前目标没有Medica II增益时，使用Medica II。"),
                KeyValuePair.Create("Upgrades to Medica III when level allows.", "当等级允许时，升级为Medica III。"),
                KeyValuePair.Create("Only Weave or Use Whilst Moving.", "仅在移动时插入或使用。"),
                KeyValuePair.Create("Use when MP is above", "当MP高于此值时使用"),
                KeyValuePair.Create("Time Remaining on Buff to Renew", "刷新增益的剩余时间"),
                KeyValuePair.Create("Party UI Mousover Checking", "小队UI鼠标悬停检查"),
                KeyValuePair.Create("Check your mouseover target for the Medica II/III buff.", "检查你的鼠标悬停目标是否有医济/医养增益。"),
                KeyValuePair.Create("Time Remaining Before Refreshing", "刷新前的剩余时间"),
                KeyValuePair.Create("Use when target HP% is at or below.", "当目标生命值百分比等于或低于此值时使用。"),
                #endregion

                // Manually added
                KeyValuePair.Create("Apply options to all Stones and Glares.", "将选项应用于所有飞石及闪耀。"),
                KeyValuePair.Create("Apply options to Aeros and Dia.", "将选项应用于所有疾风及天辉。"),
                KeyValuePair.Create($"Apply options to On 坚石.", $"将选项应用于坚石。"),
                KeyValuePair.Create($"If Both {WHMPvP.Aquaveil.ActionName()} & {WHMPvP.Cure3.ActionName()} are ready, prioritise {WHMPvP.Aquaveil.ActionName()}", "如果水流幕和愈疗都准备就绪，优先使用水流幕"),
                KeyValuePair.Create($"If Both {WHMPvP.Aquaveil.ActionName()} & {WHMPvP.Cure3.ActionName()} are ready, prioritise {WHMPvP.Cure3.ActionName()}", "如果水流幕和愈疗都准备就绪，优先使用愈疗"),
            ];
        }
    }
}
