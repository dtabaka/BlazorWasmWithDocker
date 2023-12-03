using BlazorWasmWithDocker.Models;

namespace BlazorWasmWithDocker.Services.Interfaces
{
    public interface IDataService
    {
        Task<IEnumerable<Tomato>> GetTomatoesAsync();
        //Task<IEnumerable<Tomato>> GetTomatoesAsyncBySearchTerm(string[] searchTerms);
    }
}

