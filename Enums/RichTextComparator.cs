using System.ComponentModel;

namespace NotionSDK.Enums;

public enum RichTextComparator
{
    [Description("contains")]
    Contains,
    [Description("does_not_contain")]
    DoesNotContain,
    [Description("does_not_equal")]
    NotEquals,
    [Description("ends_with")]
    EndsWith,
    [Description("equals")]
    Equals,
    [Description("is_empty")]
    IsEmpty,
    [Description("is_not_empty")]
    IsNotEmpty,
    [Description("starts_with")]
    StartsWith
}