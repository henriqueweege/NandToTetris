using JackAnalyzer.JackTokenizer;
using JackAnalyzer.JackTokenizer.Exceptions;
using System.Text;

namespace JackAnalyzer.CompilationEngine
{
    internal class Engine
    {
        private IEnumerable<XmlTag> Tags { get; set; }
        private Tokenizer _tokenizer { get; set; }

        public StringBuilder XMLBuilder { get; private set; }

        public Engine(Tokenizer tokenizer)
        {
            XMLBuilder = new StringBuilder();
            _tokenizer = tokenizer;
            Tags = new List<XmlTag>
            {
                new XmlTag(TokenTypeEnum.KeyWord, "keyword"),
                new XmlTag(TokenTypeEnum.Identifier, "identifier"),
                new XmlTag(TokenTypeEnum.Symbol, "symbol"),
                new XmlTag(TokenTypeEnum.StringConst, "stringconst"),
                new XmlTag(TokenTypeEnum.IntConst, "intconst"),
                new XmlTag(TokenTypeEnum.ParamList, "parameterList")

            };
        }

        public void GenerateXML()
        {
            var token = _tokenizer.GetToken();

            if (token.Equals("function"))
            {
                TreatFunction();
            }
            else if (token.Equals("var"))
            {
                TreatVar();
            }
            else
            {
                var tokenType = _tokenizer.GetTokenType();
                var tag = Tags.First(x => x.TokenType.Equals(tokenType));
                Insert(token, tag);
            }


            try
            {
                _tokenizer.Advance();
            }
            catch (NotAbleToAdvanceException)
            {
                return;
            }
            GenerateXML();
        }

        private void Insert(string token, XmlTag tag)
        {
            XMLBuilder.AppendLine($"{tag.Open}{token}{tag.Close}");
        }

        private void TreatVar()
        {
            throw new NotImplementedException();
        }

        private void TreatFunction()
        {
            var tag = Tags.First(x => x.TokenType.Equals(TokenTypeEnum.KeyWord));
            XMLBuilder.AppendLine($"{tag.Open}function{tag.Close}");

            _tokenizer.Advance();

            var returnToken = _tokenizer.GetToken();
            var returnType = _tokenizer.GetTokenType();
            var returnTag = Tags.First(x => x.TokenType.Equals(returnType));
            XMLBuilder.AppendLine($"{tag.Open}{returnToken}{tag.Close}");

            _tokenizer.Advance();

            var functionIdentifier = _tokenizer.GetToken().Split("(");
            var identifierTag = Tags.First(x => x.TokenType.Equals(TokenTypeEnum.Identifier));
            var symbolTag = Tags.First(x => x.TokenType.Equals(TokenTypeEnum.Symbol));

            XMLBuilder.AppendLine($"{identifierTag.Open}{functionIdentifier[0]}{identifierTag.Close}");
            XMLBuilder.AppendLine($"{symbolTag.Open}({symbolTag.Close}");

            var paramTag = Tags.First(x => x.TokenType.Equals(TokenTypeEnum.ParamList));
           
            XMLBuilder.Append(paramTag.Open);
            if (!functionIdentifier[1].Equals(")"))
            {

                XMLBuilder.Append($"{functionIdentifier[1].Split(")")[0]}");
            }
            XMLBuilder.Append($"{paramTag.Close}\n");


            XMLBuilder.AppendLine($"{symbolTag.Open}){symbolTag.Close}");
        }

    }
}
