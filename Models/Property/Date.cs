using Newtonsoft.Json;

namespace NotionSDK.Models.Property
{
    public class Date
    {
        [JsonProperty("start")]
        public string? Start { get; set; }

        [JsonProperty("end")]
        public string? End { get; set; }

        [JsonProperty("time_zone")]
        public string? TimeZone { get; set; }
    }
}
