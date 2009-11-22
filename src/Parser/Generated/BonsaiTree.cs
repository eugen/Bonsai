// $ANTLR 3.2 Sep 23, 2009 12:02:23 D:\\Projects\\Bonsai\\src\\Grammars\\BonsaiTree.g 2009-11-21 19:04:54

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162

 
    using Bonsai.Ast;
    using System.Collections.Generic;


using System;
using Antlr.Runtime;
using Antlr.Runtime.Tree;using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;



namespace  Bonsai.Ast.Generated 
{
public partial class BonsaiTree : TreeParser
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
		"'{'", 
		"'}'", 
		"'['", 
		"']'", 
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



        public BonsaiTree(ITreeNodeStream input)
    		: this(input, new RecognizerSharedState()) {
        }

        public BonsaiTree(ITreeNodeStream input, RecognizerSharedState state)
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
		get { return BonsaiTree.tokenNames; }
    }

    override public string GrammarFileName {
		get { return "D:\\Projects\\Bonsai\\src\\Grammars\\BonsaiTree.g"; }
    }


    public class program_return : TreeRuleReturnScope
    {
        public Sequence result;
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "program"
    // D:\\Projects\\Bonsai\\src\\Grammars\\BonsaiTree.g:17:1: program returns [Sequence result] : ^( GROUP (c= call )* ) ;
    public BonsaiTree.program_return program() // throws RecognitionException [1]
    {   
        BonsaiTree.program_return retval = new BonsaiTree.program_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree GROUP1 = null;
        BonsaiTree.call_return c = default(BonsaiTree.call_return);


        CommonTree GROUP1_tree=null;

        try 
    	{
            // D:\\Projects\\Bonsai\\src\\Grammars\\BonsaiTree.g:18:5: ( ^( GROUP (c= call )* ) )
            // D:\\Projects\\Bonsai\\src\\Grammars\\BonsaiTree.g:18:7: ^( GROUP (c= call )* )
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	_last = (CommonTree)input.LT(1);
            	{
            	CommonTree _save_last_1 = _last;
            	CommonTree _first_1 = null;
            	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	GROUP1=(CommonTree)Match(input,GROUP,FOLLOW_GROUP_in_program76); 
            		GROUP1_tree = (CommonTree)adaptor.DupNode(GROUP1);

            		root_1 = (CommonTree)adaptor.BecomeRoot(GROUP1_tree, root_1);


            	 retval.result =  new Sequence(); 

            	if ( input.LA(1) == Token.DOWN )
            	{
            	    Match(input, Token.DOWN, null); 
            	    // D:\\Projects\\Bonsai\\src\\Grammars\\BonsaiTree.g:20:13: (c= call )*
            	    do 
            	    {
            	        int alt1 = 2;
            	        int LA1_0 = input.LA(1);

            	        if ( (LA1_0 == CALL) )
            	        {
            	            alt1 = 1;
            	        }


            	        switch (alt1) 
            	    	{
            	    		case 1 :
            	    		    // D:\\Projects\\Bonsai\\src\\Grammars\\BonsaiTree.g:20:14: c= call
            	    		    {
            	    		    	_last = (CommonTree)input.LT(1);
            	    		    	PushFollow(FOLLOW_call_in_program107);
            	    		    	c = call();
            	    		    	state.followingStackPointer--;

            	    		    	adaptor.AddChild(root_1, c.Tree);
            	    		    	 retval.result.Statements.Add(c.result); 

            	    		    }
            	    		    break;

            	    		default:
            	    		    goto loop1;
            	        }
            	    } while (true);

            	    loop1:
            	    	;	// Stops C# compiler whining that label 'loop1' has no statements


            	    Match(input, Token.UP, null); 
            	}adaptor.AddChild(root_0, root_1);_last = _save_last_1;
            	}


            }

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "program"

    public class call_return : TreeRuleReturnScope
    {
        public Call result;
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "call"
    // D:\\Projects\\Bonsai\\src\\Grammars\\BonsaiTree.g:23:1: call returns [Call result] : ^( CALL target= expression (a= expression )* ) ;
    public BonsaiTree.call_return call() // throws RecognitionException [1]
    {   
        BonsaiTree.call_return retval = new BonsaiTree.call_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree CALL2 = null;
        BonsaiTree.expression_return target = default(BonsaiTree.expression_return);

        BonsaiTree.expression_return a = default(BonsaiTree.expression_return);


        CommonTree CALL2_tree=null;

        try 
    	{
            // D:\\Projects\\Bonsai\\src\\Grammars\\BonsaiTree.g:24:5: ( ^( CALL target= expression (a= expression )* ) )
            // D:\\Projects\\Bonsai\\src\\Grammars\\BonsaiTree.g:24:7: ^( CALL target= expression (a= expression )* )
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	_last = (CommonTree)input.LT(1);
            	{
            	CommonTree _save_last_1 = _last;
            	CommonTree _first_1 = null;
            	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	CALL2=(CommonTree)Match(input,CALL,FOLLOW_CALL_in_call134); 
            		CALL2_tree = (CommonTree)adaptor.DupNode(CALL2);

            		root_1 = (CommonTree)adaptor.BecomeRoot(CALL2_tree, root_1);


            	 retval.result =  new Call(); 

            	Match(input, Token.DOWN, null); 
            	_last = (CommonTree)input.LT(1);
            	PushFollow(FOLLOW_expression_in_call152);
            	target = expression();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_1, target.Tree);
            	 retval.result.Target = target.result; 
            	// D:\\Projects\\Bonsai\\src\\Grammars\\BonsaiTree.g:26:13: (a= expression )*
            	do 
            	{
            	    int alt2 = 2;
            	    int LA2_0 = input.LA(1);

            	    if ( ((LA2_0 >= GROUP && LA2_0 <= SQUARE) || (LA2_0 >= NUMBER && LA2_0 <= IDENTIFIER)) )
            	    {
            	        alt2 = 1;
            	    }


            	    switch (alt2) 
            		{
            			case 1 :
            			    // D:\\Projects\\Bonsai\\src\\Grammars\\BonsaiTree.g:26:14: a= expression
            			    {
            			    	_last = (CommonTree)input.LT(1);
            			    	PushFollow(FOLLOW_expression_in_call171);
            			    	a = expression();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_1, a.Tree);
            			    	 retval.result.Arguments.Add(a.result); 

            			    }
            			    break;

            			default:
            			    goto loop2;
            	    }
            	} while (true);

            	loop2:
            		;	// Stops C# compiler whining that label 'loop2' has no statements


            	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
            	}


            }

            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "call"

    public class expression_return : TreeRuleReturnScope
    {
        public Expression result;
        private CommonTree tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (CommonTree) value; }
        }
    };

    // $ANTLR start "expression"
    // D:\\Projects\\Bonsai\\src\\Grammars\\BonsaiTree.g:29:1: expression returns [Expression result] : ( ^( GROUP (c= call )* ) | ^( BLOCK (c= call )* ) | ^( SQUARE datatype= IDENTIFIER (e= expression )* ) | number= NUMBER | str= STRING | str= IDENTIFIER | str= SYMBOL );
    public BonsaiTree.expression_return expression() // throws RecognitionException [1]
    {   
        BonsaiTree.expression_return retval = new BonsaiTree.expression_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree datatype = null;
        CommonTree number = null;
        CommonTree str = null;
        CommonTree GROUP3 = null;
        CommonTree BLOCK4 = null;
        CommonTree SQUARE5 = null;
        BonsaiTree.call_return c = default(BonsaiTree.call_return);

        BonsaiTree.expression_return e = default(BonsaiTree.expression_return);


        CommonTree datatype_tree=null;
        CommonTree number_tree=null;
        CommonTree str_tree=null;
        CommonTree GROUP3_tree=null;
        CommonTree BLOCK4_tree=null;
        CommonTree SQUARE5_tree=null;

        try 
    	{
            // D:\\Projects\\Bonsai\\src\\Grammars\\BonsaiTree.g:30:5: ( ^( GROUP (c= call )* ) | ^( BLOCK (c= call )* ) | ^( SQUARE datatype= IDENTIFIER (e= expression )* ) | number= NUMBER | str= STRING | str= IDENTIFIER | str= SYMBOL )
            int alt6 = 7;
            switch ( input.LA(1) ) 
            {
            case GROUP:
            	{
                alt6 = 1;
                }
                break;
            case BLOCK:
            	{
                alt6 = 2;
                }
                break;
            case SQUARE:
            	{
                alt6 = 3;
                }
                break;
            case NUMBER:
            	{
                alt6 = 4;
                }
                break;
            case STRING:
            	{
                alt6 = 5;
                }
                break;
            case IDENTIFIER:
            	{
                alt6 = 6;
                }
                break;
            case SYMBOL:
            	{
                alt6 = 7;
                }
                break;
            	default:
            	    NoViableAltException nvae_d6s0 =
            	        new NoViableAltException("", 6, 0, input);

            	    throw nvae_d6s0;
            }

            switch (alt6) 
            {
                case 1 :
                    // D:\\Projects\\Bonsai\\src\\Grammars\\BonsaiTree.g:30:7: ^( GROUP (c= call )* )
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	{
                    	CommonTree _save_last_1 = _last;
                    	CommonTree _first_1 = null;
                    	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
                    	GROUP3=(CommonTree)Match(input,GROUP,FOLLOW_GROUP_in_expression198); 
                    		GROUP3_tree = (CommonTree)adaptor.DupNode(GROUP3);

                    		root_1 = (CommonTree)adaptor.BecomeRoot(GROUP3_tree, root_1);


                    	 retval.result =  new Sequence(); 

                    	if ( input.LA(1) == Token.DOWN )
                    	{
                    	    Match(input, Token.DOWN, null); 
                    	    // D:\\Projects\\Bonsai\\src\\Grammars\\BonsaiTree.g:32:13: (c= call )*
                    	    do 
                    	    {
                    	        int alt3 = 2;
                    	        int LA3_0 = input.LA(1);

                    	        if ( (LA3_0 == CALL) )
                    	        {
                    	            alt3 = 1;
                    	        }


                    	        switch (alt3) 
                    	    	{
                    	    		case 1 :
                    	    		    // D:\\Projects\\Bonsai\\src\\Grammars\\BonsaiTree.g:32:14: c= call
                    	    		    {
                    	    		    	_last = (CommonTree)input.LT(1);
                    	    		    	PushFollow(FOLLOW_call_in_expression229);
                    	    		    	c = call();
                    	    		    	state.followingStackPointer--;

                    	    		    	adaptor.AddChild(root_1, c.Tree);
                    	    		    	 ((Sequence)retval.result).Statements.Add(c.result); 

                    	    		    }
                    	    		    break;

                    	    		default:
                    	    		    goto loop3;
                    	        }
                    	    } while (true);

                    	    loop3:
                    	    	;	// Stops C# compiler whining that label 'loop3' has no statements


                    	    Match(input, Token.UP, null); 
                    	}adaptor.AddChild(root_0, root_1);_last = _save_last_1;
                    	}


                    }
                    break;
                case 2 :
                    // D:\\Projects\\Bonsai\\src\\Grammars\\BonsaiTree.g:33:7: ^( BLOCK (c= call )* )
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	{
                    	CommonTree _save_last_1 = _last;
                    	CommonTree _first_1 = null;
                    	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
                    	BLOCK4=(CommonTree)Match(input,BLOCK,FOLLOW_BLOCK_in_expression243); 
                    		BLOCK4_tree = (CommonTree)adaptor.DupNode(BLOCK4);

                    		root_1 = (CommonTree)adaptor.BecomeRoot(BLOCK4_tree, root_1);


                    	 retval.result =  new Block(); 

                    	if ( input.LA(1) == Token.DOWN )
                    	{
                    	    Match(input, Token.DOWN, null); 
                    	    // D:\\Projects\\Bonsai\\src\\Grammars\\BonsaiTree.g:35:13: (c= call )*
                    	    do 
                    	    {
                    	        int alt4 = 2;
                    	        int LA4_0 = input.LA(1);

                    	        if ( (LA4_0 == CALL) )
                    	        {
                    	            alt4 = 1;
                    	        }


                    	        switch (alt4) 
                    	    	{
                    	    		case 1 :
                    	    		    // D:\\Projects\\Bonsai\\src\\Grammars\\BonsaiTree.g:35:14: c= call
                    	    		    {
                    	    		    	_last = (CommonTree)input.LT(1);
                    	    		    	PushFollow(FOLLOW_call_in_expression274);
                    	    		    	c = call();
                    	    		    	state.followingStackPointer--;

                    	    		    	adaptor.AddChild(root_1, c.Tree);
                    	    		    	 ((Block)retval.result).Statements.Add(c.result); 

                    	    		    }
                    	    		    break;

                    	    		default:
                    	    		    goto loop4;
                    	        }
                    	    } while (true);

                    	    loop4:
                    	    	;	// Stops C# compiler whining that label 'loop4' has no statements


                    	    Match(input, Token.UP, null); 
                    	}adaptor.AddChild(root_0, root_1);_last = _save_last_1;
                    	}


                    }
                    break;
                case 3 :
                    // D:\\Projects\\Bonsai\\src\\Grammars\\BonsaiTree.g:36:7: ^( SQUARE datatype= IDENTIFIER (e= expression )* )
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	{
                    	CommonTree _save_last_1 = _last;
                    	CommonTree _first_1 = null;
                    	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
                    	SQUARE5=(CommonTree)Match(input,SQUARE,FOLLOW_SQUARE_in_expression288); 
                    		SQUARE5_tree = (CommonTree)adaptor.DupNode(SQUARE5);

                    		root_1 = (CommonTree)adaptor.BecomeRoot(SQUARE5_tree, root_1);


                    	 retval.result =  new DataDecl(); 

                    	Match(input, Token.DOWN, null); 
                    	_last = (CommonTree)input.LT(1);
                    	datatype=(CommonTree)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_expression307); 
                    		datatype_tree = (CommonTree)adaptor.DupNode(datatype);

                    		adaptor.AddChild(root_1, datatype_tree);

                    	 ((DataDecl)retval.result).DataTypeId = datatype.Text; 
                    	// D:\\Projects\\Bonsai\\src\\Grammars\\BonsaiTree.g:39:7: (e= expression )*
                    	do 
                    	{
                    	    int alt5 = 2;
                    	    int LA5_0 = input.LA(1);

                    	    if ( ((LA5_0 >= GROUP && LA5_0 <= SQUARE) || (LA5_0 >= NUMBER && LA5_0 <= IDENTIFIER)) )
                    	    {
                    	        alt5 = 1;
                    	    }


                    	    switch (alt5) 
                    		{
                    			case 1 :
                    			    // D:\\Projects\\Bonsai\\src\\Grammars\\BonsaiTree.g:39:8: e= expression
                    			    {
                    			    	_last = (CommonTree)input.LT(1);
                    			    	PushFollow(FOLLOW_expression_in_expression320);
                    			    	e = expression();
                    			    	state.followingStackPointer--;

                    			    	adaptor.AddChild(root_1, e.Tree);
                    			    	 ((DataDecl)retval.result).Expressions.Add(e.result); 

                    			    }
                    			    break;

                    			default:
                    			    goto loop5;
                    	    }
                    	} while (true);

                    	loop5:
                    		;	// Stops C# compiler whining that label 'loop5' has no statements


                    	Match(input, Token.UP, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
                    	}


                    }
                    break;
                case 4 :
                    // D:\\Projects\\Bonsai\\src\\Grammars\\BonsaiTree.g:40:7: number= NUMBER
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	number=(CommonTree)Match(input,NUMBER,FOLLOW_NUMBER_in_expression335); 
                    		number_tree = (CommonTree)adaptor.DupNode(number);

                    		adaptor.AddChild(root_0, number_tree);

                    	 retval.result =  new Number() { Value = decimal.Parse(number.Text) }; 

                    }
                    break;
                case 5 :
                    // D:\\Projects\\Bonsai\\src\\Grammars\\BonsaiTree.g:42:7: str= STRING
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	str=(CommonTree)Match(input,STRING,FOLLOW_STRING_in_expression355); 
                    		str_tree = (CommonTree)adaptor.DupNode(str);

                    		adaptor.AddChild(root_0, str_tree);


                    	            retval.result =  new Bonsai.Ast.String()
                    	            { Value = str.Text.Substring(1, str.Text.Length - 2) }; 

                    }
                    break;
                case 6 :
                    // D:\\Projects\\Bonsai\\src\\Grammars\\BonsaiTree.g:45:7: str= IDENTIFIER
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	str=(CommonTree)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_expression367); 
                    		str_tree = (CommonTree)adaptor.DupNode(str);

                    		adaptor.AddChild(root_0, str_tree);

                    	 retval.result =  new Reference() { Name = str.Text }; 

                    }
                    break;
                case 7 :
                    // D:\\Projects\\Bonsai\\src\\Grammars\\BonsaiTree.g:46:7: str= SYMBOL
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	str=(CommonTree)Match(input,SYMBOL,FOLLOW_SYMBOL_in_expression379); 
                    		str_tree = (CommonTree)adaptor.DupNode(str);

                    		adaptor.AddChild(root_0, str_tree);

                    	 retval.result =  new Symbol() { Name = str.Text.Substring(1) }; 

                    }
                    break;

            }
            	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "expression"

    // Delegated rules


	private void InitializeCyclicDFAs()
	{
	}

 

    public static readonly BitSet FOLLOW_GROUP_in_program76 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_call_in_program107 = new BitSet(new ulong[]{0x0000000000000018UL});
    public static readonly BitSet FOLLOW_CALL_in_call134 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_expression_in_call152 = new BitSet(new ulong[]{0x0000000000001EE8UL});
    public static readonly BitSet FOLLOW_expression_in_call171 = new BitSet(new ulong[]{0x0000000000001EE8UL});
    public static readonly BitSet FOLLOW_GROUP_in_expression198 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_call_in_expression229 = new BitSet(new ulong[]{0x0000000000000018UL});
    public static readonly BitSet FOLLOW_BLOCK_in_expression243 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_call_in_expression274 = new BitSet(new ulong[]{0x0000000000000018UL});
    public static readonly BitSet FOLLOW_SQUARE_in_expression288 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_expression307 = new BitSet(new ulong[]{0x0000000000001EE8UL});
    public static readonly BitSet FOLLOW_expression_in_expression320 = new BitSet(new ulong[]{0x0000000000001EE8UL});
    public static readonly BitSet FOLLOW_NUMBER_in_expression335 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_STRING_in_expression355 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_expression367 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_SYMBOL_in_expression379 = new BitSet(new ulong[]{0x0000000000000002UL});

}
}