using System.ComponentModel;

namespace NotionSDK.Enums;

public enum RelationComparator
{
    [Description("contains")]
    Contains,
    [Description("does_not_contain")]
    DoesNotContain,
    [Description("is_empty")]
    IsEmpty,
    [Description("is_not_empty")]
    IsNotEmpty
}