# AntiLag
TShock Plugin: Clears trash items.
- Originally made by [GeckGlobal](https://github.com/GeckGlobal).
- Originally updated to **TShock** `5.2` for `1.4.4.9` by `thecursedkey` on discord.
- Configs added by Maxthegreat99.

## How to Install
1. Put the .dll into the `\ServerPlugins\` folder.
2. Restart the server.

## How to Use
### Usage
Antilag checks to cleans the server of its dropped items every `x` amount of time (`x` being specified in configs). If the check detects more than `150` items on the ground it will warn in how long the items will be cleared and clear the items once te said time is done. How long the plugin waits and whether it should keep recent dropped items can be configured.

### Config Options
- `enabled` - Whether the check timer is enabled or not.
- `clearCheckIntevalMS` - The time interval at which the check is initiated in milliseconds.
- `disableHalOnEvents` - Whether or not the check is disabled during events.
- `itemAmountToKeep` - How many of the most recent items to keep when items are cleared.
- `itemAmountToKeepOnEvents` - How many of the most recent items to keep during events.
- `syncTilesOnIntervalToo` - Whether or not the plugin should also initiate `/sync` when items are cleared.
- `baseTimeUntilClearLagMS` - Base multiplier of the time to wait in milliseconds (when 1000 the wait time is `5` seconds and `2` seconds when the item cap is more than `225`.

## Default Configs
```JSON
{
  "enabled": true,
  "clearCheckIntevalMS": 3000.0,
  "disableHalOnEvents": false,
  "itemAmountToKeep": 20,
  "itemAmountToKeepOnEvents": 50,
  "syncTilesOnIntervalToo": true,
  "baseTimeUntilClearLagMS": 1000
}
```
## Forked Repository
https://github.com/GeckGlobal/AntiLag
