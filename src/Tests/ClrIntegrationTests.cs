using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
    [TestClass]
    public class ClrIntegrationTests : BonsaiTestClass {
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
            Assert.AreEqual(
                0,
                Execute("import .int .System.Int32 \n int .new"));
        }

        [TestMethod]
        public void TestCallInstanceProperty() {
            Assert.AreEqual(
                0,
                Execute("import .list .System.Collections.ArrayList \n = .l (.list .new) \n l .Count"));
        }

        [TestMethod]
        public void TestCallInstanceMethod() {
            Assert.AreEqual(
                typeof(System.Collections.ArrayList),
                Execute("import .list .System.Collections.ArrayList \n = .l (.list .new) \n l .GetType"));
        }
    }
}
