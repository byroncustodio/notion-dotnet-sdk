using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NotionSDK.Models.Parent;
using NotionSDK.Models.Property;

namespace NotionSDK.Models;

public class Database
{
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
    public List<RichText> Title { get; set; } = new();

    [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
    public List<RichText> Description { get; set; } = new();

    [JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
    public object? Icon { get; set; }

    [JsonProperty("cover", NullValueHandling = NullValueHandling.Ignore)]
    public object? Cover { get; set; }

    [JsonProperty("properties")]
    public JObject Properties = new();

    [JsonProperty("parent")]
    public Base Parent = new();

    [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
    public string? Url { get; set; }

    [JsonProperty("archived", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Archived { get; set; }

    [JsonProperty("is_inline", NullValueHandling = NullValueHandling.Ignore)]
    public bool? IsInline { get; set; }

    [JsonProperty("public_url", NullValueHandling = NullValueHandling.Ignore)]
    public string? PublicUrl { get; set; }
}