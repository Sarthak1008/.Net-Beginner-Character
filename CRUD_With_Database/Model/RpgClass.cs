using System.Text.Json.Serialization;

namespace crud.Model
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
         Knight=1,
         Mage=2,
         Clerik=3
    }
}