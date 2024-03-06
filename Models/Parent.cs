using Newtonsoft.Json;

namespace NotionSDK.Models;

public class Parent
{
    public Parent() { }
    
    public Parent(Parent parentParent)
    {
        Type = parentParent.Type;
        BlockId = parentParent.BlockId;
        PageId = parentParent.PageId;
        DatabaseId = parentParent.DatabaseId;
    }

    [JsonProperty("type")]
    public string? Type { get; set; }
    
    [JsonProperty("block_id", NullValueHandling = NullValueHandling.Ignore)]
    public string? BlockId { get; set; }
    
    [JsonProperty("page_id", NullValueHandling = NullValueHandling.Ignore)]
    public string? PageId { get; set; }
    
    [JsonProperty("database_id", NullValueHandling = NullValueHandling.Ignore)]
    public string? DatabaseId { get; set; }
}