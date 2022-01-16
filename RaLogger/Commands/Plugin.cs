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
            Singleton = null;
            EventHandlers = null;
            Player.Banning -= EventHandlers.BanEvent;
            Player.Kicking -= EventHandlers.KickEvent;
            Player.ChangingRole -= EventHandlers.ForceChangeClass;
            base.OnDisabled();
        }
    }
}
