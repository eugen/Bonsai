using System;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting.Hosting.Providers;

using Bonsai.Ast;
using Bonsai.Runtime;

namespace Bonsai.Shell
{
	public static class Extensions {
	}
			
	class MainClass
	{
		public static void Main(string[] args)
		{
            ScriptRuntimeSetup runtimeSetup = new ScriptRuntimeSetup()
            {
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
            //Console.WriteLine(engine.Execute("(\"zomg i'm writing caps!\" .ToUpper) .Substring 5"));
            //engine.Execute("= .a print \n a 1 .2 \"3\"");
            engine.Execute("= .printa { print .a } \n print .printa_este \n printa .Invoke)");
      	}
	}
}