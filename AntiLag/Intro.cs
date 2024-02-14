using System;

namespace AntiLag
{
    internal class Intro
    {
        public static void PrintIntro()
        {
            ConsoleColor originalBackColour;

            originalBackColour = Console.BackgroundColor;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" 反卡 Minitaka 已启动 - GeckGlobal 更新，肝帝熙恩汉化.");
            Console.BackgroundColor = originalBackColour;
        }
    }
}