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

        public Tokenizer(string[] fileRows)
        {
            KeyWords = GetKeyWords();
            Symbols = GetSymbols();
            GetTokens(fileRows);
        }

        public bool IsFuncCall()
            => (Tokens[CurrIndex].TokenType.Equals(TokenTypeEnum.Identifier) && NextToken().Value.Equals(".")) || (Tokens[CurrIndex].Value.Equals("(") && Tokens[CurrIndex -1 ].IsWhileORIf());

        private void GetTokens(string[] fileRows)
        {
            foreach (var row in fileRows)
            {
                if (row.StartsWith("//"))
                {
                    continue;
                }

                var openPar = "(";
                var closePar = ")";
                var openCurlyBrac = "{";
                var closeCurlyBrac = "}";
                var semiColumn = ";";
                var openBrac = "[";
                var closeBrac = "]";
                var comma = ",";
                var dot = ".";

                var treatedRow = row
                                    .Replace("(", " ( ")
                                    .Replace(")", " ) ")
                                    .Replace(";", " ; ")
                                    .Replace(@"\", "")
                                    .Split("//").First();

                for (var i = 0; i < treatedRow.Length; i++)
                {
                    var tokenBuilder = new StringBuilder();
                    var currChar = treatedRow[i];
                    if (currChar == ' ')
                    {
                        continue;
                    }
                    if (treatedRow.Contains("How"))
                    {

                    }
                    if (currChar == '"')
                    {
                        while (treatedRow[i + 1] != '"' && i < treatedRow.Length)
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

                    if (token.Contains("."))
                    {
                        var functionCall = token.Split(".");

                        var tokenType = GetTokenType(functionCall[0]);
                        Tokens.Add(new Token(functionCall[0], tokenType));

                        tokenType = GetTokenType(".");
                        Tokens.Add(new Token(".", tokenType));

                        tokenType = GetTokenType(functionCall[1]);
                        Tokens.Add(new Token(functionCall[1], tokenType));

                        continue;

                    }

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

        public bool IsVoidFunction()
        {
            return Tokens[CurrIndex].IsFunction() && Tokens[CurrIndex + 1].IsVoid();
        }

        public bool IsParameterlessFunction()
        {
            return Tokens[CurrIndex].Value.Equals("(") && Tokens[CurrIndex + 1].Value.Equals(")");
        }

        public bool IsVarName()
        {
            return CurrIndex - 2 > 0 && Tokens[CurrIndex].TokenType.Equals(TokenTypeEnum.Identifier) && Tokens[CurrIndex - 2].Value.Equals("var");
        }
        public Token GetToken()
        {
            return Tokens[CurrIndex];
        }

        public Token NextToken()
        {
            if (HasMoreTokens())
            {
                return Tokens[CurrIndex + 1];
            }
            throw new NotAbleToAdvanceException();
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
                "class", "constructor", "function", "method", "field", "static", "var","int", "char", "boolean", "void", "true", "false", "null", "this", "let", "do", "if", "else", "while", "return", "Array"
            };
        }

        internal Token LastToken()
            => Tokens[CurrIndex - 1];

        internal bool IsFuncDec()
        {
            var x = Tokens[CurrIndex - 3];
            return CurrIndex - 3 > 0 && Tokens[CurrIndex -3].Value.Equals("function");
        }
    }
}
