using System.Net.Http;
using Domain.Auth;
using HttpClients.ClientInterfaces;
using HttpClients.Implementations;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using WebApp;
using WebApp.auth;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IRideService, RideHttpClient>();
builder.Services.AddScoped<IReservationService, ReservationHttpClient>();
builder.Services.AddScoped<ILoginService, LoginHttpClient>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();

AuthorizationPolicies.AddPolicies(builder.Services);

builder.Services.AddScoped(sp => new HttpClient { });

await builder.Build().RunAsync();