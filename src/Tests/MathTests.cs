using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bonsai.Tests {
    [TestClass]
    public class MathTests : BonsaiTestClass {
        [TestMethod]
        public void SimpleAddSubstractMultiplyDivideTest() {
            Assert.AreEqual(42M, ScriptEngine.Execute("40 .+ 2"));
            Assert.AreEqual(42M, ScriptEngine.Execute("50 .+ -8"));
            Assert.AreEqual(42M, ScriptEngine.Execute("41.99999999 .+ 0.00000001"));
            Assert.AreNotEqual(42M, ScriptEngine.Execute("41.99999998 .+ 0.00000001"));

            Assert.AreEqual(42M, ScriptEngine.Execute("43 .- 1"));

            Assert.AreEqual(42M, ScriptEngine.Execute("0.000042 .* 1000000"));

            Assert.AreEqual(42M, ScriptEngine.Execute("42000000 ./ 1000000"));
            Assert.AreEqual(0M, Execute(@"
                = .a 0
                = .a (a .+ 1)
                = .a (a .- 6)
                = .a (a .+ 2)
                = .a (a .- 5)
                = .a (a .+ 3)
                = .a (a .- 4)
                = .a (a .+ 4)
                = .a (a .- 3)
                = .a (a .+ 5)
                = .a (a .- 2)
                = .a (a .+ 6)
                = .a (a .- 1)
                a"));
        }

        [TestMethod]
        public void TestOperationsBetweenVariables() {
            Assert.AreEqual(42M, Execute("= .a 40 \n = .b 2 \n a .+ b"));
        }

        [TestMethod]
        public void TestMathOperations() {
            Assert.AreEqual(130691232M, ScriptEngine.Execute("42 .^ 5"));
            Assert.AreEqual(42M, ScriptEngine.Execute("130691232 .^ 0.2"));
        }
    }
}
