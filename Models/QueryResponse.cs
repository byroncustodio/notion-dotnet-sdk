using Newtonsoft.Json;

namespace NotionSDK.Models;

public class QueryResponse
{
    [JsonProperty("has_more")]
    public bool HasMore { get; }
        
    [JsonProperty("next_cursor")]
    public string? NextCursor { get; }
        
    [JsonProperty("type")]
    public string? Type { get; }

    [JsonProperty("results")]
    public List<Page> Results { get; } = new();
}