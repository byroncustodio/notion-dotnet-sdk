using Newtonsoft.Json;

namespace NotionSDK.Models.Property;

public class Select : PageProperty
{
    [JsonConstructor]
    public Select(SelectData data)
    {
        Data = data;
    }

    public Select(string? name)
    {
        Data = new SelectData
        {
            Name = name
        };
    }

    [JsonProperty("select")]
    public SelectData Data { get; set; }
}

public class SelectData
{
    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public string? Id { get; set; }

    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string? Name { get; set; }

    [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
    public string? Color { get; set; }
}