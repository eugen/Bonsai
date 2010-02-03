using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bonsai.Tests {
    [TestClass]
    public class IListTests : BonsaiTestClass {
        [TestMethod]
        public void TestContains() {
            Assert.AreEqual(true, Execute("[| 41 42 43 ] .contains 42"));
            Assert.AreEqual(false, Execute("[| 41 43 ] .contains 42"));
        }

        [TestMethod]
        public void TestJoin() {
            Assert.AreEqual("1, 2, 3", Execute("[| 1 2 3] .join ', '"));
        }

        [TestMethod]
        public void TestIndexer() {
            Assert.AreEqual(42M, Execute("[| 39 40 41 42 43 ] 3"));
            Assert.AreEqual(42M, Execute("[| 41 42 ] 1"));
        }
    }
}
