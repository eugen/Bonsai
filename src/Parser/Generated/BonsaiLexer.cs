// $ANTLR 3.2 Sep 23, 2009 12:02:23 D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g 2009-11-15 16:21:58

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
    	get { return "D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g";} 
    }

    // $ANTLR start "T__17"
    public void mT__17() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__17;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:7:7: ( '{' )
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:7:9: '{'
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
    // $ANTLR end "T__17"

    // $ANTLR start "T__18"
    public void mT__18() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__18;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:8:7: ( '}' )
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:8:9: '}'
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
    // $ANTLR end "T__18"

    // $ANTLR start "T__19"
    public void mT__19() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__19;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:9:7: ( '[' )
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:9:9: '['
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
    // $ANTLR end "T__19"

    // $ANTLR start "T__20"
    public void mT__20() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__20;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:10:7: ( ']' )
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:10:9: ']'
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
    // $ANTLR end "T__20"

    // $ANTLR start "T__21"
    public void mT__21() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__21;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:11:7: ( '(' )
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:11:9: '('
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
    // $ANTLR end "T__21"

    // $ANTLR start "T__22"
    public void mT__22() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__22;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:12:7: ( ')' )
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:12:9: ')'
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
    // $ANTLR end "T__22"

    // $ANTLR start "SEPARATOR"
    public void mSEPARATOR() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = SEPARATOR;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:64:5: ( ( '\\r' )? '\\n' | ';' )
            int alt2 = 2;
            int LA2_0 = input.LA(1);

            if ( (LA2_0 == '\n' || LA2_0 == '\r') )
            {
                alt2 = 1;
            }
            else if ( (LA2_0 == ';') )
            {
                alt2 = 2;
            }
            else 
            {
                NoViableAltException nvae_d2s0 =
                    new NoViableAltException("", 2, 0, input);

                throw nvae_d2s0;
            }
            switch (alt2) 
            {
                case 1 :
                    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:64:9: ( '\\r' )? '\\n'
                    {
                    	// D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:64:9: ( '\\r' )?
                    	int alt1 = 2;
                    	int LA1_0 = input.LA(1);

                    	if ( (LA1_0 == '\r') )
                    	{
                    	    alt1 = 1;
                    	}
                    	switch (alt1) 
                    	{
                    	    case 1 :
                    	        // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:64:9: '\\r'
                    	        {
                    	        	Match('\r'); 

                    	        }
                    	        break;

                    	}

                    	Match('\n'); 

                    }
                    break;
                case 2 :
                    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:65:9: ';'
                    {
                    	Match(';'); 

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
    // $ANTLR end "SEPARATOR"

    // $ANTLR start "WS"
    public void mWS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = WS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:68:5: ( ( ' ' | '\\t' )* )
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:68:9: ( ' ' | '\\t' )*
            {
            	// D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:68:9: ( ' ' | '\\t' )*
            	do 
            	{
            	    int alt3 = 2;
            	    int LA3_0 = input.LA(1);

            	    if ( (LA3_0 == '\t' || LA3_0 == ' ') )
            	    {
            	        alt3 = 1;
            	    }


            	    switch (alt3) 
            		{
            			case 1 :
            			    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:
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
            			    goto loop3;
            	    }
            	} while (true);

            	loop3:
            		;	// Stops C# compiler whining that label 'loop3' has no statements

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
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:72:5: (~ ( ' ' | '\\t' | '{' | '}' | '(' | ')' | '[' | ']' | '\\n' | '\\r' | '\\'' | '\"' ) )
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:72:9: ~ ( ' ' | '\\t' | '{' | '}' | '(' | ')' | '[' | ']' | '\\n' | '\\r' | '\\'' | '\"' )
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
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:76:5: ( '.' ( NAMECHAR )* )
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:76:9: '.' ( NAMECHAR )*
            {
            	Match('.'); 
            	// D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:76:13: ( NAMECHAR )*
            	do 
            	{
            	    int alt4 = 2;
            	    int LA4_0 = input.LA(1);

            	    if ( ((LA4_0 >= '\u0000' && LA4_0 <= '\b') || (LA4_0 >= '\u000B' && LA4_0 <= '\f') || (LA4_0 >= '\u000E' && LA4_0 <= '\u001F') || LA4_0 == '!' || (LA4_0 >= '#' && LA4_0 <= '&') || (LA4_0 >= '*' && LA4_0 <= 'Z') || LA4_0 == '\\' || (LA4_0 >= '^' && LA4_0 <= 'z') || LA4_0 == '|' || (LA4_0 >= '~' && LA4_0 <= '\uFFFF')) )
            	    {
            	        alt4 = 1;
            	    }


            	    switch (alt4) 
            		{
            			case 1 :
            			    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:76:13: NAMECHAR
            			    {
            			    	mNAMECHAR(); 

            			    }
            			    break;

            			default:
            			    goto loop4;
            	    }
            	} while (true);

            	loop4:
            		;	// Stops C# compiler whining that label 'loop4' has no statements


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
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:80:5: ( ( '-' )? ( '0' .. '9' )+ ( '.' ( '0' .. '9' )* )? )
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:80:9: ( '-' )? ( '0' .. '9' )+ ( '.' ( '0' .. '9' )* )?
            {
            	// D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:80:9: ( '-' )?
            	int alt5 = 2;
            	int LA5_0 = input.LA(1);

            	if ( (LA5_0 == '-') )
            	{
            	    alt5 = 1;
            	}
            	switch (alt5) 
            	{
            	    case 1 :
            	        // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:80:9: '-'
            	        {
            	        	Match('-'); 

            	        }
            	        break;

            	}

            	// D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:80:14: ( '0' .. '9' )+
            	int cnt6 = 0;
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
            			    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:80:15: '0' .. '9'
            			    {
            			    	MatchRange('0','9'); 

            			    }
            			    break;

            			default:
            			    if ( cnt6 >= 1 ) goto loop6;
            		            EarlyExitException eee6 =
            		                new EarlyExitException(6, input);
            		            throw eee6;
            	    }
            	    cnt6++;
            	} while (true);

            	loop6:
            		;	// Stops C# compiler whining that label 'loop6' has no statements

            	// D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:80:26: ( '.' ( '0' .. '9' )* )?
            	int alt8 = 2;
            	int LA8_0 = input.LA(1);

            	if ( (LA8_0 == '.') )
            	{
            	    alt8 = 1;
            	}
            	switch (alt8) 
            	{
            	    case 1 :
            	        // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:80:27: '.' ( '0' .. '9' )*
            	        {
            	        	Match('.'); 
            	        	// D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:80:31: ( '0' .. '9' )*
            	        	do 
            	        	{
            	        	    int alt7 = 2;
            	        	    int LA7_0 = input.LA(1);

            	        	    if ( ((LA7_0 >= '0' && LA7_0 <= '9')) )
            	        	    {
            	        	        alt7 = 1;
            	        	    }


            	        	    switch (alt7) 
            	        		{
            	        			case 1 :
            	        			    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:80:32: '0' .. '9'
            	        			    {
            	        			    	MatchRange('0','9'); 

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop7;
            	        	    }
            	        	} while (true);

            	        	loop7:
            	        		;	// Stops C# compiler whining that label 'loop7' has no statements


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
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:84:5: ( ( NAMECHAR )* )
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:84:9: ( NAMECHAR )*
            {
            	// D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:84:9: ( NAMECHAR )*
            	do 
            	{
            	    int alt9 = 2;
            	    int LA9_0 = input.LA(1);

            	    if ( ((LA9_0 >= '\u0000' && LA9_0 <= '\b') || (LA9_0 >= '\u000B' && LA9_0 <= '\f') || (LA9_0 >= '\u000E' && LA9_0 <= '\u001F') || LA9_0 == '!' || (LA9_0 >= '#' && LA9_0 <= '&') || (LA9_0 >= '*' && LA9_0 <= 'Z') || LA9_0 == '\\' || (LA9_0 >= '^' && LA9_0 <= 'z') || LA9_0 == '|' || (LA9_0 >= '~' && LA9_0 <= '\uFFFF')) )
            	    {
            	        alt9 = 1;
            	    }


            	    switch (alt9) 
            		{
            			case 1 :
            			    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:84:9: NAMECHAR
            			    {
            			    	mNAMECHAR(); 

            			    }
            			    break;

            			default:
            			    goto loop9;
            	    }
            	} while (true);

            	loop9:
            		;	// Stops C# compiler whining that label 'loop9' has no statements


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
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:88:5: ( SIMPLE_STRING | ESCAPED_STRING )
            int alt10 = 2;
            int LA10_0 = input.LA(1);

            if ( (LA10_0 == '\'') )
            {
                alt10 = 1;
            }
            else if ( (LA10_0 == '\"') )
            {
                alt10 = 2;
            }
            else 
            {
                NoViableAltException nvae_d10s0 =
                    new NoViableAltException("", 10, 0, input);

                throw nvae_d10s0;
            }
            switch (alt10) 
            {
                case 1 :
                    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:88:9: SIMPLE_STRING
                    {
                    	mSIMPLE_STRING(); 

                    }
                    break;
                case 2 :
                    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:89:9: ESCAPED_STRING
                    {
                    	mESCAPED_STRING(); 

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
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:93:5: ( '\\'' (~ '\\'' )* '\\'' )
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:93:9: '\\'' (~ '\\'' )* '\\''
            {
            	Match('\''); 
            	// D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:93:14: (~ '\\'' )*
            	do 
            	{
            	    int alt11 = 2;
            	    int LA11_0 = input.LA(1);

            	    if ( ((LA11_0 >= '\u0000' && LA11_0 <= '&') || (LA11_0 >= '(' && LA11_0 <= '\uFFFF')) )
            	    {
            	        alt11 = 1;
            	    }


            	    switch (alt11) 
            		{
            			case 1 :
            			    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:93:15: ~ '\\''
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
            			    goto loop11;
            	    }
            	} while (true);

            	loop11:
            		;	// Stops C# compiler whining that label 'loop11' has no statements

            	Match('\''); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "SIMPLE_STRING"

    // $ANTLR start "ESCAPED_STRING"
    public void mESCAPED_STRING() // throws RecognitionException [2]
    {
    		try
    		{
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:97:5: ( '\"' (~ '\"' )* '\"' )
            // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:97:9: '\"' (~ '\"' )* '\"'
            {
            	Match('\"'); 
            	// D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:97:13: (~ '\"' )*
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
            			    // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:97:14: ~ '\"'
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
        // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:1:8: ( T__17 | T__18 | T__19 | T__20 | T__21 | T__22 | SEPARATOR | WS | SYMBOL | NUMBER | IDENTIFIER | STRING )
        int alt13 = 12;
        alt13 = dfa13.Predict(input);
        switch (alt13) 
        {
            case 1 :
                // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:1:10: T__17
                {
                	mT__17(); 

                }
                break;
            case 2 :
                // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:1:16: T__18
                {
                	mT__18(); 

                }
                break;
            case 3 :
                // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:1:22: T__19
                {
                	mT__19(); 

                }
                break;
            case 4 :
                // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:1:28: T__20
                {
                	mT__20(); 

                }
                break;
            case 5 :
                // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:1:34: T__21
                {
                	mT__21(); 

                }
                break;
            case 6 :
                // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:1:40: T__22
                {
                	mT__22(); 

                }
                break;
            case 7 :
                // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:1:46: SEPARATOR
                {
                	mSEPARATOR(); 

                }
                break;
            case 8 :
                // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:1:56: WS
                {
                	mWS(); 

                }
                break;
            case 9 :
                // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:1:59: SYMBOL
                {
                	mSYMBOL(); 

                }
                break;
            case 10 :
                // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:1:66: NUMBER
                {
                	mNUMBER(); 

                }
                break;
            case 11 :
                // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:1:73: IDENTIFIER
                {
                	mIDENTIFIER(); 

                }
                break;
            case 12 :
                // D:\\Projects\\Bonsai\\src\\Grammars\\Bonsai.g:1:84: STRING
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
        "\x01\x09\x07\uffff\x01\x07\x01\uffff\x01\x0f\x01\x0d\x01\x12\x03"+
        "\uffff\x01\x0f\x01\x12\x01\uffff\x01\x12";
    const string DFA13_eofS =
        "\x14\uffff";
    const string DFA13_minS =
        "\x01\x00\x07\uffff\x01\x00\x01\uffff\x01\x00\x01\x30\x01\x00\x03"+
        "\uffff\x02\x00\x01\uffff\x01\x00";
    const string DFA13_maxS =
        "\x01\uffff\x07\uffff\x01\uffff\x01\uffff\x01\uffff\x01\x39\x01"+
        "\uffff\x03\uffff\x02\uffff\x01\uffff\x01\uffff";
    const string DFA13_acceptS =
        "\x01\uffff\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06\x01"+
        "\x07\x01\uffff\x01\x08\x03\uffff\x01\x0b\x01\x0c\x01\x09\x02\uffff"+
        "\x01\x0a\x01\uffff";
    const string DFA13_specialS =
        "\x01\x00\x07\uffff\x01\x03\x01\uffff\x01\x06\x01\uffff\x01\x05"+
        "\x03\uffff\x01\x02\x01\x01\x01\uffff\x01\x04}>";
    static readonly string[] DFA13_transitionS = {
            "\x09\x0d\x01\uffff\x01\x07\x02\x0d\x01\x07\x12\x0d\x01\uffff"+
            "\x01\x0d\x01\x0e\x04\x0d\x01\x0e\x01\x05\x01\x06\x03\x0d\x01"+
            "\x0b\x01\x0a\x01\x0d\x0a\x0c\x01\x0d\x01\x08\x1f\x0d\x01\x03"+
            "\x01\x0d\x01\x04\x1d\x0d\x01\x01\x01\x0d\x01\x02\uff82\x0d",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x09\x0d\x02\uffff\x02\x0d\x01\uffff\x12\x0d\x01\uffff\x01"+
            "\x0d\x01\uffff\x04\x0d\x03\uffff\x31\x0d\x01\uffff\x01\x0d\x01"+
            "\uffff\x1d\x0d\x01\uffff\x01\x0d\x01\uffff\uff82\x0d",
            "",
            "\x09\x10\x02\uffff\x02\x10\x01\uffff\x12\x10\x01\uffff\x01"+
            "\x10\x01\uffff\x04\x10\x03\uffff\x31\x10\x01\uffff\x01\x10\x01"+
            "\uffff\x1d\x10\x01\uffff\x01\x10\x01\uffff\uff82\x10",
            "\x0a\x0c",
            "\x09\x0d\x02\uffff\x02\x0d\x01\uffff\x12\x0d\x01\uffff\x01"+
            "\x0d\x01\uffff\x04\x0d\x03\uffff\x04\x0d\x01\x11\x01\x0d\x0a"+
            "\x0c\x21\x0d\x01\uffff\x01\x0d\x01\uffff\x1d\x0d\x01\uffff\x01"+
            "\x0d\x01\uffff\uff82\x0d",
            "",
            "",
            "",
            "\x09\x10\x02\uffff\x02\x10\x01\uffff\x12\x10\x01\uffff\x01"+
            "\x10\x01\uffff\x04\x10\x03\uffff\x31\x10\x01\uffff\x01\x10\x01"+
            "\uffff\x1d\x10\x01\uffff\x01\x10\x01\uffff\uff82\x10",
            "\x09\x0d\x02\uffff\x02\x0d\x01\uffff\x12\x0d\x01\uffff\x01"+
            "\x0d\x01\uffff\x04\x0d\x03\uffff\x06\x0d\x0a\x13\x21\x0d\x01"+
            "\uffff\x01\x0d\x01\uffff\x1d\x0d\x01\uffff\x01\x0d\x01\uffff"+
            "\uff82\x0d",
            "",
            "\x09\x0d\x02\uffff\x02\x0d\x01\uffff\x12\x0d\x01\uffff\x01"+
            "\x0d\x01\uffff\x04\x0d\x03\uffff\x06\x0d\x0a\x13\x21\x0d\x01"+
            "\uffff\x01\x0d\x01\uffff\x1d\x0d\x01\uffff\x01\x0d\x01\uffff"+
            "\uff82\x0d"
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
            get { return "1:1: Tokens : ( T__17 | T__18 | T__19 | T__20 | T__21 | T__22 | SEPARATOR | WS | SYMBOL | NUMBER | IDENTIFIER | STRING );"; }
        }

    }


    protected internal int DFA13_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            IIntStream input = _input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA13_0 = input.LA(1);

                   	s = -1;
                   	if ( (LA13_0 == '{') ) { s = 1; }

                   	else if ( (LA13_0 == '}') ) { s = 2; }

                   	else if ( (LA13_0 == '[') ) { s = 3; }

                   	else if ( (LA13_0 == ']') ) { s = 4; }

                   	else if ( (LA13_0 == '(') ) { s = 5; }

                   	else if ( (LA13_0 == ')') ) { s = 6; }

                   	else if ( (LA13_0 == '\n' || LA13_0 == '\r') ) { s = 7; }

                   	else if ( (LA13_0 == ';') ) { s = 8; }

                   	else if ( (LA13_0 == '.') ) { s = 10; }

                   	else if ( (LA13_0 == '-') ) { s = 11; }

                   	else if ( ((LA13_0 >= '0' && LA13_0 <= '9')) ) { s = 12; }

                   	else if ( ((LA13_0 >= '\u0000' && LA13_0 <= '\b') || (LA13_0 >= '\u000B' && LA13_0 <= '\f') || (LA13_0 >= '\u000E' && LA13_0 <= '\u001F') || LA13_0 == '!' || (LA13_0 >= '#' && LA13_0 <= '&') || (LA13_0 >= '*' && LA13_0 <= ',') || LA13_0 == '/' || LA13_0 == ':' || (LA13_0 >= '<' && LA13_0 <= 'Z') || LA13_0 == '\\' || (LA13_0 >= '^' && LA13_0 <= 'z') || LA13_0 == '|' || (LA13_0 >= '~' && LA13_0 <= '\uFFFF')) ) { s = 13; }

                   	else if ( (LA13_0 == '\"' || LA13_0 == '\'') ) { s = 14; }

                   	else s = 9;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 1 : 
                   	int LA13_17 = input.LA(1);

                   	s = -1;
                   	if ( ((LA13_17 >= '0' && LA13_17 <= '9')) ) { s = 19; }

                   	else if ( ((LA13_17 >= '\u0000' && LA13_17 <= '\b') || (LA13_17 >= '\u000B' && LA13_17 <= '\f') || (LA13_17 >= '\u000E' && LA13_17 <= '\u001F') || LA13_17 == '!' || (LA13_17 >= '#' && LA13_17 <= '&') || (LA13_17 >= '*' && LA13_17 <= '/') || (LA13_17 >= ':' && LA13_17 <= 'Z') || LA13_17 == '\\' || (LA13_17 >= '^' && LA13_17 <= 'z') || LA13_17 == '|' || (LA13_17 >= '~' && LA13_17 <= '\uFFFF')) ) { s = 13; }

                   	else s = 18;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 2 : 
                   	int LA13_16 = input.LA(1);

                   	s = -1;
                   	if ( ((LA13_16 >= '\u0000' && LA13_16 <= '\b') || (LA13_16 >= '\u000B' && LA13_16 <= '\f') || (LA13_16 >= '\u000E' && LA13_16 <= '\u001F') || LA13_16 == '!' || (LA13_16 >= '#' && LA13_16 <= '&') || (LA13_16 >= '*' && LA13_16 <= 'Z') || LA13_16 == '\\' || (LA13_16 >= '^' && LA13_16 <= 'z') || LA13_16 == '|' || (LA13_16 >= '~' && LA13_16 <= '\uFFFF')) ) { s = 16; }

                   	else s = 15;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 3 : 
                   	int LA13_8 = input.LA(1);

                   	s = -1;
                   	if ( ((LA13_8 >= '\u0000' && LA13_8 <= '\b') || (LA13_8 >= '\u000B' && LA13_8 <= '\f') || (LA13_8 >= '\u000E' && LA13_8 <= '\u001F') || LA13_8 == '!' || (LA13_8 >= '#' && LA13_8 <= '&') || (LA13_8 >= '*' && LA13_8 <= 'Z') || LA13_8 == '\\' || (LA13_8 >= '^' && LA13_8 <= 'z') || LA13_8 == '|' || (LA13_8 >= '~' && LA13_8 <= '\uFFFF')) ) { s = 13; }

                   	else s = 7;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 4 : 
                   	int LA13_19 = input.LA(1);

                   	s = -1;
                   	if ( ((LA13_19 >= '0' && LA13_19 <= '9')) ) { s = 19; }

                   	else if ( ((LA13_19 >= '\u0000' && LA13_19 <= '\b') || (LA13_19 >= '\u000B' && LA13_19 <= '\f') || (LA13_19 >= '\u000E' && LA13_19 <= '\u001F') || LA13_19 == '!' || (LA13_19 >= '#' && LA13_19 <= '&') || (LA13_19 >= '*' && LA13_19 <= '/') || (LA13_19 >= ':' && LA13_19 <= 'Z') || LA13_19 == '\\' || (LA13_19 >= '^' && LA13_19 <= 'z') || LA13_19 == '|' || (LA13_19 >= '~' && LA13_19 <= '\uFFFF')) ) { s = 13; }

                   	else s = 18;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 5 : 
                   	int LA13_12 = input.LA(1);

                   	s = -1;
                   	if ( (LA13_12 == '.') ) { s = 17; }

                   	else if ( ((LA13_12 >= '0' && LA13_12 <= '9')) ) { s = 12; }

                   	else if ( ((LA13_12 >= '\u0000' && LA13_12 <= '\b') || (LA13_12 >= '\u000B' && LA13_12 <= '\f') || (LA13_12 >= '\u000E' && LA13_12 <= '\u001F') || LA13_12 == '!' || (LA13_12 >= '#' && LA13_12 <= '&') || (LA13_12 >= '*' && LA13_12 <= '-') || LA13_12 == '/' || (LA13_12 >= ':' && LA13_12 <= 'Z') || LA13_12 == '\\' || (LA13_12 >= '^' && LA13_12 <= 'z') || LA13_12 == '|' || (LA13_12 >= '~' && LA13_12 <= '\uFFFF')) ) { s = 13; }

                   	else s = 18;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 6 : 
                   	int LA13_10 = input.LA(1);

                   	s = -1;
                   	if ( ((LA13_10 >= '\u0000' && LA13_10 <= '\b') || (LA13_10 >= '\u000B' && LA13_10 <= '\f') || (LA13_10 >= '\u000E' && LA13_10 <= '\u001F') || LA13_10 == '!' || (LA13_10 >= '#' && LA13_10 <= '&') || (LA13_10 >= '*' && LA13_10 <= 'Z') || LA13_10 == '\\' || (LA13_10 >= '^' && LA13_10 <= 'z') || LA13_10 == '|' || (LA13_10 >= '~' && LA13_10 <= '\uFFFF')) ) { s = 16; }

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
