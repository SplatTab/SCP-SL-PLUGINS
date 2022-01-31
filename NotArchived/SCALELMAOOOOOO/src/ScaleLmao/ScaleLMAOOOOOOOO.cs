using System;
using System.Collections.Generic;
using System.Linq;
using CommandSystem;
using Exiled.API.Features;
using RemoteAdmin;
using UnityEngine;

namespace ScaleLmao
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class ScaleLMAOOOOOOOO : ICommand
    {
        public string Command => "setscale";

        public string[] Aliases => new string[] { "scale" };

        public string Description => "Set player scale";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (sender is PlayerCommandSender player && player.CheckPermission(PlayerPermissions.PlayersManagement))
            {
                var args = arguments.Array;
                if (args[1] == "all")
                {
                    for (int i = 0; i < Player.List.Count(); i++)
                    {
                        decimal scalex1 = Decimal.Parse(args[2]);
                        decimal scaley1 = Decimal.Parse(args[3]);
                        decimal scalez1 = Decimal.Parse(args[4]);
                        Player.List.ElementAt(i).Scale = new Vector3((float)scalex1, (float)scaley1, (float)scalez1);
                        response = $"Every Players scale set to {scalex1} {scaley1} {scalez1}";
                    }
                }
                else
                {
                    int id = Int32.Parse(args[1]);
                    List<Player> validplayers = Player.List.Where(x => x.Id == id).ToList();
                    Player validplayer = validplayers[0];
                    decimal scalex = Decimal.Parse(args[2]);
                    decimal scaley = Decimal.Parse(args[3]);
                    decimal scalez = Decimal.Parse(args[4]);
                    validplayer.Scale = new Vector3((float)scalex, (float)scaley, (float)scalez);
                }

                response = $"Players scale set";
                return true;
            }
            response = "Correct permission not found";
            return false;
        }
    }
}
