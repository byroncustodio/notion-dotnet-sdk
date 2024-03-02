using Newtonsoft.Json;

namespace NotionSDK.Models.Parent;

 internal class Page : Base
{
    [JsonProperty("page_id")]
    public string? PageId { get; set; }
}