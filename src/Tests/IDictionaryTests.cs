using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bonsai.Tests {
    [TestClass]
    public class IDictionaryTests : BonsaiTestClass {
        [TestMethod]
        public void TestIndexer() {
            Assert.AreEqual(42M, Execute("[# .a 42 ] .a"));
            
        }

        [TestMethod]
        public void TestToList() {
            var o = Execute("[# 1 'a' 2 'b' ] .toList");
            Assert.IsInstanceOfType(o, typeof(List<Tuple<object, object>>));
            var list = (List<Tuple<object, object>>)o;
            Assert.AreEqual(2, list.Count);
            var tuple = list[0];
            Assert.AreEqual(Tuple.Create<object, object>(1M, "a"), tuple);
        }
    }
}
