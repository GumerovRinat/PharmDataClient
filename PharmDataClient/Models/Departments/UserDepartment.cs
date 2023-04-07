using Newtonsoft.Json;

namespace PharmDataClient.Models.Departments
{
    public class UserDepartment
    {
        [JsonProperty(Required = Required.Always, PropertyName = "department")]
        public Department Department { get; set; }

        [JsonProperty(Required = Required.Always, PropertyName = "source")]
        public Source Source { get; set; }

        [JsonProperty(Required = Required.Always, PropertyName = "isActivated")]
        public bool IsActivated { get; set; }
    }
}
