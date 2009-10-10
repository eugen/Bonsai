using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
    [TestClass]
    public class StringTests : BonsaiTestClass {
        [TestMethod]
        public void TestStringMethods() {
            Assert.AreEqual("ZOMG", Execute("\"zomg\" .upcase"));
            Assert.AreEqual("zomg", Execute("\"ZOMG\" .downcase"));
            Assert.AreEqual("Omg Wtf Bbq", Execute("\"omg wtf bbq\" .capitalize"));

            Assert.AreEqual(true, Execute("\"omgwtfbbq\" .contains \"wtf\""));
            Assert.AreEqual(false, Execute("\"omgwtfbbq\" .contains \"bogus\""));
        }
    }
}
