# RALogger or Discord Webhook Logger
<img src="https://cloud.githubusercontent.com/assets/4307137/10105283/251b6868-63ae-11e5-9918-b789d9d682ec.png" width="15%"></img> <img src="https://cloud.githubusercontent.com/assets/4307137/10105290/2a183f3a-63ae-11e5-9380-50d9f6d8afd6.png" width="15%"></img> <img src="https://cloud.githubusercontent.com/assets/4307137/10105284/26aa7ad4-63ae-11e5-88b7-bc523a095c9f.png" width="15%"></img> <img src="https://cloud.githubusercontent.com/assets/4307137/10105288/28698fae-63ae-11e5-8ba7-a62360a8e8a7.png" width="15%"></img> <img src="https://cloud.githubusercontent.com/assets/4307137/10105283/251b6868-63ae-11e5-9918-b789d9d682ec.png" width="15%"></img> <img src="https://cloud.githubusercontent.com/assets/4307137/10105290/2a183f3a-63ae-11e5-9380-50d9f6d8afd6.png" width="15%"></img> 
Sends a message to a discord webhook that logs various in game events

## Features:
```
Log Kick/Bans via discord webhook
Log Force Class Changes
Log Cuffed Team Kills
Log virtually every remote admin command
Have multiple webhooks for ultimate orginization
No Dependicies

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
