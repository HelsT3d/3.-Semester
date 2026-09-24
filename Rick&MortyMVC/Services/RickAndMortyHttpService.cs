using Rick_MortyMVC.Models;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Rick_MortyMVC.Services
{
    public class RickAndMortyHttpService : IRickAndMortyHttpService
    {
        private readonly IHttpClientFactory _rickAndMortyHttpFactory;

        public RickAndMortyHttpService(IHttpClientFactory rickAndMortyHttpFactory)
        {
            _rickAndMortyHttpFactory = rickAndMortyHttpFactory;
        }

        public async Task<Character?> GetCharacterByIdAsync(int id)
        {
            using HttpClient httpClient = _rickAndMortyHttpFactory.CreateClient("RickAndMortyHttpClient");

            try
            {
                return await httpClient.GetFromJsonAsync<Character>($"/api/character/{id}");

            }
            catch ( HttpRequestException)
            {

                return null;
            }
        }

    }

}
