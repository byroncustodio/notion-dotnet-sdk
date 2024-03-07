using Newtonsoft.Json;
using NotionSDK.Models.Block;

namespace NotionSDK.Models.Property;

public class Relation : PageProperty
{
    [JsonConstructor]
    public Relation(List<PageReference> data)
    {
        Data = data;
    }

    public Relation(Database database)
    {
        Data = new List<PageReference>
        {
            new() { Id = database.Id }
        };
    }

    public Relation(Page? page = null)
    {
        if (page != null)
        {
            Data = new List<PageReference>
            {
                new() { Id = page.Id }
            };
        }
        else
        {
            Data = new List<PageReference>();
        }
    }

    [JsonProperty("relation")]
    public List<PageReference> Data { get; set; }
}