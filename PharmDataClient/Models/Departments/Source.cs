
using Newtonsoft.Json;

namespace PharmDataClient.Models.Departments
{
    public class Source
    {
        [JsonProperty(Required = Required.Always, PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(Required = Required.Default, PropertyName = "name")]
        public string? Name { get; set; }

        [JsonProperty(Required = Required.Default, PropertyName = "phone")]
        public string? Phone { get; set; }

        [JsonProperty(Required = Required.Default, PropertyName = "email")]
        public string? Email { get; set; }

        [JsonProperty(Required = Required.Default, PropertyName = "address")]
        public string? Address { get; set; }

        [JsonProperty(Required = Required.Default, PropertyName = "isCentral")]
        public bool? IsCentral { get; set; }

        [JsonProperty(Required = Required.Default, PropertyName = "registered")]
        public DateTimeOffset? Registered { get; set; }
    }
}
