// $ANTLR 3.1.2 C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\BonsaiTree.g 2009-06-25 21:22:39

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162
namespace  Bonsai.Ast.Generated
{
 
	using Bonsai.Ast;
    using System.Collections.Generic;


using System;
using Antlr.Runtime;
using Antlr.Runtime.Tree;using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;



partial class BonsaiTree : TreeParser
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
		get { return "C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\BonsaiTree.g"; }
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
    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\BonsaiTree.g:17:1: program returns [Sequence result] : ^( GROUP (c= call )* ) ;
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
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\BonsaiTree.g:18:5: ( ^( GROUP (c= call )* ) )
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\BonsaiTree.g:18:7: ^( GROUP (c= call )* )
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	_last = (CommonTree)input.LT(1);
            	{
            	CommonTree _save_last_1 = _last;
            	CommonTree _first_1 = null;
            	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	GROUP1=(CommonTree)Match(input,GROUP,FOLLOW_GROUP_in_program64); 
            		GROUP1_tree = (CommonTree)adaptor.DupNode(GROUP1);

            		root_1 = (CommonTree)adaptor.BecomeRoot(GROUP1_tree, root_1);


            	 retval.result =  new Sequence(); 

            	if ( input.LA(1) == Token.DOWN )
            	{
            	    Match(input, Token.DOWN, null); 
            	    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\BonsaiTree.g:18:45: (c= call )*
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
            	    		    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\BonsaiTree.g:18:46: c= call
            	    		    {
            	    		    	_last = (CommonTree)input.LT(1);
            	    		    	PushFollow(FOLLOW_call_in_program71);
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
    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\BonsaiTree.g:21:1: call returns [Call result] : ^( CALL target= expression (a= expression )* ) ;
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
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\BonsaiTree.g:22:5: ( ^( CALL target= expression (a= expression )* ) )
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\BonsaiTree.g:22:7: ^( CALL target= expression (a= expression )* )
            {
            	root_0 = (CommonTree)adaptor.GetNilNode();

            	_last = (CommonTree)input.LT(1);
            	{
            	CommonTree _save_last_1 = _last;
            	CommonTree _first_1 = null;
            	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
            	CALL2=(CommonTree)Match(input,CALL,FOLLOW_CALL_in_call98); 
            		CALL2_tree = (CommonTree)adaptor.DupNode(CALL2);

            		root_1 = (CommonTree)adaptor.BecomeRoot(CALL2_tree, root_1);


            	 retval.result =  new Call(); 

            	Match(input, Token.DOWN, null); 
            	_last = (CommonTree)input.LT(1);
            	PushFollow(FOLLOW_expression_in_call116);
            	target = expression();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_1, target.Tree);
            	 retval.result.Target = target.result; 
            	// C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\BonsaiTree.g:24:13: (a= expression )*
            	do 
            	{
            	    int alt2 = 2;
            	    int LA2_0 = input.LA(1);

            	    if ( ((LA2_0 >= GROUP && LA2_0 <= BLOCK) || (LA2_0 >= NUMBER && LA2_0 <= IDENTIFIER)) )
            	    {
            	        alt2 = 1;
            	    }


            	    switch (alt2) 
            		{
            			case 1 :
            			    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\BonsaiTree.g:24:14: a= expression
            			    {
            			    	_last = (CommonTree)input.LT(1);
            			    	PushFollow(FOLLOW_expression_in_call135);
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
    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\BonsaiTree.g:27:1: expression returns [Expression result] : ( ^( GROUP (c= call )* ) | ^( BLOCK (c= call )* ) | number= NUMBER | str= STRING | str= IDENTIFIER | str= SYMBOL );
    public BonsaiTree.expression_return expression() // throws RecognitionException [1]
    {   
        BonsaiTree.expression_return retval = new BonsaiTree.expression_return();
        retval.Start = input.LT(1);

        CommonTree root_0 = null;

        CommonTree _first_0 = null;
        CommonTree _last = null;

        CommonTree number = null;
        CommonTree str = null;
        CommonTree GROUP3 = null;
        CommonTree BLOCK4 = null;
        BonsaiTree.call_return c = default(BonsaiTree.call_return);


        CommonTree number_tree=null;
        CommonTree str_tree=null;
        CommonTree GROUP3_tree=null;
        CommonTree BLOCK4_tree=null;

        try 
    	{
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\BonsaiTree.g:28:5: ( ^( GROUP (c= call )* ) | ^( BLOCK (c= call )* ) | number= NUMBER | str= STRING | str= IDENTIFIER | str= SYMBOL )
            int alt5 = 6;
            switch ( input.LA(1) ) 
            {
            case GROUP:
            	{
                alt5 = 1;
                }
                break;
            case BLOCK:
            	{
                alt5 = 2;
                }
                break;
            case NUMBER:
            	{
                alt5 = 3;
                }
                break;
            case STRING:
            	{
                alt5 = 4;
                }
                break;
            case IDENTIFIER:
            	{
                alt5 = 5;
                }
                break;
            case SYMBOL:
            	{
                alt5 = 6;
                }
                break;
            	default:
            	    NoViableAltException nvae_d5s0 =
            	        new NoViableAltException("", 5, 0, input);

            	    throw nvae_d5s0;
            }

            switch (alt5) 
            {
                case 1 :
                    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\BonsaiTree.g:28:7: ^( GROUP (c= call )* )
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	{
                    	CommonTree _save_last_1 = _last;
                    	CommonTree _first_1 = null;
                    	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
                    	GROUP3=(CommonTree)Match(input,GROUP,FOLLOW_GROUP_in_expression162); 
                    		GROUP3_tree = (CommonTree)adaptor.DupNode(GROUP3);

                    		root_1 = (CommonTree)adaptor.BecomeRoot(GROUP3_tree, root_1);


                    	 retval.result =  new Sequence(); 

                    	if ( input.LA(1) == Token.DOWN )
                    	{
                    	    Match(input, Token.DOWN, null); 
                    	    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\BonsaiTree.g:28:45: (c= call )*
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
                    	    		    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\BonsaiTree.g:28:46: c= call
                    	    		    {
                    	    		    	_last = (CommonTree)input.LT(1);
                    	    		    	PushFollow(FOLLOW_call_in_expression169);
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
                    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\BonsaiTree.g:29:7: ^( BLOCK (c= call )* )
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	{
                    	CommonTree _save_last_1 = _last;
                    	CommonTree _first_1 = null;
                    	CommonTree root_1 = (CommonTree)adaptor.GetNilNode();_last = (CommonTree)input.LT(1);
                    	BLOCK4=(CommonTree)Match(input,BLOCK,FOLLOW_BLOCK_in_expression183); 
                    		BLOCK4_tree = (CommonTree)adaptor.DupNode(BLOCK4);

                    		root_1 = (CommonTree)adaptor.BecomeRoot(BLOCK4_tree, root_1);


                    	 retval.result =  new Block(); 

                    	if ( input.LA(1) == Token.DOWN )
                    	{
                    	    Match(input, Token.DOWN, null); 
                    	    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\BonsaiTree.g:29:42: (c= call )*
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
                    	    		    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\BonsaiTree.g:29:43: c= call
                    	    		    {
                    	    		    	_last = (CommonTree)input.LT(1);
                    	    		    	PushFollow(FOLLOW_call_in_expression190);
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
                    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\BonsaiTree.g:30:7: number= NUMBER
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	number=(CommonTree)Match(input,NUMBER,FOLLOW_NUMBER_in_expression205); 
                    		number_tree = (CommonTree)adaptor.DupNode(number);

                    		adaptor.AddChild(root_0, number_tree);

                    	 retval.result =  new Number() { Value = decimal.Parse(number.Text) }; 

                    }
                    break;
                case 4 :
                    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\BonsaiTree.g:31:7: str= STRING
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	str=(CommonTree)Match(input,STRING,FOLLOW_STRING_in_expression217); 
                    		str_tree = (CommonTree)adaptor.DupNode(str);

                    		adaptor.AddChild(root_0, str_tree);

                    	 retval.result =  new Bonsai.Ast.String() { Value = str.Text.Substring(1, str.Text.Length - 2) }; 

                    }
                    break;
                case 5 :
                    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\BonsaiTree.g:32:7: str= IDENTIFIER
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	str=(CommonTree)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_expression229); 
                    		str_tree = (CommonTree)adaptor.DupNode(str);

                    		adaptor.AddChild(root_0, str_tree);

                    	 retval.result =  new Reference() { Name = str.Text }; 

                    }
                    break;
                case 6 :
                    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\BonsaiTree.g:33:7: str= SYMBOL
                    {
                    	root_0 = (CommonTree)adaptor.GetNilNode();

                    	_last = (CommonTree)input.LT(1);
                    	str=(CommonTree)Match(input,SYMBOL,FOLLOW_SYMBOL_in_expression241); 
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

 

    public static readonly BitSet FOLLOW_GROUP_in_program64 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_call_in_program71 = new BitSet(new ulong[]{0x0000000000000018UL});
    public static readonly BitSet FOLLOW_CALL_in_call98 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_expression_in_call116 = new BitSet(new ulong[]{0x0000000000001E68UL});
    public static readonly BitSet FOLLOW_expression_in_call135 = new BitSet(new ulong[]{0x0000000000001E68UL});
    public static readonly BitSet FOLLOW_GROUP_in_expression162 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_call_in_expression169 = new BitSet(new ulong[]{0x0000000000000018UL});
    public static readonly BitSet FOLLOW_BLOCK_in_expression183 = new BitSet(new ulong[]{0x0000000000000004UL});
    public static readonly BitSet FOLLOW_call_in_expression190 = new BitSet(new ulong[]{0x0000000000000018UL});
    public static readonly BitSet FOLLOW_NUMBER_in_expression205 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_STRING_in_expression217 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_expression229 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_SYMBOL_in_expression241 = new BitSet(new ulong[]{0x0000000000000002UL});

}
}