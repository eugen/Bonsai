using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
    [TestClass]
    public class OverridePrimitivesTest : BonsaiTestClass {
        [TestMethod]
        public void OverrideEqualsTest() {
            Assert.AreEqual(42M, ScriptEngine.Execute("= .= { 42 } \n = .Invoke"));
        }
    }
}
