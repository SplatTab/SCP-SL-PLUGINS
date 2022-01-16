using Exiled.Events.EventArgs;
using Exiled.API.Features;
using MEC;
using System.Collections;
using System.Collections.Generic;
using Exiled.API.Enums;

namespace Commands
{
    public class EventHandlers : Plugin<Config>
    {
        private readonly Plugin plugin;
        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        public void BanEvent(BanningEventArgs ev)
        {
            Timing.RunCoroutine(HookSend($"***{ev.Issuer.Nickname}*** banned **{ev.Target.Nickname}** for __**{ev.Duration}**__ Reason:_{ev.Reason}_"));
        }

        public void KickEvent(KickingEventArgs ev)
        {
            Timing.RunCoroutine(HookSend($"***{ev.Issuer.Nickname}*** kicked **{ev.Target.Nickname}** Reason:_{ev.Reason}_"));
        }

        public void ForceChangeClass(ChangingRoleEventArgs ev)
        {
            if (ev.Reason == SpawnReason.ForceClass)
                Timing.RunCoroutine(HookSend($"{ev.Player.Nickname}'s class was forced to {ev.NewRole}"));
        }

        public IEnumerator<float> HookSend(string msg)
        {
            using (dWebHook dcWeb = new dWebHook())
            {
                dcWeb.ProfilePicture = Config.Avatar;
                dcWeb.UserName = Config.Username;
                dcWeb.WebHook = Config.WebhookURL;
                dcWeb.SendMessage(msg);
                yield return Timing.WaitForSeconds(1);
                dcWeb.Dispose();
            }
        }
    }
}
