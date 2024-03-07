using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NotionSDK.Models;

public class Page
{
    public Page() { }

    public Page(Page page)
    {
        Object = page.Object;
        Id = page.Id;
        CreatedTime = page.CreatedTime;
        LastEditedTime = page.LastEditedTime;
        CreatedBy = page.CreatedBy;
        LastEditedBy = page.LastEditedBy;
        Cover = page.Cover;
        Icon = page.Icon;
        Parent = page.Parent;
        Archived = page.Archived;
        Properties = page.Properties;
        Url = page.Url;
        PublicUrl = page.PublicUrl;
    }

    [JsonProperty("object", NullValueHandling = NullValueHandling.Ignore)]
    public string? Object { get; }

    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public string? Id { get; }

    [JsonProperty("created_time", NullValueHandling = NullValueHandling.Ignore)]
    public string? CreatedTime { get; }

    [JsonProperty("last_edited_time", NullValueHandling = NullValueHandling.Ignore)]
    public string? LastEditedTime { get; }

    [JsonProperty("created_by", NullValueHandling = NullValueHandling.Ignore)]
    public object? CreatedBy { get; }
    
    [JsonProperty("last_edited_by", NullValueHandling = NullValueHandling.Ignore)]
    public object? LastEditedBy { get; }

    [JsonProperty("cover", NullValueHandling = NullValueHandling.Ignore)]
    public object? Cover { get; set; }

    [JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
    public object? Icon { get; set; }

    [JsonProperty("parent")]
    public Parent Parent = new();

    [JsonProperty("archived")]
    public bool Archived { get; }
    
    [JsonProperty("properties")]
    public JObject Properties = new();
    
    [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
    public string? Url { get; }

    [JsonProperty("public_url", NullValueHandling = NullValueHandling.Ignore)]
    public string? PublicUrl { get; }
}