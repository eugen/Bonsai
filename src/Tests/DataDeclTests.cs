using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bonsai.Tests
{
    [TestClass]
    public class DataDeclTests : BonsaiTestClass
    {
        [TestMethod]
        public void TestListDecl() {
            dynamic a = Execute("[| 1 2 3 ]");
            Assert.AreEqual(1, a[0]);
            Assert.AreEqual(2, a[1]);
            Assert.AreEqual(3, a[2]);
            Assert.AreEqual(3, a.Length);
        }
    }
}
