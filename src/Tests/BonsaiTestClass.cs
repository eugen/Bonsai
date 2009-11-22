using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting.Hosting.Providers;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Bonsai.Ast;
using Bonsai.Runtime;


namespace Bonsai.Tests {

    public class BonsaiTestClass {
        private TestContext testContextInstance;
        public TestContext TestContext {
            get {
                return testContextInstance;
            }
            set {
                testContextInstance = value;
            }
        }

        private static ScriptEngine scriptEngineInstance;
        protected static ScriptEngine ScriptEngine {
            get {
                return scriptEngineInstance;
            }
        }

        public BonsaiTestClass () {
            ScriptRuntimeSetup runtimeSetup = new ScriptRuntimeSetup() {
                DebugMode = true,
                LanguageSetups = {
                      new LanguageSetup(
                        typeof(BonsaiContext).AssemblyQualifiedName,
                        "Bonsai",
                        new string[] {"Bonsai"},
                        new string[] {".bon"})
                }
            };

            ScriptRuntime runtime = new ScriptRuntime(runtimeSetup);
            ScriptScope global = runtime.CreateScope();
            scriptEngineInstance = runtime.GetEngineByTypeName(typeof(BonsaiContext).AssemblyQualifiedName);
        }

        public object Execute(string code) {
            return ScriptEngine.Execute(code);
        }
    }
}
