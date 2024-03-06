using Newtonsoft.Json;

namespace NotionSDK.Models;

public class Page
{
    [JsonProperty("object")]
    public string? Object { get; set; }

    [JsonProperty("id")]
    public string? Id { get; set; }

    // TODO: Create custom JSON deserializer
    public object? Parent { get; set; }
    
    private Parent.Page? ParentPage { get; set; }
    
    private Parent.Database? ParentDatabase { get; set; }
}