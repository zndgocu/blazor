using blazor.wasm.Client;
using blazor.wasm.Client.JsInterop.Container;
using blazor.wasm.Client.Service;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<MenuProviderService>();
builder.Services.AddSingleton<JsInteropRepository>();
builder.Services.AddSingleton<JsProviderService>();

//mudblazor
builder.Services.AddMudServices();


await builder.Build().RunAsync();
