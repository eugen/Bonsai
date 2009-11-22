using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Scripting;

namespace Bonsai.Tests {
    [TestClass]
    public class BuiltinTests : BonsaiTestClass {
        [TestMethod]
        public void AssignmentTests() {
            Assert.AreEqual(42M, Execute("= .a 42 \n a"));
            Assert.AreEqual("fortytwo", Execute("= .a \"fortytwo\" \n a"));
            Assert.AreEqual(SymbolTable.StringToId("fortytwo"), Execute("= .a .fortytwo \n a"));

            //This tests a previous bug; don't remove
            Assert.AreEqual(42M, Execute("= .a 42 \n = .a a \n = .a a \n = .a a \n a"));
        }

        [TestMethod]
        public void SimpleSequenceTests() {
            Assert.AreEqual(1M, Execute("(1)"));
            Assert.AreEqual(3M, Execute("(1 \n 2 \n 3)"));
            Assert.AreEqual(1M, Execute("(= .a 1 \n = .b 2 \n a)"));
        }
    }
}
