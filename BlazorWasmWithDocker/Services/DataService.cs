
using System.Net.Http.Json;
using BlazorWasmWithDocker.Models;
using BlazorWasmWithDocker.Services.Interfaces;

namespace BlazorWasmWithDocker.Services
{
    public class DataService : IDataService
    {
        private readonly HttpClient _httpClient;
        public DataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Tomato>> GetTomatoesAsync()
        {
            //Clear() is a quick fix/hack in case you login first before loading the catalog from firestore, it add headers causing CORS errors.
            //Look at typed clients instead?
            _httpClient.DefaultRequestHeaders.Clear();
            return await _httpClient.GetFromJsonAsync<IEnumerable<Tomato>>("https://firestore-gateway-details-1bkt07r7.uc.gateway.dev/tomato-list");
        }
    }
}



