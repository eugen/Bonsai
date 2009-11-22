// $ANTLR 3.2 Sep 23, 2009 12:02:23 D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g 2009-11-22 15:30:43

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162


using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;



using Antlr.Runtime.Tree;

namespace  Bonsai.Ast.Generated 
{
public partial class BonsaiParser : Parser
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
		"SEPARATOR", 
		"NUMBER", 
		"STRING", 
		"SYMBOL", 
		"IDENTIFIER", 
		"WS", 
		"NAMECHAR", 
		"SIMPLE_STRING", 
		"ESCAPED_STRING", 
		"'['", 
		"']'", 
		"'{'", 
		"'}'", 
		"'('", 
		"')'"
    };

    public const int SYMBOL = 11;
    public const int SIMPLE_STRING = 15;
    public const int T__22 = 22;
    public const int T__21 = 21;
    public const int T__20 = 20;
    public const int NUMBER = 9;
    public const int ESCAPED_STRING = 16;
    public const int SEPARATOR = 8;
    public const int EOF = -1;
    public const int NAMECHAR = 14;
    public const int T__19 = 19;
    public const int GROUP = 5;
    public const int WS = 13;
    public const int T__18 = 18;
    public const int T__17 = 17;
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
		get { return "D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g"; }
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
    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:17:1: program : statements -> ^( GROUP statements ) ;
    public BonsaiParser.program_return program() // throws RecognitionException [1]
    {   
        BonsaiParser.program_return retval = new BonsaiParser.program_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        BonsaiParser.statements_return statements1 = default(BonsaiParser.statements_return);


        RewriteRuleSubtreeStream stream_statements = new RewriteRuleSubtreeStream(adaptor,"rule statements");
        try 
    	{
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:18:5: ( statements -> ^( GROUP statements ) )
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:18:9: statements
            {
            	PushFollow(FOLLOW_statements_in_program97);
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
            	// 18:20: -> ^( GROUP statements )
            	{
            	    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:18:23: ^( GROUP statements )
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
    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:21:1: statements : (calls+= call ( SEPARATOR (calls+= call )? )* -> ( $calls)* | ( SEPARATOR )+ (calls+= call ( SEPARATOR (calls+= call )? )* )? -> ( $calls)* );
    public BonsaiParser.statements_return statements() // throws RecognitionException [1]
    {   
        BonsaiParser.statements_return retval = new BonsaiParser.statements_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        IToken SEPARATOR2 = null;
        IToken SEPARATOR3 = null;
        IToken SEPARATOR4 = null;
        IList list_calls = null;
        BonsaiParser.call_return calls = default(BonsaiParser.call_return);
         calls = null;
        CommonTree SEPARATOR2_tree=null;
        CommonTree SEPARATOR3_tree=null;
        CommonTree SEPARATOR4_tree=null;
        RewriteRuleTokenStream stream_SEPARATOR = new RewriteRuleTokenStream(adaptor,"token SEPARATOR");
        RewriteRuleSubtreeStream stream_call = new RewriteRuleSubtreeStream(adaptor,"rule call");
        try 
    	{
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:22:5: (calls+= call ( SEPARATOR (calls+= call )? )* -> ( $calls)* | ( SEPARATOR )+ (calls+= call ( SEPARATOR (calls+= call )? )* )? -> ( $calls)* )
            int alt7 = 2;
            int LA7_0 = input.LA(1);

            if ( ((LA7_0 >= NUMBER && LA7_0 <= IDENTIFIER) || LA7_0 == 17 || LA7_0 == 19 || LA7_0 == 21) )
            {
                alt7 = 1;
            }
            else if ( (LA7_0 == SEPARATOR) )
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
                    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:22:9: calls+= call ( SEPARATOR (calls+= call )? )*
                    {
                    	PushFollow(FOLLOW_call_in_statements126);
                    	calls = call();
                    	state.followingStackPointer--;

                    	stream_call.Add(calls.Tree);
                    	if (list_calls == null) list_calls = new ArrayList();
                    	list_calls.Add(calls.Tree);

                    	// D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:22:21: ( SEPARATOR (calls+= call )? )*
                    	do 
                    	{
                    	    int alt2 = 2;
                    	    int LA2_0 = input.LA(1);

                    	    if ( (LA2_0 == SEPARATOR) )
                    	    {
                    	        alt2 = 1;
                    	    }


                    	    switch (alt2) 
                    		{
                    			case 1 :
                    			    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:22:22: SEPARATOR (calls+= call )?
                    			    {
                    			    	SEPARATOR2=(IToken)Match(input,SEPARATOR,FOLLOW_SEPARATOR_in_statements129);  
                    			    	stream_SEPARATOR.Add(SEPARATOR2);

                    			    	// D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:22:37: (calls+= call )?
                    			    	int alt1 = 2;
                    			    	int LA1_0 = input.LA(1);

                    			    	if ( ((LA1_0 >= NUMBER && LA1_0 <= IDENTIFIER) || LA1_0 == 17 || LA1_0 == 19 || LA1_0 == 21) )
                    			    	{
                    			    	    alt1 = 1;
                    			    	}
                    			    	switch (alt1) 
                    			    	{
                    			    	    case 1 :
                    			    	        // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:22:37: calls+= call
                    			    	        {
                    			    	        	PushFollow(FOLLOW_call_in_statements133);
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
                    	// 23:9: -> ( $calls)*
                    	{
                    	    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:23:12: ( $calls)*
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
                    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:24:9: ( SEPARATOR )+ (calls+= call ( SEPARATOR (calls+= call )? )* )?
                    {
                    	// D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:24:9: ( SEPARATOR )+
                    	int cnt3 = 0;
                    	do 
                    	{
                    	    int alt3 = 2;
                    	    int LA3_0 = input.LA(1);

                    	    if ( (LA3_0 == SEPARATOR) )
                    	    {
                    	        alt3 = 1;
                    	    }


                    	    switch (alt3) 
                    		{
                    			case 1 :
                    			    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:24:9: SEPARATOR
                    			    {
                    			    	SEPARATOR3=(IToken)Match(input,SEPARATOR,FOLLOW_SEPARATOR_in_statements160);  
                    			    	stream_SEPARATOR.Add(SEPARATOR3);


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
                    		;	// Stops C# compiler whining that label 'loop3' has no statements

                    	// D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:24:20: (calls+= call ( SEPARATOR (calls+= call )? )* )?
                    	int alt6 = 2;
                    	int LA6_0 = input.LA(1);

                    	if ( ((LA6_0 >= NUMBER && LA6_0 <= IDENTIFIER) || LA6_0 == 17 || LA6_0 == 19 || LA6_0 == 21) )
                    	{
                    	    alt6 = 1;
                    	}
                    	switch (alt6) 
                    	{
                    	    case 1 :
                    	        // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:24:21: calls+= call ( SEPARATOR (calls+= call )? )*
                    	        {
                    	        	PushFollow(FOLLOW_call_in_statements166);
                    	        	calls = call();
                    	        	state.followingStackPointer--;

                    	        	stream_call.Add(calls.Tree);
                    	        	if (list_calls == null) list_calls = new ArrayList();
                    	        	list_calls.Add(calls.Tree);

                    	        	// D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:24:33: ( SEPARATOR (calls+= call )? )*
                    	        	do 
                    	        	{
                    	        	    int alt5 = 2;
                    	        	    int LA5_0 = input.LA(1);

                    	        	    if ( (LA5_0 == SEPARATOR) )
                    	        	    {
                    	        	        alt5 = 1;
                    	        	    }


                    	        	    switch (alt5) 
                    	        		{
                    	        			case 1 :
                    	        			    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:24:34: SEPARATOR (calls+= call )?
                    	        			    {
                    	        			    	SEPARATOR4=(IToken)Match(input,SEPARATOR,FOLLOW_SEPARATOR_in_statements169);  
                    	        			    	stream_SEPARATOR.Add(SEPARATOR4);

                    	        			    	// D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:24:49: (calls+= call )?
                    	        			    	int alt4 = 2;
                    	        			    	int LA4_0 = input.LA(1);

                    	        			    	if ( ((LA4_0 >= NUMBER && LA4_0 <= IDENTIFIER) || LA4_0 == 17 || LA4_0 == 19 || LA4_0 == 21) )
                    	        			    	{
                    	        			    	    alt4 = 1;
                    	        			    	}
                    	        			    	switch (alt4) 
                    	        			    	{
                    	        			    	    case 1 :
                    	        			    	        // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:24:49: calls+= call
                    	        			    	        {
                    	        			    	        	PushFollow(FOLLOW_call_in_statements173);
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
                    	// 25:9: -> ( $calls)*
                    	{
                    	    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:25:12: ( $calls)*
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
    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:28:1: expression : ( paren_expr | square_expr | curly_expr | atom );
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
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:29:5: ( paren_expr | square_expr | curly_expr | atom )
            int alt8 = 4;
            switch ( input.LA(1) ) 
            {
            case 21:
            	{
                alt8 = 1;
                }
                break;
            case 17:
            	{
                alt8 = 2;
                }
                break;
            case 19:
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
                    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:29:9: paren_expr
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_paren_expr_in_expression212);
                    	paren_expr5 = paren_expr();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, paren_expr5.Tree);

                    }
                    break;
                case 2 :
                    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:30:9: square_expr
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_square_expr_in_expression222);
                    	square_expr6 = square_expr();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, square_expr6.Tree);

                    }
                    break;
                case 3 :
                    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:31:9: curly_expr
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_curly_expr_in_expression232);
                    	curly_expr7 = curly_expr();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, curly_expr7.Tree);

                    }
                    break;
                case 4 :
                    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:32:9: atom
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_atom_in_expression242);
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
    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:36:1: square_expr : '[' datatype= atom ( SEPARATOR )* (exp+= expression ( SEPARATOR )* )* ']' -> ^( SQUARE $datatype ( $exp)* ) ;
    public BonsaiParser.square_expr_return square_expr() // throws RecognitionException [1]
    {   
        BonsaiParser.square_expr_return retval = new BonsaiParser.square_expr_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        IToken char_literal9 = null;
        IToken SEPARATOR10 = null;
        IToken SEPARATOR11 = null;
        IToken char_literal12 = null;
        IList list_exp = null;
        BonsaiParser.atom_return datatype = default(BonsaiParser.atom_return);

        BonsaiParser.expression_return exp = default(BonsaiParser.expression_return);
         exp = null;
        CommonTree char_literal9_tree=null;
        CommonTree SEPARATOR10_tree=null;
        CommonTree SEPARATOR11_tree=null;
        CommonTree char_literal12_tree=null;
        RewriteRuleTokenStream stream_SEPARATOR = new RewriteRuleTokenStream(adaptor,"token SEPARATOR");
        RewriteRuleTokenStream stream_17 = new RewriteRuleTokenStream(adaptor,"token 17");
        RewriteRuleTokenStream stream_18 = new RewriteRuleTokenStream(adaptor,"token 18");
        RewriteRuleSubtreeStream stream_expression = new RewriteRuleSubtreeStream(adaptor,"rule expression");
        RewriteRuleSubtreeStream stream_atom = new RewriteRuleSubtreeStream(adaptor,"rule atom");
        try 
    	{
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:39:5: ( '[' datatype= atom ( SEPARATOR )* (exp+= expression ( SEPARATOR )* )* ']' -> ^( SQUARE $datatype ( $exp)* ) )
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:39:9: '[' datatype= atom ( SEPARATOR )* (exp+= expression ( SEPARATOR )* )* ']'
            {
            	char_literal9=(IToken)Match(input,17,FOLLOW_17_in_square_expr266);  
            	stream_17.Add(char_literal9);

            	PushFollow(FOLLOW_atom_in_square_expr270);
            	datatype = atom();
            	state.followingStackPointer--;

            	stream_atom.Add(datatype.Tree);
            	// D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:39:27: ( SEPARATOR )*
            	do 
            	{
            	    int alt9 = 2;
            	    int LA9_0 = input.LA(1);

            	    if ( (LA9_0 == SEPARATOR) )
            	    {
            	        alt9 = 1;
            	    }


            	    switch (alt9) 
            		{
            			case 1 :
            			    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:39:27: SEPARATOR
            			    {
            			    	SEPARATOR10=(IToken)Match(input,SEPARATOR,FOLLOW_SEPARATOR_in_square_expr272);  
            			    	stream_SEPARATOR.Add(SEPARATOR10);


            			    }
            			    break;

            			default:
            			    goto loop9;
            	    }
            	} while (true);

            	loop9:
            		;	// Stops C# compiler whining that label 'loop9' has no statements

            	// D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:39:38: (exp+= expression ( SEPARATOR )* )*
            	do 
            	{
            	    int alt11 = 2;
            	    int LA11_0 = input.LA(1);

            	    if ( ((LA11_0 >= NUMBER && LA11_0 <= IDENTIFIER) || LA11_0 == 17 || LA11_0 == 19 || LA11_0 == 21) )
            	    {
            	        alt11 = 1;
            	    }


            	    switch (alt11) 
            		{
            			case 1 :
            			    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:39:39: exp+= expression ( SEPARATOR )*
            			    {
            			    	PushFollow(FOLLOW_expression_in_square_expr278);
            			    	exp = expression();
            			    	state.followingStackPointer--;

            			    	stream_expression.Add(exp.Tree);
            			    	if (list_exp == null) list_exp = new ArrayList();
            			    	list_exp.Add(exp.Tree);

            			    	// D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:39:55: ( SEPARATOR )*
            			    	do 
            			    	{
            			    	    int alt10 = 2;
            			    	    int LA10_0 = input.LA(1);

            			    	    if ( (LA10_0 == SEPARATOR) )
            			    	    {
            			    	        alt10 = 1;
            			    	    }


            			    	    switch (alt10) 
            			    		{
            			    			case 1 :
            			    			    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:39:55: SEPARATOR
            			    			    {
            			    			    	SEPARATOR11=(IToken)Match(input,SEPARATOR,FOLLOW_SEPARATOR_in_square_expr280);  
            			    			    	stream_SEPARATOR.Add(SEPARATOR11);


            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop10;
            			    	    }
            			    	} while (true);

            			    	loop10:
            			    		;	// Stops C# compiler whining that label 'loop10' has no statements


            			    }
            			    break;

            			default:
            			    goto loop11;
            	    }
            	} while (true);

            	loop11:
            		;	// Stops C# compiler whining that label 'loop11' has no statements

            	char_literal12=(IToken)Match(input,18,FOLLOW_18_in_square_expr285);  
            	stream_18.Add(char_literal12);



            	// AST REWRITE
            	// elements:          exp, datatype
            	// token labels:      
            	// rule labels:       retval, datatype
            	// token list labels: 
            	// rule list labels:  exp
            	// wildcard labels: 
            	retval.Tree = root_0;
            	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "rule retval", retval!=null ? retval.Tree : null);
            	RewriteRuleSubtreeStream stream_datatype = new RewriteRuleSubtreeStream(adaptor, "rule datatype", datatype!=null ? datatype.Tree : null);
            	RewriteRuleSubtreeStream stream_exp = new RewriteRuleSubtreeStream(adaptor, "token exp", list_exp);
            	root_0 = (CommonTree)adaptor.GetNilNode();
            	// 39:72: -> ^( SQUARE $datatype ( $exp)* )
            	{
            	    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:39:75: ^( SQUARE $datatype ( $exp)* )
            	    {
            	    CommonTree root_1 = (CommonTree)adaptor.GetNilNode();
            	    root_1 = (CommonTree)adaptor.BecomeRoot((CommonTree)adaptor.Create(SQUARE, "SQUARE"), root_1);

            	    adaptor.AddChild(root_1, stream_datatype.NextTree());
            	    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:39:94: ( $exp)*
            	    while ( stream_exp.HasNext() )
            	    {
            	        adaptor.AddChild(root_1, stream_exp.NextTree());

            	    }
            	    stream_exp.Reset();

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
    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:41:1: curly_expr : '{' ( statements )? '}' -> ^( BLOCK statements ) ;
    public BonsaiParser.curly_expr_return curly_expr() // throws RecognitionException [1]
    {   
        BonsaiParser.curly_expr_return retval = new BonsaiParser.curly_expr_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        IToken char_literal13 = null;
        IToken char_literal15 = null;
        BonsaiParser.statements_return statements14 = default(BonsaiParser.statements_return);


        CommonTree char_literal13_tree=null;
        CommonTree char_literal15_tree=null;
        RewriteRuleTokenStream stream_20 = new RewriteRuleTokenStream(adaptor,"token 20");
        RewriteRuleTokenStream stream_19 = new RewriteRuleTokenStream(adaptor,"token 19");
        RewriteRuleSubtreeStream stream_statements = new RewriteRuleSubtreeStream(adaptor,"rule statements");
        try 
    	{
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:42:5: ( '{' ( statements )? '}' -> ^( BLOCK statements ) )
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:42:9: '{' ( statements )? '}'
            {
            	char_literal13=(IToken)Match(input,19,FOLLOW_19_in_curly_expr316);  
            	stream_19.Add(char_literal13);

            	// D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:42:13: ( statements )?
            	int alt12 = 2;
            	int LA12_0 = input.LA(1);

            	if ( ((LA12_0 >= SEPARATOR && LA12_0 <= IDENTIFIER) || LA12_0 == 17 || LA12_0 == 19 || LA12_0 == 21) )
            	{
            	    alt12 = 1;
            	}
            	switch (alt12) 
            	{
            	    case 1 :
            	        // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:42:13: statements
            	        {
            	        	PushFollow(FOLLOW_statements_in_curly_expr318);
            	        	statements14 = statements();
            	        	state.followingStackPointer--;

            	        	stream_statements.Add(statements14.Tree);

            	        }
            	        break;

            	}

            	char_literal15=(IToken)Match(input,20,FOLLOW_20_in_curly_expr321);  
            	stream_20.Add(char_literal15);



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
            	// 42:29: -> ^( BLOCK statements )
            	{
            	    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:42:32: ^( BLOCK statements )
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
    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:46:1: paren_expr : '(' ( statements )? ')' -> ^( GROUP statements ) ;
    public BonsaiParser.paren_expr_return paren_expr() // throws RecognitionException [1]
    {   
        BonsaiParser.paren_expr_return retval = new BonsaiParser.paren_expr_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        IToken char_literal16 = null;
        IToken char_literal18 = null;
        BonsaiParser.statements_return statements17 = default(BonsaiParser.statements_return);


        CommonTree char_literal16_tree=null;
        CommonTree char_literal18_tree=null;
        RewriteRuleTokenStream stream_21 = new RewriteRuleTokenStream(adaptor,"token 21");
        RewriteRuleTokenStream stream_22 = new RewriteRuleTokenStream(adaptor,"token 22");
        RewriteRuleSubtreeStream stream_statements = new RewriteRuleSubtreeStream(adaptor,"rule statements");
        try 
    	{
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:47:5: ( '(' ( statements )? ')' -> ^( GROUP statements ) )
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:47:9: '(' ( statements )? ')'
            {
            	char_literal16=(IToken)Match(input,21,FOLLOW_21_in_paren_expr349);  
            	stream_21.Add(char_literal16);

            	// D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:47:13: ( statements )?
            	int alt13 = 2;
            	int LA13_0 = input.LA(1);

            	if ( ((LA13_0 >= SEPARATOR && LA13_0 <= IDENTIFIER) || LA13_0 == 17 || LA13_0 == 19 || LA13_0 == 21) )
            	{
            	    alt13 = 1;
            	}
            	switch (alt13) 
            	{
            	    case 1 :
            	        // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:47:13: statements
            	        {
            	        	PushFollow(FOLLOW_statements_in_paren_expr351);
            	        	statements17 = statements();
            	        	state.followingStackPointer--;

            	        	stream_statements.Add(statements17.Tree);

            	        }
            	        break;

            	}

            	char_literal18=(IToken)Match(input,22,FOLLOW_22_in_paren_expr354);  
            	stream_22.Add(char_literal18);



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
            	// 47:29: -> ^( GROUP statements )
            	{
            	    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:47:32: ^( GROUP statements )
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
    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:50:1: call : target= expression (args= arguments ) -> ^( CALL $target ( $args)* ) ;
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
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:51:5: (target= expression (args= arguments ) -> ^( CALL $target ( $args)* ) )
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:51:9: target= expression (args= arguments )
            {
            	PushFollow(FOLLOW_expression_in_call383);
            	target = expression();
            	state.followingStackPointer--;

            	stream_expression.Add(target.Tree);
            	// D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:51:27: (args= arguments )
            	// D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:51:28: args= arguments
            	{
            		PushFollow(FOLLOW_arguments_in_call388);
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
            	// 52:9: -> ^( CALL $target ( $args)* )
            	{
            	    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:52:13: ^( CALL $target ( $args)* )
            	    {
            	    CommonTree root_1 = (CommonTree)adaptor.GetNilNode();
            	    root_1 = (CommonTree)adaptor.BecomeRoot((CommonTree)adaptor.Create(CALL, "CALL"), root_1);

            	    adaptor.AddChild(root_1, stream_target.NextTree());
            	    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:52:28: ( $args)*
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
    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:55:1: arguments : ( expression )* ;
    public BonsaiParser.arguments_return arguments() // throws RecognitionException [1]
    {   
        BonsaiParser.arguments_return retval = new BonsaiParser.arguments_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        BonsaiParser.expression_return expression19 = default(BonsaiParser.expression_return);



        try 
    	{
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:56:5: ( ( expression )* )
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:56:9: ( expression )*
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	// D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:56:9: ( expression )*
            	do 
            	{
            	    int alt14 = 2;
            	    int LA14_0 = input.LA(1);

            	    if ( ((LA14_0 >= NUMBER && LA14_0 <= IDENTIFIER) || LA14_0 == 17 || LA14_0 == 19 || LA14_0 == 21) )
            	    {
            	        alt14 = 1;
            	    }


            	    switch (alt14) 
            		{
            			case 1 :
            			    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:56:9: expression
            			    {
            			    	PushFollow(FOLLOW_expression_in_arguments435);
            			    	expression19 = expression();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, expression19.Tree);

            			    }
            			    break;

            			default:
            			    goto loop14;
            	    }
            	} while (true);

            	loop14:
            		;	// Stops C# compiler whining that label 'loop14' has no statements


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
    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:59:1: atom : ( NUMBER | STRING | SYMBOL | IDENTIFIER );
    public BonsaiParser.atom_return atom() // throws RecognitionException [1]
    {   
        BonsaiParser.atom_return retval = new BonsaiParser.atom_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        IToken set20 = null;

        CommonTree set20_tree=null;

        try 
    	{
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:60:5: ( NUMBER | STRING | SYMBOL | IDENTIFIER )
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	set20 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= NUMBER && input.LA(1) <= IDENTIFIER) ) 
            	{
            	    input.Consume();
            	    adaptor.AddChild(root_0, (CommonTree)adaptor.Create(set20));
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

 

    public static readonly BitSet FOLLOW_statements_in_program97 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_call_in_statements126 = new BitSet(new ulong[]{0x0000000000000102UL});
    public static readonly BitSet FOLLOW_SEPARATOR_in_statements129 = new BitSet(new ulong[]{0x00000000002A1F02UL});
    public static readonly BitSet FOLLOW_call_in_statements133 = new BitSet(new ulong[]{0x0000000000000102UL});
    public static readonly BitSet FOLLOW_SEPARATOR_in_statements160 = new BitSet(new ulong[]{0x00000000002A1F02UL});
    public static readonly BitSet FOLLOW_call_in_statements166 = new BitSet(new ulong[]{0x0000000000000102UL});
    public static readonly BitSet FOLLOW_SEPARATOR_in_statements169 = new BitSet(new ulong[]{0x00000000002A1F02UL});
    public static readonly BitSet FOLLOW_call_in_statements173 = new BitSet(new ulong[]{0x0000000000000102UL});
    public static readonly BitSet FOLLOW_paren_expr_in_expression212 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_square_expr_in_expression222 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_curly_expr_in_expression232 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_atom_in_expression242 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_17_in_square_expr266 = new BitSet(new ulong[]{0x00000000002A1E00UL});
    public static readonly BitSet FOLLOW_atom_in_square_expr270 = new BitSet(new ulong[]{0x00000000002E1F00UL});
    public static readonly BitSet FOLLOW_SEPARATOR_in_square_expr272 = new BitSet(new ulong[]{0x00000000002E1F00UL});
    public static readonly BitSet FOLLOW_expression_in_square_expr278 = new BitSet(new ulong[]{0x00000000002E1F00UL});
    public static readonly BitSet FOLLOW_SEPARATOR_in_square_expr280 = new BitSet(new ulong[]{0x00000000002E1F00UL});
    public static readonly BitSet FOLLOW_18_in_square_expr285 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_19_in_curly_expr316 = new BitSet(new ulong[]{0x00000000003A1F00UL});
    public static readonly BitSet FOLLOW_statements_in_curly_expr318 = new BitSet(new ulong[]{0x0000000000100000UL});
    public static readonly BitSet FOLLOW_20_in_curly_expr321 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_21_in_paren_expr349 = new BitSet(new ulong[]{0x00000000006A1F00UL});
    public static readonly BitSet FOLLOW_statements_in_paren_expr351 = new BitSet(new ulong[]{0x0000000000400000UL});
    public static readonly BitSet FOLLOW_22_in_paren_expr354 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_expression_in_call383 = new BitSet(new ulong[]{0x00000000002A1E00UL});
    public static readonly BitSet FOLLOW_arguments_in_call388 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_expression_in_arguments435 = new BitSet(new ulong[]{0x00000000002A1E02UL});
    public static readonly BitSet FOLLOW_set_in_atom0 = new BitSet(new ulong[]{0x0000000000000002UL});

}
}