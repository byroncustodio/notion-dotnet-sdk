using Newtonsoft.Json;

namespace NotionSDK.Models;

public class DatabaseProperty
{
    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("type")]
    public string? Type { get; set; }
}