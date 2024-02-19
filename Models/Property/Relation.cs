using Newtonsoft.Json;
using NotionSDK.Models.Block;

namespace NotionSDK.Models.Property
{
    public class Relation
    {
        [JsonProperty("relation", NullValueHandling = NullValueHandling.Ignore)]
        public List<PageReference>? Id { get; set; }
    }
}
