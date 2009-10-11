using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Bonsai.Runtime {
    public class PatternMatchingBonsaiFunction : BonsaiFunction {
        public List<Tuple<List<IPattern>, BlockBonsaiFunction>> Cases { get; private set; }

        public PatternMatchingBonsaiFunction() {
            this.Cases = new List<Tuple<List<IPattern>, BlockBonsaiFunction>>();
        }

        public void AddCase(List<IPattern> patterns, BlockBonsaiFunction block) {
            this.Cases.Add(new Tuple<List<IPattern>, BlockBonsaiFunction>(patterns, block));
        }

        public override object Call(object[] arguments) {
            foreach (var @case in Cases) {
                if (@case.Item1.Count == arguments.Length - 1) {
                    bool ismatch = true;
                    for (int i = 0; i < arguments.Length - 1; i++) {
                        var arg = arguments[i + 1];
                        var pat = @case.Item1[i];
                        if (!pat.Test(arg)) {
                            ismatch = false;
                            break;
                        }
                    }
                    if (ismatch) {
                        var blockLocalVariables = new DictionaryBonsaiFunction();
                        for (int i = 0; i < @case.Item1.Count; i++) {
                            blockLocalVariables[@case.Item1[i].ParameterName] = arguments[i + 1];
                        }
                        return @case.Item2.Invoke(blockLocalVariables);
                    }
                }
            }
            throw new NoMatchException();
        }
    }
}
