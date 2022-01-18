using Exiled.API.Enums;
using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace Commands
{
    public class Config : IConfig
    {
        [Description("Whether or not the plugin is enabled on this server.")]
        public bool IsEnabled { get; set; } = true;

        [Description("The URL of the webhook")]
        public string WebhookURL { get; set; } = "https://discord.com/api/webhooks/932098593068810250/YpCEGWZf_GBzOk3EVTYure6NK-kfzUurjgi5JRadbyTZjqAPoTJzY4p8iKmpmxD241EK";

        [Description("The Username of the webhook")]
        public string Username { get; set; } = "RALogger";

        [Description("The Image of the webhook")]
        public string Avatar { get; set; } = "https://i.ytimg.com/vi/Xmb6bvoydf8/maxresdefault.jpg";

        [Description("Logs kicks and bans")]
        public bool LogKickAndBan { get; set; } = true;

        [Description("Logs kills on cuffed people Ex. Mtf Slaughtering D-Bois")]
        public bool LogTKCuffed { get; set; } = true;

        [Description("Logs Peoples classes being forcefully changed by force class")]
        public bool LogForceClass { get; set; } = true;
    }
}