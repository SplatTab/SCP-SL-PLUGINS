using Exiled.Events.EventArgs;
using Exiled.API.Features;
using Exiled.API.Enums;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace Commands
{
    public class EventHandlers
    {
        private readonly Plugin plugin;
        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        public void BanEvent(BanningEventArgs ev)
        {
            if (plugin.Config.LogKickAndBan)
                SendMessage($"***{ev.Issuer.Nickname}*** banned **{ev.Target.Nickname}** for __**{ev.Duration}**__ Reason:_{ev.Reason}_", "Player Banned", "9109504");
        }

        public void KickEvent(KickingEventArgs ev)
        {
            if (plugin.Config.LogKickAndBan)
                SendMessage($"***{ev.Issuer.Nickname}*** kicked **{ev.Target.Nickname}** Reason:_{ev.Reason}_", "Player Kicked!", "13771309");
        }

        public void ForceChangeClass(ChangingRoleEventArgs ev)
        {
            if (ev.Reason == SpawnReason.ForceClass & plugin.Config.LogForceClass)
                SendMessage($"{ev.Player.Nickname}'s class was forced to {ev.NewRole}", "Class Forced!", "16760576");
        }

        public void OnDeath(DiedEventArgs ev)
        {
            if (ev.Target.IsNTF & ev.Killer.IsCHI ^ ev.Target.IsCHI & ev.Killer.IsNTF && ev.Target.IsCuffed & plugin.Config.LogTKCuffed)
                SendMessage($"{ev.Target.Nickname} was killed while cuffed by {ev.Killer} on team {ev.Killer.Team}", "Cuffed Teamkill!", "16711756");
        }

        public void SendMessage(string msgSend, string title, string color)
        {
            WebRequest dWebClient = WebRequest.CreateHttp(plugin.Config.WebhookURL);
            dWebClient.ContentType = "application/json";
            dWebClient.Method = "POST";

            using (var SW = new StreamWriter(dWebClient.GetRequestStream()))
            {
                string embeds = JsonConvert.SerializeObject(new
                {
                    username = plugin.Config.Username,
                    avatar_url = plugin.Config.Avatar,
                    embeds = new[]
                    {
                        new
                        {
                            description = msgSend,
                            title = title,
                            color = color
                        }
                    }
                }, Formatting.Indented);
                SW.Write(embeds);
                SW.Close();

                Log.Info(dWebClient.GetResponse().ToString());
            }
        }
    }
}
