using System.Reflection;
using Tokens.Enum;

namespace Tokens.Extensions;

public static class TokenTypeExtensions
{
    public static Token GetToken(this TokenTypes type)
    {
        FieldInfo? fieldInfo = type.GetType().GetField(type.ToString());
        TokenAttribute[] attributes = (fieldInfo?.GetCustomAttributes(typeof(TokenAttribute), false) as TokenAttribute[]) ?? Array.Empty<TokenAttribute>();

        if (attributes.Length > 0)
        {
            return attributes[0].Token;
        }

        throw new InvalidOperationException($"No Token found for {type.ToString()}");
    }
}