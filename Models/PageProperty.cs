using Newtonsoft.Json;

namespace NotionSDK.Models;

public class PageProperty
{
    public PageProperty(string id, string type)
    {
        Id = id;
        Type = type;
    }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }
}