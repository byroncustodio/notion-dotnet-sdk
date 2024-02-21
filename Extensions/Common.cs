using System.ComponentModel;
using System.Reflection;

namespace NotionSDK.Extensions
{
    public static class Common
    {
        public static string? GetDescription(this Enum value)
        {
            Type type = value.GetType();
            var name = Enum.GetName(type, value) ?? throw new Exception($"Could not find enum with name '{value.ToString()}'");
            FieldInfo? field = type.GetField(name) ?? throw new Exception($"Error accessing field properties for '{name}'");

            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attr)
            {
                return attr.Description;
            }

            return null;
        }
    }
}
