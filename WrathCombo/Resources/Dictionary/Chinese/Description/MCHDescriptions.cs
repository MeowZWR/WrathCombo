﻿using System;
using System.Collections.Generic;
using WrathCombo.Combos.PvE;
using WrathCombo.Combos.PvP;
using WrathCombo.Data;
using WrathCombo.Extensions;

namespace WrathCombo.Resources.Dictionary.Chinese.Description
{
    public static class MCHDesc
    {
        public static IEnumerable<KeyValuePair<string, string>> GetDescriptions()
        {
            return
            [
                // Generated by the String Extraction and Translation Tool  
                // Model: DeepSeek v3  
                // Temperature: 0.1  
                // Generation Time: 2025-03-13 18:14:55  
                #region MCHPvE
                KeyValuePair.Create("Replaces Split Shot with a full one-button single target rotation.", "用完整的一键单目标循环替换Split Shot。"),
                KeyValuePair.Create("Replaces Spreadshot with a full one-button AoE rotation.", "用完整的一键AoE循环替换Spreadshot。"),
                KeyValuePair.Create("Will lock out input to keep Flamethrower going by replacing Spreadshot with Savage Blade.", "通过用Savage Blade替换Spreadshot来锁定输入以保持Flamethrower的持续。"),
                KeyValuePair.Create("Adds the Balance opener at lvl 90+.", "在90级以上时使用由The Balance社区推荐的起手循环。"),
                KeyValuePair.Create("Adds Barrel Stabilizer to the rotation.", "将Barrel Stabilizer添加到循环中。"),
                KeyValuePair.Create("Adds Full Metal Field to the rotation.", "将Full Metal Field添加到循环中。"),
                KeyValuePair.Create("Adds Gauss Round and Ricochet or Double Check and Checkmate to the rotation. Will prevent overcapping.", "将Gauss Round和Ricochet或Double Check和Checkmate添加到循环中。防止资源溢出。"),
                KeyValuePair.Create("Adds Wildfire to the rotation.", "将Wildfire添加到循环中。"),
                KeyValuePair.Create("Adds Hypercharge to the rotation.", "将Hypercharge添加到循环中。"),
                KeyValuePair.Create("Adds Heat Blast or Blazing Shot to the rotation", "将Heat Blast或Blazing Shot添加到循环中。"),
                KeyValuePair.Create("Adds Rook Autoturret or Automaton Queen to the rotation.", "将Rook Autoturret或Automaton Queen添加到循环中。"),
                KeyValuePair.Create("Rook / Queen Overdrive Option", "Rook Overdrive / Queen Overdrive Option"),
                KeyValuePair.Create("Adds Rook or Queen Overdrive to the rotation.", "将Rook Overdrive或Queen Overdrive添加到循环中。"),
                KeyValuePair.Create("Adds Reassemble to the rotation.", "将Reassemble添加到循环中。"),
                KeyValuePair.Create("Will be used priority based.", "将根据优先级使用。"),
                KeyValuePair.Create("Order from highest to lowest priority :", "优先级从高到低排序："),
                KeyValuePair.Create("Excavator - Chainsaw - Air Anchor - Drill - Clean Shot", "Excavator - Chainsaw - Air Anchor - Drill - Clean Shot"),
                KeyValuePair.Create("Adds Drill to the rotation.", "将Drill添加到循环中。"),
                KeyValuePair.Create("Adds Hot Shot/Air Anchor to the rotation.", "将Hot Shot/Air Anchor添加到循环中。"),
                KeyValuePair.Create("Adds Chain Saw to the rotation.", "将Chain Saw添加到循环中。"),
                KeyValuePair.Create("Adds Excavator to the rotation.", "将Excavator添加到循环中。"),
                KeyValuePair.Create("Uses Head Graze to interrupt during the rotation, where applicable.", "在适用的情况下，使用Head Graze在循环中打断。"),
                KeyValuePair.Create("Use Second Wind when below the set HP percentage.", "当HP低于设定百分比时使用Second Wind。"),
                KeyValuePair.Create("Adds Flamethrower to the rotation.", "将Flamethrower添加到循环中。"),
                KeyValuePair.Create(" Changes to Savage blade when in use to prevent cancelling.", "在使用时更改为Savage Blade以防止取消。"),
                KeyValuePair.Create("Adds Gauss Round and Ricochet or Double Check and Checkmate to the rotation.", "将Gauss Round和Ricochet或Double Check和Checkmate添加到循环中。"),
                KeyValuePair.Create("Use Blazing shot instead of Crossbow at lvl 92+", "在92级以上时使用Blazing Shot代替Crossbow。"),
                KeyValuePair.Create("Adds Bioblaster to the rotation.", "将Bioblaster添加到循环中。"),
                KeyValuePair.Create("Adds Air Anchor to the the rotation.", "将Air Anchor添加到循环中。"),
                KeyValuePair.Create("Adds Chain Saw to the the rotation.", "将Chain Saw添加到循环中。"),
                KeyValuePair.Create("Prevents the use of Dismantle when target already has the effect by replacing it with Savage Blade.", "当目标已有Dismantle效果时，通过用Savage Blade替换来防止使用Dismantle。"),
                KeyValuePair.Create("Swap dismantle with tactician when dismantle is on cooldown.", "当Dismantle冷却时，用Tactician替换Dismantle。"),
                KeyValuePair.Create("Turns Heat Blast or Blazing Shot into Hypercharge ", "当你有50或更多热量或获得Hypercharge增益时，将Heat Blast或Blazing Shot转换为Hypercharge。"),
                KeyValuePair.Create("when u have 50 or more heat or when u got Hypercharged buff.", "当你有50或更多热量或获得Hypercharge增益时。"),
                KeyValuePair.Create("Adds Barrel Stabilizer to the feature when off cooldown.", "冷却结束时将Barrel Stabilizer添加到功能中。"),
                KeyValuePair.Create("Adds Wildfire to the feature when off cooldown and overheated.", "冷却结束且过热时将Wildfire添加到功能中。"),
                KeyValuePair.Create("Switches between Heat Blast and either Gauss Round and Ricochet or Double Check and Checkmate, depending on cooldown timers.", "根据冷却时间在Heat Blast和Gauss Round与Ricochet或Double Check与Checkmate之间切换。"),
                KeyValuePair.Create("Turns Auto Crossbow into Hypercharge when at or above 50 heat.", "当热量达到或超过50时，将Auto Crossbow转换为Hypercharge。"),
                KeyValuePair.Create("Adds Barrel Stabilizer to the feature when below 50 Heat Gauge.", "当热量低于50时，将Barrel Stabilizer添加到功能中。"),
                KeyValuePair.Create("Switches between Auto Crossbow and either Gauss Round and Ricochet or Double Check and Checkmate, depending on cooldown timers.", "根据冷却时间在Auto Crossbow和Gauss Round与Ricochet或Double Check与Checkmate之间切换。"),
                KeyValuePair.Create("Replace Rook Autoturret and Automaton Queen with Overdrive while active.", "在激活时用Overdrive替换Rook Autoturret和Automaton Queen。"),
                KeyValuePair.Create("Replace Hot Shot, Drill, Air Anchor, Chainsaw and Excavator depending on which is on cooldown.", "根据冷却时间替换Hot Shot、Drill、Air Anchor、Chainsaw和Excavator。"),
                KeyValuePair.Create("Replace Gauss Round and Ricochet or Double Check and Checkmate with one or the other depending on which has more charges.", "根据剩余次数替换Gauss Round和Ricochet或Double Check和Checkmate。"),
                KeyValuePair.Create("Number of Charges to Save for Manual Use", "保留用于手动使用的充能次数"),
                KeyValuePair.Create($"Uses {ActionWatching.GetActionName(MCH.AutomatonQueen)} at this battery threshold outside of Boss encounter.", $"在非Boss战中，当电量达到此阈值时使用{ActionWatching.GetActionName(MCH.AutomatonQueen)}。"),
                KeyValuePair.Create("Only counts for 'Boss encounters Only setting'.", "仅适用于“仅限Boss战”设置。"),
                KeyValuePair.Create("HP% for the target to be at or under", "目标生命百分比达到或低于此值"),
                KeyValuePair.Create($"Use Outwith {ActionWatching.GetActionName(MCH.Hypercharge)}", $"在{ActionWatching.GetActionName(MCH.Hypercharge)}之外使用"),
                KeyValuePair.Create($"Uses {ActionWatching.GetActionName(MCH.AutomatonQueen)} logic regardless of content.", $"无论内容如何，使用{ActionWatching.GetActionName(MCH.AutomatonQueen)}的逻辑。"),
                KeyValuePair.Create($"Uses {ActionWatching.GetActionName(MCH.Excavator)} logic regardless of content.", $"无论内容如何，使用{ActionWatching.GetActionName(MCH.Excavator)}的逻辑。"),
                KeyValuePair.Create($"Only uses {ActionWatching.GetActionName(MCH.Excavator)} logic when in Boss encounters.", $"仅在Boss战中使用{ActionWatching.GetActionName(MCH.Excavator)}的逻辑。"),
                KeyValuePair.Create($"Only uses {ActionWatching.GetActionName(MCH.AutomatonQueen)} logic when in Boss encounters.", $"仅在Boss战中使用{ActionWatching.GetActionName(MCH.AutomatonQueen)}的逻辑。"),
                KeyValuePair.Create("Battery threshold", "电量阈值"),
                KeyValuePair.Create("Barrel Option", "枪管加热"),
                #endregion
                
                #region MCHPvP
                KeyValuePair.Create("Turns Blast Charge into an all-in-one damage button.", "将蓄力冲击变为一个全能伤害按钮。"),
                KeyValuePair.Create("Adds Air Anchor to Burst Mode.", "将Air Anchor加入Burst Mode。"),
                KeyValuePair.Create("Adds Analysis to Burst Mode.", "将Analysis加入Burst Mode。"),
                KeyValuePair.Create("Alternate Analysis Option", "保留分析"),
                KeyValuePair.Create("Uses Analysis with Air Anchor instead of Chain Saw.", "在Burst Mode中使用Analysis与Air Anchor，而非Chain Saw。"),
                KeyValuePair.Create("Adds Drill to Burst Mode.", "将Drill加入Burst Mode。"),
                KeyValuePair.Create("Saves Drill for use after Wildfire.", "保留Drill在Wildfire之后使用。"),
                KeyValuePair.Create("Bio Blaster Option", "毒菌冲击"),
                KeyValuePair.Create("Adds Bio Blaster to Burst Mode.", "将毒菌冲击加入Burst Mode。"),
                KeyValuePair.Create("Adds Chain Saw to Burst Mode.", "将Chain Saw加入Burst Mode。"),
                KeyValuePair.Create("Adds Full Metal Field to Burst Mode.", "将Full Metal Field加入Burst Mode。"),
                KeyValuePair.Create("Adds Wildfire to Burst Mode.", "将Wildfire加入Burst Mode。"),
                KeyValuePair.Create("Adds Marksmans Spite to Burst Mode when the target is below specified HP.", "当目标生命值低于指定值时，将Marksmans Spite加入Burst Mode。"),
                KeyValuePair.Create("Adds Barrel Stabilizer to Burst Mode.", "将Barrel Stabilizer加入Burst Mode。"),
                KeyValuePair.Create("Alternate Drill Option", "保留钻头"),
                #endregion
            ];
        }
    }
}
