using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bonsai.Runtime;

namespace Tests {
    [TestClass]
    public class ClrIntegrationTests : BonsaiTestClass {
        [TestMethod]
        public void TestImportNamespace() {
            Assert.AreEqual(
                typeof(System.Environment),
                Execute("import .sys .System \n sys .Environment"));
        }
        [TestMethod]
        public void TestImportClass() {
            var console = Execute("import .console .System.Console \n ref .console");
            Assert.IsInstanceOfType(console, typeof(BonsaiClrClassFunction));
            Assert.AreEqual(typeof(System.Console), ((BonsaiClrClassFunction)console).Class);
        }

        [TestMethod]
        public void TestCallStaticProperty() {
            Assert.AreEqual(
                Environment.CurrentDirectory,
                Execute("import .env .System.Environment \n env .CurrentDirectory"));
        }
        [TestMethod]
        public void TestCallStaticMethod() {
            Assert.AreEqual(
                Environment.GetEnvironmentVariable("PATH"),
                Execute("import .env .System.Environment \n env .GetEnvironmentVariable \"PATH\""));
        }

        [TestMethod]
        public void TestInstantiateClass() {
            Assert.IsInstanceOfType(
                Execute("import .arraylist .System.Collections.ArrayList \n arraylist .new"),
                typeof(System.Collections.ArrayList));
        }

        [TestMethod]
        public void TestCallInstanceProperty() {
            Assert.AreEqual(
                0,
                Execute("import .list .System.Collections.ArrayList \n = .l (list .new) \n l .Count"));
        }

        [TestMethod]
        public void TestCallInstanceMethod() {
            Assert.AreEqual(
                typeof(System.Collections.ArrayList),
                Execute("import .list .System.Collections.ArrayList \n = .l (list .new) \n l .GetType"));
        }
    }
}
