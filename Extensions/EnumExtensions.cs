namespace Converter.Extensions;

public static class EnumExtensions
{
    public static string GetDescription(this Enum value)
    {
        if (value == null)
        {
            return "Unknown";
        }

        var field = value.GetType().GetField(value.ToString());
        var attribute = field?.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute;

        return attribute?.Description ?? value.ToString();
    }
}
