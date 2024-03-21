namespace JackAnalyzer
{
    public class XmlTag
    {
        internal TokenTypeEnum TokenType { get; private set; }
        internal string Open { get; private set; }
        internal string Close { get; private set; }

        internal XmlTag(TokenTypeEnum tokenType, string tagName)
        {
            TokenType = tokenType;
            Open = $"<{tagName}>";
            Close = $"</{tagName}>";
        }

    }
}
