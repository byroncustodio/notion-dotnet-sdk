using Newtonsoft.Json;

namespace NotionSDK.Models.Property;

public class Date : PageProperty
{
    public Date(DateData data)
    {
        Data = data;
    }

    [JsonProperty("date")]
    public DateData Data { get; set; }
}

public class DateData
{
    [JsonProperty("start", NullValueHandling = NullValueHandling.Ignore)]
    public string? Start { get; set; }

    [JsonProperty("end", NullValueHandling = NullValueHandling.Ignore)]
    public string? End { get; set; }

    [JsonProperty("time_zone", NullValueHandling = NullValueHandling.Ignore)]
    public string? TimeZone { get; set; }
}