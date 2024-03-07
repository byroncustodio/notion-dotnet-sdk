﻿using System.ComponentModel;

namespace NotionSDK.Enums;

public enum StatusComparator
{
    [Description("equals")]
    Equals,
    [Description("does_not_equal")]
    NotEquals,
    [Description("is_empty")]
    IsEmpty,
    [Description("is_not_empty")]
    IsNotEmpty
}