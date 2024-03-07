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
    public readonly string? Object;

    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public readonly string? Id;

    [JsonProperty("cover", NullValueHandling = NullValueHandling.Ignore)]
    public object? Cover { get; set; }

    [JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
    public object? Icon { get; set; }

    [JsonProperty("created_time", NullValueHandling = NullValueHandling.Ignore)]
    public readonly string? CreatedTime;

    [JsonProperty("created_by", NullValueHandling = NullValueHandling.Ignore)]
    public readonly object? CreatedBy;

    [JsonProperty("last_edited_by", NullValueHandling = NullValueHandling.Ignore)]
    public readonly object? LastEditedBy;

    [JsonProperty("last_edited_time", NullValueHandling = NullValueHandling.Ignore)]
    public readonly string? LastEditedTime;

    [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
    public List<RichTextData>? Title { get; set; }

    [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
    public List<RichTextData>? Description { get; set; }

    [JsonProperty("is_inline", NullValueHandling = NullValueHandling.Ignore)]
    public readonly bool? IsInline;

    [JsonProperty("properties")]
    public JObject Properties = new();

    [JsonProperty("parent")]
    public Parent Parent = new();

    [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
    public readonly string? Url;

    [JsonProperty("public_url", NullValueHandling = NullValueHandling.Ignore)]
    public readonly string? PublicUrl;

    [JsonProperty("archived", NullValueHandling = NullValueHandling.Ignore)]
    public readonly bool Archived;
}