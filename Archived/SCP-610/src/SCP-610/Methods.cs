using System.Linq;
using Exiled.API.Features;
using UnityEngine;
using MEC;

namespace SCP_610
{
    public class Methods
    {
        public static void Spawn610(Player player)
        {
            Timing.CallDelayed(1f, () =>
            {
                player.Role = RoleType.Scp0492;
                player.CustomInfo = "<color=red>SCP-610</color>";
                player.Health = player.MaxHealth = 600;
                player.Broadcast(5, "<color=red>You are SCP-610-A touch players to infect them</color>", Broadcast.BroadcastFlags.Normal, true);
                Timing.CallDelayed(0.5f, () =>
                {
                    player.Position = Map.Rooms.FirstOrDefault(r => r.Type == Exiled.API.Enums.RoomType.HczNuke).Position + Vector3.up * 1.5f;
                });
            });
        }

        public static void Spawn610B(Player player, Vector3 spawnpos)
        {
            Timing.CallDelayed(1f, () =>
            {
                player.Role = RoleType.Scp0492;
                player.CustomInfo = "<color=red>SCP-610</color>";
                player.Health = player.MaxHealth = 100;
                player.ArtificialHealthDecay = 0;
                player.ArtificialHealth = player.ArtificialHealth = 50;
                player.Broadcast(5, "<color=red>You are SCP-610-B touch players to infect them</color>", Broadcast.BroadcastFlags.Normal, true);
                Timing.CallDelayed(0.5f, () =>
                {
                    player.Position = spawnpos + Vector3.up * 1.5f;
                });
            });
        }
    }
}
