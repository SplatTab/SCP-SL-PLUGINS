# Basic SCP:SL Discord Intergration
Sends a message to a discord webhook that logs various in game events
Depends on newtonsoft.json so make sure you have it added to you're dependicies folder get it from releases or at https://github.com/JamesNK/Newtonsoft.Json/releases

## Features:
```
Log Kick/Bans via discord webhook
Log Force Class Changes
Log Cuffed Team Kills
Log virtually every remote admin command
Have multiple webhooks for ultimate orginization

All Mid Game and via discord!!!
```

## Config:
```
  log_blah_blah:
    log: true (turn to false to not log this thing)
    webhook_u_r_l: https://discord.com/api/webhooks/696969699696969/blah893u48924blah (the full url of the webhook)
    username: RALogger (name of the webhook)
    avatar: https://i.ytimg.com/vi/Xmb6bvoydf8/maxresdefault.jpg (profile picture of the webhook)
    role_to_ping: <@&933425790274662453> (a role to ping left empty to not ping a role)
    
    delay: 1 (the time it takes to send the webhook 1 should be fine this delay is set in place so discord doesn't deny the webhook request)
    
    response: false (if set to true the response of a webhook request will be posted to console)
```
