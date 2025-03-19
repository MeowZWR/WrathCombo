﻿using System;
using System.Collections.Generic;
using WrathCombo.Combos.PvE;
using WrathCombo.Combos.PvP;
using WrathCombo.Extensions;

namespace WrathCombo.Resources.Dictionary.Chinese.Description
{
    public static class NINSkills
    {
        public static IEnumerable<KeyValuePair<string, string>> GetSkills()
        {
            return
            [
                // Generated by the String Extraction and Translation Tool  
                // Model: DeepSeek v3  
                // Temperature: 0.1  
                // Generation Time: 2025-03-13 18:45:21  
                #region NIN
                // Basic Attacks
                KeyValuePair.Create("Spinning Edge", NIN.SpinningEdge.ActionName()),
                KeyValuePair.Create("Shade Shift", NIN.ShadeShift.ActionName()),
                KeyValuePair.Create("Gust Slash", NIN.GustSlash.ActionName()),
                KeyValuePair.Create("Hide", NIN.Hide.ActionName()),
                KeyValuePair.Create("Assassinate", NIN.Assassinate.ActionName()),
                KeyValuePair.Create("Throwing Daggers", NIN.ThrowingDaggers.ActionName()),
                KeyValuePair.Create("Throwing Dagger", NIN.ThrowingDaggers.ActionName()),
                KeyValuePair.Create("Mug", NIN.Mug.ActionName()),
                KeyValuePair.Create("Death Blossom", NIN.DeathBlossom.ActionName()),
                KeyValuePair.Create("Aeolian Edge", NIN.AeolianEdge.ActionName()),
                KeyValuePair.Create("Trick Attack", NIN.TrickAttack.ActionName()),
                KeyValuePair.Create("Kassatsu", NIN.Kassatsu.ActionName()),
                KeyValuePair.Create("Armor Crush", NIN.ArmorCrush.ActionName()),
                KeyValuePair.Create("Dream Within a Dream", NIN.DreamWithinADream.ActionName()),

                // Mudras and Jutsus
                KeyValuePair.Create("Ten Chi Jin", NIN.TenChiJin.ActionName()),
                KeyValuePair.Create("TenChiJin", NIN.TenChiJin.ActionName()),
                KeyValuePair.Create("Bhavacakra", NIN.Bhavacakra.ActionName()),
                KeyValuePair.Create("Hakke Mujinsatsu", NIN.HakkeMujinsatsu.ActionName()),
                KeyValuePair.Create("Meisui", NIN.Meisui.ActionName()),
                KeyValuePair.Create("Bunshin", NIN.Bunshin.ActionName()),
                KeyValuePair.Create("Phantom Kamaitachi", NIN.PhantomKamaitachi.ActionName()),
                KeyValuePair.Create("Forked Raiju", NIN.ForkedRaiju.ActionName()),
                KeyValuePair.Create("Fleeting Raiju", NIN.FleetingRaiju.ActionName()),
                KeyValuePair.Create("Hellfrog Medium", NIN.Hellfrog.ActionName()),
                KeyValuePair.Create("Hellfrog", NIN.Hellfrog.ActionName()),
                KeyValuePair.Create("Hollow Nozuchi", NIN.HollowNozuchi.ActionName()),
                KeyValuePair.Create("Tenri Jendo", NIN.TenriJendo.ActionName()),
                KeyValuePair.Create("Tenri Jindo", NIN.TenriJendo.ActionName()),
                KeyValuePair.Create("Kunai's Bane", NIN.KunaisBane.ActionName()),
                KeyValuePair.Create("Zesho Meppo", NIN.ZeshoMeppo.ActionName()),
                KeyValuePair.Create("Dokumori", NIN.Dokumori.ActionName()),

                // Mudra Abilities
                KeyValuePair.Create("Ninjutsu", NIN.Ninjutsu.ActionName()),
                KeyValuePair.Create("Ninjitsu", NIN.Ninjutsu.ActionName()),
                KeyValuePair.Create("Rabbit", NIN.Rabbit.ActionName()),

                // Mudras for Combos
                KeyValuePair.Create("Ten Combo", NIN.TenCombo.ActionName()),
                KeyValuePair.Create("Chi Combo", NIN.ChiCombo.ActionName()),
                KeyValuePair.Create("Jin Combo", NIN.JinCombo.ActionName()),

                // Ninjutsu Abilities
                KeyValuePair.Create("Fuma Shuriken", NIN.FumaShuriken.ActionName()),
                KeyValuePair.Create("Hyoton", NIN.Hyoton.ActionName()),
                KeyValuePair.Create("Doton", NIN.Doton.ActionName()),
                KeyValuePair.Create("Katon", NIN.Katon.ActionName()),
                KeyValuePair.Create("Suiton", NIN.Suiton.ActionName()),
                KeyValuePair.Create("Raiton", NIN.Raiton.ActionName()),
                KeyValuePair.Create("Huton", NIN.Huton.ActionName()),
                KeyValuePair.Create("Goka Mekkyaku", NIN.GokaMekkyaku.ActionName()),
                KeyValuePair.Create("Hyosho Ranryu", NIN.HyoshoRanryu.ActionName()),

                // TCJ Jutsus
                KeyValuePair.Create("TCJ Fuma Shuriken Ten", NIN.TCJFumaShurikenTen.ActionName()),
                KeyValuePair.Create("TCJ Fuma Shuriken Chi", NIN.TCJFumaShurikenChi.ActionName()),
                KeyValuePair.Create("TCJ Fuma Shuriken Jin", NIN.TCJFumaShurikenJin.ActionName()),
                KeyValuePair.Create("TCJ Katon", NIN.TCJKaton.ActionName()),
                KeyValuePair.Create("TCJ Raiton", NIN.TCJRaiton.ActionName()),
                KeyValuePair.Create("TCJ Hyoton", NIN.TCJHyoton.ActionName()),
                KeyValuePair.Create("TCJ Huton", NIN.TCJHuton.ActionName()),
                KeyValuePair.Create("TCJ Doton", NIN.TCJDoton.ActionName()),
                KeyValuePair.Create("TCJ Suiton", NIN.TCJSuiton.ActionName()),
                                
                // Initial State Mudras
                KeyValuePair.Create("Ten ", NIN.Ten.ActionName()),
                KeyValuePair.Create("Chi ", NIN.Chi.ActionName()),
                KeyValuePair.Create("Jin ", NIN.Jin.ActionName()),
                #endregion

                #region PvP
                KeyValuePair.Create("Three Mudra", NINPvP.ThreeMudra.ActionName()),
                KeyValuePair.Create("Seiton Tenchu", NINPvP.SeitonTenchu.ActionName()),
                KeyValuePair.Create("SeitonTenchu", NINPvP.SeitonTenchu.ActionName()),
                #endregion
            ];
        }
    }
}
