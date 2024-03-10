using Newtonsoft.Json;

namespace NotionSDK.Models.Property;

public class Number : PageProperty
{
    [JsonConstructor]
    public Number(decimal value)
    {
        Value = value;
    }

    [JsonProperty("number")]
    public decimal? Value { get; set; }
}