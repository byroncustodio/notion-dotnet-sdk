using Newtonsoft.Json;

namespace NotionSDK.Models.Property;

public class Status : PageProperty
{
    public Status(StatusData data)
    {
        Data = data;
    }

    [JsonProperty("status")]
    public StatusData Data { get; set; }
}

public class StatusData
{
    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public string? Id { get; set; }

    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string? Name { get; set; }

    [JsonProperty("color")]
    public string? Color { get; set; } = "default";
}