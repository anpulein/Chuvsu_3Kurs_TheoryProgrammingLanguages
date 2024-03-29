using System.ComponentModel;
using System.Reflection;

namespace LexicalAnalysis.Extensions;

public static class EnumExtension
{
    public static string Description(this Enum value)
    {
        FieldInfo? field = value.GetType().GetField(value.ToString());
        DescriptionAttribute? attribute = field?.GetCustomAttribute<DescriptionAttribute>();
        return attribute?.Description ?? value.ToString();
    }
}