﻿using System;
using System.Collections.Generic;
using WrathCombo.Combos.PvE;
using WrathCombo.Combos.PvE.Content;
using WrathCombo.Combos.PvP;
using WrathCombo.Extensions;

namespace WrathCombo.Resources.Dictionary.Chinese.Skill
{
    public static class CommonSkills
    {
        public static IEnumerable<KeyValuePair<string, string>> GetSkills()
        {
            return
            [
                // Generated by the String Extraction and Translation Tool  
                // Model: DeepSeek v3  
                // Temperature: 0.1  
                // Generation Time: 2025-03-13 18:45:21  
                #region PVE
                // Tank
                KeyValuePair.Create("Shield Wall", Tank.ShieldWall.ActionName()),
                KeyValuePair.Create("Stronghold", Tank.Stronghold.ActionName()),
                KeyValuePair.Create("Rampart", Tank.Rampart.ActionName()),
                KeyValuePair.Create("Low Blow", Tank.LowBlow.ActionName()),
                KeyValuePair.Create("Provoke", Tank.Provoke.ActionName()),
                KeyValuePair.Create("Interject", Tank.Interject.ActionName()),
                KeyValuePair.Create("Reprisal", Tank.Reprisal.ActionName()),
                KeyValuePair.Create("Shirk", Tank.Shirk.ActionName()),
                // Tank Descriptions
                KeyValuePair.Create("one-button mitigation.", "一键减伤。"),
                KeyValuePair.Create("when your target's cast is interruptible.", "(目标的施法可被打断时)。"),
                KeyValuePair.Create("when your target's casting, interruptible or not.", "(目标正在施法时，无论是否可被打断。)。"),
                KeyValuePair.Create("when your target is casting, interruptible or not.", "(目标正在施法时，无论是否可被打断。)。"),

                // Healer
                KeyValuePair.Create("Healing Wind", Healer.HealingWind.ActionName()),
                KeyValuePair.Create("Breath of the Earth", Healer.BreathOfTheEarth.ActionName()),
                KeyValuePair.Create("Repose", Healer.Repose.ActionName()),
                KeyValuePair.Create("Esuna", Healer.Esuna.ActionName()),
                KeyValuePair.Create("Rescue", Healer.Rescue.ActionName()),

                // Melee
                KeyValuePair.Create("Braver", Melee.Braver.ActionName()),
                KeyValuePair.Create("Bladedance", Melee.Bladedance.ActionName()),
                KeyValuePair.Create("Leg Sweep", Melee.LegSweep.ActionName()),
                KeyValuePair.Create("Bloodbath", Melee.Bloodbath.ActionName()),
                KeyValuePair.Create("Feint", Melee.Feint.ActionName()),
                KeyValuePair.Create("True North", Melee.TrueNorth.ActionName()),

                // PhysRanged
                KeyValuePair.Create("Big Shot", PhysRanged.BigShot.ActionName()),
                KeyValuePair.Create("Desperado", PhysRanged.Desperado.ActionName()),
                KeyValuePair.Create("Leg Graze", PhysRanged.LegGraze.ActionName()),
                KeyValuePair.Create("Foot Graze", PhysRanged.FootGraze.ActionName()),
                KeyValuePair.Create("Peloton", PhysRanged.Peloton.ActionName()),
                KeyValuePair.Create("Head Graze", PhysRanged.HeadGraze.ActionName()),

                // Caster
                KeyValuePair.Create("Skyshard", Caster.Skyshard.ActionName()),
                KeyValuePair.Create("Starstorm", Caster.Starstorm.ActionName()),
                KeyValuePair.Create("Addle", Caster.Addle.ActionName()),
                KeyValuePair.Create("Sleep", Caster.Sleep.ActionName()),

                // Multi-role actions
                KeyValuePair.Create("Second Wind", "内丹"),
                KeyValuePair.Create("Lucid Dreaming", "醒梦"),
                KeyValuePair.Create("Swiftcast", "即刻咏唱"),
                KeyValuePair.Create("Arm's Length", PhysicalRole.ArmsLength.ActionName()),
                KeyValuePair.Create("Arms Length", PhysicalRole.ArmsLength.ActionName()),
                KeyValuePair.Create("Surecast", MagicRole.Surecast.ActionName()),

                // Misc
                KeyValuePair.Create("Resurrection", "复生"),
                KeyValuePair.Create("Raise", "复活"),
                KeyValuePair.Create("Solid Reason", DOL.SolidReason.ActionName()),
                KeyValuePair.Create("Ageless Words", DOL.AgelessWords.ActionName()),
                #endregion

                #region PVP
                KeyValuePair.Create("Recuperate", PvPCommon.Recuperate.ActionName()),
                KeyValuePair.Create("Purify", PvPCommon.Purify.ActionName()),
                KeyValuePair.Create("Guard", PvPCommon.Guard.ActionName()),
                #endregion
            ];
        }
    }
}
