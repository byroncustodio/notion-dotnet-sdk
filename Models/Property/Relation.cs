using Newtonsoft.Json;
using NotionSDK.Models.Block;

namespace NotionSDK.Models.Property;

public class Relation : PageProperty
{
    public Relation(List<PageReference> data)
    {
        Data = data;
    }

    [JsonProperty("relation")]
    public List<PageReference> Data { get; set; }
}