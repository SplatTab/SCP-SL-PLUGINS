using CommandSystem.Commands.RemoteAdmin.Doors;
using HarmonyLib;
using CommandSystem;
using System;
using System.Linq;
using System.Collections.Generic;
using Utils;
using MEC;

namespace Commands
{
    public static class Lockdown
    {
        [HarmonyPatch(typeof(LockdownCommand), nameof(LockdownCommand.Execute)), CommandHandler(typeof(RemoteAdminCommandHandler))]
        public static class LockdownPatch
        {
            private static void Postfix(ArraySegment<string> arguments, ICommandSender sender)
            {
                if (Plugin.Singleton.Config.LogLocking.Log)
                {
                    string[] newargs;
                    List<ReferenceHub> referenceHubList = RAUtils.ProcessPlayerIdOrNamesList(arguments, 0, out newargs);
                    DiscordEmbed[] field = { new DiscordEmbed("Facility Lockdown", "rich", $"{sender.LogName.Split(' ').First()} locked all the doors of the facility ", 16711756, null) };
                    Timing.RunCoroutine(EventHandlers.SendMessage(field, Plugin.Singleton.Config.LogLocking));
                }
            }
        }
    }
}