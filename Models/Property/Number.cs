using Newtonsoft.Json;

namespace NotionSDK.Models.Property;

public class Number
{
    [JsonProperty("number", NullValueHandling = NullValueHandling.Ignore)]
    public int Value { get; set; }
}