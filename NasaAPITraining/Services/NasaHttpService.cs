using NasaAPITraining.Models;

namespace NasaAPITraining.Services
{
    public class NasaHttpService : INasaHttpService
    {
        private readonly IHttpClientFactory _clientFactory;

        public NasaHttpService(IHttpClientFactory clientFactory) 
        {
            _clientFactory = clientFactory;
        }


        public async Task<APOD?> GetAPODByPostIdAsync(int id)
        {
           using HttpClient httpClient = _clientFactory.CreateClient("NasaHttpClient");
            try
            {
                return await httpClient.GetFromJsonAsync<APOD?>($"apod-basic/{id}");
            }
            catch(HttpRequestException)
            {
                return null;
            }
        }
    }
}
