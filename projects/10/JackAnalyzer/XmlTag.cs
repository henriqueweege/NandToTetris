namespace JackAnalyzer
{
    public class XmlTag
    {
        internal TokenTypeEnum TokenType { get; private set; }
        internal string Begin { get; private set; }
        internal string End { get; private set; }

        internal XmlTag(TokenTypeEnum tokenType, string tagName)
        {
            TokenType = tokenType;
            Begin = $"<{tagName}>";
            End = $"<{tagName}>";
        }

    }
}
