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
                SymbolTable.StringToId("|"),
                args => args);

            this["dataHandlers"] = handlers;
        }
	}
}
