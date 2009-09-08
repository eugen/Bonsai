using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
    [TestClass]
    public class DefunTests : BonsaiTestClass {
        [TestMethod]
        public void DefunTest() {
            Assert.AreEqual(42M, ScriptEngine.Execute("defun .inc .i { i .+ 1 } \n inc 41"));
        }
    }
}
