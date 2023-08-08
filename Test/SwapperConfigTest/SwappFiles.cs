using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwivelLIb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lib.SwapperConfigTest
{
    [TestClass]
    public class SwappFiles
    {
        public SwapperConfig? swapperConfig = null;

        [TestInitialize]
        public void Initialize()
        {
            LibGlobal.WorkingDir = new DirectoryInfo(@"..\..\..\Swivel").FullName;

            swapperConfig = SwapperConfig.ByName("Test");

            Assert.IsNotNull(swapperConfig);
        }

        [TestMethod("GetFile")]
        public void GetFile()
        {
            Assert.AreEqual(true, swapperConfig.GetFile("tm", SwapType.Video, out _, out _), "Type: Video");

            Assert.AreEqual(true, swapperConfig.GetFile("*", SwapType.Video, out _, out _), "*");

            Assert.AreEqual(false, swapperConfig.GetFile("tm", SwapType.NotSpecified, out _, out _), "NotSpecified");

            Assert.AreEqual(false, swapperConfig.GetFile("tm", SwapType.Music, out _, out _), "Invalid SwapType Check");
        }

        [TestMethod("GetFiles")]
        public void GetFiles()
        {
            Assert.AreEqual(true, swapperConfig.GetFiles("tm", SwapType.Video, out _, out _), "Type: Video");

            Assert.AreEqual(true, swapperConfig.GetFiles("*", SwapType.Video, out _, out _), "*");

            Assert.AreEqual(false, swapperConfig.GetFiles("tm", SwapType.NotSpecified, out _, out _), "NotSpecified");

            Assert.AreEqual(false, swapperConfig.GetFiles("tm", SwapType.Music, out _, out _), "Invalid SwapType Check");

            var swap = swapperConfig.swapperFiles.Find(s => s.Triggers.Any(t => t.Target == "tm"));
            Assert.AreEqual(swap != null, true, "SwapFile: Not Found");

            swap.Enabled = false;
            Assert.AreEqual(false, swapperConfig.GetFiles("tm", SwapType.Video, out _, out _), "Enabled: False");

            swap.Enabled = true;
            Assert.AreEqual(true, swapperConfig.GetFiles("tm", SwapType.Video, out _, out _), "Enabled: True");

            var trig = swap.Triggers.Find(t => t.Target == "tm");
            Assert.AreEqual(trig != null, true, "Trigger: Not Found");

            trig.Enabled = false;
            Assert.AreEqual(false, swapperConfig.GetFiles("tm", SwapType.Video, out _, out _), "Trigger: False");

            trig.Enabled = true;
            Assert.AreEqual(true, swapperConfig.GetFiles("tm", SwapType.Video, out _, out _), "Trigger: True");
        }
    }
}
