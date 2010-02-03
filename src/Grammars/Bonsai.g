grammar Bonsai;
options { 
    output=AST;
    language=CSharp2;
    ASTLabelType = CommonTree;
}

tokens {
    CALL;   // "function" call
    GROUP;  // a list of expressions grouped together
    BLOCK;  // more statements grouped together 
    SQUARE; // to be used in the future
}

@namespace { Bonsai.Ast.Generated }

program
    :   statements -> ^(GROUP statements)
    ;

statements
    :   calls+=call (SEPARATOR calls+=call?)*
        -> $calls*
    |   SEPARATOR+ (calls+=call (SEPARATOR calls+=call?)*)?
        -> $calls*
    ;

expression 
    :   paren_expr
    |   square_expr
    |   curly_expr
    |   atom
    ;


square_expr
    :   '[' datatype=atom SEPARATOR* (exp+=expression SEPARATOR*)* ']' 
            -> ^(SQUARE $datatype $exp*)
    ;
curly_expr
    :   '{' statements? '}' -> ^(BLOCK statements)
    ;


paren_expr
    :   '(' statements? ')' -> ^(GROUP statements)
    ;

call
    :   target=expression (args=arguments) 
        ->  ^(CALL $target $args*)
    ;
    
arguments
    :   expression*
    ;
    
atom
    :   NUMBER
    |   STRING
    |   SYMBOL
    |   IDENTIFIER
    ; 
        
SEPARATOR
    :   '\r'? '\n'
    |   ';'
    ;

WS  :   (' '|'\t')* { $channel = HIDDEN; }
    ;

fragment NAMECHAR
    :   ~(' '|'\t'|'{'|'}'|'('|')'|'['|']'|'\n'|'\r'|'\''|'"')
    ;

SYMBOL
    :   '.' NAMECHAR*
    ;

NUMBER
    :   '-'? ('0'..'9')+ ('.' ('0'..'9')*)? 
    ;
    
IDENTIFIER
    :   NAMECHAR*
    ;
    
STRING 
    :   SIMPLE_STRING
    |   ESCAPED_STRING
    ;

fragment SIMPLE_STRING
    :   '\'' (~'\'')* '\''
    ;
    
fragment ESCAPED_STRING
    :   '"' (~'"')* '"'
    ;
