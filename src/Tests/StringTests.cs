using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bonsai.Tests {
    [TestClass]
    public class StringTests : BonsaiTestClass {
        [TestMethod]
        public void TestStringMethods() {
            Assert.AreEqual("BONSAI", Execute("\"bonsai\" .upcase"));
            Assert.AreEqual("bonsai", Execute("\"BONSAI\" .downcase"));
            Assert.AreEqual("Bonsai Is A Language", Execute("\"bonsai is a language\" .capitalize"));

            Assert.AreEqual(true, Execute("\"bonsai\" .contains \"on\""));
            Assert.AreEqual(false, Execute("\"bonsai\" .contains \"lalala\""));

            Assert.AreEqual("bonsai", Execute("\"bo\" .+ \"ns\" \"ai\""));
        }
    }
}
