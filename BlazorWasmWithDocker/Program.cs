using BlazorWasmWithDocker;
using BlazorWasmWithDocker.Services;
using BlazorWasmWithDocker.Services.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Authentication.WebAssembly.Msal;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");




//string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

////IMPORTANT:  Needs to be configured first. https://localhost:44308/ is the address of my .WebApi project
//builder.Services.AddCors(options =>
// {
//     options.AddPolicy(name: MyAllowSpecificOrigins,
//                       builder =>
//                       {
//                           builder.WithOrigins("https://localhost:44333",
//                                               "http://www.contoso.com");
//                       });
// });


//builder.Services.AddOidcAuthentication(options =>
//{
//    builder.Configuration.Bind("AzureAd", options.ProviderOptions);
//    options.ProviderOptions.ResponseType = "code";
//});


builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
    options.ProviderOptions.LoginMode = "popup";
    //These all seem to return jwt token...not sure the difference yet...
    options.ProviderOptions.DefaultAccessTokenScopes.Add("openid");
    options.ProviderOptions.DefaultAccessTokenScopes.Add("offline_access");
    options.ProviderOptions.DefaultAccessTokenScopes.Add("api://d488b2ac-94e8-48b6-b280-32f747ea28ce/.default");
    //options.ProviderOptions.DefaultAccessTokenScopes.Add("api://d488b2ac-94e8-48b6-b280-32f747ea28ce/SampleScope.Read");
});

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IDataService, DataService>();
builder.Services.AddSingleton<AuthenticationState>();
builder.Services.AddScoped<CascadingAuthenticationState>();
 
builder.Services.AddSingleton<AppStateService>();

builder.Services.AddAntDesign();

await builder.Build().RunAsync();