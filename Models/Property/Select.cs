using Newtonsoft.Json;

namespace NotionSDK.Models.Property
{
    public class Select
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string? Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string? Name { get; set; }

        [JsonProperty("color",  NullValueHandling = NullValueHandling.Ignore)]
        public string? Color { get; set; } // defaults to "default"
    }
}
