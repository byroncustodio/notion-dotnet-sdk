using Newtonsoft.Json;

namespace NotionSDK.Models.Property;

public class Url : PageProperty
{
    [JsonConstructor]
    public Url(string value)
    {
        Value = value;
    }

    [JsonProperty("url")]
    public string? Value { get; set; }
}