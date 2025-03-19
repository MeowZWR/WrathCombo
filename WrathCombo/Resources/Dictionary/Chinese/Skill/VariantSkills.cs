using System;
using System.Collections.Generic;
using WrathCombo.Combos.PvE;
using WrathCombo.Combos.PvP;
using WrathCombo.Extensions;

namespace WrathCombo.Resources.Dictionary.Chinese.Description
{
    public static class VariantSkills
    {
        public static IEnumerable<KeyValuePair<string, string>> GetSkills()
        {
            return
            [
                // Manually added
                #region Variant                                
                KeyValuePair.Create("Use Variant", "使用多变"),
                KeyValuePair.Create("whenever the debuff is not present or less than 3s.", "（目标没有精神镖DOT或DOT剩余时间少于3秒）"),
                KeyValuePair.Create("when HP is below set threshold.", "（生命值低于设定的阈值）"),
                KeyValuePair.Create("on cooldown.", "（冷却即用）"),
                KeyValuePair.Create("Spirit Dart", "精神镖"),
                KeyValuePair.Create("Ultimatum", "最后通牒"),
                KeyValuePair.Create("Variant", "多变"),
                #endregion
            ];
        }
    }
}
