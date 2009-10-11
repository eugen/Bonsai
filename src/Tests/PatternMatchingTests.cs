using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Scripting;

namespace Tests {
    [TestClass]
    public class PatternMatchingTests : BonsaiTestClass {
        [TestMethod]
        public void BasicEqualityPattern() {
            var defun = @"
def| .pf .a (|= .b 42) { 42 }
def| .pf .a .b { a }
";
            Assert.AreEqual(SymbolTable.StringToId("zomg"), Execute(defun + "pf .zomg 41"));
            Assert.AreEqual(42M, Execute(defun + "pf .zomg 42"));
        }

        [TestMethod]
        public void BasicEqualityPatternFactorial() {
            var defun = @"
def| .fact (|= .a 0) { 1 }
def| .fact .a { a .* (fact (a .- 1)) }
";
            Assert.AreEqual(5040M, Execute(defun + "fact 7"));
        }
    }
}
