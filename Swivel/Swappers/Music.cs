using Swivel.Internals;
using SwivelLIb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swivel.Swappers
{
    public class SwapperMusic : Feature
    {
        public string BaseDir;

        public SwapperMusic()
        {
            BaseDir = $@"{LibGlobal.CurrentPackDir}\Audio\Music";
        }

        public override void CleanUp()
        {
            IsLoaded = false;
        }

        public override void Setup()
        {
            IsLoaded = true;
        }
    }
}
