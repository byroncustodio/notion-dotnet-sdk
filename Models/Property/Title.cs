using Newtonsoft.Json;

namespace NotionSDK.Models.Property;

public class Title : PageProperty
{
    public Title(List<RichTextData> data)
    {
        Data = data;
    }

    [JsonProperty("title")]
    public List<RichTextData> Data { get; set; }
}