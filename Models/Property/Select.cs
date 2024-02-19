using Newtonsoft.Json;

namespace NotionSDK.Models.Property
{
    public class Select
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("color")]
        public string? Color { get; set; } // defaults to "default"
    }
}
