using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bonsai.Tests {
    [TestClass]
    public class IEnumerableTests : BonsaiTestClass {
        [TestMethod]
        public void TestIndexer() {
            Assert.AreEqual(42M, Execute("[ 42 43 ] 0"));
            Assert.AreEqual(42M, Execute("[ 41 42 ] 1"));
        }
    }
}
