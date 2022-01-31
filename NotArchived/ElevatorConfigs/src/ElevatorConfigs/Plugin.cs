using Exiled.API.Features;
using System;
using System.Collections.Generic;
using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;

namespace ElevatorConfigs
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Singleton;
        public EventHandlers EventHandlers;

        public override void OnEnabled()
        {
            Singleton = this;
            EventHandlers = new EventHandlers(this);
            Player.InteractingElevator += EventHandlers.ElevatorButton;
            Server.RoundEnded += EventHandlers.RoundRestart;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Singleton = null;
            EventHandlers = null;
            Player.InteractingElevator -= EventHandlers.ElevatorButton;
            Server.RoundEnded -= EventHandlers.RoundRestart;
            base.OnDisabled();
        }
    }
}
