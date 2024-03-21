namespace JackAnalyzer;

internal class Token
{
    public Token(string value, TokenTypeEnum tokenType)
    {
        Value = value;
        TokenType = tokenType;
    }
    public string Value { get; set; }
    public TokenTypeEnum TokenType { get; set; }
}
