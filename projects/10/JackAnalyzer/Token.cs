namespace JackAnalyzer;

internal class Token
{
    public XmlTag Tag;
    public string Value { get; set; }
    public TokenTypeEnum TokenType { get; set; }
    public Token(string value, TokenTypeEnum tokenType)
    {
        Value = value;
        TokenType = tokenType;
        Tag = new XmlTag(tokenType);
    }

    public bool IsStatemnent()
        => new List<string>{ "let", "while", "do", "return"}.Contains(Value);

    public bool IsWhileORIf()
        => new List<string> { "while", "if"}.Contains(Value);

    public bool IsTerm()
        => TokenType.Equals(TokenTypeEnum.IntConst) || TokenType.Equals(TokenTypeEnum.StringConst);

    internal bool IsOp()
        => new List<string> { "+", "-", "*", "/", "&", "|", "<", ">", "=" }.Contains(Value);
}
