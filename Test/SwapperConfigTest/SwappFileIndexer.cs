using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwivelLIb;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib.SwapperConfigTest
{
    [TestClass]
    public class SwappFileIndexer
    {
        public SwapperConfig? swapperConfig = null;

        [TestInitialize]
        public void Initialize()
        {
            LibGlobal.WorkingDir = new DirectoryInfo(@"..\..\..\Swivel").FullName;

            swapperConfig = SwapperConfig.ByName("Test");

            Assert.IsNotNull(swapperConfig);
        }

        [TestMethod]
        public void Get()
        {
            var swap = swapperConfig["tm"];

            //Assert.AreEqual(swap != null, true, "SwapFile: Not Found");

            //Assert.IsNotNull(swap["tm"], $"SwapFile: Get valid");
            //Assert.IsNull(swap["sasfdsafgdsg"], $"SwapFile: Get invalid");
        }

        [TestMethod]
        public void Set()
        {
            //var swap = swapperConfig.swapperFiles.Find(s => s.Triggers.Any(t => t.Target == "tm"));

            //swap["tm"].chance = -1;
            //var copy = swap["tm"].Clone(); 
            //copy.chance = 100; 
            //swap["tm"] = copy;
            //Assert.AreEqual(100, swap["tm"].chance, $"SwapFile: Set");
        }
    }
}
