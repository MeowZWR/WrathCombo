using System.Collections.Generic;
using WrathCombo.AutoRotation;

namespace WrathCombo.Resources.Dictionary.Chinese
{
    /// <summary>
    /// 枚举翻译字典
    /// </summary>
    public static class EnumTranslations
    {
        /// <summary>
        /// DPS目标选择模式的中文翻译
        /// </summary>
        public static readonly Dictionary<DPSRotationMode, string> DPSRotationModeTranslations = new()
        {
            { DPSRotationMode.Manual, "手动" },
            { DPSRotationMode.Highest_Max, "最高最大血量" },
            { DPSRotationMode.Lowest_Max, "最低最大血量" },
            { DPSRotationMode.Highest_Current, "当前血量最高" },
            { DPSRotationMode.Lowest_Current, "当前血量最低" },
            { DPSRotationMode.Tank_Target, "防护职业目标" },
            { DPSRotationMode.Nearest, "最近" },
            { DPSRotationMode.Furthest, "最远" },
        };

        /// <summary>
        /// 治疗师目标选择模式的中文翻译
        /// </summary>
        public static readonly Dictionary<HealerRotationMode, string> HealerRotationModeTranslations = new()
        {
            { HealerRotationMode.Manual, "手动" },
            { HealerRotationMode.Highest_Current, "当前血量最高" },
            { HealerRotationMode.Lowest_Current, "当前血量最低" }
        };
    }
}
