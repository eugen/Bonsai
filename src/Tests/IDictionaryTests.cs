using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bonsai.Tests {
    [TestClass]
    public class IDictionaryTests : BonsaiTestClass {
        [TestMethod]
        public void TestIndexer() {
            Assert.AreEqual(42M, Execute("[# .a 42 ] .a"));
            
        }
    }
}
