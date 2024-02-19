using Newtonsoft.Json;

namespace NotionSDK.Models.Property
{
    public class Relation
    {
        [JsonProperty("id")]
        public string? Id { get; set; }
    }
}
