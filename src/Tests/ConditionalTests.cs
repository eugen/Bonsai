using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bonsai.Tests {
    [TestClass]
    public class ConditionalTests : BonsaiTestClass {
        [TestMethod]
        public void TestIfValues() {
            Assert.AreEqual(42M, Execute("if .something 42 11"));
            Assert.AreEqual(42M, Execute("if 0 42 11"));

            Assert.AreEqual(42M, Execute("if null 11 42"));
            Assert.AreEqual(42M, Execute("if false 11 42"));
        }

        [TestMethod]
        public void TestIfBlocks() {
            Assert.AreEqual(42M, Execute("if true { 41 .+ 1 } 11"));
            Assert.AreEqual(42M, Execute("if null 11 { 41 .+ 1 }"));
        }

        [TestMethod]
        public void TestIfEvaluatesExactlyOneBlock() {
            Assert.AreEqual(42M, Execute("= .a 42 \n if .true 1 { = .a 11 } \n a"));
            Assert.AreEqual(42M, Execute("= .a 11 \n if .true { = .a 42 } 11 \n a"));
        }

        [TestMethod]
        public void TestWhen() {
            Assert.AreEqual(42M, Execute("= .a 0 ; when true { = .a 42 } ; a"));
            Assert.AreEqual(42M, Execute("= .a 42 ; when false { = .a 0 } ; a"));
        }

        [TestMethod]
        public void TestUnless() {
            Assert.AreEqual(42M, Execute("= .a 0 ; unless null { = .a 42 } ; a"));
            Assert.AreEqual(42M, Execute("= .a 42 ; unless true { = .a 0 } ; a"));
        }
    }
}
