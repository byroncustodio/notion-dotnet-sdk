using System.ComponentModel;

namespace NotionSDK.Extensions;

public static class Common
{
    public static string GetDescription(this Enum value)
    {
        var type = value.GetType();
        var name = Enum.GetName(type, value) ?? throw new Exception($"Could not find enum with name '{value.ToString()}'");
        var field = type.GetField(name) ?? throw new Exception($"Error accessing field properties for '{name}'");

            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attr)
            {
                return attr.Description;
            }

            return value.ToString();
        }
    }
}