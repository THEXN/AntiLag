# AntiLag
TShock插件：清除垃圾物品。
- 最初由[GeckGlobal](https://github.com/GeckGlobal)制作。
- 最初由discord上的`thecursedkey`更新到**TShock** `5.2`版本，适用于`1.4.4.9`版本。
- 配置由Maxthegreat99添加。
- 肝帝熙恩汉化优化一点点。

## 安装方式
1. 将.dll文件放入`\ServerPlugins\`文件夹中。
2. 重新启动服务器。

## 如何使用
### 使用方法
Antilag每隔`x`时间（在配置中指定）检查并清理服务器上掉落的物品。如果检查到地面上有超过`150`个物品，它将警告清理物品的时间，并在达到指定时间后清理这些物品。插件等待的时间以及是否应保留最近掉落的物品可以配置。

### 配置选项
- `enabled` - 是否启用检查计时器。
- `clearCheckIntevalMS` - 启动检查的时间间隔，以毫秒为单位。
- `disableHalOnEvents` - 是否在事件期间禁用检查。
- `itemAmountToKeep` - 清除物品时要保留的最近物品数量。
- `itemAmountToKeepOnEvents` - 在事件期间要保留的最近物品数量。
- `syncTilesOnIntervalToo` - 是否在清除物品时也应发起`/sync`命令。
- `baseTimeUntilClearLagMS` - 等待时间的基本倍增器，以毫秒为单位（当为1000时，等待时间为`5`秒，当物品上限超过`225`时，等待时间为`2`秒）。

## 默认配置
```JSON
{
                扫地机器人名字 = "扫地机器人",
                启用 = true,
                清理检查间隔毫秒 = 3000.0f,
                在事件发生时禁用清理 = false,
                清理地面物品数量 = 20,
                清理入侵地面物品数量 = 50,
                清理同步世界 = true,
                清理前等待时间 = 1000
}
```
## 分支存储库
https://github.com/GeckGlobal/AntiLag
