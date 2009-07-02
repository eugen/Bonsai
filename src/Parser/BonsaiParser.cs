using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bonsai.Ast;
using Antlr.Runtime;
using Antlr.Runtime.Tree;

namespace Bonsai.Ast {
    public class BonsaiParser { 
        public static Sequence ParseString(string text) {
            ANTLRStringStream strStream = new ANTLRStringStream(text);
			BonsaiLexer lexer = new BonsaiLexer(strStream);
            CommonTokenStream tokStream = new CommonTokenStream(lexer);
            Generated.BonsaiParser parser = new Generated.BonsaiParser(tokStream);
            var returnValue = parser.program();
			CommonTree tree = (CommonTree)returnValue.Tree;
			CommonTreeNodeStream treeNodeStream = new CommonTreeNodeStream((CommonTree)returnValue.Tree);
            Generated.BonsaiTree treeWalker = new Generated.BonsaiTree(treeNodeStream);

            return new Sequence(treeWalker.program().result.Statements);
        }
    }
}
