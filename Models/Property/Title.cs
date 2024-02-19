﻿using Newtonsoft.Json;

namespace NotionSDK.Models.Property
{
    public class Title
    {
        [JsonProperty("title")]
        public List<Block.RichText> Items = new();
    }
}
