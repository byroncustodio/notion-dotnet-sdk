using System.ComponentModel;

namespace NotionSDK.Enums;

public enum Timestamp
{
    [Description("created_time")]
    CreatedTime,
    [Description("last_edited_time")]
    LastEditedTime
}