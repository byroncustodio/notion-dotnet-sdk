using Newtonsoft.Json;

namespace NotionSDK.Models.Parent
{
    public class Page : Base
    {
        [JsonProperty("page_id")]
        public string? PageId { get; set; }
    }
}
