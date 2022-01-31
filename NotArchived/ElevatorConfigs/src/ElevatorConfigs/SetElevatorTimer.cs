using System;
using CommandSystem;
using RemoteAdmin;

namespace ElevatorConfigs
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class SetElevatorTimer : ICommand
    {
        public string Command => "elevatortimer";

        public string[] Aliases => new string[] { "lifttimer" };

        public string Description => "Set elevator wait timer in seconds for that round";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (sender is PlayerCommandSender player && player.CheckPermission(PlayerPermissions.FacilityManagement))
            {
                var args = arguments.Array;
                float result;

                if (float.TryParse(args[1], out result) && args[1] != "")
                    EventHandlers.ElevatorTimer = result;
                else
                {
                    response = "Please enter valid number";
                    return false;
                }
                response = $"Elevator timer changed to {result} for this round";
                return true;
            }
            response = "Correct permission not found";
            return false;
        }
    }
}