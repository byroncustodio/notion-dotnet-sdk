using Newtonsoft.Json;

namespace NotionSDK.Models
{
    public class Sort
    {
        [JsonProperty("property", NullValueHandling = NullValueHandling.Ignore)]
        public string? Property { get; set; }
        
        [JsonProperty("timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public string? Timestamp { get; set; }
        
        [JsonProperty("direction")]
        public string? Direction { get; set; }
    }
}
