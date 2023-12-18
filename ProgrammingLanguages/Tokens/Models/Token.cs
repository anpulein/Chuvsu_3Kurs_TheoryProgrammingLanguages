using Tokens.Interface;

namespace Tokens;

public class Token : IToken
{
    public string Name { get; }
    public int Code { get; }
    public int Value { get; }
    
    protected Token () {}

    public Token(string name, int code, int value)
    {
        Name = name;
        Code = code;
        Value = value;
    }

    public new string ToString() => $"<{Name}, {Value}>";
}

