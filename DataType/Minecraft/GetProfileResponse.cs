﻿using Newtonsoft.Json;

namespace BianCore.DataType.Minecraft
{
    public struct GetProfileResponse
    {
        [JsonProperty("id")]
        public string UUID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        //[JsonProperty("skin")]
    }
}
