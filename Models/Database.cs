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
        CreatedTime = database.CreatedTime;
        CreatedBy = database.CreatedBy;
        LastEditedTime = database.LastEditedTime;
        LastEditedBy = database.LastEditedBy;
        Title = database.Title;
        Description = database.Description;
        Icon = database.Icon;
        Cover = database.Cover;
        Properties = database.Properties;
        Parent = database.Parent;
        Url = database.Url;
        Archived = database.Archived;
        IsInline = database.IsInline;
        PublicUrl = database.PublicUrl;
    }

    [JsonProperty("object", NullValueHandling = NullValueHandling.Ignore)]
    public string? Object { get; set; }

    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public string? Id { get; set; }

    [JsonProperty("created_time", NullValueHandling = NullValueHandling.Ignore)]
    public string? CreatedTime { get; set; }

    [JsonProperty("created_by", NullValueHandling = NullValueHandling.Ignore)]
    public object? CreatedBy { get; set; }

    [JsonProperty("last_edited_time", NullValueHandling = NullValueHandling.Ignore)]
    public string? LastEditedTime { get; set; }

    [JsonProperty("last_edited_by", NullValueHandling = NullValueHandling.Ignore)]
    public object? LastEditedBy { get; set; }

    [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
    public List<RichText> Title { get; set; } = new()
    {
        new RichText(new List<RichTextData>
        {
            new() { Type = RichTextType.Text, Text = new Text { Content = "Untitled" } }
        })
    };

    [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
    public List<RichText> Description { get; set; } = new();

    [JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
    public object? Icon { get; set; }

    [JsonProperty("cover", NullValueHandling = NullValueHandling.Ignore)]
    public object? Cover { get; set; }

    [JsonProperty("properties")]
    public JObject Properties = new();

    [JsonProperty("parent")]
    public Parent Parent = new();

    [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
    public string? Url { get; set; }

    [JsonProperty("archived", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Archived { get; set; }

    [JsonProperty("is_inline", NullValueHandling = NullValueHandling.Ignore)]
    public bool? IsInline { get; set; }

    [JsonProperty("public_url", NullValueHandling = NullValueHandling.Ignore)]
    public string? PublicUrl { get; set; }
}