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
    public static class CuffMgmt
    {
        [HarmonyPatch(typeof(DisarmCommand), nameof(DisarmCommand.Execute)), CommandHandler(typeof(RemoteAdminCommandHandler))]
        public static class Disarm
        {
            private static void Postfix(ArraySegment<string> arguments, ICommandSender sender)
            {
                if (arguments.Any())
                    if (Plugin.Singleton.Config.LogCffMgmt.Log)
                    {
                        string[] newargs;
                        List<ReferenceHub> referenceHubList = RAUtils.ProcessPlayerIdOrNamesList(arguments, 0, out newargs);
                        DiscordEmbed[] field = { new DiscordEmbed("Player Disarmed", "rich", $"{sender.LogName.Split(' ').First()} disarmed {referenceHubList[0].LoggedNameFromRefHub().Split(' ').First()} from his cuffs", 16711756, null) };
                        Timing.RunCoroutine(EventHandlers.SendMessage(field, Plugin.Singleton.Config.LogCffMgmt));
                    }
            }
        }

        [HarmonyPatch(typeof(ReleaseCommand), nameof(ReleaseCommand.Execute)), CommandHandler(typeof(RemoteAdminCommandHandler))]
        public static class Release
        {
            private static void Postfix(ArraySegment<string> arguments, ICommandSender sender)
            {
                if (arguments.Any())
                    if (Plugin.Singleton.Config.LogCffMgmt.Log)
                    {
                        string[] newargs;
                        List<ReferenceHub> referenceHubList = RAUtils.ProcessPlayerIdOrNamesList(arguments, 0, out newargs);
                        DiscordEmbed[] field = { new DiscordEmbed("Player Released", "rich", $"{sender.LogName.Split(' ').First()} released {referenceHubList[0].LoggedNameFromRefHub().Split(' ').First()} from his cuffs", 16711756, null) };
                        Timing.RunCoroutine(EventHandlers.SendMessage(field, Plugin.Singleton.Config.LogCffMgmt));
                    }
            }
        }
    }
}