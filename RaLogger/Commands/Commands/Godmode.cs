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
    public static class Godmode
    {
        [HarmonyPatch(typeof(GodCommand), nameof(GodCommand.Execute)), CommandHandler(typeof(RemoteAdminCommandHandler))]
        public static class GodmodePatch
        {
            private static void Postfix(ArraySegment<string> arguments, ICommandSender sender)
            {
                if (arguments.Any())
                    if (Plugin.Singleton.Config.LogGodmode.Log)
                    {
                        string[] newargs;
                        List<ReferenceHub> referenceHubList = RAUtils.ProcessPlayerIdOrNamesList(arguments, 0, out newargs);
                        Misc.CommandOperationMode mode;
                        Misc.TryCommandModeFromArgs(ref newargs, out mode);

                        foreach (ReferenceHub me in referenceHubList)
                        {
                            CharacterClassManager characterClassManager = me.characterClassManager;
                            if (characterClassManager.GodMode && mode == Misc.CommandOperationMode.Enable)
                            {
                                DiscordEmbed[] field = { new DiscordEmbed("Godmode Enabled", "rich", $"{sender.LogName.Split(' ').First()} enabled godmode for {me.LoggedNameFromRefHub().Split(' ').First()}", 16711756, null) };
                                Timing.RunCoroutine(EventHandlers.SendMessage(field, Plugin.Singleton.Config.LogGodmode));
                            } else if (mode == Misc.CommandOperationMode.Toggle)
                            {
                                DiscordEmbed[] field = { new DiscordEmbed("Godmode Enabled", "rich", $"{sender.LogName.Split(' ').First()} enabled godmode for {sender.LogName.Split(' ').First()}", 16711756, null) };
                                Timing.RunCoroutine(EventHandlers.SendMessage(field, Plugin.Singleton.Config.LogGodmode));
                            }
                        }
                    }
            }
        }
    }
}