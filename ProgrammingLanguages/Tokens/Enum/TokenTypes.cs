namespace Tokens.Enum;

public enum TokenTypes
{
    [Token("and", 1, 0)]
    And,
    [Token("block", 2, 0)]
    BlockVarDef,
    [Token("case", 3, 0)]
    Case,
    [Token("class", 4, 0)]
    Class,
    [Token("end", 5, 0)]
    EndProg,
    [Token("endblock", 6, 0)]
    EndBlockVarDef,
    [Token("False", 7, 0)]
    False,
    [Token("match", 8, 0)]
    Match, 
    [Token("nl", 9, 0)]
    Nl,
    [Token("not", 10, 0)]
    Not,
    [Token("ot", 11, 0)]
    Or,
    [Token("start", 12, 0)]
    StartProg,
    [Token("tab", 13, 0)]
    Tab,
    [Token("True", 14, 0)]
    True,
    [Token("(", 15, 0)]
    OpenBracket,
    [Token(")", 16, 0)]
    CloseBracket,
    [Token("ass", 17, 0)]
    Assigment,
    [Token(":", 18, 0)]
    Colon,
    [Token(",", 19, 0)]
    Comma,
    [Token("_", 20, 0)]
    Underscore,
    [Token("add_op", 21, 0)]
    Plus,
    [Token("add_op", 21, 1)]
    Minus,
    [Token("mult_op", 22, 0)]
    Mult,
    [Token("mult_op", 22, 1)]
    Div,
    [Token("rel", 23, 0)]
    Equal,
    [Token("rel", 23, 1)]
    NotEqual,
    [Token("rel", 23, 2)]
    More,
    [Token("rel", 23, 3)]
    MoreEqual,
    [Token("rel", 23, 4)]
    Less,
    [Token("rel", 23, 5)]
    LessEqual,
    [Token("pt", 24, 0)]
    Point,
    [DigitalToken]
    Digital,
    [IdentifierToken]
    Identifier
}

[AttributeUsage(AttributeTargets.Field)]
sealed class TokenAttribute : Attribute
{
    public Token Token;

    public TokenAttribute(string name, int code, int value)
    {
        Token = new Token(name, code, value);
    }
}

[AttributeUsage(AttributeTargets.Field)]
sealed class DigitalTokenAttribute : Attribute
{
    public DigitalToken Token;

    public DigitalTokenAttribute()
    {
        Token = new DigitalToken();
    }
}

[AttributeUsage(AttributeTargets.Field)]
sealed class IdentifierTokenAttribute : Attribute
{
    public IdentifierToken Token;

    public IdentifierTokenAttribute()
    {
        Token = new IdentifierToken();
    }
}