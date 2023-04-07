using PharmDataClient.Abstractions;
using PharmDataClient.Exceptions;
using PharmDataClient.Models.Departments;
using PharmDataClient.Models.User;
using System.Data;

namespace PharmDataClient
{
    public class PharmDataApiClient
    {

        private readonly IRestClient _client;
        private AuthToken _token;

        public PharmDataApiClient(IRestClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Аутентификация пользователя
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <param name="role">Роль</param>
        /// <returns>Токен</returns>
        public async Task<bool> AuthenticateAsync(string login, string password, string role)
        {
            if (string.IsNullOrEmpty(login))
                throw new PharmDataApiException("Не указано имя пользователя");

            if (string.IsNullOrEmpty(password))
                throw new PharmDataApiException("Не указан пароль");

            if (string.IsNullOrEmpty(role))
                throw new PharmDataApiException("Не указана роль");

            var request = new AuthRequest
            {
                Login = login,
                Password = password
            };
            _token = await _client.PostAsync<AuthToken>($"User/auth/{role}", request);
            return _token != null && !string.IsNullOrEmpty(_token.Token);
        }

        /// <summary>
        /// Получить писок подразделений подключенных аптек
        /// </summary>
        /// <returns></returns>
        /// <exception cref="PharmDataApiException"></exception>
        public async Task<List<UserDepartment>> GetUserDepartmentsAsync()
        {
            if (!IsAuthenticate())
                throw new PharmDataApiException("Не аутентифицирован");

            return await _client.GetAsync<List<UserDepartment>>($"/User/departments", _token.Token);
        }

        /// <summary>
        /// Получение номенклатуры по ИД подразделения
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public async Task<List<Good>> GetGoodsByDepartmentId(string departmentId)
        {
            if (!IsAuthenticate())
                throw new PharmDataApiException("Не аутентифицирован");

            if(string.IsNullOrEmpty(departmentId))
                throw new PharmDataApiException("Не указан ИД подразделения");

            return await _client.GetAsync<List<Good>>($"/Goods/{departmentId}", _token.Token);
        }

        /// <summary>
        /// Флаг наличия действующего токена
        /// </summary>
        /// <returns></returns>
        public bool IsAuthenticate()
        {
            return _token != null && _token.Expiration > DateTime.Now;
        }
    }
}
