namespace LexicalAnalysis.Exceptions;

public class WrongSymbolException : Exception
{
    public WrongSymbolException(char symbol) : base($"Unexpected symbol: {symbol}") {}
}