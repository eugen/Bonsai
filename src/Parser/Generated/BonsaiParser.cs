// $ANTLR 3.1.2 C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g 2009-06-25 21:22:21

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162
namespace  Bonsai.Ast.Generated
{

using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;



using Antlr.Runtime.Tree;

partial class BonsaiParser : Parser
{
    public static readonly string[] tokenNames = new string[] 
	{
        "<invalid>", 
		"<EOR>", 
		"<DOWN>", 
		"<UP>", 
		"CALL", 
		"GROUP", 
		"BLOCK", 
		"SQUARE", 
		"NEWLINE", 
		"NUMBER", 
		"STRING", 
		"SYMBOL", 
		"IDENTIFIER", 
		"WS", 
		"NAMECHAR", 
		"SIMPLE_STRING", 
		"ESCAPED_STRING", 
		"MULTILINE_STRING", 
		"'{'", 
		"'}'", 
		"'['", 
		"']'", 
		"'('", 
		"')'"
    };

    public const int SYMBOL = 11;
    public const int SIMPLE_STRING = 15;
    public const int T__23 = 23;
    public const int T__22 = 22;
    public const int T__21 = 21;
    public const int T__20 = 20;
    public const int NUMBER = 9;
    public const int ESCAPED_STRING = 16;
    public const int MULTILINE_STRING = 17;
    public const int EOF = -1;
    public const int NAMECHAR = 14;
    public const int T__19 = 19;
    public const int GROUP = 5;
    public const int WS = 13;
    public const int T__18 = 18;
    public const int NEWLINE = 8;
    public const int IDENTIFIER = 12;
    public const int BLOCK = 6;
    public const int CALL = 4;
    public const int SQUARE = 7;
    public const int STRING = 10;

    // delegates
    // delegators



        public BonsaiParser(ITokenStream input)
    		: this(input, new RecognizerSharedState()) {
        }

        public BonsaiParser(ITokenStream input, RecognizerSharedState state)
    		: base(input, state) {
            InitializeCyclicDFAs();

             
        }
        
    protected ITreeAdaptor adaptor = new CommonTreeAdaptor();

    public ITreeAdaptor TreeAdaptor
    {
        get { return this.adaptor; }
        set {
    	this.adaptor = value;
    	}
    }

    override public string[] TokenNames {
		get { return BonsaiParser.tokenNames; }
    }

    override public string GrammarFileName {
		get { return "C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g"; }
    }


