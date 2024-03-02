using Newtonsoft.Json;

namespace NotionSDK.Models;

public class DatabaseProperty
{
    public DatabaseProperty(string id, string name, string type)
    {
        Id = id;
        Name = name;
        Type = type;
    }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }
}