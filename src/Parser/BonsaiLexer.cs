// $ANTLR 3.1.2 C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g 2009-06-25 21:22:21

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162

using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;


public partial class BonsaiLexer : Lexer {
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

    public BonsaiLexer() 
    {
		InitializeCyclicDFAs();
    }
    public BonsaiLexer(ICharStream input)
		: this(input, null) {
    }
    public BonsaiLexer(ICharStream input, RecognizerSharedState state)
		: base(input, state) {
		InitializeCyclicDFAs(); 

    }
    
    override public string GrammarFileName
    {
    	get { return "C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g";} 
    }

    // $ANTLR start "T__18"
    public void mT__18() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__18;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:7:7: ( '{' )
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:7:9: '{'
            {
            	Match('{'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__18"

    // $ANTLR start "T__19"
    public void mT__19() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__19;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:8:7: ( '}' )
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:8:9: '}'
            {
            	Match('}'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__19"

    // $ANTLR start "T__20"
    public void mT__20() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__20;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:9:7: ( '[' )
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:9:9: '['
            {
            	Match('['); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__20"

    // $ANTLR start "T__21"
    public void mT__21() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__21;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:10:7: ( ']' )
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:10:9: ']'
            {
            	Match(']'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__21"

    // $ANTLR start "T__22"
    public void mT__22() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__22;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:11:7: ( '(' )
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:11:9: '('
            {
            	Match('('); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__22"

    // $ANTLR start "T__23"
    public void mT__23() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__23;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:12:7: ( ')' )
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:12:9: ')'
            {
            	Match(')'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__23"

    // $ANTLR start "NEWLINE"
    public void mNEWLINE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = NEWLINE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:63:2: ( ( '\\r' )? '\\n' )
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:63:4: ( '\\r' )? '\\n'
            {
            	// C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:63:4: ( '\\r' )?
            	int alt1 = 2;
            	int LA1_0 = input.LA(1);

            	if ( (LA1_0 == '\r') )
            	{
            	    alt1 = 1;
            	}
            	switch (alt1) 
            	{
            	    case 1 :
            	        // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:63:4: '\\r'
            	        {
            	        	Match('\r'); 

            	        }
            	        break;

            	}

            	Match('\n'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "NEWLINE"

    // $ANTLR start "WS"
    public void mWS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = WS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:66:4: ( ( ' ' | '\\t' )* )
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:66:6: ( ' ' | '\\t' )*
            {
            	// C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:66:6: ( ' ' | '\\t' )*
            	do 
            	{
            	    int alt2 = 2;
            	    int LA2_0 = input.LA(1);

            	    if ( (LA2_0 == '\t' || LA2_0 == ' ') )
            	    {
            	        alt2 = 1;
            	    }


            	    switch (alt2) 
            		{
            			case 1 :
            			    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:
            			    {
            			    	if ( input.LA(1) == '\t' || input.LA(1) == ' ' ) 
            			    	{
            			    	    input.Consume();

            			    	}
            			    	else 
            			    	{
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    Recover(mse);
            			    	    throw mse;}


            			    }
            			    break;

            			default:
            			    goto loop2;
            	    }
            	} while (true);

            	loop2:
            		;	// Stops C# compiler whining that label 'loop2' has no statements

            	 _channel = HIDDEN; 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "WS"

    // $ANTLR start "NAMECHAR"
    public void mNAMECHAR() // throws RecognitionException [2]
    {
    		try
    		{
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:70:2: (~ ( ' ' | '\\t' | '{' | '}' | '(' | ')' | '[' | ']' | '\\n' | '\\r' | '\\'' | '\"' ) )
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:70:4: ~ ( ' ' | '\\t' | '{' | '}' | '(' | ')' | '[' | ']' | '\\n' | '\\r' | '\\'' | '\"' )
            {
            	if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '\b') || (input.LA(1) >= '\u000B' && input.LA(1) <= '\f') || (input.LA(1) >= '\u000E' && input.LA(1) <= '\u001F') || input.LA(1) == '!' || (input.LA(1) >= '#' && input.LA(1) <= '&') || (input.LA(1) >= '*' && input.LA(1) <= 'Z') || input.LA(1) == '\\' || (input.LA(1) >= '^' && input.LA(1) <= 'z') || input.LA(1) == '|' || (input.LA(1) >= '~' && input.LA(1) <= '\uFFFF') ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "NAMECHAR"

    // $ANTLR start "SYMBOL"
    public void mSYMBOL() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = SYMBOL;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:74:2: ( '.' ( NAMECHAR )* )
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:74:4: '.' ( NAMECHAR )*
            {
            	Match('.'); 
            	// C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:74:8: ( NAMECHAR )*
            	do 
            	{
            	    int alt3 = 2;
            	    int LA3_0 = input.LA(1);

            	    if ( ((LA3_0 >= '\u0000' && LA3_0 <= '\b') || (LA3_0 >= '\u000B' && LA3_0 <= '\f') || (LA3_0 >= '\u000E' && LA3_0 <= '\u001F') || LA3_0 == '!' || (LA3_0 >= '#' && LA3_0 <= '&') || (LA3_0 >= '*' && LA3_0 <= 'Z') || LA3_0 == '\\' || (LA3_0 >= '^' && LA3_0 <= 'z') || LA3_0 == '|' || (LA3_0 >= '~' && LA3_0 <= '\uFFFF')) )
            	    {
            	        alt3 = 1;
            	    }


            	    switch (alt3) 
            		{
            			case 1 :
            			    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:74:8: NAMECHAR
            			    {
            			    	mNAMECHAR(); 

            			    }
            			    break;

            			default:
            			    goto loop3;
            	    }
            	} while (true);

            	loop3:
            		;	// Stops C# compiler whining that label 'loop3' has no statements


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "SYMBOL"

    // $ANTLR start "NUMBER"
    public void mNUMBER() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = NUMBER;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:78:2: ( ( '-' )? ( '0' .. '9' )+ ( '.' ( '0' .. '9' )* )? )
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:78:4: ( '-' )? ( '0' .. '9' )+ ( '.' ( '0' .. '9' )* )?
            {
            	// C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:78:4: ( '-' )?
            	int alt4 = 2;
            	int LA4_0 = input.LA(1);

            	if ( (LA4_0 == '-') )
            	{
            	    alt4 = 1;
            	}
            	switch (alt4) 
            	{
            	    case 1 :
            	        // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:78:4: '-'
            	        {
            	        	Match('-'); 

            	        }
            	        break;

            	}

            	// C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:78:9: ( '0' .. '9' )+
            	int cnt5 = 0;
            	do 
            	{
            	    int alt5 = 2;
            	    int LA5_0 = input.LA(1);

            	    if ( ((LA5_0 >= '0' && LA5_0 <= '9')) )
            	    {
            	        alt5 = 1;
            	    }


            	    switch (alt5) 
            		{
            			case 1 :
            			    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:78:10: '0' .. '9'
            			    {
            			    	MatchRange('0','9'); 

            			    }
            			    break;

            			default:
            			    if ( cnt5 >= 1 ) goto loop5;
            		            EarlyExitException eee5 =
            		                new EarlyExitException(5, input);
            		            throw eee5;
            	    }
            	    cnt5++;
            	} while (true);

            	loop5:
            		;	// Stops C# compiler whinging that label 'loop5' has no statements

            	// C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:78:21: ( '.' ( '0' .. '9' )* )?
            	int alt7 = 2;
            	int LA7_0 = input.LA(1);

            	if ( (LA7_0 == '.') )
            	{
            	    alt7 = 1;
            	}
            	switch (alt7) 
            	{
            	    case 1 :
            	        // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:78:22: '.' ( '0' .. '9' )*
            	        {
            	        	Match('.'); 
            	        	// C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:78:26: ( '0' .. '9' )*
            	        	do 
            	        	{
            	        	    int alt6 = 2;
            	        	    int LA6_0 = input.LA(1);

            	        	    if ( ((LA6_0 >= '0' && LA6_0 <= '9')) )
            	        	    {
            	        	        alt6 = 1;
            	        	    }


            	        	    switch (alt6) 
            	        		{
            	        			case 1 :
            	        			    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:78:27: '0' .. '9'
            	        			    {
            	        			    	MatchRange('0','9'); 

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop6;
            	        	    }
            	        	} while (true);

            	        	loop6:
            	        		;	// Stops C# compiler whining that label 'loop6' has no statements


            	        }
            	        break;

            	}


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "NUMBER"

    // $ANTLR start "IDENTIFIER"
    public void mIDENTIFIER() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = IDENTIFIER;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:82:2: ( ( NAMECHAR )* )
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:82:4: ( NAMECHAR )*
            {
            	// C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:82:4: ( NAMECHAR )*
            	do 
            	{
            	    int alt8 = 2;
            	    int LA8_0 = input.LA(1);

            	    if ( ((LA8_0 >= '\u0000' && LA8_0 <= '\b') || (LA8_0 >= '\u000B' && LA8_0 <= '\f') || (LA8_0 >= '\u000E' && LA8_0 <= '\u001F') || LA8_0 == '!' || (LA8_0 >= '#' && LA8_0 <= '&') || (LA8_0 >= '*' && LA8_0 <= 'Z') || LA8_0 == '\\' || (LA8_0 >= '^' && LA8_0 <= 'z') || LA8_0 == '|' || (LA8_0 >= '~' && LA8_0 <= '\uFFFF')) )
            	    {
            	        alt8 = 1;
            	    }


            	    switch (alt8) 
            		{
            			case 1 :
            			    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:82:4: NAMECHAR
            			    {
            			    	mNAMECHAR(); 

            			    }
            			    break;

            			default:
            			    goto loop8;
            	    }
            	} while (true);

            	loop8:
            		;	// Stops C# compiler whining that label 'loop8' has no statements


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "IDENTIFIER"

    // $ANTLR start "STRING"
    public void mSTRING() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = STRING;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:86:2: ( SIMPLE_STRING | ESCAPED_STRING | MULTILINE_STRING )
            int alt9 = 3;
            int LA9_0 = input.LA(1);

            if ( (LA9_0 == '\'') )
            {
                alt9 = 1;
            }
            else if ( (LA9_0 == '\"') )
            {
                int LA9_2 = input.LA(2);

                if ( (LA9_2 == '\"') )
                {
                    int LA9_3 = input.LA(3);

                    if ( (LA9_3 == '\"') )
                    {
                        alt9 = 3;
                    }
                    else 
                    {
                        alt9 = 2;}
                }
                else if ( ((LA9_2 >= '\u0000' && LA9_2 <= '!') || (LA9_2 >= '#' && LA9_2 <= '\uFFFF')) )
                {
                    alt9 = 2;
                }
                else 
                {
                    NoViableAltException nvae_d9s2 =
                        new NoViableAltException("", 9, 2, input);

                    throw nvae_d9s2;
                }
            }
            else 
            {
                NoViableAltException nvae_d9s0 =
                    new NoViableAltException("", 9, 0, input);

                throw nvae_d9s0;
            }
            switch (alt9) 
            {
                case 1 :
                    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:86:4: SIMPLE_STRING
                    {
                    	mSIMPLE_STRING(); 

                    }
                    break;
                case 2 :
                    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:87:4: ESCAPED_STRING
                    {
                    	mESCAPED_STRING(); 

                    }
                    break;
                case 3 :
                    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:88:4: MULTILINE_STRING
                    {
                    	mMULTILINE_STRING(); 

                    }
                    break;

            }
            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "STRING"

    // $ANTLR start "SIMPLE_STRING"
    public void mSIMPLE_STRING() // throws RecognitionException [2]
    {
    		try
    		{
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:92:2: ( '\\'' (~ '\\'' )* '\\'' )
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:92:4: '\\'' (~ '\\'' )* '\\''
            {
            	Match('\''); 
            	// C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:92:9: (~ '\\'' )*
            	do 
            	{
            	    int alt10 = 2;
            	    int LA10_0 = input.LA(1);

            	    if ( ((LA10_0 >= '\u0000' && LA10_0 <= '&') || (LA10_0 >= '(' && LA10_0 <= '\uFFFF')) )
            	    {
            	        alt10 = 1;
            	    }


            	    switch (alt10) 
            		{
            			case 1 :
            			    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:92:10: ~ '\\''
            			    {
            			    	if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '&') || (input.LA(1) >= '(' && input.LA(1) <= '\uFFFF') ) 
            			    	{
            			    	    input.Consume();

            			    	}
            			    	else 
            			    	{
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    Recover(mse);
            			    	    throw mse;}


            			    }
            			    break;

            			default:
            			    goto loop10;
            	    }
            	} while (true);

            	loop10:
            		;	// Stops C# compiler whining that label 'loop10' has no statements

            	Match('\''); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "SIMPLE_STRING"

    // $ANTLR start "MULTILINE_STRING"
    public void mMULTILINE_STRING() // throws RecognitionException [2]
    {
    		try
    		{
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:97:2: ( '\"\"\"' ( . )* '\"\"\"' )
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:97:4: '\"\"\"' ( . )* '\"\"\"'
            {
            	Match("\"\"\""); 

            	// C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:97:10: ( . )*
            	do 
            	{
            	    int alt11 = 2;
            	    int LA11_0 = input.LA(1);

            	    if ( (LA11_0 == '\"') )
            	    {
            	        int LA11_1 = input.LA(2);

            	        if ( (LA11_1 == '\"') )
            	        {
            	            int LA11_3 = input.LA(3);

            	            if ( (LA11_3 == '\"') )
            	            {
            	                alt11 = 2;
            	            }
            	            else if ( ((LA11_3 >= '\u0000' && LA11_3 <= '!') || (LA11_3 >= '#' && LA11_3 <= '\uFFFF')) )
            	            {
            	                alt11 = 1;
            	            }


            	        }
            	        else if ( ((LA11_1 >= '\u0000' && LA11_1 <= '!') || (LA11_1 >= '#' && LA11_1 <= '\uFFFF')) )
            	        {
            	            alt11 = 1;
            	        }


            	    }
            	    else if ( ((LA11_0 >= '\u0000' && LA11_0 <= '!') || (LA11_0 >= '#' && LA11_0 <= '\uFFFF')) )
            	    {
            	        alt11 = 1;
            	    }


            	    switch (alt11) 
            		{
            			case 1 :
            			    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:97:10: .
            			    {
            			    	MatchAny(); 

            			    }
            			    break;

            			default:
            			    goto loop11;
            	    }
            	} while (true);

            	loop11:
            		;	// Stops C# compiler whining that label 'loop11' has no statements

            	Match("\"\"\""); 


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "MULTILINE_STRING"

    // $ANTLR start "ESCAPED_STRING"
    public void mESCAPED_STRING() // throws RecognitionException [2]
    {
    		try
    		{
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:101:2: ( '\"' (~ '\"' )* '\"' )
            // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:101:4: '\"' (~ '\"' )* '\"'
            {
            	Match('\"'); 
            	// C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:101:8: (~ '\"' )*
            	do 
            	{
            	    int alt12 = 2;
            	    int LA12_0 = input.LA(1);

            	    if ( ((LA12_0 >= '\u0000' && LA12_0 <= '!') || (LA12_0 >= '#' && LA12_0 <= '\uFFFF')) )
            	    {
            	        alt12 = 1;
            	    }


            	    switch (alt12) 
            		{
            			case 1 :
            			    // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:101:9: ~ '\"'
            			    {
            			    	if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '!') || (input.LA(1) >= '#' && input.LA(1) <= '\uFFFF') ) 
            			    	{
            			    	    input.Consume();

            			    	}
            			    	else 
            			    	{
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    Recover(mse);
            			    	    throw mse;}


            			    }
            			    break;

            			default:
            			    goto loop12;
            	    }
            	} while (true);

            	loop12:
            		;	// Stops C# compiler whining that label 'loop12' has no statements

            	Match('\"'); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "ESCAPED_STRING"

    override public void mTokens() // throws RecognitionException 
    {
        // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:1:8: ( T__18 | T__19 | T__20 | T__21 | T__22 | T__23 | NEWLINE | WS | SYMBOL | NUMBER | IDENTIFIER | STRING )
        int alt13 = 12;
        alt13 = dfa13.Predict(input);
        switch (alt13) 
        {
            case 1 :
                // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:1:10: T__18
                {
                	mT__18(); 

                }
                break;
            case 2 :
                // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:1:16: T__19
                {
                	mT__19(); 

                }
                break;
            case 3 :
                // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:1:22: T__20
                {
                	mT__20(); 

                }
                break;
            case 4 :
                // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:1:28: T__21
                {
                	mT__21(); 

                }
                break;
            case 5 :
                // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:1:34: T__22
                {
                	mT__22(); 

                }
                break;
            case 6 :
                // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:1:40: T__23
                {
                	mT__23(); 

                }
                break;
            case 7 :
                // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:1:46: NEWLINE
                {
                	mNEWLINE(); 

                }
                break;
            case 8 :
                // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:1:54: WS
                {
                	mWS(); 

                }
                break;
            case 9 :
                // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:1:57: SYMBOL
                {
                	mSYMBOL(); 

                }
                break;
            case 10 :
                // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:1:64: NUMBER
                {
                	mNUMBER(); 

                }
                break;
            case 11 :
                // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:1:71: IDENTIFIER
                {
                	mIDENTIFIER(); 

                }
                break;
            case 12 :
                // C:\\Users\\Eugen\\Projects\\bonsai\\clr\\src\\Parser\\Bonsai.g:1:82: STRING
                {
                	mSTRING(); 

                }
                break;

        }

    }


    protected DFA13 dfa13;
	private void InitializeCyclicDFAs()
	{
	    this.dfa13 = new DFA13(this);
	    this.dfa13.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA13_SpecialStateTransition);
	}

    const string DFA13_eotS =
        "\x01\x08\x08\uffff\x01\x0f\x01\x0c\x01\x11\x02\uffff\x01\x0f\x01"+
        "\uffff\x01\x11\x01\uffff\x01\x11";
    const string DFA13_eofS =
        "\x13\uffff";
    const string DFA13_minS =
        "\x01\x00\x08\uffff\x01\x00\x01\x30\x01\x00\x02\uffff\x01\x00\x01"+
        "\uffff\x01\x00\x01\uffff\x01\x00";
    const string DFA13_maxS =
        "\x01\uffff\x08\uffff\x01\uffff\x01\x39\x01\uffff\x02\uffff\x01"+
        "\uffff\x01\uffff\x01\uffff\x01\uffff\x01\uffff";
    const string DFA13_acceptS =
        "\x01\uffff\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06\x01"+
        "\x07\x01\x08\x03\uffff\x01\x0b\x01\x0c\x01\uffff\x01\x09\x01\uffff"+
        "\x01\x0a\x01\uffff";
    const string DFA13_specialS =
        "\x01\x04\x08\uffff\x01\x05\x01\uffff\x01\x01\x02\uffff\x01\x03"+
        "\x01\uffff\x01\x02\x01\uffff\x01\x00}>";
    static readonly string[] DFA13_transitionS = {
            "\x09\x0c\x01\uffff\x01\x07\x02\x0c\x01\x07\x12\x0c\x01\uffff"+
            "\x01\x0c\x01\x0d\x04\x0c\x01\x0d\x01\x05\x01\x06\x03\x0c\x01"+
            "\x0a\x01\x09\x01\x0c\x0a\x0b\x21\x0c\x01\x03\x01\x0c\x01\x04"+
            "\x1d\x0c\x01\x01\x01\x0c\x01\x02\uff82\x0c",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x09\x0e\x02\uffff\x02\x0e\x01\uffff\x12\x0e\x01\uffff\x01"+
            "\x0e\x01\uffff\x04\x0e\x03\uffff\x31\x0e\x01\uffff\x01\x0e\x01"+
            "\uffff\x1d\x0e\x01\uffff\x01\x0e\x01\uffff\uff82\x0e",
            "\x0a\x0b",
            "\x09\x0c\x02\uffff\x02\x0c\x01\uffff\x12\x0c\x01\uffff\x01"+
            "\x0c\x01\uffff\x04\x0c\x03\uffff\x04\x0c\x01\x10\x01\x0c\x0a"+
            "\x0b\x21\x0c\x01\uffff\x01\x0c\x01\uffff\x1d\x0c\x01\uffff\x01"+
            "\x0c\x01\uffff\uff82\x0c",
            "",
            "",
            "\x09\x0e\x02\uffff\x02\x0e\x01\uffff\x12\x0e\x01\uffff\x01"+
            "\x0e\x01\uffff\x04\x0e\x03\uffff\x31\x0e\x01\uffff\x01\x0e\x01"+
            "\uffff\x1d\x0e\x01\uffff\x01\x0e\x01\uffff\uff82\x0e",
            "",
            "\x09\x0c\x02\uffff\x02\x0c\x01\uffff\x12\x0c\x01\uffff\x01"+
            "\x0c\x01\uffff\x04\x0c\x03\uffff\x06\x0c\x0a\x12\x21\x0c\x01"+
            "\uffff\x01\x0c\x01\uffff\x1d\x0c\x01\uffff\x01\x0c\x01\uffff"+
            "\uff82\x0c",
            "",
            "\x09\x0c\x02\uffff\x02\x0c\x01\uffff\x12\x0c\x01\uffff\x01"+
            "\x0c\x01\uffff\x04\x0c\x03\uffff\x06\x0c\x0a\x12\x21\x0c\x01"+
            "\uffff\x01\x0c\x01\uffff\x1d\x0c\x01\uffff\x01\x0c\x01\uffff"+
            "\uff82\x0c"
    };

    static readonly short[] DFA13_eot = DFA.UnpackEncodedString(DFA13_eotS);
    static readonly short[] DFA13_eof = DFA.UnpackEncodedString(DFA13_eofS);
    static readonly char[] DFA13_min = DFA.UnpackEncodedStringToUnsignedChars(DFA13_minS);
    static readonly char[] DFA13_max = DFA.UnpackEncodedStringToUnsignedChars(DFA13_maxS);
    static readonly short[] DFA13_accept = DFA.UnpackEncodedString(DFA13_acceptS);
    static readonly short[] DFA13_special = DFA.UnpackEncodedString(DFA13_specialS);
    static readonly short[][] DFA13_transition = DFA.UnpackEncodedStringArray(DFA13_transitionS);

    protected class DFA13 : DFA
    {
        public DFA13(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 13;
            this.eot = DFA13_eot;
            this.eof = DFA13_eof;
            this.min = DFA13_min;
            this.max = DFA13_max;
            this.accept = DFA13_accept;
            this.special = DFA13_special;
            this.transition = DFA13_transition;

        }

        override public string Description
        {
            get { return "1:1: Tokens : ( T__18 | T__19 | T__20 | T__21 | T__22 | T__23 | NEWLINE | WS | SYMBOL | NUMBER | IDENTIFIER | STRING );"; }
        }

    }


    protected internal int DFA13_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            IIntStream input = _input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA13_18 = input.LA(1);

                   	s = -1;
                   	if ( ((LA13_18 >= '0' && LA13_18 <= '9')) ) { s = 18; }

                   	else if ( ((LA13_18 >= '\u0000' && LA13_18 <= '\b') || (LA13_18 >= '\u000B' && LA13_18 <= '\f') || (LA13_18 >= '\u000E' && LA13_18 <= '\u001F') || LA13_18 == '!' || (LA13_18 >= '#' && LA13_18 <= '&') || (LA13_18 >= '*' && LA13_18 <= '/') || (LA13_18 >= ':' && LA13_18 <= 'Z') || LA13_18 == '\\' || (LA13_18 >= '^' && LA13_18 <= 'z') || LA13_18 == '|' || (LA13_18 >= '~' && LA13_18 <= '\uFFFF')) ) { s = 12; }

                   	else s = 17;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 1 : 
                   	int LA13_11 = input.LA(1);

                   	s = -1;
                   	if ( (LA13_11 == '.') ) { s = 16; }

                   	else if ( ((LA13_11 >= '0' && LA13_11 <= '9')) ) { s = 11; }

                   	else if ( ((LA13_11 >= '\u0000' && LA13_11 <= '\b') || (LA13_11 >= '\u000B' && LA13_11 <= '\f') || (LA13_11 >= '\u000E' && LA13_11 <= '\u001F') || LA13_11 == '!' || (LA13_11 >= '#' && LA13_11 <= '&') || (LA13_11 >= '*' && LA13_11 <= '-') || LA13_11 == '/' || (LA13_11 >= ':' && LA13_11 <= 'Z') || LA13_11 == '\\' || (LA13_11 >= '^' && LA13_11 <= 'z') || LA13_11 == '|' || (LA13_11 >= '~' && LA13_11 <= '\uFFFF')) ) { s = 12; }

                   	else s = 17;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 2 : 
                   	int LA13_16 = input.LA(1);

                   	s = -1;
                   	if ( ((LA13_16 >= '0' && LA13_16 <= '9')) ) { s = 18; }

                   	else if ( ((LA13_16 >= '\u0000' && LA13_16 <= '\b') || (LA13_16 >= '\u000B' && LA13_16 <= '\f') || (LA13_16 >= '\u000E' && LA13_16 <= '\u001F') || LA13_16 == '!' || (LA13_16 >= '#' && LA13_16 <= '&') || (LA13_16 >= '*' && LA13_16 <= '/') || (LA13_16 >= ':' && LA13_16 <= 'Z') || LA13_16 == '\\' || (LA13_16 >= '^' && LA13_16 <= 'z') || LA13_16 == '|' || (LA13_16 >= '~' && LA13_16 <= '\uFFFF')) ) { s = 12; }

                   	else s = 17;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 3 : 
                   	int LA13_14 = input.LA(1);

                   	s = -1;
                   	if ( ((LA13_14 >= '\u0000' && LA13_14 <= '\b') || (LA13_14 >= '\u000B' && LA13_14 <= '\f') || (LA13_14 >= '\u000E' && LA13_14 <= '\u001F') || LA13_14 == '!' || (LA13_14 >= '#' && LA13_14 <= '&') || (LA13_14 >= '*' && LA13_14 <= 'Z') || LA13_14 == '\\' || (LA13_14 >= '^' && LA13_14 <= 'z') || LA13_14 == '|' || (LA13_14 >= '~' && LA13_14 <= '\uFFFF')) ) { s = 14; }

                   	else s = 15;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 4 : 
                   	int LA13_0 = input.LA(1);

                   	s = -1;
                   	if ( (LA13_0 == '{') ) { s = 1; }

                   	else if ( (LA13_0 == '}') ) { s = 2; }

                   	else if ( (LA13_0 == '[') ) { s = 3; }

                   	else if ( (LA13_0 == ']') ) { s = 4; }

                   	else if ( (LA13_0 == '(') ) { s = 5; }

                   	else if ( (LA13_0 == ')') ) { s = 6; }

                   	else if ( (LA13_0 == '\n' || LA13_0 == '\r') ) { s = 7; }

                   	else if ( (LA13_0 == '.') ) { s = 9; }

                   	else if ( (LA13_0 == '-') ) { s = 10; }

                   	else if ( ((LA13_0 >= '0' && LA13_0 <= '9')) ) { s = 11; }

                   	else if ( ((LA13_0 >= '\u0000' && LA13_0 <= '\b') || (LA13_0 >= '\u000B' && LA13_0 <= '\f') || (LA13_0 >= '\u000E' && LA13_0 <= '\u001F') || LA13_0 == '!' || (LA13_0 >= '#' && LA13_0 <= '&') || (LA13_0 >= '*' && LA13_0 <= ',') || LA13_0 == '/' || (LA13_0 >= ':' && LA13_0 <= 'Z') || LA13_0 == '\\' || (LA13_0 >= '^' && LA13_0 <= 'z') || LA13_0 == '|' || (LA13_0 >= '~' && LA13_0 <= '\uFFFF')) ) { s = 12; }

                   	else if ( (LA13_0 == '\"' || LA13_0 == '\'') ) { s = 13; }

                   	else s = 8;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 5 : 
                   	int LA13_9 = input.LA(1);

                   	s = -1;
                   	if ( ((LA13_9 >= '\u0000' && LA13_9 <= '\b') || (LA13_9 >= '\u000B' && LA13_9 <= '\f') || (LA13_9 >= '\u000E' && LA13_9 <= '\u001F') || LA13_9 == '!' || (LA13_9 >= '#' && LA13_9 <= '&') || (LA13_9 >= '*' && LA13_9 <= 'Z') || LA13_9 == '\\' || (LA13_9 >= '^' && LA13_9 <= 'z') || LA13_9 == '|' || (LA13_9 >= '~' && LA13_9 <= '\uFFFF')) ) { s = 14; }

                   	else s = 15;

                   	if ( s >= 0 ) return s;
                   	break;
        }
        NoViableAltException nvae13 =
            new NoViableAltException(dfa.Description, 13, _s, input);
        dfa.Error(nvae13);
        throw nvae13;
    }
 
    
}
