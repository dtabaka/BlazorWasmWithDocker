namespace BlazorWasmWithDocker.Services
{
    using System.Threading.Tasks;
        public interface ITokenService
    {
        Task SetTokenAsync(string token);
        Task<string> GetTokenAsync();
    }

    public class TokenService : ITokenService
    {
        private string token;

        public async Task SetTokenAsync(string newToken)
        {
            token = newToken;
            // You might also want to store the token securely, such as in local storage.
        }

        public Task<string> GetTokenAsync()
        {
            return Task.FromResult(token);
        }
    }

}
