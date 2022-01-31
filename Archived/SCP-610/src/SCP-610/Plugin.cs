using System;
using System.Collections.Generic;
using Exiled.API.Features;
using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;

namespace SCP_610
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Singleton;
        public EventHandlers EventHandlers;

        public override void OnEnabled()
        {
            Singleton = this;
            EventHandlers = new EventHandlers(this);
            Server.RoundStarted += EventHandlers.RoundStarted;
            Player.Hurting += EventHandlers.OnHurting;
            Player.Died += EventHandlers.OnDeath;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Singleton = null;
            Server.RoundStarted -= EventHandlers.RoundStarted;
            Player.Hurting -= EventHandlers.OnHurting;
            Player.Died -= EventHandlers.OnDeath;
            EventHandlers = null;
            base.OnDisabled();
        }
    }
}