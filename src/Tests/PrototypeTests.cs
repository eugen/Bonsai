using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bonsai.Tests {
    [TestClass]
    public class PrototypeTests : BonsaiTestClass {
        [TestMethod] public void TestPrototypes() {
            Console.WriteLine("ZOMG");
            Assert.AreEqual("John Johnson & Mary Johnson", Execute(@"
                = .user (object .clone .UserProto)
                user .method .fullName { (self .firstName) .+ "" "" (self .lastName) }
                = .john (user .clone .JohnObject)
                john .= .firstName ""John""
                john .= .lastName ""Johnson""
                = .mary (john .clone .MaryObject)
                mary .= .firstName ""Mary""
                (john .fullName) .+ "" & "" (mary .fullName)"));
        }
    }
}
