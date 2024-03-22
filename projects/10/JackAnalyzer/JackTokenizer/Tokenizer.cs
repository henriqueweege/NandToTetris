using JackAnalyzer.JackTokenizer.Exceptions;
using System.Text;

namespace JackAnalyzer.JackTokenizer
{
    internal class Tokenizer
    {
        private IList<Token> Tokens = new List<Token>();
        private IEnumerable<string> KeyWords;
        private IEnumerable<string> Symbols;
        private int CurrIndex = 0;
            string name;

        public Tokenizer(string[] fileRows, string name)
        {


                this.name = name;

            //TODO : 
            // as string que são constantes não estão sendo
            //tratadas da maneira adequada. Está sendo splitado
            //por conta do espaço em branco, tem que pensar
            //em: ou uma maneira de tratar string nesse caso,
            //ou outra maneira de fazer o split da linha 34.


            KeyWords = GetKeyWords();
            Symbols = GetSymbols();
            foreach (var row in fileRows)
            {
                if (row.StartsWith("//"))
                {
                    continue;
                }
                var openPar = "(";
                var closePar = "(";
                var openCurlyBrac = "{";
                var closeCurlyBrac = "}";
                var semiColumn = ";";
                var openBrac = "]";
                var closeBrac = "[";
                var comma = ",";
                var dot = ".";

                var treatedRow = row.Replace("(", " ( ").Replace(")", " ) ").Replace(";", " ; ").Replace(@"\", "");

                for (var i = 0; i < treatedRow.Length; i++)
                {
                    var tokenBuilder = new StringBuilder();
                    var currChar = treatedRow[i];
                    if(currChar == ' ') 
                    {
                        continue;
                    }
                    if (treatedRow.Contains("How"))
                    {

                    }
                    if (currChar == '"')
                    {
                        while (treatedRow[i+1] != '"' && i < treatedRow.Length)
                        {
                            tokenBuilder.Append(currChar);
                            try
                            {
                                currChar = treatedRow[++i];
                            }
                            catch
                            {

                            }
                        }
                        i++;
                        tokenBuilder.Append('"');

                    }
                    else
                    {
                        while (currChar != ' ' && i < treatedRow.Length && currChar != '\\')
                        {
                            tokenBuilder.Append(currChar);
                            try
                            {
                                currChar = treatedRow[++i];
                            }
                            catch
                            {

                            }
                        }
                    }

                    var token = tokenBuilder.ToString();


                    if (string.IsNullOrWhiteSpace(token)) continue;

                    var validToken = new StringBuilder();
                    foreach (var c in token)
                    {
                        if (c.ToString().Equals(openPar))
                        {
                            AddCurrToken(validToken);
                            Tokens.Add(new Token(openPar, GetTokenType(openPar)));
                            validToken = new StringBuilder();
                            continue;
                        }
                        if (c.ToString().Equals(openCurlyBrac))
                        {
                            AddCurrToken(validToken);
                            Tokens.Add(new Token(openCurlyBrac, GetTokenType(openCurlyBrac)));
                            validToken = new StringBuilder();
                            continue;
                        }
                        if (c.ToString().Equals(openBrac))
                        {
                            AddCurrToken(validToken);
                            Tokens.Add(new Token(openBrac, GetTokenType(openBrac)));
                            validToken = new StringBuilder();
                            continue;
                        }
                        if (c.ToString().Equals(closePar))
                        {
                            AddCurrToken(validToken);

                            Tokens.Add(new Token(closePar, GetTokenType(closePar)));
                            validToken = new StringBuilder();
                            continue;
                        }
                        if (c.ToString().Equals(closeCurlyBrac))
                        {
                            AddCurrToken(validToken);

                            Tokens.Add(new Token(closeCurlyBrac, GetTokenType(closeCurlyBrac)));
                            validToken = new StringBuilder();
                            continue;
                        }
                        if (c.ToString().Equals(closeBrac))
                        {
                            AddCurrToken(validToken);

                            Tokens.Add(new Token(closeBrac, GetTokenType(closeBrac)));
                            validToken = new StringBuilder();
                            continue;
                        }
                        if (c.ToString().Equals(semiColumn))
                        {
                            AddCurrToken(validToken);

                            Tokens.Add(new Token(semiColumn, GetTokenType(semiColumn)));
                            validToken = new StringBuilder();
                            continue;
                        }
                        if (c.ToString().Equals(comma))
                        {
                            AddCurrToken(validToken);

                            Tokens.Add(new Token(comma, GetTokenType(comma)));
                            validToken = new StringBuilder();
                            continue;
                        }
                        if (c.ToString().Equals(dot))
                        {
                            AddCurrToken(validToken);

                            Tokens.Add(new Token(dot, GetTokenType(dot)));
                            validToken = new StringBuilder();
                            continue;
                        }
                        if (!string.IsNullOrWhiteSpace(c.ToString()))
                        {
                            validToken.Append(c);
                        }
                    }
                    AddCurrToken(validToken);
                }
            }

        }

        private void AddCurrToken(StringBuilder validToken)
        {
            if (validToken.ToString().Length == 0) return;
            var tokenType = GetTokenType(validToken.ToString());
            Tokens.Add(new Token(validToken.ToString(), tokenType));
        }

        private TokenTypeEnum GetTokenType(string token)
        {
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

        public Token GetToken()
        {
            return Tokens[CurrIndex];
        }


        public bool HasMoreTokens()
        {
            return CurrIndex < Tokens.Count - 1;
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
