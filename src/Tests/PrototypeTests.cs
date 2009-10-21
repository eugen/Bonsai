using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
    [TestClass]
    public class PrototypeTests : BonsaiTestClass {
        [TestMethod] public void TestPrototypes() {
            Assert.AreEqual("John Johnson", Execute(@"
                = User (object .clone .user)
                user .set .fullName { (self .firstName) .+ "" "" (self .lastName) }
                = john (User .clone)
                john .set .firstName ""John""
                john .set .lastName ""Johnson""
                john .fullName"));
        }
    }
}
