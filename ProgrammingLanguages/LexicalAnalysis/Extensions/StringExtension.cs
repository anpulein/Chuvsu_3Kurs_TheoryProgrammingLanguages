using LexicalAnalysis.Models;

namespace LexicalAnalysis.Extensions;

public static class StringExtension
{
    public static string ChangePrefixToTabs(this string str)
    {
        string prefix = Constants.TabSpaces;
        while (str.StartsWith(prefix))
        {
            str = '\t' + str[prefix.Length..];
        }

        return str;
    }
}