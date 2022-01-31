using System;
using System.Collections.Generic;
using Exiled.API.Features;
using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;

namespace Medkit_Antidote
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Singleton;
        public EventHandlers EventHandlers;

        public override void OnEnabled()
        {
            Singleton = this;
            EventHandlers = new EventHandlers(this);
            Player.ItemUsed += EventHandlers.OnMedicalItem;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Singleton = null;
            Player.ItemUsed -= EventHandlers.OnMedicalItem;
            EventHandlers = null;
            base.OnDisabled();
        }
    }
}