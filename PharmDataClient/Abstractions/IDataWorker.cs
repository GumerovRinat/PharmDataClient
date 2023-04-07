
namespace PharmDataClient.Abstractions
{
    public interface IDataWorker
    {
        /// <summary>
        /// Сохранение данных
        /// </summary>
        /// <param name="data">Объект данных</param>
        Task SaveData(object data);

        /// <summary>
        /// Загрузка данных
        /// </summary>
        /// <returns>Объект данных</returns>
        Task<T> LoadData<T>();
    }
}
