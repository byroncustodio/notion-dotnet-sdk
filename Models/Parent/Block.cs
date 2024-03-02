using Newtonsoft.Json;

namespace NotionSDK.Models.Parent;

internal class Block : Base
{
    [JsonProperty("block_id")]
    public string? BlockId { get; set; }
}