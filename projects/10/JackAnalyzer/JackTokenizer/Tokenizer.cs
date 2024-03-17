using JackAnalyzer.JackTokenizer.Exceptions;

namespace JackAnalyzer.JackTokenizer
{
    internal class Tokenizer
    {
        private IList<string> Tokens;
        private IEnumerable<string> KeyWords;
        private IEnumerable<string> Symbols;
        private int CurrIndex = 0;

        public Tokenizer(string[] fileRows)
        {
            Tokens = new List<string>();

            foreach (var row in fileRows)
            {
                var validTokens = row.Split("//")[0].Split(" ");
                foreach (var token in validTokens)
                {
                    if (string.IsNullOrWhiteSpace(token)) continue;
                    Tokens.Add(token);
                }
            }
            KeyWords = GetKeyWords();
            Symbols = GetSymbols();
        }

        public TokenTypeEnum GetTokenType()
        {
            var token = Tokens[CurrIndex];
            if (KeyWords.Contains(token))
            {
                return TokenTypeEnum.KeyWord;
            }
            else if (Symbols.Contains(token))
            {
                return TokenTypeEnum.Symbol;
            }
            else if (int.TryParse(token, out _) && int.Parse(token) <= 32767)
            {
                return TokenTypeEnum.IntConst;
            }
            else if (token[0].Equals('"'))
            {
                return TokenTypeEnum.StringConst;
            }

            return TokenTypeEnum.Identifier;

        }

        public string GetToken()
        {
            return Tokens[CurrIndex];
        }


        public bool HasMoreTokens()
        {
            return CurrIndex < Tokens.Count -1;
        }

        public void Advance()
        {
            if (HasMoreTokens())
            {
                CurrIndex++;
                return;
            }

            throw new NotAbleToAdvanceException();
        }

        private static IEnumerable<string> GetSymbols()
        {
            return new List<string>
            {
                "{","}","(",")","[","]",".",",",";","+","-","*","/","&","|","<",">","=","~"
            };
        }

        private static IEnumerable<string> GetKeyWords()
        {
            return new List<string>
            {
                "class", "constructor", "function", "method", "field", "static", "var","int", "char", "boolean", "void", "true", "false", "null", "this", "let", "do", "if", "else", "while", "return"
            };
        }

    }
}
