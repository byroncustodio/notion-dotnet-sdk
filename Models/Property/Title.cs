using Newtonsoft.Json;

namespace NotionSDK.Models.Property;

public class Title : PageProperty
{
    [JsonConstructor]
    public Title(List<RichTextData> data)
    {
        Data = data;
    }

    public Title(string title)
    {
        Data = new List<RichTextData>
        {
            new() { Type = RichTextType.Text, Text = new Text { Content = title } }
        };
    }

    [JsonProperty("title")]
    public List<RichTextData> Data { get; set; }
}