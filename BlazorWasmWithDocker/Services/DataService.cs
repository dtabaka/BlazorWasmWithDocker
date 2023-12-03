
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using BlazorWasmWithDocker.Models;
using BlazorWasmWithDocker.Services.Interfaces;
using System.Text.Json;

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
            return await _httpClient.GetFromJsonAsync<IEnumerable<Tomato>>("https://firestore-gateway-details-1bkt07r7.uc.gateway.dev/tomato-list");
        }

        //public Task<IEnumerable<Tomato>> GetTomatoesAsyncBySearchTerm(string[] searchTerms)
        //{
        //    _tomatoes = await httpClient.GetFromJsonAsync<Tomato[]>("https://firestore-gateway-details-1bkt07r7.uc.gateway.dev/tomato-list");
        //    Tomatoes = _tomatoes;
        //}
    }
}



