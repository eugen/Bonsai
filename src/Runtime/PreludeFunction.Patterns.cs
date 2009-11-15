using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bonsai.Runtime.Primitives;
using System.Diagnostics;
using Microsoft.Scripting;

namespace Bonsai.Runtime {
    public partial class PreludeFunction {
        [MapsToSymbol("def|")]
        public object DefPattern(object[] args) {
            Debug.Assert(args.Length >= 3, "A call to def| should have at least 2 parameters: the name of the function and a block");
            Debug.Assert(args[0] is DictionaryBonsaiFunction);
            Debug.Assert(args[1] is SymbolId);
            for (int i = 2; i < args.Length - 1; i++)
                Debug.Assert(args[i] is SymbolId || args[i] is IPattern);
            Debug.Assert(args[args.Length - 1] is BlockBonsaiFunction);
            
            var scope = (DictionaryBonsaiFunction)args[0];
            var name = (SymbolId)args[1];
            var block = (BlockBonsaiFunction)args[args.Length - 1];

            PatternMatchingBonsaiFunction pmf = null;
            if (scope.Defines(name))
                pmf = scope[name] as PatternMatchingBonsaiFunction;
            if (pmf == null) {
                pmf = new PatternMatchingBonsaiFunction();
                scope[name] = pmf;
            }

            var patterns = new List<IPattern>();
            for (int i = 2; i < args.Length - 1; i++) {
                var arg = args[i];
                if (arg is IPattern)
                    patterns.Add((IPattern)arg);
                else
                    patterns.Add(new SymbolPattern((SymbolId)arg));
            }

            pmf.AddCase(patterns, block);
            return pmf;
        }

        [MapsToSymbol("|=")]
        public object EqPattern(object[] args) {
            Debug.Assert(args.Length == 3);
            return new EqPattern((SymbolId)args[1], args[2]);
        }

        [MapsToSymbol("|is")]
        public object IsPattern(object[] args) {
            Debug.Assert(args.Length == 3);
            return new IsPattern((SymbolId)args[1], args[2]);
        }
    }
}