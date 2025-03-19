﻿using System;
using System.Collections.Generic;
using WrathCombo.Combos.PvE;
using WrathCombo.Combos.PvP;
using WrathCombo.Extensions;

namespace WrathCombo.Resources.Dictionary.Chinese.Description
{
    public static class VPRDesc
    {
        public static IEnumerable<KeyValuePair<string, string>> GetDescriptions()
        {
            return
            [
                // Generated by the String Extraction and Translation Tool  
                // Model: DeepSeek v3  
                // Temperature: 0.1  
                // Generation Time: 2025-03-13 18:14:55  
                #region VPRPvE
                KeyValuePair.Create("Replaces Steel Fangs with a full one-button single target rotation.", "用一键完整单体循环替换Steel Fangs。"),
                KeyValuePair.Create("Replaces Steel Maw with a full one-button AoE rotation.", "用一键完整AOE循环替换Steel Maw。"),
                KeyValuePair.Create("These features are ideal if you want to customize the rotation.", "适合想要自定义循环的玩家。"),
                KeyValuePair.Create(" Does not check positional choice.", "不检查位置选择。"),
                KeyValuePair.Create(" Always does Hunter's Coil first (FLANK)", "总是先使用猛袭盘蛇（侧方身位）。"),
                KeyValuePair.Create("Adds Serpents Ire to the rotation.", "将Serpents Ire加入循环。"),
                KeyValuePair.Create("Adds Vicewinder to the rotation.", "将Vicewinder加入循环。"),
                KeyValuePair.Create("Adds Swiftskin's Coil and Hunter's Coil to the rotation.", "将Swiftskin's Coil和Hunter's Coil加入循环。"),
                KeyValuePair.Create("Will automatically swap depending on your position.", "会根据你的身位自动切换。"),
                KeyValuePair.Create("Adds Twinfang and Bloodfang to the rotation.", "将飞蛇连尾击和飞蛇乱尾击加入循环。"),
                KeyValuePair.Create("Adds Serpents Tail to the rotation.", "将Serpents Tail加入循环。"),
                KeyValuePair.Create("Adds Uncoiled Fury to the rotation.", "将Uncoiled Fury加入循环。"),
                KeyValuePair.Create("Adds Uncoiled Twinfang and Uncoiled Twinblood to the rotation.", "将Uncoiled Twinfang和Uncoiled Twinblood加入循环。"),
                KeyValuePair.Create("Adds Reawaken to the rotation.", "将Reawaken加入循环。"),
                KeyValuePair.Create("Adds Generation and Legacy to the rotation.", "将祖灵之牙和祖灵之蛇加入循环。"),
                KeyValuePair.Create("Adds True North when you are not in the correct position for the enhanced potency bonus.", "当你不处于正确位置以获得增强威力加成时，添加True North。"),
                KeyValuePair.Create("Adds Writhing Snap to the rotation when you are out of melee range.", "当你处于近战范围外时，将Writhing Snap加入循环。"),
                KeyValuePair.Create("Adds Uncoiled Fury to the rotation when you are out of melee range and have Rattling Coil charges.", "当你处于近战范围外且拥有Rattling Coil充能时，将Uncoiled Fury加入循环。"),
                KeyValuePair.Create("Adds Bloodbath and Second Wind to the rotation.", "将Bloodbath和Second Wind加入循环。"),
                KeyValuePair.Create("Adds Vicepit to the rotation.", "将Vicepit加入循环。"),
                KeyValuePair.Create("Disables the range check for Vicepit, so it will be used even without a target selected.", "禁用Vicepit的范围检查，即使没有选择目标也会使用。"),
                KeyValuePair.Create("Adds Swiftskin's Den and Hunter's Den to the rotation.", "将Swiftskin's Den和Hunter's Den加入循环。"),
                KeyValuePair.Create("Disables the range check for Swiftskin's Den and Hunter's Den, so they will be used even without a target selected.", "禁用Swiftskin's Den和Hunter's Den的范围检查，即使没有选择目标也会使用。"),
                KeyValuePair.Create("Adds Twinfang and Twinblood to the rotation.", "将Twinfang和Twinblood加入循环。"),
                KeyValuePair.Create("Disables the range check for Reawaken, so it will be used even without a target selected.", "禁用Reawaken的范围检查，即使没有选择目标也会使用。"),
                KeyValuePair.Create("Replaces Vicewinder with Hunter's/Swiftskin's Coils.", "用Hunter's Coils/Swiftskin's Coils替换Vicewinder。"),
                KeyValuePair.Create("Replaces Vicepit with Hunter's/Swiftskin's Dens.", "用Hunter's Coils/Swiftskin's Dens替换Vicepit。"),
                KeyValuePair.Create("Replaces Uncoiled Fury with Uncoiled Twinfang and Uncoiled Twinblood.", "用Uncoiled Twinfang和Uncoiled Twinblood替换Uncoiled Fury。"),
                KeyValuePair.Create("Replaces Option with the Generations.", "用祖灵之牙替换。"),
                KeyValuePair.Create("Replaces Option with the Legacys.", "用祖灵之蛇替换。"),
                KeyValuePair.Create("Combines Serpent's Tail, Twinfang, and Twinblood to one button.", "将Serpent's Tail、Twinfang和Twinblood合并为一个按钮。"),
                KeyValuePair.Create("Adds Twinfang and Twinblood to the button.", "将Twinfang和Twinblood添加到按钮。"),
                KeyValuePair.Create("Legacy Buttons", "祖灵之蛇"),
                KeyValuePair.Create("Replaces Generations with the Legacys.", "用祖灵之蛇替换祖灵之牙。"),
                KeyValuePair.Create("Replaces basic combo with Death Rattle or Last Lash when applicable.", "在适用时用Death Rattle或Last Lash替换基础连击。"),
                KeyValuePair.Create("Set a HP% Threshold to use all charges.", "设置生命百分比阈值以使用所有充能。"),
                KeyValuePair.Create("Disable Range Check", "禁用范围检查"),
                KeyValuePair.Create("Include Twin Combo Actions", "包含双牙连击技能"),
                KeyValuePair.Create("Vicewinder - Coils", "强碎灵蛇 - 盘蛇"),
                KeyValuePair.Create("Uncoiled - Twins", "飞蛇连击"),
                KeyValuePair.Create("Vicepit - Dens", "强碎灵蝰 - 盘蝰"),
                KeyValuePair.Create("Reawaken - Generation", "祖灵降临 - 祖灵之牙"),
                KeyValuePair.Create("Reawaken - Legacy", "祖灵降临 - 祖灵之蛇"),
                KeyValuePair.Create("Combined Combo Ability Feature", "组合连击技"),
                KeyValuePair.Create($"Stop using {VPR.Reawaken.ActionName()} at Enemy HP %. Set to Zero to disable this check.", $"当敌人生命百分比达到此值时停止使用{VPR.Reawaken.ActionName()}。设置为零以禁用此检查。"),
                KeyValuePair.Create($"Replaces {VPR.Reawaken.ActionName()} with Full Generation - Legacy combo.", $"将{VPR.Reawaken.ActionName()}替换为祖灵之牙-祖灵之蛇连击。"),
                #endregion
                
                #region VPRPvP
                KeyValuePair.Create("Turns Dual Fang Combo into an all-in-one button.", "将咬噬尖齿和切割尖齿连击整合为一个按钮。"),
                KeyValuePair.Create("Uses Bloodcoil when available.", "在可用时使用Bloodcoil。"),
                KeyValuePair.Create("- Requires target's or player's HP to be under:", "- 需要目标或玩家的HP低于："),
                KeyValuePair.Create("Uses Uncoiled Fury when available.", "在可用时使用Uncoiled Fury。"),
                KeyValuePair.Create("Uses Backlash when available.", "在可用时使用Backlash。"),
                KeyValuePair.Create("Uses Rattling Coil when any condition is met.", "当满足任何条件时使用Rattling Coil。"),
                KeyValuePair.Create("Uses Slither when outside melee.", "在近战范围外时使用Slither。"),
                KeyValuePair.Create("- Must remain within maximum range.", "- 必须保持在最大范围内。"),
                KeyValuePair.Create("- Will not use if already under Slither's effect.", "- 如果已经处于Slither效果下则不会使用。"),
                KeyValuePair.Create("Adds Rattling Coil to Snake Scales when available.", "在可用时将Rattling Coil添加到Snake Scales中。"),
                KeyValuePair.Create("- Requires Snake Scales to be on cooldown.", "- 需要Snake Scales处于冷却中。"),
                #endregion
            ];
        }
    }
}
