using System.ComponentModel;
using Newtonsoft.Json;

namespace NotionSDK.Models.Property
{
    public class RichText
    {
        [JsonProperty("type")]
        public RichTextType Type { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public Text? Text { get; set; }

        [JsonProperty("mention", NullValueHandling = NullValueHandling.Ignore)]
        public Mention? Mention { get; set; }

        [JsonProperty("equation", NullValueHandling = NullValueHandling.Ignore)]
        public Equation? Equation { get; set; }

        [JsonProperty("annotations", NullValueHandling = NullValueHandling.Ignore)]
        public Annotations? Annotations { get; set; }

        [JsonProperty("plain_text", NullValueHandling = NullValueHandling.Ignore)]
        public string? PlainText { get; set; }

        [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
        public string? Href { get; set; }
    }

    public class Text
    {
        [JsonProperty("content")]
        public string Content = string.Empty;

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
}
