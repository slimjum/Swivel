using Swivel.Internals;
using SwivelLIb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swivel.Swappers
{
    public static class Swapper
    {
        public static bool IsLoaded = false;

        public static List<Feature> SwapperList = new List<Feature>();

        public static SwapperConfig Config = LibGlobal.SwapperConfig;

        public static SwapperVideo? SwapperVideo = null;

        public static SwapperAudioEffect SwapperAudioEffects = null;

        public static SwapperMusic SwapperMusic = null;

        public static void CleanUp()
        {
            IsLoaded = false;

            foreach (var feature in SwapperList)
            {
                feature.CleanUp();
            }
        }

        public static void Setup()
        {
            if (IsLoaded)
                return;

            IsLoaded = true;
            DirCheck();

            if (Config != null)
                Config.Update();

            if (Config.ActiveSwappers.HasFlag(SwapType.Music))
                SwapperList.Add(SwapperMusic = new SwapperMusic());

            if (Config.ActiveSwappers.HasFlag(SwapType.Video))
                SwapperList.Add(SwapperVideo = new SwapperVideo());

            if (Config.ActiveSwappers.HasFlag(SwapType.SoundEffect))
                SwapperList.Add(SwapperAudioEffects = new SwapperAudioEffect());

            foreach (var item in SwapperList)
            {
                item.Setup();
            }
        }

        public static void DirCheck()
        {
            if (Directory.Exists(LibGlobal.Dir))
                Directory.CreateDirectory(LibGlobal.Dir);
        }
    }
}
