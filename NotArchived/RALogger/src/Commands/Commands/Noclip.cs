using CommandSystem.Commands.RemoteAdmin;
using HarmonyLib;
using CommandSystem;
using System;
using System.Linq;
using System.Collections.Generic;
using Utils;
using MEC;
using Exiled.API.Features;

namespace Commands
{
    public static class Noclip
    {
        [HarmonyPatch(typeof(NoclipCommand), nameof(NoclipCommand.Execute)), CommandHandler(typeof(RemoteAdminCommandHandler))]
        public static class NoclipPatch
        {
            private static void Prefix(ArraySegment<string> arguments, ICommandSender sender)
            {
                if (Plugin.Singleton.Config.LogNoclip.Log)
                {
                    string[] newargs;
                    List<ReferenceHub> referenceHubList = RAUtils.ProcessPlayerIdOrNamesList(arguments, 0, out newargs);
                    Misc.CommandOperationMode mode;
                    Misc.TryCommandModeFromArgs(ref newargs, out mode);
                    foreach (ReferenceHub me in referenceHubList)
                    {
                        ServerRoles serverRoles = me.serverRoles;
                        if (!serverRoles.BypassMode && mode == Misc.CommandOperationMode.Enable)
                        {
                            DiscordEmbed[] field = { new DiscordEmbed("Noclip", "rich", $"{sender.LogName.Split(' ').First()} enabled noclip for player {me.LoggedNameFromRefHub()}", 16711756, null) };
                            Timing.RunCoroutine(EventHandlers.SendMessage(field, Plugin.Singleton.Config.LogNoclip));
                        }
                    }
                }
            }
        }
    }
}