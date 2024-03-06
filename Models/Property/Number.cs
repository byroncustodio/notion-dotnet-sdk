using Newtonsoft.Json;

namespace NotionSDK.Models.Property;

public class Number : PageProperty
{
    public Number(NumberData data)
    {
        Data = data;
    }

    public Number(decimal value)
    {
        Data = new NumberData
        {
            Value = value
        };
    }

    [JsonProperty("number")]
    public NumberData Data { get; set; }
}

public class NumberData
{
    [JsonProperty("number", NullValueHandling = NullValueHandling.Ignore)]
    public decimal Value { get; set; }
}