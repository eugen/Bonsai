using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
    [TestClass]
    public class FunctionTests : BonsaiTestClass {
        [TestMethod]
        public void DefunTest() {
            Assert.AreEqual(42M, ScriptEngine.Execute("defun .inc .i { (i) .+ 1 } \n inc 41"));
        }

        [TestMethod]
        public void UsingFunctionTest() {
            string code = @"
                defun .using .a .block { 
                    print ""Invoking block""
                    = .result (block .Invoke)
                    print ""Disposing of "" a
                    result
                }
                using .TOXIC_WASTE { 
                    print ""IMA BLOCK!"" 
                    42
                }";
            Assert.AreEqual(42M, ScriptEngine.Execute(code));
        }

        [TestMethod, ExpectedException(typeof(Exception), "The variable 'a' should not be declared after the call to 'f'", AllowDerivedTypes=true)]
        public void DontLeakArgumentsToOuterScopeTest() {
            string code = @"
                defun .f .a .b { print a b }
                f 4 2
                print .this_should_not_be_declared:_ a";
            ScriptEngine.Execute(code);
        }

        [TestMethod, Ignore]
        public void CallsShouldHaveDifferentScopes() {
            throw new NotImplementedException();
        }
    }
}
