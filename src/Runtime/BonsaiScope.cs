using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using Microsoft.Scripting.Runtime;
using Microsoft.Scripting;

namespace Bonsai.Ast
{
	public class BonsaiScope : Scope
	{		
		public BonsaiScope()
		{
		}

        public BonsaiScope(Scope parent, IAttributesCollection dictionary)
            : base(parent, dictionary) {
        }
	}
}