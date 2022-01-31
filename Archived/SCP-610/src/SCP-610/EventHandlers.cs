using System.Collections.Generic;
using System.Linq;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using UnityEngine;
using MEC;

namespace SCP_610
{
    public class EventHandlers
    {
        private readonly Plugin plugin;
        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        public void RoundStarted()
        {
            Log.Info("Round Started");
            if (Player.List.Any(x => x.Role == RoleType.Scp096))
            {
                Log.Info("096 Found");
                //if 50% chance is true then spawn scp 610
                if (Random.Range(1, 2) == 2)
                {
                    List<Player> PlayerList = Player.List.Where(x => x.Role == RoleType.Scp096).ToList();
                    Player player = PlayerList[0];
                    Methods.Spawn610(player);
                }
            }
        }
        public void OnHurting(HurtingEventArgs ev)
        {
            if (ev.Attacker.Role == RoleType.Scp0492 && ev.Attacker.CustomInfo == "<color=red>SCP-610</color>")
            {
                Timing.CallDelayed(0.8f, () =>
                {
                    Methods.Spawn610B(ev.Target, ev.Target.Position);
                });
            }
        }

        public void OnDeath(DiedEventArgs ev)
        {
            if(ev.Target.CustomInfo == "<color=red>SCP-610</color>")
            {
                ev.Target.CustomInfo = null;
            }
        }

    }
}
