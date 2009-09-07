using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Scripting;

namespace Tests {
    [TestClass]
    public class BuiltinTests : BonsaiTestClass {
        [TestMethod]
        public void AssignmentTests() {
            Assert.AreEqual(42M, Execute("= .a 42 \n a"));
            Assert.AreEqual("fortytwo", Execute("= .a \"fortytwo\" \n a"));
            Assert.AreEqual(SymbolTable.StringToId("fortytwo"), Execute("= .a .fortytwo \n a"));
        }

        [TestMethod]
        public void SimpleSequenceTests() {
            Assert.AreEqual(1M, Execute("(1)"));
            Assert.AreEqual(3M, Execute("(1 \n 2 \n 3)"));
        }

        [TestMethod]
        public void EmptySequenceTest() {
            Assert.IsNull(Execute("= .a () \n a"));
        }
    }
}
