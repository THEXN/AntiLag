namespace AntiLag
{
    public class Config
    {
        public string 扫地机器人名字 = "扫地机器人";
        public bool 启用 = false;
        public float 清理检查间隔毫秒 = 0;
        public bool 在事件发生时禁用清理 = false;
        public int 清理地面物品数量 = 0;
        public int 清理入侵地面物品数量 = 0;
        public bool 清理同步世界 = false;
        public int 清理前等待时间 = 0;

        public static Config DefaultConfig()
        {
            Config vConf = new Config
            {
                扫地机器人名字 = "扫地机器人",
                启用 = true,
                清理检查间隔毫秒 = 3000.0f,
                在事件发生时禁用清理 = false,
                清理地面物品数量 = 20,
                清理入侵地面物品数量 = 50,
                清理同步世界 = true,
                清理前等待时间 = 1000
            };

            return vConf;
        }
    }
}
