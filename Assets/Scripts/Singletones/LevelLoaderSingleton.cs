using System;

namespace FrontierSingletons
{
    public class LevelLoaderSingleton : Singleton<LevelLoaderSingleton>
    {
        public Action OnLevelInitialized { get; set; }

        public bool LevelReadyToRun() => true;
    }
}
