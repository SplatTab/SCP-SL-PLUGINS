using HarmonyLib;
using CommandSystem;
using System;
using System.Linq;
using MEC;
using RemoteAdmin;
using Exiled.API.Features;

namespace Commands
{
    public static class AdminChat
    {
        [HarmonyPatch(typeof(CommandProcessor), nameof(CommandProcessor.ProcessQuery))]
        public static class AdminChatPatch
        {
            private static void Postfix(string q, CommandSender sender)
            {
                PlayerCommandSender playerCommandSender1 = sender as PlayerCommandSender;
                if (q.StartsWith("@", StringComparison.Ordinal) & Plugin.Singleton.Config.LogAdminChat.Log && sender.CheckPermission(PlayerPermissions.AdminChat))
                {
                    DiscordEmbed[] field = {
                    new DiscordEmbed("Admin Chat", "rich", null, 16711756, new DiscordEmbedField[1]
                        {
                            new DiscordEmbedField("Message:", q, true),
                        })
                    };
                    Timing.RunCoroutine(EventHandlers.SendMessage(field, Plugin.Singleton.Config.LogAdminChat));
                }
            }
        }
    }
}