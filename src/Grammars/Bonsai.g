grammar Bonsai;
options { 
	output=AST;
	language=CSharp2;
    ASTLabelType = CommonTree;
}

tokens {
	CALL;   // "function" call
	GROUP;  // a list of expressions grouped together
	BLOCK;  // more statements grouped together which are "lazy"
	SQUARE; // I don't know what this is supposed to do
}

@namespace { Bonsai.Parsers }

program
	:	statements -> ^(GROUP statements)
    ;

statements
	:	calls+=call (NEWLINE calls+=call?)* 			-> $calls*
	|	NEWLINE+ (calls+=call (NEWLINE calls+=call?)*)?	-> $calls*
	;

expression 
	: 	paren_expr
	| 	square_expr
	| 	curly_expr
	| 	atom
	;

curly_expr
	:	'{' statements? '}' -> ^(BLOCK statements)
	;

square_expr
	:	'[' statements? ']' -> ^(SQUARE statements)
	;

paren_expr
	:	'(' statements? ')' -> ^(GROUP statements)
	;

call
	:	target=expression (args=arguments) 
		->	^(CALL $target $args*)
	;
	
arguments
	:	expression*
	;
	
atom
	:	NUMBER
	|	STRING
	|	SYMBOL
	|	IDENTIFIER
	; 
		

NEWLINE
	:	'\r'? '\n'
	;

WS	:	(' '|'\t')* { $channel = HIDDEN; }
	;

fragment NAMECHAR
	:	~(' '|'\t'|'{'|'}'|'('|')'|'['|']'|'\n'|'\r'|'\''|'"')
	;

SYMBOL
	:	'.' NAMECHAR*
	;

NUMBER
	:	'-'? ('0'..'9')+ ('.' ('0'..'9')*)? 
	;
	
IDENTIFIER
	:	NAMECHAR*
	;
	
STRING 
	:	SIMPLE_STRING
	|	ESCAPED_STRING
	|	MULTILINE_STRING
	;

fragment SIMPLE_STRING
	:	'\'' (~'\'')* '\''
	;
	

fragment MULTILINE_STRING 
	:	'"""' .* '"""'
	;

fragment ESCAPED_STRING
	:	'"' (~'"')* '"'
	;
