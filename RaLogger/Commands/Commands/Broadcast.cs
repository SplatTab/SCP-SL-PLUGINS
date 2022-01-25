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
    public static class Broadcast
    {
        [HarmonyPatch(typeof(BroadcastCommand), nameof(BroadcastCommand.Execute)), CommandHandler(typeof(RemoteAdminCommandHandler))]
        public static class BroadcastPatch
        {
            private static void Postfix(ArraySegment<string> arguments, ICommandSender sender)
            {
                if (arguments.Count > 1)
                    if (Plugin.Singleton.Config.LogBroadcast.Log)
                    {
                        string[] newargs;
                        List<ReferenceHub> referenceHubList = RAUtils.ProcessPlayerIdOrNamesList(arguments, 0, out newargs);
                        string data = RAUtils.FormatArguments(arguments, 1);
                        DiscordEmbed[] field = { new DiscordEmbed("Broadcasted", "rich", $"{sender.LogName.Split(' ').First()} broadcasted \u0022{data}\u0022 to all players for duration {arguments.At<string>(0)}", 16711756, null) };
                        Timing.RunCoroutine(EventHandlers.SendMessage(field, Plugin.Singleton.Config.LogBroadcast));
                    }
            }
        }

        [HarmonyPatch(typeof(BroadcastMonoCommand), nameof(BroadcastMonoCommand.Execute)), CommandHandler(typeof(RemoteAdminCommandHandler))]
        public static class BroadcastMONOPatch
        {
            private static void Postfix(ArraySegment<string> arguments, ICommandSender sender)
            {
                if (arguments.Count > 1)
                    if (Plugin.Singleton.Config.LogBroadcast.Log)
                    {
                        string[] newargs;
                        List<ReferenceHub> referenceHubList = RAUtils.ProcessPlayerIdOrNamesList(arguments, 0, out newargs);
                        string data = RAUtils.FormatArguments(arguments, 1);
                        DiscordEmbed[] field = { new DiscordEmbed("Broadcasted", "rich", $"{sender.LogName.Split(' ').First()} broadcasted \u0022{data}\u0022 to all players for duration {arguments.At<string>(0)} type:MONO", 16711756, null) };
                        Timing.RunCoroutine(EventHandlers.SendMessage(field, Plugin.Singleton.Config.LogBroadcast));
                    }
            }
        }

        [HarmonyPatch(typeof(PlayerBroadcastCommand), nameof(PlayerBroadcastCommand.Execute)), CommandHandler(typeof(RemoteAdminCommandHandler))]
        public static class PlayerBroadcastPatch
        {
            private static void Postfix(ArraySegment<string> arguments, ICommandSender sender)
            {
                if (arguments.Count > 2)
                    if (Plugin.Singleton.Config.LogBroadcast.Log)
                    {
                        string[] newargs;
                        List<ReferenceHub> referenceHubList = RAUtils.ProcessPlayerIdOrNamesList(arguments, 0, out newargs);
                        string data = RAUtils.FormatArguments(arguments, 2);
                        DiscordEmbed[] field = { new DiscordEmbed("Broadcasted", "rich", $"{sender.LogName.Split(' ').First()} broadcasted \u0022{data}\u0022 to {referenceHubList[0].LoggedNameFromRefHub().Split(' ').First()} for duration {arguments.At<string>(1)}", 16711756, null) };
                        Timing.RunCoroutine(EventHandlers.SendMessage(field, Plugin.Singleton.Config.LogBroadcast));
                    }
            }
        }
    }
}