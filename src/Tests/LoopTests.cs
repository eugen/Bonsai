using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bonsai.Tests {
    [TestClass]
    public class LoopTests : BonsaiTestClass {
        [TestMethod]
        public void TestForeach() {
            Assert.AreEqual(6M, Execute("= .sum 0 ; foreach .e [| 1 2 3 ] { = .sum ( sum .+ e ) }"));
        }
    }
}
