using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NotionSDK.Models.Property;

namespace NotionSDK.Extensions;

public class PropertyBuilder
{
    private readonly List<object> _properties = new();

    public void Add(string name, string property)
    {
        _properties.Add(JsonConvert.DeserializeObject($"{{{name}:{property}}}") 
                        ?? throw new JsonException("Add failed due to missing/invalid arguments"));
    }

    public JObject Build()
    {
        JObject result = new();

        foreach (JObject property in _properties)
        {
            result.Merge(property);
        }
            
        return result;
    }
        
    public static string Title(RichText title)
    {
        return JsonConvert.SerializeObject(title);
    }

    public static string Date(Date date)
    {
        return JsonConvert.SerializeObject(new { date });
    }

    public static string Relation(Relation relation)
    {
        return JsonConvert.SerializeObject(relation);
    }

    public static string Select(Select select)
    {
        return JsonConvert.SerializeObject(new { select });
    }

    public static string Number(Number number)
    {
        return JsonConvert.SerializeObject(new { number });
    }

    public static string Status(Status status)
    {
        return JsonConvert.SerializeObject(new { status });
    }

    public static string RichText(RichText richText)
    {
        return JsonConvert.SerializeObject(richText);
    }
}