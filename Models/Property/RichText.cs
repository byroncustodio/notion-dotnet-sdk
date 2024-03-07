using System.ComponentModel;
using Newtonsoft.Json;
using NotionSDK.Extensions;

namespace NotionSDK.Models.Property;

public class RichText : PageProperty
{
    [JsonConstructor]
    public RichText(List<RichTextData> data)
    {
        Data = data;
    }

    public RichText(string? text)
    {
        Data = new List<RichTextData>
        {
            new() { RichTextType = RichTextType.Text, Text = new Text { Content = text } }
        };
    }

    [JsonProperty("rich_text")]
    public List<RichTextData> Data { get; set; }
}

public class RichTextData
{
    [JsonProperty("type")]
    public string? Type { get; set; }

    public RichTextType RichTextType
    {
        set => Type = value.GetDescription();
    }

    [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
    public Text? Text { get; set; }

    [JsonProperty("mention", NullValueHandling = NullValueHandling.Ignore)]
    public Mention? Mention { get; set; }

    [JsonProperty("equation", NullValueHandling = NullValueHandling.Ignore)]
    public Equation? Equation { get; set; }

    [JsonProperty("annotations")]
    public Annotations Annotations { get; set; } = new();

    [JsonProperty("plain_text", NullValueHandling = NullValueHandling.Ignore)]
    public string? PlainText { get; set; }

    [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
    public string? Href { get; set; }
}

public class Text
{
    [JsonProperty("content")]
    public string? Content = string.Empty;

    [JsonProperty("link", NullValueHandling = NullValueHandling.Ignore)]
    public object? Link { get; set; }
}

public class Mention
{
    [JsonProperty("type")]
    public string Type = string.Empty;

    // TODO: Add type-specific configuration here
    // https://developers.notion.com/reference/rich-text#mention
    public object? Configuration { get; set; }
}

public class Equation
{
    [JsonProperty("expression")]
    public string Expression = string.Empty;
}

public class Annotations
{
    [JsonProperty("bold")]
    public bool Bold;

    [JsonProperty("italic")]
    public bool Italic;

    [JsonProperty("strikethrough")]
    public bool Strikethrough;

    [JsonProperty("underline")]
    public bool Underline;

    [JsonProperty("code")]
    public bool Code;

    [JsonProperty("color")]
    public string Color = "default";
}

public enum RichTextType
{
    [Description("text")]
    Text,
    [Description("mention")]
    Mention,
    [Description("equation")]
    Equation
}