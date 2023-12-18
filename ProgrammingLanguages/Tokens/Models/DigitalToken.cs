using System.Globalization;
using LexicalAnalysis.Extensions;
using LexicalAnalysis.Types;

namespace Tokens;

public class DigitalToken : Token
{

    private readonly double _attr;
    private readonly string _type;

    private static readonly List<DigitalToken> DigitalTokens = new List<DigitalToken>();

    public DigitalToken()
    {
        _attr = default;
        _type = String.Empty;
    }
    
    private DigitalToken(string type, double attr, int value) : base(name: "num", code: 26, value: value)
    {
        _attr = attr;
        _type = type;
    }

    public static DigitalToken GetOrCreate(string lexeme, TypesEnum type)
    {
        double attr = double.Parse(lexeme, CultureInfo.InvariantCulture);
        if (type == TypesEnum.Int)
            attr = (int)attr;

        var found = DigitalTokens.Find(x => Math.Abs(x._attr - attr) < double.Epsilon && x._type == type.Description());
        if (found != null)
            return found;

        int tokenValue = DigitalTokens.Count;
        var newToken = new DigitalToken(value: tokenValue, attr: attr, type: type.Description());
        DigitalTokens.Add(newToken);
        return newToken;
    }
    
}