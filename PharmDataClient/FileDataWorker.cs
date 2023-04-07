using Newtonsoft.Json;
using PharmDataClient.Abstractions;

namespace PharmDataClient
{
    public class FileDataWorker : IDataWorker
    {
        private readonly string _fileName;

        public FileDataWorker(string fileName)
        {
            _fileName = fileName;
            if(File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

        /// <inheritdoc />
        public async Task<T> LoadData<T>()
        {
            using (var sr = new StreamReader(_fileName))
            {
                var data = await sr.ReadToEndAsync();
                return JsonConvert.DeserializeObject<T>(data);
            }
        }

        /// <inheritdoc />
        public async Task SaveData(object data)
        {
            using (var sw = new StreamWriter(_fileName))
            {
                await sw.WriteAsync(JsonConvert.SerializeObject(data));
            }
        }
    }
}
