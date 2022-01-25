using CommandSystem.Commands.RemoteAdmin;
using HarmonyLib;
using CommandSystem;
using System;
using System.Collections.Generic;
using Utils;
using RemoteAdmin;
using System.Linq;
using MEC;

namespace Commands
{
    public static class ForceClass
    {
        [HarmonyPatch(typeof(ForceClassCommand), nameof(ForceClassCommand.Execute)), CommandHandler(typeof(RemoteAdminCommandHandler))]
        public static class ForceClassPatch
        {
            private static void Postfix(ArraySegment<string> arguments, ICommandSender sender)
            {
                if(arguments.Count > 1)
                if (Plugin.Singleton.Config.LogForceClass.Log)
                {
                    string[] newargs;
                    List<ReferenceHub> referenceHubList = RAUtils.ProcessPlayerIdOrNamesList(arguments, 0, out newargs);
                    int result;
                    if (!int.TryParse(newargs[0], out result) || result < 0 || result >= QueryProcessor.LocalCCM.Classes.Length)
                    {
                        Role role = ((IEnumerable<Role>)QueryProcessor.LocalCCM.Classes).SingleOrDefault<Role>((Func<Role, bool>)(c => c.fullName.Replace(" ", string.Empty).ToLower() == newargs[0].ToLower()));
                        if (role != null)
                        {
                            result = (int)role.roleId;
                        }
                    }

                    foreach (ReferenceHub me in referenceHubList)
                    {
                        if (me != null)
                        {
                            DiscordEmbed[] field = { new DiscordEmbed("Role Forced", "rich", $"{sender.LogName.Split(' ').First()} changed player's class {me.LoggedNameFromRefHub().Split(' ').First()} to {QueryProcessor.LocalCCM.Classes.SafeGet(result).fullName}", 16711756, null) };
                            Timing.RunCoroutine(EventHandlers.SendMessage(field, Plugin.Singleton.Config.LogForceClass));
                        }
                    }
                }
            }
        }
    }
}