using Newtonsoft.Json;
using System;
using System.IO;
using Terraria;
using TerrariaApi.Server;
using TShockAPI;
using TShockAPI.Hooks;

namespace AntiLag
{
    [ApiVersion(2, 1)]
    public class AntiLag : TerrariaPlugin
    {
        internal static string filepath { get { return Path.Combine(TShock.SavePath, "Antilag.json"); } }
        public override string Author => "Jewsus + TheCursedKey + MaxTheGreat99，肝帝熙恩汉化";
        public override string Name => "AntiLag";
        public override string Description => "扫地";
        public override Version Version => new Version(1, 0, 0, 2);
        public static Config config;

        public AntiLag(Main game) : base(game)
        {
            Order = 0;
        }
        private static void ReadConfig<TConfig>(string path, TConfig defaultConfig, out TConfig config)
        {
            if (!File.Exists(path))
            {
                config = defaultConfig;
                File.WriteAllText(path, JsonConvert.SerializeObject(config, Formatting.Indented));
            }
            else
            {
                config = JsonConvert.DeserializeObject<TConfig>(File.ReadAllText(path));
            }
        }
        public override void Initialize()
        {
            ReadConfig(filepath, Config.DefaultConfig(), out config);
            Intro.PrintIntro();
            ItemClear.AntiLagTimer();
            GeneralHooks.ReloadEvent += AntiLagReload;
        }

        private void AntiLagReload(ReloadEventArgs args)
        {
            ReadConfig(filepath, Config.DefaultConfig(), out config);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                GeneralHooks.ReloadEvent -= AntiLagReload;
            }
            base.Dispose(disposing);
        }
    }
}