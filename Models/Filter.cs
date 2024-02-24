using Newtonsoft.Json;

namespace NotionSDK.Models
{
    public class Filter
    {
        [JsonProperty("property")]
        public string? Property { get; set; }
    }
}
