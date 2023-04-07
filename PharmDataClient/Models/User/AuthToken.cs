using Newtonsoft.Json;

namespace PharmDataClient.Models.User
{
    public class AuthToken
    {
        /// <summary>
        /// Токен
        /// </summary>
        [JsonProperty(Required = Required.Always, PropertyName = "token")]
        public string? Token { get; set; }

        /// <summary>
        /// Дата окончания
        /// </summary>
        [JsonProperty(Required = Required.Always, PropertyName = "expiration")]
        public DateTime Expiration { get; set; }
    }
}
