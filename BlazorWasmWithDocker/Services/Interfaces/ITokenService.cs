namespace BlazorWasmWithDocker.Services.Interfaces
{
    public interface ITokenService
    {
        Task SetTokenAsync(string token);
        Task<string> GetTokenAsync();
    }
}
