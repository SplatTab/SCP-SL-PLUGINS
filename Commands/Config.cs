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
        public string WebhookURL { get; set; } = "https://discord.com/api/webhooks/924142404414619658/wBA-YUGKi7laGOEn5RvtdhmK63LN7GY9d03kVbW3zWPlGMD6aXnDlIiC1_eMHlTijae3";

        [Description("The Username of the webhook")]
        public string Username { get; set; } = "RALogger";

        [Description("The Image of the webhook")]
        public string Avatar { get; set; } = "https://i.ytimg.com/vi/Xmb6bvoydf8/maxresdefault.jpg";
    }
}