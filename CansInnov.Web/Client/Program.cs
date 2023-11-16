using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CansInnov.Application;
using CansInnov.Client;
using CansInnov.Persistence;
using Radzen;
using Microsoft.AspNetCore.Components.Authorization;
using CansInnov.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, HostAuthenticationStateProvider>();


await builder.Build().RunAsync();
