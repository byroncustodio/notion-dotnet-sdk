using Newtonsoft.Json;
using System.ComponentModel;

namespace NotionSDK.Models.Block
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

        [JsonProperty("annotations")]
        public Annotations Annotations = new();

        [JsonProperty("plain_text")]
        public string PlainText = string.Empty;

        [JsonProperty("href")]
        public string? Href { get; set; }
    }

    public class Text
    {
        [JsonProperty("content")]
        public string Content = string.Empty;

        [JsonProperty("link")]
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
        public bool Bold = false;

        [JsonProperty("italic")]
        public bool Italic = false;

        [JsonProperty("strikethrough")]
        public bool Strikethrough = false;

        [JsonProperty("underline")]
        public bool Underline = false;

        [JsonProperty("code")]
        public bool Code = false;

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
