﻿using System;
using System.Collections.Generic;
using WrathCombo.Combos.PvE;
using WrathCombo.Combos.PvP;
using WrathCombo.Extensions;

namespace WrathCombo.Resources.Dictionary.Chinese.Description
{
    public static class MNKDesc
    {
        public static IEnumerable<KeyValuePair<string, string>> GetDescriptions()
        {
            return
            [
                // Generated by the String Extraction and Translation Tool  
                // Model: DeepSeek v3  
                // Temperature: 0.1  
                // Generation Time: 2025-03-13 18:14:55  
                #region MNK
                KeyValuePair.Create("Replaces Bootshine with a full one-button single target rotation.", "用一键连击替换Bootshine，用于单体目标循环。"),
                KeyValuePair.Create("Replaces Arms of the Destroyer with a full one-button AoE rotation.", "用一键连击替换Arms of the Destroyer，用于群体目标循环。"),
                KeyValuePair.Create("Adds The Forbidden Chakra to the rotation", "将The Forbidden Chakra加入循环。"),
                KeyValuePair.Create("Adds Form Shift to the rotation", "将Form Shift加入循环。"),
                KeyValuePair.Create("Uses selected opener", "使用选定的起手式。"),
                KeyValuePair.Create("Adds selected buffs to the rotation", "将选定的增益技能加入循环。"),
                KeyValuePair.Create("Adds Brotherhood to the rotation", "将Brotherhood加入循环。"),
                KeyValuePair.Create("Riddle of Fire Option", "红莲极意"),
                KeyValuePair.Create("Adds Riddle of Fire to the rotation", "将红莲极意加入循环。"),
                KeyValuePair.Create("Fire's Reply Option", "乾坤斗气弹"),
                KeyValuePair.Create("Adds Fire's Reply to the rotation", "将乾坤斗气弹加入循环。"),
                KeyValuePair.Create("Adds Riddle of Wind to the rotation", "将Riddle of Wind加入循环。"),
                KeyValuePair.Create("Adds Wind's Reply to the rotation", "将Wind's Reply加入循环。"),
                KeyValuePair.Create("Adds Perfect Balance to the rotation", "将Perfect Balance加入循环。"),
                KeyValuePair.Create("Adds Masterful Blitz to the rotation", "将Masterful Blitz加入循环。"),
                KeyValuePair.Create("Adds True North dynamically, when not in positional, to the rotation", "当不在位置要求时，动态将True North加入循环。"),
                KeyValuePair.Create("Adds Howling Fist to the rotation", "将Howling Fist加入循环。"),
                KeyValuePair.Create("Merge single target GCDs which share the same beast chakra", "合并共享相同兽脉的单体GCD技能。"),
                KeyValuePair.Create("Perfect Balance becomes Masterful Blitz while you have 3 Beast Chakra.", "当拥有3个兽脉时，Perfect Balance变为Masterful Blitz。"),
                KeyValuePair.Create("Turns Phantom Rush Combo into an all-in-one damage button.", "将Phantom Rush连击变为一个全能的伤害按钮。"),
                KeyValuePair.Create("Adds Meteodrive Limit break to Burst Mode when target is below 20k and guarded", "当目标血量低于20k且处于防御状态时，将Meteodrive极限技加入爆发模式。"),
                KeyValuePair.Create("Adds Thunderclap to Burst Mode when not buffed with Wind Resonance.", "当未获得疾风神髓增益时，将Thunderclap加入爆发模式。"),
                KeyValuePair.Create("Adds Riddle of Earth and Earth's Reply to Burst Mode when in combat.", "在战斗中，将Riddle of Earth和Earth's Reply加入爆发模式。"),
                KeyValuePair.Create("Adds Flints Reply to Burst Mode.", "将Flint's Reply加入爆发模式。"),
                KeyValuePair.Create("Adds Rising Phoenix to Burst Mode.", "将Rising Phoenix加入爆发模式。"),
                KeyValuePair.Create("Adds Wind's Reply to Burst Mode.", "将Wind's Reply加入爆发模式。"),
                KeyValuePair.Create("Beast Chakra Handlers", "象形拳处理"),
                KeyValuePair.Create("Meditation Option", "斗气"),
                KeyValuePair.Create("Adds Meditation to the rotation", "将斗气添加到循环中"),
                KeyValuePair.Create("Double Lunar", "双阴"),
                KeyValuePair.Create("Uses Lunar/Lunar opener", "使用双阴斗气起手"),
                KeyValuePair.Create("Solar Lunar", "阳阴"),
                KeyValuePair.Create("Uses Solar/Lunar opener", "使用阳阴斗气起手"),
                KeyValuePair.Create($"Stop Using {MNK.Brotherhood.ActionName()} When Target HP% is at or Below (Set to 0 to Disable This Check)", $"当目标生命百分比达到或低于此值时停止使用 {MNK.Brotherhood.ActionName()}（设置为0以禁用此检查）"),
                KeyValuePair.Create("Riddle of Fire/Brotherhood Feature", "红莲极意/义结金兰"),
                KeyValuePair.Create("Replaces Riddle of Fire with Brotherhood when Riddle of Fire is on cooldown.", "如果红莲极意进入冷却时，用义结金兰代替。"),
                KeyValuePair.Create("Replaces Brotherhood with Riddle of Fire when Brotherhood is on cooldown.", "如果义结金兰进入冷却时，用红莲极意代替。"),
                KeyValuePair.Create($"Stop Using {MNK.RiddleOfFire.ActionName()} When Target HP% is at or Below (Set to 0 to Disable This Check)", $"当目标生命百分比达到或低于此值时停止使用{MNK.RiddleOfFire.ActionName()}（设置为0以禁用此检查）"),
                KeyValuePair.Create($"Stop Using {MNK.RiddleOfWind.ActionName()} When Target HP% is at or Below (Set to 0 to Disable This Check)", $"当目标生命百分比达到此值时停止使用{MNK.RiddleOfWind.ActionName()}（设置为0以禁用此检查）"),
                KeyValuePair.Create("Opo-opo Option", "魔猿"),
                KeyValuePair.Create("Replace Bootshine/Leaping Opo with Dragon Kick.", "将连击/猿舞连击添加到双龙脚。"),
                KeyValuePair.Create("Raptor Option", "猛禽选项"),
                KeyValuePair.Create("Replace True Strike/Rising Raptor with Twin Snakes.", "将正拳/龙颚正拳添加到双掌打。"),
                KeyValuePair.Create("Coeurl Option", "豹选项"),
                KeyValuePair.Create("Replace Snap Punch/Pouncing Coeurl with Demolish.", "将崩拳/豹袭崩拳添加到破碎拳。"),
                                #endregion
            ];
        }
    }
}
