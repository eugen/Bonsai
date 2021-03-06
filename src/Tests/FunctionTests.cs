﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Scripting;

namespace Bonsai.Tests {
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
                using .toxic { 
                    print ""I am a block!"" 
                    42
                }";
            Assert.AreEqual(42M, ScriptEngine.Execute(code));
        }

        [TestMethod]
        public void FunTest() {
            Assert.AreEqual(42M, Execute(@"
                = .f (fun .a .b { a .+ b })
                f 40 2
                "));
        }

        [TestMethod]
        public void FunTestClosure() {
            Assert.AreEqual(42M, Execute(@"
                defun .make_counter .start {
                    fun .increment {
                        = .start (start .+ increment)
                        start
                    }
                }
                = .c1 (make_counter 400)
                = .c2 (make_counter 5)
                print (c1 5)
                print (c2 2)
                print (c1 5)
                print (c2 2)
                (c1 10) ./ (c2 1)"));
        }

        [TestMethod, ExpectedException(typeof(Exception), "The variable 'a' should not be declared after the call to 'f'", AllowDerivedTypes = true)]
        public void DontLeakArgumentsToOuterScopeTest() {
            string code = @"
                defun .f .a .b { print a b }
                f 4 2
                print ""This variable should not be declared: "" a";
            ScriptEngine.Execute(code);
        }

        [TestMethod]
        public void ClosureTest() {
            Assert.AreEqual(42M, Execute(@"
                defun .make_counter .start {
                    defun .add .increment {
                        = .start (start .+ increment)
                        start
                    }
                    ref .add
                }
                = .c1 (make_counter 400)
                = .c2 (make_counter 5)
                print (c1 5)
                print (c2 2)
                print (c1 5)
                print (c2 2)
                (c1 10) ./ (c2 1)"));
        }
    }
}
