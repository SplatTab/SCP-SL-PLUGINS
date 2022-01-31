using Exiled.API.Features;
using System;
using HarmonyLib;
using Player = Exiled.Events.Handlers.Player;

namespace Commands
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Singleton;
        public EventHandlers EventHandlers;
        private Harmony Harmony;
        public override string Author => "SplatTab";
        public override string Name => "RALogger";
        public override Version Version => new Version(1, 4, 0);
        public override Version RequiredExiledVersion => new Version(3, 0, 0);

        public override void OnEnabled()
        {
            Singleton = this;
            EventHandlers = new EventHandlers(this);
            Harmony = new Harmony("SplatTabIsKewl");
            Harmony.PatchAll();
            Player.Banning += EventHandlers.BanEvent;
            Player.Kicking += EventHandlers.KickEvent;
            Player.Dying += EventHandlers.OnDeath;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Player.Banning -= EventHandlers.BanEvent;
            Player.Kicking -= EventHandlers.KickEvent;
            Player.Dying -= EventHandlers.OnDeath;
            Harmony.UnpatchAll();
            Singleton = null;
            EventHandlers = null;
            base.OnDisabled();
        }
    }
}