    public class program_return : ParserRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "program"
    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:17:1: program : statements -> ^( GROUP statements ) ;
    public BonsaiParser.program_return program() // throws RecognitionException [1]
    {   
        BonsaiParser.program_return retval = new BonsaiParser.program_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        BonsaiParser.statements_return statements1 = default(BonsaiParser.statements_return);


        RewriteRuleSubtreeStream stream_statements = new RewriteRuleSubtreeStream(adaptor,"rule statements");
        try 
    	{
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:18:2: ( statements -> ^( GROUP statements ) )
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:18:4: statements
            {
            	PushFollow(FOLLOW_statements_in_program74);
            	statements1 = statements();
            	state.followingStackPointer--;

            	stream_statements.Add(statements1.Tree);


            	// AST REWRITE
            	// elements:          statements
            	// token labels:      
            	// rule labels:       retval
            	// token list labels: 
            	// rule list labels:  
            	// wildcard labels: 
            	retval.Tree = root_0;
            	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "rule retval", retval!=null ? retval.Tree : null);

            	root_0 = (CommonTree)adaptor.GetNilNode();
            	// 18:15: -> ^( GROUP statements )
            	{
            	    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:18:18: ^( GROUP statements )
            	    {
            	    CommonTree root_1 = (CommonTree)adaptor.GetNilNode();
            	    root_1 = (CommonTree)adaptor.BecomeRoot((CommonTree)adaptor.Create(GROUP, "GROUP"), root_1);

            	    adaptor.AddChild(root_1, stream_statements.NextTree());

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}

            	retval.Tree = root_0;retval.Tree = root_0;
            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "program"

    public class statements_return : ParserRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "statements"
    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:21:1: statements : (calls+= call ( NEWLINE (calls+= call )? )* -> ( $calls)* | ( NEWLINE )+ (calls+= call ( NEWLINE (calls+= call )? )* )? -> ( $calls)* );
    public BonsaiParser.statements_return statements() // throws RecognitionException [1]
    {   
        BonsaiParser.statements_return retval = new BonsaiParser.statements_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        IToken NEWLINE2 = null;
        IToken NEWLINE3 = null;
        IToken NEWLINE4 = null;
        IList list_calls = null;
        BonsaiParser.call_return calls = default(BonsaiParser.call_return);
         calls = null;
        CommonTree NEWLINE2_tree=null;
        CommonTree NEWLINE3_tree=null;
        CommonTree NEWLINE4_tree=null;
        RewriteRuleTokenStream stream_NEWLINE = new RewriteRuleTokenStream(adaptor,"token NEWLINE");
        RewriteRuleSubtreeStream stream_call = new RewriteRuleSubtreeStream(adaptor,"rule call");
        try 
    	{
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:22:2: (calls+= call ( NEWLINE (calls+= call )? )* -> ( $calls)* | ( NEWLINE )+ (calls+= call ( NEWLINE (calls+= call )? )* )? -> ( $calls)* )
            int alt7 = 2;
            int LA7_0 = input.LA(1);

            if ( ((LA7_0 >= NUMBER && LA7_0 <= IDENTIFIER) || LA7_0 == 18 || LA7_0 == 20 || LA7_0 == 22) )
            {
                alt7 = 1;
            }
            else if ( (LA7_0 == NEWLINE) )
            {
                alt7 = 2;
            }
            else 
            {
                NoViableAltException nvae_d7s0 =
                    new NoViableAltException("", 7, 0, input);

                throw nvae_d7s0;
            }
            switch (alt7) 
            {
                case 1 :
                    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:22:4: calls+= call ( NEWLINE (calls+= call )? )*
                    {
                    	PushFollow(FOLLOW_call_in_statements98);
                    	calls = call();
                    	state.followingStackPointer--;

                    	stream_call.Add(calls.Tree);
                    	if (list_calls == null) list_calls = new ArrayList();
                    	list_calls.Add(calls.Tree);

                    	// C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:22:16: ( NEWLINE (calls+= call )? )*
                    	do 
                    	{
                    	    int alt2 = 2;
                    	    int LA2_0 = input.LA(1);

                    	    if ( (LA2_0 == NEWLINE) )
                    	    {
                    	        alt2 = 1;
                    	    }


                    	    switch (alt2) 
                    		{
                    			case 1 :
                    			    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:22:17: NEWLINE (calls+= call )?
                    			    {
                    			    	NEWLINE2=(IToken)Match(input,NEWLINE,FOLLOW_NEWLINE_in_statements101);  
                    			    	stream_NEWLINE.Add(NEWLINE2);

                    			    	// C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:22:30: (calls+= call )?
                    			    	int alt1 = 2;
                    			    	int LA1_0 = input.LA(1);

                    			    	if ( ((LA1_0 >= NUMBER && LA1_0 <= IDENTIFIER) || LA1_0 == 18 || LA1_0 == 20 || LA1_0 == 22) )
                    			    	{
                    			    	    alt1 = 1;
                    			    	}
                    			    	switch (alt1) 
                    			    	{
                    			    	    case 1 :
                    			    	        // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:22:30: calls+= call
                    			    	        {
                    			    	        	PushFollow(FOLLOW_call_in_statements105);
                    			    	        	calls = call();
                    			    	        	state.followingStackPointer--;

                    			    	        	stream_call.Add(calls.Tree);
                    			    	        	if (list_calls == null) list_calls = new ArrayList();
                    			    	        	list_calls.Add(calls.Tree);


                    			    	        }
                    			    	        break;

                    			    	}


                    			    }
                    			    break;

                    			default:
                    			    goto loop2;
                    	    }
                    	} while (true);

                    	loop2:
                    		;	// Stops C# compiler whining that label 'loop2' has no statements



                    	// AST REWRITE
                    	// elements:          calls
                    	// token labels:      
                    	// rule labels:       retval
                    	// token list labels: 
                    	// rule list labels:  calls
                    	// wildcard labels: 
                    	retval.Tree = root_0;
                    	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "rule retval", retval!=null ? retval.Tree : null);
                    	RewriteRuleSubtreeStream stream_calls = new RewriteRuleSubtreeStream(adaptor, "token calls", list_calls);
                    	root_0 = (CommonTree)adaptor.GetNilNode();
                    	// 22:43: -> ( $calls)*
                    	{
                    	    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:22:46: ( $calls)*
                    	    while ( stream_calls.HasNext() )
                    	    {
                    	        adaptor.AddChild(root_0, stream_calls.NextTree());

                    	    }
                    	    stream_calls.Reset();

                    	}

                    	retval.Tree = root_0;retval.Tree = root_0;
                    }
                    break;
                case 2 :
                    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:23:4: ( NEWLINE )+ (calls+= call ( NEWLINE (calls+= call )? )* )?
                    {
                    	// C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:23:4: ( NEWLINE )+
                    	int cnt3 = 0;
                    	do 
                    	{
                    	    int alt3 = 2;
                    	    int LA3_0 = input.LA(1);

                    	    if ( (LA3_0 == NEWLINE) )
                    	    {
                    	        alt3 = 1;
                    	    }


                    	    switch (alt3) 
                    		{
                    			case 1 :
                    			    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:23:4: NEWLINE
                    			    {
                    			    	NEWLINE3=(IToken)Match(input,NEWLINE,FOLLOW_NEWLINE_in_statements122);  
                    			    	stream_NEWLINE.Add(NEWLINE3);


                    			    }
                    			    break;

                    			default:
                    			    if ( cnt3 >= 1 ) goto loop3;
                    		            EarlyExitException eee3 =
                    		                new EarlyExitException(3, input);
                    		            throw eee3;
                    	    }
                    	    cnt3++;
                    	} while (true);

                    	loop3:
                    		;	// Stops C# compiler whinging that label 'loop3' has no statements

                    	// C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:23:13: (calls+= call ( NEWLINE (calls+= call )? )* )?
                    	int alt6 = 2;
                    	int LA6_0 = input.LA(1);

                    	if ( ((LA6_0 >= NUMBER && LA6_0 <= IDENTIFIER) || LA6_0 == 18 || LA6_0 == 20 || LA6_0 == 22) )
                    	{
                    	    alt6 = 1;
                    	}
                    	switch (alt6) 
                    	{
                    	    case 1 :
                    	        // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:23:14: calls+= call ( NEWLINE (calls+= call )? )*
                    	        {
                    	        	PushFollow(FOLLOW_call_in_statements128);
                    	        	calls = call();
                    	        	state.followingStackPointer--;

                    	        	stream_call.Add(calls.Tree);
                    	        	if (list_calls == null) list_calls = new ArrayList();
                    	        	list_calls.Add(calls.Tree);

                    	        	// C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:23:26: ( NEWLINE (calls+= call )? )*
                    	        	do 
                    	        	{
                    	        	    int alt5 = 2;
                    	        	    int LA5_0 = input.LA(1);

                    	        	    if ( (LA5_0 == NEWLINE) )
                    	        	    {
                    	        	        alt5 = 1;
                    	        	    }


                    	        	    switch (alt5) 
                    	        		{
                    	        			case 1 :
                    	        			    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:23:27: NEWLINE (calls+= call )?
                    	        			    {
                    	        			    	NEWLINE4=(IToken)Match(input,NEWLINE,FOLLOW_NEWLINE_in_statements131);  
                    	        			    	stream_NEWLINE.Add(NEWLINE4);

                    	        			    	// C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:23:40: (calls+= call )?
                    	        			    	int alt4 = 2;
                    	        			    	int LA4_0 = input.LA(1);

                    	        			    	if ( ((LA4_0 >= NUMBER && LA4_0 <= IDENTIFIER) || LA4_0 == 18 || LA4_0 == 20 || LA4_0 == 22) )
                    	        			    	{
                    	        			    	    alt4 = 1;
                    	        			    	}
                    	        			    	switch (alt4) 
                    	        			    	{
                    	        			    	    case 1 :
                    	        			    	        // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:23:40: calls+= call
                    	        			    	        {
                    	        			    	        	PushFollow(FOLLOW_call_in_statements135);
                    	        			    	        	calls = call();
                    	        			    	        	state.followingStackPointer--;

                    	        			    	        	stream_call.Add(calls.Tree);
                    	        			    	        	if (list_calls == null) list_calls = new ArrayList();
                    	        			    	        	list_calls.Add(calls.Tree);


                    	        			    	        }
                    	        			    	        break;

                    	        			    	}


                    	        			    }
                    	        			    break;

                    	        			default:
                    	        			    goto loop5;
                    	        	    }
                    	        	} while (true);

                    	        	loop5:
                    	        		;	// Stops C# compiler whining that label 'loop5' has no statements


                    	        }
                    	        break;

                    	}



                    	// AST REWRITE
                    	// elements:          calls
                    	// token labels:      
                    	// rule labels:       retval
                    	// token list labels: 
                    	// rule list labels:  calls
                    	// wildcard labels: 
                    	retval.Tree = root_0;
                    	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "rule retval", retval!=null ? retval.Tree : null);
                    	RewriteRuleSubtreeStream stream_calls = new RewriteRuleSubtreeStream(adaptor, "token calls", list_calls);
                    	root_0 = (CommonTree)adaptor.GetNilNode();
                    	// 23:52: -> ( $calls)*
                    	{
                    	    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:23:55: ( $calls)*
                    	    while ( stream_calls.HasNext() )
                    	    {
                    	        adaptor.AddChild(root_0, stream_calls.NextTree());

                    	    }
                    	    stream_calls.Reset();

                    	}

                    	retval.Tree = root_0;retval.Tree = root_0;
                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "statements"

    public class expression_return : ParserRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "expression"
    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:26:1: expression : ( paren_expr | square_expr | curly_expr | atom );
    public BonsaiParser.expression_return expression() // throws RecognitionException [1]
    {   
        BonsaiParser.expression_return retval = new BonsaiParser.expression_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        BonsaiParser.paren_expr_return paren_expr5 = default(BonsaiParser.paren_expr_return);

        BonsaiParser.square_expr_return square_expr6 = default(BonsaiParser.square_expr_return);

        BonsaiParser.curly_expr_return curly_expr7 = default(BonsaiParser.curly_expr_return);

        BonsaiParser.atom_return atom8 = default(BonsaiParser.atom_return);



        try 
    	{
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:27:2: ( paren_expr | square_expr | curly_expr | atom )
            int alt8 = 4;
            switch ( input.LA(1) ) 
            {
            case 22:
            	{
                alt8 = 1;
                }
                break;
            case 20:
            	{
                alt8 = 2;
                }
                break;
            case 18:
            	{
                alt8 = 3;
                }
                break;
            case NUMBER:
            case STRING:
            case SYMBOL:
            case IDENTIFIER:
            	{
                alt8 = 4;
                }
                break;
            	default:
            	    NoViableAltException nvae_d8s0 =
            	        new NoViableAltException("", 8, 0, input);

            	    throw nvae_d8s0;
            }

            switch (alt8) 
            {
                case 1 :
                    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:27:5: paren_expr
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_paren_expr_in_expression159);
                    	paren_expr5 = paren_expr();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, paren_expr5.Tree);

                    }
                    break;
                case 2 :
                    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:28:5: square_expr
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_square_expr_in_expression165);
                    	square_expr6 = square_expr();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, square_expr6.Tree);

                    }
                    break;
                case 3 :
                    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:29:5: curly_expr
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_curly_expr_in_expression171);
                    	curly_expr7 = curly_expr();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, curly_expr7.Tree);

                    }
                    break;
                case 4 :
                    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:30:5: atom
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_atom_in_expression177);
                    	atom8 = atom();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, atom8.Tree);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "expression"

    public class curly_expr_return : ParserRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "curly_expr"
    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:33:1: curly_expr : '{' ( statements )? '}' -> ^( BLOCK statements ) ;
    public BonsaiParser.curly_expr_return curly_expr() // throws RecognitionException [1]
    {   
        BonsaiParser.curly_expr_return retval = new BonsaiParser.curly_expr_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        IToken char_literal9 = null;
        IToken char_literal11 = null;
        BonsaiParser.statements_return statements10 = default(BonsaiParser.statements_return);


        CommonTree char_literal9_tree=null;
        CommonTree char_literal11_tree=null;
        RewriteRuleTokenStream stream_19 = new RewriteRuleTokenStream(adaptor,"token 19");
        RewriteRuleTokenStream stream_18 = new RewriteRuleTokenStream(adaptor,"token 18");
        RewriteRuleSubtreeStream stream_statements = new RewriteRuleSubtreeStream(adaptor,"rule statements");
        try 
    	{
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:34:2: ( '{' ( statements )? '}' -> ^( BLOCK statements ) )
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:34:4: '{' ( statements )? '}'
            {
            	char_literal9=(IToken)Match(input,18,FOLLOW_18_in_curly_expr188);  
            	stream_18.Add(char_literal9);

            	// C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:34:8: ( statements )?
            	int alt9 = 2;
            	int LA9_0 = input.LA(1);

            	if ( ((LA9_0 >= NEWLINE && LA9_0 <= IDENTIFIER) || LA9_0 == 18 || LA9_0 == 20 || LA9_0 == 22) )
            	{
            	    alt9 = 1;
            	}
            	switch (alt9) 
            	{
            	    case 1 :
            	        // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:34:8: statements
            	        {
            	        	PushFollow(FOLLOW_statements_in_curly_expr190);
            	        	statements10 = statements();
            	        	state.followingStackPointer--;

            	        	stream_statements.Add(statements10.Tree);

            	        }
            	        break;

            	}

            	char_literal11=(IToken)Match(input,19,FOLLOW_19_in_curly_expr193);  
            	stream_19.Add(char_literal11);



            	// AST REWRITE
            	// elements:          statements
            	// token labels:      
            	// rule labels:       retval
            	// token list labels: 
            	// rule list labels:  
            	// wildcard labels: 
            	retval.Tree = root_0;
            	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "rule retval", retval!=null ? retval.Tree : null);

            	root_0 = (CommonTree)adaptor.GetNilNode();
            	// 34:24: -> ^( BLOCK statements )
            	{
            	    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:34:27: ^( BLOCK statements )
            	    {
            	    CommonTree root_1 = (CommonTree)adaptor.GetNilNode();
            	    root_1 = (CommonTree)adaptor.BecomeRoot((CommonTree)adaptor.Create(BLOCK, "BLOCK"), root_1);

            	    adaptor.AddChild(root_1, stream_statements.NextTree());

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}

            	retval.Tree = root_0;retval.Tree = root_0;
            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "curly_expr"

    public class square_expr_return : ParserRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "square_expr"
    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:37:1: square_expr : '[' ( statements )? ']' -> ^( SQUARE statements ) ;
    public BonsaiParser.square_expr_return square_expr() // throws RecognitionException [1]
    {   
        BonsaiParser.square_expr_return retval = new BonsaiParser.square_expr_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        IToken char_literal12 = null;
        IToken char_literal14 = null;
        BonsaiParser.statements_return statements13 = default(BonsaiParser.statements_return);


        CommonTree char_literal12_tree=null;
        CommonTree char_literal14_tree=null;
        RewriteRuleTokenStream stream_21 = new RewriteRuleTokenStream(adaptor,"token 21");
        RewriteRuleTokenStream stream_20 = new RewriteRuleTokenStream(adaptor,"token 20");
        RewriteRuleSubtreeStream stream_statements = new RewriteRuleSubtreeStream(adaptor,"rule statements");
        try 
    	{
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:38:2: ( '[' ( statements )? ']' -> ^( SQUARE statements ) )
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:38:4: '[' ( statements )? ']'
            {
            	char_literal12=(IToken)Match(input,20,FOLLOW_20_in_square_expr212);  
            	stream_20.Add(char_literal12);

            	// C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:38:8: ( statements )?
            	int alt10 = 2;
            	int LA10_0 = input.LA(1);

            	if ( ((LA10_0 >= NEWLINE && LA10_0 <= IDENTIFIER) || LA10_0 == 18 || LA10_0 == 20 || LA10_0 == 22) )
            	{
            	    alt10 = 1;
            	}
            	switch (alt10) 
            	{
            	    case 1 :
            	        // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:38:8: statements
            	        {
            	        	PushFollow(FOLLOW_statements_in_square_expr214);
            	        	statements13 = statements();
            	        	state.followingStackPointer--;

            	        	stream_statements.Add(statements13.Tree);

            	        }
            	        break;

            	}

            	char_literal14=(IToken)Match(input,21,FOLLOW_21_in_square_expr217);  
            	stream_21.Add(char_literal14);



            	// AST REWRITE
            	// elements:          statements
            	// token labels:      
            	// rule labels:       retval
            	// token list labels: 
            	// rule list labels:  
            	// wildcard labels: 
            	retval.Tree = root_0;
            	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "rule retval", retval!=null ? retval.Tree : null);

            	root_0 = (CommonTree)adaptor.GetNilNode();
            	// 38:24: -> ^( SQUARE statements )
            	{
            	    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:38:27: ^( SQUARE statements )
            	    {
            	    CommonTree root_1 = (CommonTree)adaptor.GetNilNode();
            	    root_1 = (CommonTree)adaptor.BecomeRoot((CommonTree)adaptor.Create(SQUARE, "SQUARE"), root_1);

            	    adaptor.AddChild(root_1, stream_statements.NextTree());

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}

            	retval.Tree = root_0;retval.Tree = root_0;
            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "square_expr"

    public class paren_expr_return : ParserRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "paren_expr"
    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:41:1: paren_expr : '(' ( statements )? ')' -> ^( GROUP statements ) ;
    public BonsaiParser.paren_expr_return paren_expr() // throws RecognitionException [1]
    {   
        BonsaiParser.paren_expr_return retval = new BonsaiParser.paren_expr_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        IToken char_literal15 = null;
        IToken char_literal17 = null;
        BonsaiParser.statements_return statements16 = default(BonsaiParser.statements_return);


        CommonTree char_literal15_tree=null;
        CommonTree char_literal17_tree=null;
        RewriteRuleTokenStream stream_22 = new RewriteRuleTokenStream(adaptor,"token 22");
        RewriteRuleTokenStream stream_23 = new RewriteRuleTokenStream(adaptor,"token 23");
        RewriteRuleSubtreeStream stream_statements = new RewriteRuleSubtreeStream(adaptor,"rule statements");
        try 
    	{
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:42:2: ( '(' ( statements )? ')' -> ^( GROUP statements ) )
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:42:4: '(' ( statements )? ')'
            {
            	char_literal15=(IToken)Match(input,22,FOLLOW_22_in_paren_expr236);  
            	stream_22.Add(char_literal15);

            	// C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:42:8: ( statements )?
            	int alt11 = 2;
            	int LA11_0 = input.LA(1);

            	if ( ((LA11_0 >= NEWLINE && LA11_0 <= IDENTIFIER) || LA11_0 == 18 || LA11_0 == 20 || LA11_0 == 22) )
            	{
            	    alt11 = 1;
            	}
            	switch (alt11) 
            	{
            	    case 1 :
            	        // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:42:8: statements
            	        {
            	        	PushFollow(FOLLOW_statements_in_paren_expr238);
            	        	statements16 = statements();
            	        	state.followingStackPointer--;

            	        	stream_statements.Add(statements16.Tree);

            	        }
            	        break;

            	}

            	char_literal17=(IToken)Match(input,23,FOLLOW_23_in_paren_expr241);  
            	stream_23.Add(char_literal17);



            	// AST REWRITE
            	// elements:          statements
            	// token labels:      
            	// rule labels:       retval
            	// token list labels: 
            	// rule list labels:  
            	// wildcard labels: 
            	retval.Tree = root_0;
            	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "rule retval", retval!=null ? retval.Tree : null);

            	root_0 = (CommonTree)adaptor.GetNilNode();
            	// 42:24: -> ^( GROUP statements )
            	{
            	    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:42:27: ^( GROUP statements )
            	    {
            	    CommonTree root_1 = (CommonTree)adaptor.GetNilNode();
            	    root_1 = (CommonTree)adaptor.BecomeRoot((CommonTree)adaptor.Create(GROUP, "GROUP"), root_1);

            	    adaptor.AddChild(root_1, stream_statements.NextTree());

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}

            	retval.Tree = root_0;retval.Tree = root_0;
            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "paren_expr"

    public class call_return : ParserRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "call"
    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:45:1: call : target= expression (args= arguments ) -> ^( CALL $target ( $args)* ) ;
    public BonsaiParser.call_return call() // throws RecognitionException [1]
    {   
        BonsaiParser.call_return retval = new BonsaiParser.call_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        BonsaiParser.expression_return target = default(BonsaiParser.expression_return);

        BonsaiParser.arguments_return args = default(BonsaiParser.arguments_return);


        RewriteRuleSubtreeStream stream_expression = new RewriteRuleSubtreeStream(adaptor,"rule expression");
        RewriteRuleSubtreeStream stream_arguments = new RewriteRuleSubtreeStream(adaptor,"rule arguments");
        try 
    	{
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:46:2: (target= expression (args= arguments ) -> ^( CALL $target ( $args)* ) )
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:46:4: target= expression (args= arguments )
            {
            	PushFollow(FOLLOW_expression_in_call262);
            	target = expression();
            	state.followingStackPointer--;

            	stream_expression.Add(target.Tree);
            	// C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:46:22: (args= arguments )
            	// C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:46:23: args= arguments
            	{
            		PushFollow(FOLLOW_arguments_in_call267);
            		args = arguments();
            		state.followingStackPointer--;

            		stream_arguments.Add(args.Tree);

            	}



            	// AST REWRITE
            	// elements:          target, args
            	// token labels:      
            	// rule labels:       retval, args, target
            	// token list labels: 
            	// rule list labels:  
            	// wildcard labels: 
            	retval.Tree = root_0;
            	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "rule retval", retval!=null ? retval.Tree : null);
            	RewriteRuleSubtreeStream stream_args = new RewriteRuleSubtreeStream(adaptor, "rule args", args!=null ? args.Tree : null);
            	RewriteRuleSubtreeStream stream_target = new RewriteRuleSubtreeStream(adaptor, "rule target", target!=null ? target.Tree : null);

            	root_0 = (CommonTree)adaptor.GetNilNode();
            	// 47:3: -> ^( CALL $target ( $args)* )
            	{
            	    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:47:6: ^( CALL $target ( $args)* )
            	    {
            	    CommonTree root_1 = (CommonTree)adaptor.GetNilNode();
            	    root_1 = (CommonTree)adaptor.BecomeRoot((CommonTree)adaptor.Create(CALL, "CALL"), root_1);

            	    adaptor.AddChild(root_1, stream_target.NextTree());
            	    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:47:21: ( $args)*
            	    while ( stream_args.HasNext() )
            	    {
            	        adaptor.AddChild(root_1, stream_args.NextTree());

            	    }
            	    stream_args.Reset();

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}

            	retval.Tree = root_0;retval.Tree = root_0;
            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "call"

    public class arguments_return : ParserRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "arguments"
    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:50:1: arguments : ( expression )* ;
    public BonsaiParser.arguments_return arguments() // throws RecognitionException [1]
    {   
        BonsaiParser.arguments_return retval = new BonsaiParser.arguments_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        BonsaiParser.expression_return expression18 = default(BonsaiParser.expression_return);



        try 
    	{
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:51:2: ( ( expression )* )
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:51:4: ( expression )*
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	// C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:51:4: ( expression )*
            	do 
            	{
            	    int alt12 = 2;
            	    int LA12_0 = input.LA(1);

            	    if ( ((LA12_0 >= NUMBER && LA12_0 <= IDENTIFIER) || LA12_0 == 18 || LA12_0 == 20 || LA12_0 == 22) )
            	    {
            	        alt12 = 1;
            	    }


            	    switch (alt12) 
            		{
            			case 1 :
            			    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:51:4: expression
            			    {
            			    	PushFollow(FOLLOW_expression_in_arguments296);
            			    	expression18 = expression();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, expression18.Tree);

            			    }
            			    break;

            			default:
            			    goto loop12;
            	    }
            	} while (true);

            	loop12:
            		;	// Stops C# compiler whining that label 'loop12' has no statements


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "arguments"

    public class atom_return : ParserRuleReturnScope
    {
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "atom"
    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:54:1: atom : ( NUMBER | STRING | SYMBOL | IDENTIFIER );
    public BonsaiParser.atom_return atom() // throws RecognitionException [1]
    {   
        BonsaiParser.atom_return retval = new BonsaiParser.atom_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        IToken set19 = null;

        CommonTree set19_tree=null;

        try 
    	{
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:55:2: ( NUMBER | STRING | SYMBOL | IDENTIFIER )
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	set19 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= NUMBER && input.LA(1) <= IDENTIFIER) ) 
            	{
            	    input.Consume();
            	    adaptor.AddChild(root_0, (CommonTree)adaptor.Create(set19));
            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "atom"

    // Delegated rules


	private void InitializeCyclicDFAs()
	{
	}

 

    public static readonly BitSet FOLLOW_statements_in_program74 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_call_in_statements98 = new BitSet(new ulong[]{0x0000000000000102UL});
    public static readonly BitSet FOLLOW_NEWLINE_in_statements101 = new BitSet(new ulong[]{0x0000000000541F02UL});
    public static readonly BitSet FOLLOW_call_in_statements105 = new BitSet(new ulong[]{0x0000000000000102UL});
    public static readonly BitSet FOLLOW_NEWLINE_in_statements122 = new BitSet(new ulong[]{0x0000000000541F02UL});
    public static readonly BitSet FOLLOW_call_in_statements128 = new BitSet(new ulong[]{0x0000000000000102UL});
    public static readonly BitSet FOLLOW_NEWLINE_in_statements131 = new BitSet(new ulong[]{0x0000000000541F02UL});
    public static readonly BitSet FOLLOW_call_in_statements135 = new BitSet(new ulong[]{0x0000000000000102UL});
    public static readonly BitSet FOLLOW_paren_expr_in_expression159 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_square_expr_in_expression165 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_curly_expr_in_expression171 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_atom_in_expression177 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_18_in_curly_expr188 = new BitSet(new ulong[]{0x00000000005C1F00UL});
    public static readonly BitSet FOLLOW_statements_in_curly_expr190 = new BitSet(new ulong[]{0x0000000000080000UL});
    public static readonly BitSet FOLLOW_19_in_curly_expr193 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_20_in_square_expr212 = new BitSet(new ulong[]{0x0000000000741F00UL});
    public static readonly BitSet FOLLOW_statements_in_square_expr214 = new BitSet(new ulong[]{0x0000000000200000UL});
    public static readonly BitSet FOLLOW_21_in_square_expr217 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_22_in_paren_expr236 = new BitSet(new ulong[]{0x0000000000D41F00UL});
    public static readonly BitSet FOLLOW_statements_in_paren_expr238 = new BitSet(new ulong[]{0x0000000000800000UL});
    public static readonly BitSet FOLLOW_23_in_paren_expr241 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_expression_in_call262 = new BitSet(new ulong[]{0x0000000000541E00UL});
    public static readonly BitSet FOLLOW_arguments_in_call267 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_expression_in_arguments296 = new BitSet(new ulong[]{0x0000000000541E02UL});
    public static readonly BitSet FOLLOW_set_in_atom0 = new BitSet(new ulong[]{0x0000000000000002UL});

}
}