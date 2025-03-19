﻿using System;
using System.Collections.Generic;
using WrathCombo.Combos.PvE;
using WrathCombo.Combos.PvP;
using WrathCombo.Extensions;

namespace WrathCombo.Resources.Dictionary.Chinese.Description
{
    public static class VPRSkills
    {
        public static IEnumerable<KeyValuePair<string, string>> GetSkills()
        {
            return
            [
                // Generated by the String Extraction and Translation Tool  
                // Model: DeepSeek v3  
                // Temperature: 0.1  
                // Generation Time: 2025-03-13 18:45:21  
                #region VPRPvE
                // Fangs and Maw
                KeyValuePair.Create("Reaving Fangs", VPR.ReavingFangs.ActionName()),
                KeyValuePair.Create("Reaving Maw", VPR.ReavingMaw.ActionName()),
                KeyValuePair.Create("Steel Fangs", VPR.SteelFangs.ActionName()),
                KeyValuePair.Create("Steel Maw", VPR.SteelMaw.ActionName()),

                // Coil and Snap
                KeyValuePair.Create("Vicewinder", VPR.Vicewinder.ActionName()),
                KeyValuePair.Create("Hunter's Coil", VPR.HuntersCoil.ActionName()),
                KeyValuePair.Create("Hunter's Den", VPR.HuntersDen.ActionName()),
                KeyValuePair.Create("Hunters Snap", VPR.HuntersSnap.ActionName()),
                KeyValuePair.Create("Vicepit", VPR.Vicepit.ActionName()),
                KeyValuePair.Create("Rattling Coil", VPR.RattlingCoil.ActionName()),

                // Reawakening and Fury
                KeyValuePair.Create("Reawaken", VPR.Reawaken.ActionName()),
                KeyValuePair.Create("Serpent's Ire", VPR.SerpentsIre.ActionName()),
                KeyValuePair.Create("Serpents Ire", VPR.SerpentsIre.ActionName()),
                KeyValuePair.Create("Serpent's Tail", VPR.SerpentsTail.ActionName()),
                KeyValuePair.Create("Serpents Tail", VPR.SerpentsTail.ActionName()),
                KeyValuePair.Create("Slither", VPR.Slither.ActionName()),

                // Uncoiled Attacks
                KeyValuePair.Create("Uncoiled Fury", VPR.UncoiledFury.ActionName()),
                KeyValuePair.Create("Writhing Snap", VPR.WrithingSnap.ActionName()),
                KeyValuePair.Create("Uncoiled Twinfang", VPR.UncoiledTwinfang.ActionName()),
                KeyValuePair.Create("Uncoiled Twinblood", VPR.UncoiledTwinblood.ActionName()),

                // Twin and Blood
                KeyValuePair.Create("Twinfang Bite", VPR.TwinfangBite.ActionName()),
                KeyValuePair.Create("Twinfang", VPR.Twinfang.ActionName()),
                KeyValuePair.Create("Twinblood Bite", VPR.TwinbloodBite.ActionName()),
                KeyValuePair.Create("Twinblood", VPR.Twinblood.ActionName()),

                // Sting and Bite
                KeyValuePair.Create("Swiftskin's Coil", VPR.SwiftskinsCoil.ActionName()),
                KeyValuePair.Create("Swiftskin's Den", VPR.SwiftskinsDen.ActionName()),
                KeyValuePair.Create("Swiftskin's Sting", VPR.SwiftskinsSting.ActionName()),
                KeyValuePair.Create("Swiftskin's Bite", VPR.SwiftskinsBite.ActionName()),

                // Additional Strikes and Fang
                KeyValuePair.Create("Hindsting Strike", VPR.HindstingStrike.ActionName()),
                KeyValuePair.Create("Death Rattle", VPR.DeathRattle.ActionName()),
                KeyValuePair.Create("Hunter's Sting", VPR.HuntersSting.ActionName()),
                KeyValuePair.Create("Hindsbane Fang", VPR.HindsbaneFang.ActionName()),
                KeyValuePair.Create("Flanksting Strike", VPR.FlankstingStrike.ActionName()),
                KeyValuePair.Create("Flanksbane Fang", VPR.FlanksbaneFang.ActionName()),
                KeyValuePair.Create("Hunter's Bite", VPR.HuntersBite.ActionName()),
                KeyValuePair.Create("Jagged Maw", VPR.JaggedMaw.ActionName()),
                KeyValuePair.Create("Bloodied Maw", VPR.BloodiedMaw.ActionName()),

                // Generations and Legacy
                KeyValuePair.Create("First Generation", VPR.FirstGeneration.ActionName()),
                KeyValuePair.Create("First Legacy", VPR.FirstLegacy.ActionName()),
                KeyValuePair.Create("Second Generation", VPR.SecondGeneration.ActionName()),
                KeyValuePair.Create("Second Legacy", VPR.SecondLegacy.ActionName()),
                KeyValuePair.Create("Third Generation", VPR.ThirdGeneration.ActionName()),
                KeyValuePair.Create("Third Legacy", VPR.ThirdLegacy.ActionName()),
                KeyValuePair.Create("Fourth Generation", VPR.FourthGeneration.ActionName()),
                KeyValuePair.Create("Fourth Legacy", VPR.FourthLegacy.ActionName()),

                // Ouroboros and Lash
                KeyValuePair.Create("Ouroboros", VPR.Ouroboros.ActionName()),
                KeyValuePair.Create("Last Lash", VPR.LastLash.ActionName()),
                #endregion

                #region VPRPvP
                KeyValuePair.Create("Bloodcoil", VPRPvP.Bloodcoil.ActionName()),
                KeyValuePair.Create("Backlash", VPRPvP.Backlash.ActionName()),
                KeyValuePair.Create("Snake Scales", VPRPvP.SnakeScales.ActionName()),
                #endregion
            ];
        }
    }
}
