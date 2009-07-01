module Bonsai.Parser where
import Monad
import Text.ParserCombinators.Parsec hiding (spaces)
import System.Environment

data Token = Symbol String 
                 | Number Double
                 | String String
                 | Reference String -- variables and functions
                 | Call Token [Token]
                 | Group [Token] -- paren expression
                 | Block [Token] -- lazy expression?
         
instance Show Token where
    show (Symbol s) = "." ++ s
    show (Number f) = show f
    show (String a) = "\"" ++ a ++ "\""
    show (Reference r) = "@" ++ r
    show (Call t []) = "(call " ++ (show t) ++ ")"
    show (Call t args) = "(call " ++ (show t) ++ " with " ++ (unwords.map show) args ++ ")"
    show (Group list) = "(group " ++ (unwords.(map show)) list ++ ")"
    show (Block list) = "(block " ++ (unwords.(map show)) list ++ ")"
    
punctuation :: Parser Char
punctuation = oneOf "!#$%&|*+-/:<=>?@^_~"

spaces :: Parser ()
spaces = skipMany (char ' ')

bonsaiString :: Parser Token
bonsaiString = do
  char '"'
  str <- many (noneOf "\"")
  char '"'
  return $ String str

bonsaiNumber :: Parser Token
bonsaiNumber = do 
  signChar <- char '+' <|> char '-' <|> return '+'
  digits <- many1 digit
  return $ Number ((if signChar == '-' then -1 else 1) * read digits)

bonsaiSymbol :: Parser Token
bonsaiSymbol = do
  char '.'
  str <- many (letter <|> digit <|> punctuation)
  return $ Symbol str

bonsaiReference :: Parser Token
bonsaiReference = do
  str <- many1 (letter <|> digit <|> punctuation)
  return $ Reference str

bonsaiAtom :: Parser Token
bonsaiAtom = do
  atom <- (try bonsaiNumber) <|> bonsaiString <|> bonsaiSymbol <|> bonsaiReference
  spaces
  return atom

bonsaiPrimary :: Parser Token
bonsaiPrimary =
    spaces >> (bonsaiAtom <|> bonsaiParen <|> bonsaiBlock)

bonsaiStatements :: Parser [Token]
bonsaiStatements =
    -- 'space' includes newline
    many space >> (sepEndBy bonsaiCall (many (space <|> char ';')))

bonsaiCall :: Parser Token
bonsaiCall = do
  calee <- bonsaiPrimary
  arguments <- many bonsaiPrimary
  return $ Call calee arguments
  
bonsaiParen :: Parser Token
bonsaiParen = do
  spaces >> char '('
  list <- bonsaiStatements
  char ')' 
  return $ Group list

bonsaiBlock :: Parser Token
bonsaiBlock = do
  spaces >> char '{'
  list <- bonsaiStatements
  char '}' 
  return $ Block list

parseString :: String -> Maybe [Token]
parseString code =
    case (parse bonsaiStatements "bonsai" code) of
      Right tokens -> Just tokens
      Left error -> Nothing

parseFile :: String -> IO (Maybe [Token])
parseFile fileName = do
  code <- readFile fileName
  return $ parseString code
