namespace JackAnalyzer;

internal class Token
{
    public XmlTag Tag;
    public Token(string value, TokenTypeEnum tokenType)
    {
        Value = value;
        TokenType = tokenType;
        Tag = new XmlTag(tokenType);
    }
    public string Value { get; set; }
    public TokenTypeEnum TokenType { get; set; }
}
