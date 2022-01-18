# Basic SCP:SL Discord Intergration
Sends a message to a discord webhook whenever a player is banned, kicked, or class forced

## Features:
```
Log Kick/Bans via discord webhook
Log Force Class Changes
Log Cuffed Team Kills

All Mid Games!!!
```

## Config:
```
        [Description("The URL of the webhook")]
        WebhookURL:

        [Description("The Username of the webhook")]
        Username:

        [Description("The Image of the webhook")]
        Avatar:

        [Description("Logs kicks and bans")]
        LogKickAndBan: Default:True

        [Description("Logs kills on cuffed people Ex. Mtf Slaughtering D-Bois")]
        LogTKCuffed : Default:True

        [Description("Logs Peoples classes being forcefully changed by force class")]
        LogForceClass: Default:True
```
