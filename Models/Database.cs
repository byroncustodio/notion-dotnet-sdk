using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NotionSDK.Models.Property;

namespace NotionSDK.Models;

public class Database
{
    public Database() { }
    
    public Database(Database database)
    {
        Object = database.Object;
        Id = database.Id;
        Cover = database.Cover;
        Icon = database.Icon;
        CreatedTime = database.CreatedTime;
        CreatedBy = database.CreatedBy;
        LastEditedBy = database.LastEditedBy;
        LastEditedTime = database.LastEditedTime;
        Title = database.Title;
        Description = database.Description;
        IsInline = database.IsInline;
        Properties = database.Properties;
        Parent = database.Parent;
        Url = database.Url;
        PublicUrl = database.PublicUrl;
        Archived = database.Archived;
    }

    [JsonProperty("object", NullValueHandling = NullValueHandling.Ignore)]
    public string? Object { get; }

    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public string? Id { get; }

    [JsonProperty("cover", NullValueHandling = NullValueHandling.Ignore)]
    public object? Cover { get; set; }

    [JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
    public object? Icon { get; set; }
    
    [JsonProperty("created_time", NullValueHandling = NullValueHandling.Ignore)]
    public string? CreatedTime { get; }

    [JsonProperty("created_by", NullValueHandling = NullValueHandling.Ignore)]
    public object? CreatedBy { get; }

    [JsonProperty("last_edited_by", NullValueHandling = NullValueHandling.Ignore)]
    public object? LastEditedBy { get; }
    
    [JsonProperty("last_edited_time", NullValueHandling = NullValueHandling.Ignore)]
    public string? LastEditedTime { get; }

    [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
    public List<RichTextData>? Title { get; set; }

    [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
    public List<RichTextData>? Description { get; set; }

    [JsonProperty("is_inline", NullValueHandling = NullValueHandling.Ignore)]
    public bool? IsInline { get; }

    [JsonProperty("properties")]
    public JObject Properties = new();

    [JsonProperty("parent")]
    public Parent Parent = new();

    [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
    public string? Url { get; }

    [JsonProperty("public_url", NullValueHandling = NullValueHandling.Ignore)]
    public string? PublicUrl { get; }
    
    [JsonProperty("archived", NullValueHandling = NullValueHandling.Ignore)]
    public bool Archived { get; }
}