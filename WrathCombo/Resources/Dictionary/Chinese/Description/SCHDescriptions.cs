﻿using System;
using System.Collections.Generic;
using WrathCombo.Combos.PvE;
using WrathCombo.Combos.PvP;
using WrathCombo.Extensions;

namespace WrathCombo.Resources.Dictionary.Chinese.Description
{
    public static class SCHDesc
    {
        public static IEnumerable<KeyValuePair<string, string>> GetDescriptions()
        {
            return
            [
                // Generated by the String Extraction and Translation Tool  
                // Model: DeepSeek v3  
                // Temperature: 0.1  
                // Generation Time: 2025-03-13 18:14:55  
                #region SCH
                KeyValuePair.Create("Replaces Ruin I / Broils with options below", "用下方选项替换Ruin / Broil"),
                KeyValuePair.Create("Adds Summon Eos whenever you've not summoned your fairy.", "当你未召唤小仙女时添加Summon Eos。"),
                KeyValuePair.Create("Adds Lucid Dreaming when MP drops below slider value:", "当MP低于滑块值时添加Lucid Dreaming："),
                KeyValuePair.Create("Adds Chain Stratagem & Baneful Impact on cooldown with overlap protection", "添加Chain Stratagem & Baneful Impact，并在冷却时使用，带有重叠保护。"),
                KeyValuePair.Create("Use Aetherflow when out of Aetherflow stacks.", "当Aetherflow层数耗尽时使用Aetherflow。"),
                KeyValuePair.Create("Use Energy Drain to consume remaining Aetherflow stacks when Aetherflow is about to come off cooldown.", "当Aetherflow即将冷却完毕时，使用Energy Drain消耗剩余的Aetherflow层数。"),
                KeyValuePair.Create("Holds Energy Drain when Chain Stratagem is ready or has less than 10 seconds cooldown remaining.", "当Chain Stratagem准备就绪或剩余冷却时间少于10秒时，保留Energy Drain。"),
                KeyValuePair.Create("Use Ruin II when you have to move.", "当你需要移动时使用Ruin II。"),
                KeyValuePair.Create("Automatic DoT uptime.", "自动续DoT。"),
                KeyValuePair.Create("Replaces Art of War with options below.", "用下方选项替换Art of War。"),
                KeyValuePair.Create("Change Fey Blessing into Consolation when Seraph is out.", "当炽天使在场时，将Fey Blessing替换为Consolation。"),
                KeyValuePair.Create("Change Lustrate into Excogitation when Excogitation is ready.", "当Excogitation准备就绪时，将Lustrate替换为Excogitation。"),
                KeyValuePair.Create("Change Recitation into either Adloquium, Succor, Indomitability, or Excogitation when used.", "当使用Recitation时，将其替换为Adloquium、Succor、Indomitability或Excogitation。"),
                KeyValuePair.Create("Change Whispering Dawn into Fey Illumination, Fey Blessing, then Whispering Dawn when used.", "当使用Whispering Dawn时，将其替换为Fey Illumination、Fey Blessing，然后Whispering Dawn。"),
                KeyValuePair.Create("Adds Consolation during Seraph.", "在炽天使期间添加Consolation。"),
                KeyValuePair.Create("Consolation During Seraph Option", "炽天使Consolation"),
                KeyValuePair.Create("Replaces Succor with options below:", "用下方选项替换Succor："),
                KeyValuePair.Create("Adds Lucid Dreaming when MP isn't high enough to cast Succor.", "当MP不足以施放Succor时添加Lucid Dreaming。"),
                KeyValuePair.Create("Only uses Aetherflow is Indomitability is ready to use.", "仅在Indomitability准备就绪时使用Aetherflow。"),
                KeyValuePair.Create("Indomitability Ready Only Option", "仅在Indomitability就绪时"),
                KeyValuePair.Create("Use Dissipation when out of Aetherflow stacks.", "当Aetherflow层数耗尽时使用Dissipation。"),
                KeyValuePair.Create("Use Indomitability before using Succor.", "在使用Succor之前使用Indomitability。"),
                KeyValuePair.Create("Use Fey Illumination before using Succor.", "在使用Succor之前使用Fey Illumination。"),
                KeyValuePair.Create("Use Whispering Dawn before using Succor.", "在使用Succor之前使用Whispering Dawn。"),
                KeyValuePair.Create("Use Seraphism before using Succor.", "在使用Succor之前使用Seraphism。"),
                KeyValuePair.Create("Use Fey Blessing before using Succor.", "在使用Succor之前使用Fey Blessing。"),
                KeyValuePair.Create("Use Consolation before using Succor.", "在使用Succor之前使用Consolation。"),
                KeyValuePair.Create("Change Physick into Adloquium, Lustrate, then Physick with below options:", "将Physick替换为Adloquium、Lustrate，然后Physick，使用下方选项："),
                KeyValuePair.Create("Use Adloquium when missing Galvanize or target HP%% below:", "当目标缺少Galvanize或目标HP%%低于以下值时使用Adloquium："),
                KeyValuePair.Create("Use Lustrate when target HP%% below:", "当目标HP%%低于以下值时使用Lustrate："),
                KeyValuePair.Create("Use Excogitation when target HP%% below:", "当目标HP%%低于以下值时使用Excogitation："),
                KeyValuePair.Create("Use Protraction when target HP%% below:", "当目标HP%%低于以下值时使用Protraction："),
                KeyValuePair.Create("Use Aetherpact when target HP%% below:", "当目标HP%%低于以下值时使用Aetherpact："),
                KeyValuePair.Create("Aetherflow Helper Feature", "以太超流辅助功能"),
                KeyValuePair.Create("Change Aetherflow-using skills to Aetherflow, Recitation, or Dissipation as selected.", "将使用Aetherflow的技能替换为Aetherflow、Recitation或Dissipation，根据选择。"),
                KeyValuePair.Create("Prioritizes Recitation usage on Excogitation or Indomitability.", "优先在Excogitation或Indomitability上使用Recitation。"),
                KeyValuePair.Create("If Aetherflow is on cooldown, show Dissipation instead.", "如果Aetherflow在冷却中，则显示Dissipation。"),
                KeyValuePair.Create("Changes Swiftcast to Resurrection while Swiftcast is on cooldown.", "当Swiftcast在冷却中时，将Swiftcast替换为Resurrection。"),
                KeyValuePair.Create("Change all fairy actions into Summon Eos when the Fairy is not summoned.", "当未召唤小仙女时，将所有小仙女技能替换为Summon Eos。"),
                KeyValuePair.Create("Changes Deployment Tactics to Adloquium until a party member has the Galvanize buff.", "将Deployment Tactics替换为Adloquium，直到队伍成员获得Galvanize增益。"),
                KeyValuePair.Create("Adds Recitation when off cooldown to force a critical Galvanize buff on a party member.", "当Recitation冷却完毕时添加Recitation，以强制为队伍成员施加暴击Galvanize增益。"),
                KeyValuePair.Create("Turns Broil IV into all-in-one damage button.", "将Broil IV变为全能伤害按钮。"),
                KeyValuePair.Create("Adds Expedient to Burst Mode to empower Biolysis.", "在爆发模式中添加Expedient以增强Biolysis。"),
                KeyValuePair.Create("Adds Biolysis use on cooldown to Burst Mode.", "在爆发模式中添加Biolysis，并在冷却时使用。"),
                KeyValuePair.Create("Adds Deployment Tactics to Burst Mode when available.", "在爆发模式中添加Deployment Tactics，当可用时。"),
                KeyValuePair.Create("Adds Chain Stratagem to Burst Mode when available.", "在爆发模式中添加Chain Stratagem，当可用时。"),
                KeyValuePair.Create("Warning, will force the use of Adloquium, and normal Physick maybe unavailable.", "警告：将强制使用鼓舞激励之策，且可能无法使用普通的医术。"),
                KeyValuePair.Create("Sage Shield Check", "贤者护盾检查"),
                KeyValuePair.Create("Dissipation First", "先使用转化"),
                KeyValuePair.Create("Uses Dissipation first, then Aetherflow", "先使用转化，再使用以太超流"),
                KeyValuePair.Create("Aetherflow First", "先使用以太超流"),
                KeyValuePair.Create("Uses Aetherflow first, then Dissipation", "先使用以太超流，再使用转化"),
                KeyValuePair.Create("Aetherflow remaining cooldown:", "以太超流剩余冷却时间："),
                KeyValuePair.Create($"Warning, will force the use of {SCH.Adloquium.ActionName()}, and normal {SCH.Physick.ActionName()} maybe unavailable.", $"警告，将强制使用{SCH.Adloquium.ActionName()}，而正常的{SCH.Physick.ActionName()}可能不可用。"),
                KeyValuePair.Create("Enable to not override an existing Sage's shield.", "启用以避免覆盖现有贤者的护盾。"),
                KeyValuePair.Create($"{SCH.EmergencyTactics.ActionName()}", $"{SCH.EmergencyTactics.ActionName()}"),
                KeyValuePair.Create($"Use {SCH.EmergencyTactics.ActionName()} before {SCH.Adloquium.ActionName()}", $"在{SCH.Adloquium.ActionName()}之前使用{SCH.EmergencyTactics.ActionName()}"),
                KeyValuePair.Create("Start using when below HP %. Set to 100 to disable this check", "当生命值低于此百分比时开始使用。设置为100以禁用此检查。"),
                KeyValuePair.Create("Stop using when above HP %.", "当生命值高于此百分比时停止使用。"),
                KeyValuePair.Create("Minimal Fairy Gauge to start using Aetherpact", "开始使用以太契约所需的最低异想以太"),
                KeyValuePair.Create("Show Aetherflow On Energy Drain Only", "仅在能量吸收上显示以太超流"),
                KeyValuePair.Create("Show Aetherflow On All Aetherflow Skills", "在所有以太超流技能上显示以太超流"),
                KeyValuePair.Create("Only when out of Aetherflow Stacks", "仅在以太超流层数用尽时"),
                KeyValuePair.Create("Always when available", "只要可用就使用"),
                KeyValuePair.Create("On Indominability", "不屈不挠之策"),
                #endregion

                // Manually added
                KeyValuePair.Create("On Ruin/Broils", "应用于毁灭/死炎法"),
                KeyValuePair.Create("Apply options to Ruin and all Broils.", "将选项应用于毁灭及所有死炎法。"),
                KeyValuePair.Create("On Bio/Bio II/Biolysis", "应用于毒菌/猛毒菌/蛊毒法"),
                KeyValuePair.Create("Apply options to Bio and Biolysis.", "将选项应用于毒菌及蛊毒法。"),
                KeyValuePair.Create("On Ruin II", "应用于毁坏"),
                KeyValuePair.Create("Apply options to Ruin II.", "将选项应用于毁坏。"),
            ];
        }
    }
}
