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
    public static class GiveItem
    {
        [HarmonyPatch(typeof(GiveCommand), nameof(GiveCommand.Execute)), CommandHandler(typeof(RemoteAdminCommandHandler))]
        public static class GivePatch
        {
            private static void Postfix(ArraySegment<string> arguments, ICommandSender sender)
            {
                if (arguments.Count > 1)
                    if (Plugin.Singleton.Config.LogGiveItem.Log)
                    {
                        string[] newargs;
                        List<ReferenceHub> referenceHubList = RAUtils.ProcessPlayerIdOrNamesList(arguments, 0, out newargs);
                        int result;
                        int.TryParse(newargs[0], out result);
                        string name = Enum.GetName(typeof(ItemType), (object)result);
                        DiscordEmbed[] field = { new DiscordEmbed("Item Given", "rich", $"{sender.LogName.Split(' ').First()} gave item {name} to {referenceHubList[0].LoggedNameFromRefHub().Split(' ').First()}", 16711756, null) };
                        Timing.RunCoroutine(EventHandlers.SendMessage(field, Plugin.Singleton.Config.LogGiveItem));
                    }
            }
        }
    }
}