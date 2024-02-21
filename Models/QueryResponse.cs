using Newtonsoft.Json;

namespace NotionSDK.Models
{
    public class QueryResponse
    {
        [JsonProperty("has_more")]
        public bool HasMore { get; set; }
        
        [JsonProperty("next_cursor")]
        public string? NextCursor { get; set; }
        
        [JsonProperty("type")]
        public string? Type { get; set; }
        
        [JsonProperty("results")]
        public List<Database>? Results { get; set; }
    }
}
