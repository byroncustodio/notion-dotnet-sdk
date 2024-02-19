using Newtonsoft.Json;

namespace NotionSDK.Models.Property
{
    public class RichText
    {
        [JsonProperty("rich_text")]
        public List<Block.RichText> Items = new();
    }
}
