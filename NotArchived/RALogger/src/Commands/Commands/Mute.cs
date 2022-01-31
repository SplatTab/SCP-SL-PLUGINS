using CommandSystem.Commands.RemoteAdmin.MutingAndIntercom;
using HarmonyLib;
using CommandSystem;
using System;
using System.Linq;
using System.Collections.Generic;
using Utils;
using MEC;

namespace Commands
{
    public static class Mute
    {
        [HarmonyPatch(typeof(MuteCommand), nameof(MuteCommand.Execute)), CommandHandler(typeof(RemoteAdminCommandHandler))]
        public static class MutePatch
        {
            private static void Postfix(ArraySegment<string> arguments, ICommandSender sender)
            {
                if (arguments.Any())
                    if (Plugin.Singleton.Config.LogPlayerPunishments.Log)
                    {
                        string[] newargs;
                        List<ReferenceHub> referenceHubList = RAUtils.ProcessPlayerIdOrNamesList(arguments, 0, out newargs);
                        DiscordEmbed[] field = { new DiscordEmbed("Server Mute", "rich", $"{sender.LogName.Split(' ').First()} muted {referenceHubList[0].LoggedNameFromRefHub().Split(' ').First()}", 16711756, null) };
                        Timing.RunCoroutine(EventHandlers.SendMessage(field, Plugin.Singleton.Config.LogPlayerPunishments));
                    }
            }

            [HarmonyPatch(typeof(IntercomMuteCommand), nameof(IntercomMuteCommand.Execute)), CommandHandler(typeof(RemoteAdminCommandHandler))]
            public static class IMutePatch
            {
                private static void Postfix(ArraySegment<string> arguments, ICommandSender sender)
                {
                    if (arguments.Any())
                        if (Plugin.Singleton.Config.LogPlayerPunishments.Log)
                        {
                            string[] newargs;
                            List<ReferenceHub> referenceHubList = RAUtils.ProcessPlayerIdOrNamesList(arguments, 0, out newargs);
                            DiscordEmbed[] field = { new DiscordEmbed("Intercom Mute", "rich", $"{sender.LogName.Split(' ').First()} intercom muted {referenceHubList[0].LoggedNameFromRefHub().Split(' ').First()}", 16711756, null) };
                            Timing.RunCoroutine(EventHandlers.SendMessage(field, Plugin.Singleton.Config.LogPlayerPunishments));
                        }
                }
            }
        }
    }
}