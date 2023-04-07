namespace PharmDataClient.Exceptions
{
    public class PharmDataApiException : Exception
    {
        public PharmDataApiException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public PharmDataApiException(string message) { }
    }
}
