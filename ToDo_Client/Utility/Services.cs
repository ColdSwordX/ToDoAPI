namespace ToDo_Client.Utility
{
    public class Services
    {
        static readonly private HttpClient _httpClient = new();

        static public HttpClient Client 
        { 
            get 
            {
                return _httpClient;
            }
        }
    }
}
