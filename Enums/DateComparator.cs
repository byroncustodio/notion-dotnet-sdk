using System.ComponentModel;

namespace NotionSDK.Enums;

public enum DateComparator
{
    [Description("after")]
    After,
    [Description("before")]
    Before,
    [Description("equals")]
    Equals,
    [Description("is_empty")]
    IsEmpty,
    [Description("is_not_empty")]
    IsNotEmpty,
    [Description("next_month")]
    NextMonth,
    [Description("next_week")]
    NextWeek,
    [Description("next_year")]
    NextYear,
    [Description("on_or_after")]
    OnOrAfter,
    [Description("on_or_before")]
    OnOrBefore,
    [Description("past_month")]
    PastMonth,
    [Description("past_week")]
    PastWeek,
    [Description("past_year")]
    PastYear,
    [Description("this_week")]
    ThisWeek,
}