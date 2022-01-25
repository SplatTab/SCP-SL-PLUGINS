# RALogger or Discord Webhook Logger
Sends a message to a discord webhook that logs various in game events
<p align="center">
  <a href="https://github.com/cabaletta/baritone/releases/"><img src="https://img.shields.io/github/downloads/cabaletta/baritone/total.svg" alt="GitHub All Releases"/></a>
</p>

<p align="center">
  <a href="https://github.com/splattab/baritone/releases/"><img src="https://img.shields.io/github/release/cabaletta/baritone.svg" alt="Release"/></a>
  <a href="https://snyk.io/test/github/cabaletta/baritone?targetFile=build.gradle"><img src="https://snyk.io/test/github/cabaletta/baritone/badge.svg?targetFile=build.gradle" alt="Known Vulnerabilities"/></a>
  <a href="https://github.com/cabaletta/baritone/issues/"><img src="https://img.shields.io/badge/contributions-welcome-brightgreen.svg?style=flat" alt="Contributions welcome"/></a>
  <a href="https://github.com/cabaletta/baritone/issues/"><img src="https://img.shields.io/github/issues/cabaletta/baritone.svg" alt="Issues"/></a>
  <a href="https://github.com/cabaletta/baritone/issues?q=is%3Aissue+is%3Aclosed"><img src="https://img.shields.io/github/issues-closed/cabaletta/baritone.svg" alt="GitHub issues-closed"/></a>
  <a href="https://github.com/cabaletta/baritone/pulls/"><img src="https://img.shields.io/github/issues-pr/cabaletta/baritone.svg" alt="Pull Requests"/></a>
  <a href="https://github.com/cabaletta/baritone/graphs/contributors/"><img src="https://img.shields.io/github/contributors/cabaletta/baritone.svg" alt="GitHub contributors"/></a>
  <a href="https://github.com/cabaletta/baritone/commit/"><img src="https://img.shields.io/github/commits-since/cabaletta/baritone/v1.0.0.svg" alt="GitHub commits"/></a>
  <img src="https://img.shields.io/github/languages/code-size/cabaletta/baritone.svg" alt="Code size"/>
  <img src="https://img.shields.io/github/repo-size/cabaletta/baritone.svg" alt="GitHub repo size"/>
  <img src="https://tokei.rs/b1/github/splattab/RALogger?category=code" alt="Lines of Code"/>
</p>

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
