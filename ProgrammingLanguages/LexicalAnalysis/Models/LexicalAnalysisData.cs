using LexicalAnalysis.Extensions;
using LexicalAnalysis.Types;
using Tokens.Enum;

namespace LexicalAnalysis.Models;

public static class LexicalAnalysisData
{
    public static readonly Dictionary<string, List<int>> StateTransitionTable = new Dictionary<string, List<int>>
    {
        { "(", new List<int> { -1, -11, 2, -13, int.MaxValue, -16, -18, -20, -21, int.MaxValue, int.MaxValue, -22, int.MaxValue, -22 } },
        { ")", new List<int> { -2, -11, 2, -13, int.MaxValue, -16, -18, -20, -21, int.MaxValue, int.MaxValue, -22, int.MaxValue, -22 } },
        { ":", new List<int> { -3, -11, 2, -13, int.MaxValue, -16, -18, -20, -21, int.MaxValue, int.MaxValue, -22, int.MaxValue, -22 } },
        { ",", new List<int> { -4, -11, 2, -13, int.MaxValue, -16, -18, -20, -21, int.MaxValue, int.MaxValue, -22, int.MaxValue, -22 } },
        { "_", new List<int> { -5, -11, 2, -13, int.MaxValue, -16, -18, 7, -21, int.MaxValue, int.MaxValue, -22, int.MaxValue, -22 } },
        { "+", new List<int> { -6, -11, 2, -13, int.MaxValue, -16, -18, -20, -21, int.MaxValue, 12, -22, int.MaxValue, -22 } },
        { "-", new List<int> { -7, -11, 2, -13, int.MaxValue, -16, -18, -20, -21, int.MaxValue, 12, -22, int.MaxValue, -22 } },
        { "*", new List<int> { -8, -11, 2, -13, int.MaxValue, -16, -18, -20, -21, int.MaxValue, int.MaxValue, -22, int.MaxValue, -22 } },
        { "/", new List<int> { -9, -11, 2, -13, int.MaxValue, -16, -18, -20, -21, int.MaxValue, int.MaxValue, -22, int.MaxValue, -22 } },
        { ".", new List<int> { -25, -11, 2, -13, int.MaxValue, -16, -18, -20, 9, int.MaxValue, int.MaxValue, -22, int.MaxValue, -22 } },
        { " ", new List<int> { 1, 1, 2, -13, int.MaxValue, -16, -18, -20, -21, int.MaxValue, int.MaxValue, -22, int.MaxValue, -22 } },
        { "{", new List<int> { 2, -11, 2, -13, int.MaxValue, -16, -18, -20, -21, int.MaxValue, int.MaxValue, -22, int.MaxValue, -22 } },
        { "}", new List<int> { int.MaxValue, -11, -12, -13, int.MaxValue, -16, -18, -20, -21, int.MaxValue, int.MaxValue, -22, int.MaxValue, -22 } },
        { "digits", new List<int> { 8, -11, 2, -13, int.MaxValue, -16, -18, 7, 8, 11, 13, 11, 13, 13 } },
        { "e", new List<int> { int.MaxValue, -11, 2, -13, int.MaxValue, -16, -18, -20, 10, int.MaxValue, int.MaxValue, -22, int.MaxValue, -22 } },
        { "=", new List<int> { 3, -11, 2, -14, -15, -17, -19, -20, -21, int.MaxValue, int.MaxValue, -22, int.MaxValue, -22 } },
        { "!", new List<int> { 4, -11, 2, -13, int.MaxValue, -16, -18, -20, -21, int.MaxValue, int.MaxValue, -22, int.MaxValue, -22 } },
        { ">", new List<int> { 5, -11, 2, -13, int.MaxValue, -16, -18, -20, -21, int.MaxValue, int.MaxValue, -22, int.MaxValue, -22 } },
        { "<", new List<int> { 6, -11, 2, -13, int.MaxValue, -16, -18, -20, -21, int.MaxValue, int.MaxValue, -22, int.MaxValue, -22 } },
        { "letters", new List<int> { 7, -11, 2, -13, int.MaxValue, -16, -18, 7, -21, int.MaxValue, int.MaxValue, -22, int.MaxValue, -22 } },
        { "\n", new List<int> { -23, -11, 2, -13, int.MaxValue, -16, -18, -20, -21, int.MaxValue, int.MaxValue, -22, int.MaxValue, -22 } },
        { "\t", new List<int> { -24, -11, 2, -13, int.MaxValue, -16, -18, -20, -21, int.MaxValue, int.MaxValue, -22, int.MaxValue, -22 } },
        { "another", new List<int> { int.MaxValue, int.MaxValue, 2, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue } },
    };

    public static readonly Dictionary<int, TokenTypes> StateTokenMapping = new Dictionary<int, TokenTypes>
    {
        { -1, TokenTypes.OpenBracket },
        { -2, TokenTypes.CloseBracket },
        { -3, TokenTypes.Colon },
        { -4, TokenTypes.Comma },
        { -5, TokenTypes.Underscore },
        { -6, TokenTypes.Plus },
        { -7, TokenTypes.Minus },
        { -8, TokenTypes.Mult },
        { -9, TokenTypes.Div },
        { -13, TokenTypes.Assigment },
        { -14, TokenTypes.Equal },
        { -15, TokenTypes.NotEqual },
        { -16, TokenTypes.More },
        { -17, TokenTypes.MoreEqual },
        { -18, TokenTypes.Less },
        { -19, TokenTypes.LessEqual },
        { -25, TokenTypes.Point },
    };
    
    public static readonly Dictionary<string, TokenTypes> KeywordsTokenMapping = new Dictionary<string, TokenTypes>
    {
        { KeywordsEnum.And.Description(), TokenTypes.And },
        { KeywordsEnum.BlockVarDef.Description(), TokenTypes.BlockVarDef },
        { KeywordsEnum.Case.Description(), TokenTypes.Case },
        { KeywordsEnum.Class.Description(), TokenTypes.Class },
        { KeywordsEnum.EndProg.Description(), TokenTypes.EndProg },
        { KeywordsEnum.EndBlockVarDef.Description(), TokenTypes.EndBlockVarDef },
        { KeywordsEnum.False.Description(), TokenTypes.False },
        { KeywordsEnum.Match.Description(), TokenTypes.Match },
        { KeywordsEnum.NewLine.Description(), TokenTypes.Nl },
        { KeywordsEnum.Not.Description(), TokenTypes.Not },
        { KeywordsEnum.Or.Description(), TokenTypes.Or },
        { KeywordsEnum.StartProg.Description(), TokenTypes.StartProg },
        { KeywordsEnum.Tab.Description(), TokenTypes.Tab },
        { KeywordsEnum.True.Description(), TokenTypes.True },
    };
}