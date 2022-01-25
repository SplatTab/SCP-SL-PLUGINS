using Exiled.API.Interfaces;
using System.ComponentModel;
using Commands.Configs;
using System.Collections.Generic;

namespace Commands
{
    public class Config : IConfig
    {
        [Description("Whether or not the plugin is enabled on this server.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Logs kicks, bans, and mutes")]
        public WebHook LogPlayerPunishments { get; set; } = new WebHook(true, "https://discord.com/api/webhooks/933459069996515358/GV7PRgYBcgARXNxScfiC84M4wP1YI6TQFCMokwEW8rbTNVCaScmNcv2q7roYmhNeSS7-", "RALogger", "https://i.ytimg.com/vi/Xmb6bvoydf8/maxresdefault.jpg", "");

        [Description("Logs kills on cuffed people Ex. Mtf Slaughtering D-Bois")]
        public WebHook LogTKCuffed { get; set; } = new WebHook(true, "https://discord.com/api/webhooks/933459069996515358/GV7PRgYBcgARXNxScfiC84M4wP1YI6TQFCMokwEW8rbTNVCaScmNcv2q7roYmhNeSS7-", "RALogger", "https://i.ytimg.com/vi/Xmb6bvoydf8/maxresdefault.jpg", "");

        [Description("Logs Peoples classes being forcefully changed via force class cmd")]
        public WebHook LogForceClass { get; set; }

        [Description("Logs Peoples being teleported via bring and goto cmds")]
        public WebHook LogTeleportion { get; set; }
        
        [Description("Logs players going godmode via godmode cmd")]
        public WebHook LogGodmode { get; set; }

        [Description("Logs players activating noclip via noclip cmd")]
        public WebHook LogNoclip { get; set; }

        [Description("Logs the round being locked and all doors being locked via lockdown and roundlock cmds")]
        public WebHook LogLocking { get; set; }

        [Description("Logs players being given a item via give item cmd")]
        public WebHook LogGiveItem { get; set; }

        [Description("Logs all broadcast being sent via broadcast pbc cmds etc")]
        public WebHook LogBroadcast { get; set; }

        [Description("Logs players being cuffed and uncuffed via disarm and release cmds")]
        public WebHook LogCffMgmt { get; set; }

        [Description("Logs admins talking via admin chat")]
        public WebHook LogAdminChat { get; set; }

        [Description("How long it takes to log to discord after the thing happens increase this if you are experiencing any errors or things not getting logged due to discord denying the request")]
        public int Delay { get; set; } = 1;

        [Description("logs the response of the webhook to console")]
        public bool responselog { get; set; } = false;
    }
}