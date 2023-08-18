using BepInEx;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MC_SVNoAESound
{
    [BepInPlugin(pluginGuid, pluginName, pluginVersion)]
    public class Main : BaseUnityPlugin
    {
        public const string pluginGuid = "mc.starvalor.noaesound";
        public const string pluginName = "SV No Active Equipment Sound";
        public const string pluginVersion = "1.0.1";

        public void Awake()
        {
            Harmony.CreateAndPatchAll(typeof(Main));
        }

        [HarmonyPatch(typeof(BuffControl), nameof(BuffControl.Begin))]
        [HarmonyPostfix]
        private static void BuffControlBegin_Post(AudioSource ___audioS)
        {
            if (___audioS != null && ___audioS.isPlaying)
                ___audioS.Stop();
        }
    }
}
