namespace Tokens.Interface;

public interface IToken
{
    public string Name { get; }
    public int Code { get; }
    public int Value { get; }
    
    public string ToString();
}