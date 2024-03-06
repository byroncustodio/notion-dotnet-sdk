using Newtonsoft.Json;

namespace NotionSDK.Models;

public class PageProperty
{
    [JsonProperty("id")]
    public string? Id { get; set; }
}