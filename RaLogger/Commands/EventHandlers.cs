using Exiled.Events.EventArgs;
using Exiled.API.Features;
using System.Net;
using Utf8Json;
using System.IO;
using Commands.Configs;
using System.Collections.Generic;
using MEC;

namespace Commands
{
    public class EventHandlers
    {
        private readonly Plugin plugin;
        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        public void BanEvent(BanningEventArgs ev)
        {
            if (plugin.Config.LogPlayerPunishments.Log)
            {
                DiscordEmbed[] field = {
                    new DiscordEmbed("Player Kicked", "rich", $"{ev.Issuer.Nickname} banned {ev.Target.Nickname} for {ev.Duration}", 16711756, new DiscordEmbedField[1]
                    {
                        new DiscordEmbedField("Reason:", ev.Reason, true),
                    })
                };
                Timing.RunCoroutine(SendMessage(field, plugin.Config.LogPlayerPunishments));
            }
        }

        public void KickEvent(KickingEventArgs ev)
        {
            if (plugin.Config.LogPlayerPunishments.Log)
            {
                DiscordEmbed[] field = {
                    new DiscordEmbed("Player Kicked", "rich", $"{ev.Issuer.Nickname} kicked {ev.Target.Nickname}", 16711756, new DiscordEmbedField[1]
                    {
                        new DiscordEmbedField("Reason:", ev.Reason, true),
                    })
                };
                Timing.RunCoroutine(SendMessage(field, plugin.Config.LogPlayerPunishments));
            }
        }

        public void OnDeath(DyingEventArgs ev)
        {
            if (ev.Target == null || ev.Killer == null || !ev.Target.IsCuffed || !plugin.Config.LogTKCuffed.Log) return;
            if ((IsNTFSide(ev.Target) & IsChaosSide(ev.Killer)) || (IsChaosSide(ev.Target) & IsNTFSide(ev.Killer)))
            {
                DiscordEmbed[] field = {
                    new DiscordEmbed("CuffedTk", "rich", $"A {ev.Target.Role} has been killed while cuffed by a {ev.Killer.Role}", 16711756, new DiscordEmbedField[4]
                    {
                        new DiscordEmbedField("Victim Name", ev.Target.Nickname, false),
                        new DiscordEmbedField("Victim Id", ev.Target.UserId, false),
                        new DiscordEmbedField("Killer Name", ev.Killer.Nickname, false),
                        new DiscordEmbedField("Killer Id", ev.Killer.UserId, false),
                    })
                };
                Timing.RunCoroutine(SendMessage(field, plugin.Config.LogTKCuffed));
            }
        }

        public static IEnumerator<float> SendMessage(DiscordEmbed[] msgField, WebHook hook)
        {
            yield return Timing.WaitForSeconds(Plugin.Singleton.Config.Delay);
            WebRequest dWebClient = WebRequest.CreateHttp(hook.WebhookURL);
            dWebClient.ContentType = "application/json";
            dWebClient.Method = "POST";

            using (var SW = new StreamWriter(dWebClient.GetRequestStream()))
            {
                string embeds = JsonSerializer.ToJsonString<DiscordWebhook>(new DiscordWebhook(hook.RoleToPing, hook.Username, hook.Avatar, false, msgField));
                SW.Write(embeds);
                SW.Close();
                if (Plugin.Singleton.Config.responselog)
                    Log.Info(dWebClient.GetResponse().ToString());
                else
                    dWebClient.GetResponse();
            }
        }

        public bool IsChaosSide(Player player)
        {
            if (player.IsCHI || player.Role == RoleType.ClassD)
                return true;
            else
                return false;
        }

        public bool IsNTFSide(Player player)
        {
            if (player.IsNTF || player.Role == RoleType.Scientist)
                return true;
            else
                return false;
        }
    }
}
