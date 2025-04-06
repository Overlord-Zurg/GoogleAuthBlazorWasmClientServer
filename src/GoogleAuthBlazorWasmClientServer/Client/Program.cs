using Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var googleClientID = "GOOGLE_CLIENT_ID_GOES_HERE";

builder.Services.AddOidcAuthentication(options =>
{
    // Configure your authentication provider options here.
    // For more information, see https://aka.ms/blazor-standalone-auth
    options.ProviderOptions.ClientId = googleClientID;
    options.ProviderOptions.Authority = "https://accounts.google.com";
    options.ProviderOptions.RedirectUri = "https://localhost:7135/authentication/login-callback";
    options.ProviderOptions.PostLogoutRedirectUri = "https://localhost:7135/authentication/logout-callback";
    options.ProviderOptions.ResponseType = "id_token";
    //options.ProviderOptions.DefaultScopes.Add("openid");
    //options.ProviderOptions.DefaultScopes.Add("profile");
    //options.ProviderOptions.DefaultScopes.Add("email");
});


await builder.Build().RunAsync();
