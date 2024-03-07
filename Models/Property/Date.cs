using Newtonsoft.Json;

namespace NotionSDK.Models.Property;

public class Date : PageProperty
{
    [JsonConstructor]
    public Date(DateData data)
    {
        Data = data;
    }

    public Date(string? start, string? timezone = null)
    {
        Data = new DateData
        {
            Start = start,
            TimeZone = timezone
        };
    }
    
    public Date(string? start, string? end = null, string? timezone = null)
    {
        Data = new DateData
        {
            Start = start,
            End = end,
            TimeZone = timezone
        };
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