tree grammar BonsaiTree;

options {
    tokenVocab=Bonsai;
    language=CSharp2;
    ASTLabelType = CommonTree;
    output=AST;
}

@namespace { Bonsai.Ast.Generated }

@header { 
    using Bonsai.Ast;
    using System.Collections.Generic;
}

program returns [Sequence result]
    : ^(GROUP
            { $result = new Sequence(); }
            (c=call { $result.Statements.Add(c.result); })*)
    ;

call returns [Call result]
    : ^(CALL { $result = new Call(); }
            target=expression { $result.Target = target.result; }
            (a=expression { $result.Arguments.Add(a.result); })*)
    ;

expression returns [Expression result]
    : ^(GROUP
            { $result = new Sequence(); }
            (c=call { ((Sequence)$result).Statements.Add(c.result); })*)
    | ^(BLOCK
            { $result = new Block(); }
            (c=call { ((Block)$result).Statements.Add(c.result); })*)
    | ^(SQUARE 
            { $result = new DataDecl(); }
            datatype=IDENTIFIER { 
                ((DataDecl)$result).DataTypeId = $datatype.Text; }
            (e=expression { 
                ((DataDecl)$result).Expressions.Add(e.result); })*)
    | number=NUMBER { $result = new Number() { 
            Value = decimal.Parse($number.Text) }; }
    | str=STRING { $result = new Bonsai.Ast.String()
            { Value = $str.Text.Substring(1, $str.Text.Length - 2) }; }
    | str=IDENTIFIER { $result = new Reference() { 
            Name = $str.Text }; }
    | str=SYMBOL { $result = new Symbol() { 
            Name = $str.Text.Substring(1) }; }
    ;
