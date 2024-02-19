using Newtonsoft.Json;

namespace NotionSDK.Models.Block
{
    public class PageReference
    {
        [JsonProperty("id")]
        public string? Id { get; set;  }
    }
}
