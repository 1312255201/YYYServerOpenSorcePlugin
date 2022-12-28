using Exiled.API.Features;
using Exiled.Events.Handlers;
using HarmonyLib;
using InventorySystem.Items.Usables;
using System;
using YYYServerOpenSorcePlugin.Events.Function;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace YYYServerOpenSorcePlugin
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance;
        private Harmony hInstance;
        
        public override string Author { get; } = "1312255201";
        public override string Name { get; } = "YYYServerOpenSorcePlugin";
        public override string Prefix { get; } = "YOSP"; 
        public override System.Version Version { get; } = new Version(0,0,1); 
        public override System.Version RequiredExiledVersion { get; } = new Version(6,0,0); 
        public int PatchesCounter { get; private set; }
        public Harmony Harmony { get; private set; }

        public override void OnEnabled()
        {
            Instance = this;
            RegisterEvents();
            Log.Info("Exiled6.0插件读取完毕");
        }

        private void RegisterEvents()
        {
            Log.Info("你好正在看代码的这位兄弟，本代码为开源项目，开源地址https://github.com/1312255201/YYYServerOpenSorcePlugin");
            Log.Info("希望你可以通过这个插件学到一些技术");
            if(Config.Enable_cleaneraddon)
            {
                cleaneraddon.Reg();
            }
            try
            {
                hInstance = new Harmony($"com.gugufish.yyyserver-{DateTime.UtcNow.Ticks}");
                hInstance.PatchAll();
            }
            catch (Exception e)
            {
                Log.Error($"Patching failed!, " + e);
            }
        }


        public override void OnDisabled()
        {
            UnregisterEvents();
        }

        private void UnregisterEvents()
        {
            hInstance.UnpatchAll();
            hInstance = null;
        }
    }
}
