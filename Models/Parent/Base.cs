using Newtonsoft.Json;

namespace NotionSDK.Models.Parent
{
    public class Base
    {
        [JsonProperty("type")]
        public string? Type { get; set; }
    }
}
