using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Portfolio.Shared
{
    public class Project
    {
        
        [JsonPropertyName("id")]
        public int id { get; set; }
        
        [JsonPropertyName("title")]
        public string Title { get; set; }
        
        [JsonPropertyName("requirement")]
        public string Requirement { get; set; }
        
        [JsonPropertyName("design")]
        public string Design { get; set; }
        
        [JsonPropertyName("completionDate")]
        public DateTime CompletionDate { get; set; }
    }
}
