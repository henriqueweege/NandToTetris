namespace JackAnalyzer
{
    public class XmlTag
    {
        internal TokenTypeEnum TokenType { get; private set; }
        internal string Open { get; private set; }
        internal string Close { get; private set; }

        internal XmlTag(TokenTypeEnum tokenType)
        {
            TokenType = tokenType;
            var tagName = GetTagName();
            Open = $"<{tagName}>";
            Close = $"</{tagName}>";
        }

        private string GetTagName()
        {
            switch (TokenType)
            {
                case TokenTypeEnum.KeyWord:
                    return "keyword";
                case TokenTypeEnum.Symbol:
                    return "symbol";
                case TokenTypeEnum.Identifier:
                    return "identifier";
                case TokenTypeEnum.IntConst: 
                    return "integerConstant";
                case TokenTypeEnum.StringConst:
                    return "stringConstant";
                default:
                    return string.Empty;
            }
        }

    }
}
