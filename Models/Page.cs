using Newtonsoft.Json;

namespace NotionSDK.Models;

public class Page
{
    public Page(string o, string id)
    {
        Object = o;
        Id = id;
    }

    [JsonProperty("object")]
    public string Object { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }
}