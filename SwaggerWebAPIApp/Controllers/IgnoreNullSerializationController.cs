using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace SwaggerWebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IgnoreNullSerializationController : ControllerBase
    {

       
        //public ActionResult TestNullEnumAction([FromBody] EnumNullTestClass request)
        //{
        //    return Ok(request);
        //}
    }
  
    public class EnumNullTestClass
    {
     
        public string FileName { get; set; }
       
        public NullEnumTest? NullEnumTest { get; set; }

    }
    public class SafeStringEnumConverter : StringEnumConverter
    {
        public object DefaultValue { get; }

        public SafeStringEnumConverter() { }

        public SafeStringEnumConverter(object defaultValue)
        {
            DefaultValue = defaultValue;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                return base.ReadJson(reader, objectType, existingValue, serializer);
            }
            catch
            {
                return DefaultValue;
            }
        }
    }
    public class DocumentInfo
    {
        [JsonProperty("FileName", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("FileName")]
        public string FileName { get; set; }

        [JsonPropertyName("Template")]
        [JsonProperty("Template", NullValueHandling = NullValueHandling.Ignore)]
        public string? Template { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public string FileExtension => Path.GetExtension(this.FileName);
    }

    [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
    public enum NullEnumTest
    {
        Unknown,
        None,
        RecordNotFound,
        FileNotFound
    }
}
