using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NotionSDK.Models.Property;

namespace NotionSDK.Extensions;

public class PropertyBuilder
{
    private readonly List<object> _properties = new();

    private void Add(string name, string property)
    {
        _properties.Add(JsonConvert.DeserializeObject($"{{{name}:{property}}}") ?? throw new JsonException("Add failed due to missing/invalid arguments"));
    }

    public void Add(string name, Date property) { Add(name, JsonConvert.SerializeObject(property)); }
    public void Add(string name, Number property) { Add(name, JsonConvert.SerializeObject(property)); }
    public void Add(string name, Relation property) { Add(name, JsonConvert.SerializeObject(property)); }
    public void Add(string name, RichText property) { Add(name, JsonConvert.SerializeObject(property)); }
    public void Add(string name, Select property) { Add(name, JsonConvert.SerializeObject(property)); }
    public void Add(string name, Status property) { Add(name, JsonConvert.SerializeObject(property)); }
    public void Add(string name, Title property) { Add(name, JsonConvert.SerializeObject(property)); }
    
    public JObject Build()
    {
        JObject result = new();

        foreach (JObject property in _properties)
        {
            result.Merge(property);
        }
            
        return result;
    }
}