using Newtonsoft.Json;

namespace NotionSDK.Models.Parent
{
    public class Block : Base
    {
        [JsonProperty("block_id")]
        public string? BlockId { get; set; }
    }
}
