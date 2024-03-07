using NotionSDK.Enums;
using NotionSDK.Models;

namespace NotionSDK.Extensions;

public class QuerySort
{
    private readonly List<Sort> _sorts = new();
        
    public void Add(string property, Direction direction)
    {
        _sorts.Add(new Sort { Property = property, Direction = direction.GetDescription() });
    }

    public void Add(Timestamp timestamp, Direction direction)
    {
        _sorts.Add(new Sort { Timestamp = timestamp.GetDescription(), Direction = direction.GetDescription() });
    }
        
    public List<Sort> Build()
    {
        return _sorts;
    }
}
    

    
