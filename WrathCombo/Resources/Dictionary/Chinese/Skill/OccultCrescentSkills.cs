using System;
using System.Collections.Generic;

namespace WrathCombo.Resources.Dictionary.Chinese.Skill
{
    public static class OccultCrescentSkills
    {
        public static IEnumerable<KeyValuePair<string, string>> GetSkills()
        {
            return
            [
                // Occult Crescent (新月岛) 技能对照表
                #region 辅助骑士
                KeyValuePair.Create("Phantom Guard", "防护"),
                KeyValuePair.Create("Pray", "祈祷"),
                KeyValuePair.Create("Occult Heal", "魔疗愈"),
                KeyValuePair.Create("Pledge", "起誓"),
                KeyValuePair.Create("Enhanced Phantom Guard", "防护效果提高"),
                KeyValuePair.Create("Enhanced Pray", "祈祷效果提高"),
                #endregion

                #region 辅助狂战士
                KeyValuePair.Create("Rage", "狂怒"),
                KeyValuePair.Create("Deadly Blow", "一击"),
                KeyValuePair.Create("Enhanced Rage", "狂怒效果提高"),
                #endregion

                #region 辅助武僧
                KeyValuePair.Create("Phantom Kick", "踢击"),
                KeyValuePair.Create("Occult Counter", "魔反击"),
                KeyValuePair.Create("Counterstance", "架招"),
                KeyValuePair.Create("Occult Chakra", "魔脉轮"),
                KeyValuePair.Create("Enhanced Phantom Kick", "踢击效果提高"),
                KeyValuePair.Create("Enhanced Phantom Kick II", "踢击效果提高II"),
                #endregion

                #region 辅助猎人
                KeyValuePair.Create("Phantom Aim", "狙击"),
                KeyValuePair.Create("Occult Featherfoot", "魔猎步"),
                KeyValuePair.Create("Occult Falcon", "魔猎鹰"),
                KeyValuePair.Create("Occult Unicorn", "魔独角兽"),
                KeyValuePair.Create("Enhanced Phantom Aim", "狙击效果提高"),
                KeyValuePair.Create("Enhanced Phantom Aim II", "狙击效果提高II"),
                #endregion

                #region 辅助武士
                KeyValuePair.Create("Shirahadori", "空手接白刃"),
                KeyValuePair.Create("Iainuki", "居合斩"),
                KeyValuePair.Create("Zeninage", "扔钱"),
                KeyValuePair.Create("Enhanced Iainuki", "居合斩效果提高"),
                #endregion

                #region 辅助吟游诗人
                KeyValuePair.Create("Offensive Aria", "攻击之歌"),
                KeyValuePair.Create("Romeo's Ballad", "爱之歌"),
                KeyValuePair.Create("Mighty March", "体力之歌"),
                KeyValuePair.Create("Hero's Rime", "英雄之歌"),
                KeyValuePair.Create("Enhanced Vocals", "歌吟效果提高"),
                #endregion

                #region 辅助风水师
                KeyValuePair.Create("Battle Bell", "战斗之铃"),
                KeyValuePair.Create("Weather", "天气"),
                KeyValuePair.Create("Ringing Respite", "休憩之铃"),
                KeyValuePair.Create("Suspend", "浮空"),
                KeyValuePair.Create("Sunbath", "日光浴"),
                KeyValuePair.Create("Cloudy Caress", "晚风凉"),
                KeyValuePair.Create("Blessed Rain", "恩惠雨"),
                KeyValuePair.Create("Misty Mirage", "空蜃景"),
                KeyValuePair.Create("Hasty Mirage", "水蜃景"),
                KeyValuePair.Create("Aetherial Gain", "以太浴"),
                KeyValuePair.Create("Enhanced Bell", "铃铛效果提高"),
                #endregion

                #region 辅助时魔法师
                KeyValuePair.Create("Occult Slowga", "魔强减速"),
                KeyValuePair.Create("Occult Dispel", "魔驱魔"),
                KeyValuePair.Create("Occult Comet", "魔彗星"),
                KeyValuePair.Create("Occult Mage Masher", "魔封魔"),
                KeyValuePair.Create("Occult Quick", "魔神速"),
                #endregion

                #region 辅助炮击士
                KeyValuePair.Create("Phantom Fire", "炮击"),
                KeyValuePair.Create("Holy Cannon", "神圣炮"),
                KeyValuePair.Create("Dark Cannon", "暗黑炮"),
                KeyValuePair.Create("Shock Cannon", "冲击炮"),
                KeyValuePair.Create("Silver Cannon", "老化炮"),
                KeyValuePair.Create("Enhanced Phantom Fire", "炮击效果提高"),
                #endregion

                #region 辅助药剂师
                KeyValuePair.Create("Occult Potion", "魔恢复药"),
                KeyValuePair.Create("Occult Ether", "魔以太药"),
                KeyValuePair.Create("Revive", "苏生"),
                KeyValuePair.Create("Occult Elixir", "魔圣灵药"),
                #endregion

                #region 辅助预言师
                KeyValuePair.Create("Predict", "预言"),
                KeyValuePair.Create("Recuperation", "痊愈宣告"),
                KeyValuePair.Create("Phantom Doom", "死亡宣告"),
                KeyValuePair.Create("Phantom Rejuvenation", "治愈宣告"),
                KeyValuePair.Create("Invulnerability", "不死宣告"),
                KeyValuePair.Create("Phantom Judgment", "神圣审判"),
                KeyValuePair.Create("Cleansing", "天崩地裂"),
                KeyValuePair.Create("Blessing", "天之恩典"),
                KeyValuePair.Create("Starfall", "陨石"),
                #endregion

                #region 辅助盗贼
                KeyValuePair.Create("Steal", "偷盗"),
                KeyValuePair.Create("Occult Sprint", "魔冲刺"),
                KeyValuePair.Create("Vigilance", "警戒"),
                KeyValuePair.Create("Trap Detection", "陷阱感知"),
                KeyValuePair.Create("Pilfer Weapon", "偷盗武器"),
                KeyValuePair.Create("Lockpicker", "开锁"),
                #endregion

                #region 辅助自由人技能
                KeyValuePair.Create("Occult Resuscitation", "魔急救"),
                KeyValuePair.Create("Occult Treasuresight", "魔寻宝"),
                #endregion
            ];
        }
    }
}
