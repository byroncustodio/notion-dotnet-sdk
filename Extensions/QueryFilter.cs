using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NotionSDK.Enums;
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
        
    /// <summary>
    /// Adds filter to instance for building query request.
    /// </summary>
    /// <param name="property">The name of a property</param>
    /// <param name="comparator">The comparator enum</param>
    /// <param name="value">The value to compare against</param>
    /// <typeparam name="TP">A page/database property type.<br/><b>Examples: </b><i>Date, Number, Relation</i></typeparam>
    /// <typeparam name="TE">An enum comparator type with respect to property type.<br/><b>Examples: </b><i>DateComparator, NumberComparator, RelationComparator</i></typeparam>
    /// <exception cref="JsonException"></exception>
    public void Add<TP, TE>(string property, TE comparator, object value) where TE : Enum
    {
        Add(property, JsonConvert.DeserializeObject<JObject>($"{{ {typeof(TP).Name.ToLower()}: {{ {comparator.GetDescription()}: \"{value}\" }} }}") ??
                      throw new JsonException("Failed to build filter due to missing/invalid arguments."));
    }

    /// <summary>
    /// Builds added filters to create single object for query request
    /// </summary>
    /// <param name="operand">[Optional] Specify what operand to use to group filters.<br/><b>Examples: </b><i>Operand.And, Operand.Or</i><br/><br/>Note: If operand is null, only the first filter added will be used.</param>
    /// <returns>A JObject to be passed to <see cref="Notion.QueryDatabase"/></returns>
    /// <exception cref="JsonException"></exception>
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