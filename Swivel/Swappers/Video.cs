using Swivel.Internals;
using SwivelLIb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swivel.Swappers
{
    public class SwapperVideo : Feature
    {
        public string BaseDir;

        public object BackGroundScreenInstance = null;

        public bool Muted = false;

        public SwapperVideo()
        {
            BaseDir = $@"{LibGlobal.CurrentPackDir}\Video";
        }

        public override void CleanUp()
        {
            IsLoaded = false;
        }

        public override void Setup()
        {
            IsLoaded = true;

            //Muted = true;
        }
    }
}
