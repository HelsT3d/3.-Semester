using API_training.Models;
using System.Text.Json;

namespace API_training.Services
{
    public class RAMService : IRAMService
    {
        private readonly IHttpClientFactory _clientFactory;

        public RAMService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<Character?> GetCharacterByIdAsync(int id)
        {
            HttpClient httpClient = _clientFactory.CreateClient("RAMHttpClient");

            var response = httpClient.GetFromJsonAsync<Character?>($"character/{id}");
           return  await response;
               
        }
        public async Task<List<Character>?> GetAllCharactersAsync()
        {
            HttpClient httpClient = _clientFactory.CreateClient("RAMHttpClient");

            string json = await httpClient.GetStringAsync("character");

            using JsonDocument document = JsonDocument.Parse(json);

            string results = document.RootElement
                .GetProperty("results")
                .GetRawText();

            List<Character>? characters =
                JsonSerializer.Deserialize<List<Character>>(
                    results, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }
                    );

            return characters ?? new List<Character>();
        }
    }
}
