using LexicalAnalysis.Extensions;
using LexicalAnalysis.Types;

namespace Tokens;

public class IdentifierToken : Token
{
    private static readonly string _categoryVar = "var";
    private static readonly string _categoryType = "type";
    
    private readonly string _attrName;
    private readonly string _attrValue;
    private readonly string _type;
    private readonly string _category;
    
    private static readonly List<IdentifierToken> IdentifierTokens = new List<IdentifierToken>()
    {
        new IdentifierToken(value: 0, attrName: TypesEnum.Int.Description(), attrValue: TypesEnum.Int.Description(), type: string.Empty, catergory: IdentifierToken._categoryType),
        new IdentifierToken(value: 0, attrName: TypesEnum.Float.Description(), attrValue: TypesEnum.Float.Description(), type: string.Empty, catergory: IdentifierToken._categoryType),
        new IdentifierToken(value: 0, attrName: TypesEnum.Boolean.Description(), attrValue: TypesEnum.Boolean.Description(), type: string.Empty, catergory: IdentifierToken._categoryType),
    };


    public IdentifierToken()
    {
        _attrName = string.Empty;
        _type = string.Empty;
        _category = string.Empty;
    }

    private IdentifierToken(string type, string attrName, int value, string attrValue, string catergory = "") : 
        base(name: "id", code: 25, value: value)
    {
        _type = type;
        _attrName = attrName;
        _attrValue = attrValue;
        _category = catergory;
    }

    public static IdentifierToken GetOrCreate(string lexeme)
    {
        if (string.IsNullOrEmpty(lexeme))
            return null;

        var found = IdentifierTokens.Find(x => x._attrName == lexeme);
        if (found != null)
            return found;

        int tokenValue = IdentifierTokens.Count;
        var newToken = new IdentifierToken(value: tokenValue, attrName: lexeme, type: string.Empty, attrValue: string.Empty);
        IdentifierTokens.Add(newToken);
        return newToken;
    }
}