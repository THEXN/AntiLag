using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Timers;
using Terraria;
using TShockAPI;

namespace AntiLag
{
    internal class ItemClear
    {
        public static bool inprogress = false;
        public static DateTime LastCheck = DateTime.UtcNow;
        public static System.Timers.Timer Timer = new System.Timers.Timer();
        private static string tag = TShock.Utils.ColorTag($"{AntiLag.config.扫地机器人名字}:", Color.Orange);

        internal static void AntiLagTimer()
        {
            Timer.Interval = AntiLag.config.清理检查间隔毫秒;
            Timer.Enabled = AntiLag.config.启用;
            Timer.Elapsed += new ElapsedEventHandler(TimerElapsed);
        }

        internal static void TimerElapsed(object sender, ElapsedEventArgs args)
        {
            bool isEvent = (Main.invasionType == 0) ? false : true;

            if (isEvent && AntiLag.config.在事件发生时禁用清理)
                return;
            IDictionary<int,Item> activeItems = new Dictionary<int,Item>();
            
            if (!inprogress)
            {
                int num = 0;
                int num2;
                for (int i = 0; i < 400; i = num2 + 1)
                {
                    bool active = Main.item[i].active;
                    if (active)
                    {
                        activeItems.Add(i,Main.item[i]);
                        num2 = num;
                        num = num2 + 1;
                    }
                    num2 = i;
                }
                if (num > 150)
                {
                    int num3 = 5;
                    inprogress = true;
                    if (num > 275)
                    {
                        num3 = 2;
                    }
                    else
                    {
                        if (num > 225)
                        {
                            num3 = 5;
                        }
                    }
                    
                    if( (AntiLag.config.清理入侵地面物品数量 != 0 && isEvent) 
                      || (AntiLag.config.清理地面物品数量 != 0 && !isEvent) )
                        activeItems = activeItems.OrderBy(i =>-i.Value.timeSinceItemSpawned).ToDictionary(i => i.Key, i => i.Value);

                    TShock.Utils.Broadcast(string.Format("{0} 发现 {1} 个垃圾物品。 将在 {2} 秒内移除", tag,
                                           num - (isEvent ? AntiLag.config.清理入侵地面物品数量 : AntiLag.config.清理地面物品数量), num3), Color.Silver);
                    Thread.Sleep(AntiLag.config.清理前等待时间 * num3);
                    
                    int i = 0;
                    foreach (KeyValuePair<int, Item> kvp in activeItems)
                    {
                        bool active2 = kvp.Value.active;

                        if (isEvent 
                            && AntiLag.config.清理入侵地面物品数量 != 0
                            && i > activeItems.Count - AntiLag.config.清理入侵地面物品数量)
                            break;

                        if (!isEvent
                           && AntiLag.config.清理地面物品数量 != 0
                           && i > activeItems.Count - AntiLag.config.清理地面物品数量)
                            break;

                        if (active2)
                        {

                            Main.item[kvp.Key].active = false;
                            
                            TSPlayer.All.SendData(PacketTypes.UpdateItemDrop, "", kvp.Key, 0f, 0f, 0f, 0);
                        }
                        
                        i++;
                    }
                    
                    if(AntiLag.config.清理同步世界)
                        Commands.HandleCommand(TSPlayer.Server, "/sync");

                    TShock.Utils.Broadcast(string.Format("{0} 所有垃圾物品已清理并同步到服务器", tag), Color.Silver);
                    inprogress = false;
                }
            }
        }
    }
}