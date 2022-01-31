using CommandSystem.Commands.RemoteAdmin;
using HarmonyLib;
using CommandSystem;
using System;
using System.Linq;
using System.Collections.Generic;
using Utils;
using MEC;

namespace Commands
{
    public static class Goto
    {
        [HarmonyPatch(typeof(GotoCommand), nameof(GotoCommand.Execute)), CommandHandler(typeof(RemoteAdminCommandHandler))]
        public static class GotoPatch
        {
            private static void Postfix(ArraySegment<string> arguments, ICommandSender sender)
            {
                if (arguments.Any())
                    if (Plugin.Singleton.Config.LogTeleportion.Log)
                    {
                        string[] newargs;
                        List<ReferenceHub> referenceHubList = RAUtils.ProcessPlayerIdOrNamesList(arguments, 0, out newargs);
                        DiscordEmbed[] field = { new DiscordEmbed("GoTo Teleportion", "rich", $"{sender.LogName.Split(' ').First()} teleported to {referenceHubList[0].LoggedNameFromRefHub().Split(' ').First()}", 16711756, null) };
                        Timing.RunCoroutine(EventHandlers.SendMessage(field, Plugin.Singleton.Config.LogTeleportion));
                    }
            }
        }
    }
}