using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwivelLIb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib.SwapperConfigTest
{
    [TestClass]
    public class Main
    {
        public SwapperConfig? swapperConfig = null;

        [TestInitialize]
        public void Initialize()
        {
            LibGlobal.WorkingDir = new DirectoryInfo(@"..\..\..\Swivel").FullName;

            swapperConfig = SwapperConfig.ByName("Test");

            Assert.IsNotNull(swapperConfig);
        }

        [TestMethod("ByName")]
        public void ByName()
        {
            Assert.IsNotNull(SwapperConfig.ByName("Test"));
        }

        [TestMethod("PackName")]
        public void PackName()
        {
            Assert.AreEqual("Test", swapperConfig.PackName);
        }

        [TestMethod("swapper")]
        public void swapper()
        {
            Assert.IsNotNull(LibGlobal.SwapperConfig);
        }
    }
}
