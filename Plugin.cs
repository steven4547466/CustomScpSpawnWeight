using HarmonyLib;
using Interactables.Interobjects;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomScpSpawnWeight
{
    public class Plugin
    {
        public static Plugin Singleton { get; set; }

        public static Harmony Harmony { get; private set; }

        [PluginEntryPoint("Custom SCP Spawn Weights", "1.0.0", "Customize your scp spawn weights", "Steven4547466")]
        void LoadPlugin()
        {
            Singleton = this;
            //PluginHandler handler = PluginHandler.Get(this);

            Harmony = new Harmony($"scpweight-{DateTime.Now.Ticks}");
            Harmony.PatchAll();
        }

        [PluginUnload]
        void UnloadPlugin()
        {
            Harmony.UnpatchAll(Harmony.Id);
            Harmony = null;
            Singleton = null;
        }

        [PluginConfig]
        public Config Config;
    }
}
