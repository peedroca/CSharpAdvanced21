using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace swager.Models
{
    public class DMSwagger
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<DMSwaggerController> Controllers { get; set; }
    }

    public class DMSwaggerController
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Name { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<DMSwaggerEndpoint> Endpoints { get; set; }
    }

    public class DMSwaggerEndpoint
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Verb { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Path { get; set; }
        
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DMSwaggerRequest Request { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DMSwaggerResponse Response { get; set; }
    }

    public class DMSwaggerResponse
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<DMSwaggerObject> Fields { get; set; }
    }
    
    public class DMSwaggerRequest
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DMSwaggerBody Body { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<DMSwaggerObject> Params { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<DMSwaggerObject> Query { get; set; }
    }

    public class DMSwaggerBody
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<DMSwaggerObject> Fields { get; set; }
    }

    public class DMSwaggerObject
    {
        public string Field { get; set; }
        public string Type { get; set; }
    }
}