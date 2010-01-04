using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Scripting;
using Bonsai.Runtime;

namespace Bonsai.Tests {
    [TestClass]
    public class BlockTests : BonsaiTestClass{
        [TestMethod]
        public void TestBlockAssign() {
            object o = ScriptEngine.Execute("= .a { 42 } \n a");
            Assert.IsInstanceOfType(o, typeof(BlockBonsaiFunction));
        }

        [TestMethod]
        public void TestBlockInvoke() {
            object o = Execute("= .a { 42 } \n a .Invoke");
            Assert.AreEqual(42M, o);
        }

        [TestMethod]
        public void TestAssignmentInInnerScope() {
            Assert.AreEqual(
                SymbolTable.StringToId("InnerValue"),
                Execute("= .a .OuterValue \n = .b { = .a .InnerValue \n a } \n b .Invoke"));
            Assert.AreEqual(
                SymbolTable.StringToId("InnerValue"),
                Execute("= .a .OuterValue \n = .b { = .a .InnerValue \n a } \n b .Invoke \n a"));
            Assert.AreEqual(
                SymbolTable.StringToId("OuterValue"),
                Execute("= .a .OuterValue \n = .b { =: .a .InnerValue \n a } \n b .Invoke \n a"));
        }

        [TestMethod]
        public void TestAccessOuterVariable() {
            Assert.AreEqual(42M, Execute("= .a 42 \n = .b { a } \n b .Invoke"));
        }

        [TestMethod]
        public void ClosureTest() {
            Assert.AreEqual(42M, Execute(@"
                defun .make_counter .start {
                    = .block {
                        = .start (start .+ 1)
                        start
                    }
                    block
                }
                = .c1 (make_counter 416)
                = .c2 (make_counter 6)
                print (c1 .Invoke)
                print (c2 .Invoke)
                print (c1 .Invoke)
                print (c2 .Invoke)
                print (c1 .Invoke)
                print (c2 .Invoke)
                (c1 .Invoke) ./ (c2 .Invoke)"));
        }
    }
}
