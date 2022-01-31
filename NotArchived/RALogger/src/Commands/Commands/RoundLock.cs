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
    public static class RoundLock
    {
        [HarmonyPatch(typeof(RoundLockCommand), nameof(RoundLockCommand.Execute)), CommandHandler(typeof(RemoteAdminCommandHandler))]
        public static class RoundLockPatch
        {
            private static void Postfix(ArraySegment<string> arguments, ICommandSender sender)
            {
                if (Plugin.Singleton.Config.LogLocking.Log)
                {
                    string[] newargs;
                    List<ReferenceHub> referenceHubList = RAUtils.ProcessPlayerIdOrNamesList(arguments, 0, out newargs);
                    DiscordEmbed[] field = { new DiscordEmbed("Round Lockdown", "rich", $"{sender.LogName.Split(' ').First()} locked the round", 16711756, null) };
                    Timing.RunCoroutine(EventHandlers.SendMessage(field, Plugin.Singleton.Config.LogLocking));
                }
            }
        }
    }
}