using System;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting.Hosting.Providers;

using Bonsai.Ast;
using Bonsai.Runtime;
using System.Reflection;
using System.Collections.Generic;

namespace Bonsai.Shell
{
	public static class Extensions {
	}
			
	class MainClass
	{
		public static void Main(string[] args)
		{
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
            ScriptEngine engine = runtime.GetEngineByTypeName(typeof(BonsaiContext).AssemblyQualifiedName);
            Console.WriteLine(engine.Execute(@"
import .arrl .System.Collections.ArrayList
= .a (arrl .new)
a .Add 4
a .Add 6
print (a .Item 0)
print (a .Count)
                "));
      	}
	}
}