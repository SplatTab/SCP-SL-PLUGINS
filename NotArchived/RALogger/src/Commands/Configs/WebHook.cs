namespace Commands.Configs
{
    public struct WebHook
    {
        public WebHook(bool log, string webhookURL, string username, string avatar, string roletoping)
        {
            Avatar = avatar;
            Username = username;
            WebhookURL = webhookURL;
            Log = log;
            RoleToPing = roletoping;
        }
        public bool Log { get; set; }
        public string WebhookURL { get; set; }
        public string Username { get; set; }
        public string Avatar { get; set; }
        public string RoleToPing { get; set; }
    }
}
