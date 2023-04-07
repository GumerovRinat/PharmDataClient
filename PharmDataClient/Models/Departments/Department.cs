using Newtonsoft.Json;

namespace PharmDataClient.Models.Departments
{
    public class Department
    {
        [JsonProperty(Required = Required.Always, PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(Required = Required.Default, PropertyName = "name")]
        public string? Name { get; set; }

        [JsonProperty(Required = Required.Default, PropertyName = "address")]
        public string? Address { get; set; }

        [JsonProperty(Required = Required.Default, PropertyName = "phone")]
        public string? Phone { get; set; }

        [JsonProperty(Required = Required.Default, PropertyName = "inn")]
        public string? Inn { get; set; }

        [JsonProperty(Required = Required.Default, PropertyName = "kpp")]
        public string? Kpp { get; set; }

        [JsonProperty(Required = Required.Default, PropertyName = "edmOperator")]
        public string? EdmOperator { get; set; }

        [JsonProperty(Required = Required.Default, PropertyName = "edmId")]
        public string? EdmId { get; set; }

        [JsonProperty(Required = Required.Default, PropertyName = "kizId")]
        public string? KizId { get; set; }

        [JsonProperty(Required = Required.Default, PropertyName = "coords")]
        public Coords Coords { get; set; }

        [JsonProperty(Required = Required.Default, PropertyName = "rv")]
        public string? Rv { get; set; }

        [JsonProperty(Required = Required.Default, PropertyName = "created")]
        public DateTime Created { get; set; }
    }
}
