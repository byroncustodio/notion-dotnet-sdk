using Newtonsoft.Json;

namespace NotionSDK.Models
{
    public class Page
    {
        [JsonProperty("object")]
        public string? Object { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }
    }
}
