using Rick_MortyMVC.Models;

namespace Rick_MortyMVC.Services
{
    public interface IRickAndMortyHttpService
    {
        Task<Character?> GetCharacterByIdAsync(int id);
        



        
    }
}
