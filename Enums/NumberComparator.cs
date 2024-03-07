using System.ComponentModel;

namespace NotionSDK.Enums;

public enum NumberComparator
{
    [Description("does_not_equal")]
    NotEquals,
    [Description("equals")]
    Equals,
    [Description("greater_than")]
    GreaterThan,
    [Description("greater_than_or_equal_to")]
    GreaterThanOrEqualTo,
    [Description("is_empty")]
    IsEmpty,
    [Description("is_not_empty")]
    IsNotEmpty,
    [Description("less_than")]
    LessThan,
    [Description("less_than_or_equal_to")]
    LessThanOrEqualTo
}