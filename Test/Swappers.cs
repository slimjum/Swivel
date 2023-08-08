using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using SwivelLIb;

namespace Swivel
{
    [TestClass]
    public class SwapperTest
    {
        public SwapperConfig? Config;

        [TestInitialize]
        public void Initialize()
        {
            LibGlobal.WorkingDir = new DirectoryInfo(@"..\..\..\Swivel").FullName;

            Config = SwapperConfig.ByName("Test");
        }

        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(true ,Config.GetFiles("tm", SwapType.Video, out var _Names, out var _RootDir));

            //CollectionAssert.AreEqual(list, list);

            Assert.IsTrue(_Names.Count() > 0);

            //Assert.AreEqual(2, );
        }
    }
}
