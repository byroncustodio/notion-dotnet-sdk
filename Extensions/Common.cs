﻿using System.ComponentModel;
using System.Reflection;

namespace NotionSDK.Extensions
{
    public static class Common
    {
        public static string? GetDescription(this Enum value)
        {
            Type type = value.GetType();
            string? name = Enum.GetName(type, value);

            if (name != null)
            {
                FieldInfo? field = type.GetField(name);

                if (field != null)
                {
                    if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attr)
                    {
                        return attr.Description;
                    }
                }
            }

            return null;
        }
    }
}
