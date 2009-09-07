using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Scripting;
using Bonsai.Runtime;

namespace Tests {
    [TestClass]
    public class BlockTests : BonsaiTestClass{
        [TestMethod]
        public void TestBlockAssign() {
            object o = ScriptEngine.Execute("= .a { 42 } \n a");
            Assert.IsInstanceOfType(o, typeof(BlockBonsaiFunction));
        }

        [TestMethod]
        public void TestBlockInvoke() {
            object o = ScriptEngine.Execute("= .a { 42 } \n a .Invoke");
            Assert.AreEqual(42M, o);
        }

        [TestMethod]
        public void TestLexicalScoping() {
            Assert.AreEqual(SymbolTable.StringToId("InnerValue"), Execute("= .a .OuterValue \n = .b { = .a .InnerValue \n a } \n b .Invoke"));
            Assert.AreEqual(SymbolTable.StringToId("OuterValue"), Execute("= .a .OuterValue \n = .b { = .a .InnerValue \n a } \n b .Invoke \n a"));
        }
    }
}
