using Newtonsoft.Json;

namespace PharmDataClient.Models.User
{
    public class AuthRequest
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        [JsonProperty(Required = Required.Always, PropertyName = "login")]
        public string Login { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        [JsonProperty(Required = Required.Always, PropertyName = "password")]
        public string Password { get; set; }
    }
}
