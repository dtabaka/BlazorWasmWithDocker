using BlazorWasmWithDocker.Models;

namespace BlazorWasmWithDocker.Services.Interfaces
{
    public interface IDataService
    {
        Task<IEnumerable<Tomato>> GetTomatoesAsync();
    }
}