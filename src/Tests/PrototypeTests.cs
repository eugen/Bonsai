using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bonsai.Runtime;

namespace Bonsai.Tests {
    [TestClass]
    public class PrototypeTests : BonsaiTestClass {
        [TestMethod]
        public void TestClone() {
            var newObject = (BonsaiPrototypeFunction)Execute("object .clone .NewObject");
            Assert.AreEqual("NewObject".ToSymbol(), newObject.Name);
        }

        [TestMethod]
        public void TestAddMethod() {
            var answer = Execute(@"
                = .user (object .clone)
                user .method .getAnswer { 42 }
                user .getAnswer");
            Assert.AreEqual(42M, answer);
        }

        [TestMethod]
        public void TestAddField() {
            var answer = Execute(@"
                = .user (object .clone)
                user .field .answer 42
                user .answer");
            Assert.AreEqual(42M, answer);
        }

        [TestMethod]
        public void TestMethodSelfReference() {
            var area = Execute(@"
                = .rect (object .clone)
                rect .field .height 4
                rect .field .width 3
                rect .method .area {
                    (self .height) .* (self .width)
                }
                rect .area");
            Assert.AreEqual(12M, area);
        }

        [TestMethod]
        public void TestMethodWithParameters() {
            var code = @"
                = .user (object .clone)
                user .field .name ""John Doe""
                user .field .title ""Dr. ""
                user .method .fullName .includeTitle { 
                    print includeTitle
                    if includeTitle { 
                        (self .title) .+ (self .name) 
                    } { 
                        (self .name) 
                    }
                }
                ";
            Assert.AreEqual("Dr. John Doe", Execute(code + "user .fullName .yes"));
            Assert.AreEqual("John Doe", Execute(code + "user .fullName null"));
        }

        [TestMethod]
        public void TestInheritance() {
            Assert.AreEqual(
                "John Johnson & Mary Johnson", 
                Execute(@"
                    = .user (object .clone .UserProto)
                    user .method .fullName { (self .firstName) .+ "" "" (self .lastName) }
                    = .john (user .clone .JohnObject)
                    john .field .firstName ""John""
                    john .field .lastName ""Johnson""
                    = .mary (john .clone .MaryObject)
                    mary .field .firstName ""Mary""
                    (john .fullName) .+ "" & "" (mary .fullName)"));
        }
    }
}
