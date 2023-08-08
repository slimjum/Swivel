using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwivelLIb;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib
{
    [TestClass]
    public class LibGlobalTest
    {
        [TestInitialize]
        public void Initialize()
        {
            LibGlobal.WorkingDir = new DirectoryInfo(@"..\..\..\Swivel").FullName;
        }

        [TestMethod("Dir")]
        public void Dir()
        {
            Assert.AreEqual(LibGlobal.WorkingDir, LibGlobal.Dir);
        }

        [TestMethod("ConfigPath")]
        public void ConfigPath()
        {
            Assert.AreEqual(new FileInfo(@$"..\..\..\Swivel\{LibGlobal.SwahiliConfigFileName}").FullName, LibGlobal.ConfigPath);
        }

        [TestMethod("CurrentPack")]
        public void CurrentPack()
        {
            Assert.AreEqual("Test", LibGlobal.CurrentPack);
        }

        [TestMethod("CurrentPackDir")]
        public void CurrentPackDir()
        {
            Assert.AreEqual(new DirectoryInfo(@"..\..\..\Swivel\Test").FullName, LibGlobal.CurrentPackDir);
        }
    }
}
