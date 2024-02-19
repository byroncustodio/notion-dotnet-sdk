using Newtonsoft.Json;
using NotionSDK.Models.Block;

namespace NotionSDK.Models.Property
{
    public class Title
    {
        [JsonProperty("title")]
        public List<RichText> Items = new();
    }
}
