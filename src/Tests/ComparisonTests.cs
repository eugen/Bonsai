using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bonsai.Tests {
    [TestClass]
    public class ComparisonTests : BonsaiTestClass  {
        [TestMethod]
        public void TestComparisons() {
            Assert.IsTrue((bool)Execute("< 1 4"));
            Assert.IsFalse((bool)Execute("< 1 1"));
            Assert.IsFalse((bool)Execute("< 1 -5"));

            Assert.IsTrue((bool)Execute("<= 1 4"));
            Assert.IsTrue((bool)Execute("<= 1 1"));
            Assert.IsFalse((bool)Execute("<= 1 -2"));

            Assert.IsTrue((bool)Execute("> 1 -100"));
            Assert.IsFalse((bool)Execute("> 1 1"));
            Assert.IsFalse((bool)Execute("> 1 5"));

            Assert.IsTrue((bool)Execute(">= 1 0"));
            Assert.IsTrue((bool)Execute(">= 1 1"));
            Assert.IsFalse((bool)Execute(">= 1 99"));
        }

        [TestMethod]
        public void TestEquals() {
            Assert.IsTrue((bool)Execute("== 1 1"));
            Assert.IsTrue((bool)Execute("== (1 .ToString) \"1\""));
            Assert.IsFalse((bool)Execute("== 0 1"));
        }

        [TestMethod]
        public void TestComparisonsMultiParameter() {
            Assert.IsTrue((bool)Execute("== 1 1 1"));
            Assert.IsTrue((bool)Execute("< 1 2 3"));
            Assert.IsTrue((bool)Execute("<= 1 2 2 3"));
            Assert.IsTrue((bool)Execute("> 3 2 1"));

            Assert.IsFalse((bool)Execute("== 1 1 1 2"));
            Assert.IsFalse((bool)Execute("< 1 2 3 3"));
            Assert.IsFalse((bool)Execute("< 1 2 2 3"));
        }
    }
}
