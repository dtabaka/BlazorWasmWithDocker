
using System.Net.Http.Json;
using BlazorWasmWithDocker.Models;
using BlazorWasmWithDocker.Services.Interfaces;
using static BlazorWasmWithDocker.Shared.Constants;

namespace BlazorWasmWithDocker.Services
{
    public class DataService : IDataService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public DataService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<IEnumerable<Tomato>> GetTomatoesAsync()
        {
            var tomatoEndpoint = _configuration[Endpoints.TomatoList];
            _httpClient.DefaultRequestHeaders.Clear();  //Clear() is a quick fix/hack in case you login first before loading the catalog from firestore, it add headers causing CORS errors. Look at typed clients instead?
            return await _httpClient.GetFromJsonAsync<IEnumerable<Tomato>>(tomatoEndpoint);
        }

        public async Task<IEnumerable<GrowingTip>> GetGrowingTipsAsync()
        {
            var growingTipsEndpoint = _configuration[Endpoints.GrowingTips];
            _httpClient.DefaultRequestHeaders.Clear();
            return await _httpClient.GetFromJsonAsync<IEnumerable<GrowingTip>>(growingTipsEndpoint);
        }
    }
}

