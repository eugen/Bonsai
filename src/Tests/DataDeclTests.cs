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
            Assert.AreEqual(3, a.Count);
            Assert.IsInstanceOfType(a, typeof(List<object>));
        }

        [TestMethod]
        public void TestDictDecl() {
            dynamic d = Execute("[# .a 1 .b 2 .c 3]");
            Assert.AreEqual(1, d["a".ToSymbol()]);
            Assert.AreEqual(2, d["b".ToSymbol()]);
            Assert.AreEqual(3, d["c".ToSymbol()]);
            Assert.IsInstanceOfType(d, typeof(Dictionary<object, object>));
        }

        [TestMethod]
        public void TestDictOfLists() {
            dynamic d = Execute(@"[# 
                'numbers' 
                    [| 1 2 3 ] 
                'strings' 
                    [| '1' '2' '3' ]
            ]");
            Assert.AreEqual(1, d["numbers"][0]);
            Assert.AreEqual("1", d["strings"][0]);
        }
    }
}
