using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NotionSDK.Models;

namespace NotionSDK.Extensions;

public class QueryFilter
{
    private readonly List<JObject> _filters = new();

    private void Add(string property, JObject condition)
    {
        var filter = JObject.FromObject(new Filter
        {
            Property = property
        });
            
        filter.Merge(condition);
        _filters.Add(filter);
    }
        
    public void Add<T>(string property, Comparator comparator, object value)
    {
        Add(property, JsonConvert.DeserializeObject<JObject>($"{{ {typeof(T).Name.ToLower()}: {{ {comparator.GetDescription()}: \"{value}\" }} }}") ??
                      throw new JsonException("Failed to build filter due to missing/invalid arguments."));
    }

    public JObject Create<T>(string property, Comparator comparator, object value)
    {
        var filter = JObject.FromObject(new Filter
        {
            Property = property
        });
            
        filter.Merge(JsonConvert.DeserializeObject<JObject>($"{{ {typeof(T).Name.ToLower()}: {{ {comparator.GetDescription()}: \"{value}\" }} }}") ??
                     throw new JsonException("Failed to create filter due to missing/invalid arguments."));

        return filter;
    }

    // TODO: Add support for nested compounds (i.e. "or" filters inside of "and" filters)
    public JObject Build(Operand? operand = null)
    {
        if (operand != null)
        {
            return JsonConvert.DeserializeObject<JObject>(
                       $"{{ {operand.GetDescription()}: [{string.Join(",", _filters.Select(filter => filter))}] }}") ??
                   throw new JsonException("Failed to build filter due to missing/invalid arguments.");
        }

        return _filters.First();
    }
}
    
public enum Operand
{
    [Description("and")]
    And,
    [Description("or")]
    Or
}

public enum Comparator
{
    [Description("equals")]
    Equals,
    [Description("does_not_equal")]
    NotEquals,
    [Description("after")]
    After,
    [Description("before")]
    Before,
    [Description("on_or_after")]
    OnOrAfter,
    [Description("on_or_before")]
    OnOrBefore,
    [Description("contains")]
    Contains,
    [Description("does_not_contain")]
    DoesNotContain,
    [Description("is_empty")]
    IsEmpty,
    [Description("is_not_empty")]
    IsNotEmpty
}