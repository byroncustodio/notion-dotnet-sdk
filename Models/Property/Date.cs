using Newtonsoft.Json;

namespace NotionSDK.Models.Property
{
    public class Date
    {
        [JsonProperty("start", NullValueHandling = NullValueHandling.Ignore)]
        public string? Start { get; set; }

        [JsonProperty("end", NullValueHandling = NullValueHandling.Ignore)]
        public string? End { get; set; }

        [JsonProperty("time_zone", NullValueHandling = NullValueHandling.Ignore)]
        public string? TimeZone { get; set; }
    }
}
