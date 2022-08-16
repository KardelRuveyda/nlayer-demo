using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace NLayerDemo.Core.DTOs
{
    public class NoContentDto
    {
        [JsonIgnore]
        public int StatusCode { get; set; }
        public List<String> Errors { get; set; }
    }
}
