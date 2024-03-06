using Newtonsoft.Json;

namespace NotionSDK.Models.Property;

public class Number : PageProperty
{
    public Number(NumberData data)
    {
        Data = data;
    }

    [JsonProperty("number")]
    public NumberData Data { get; set; }
}

public class NumberData
{
    [JsonProperty("number", NullValueHandling = NullValueHandling.Ignore)]
    public int Value { get; set; }
}