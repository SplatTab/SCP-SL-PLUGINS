using Exiled.API.Features;
using System;
using System.Collections.Generic;
using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;

namespace Commands
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Singleton;
        public EventHandlers EventHandlers;
        public override string Author => "SplatTab";
        public override string Name => "RALogger";
        public override Version Version => new Version(1, 1, 0);
        public override Version RequiredExiledVersion => new Version(3, 0, 0);

        public override void OnEnabled()
        {
            Singleton = this;
            EventHandlers = new EventHandlers(this);
            Player.Banning += EventHandlers.BanEvent;
            Player.Kicking += EventHandlers.KickEvent;
            Player.ChangingRole += EventHandlers.ForceChangeClass;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Player.Banning -= EventHandlers.BanEvent;
            Player.Kicking -= EventHandlers.KickEvent;
            Player.ChangingRole -= EventHandlers.ForceChangeClass;
            Singleton = null;
            EventHandlers = null;
            base.OnDisabled();
        }
    }
}