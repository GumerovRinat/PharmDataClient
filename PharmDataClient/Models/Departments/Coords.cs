using Newtonsoft.Json;

namespace PharmDataClient.Models.Departments
{
    public class Coords
    {
        [JsonProperty(Required = Required.Always, PropertyName = "latitude")]
        public double Latitude { get; set; }

        [JsonProperty(Required = Required.Always, PropertyName = "longitude")]
        public double Longitude { get; set; }
    }
}
