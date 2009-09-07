using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
    [TestClass]
    public class StringTests : BonsaiTestClass {
        [TestMethod]
        public void CallStringFrameworkMethodsTest() {
            Assert.AreEqual("CAPS", Execute("\"caps\" .ToUpper"));
        }
    }
}
