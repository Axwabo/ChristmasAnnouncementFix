using HarmonyLib;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;

namespace ChristmasAnnouncementFix {

    public sealed class CafPlugin {

        public static CafPlugin Instance { get; private set; }

        public static bool EnforceChristmas => Instance.Config.EnforceChristmas;

        [PluginConfig]
        public CafConfig Config = new();

        private Harmony _harmony;

        [PluginEntryPoint("ChristmasAnnouncementFix", "1.1.0", "A plugin that fixes the Christmas announcement bug in the game.", "Axwabo")]
        public void OnEnabled() {
            Instance = this;
            _harmony = new Harmony("Axwabo.CAF");
            _harmony.PatchAll();
            Log.Info("Christmas Announcement has been fixed.");
        }

        [PluginUnload]
        public void Unload() => _harmony.UnpatchAll();

    }

}
