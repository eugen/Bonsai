using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Scripting;

namespace Bonsai.Runtime
{
	public partial class PreludeFunction
	{
        private void InitDataHandlers() {
            var handlers = new Dictionary<SymbolId, Func<IEnumerable<object>, object>>();

            handlers.Add(
                "|".ToSymbol(),
                args => new List<object>(args));

            handlers.Add(
                "#".ToSymbol(), 
                args => {
                    var dict = new Dictionary<object, object>();
                    var enumerator = args.GetEnumerator();
                    while (enumerator.MoveNext()) {
                        var key = enumerator.Current;
                        if (!enumerator.MoveNext())
                            throw new Exception("Cannot parse dictionary data declaration: key without a value");
                        var value = enumerator.Current;
                        dict[key] = value;
                    }
                    return dict;
                });

            this["dataHandlers"] = handlers;
        }
	}
}
