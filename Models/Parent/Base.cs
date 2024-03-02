using Newtonsoft.Json;

namespace NotionSDK.Models.Parent;

internal class Base
{
    [JsonProperty("type")]
    public string? Type { get; set; }
}