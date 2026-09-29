using API_training.Models;

namespace API_training.Services
{
    public interface IRAMService
    {
        Task<Character?> GetCharacterByIdAsync(int id);
        Task<List<Character>?> GetAllCharactersAsync();
    }
}
