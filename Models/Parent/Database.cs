using Newtonsoft.Json;

namespace NotionSDK.Models.Parent
{
    public class Database : Base
    {
        [JsonProperty("database_id")]
        public string? DatabaseId { get; set; }
    }
}
