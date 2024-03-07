using Newtonsoft.Json;

namespace NotionSDK.Models.Property;

public class Status : PageProperty
{
    [JsonConstructor]
    public Status(StatusData data)
    {
        Data = data;
    }
    
    public Status(string? name)
    {
        Data = new StatusData
        {
            Name = name
        };
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

    [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
    public string? Color { get; set; }
}