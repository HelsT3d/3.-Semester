using NasaAPITraining.Models;
namespace NasaAPITraining.Services
{
    public interface INasaHttpService
    {
        Task<APOD?> GetAPODByPostIdAsync(int id);
    }
}
