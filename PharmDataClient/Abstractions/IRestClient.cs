namespace PharmDataClient.Abstractions
{
    public interface IRestClient
    {
        /// <summary>
        /// Выполняет GET запрос
        /// </summary>
        /// <param name="requestUri">API Метод</param>
        /// <param name="token">Токен</param>
        /// <returns>Результат запроса</returns>
        Task<T> GetAsync<T>(string requestUri, string token = null);

        /// <summary>
        /// Выполняет POST запрос
        /// </summary>
        /// <param name="requestUri">API Метод</param>
        /// <param name="content">Тело запроса</param>
        /// <param name="token">Токен</param>
        /// <returns></returns>
        Task<T> PostAsync<T>(string requestUri, object content, string token = null);

        /// <summary>
        /// Выполняет PUT запрос
        /// </summary>
        /// <param name="requestUri">API Метод</param>
        /// <param name="content">Тело запроса</param>
        /// <param name="token">Токен</param>
        Task PutAsync(string requestUri, object content, string token = null);

        /// <summary>
        /// Выполняет DELETE запрос
        /// </summary>
        /// <param name="requestUri">API Метод</param>
        /// <param name="token">Токен</param>
        Task DeleteAsync(string requestUri, string token = null);
    }
}