using BlazorAppAlejandroChR.Client;
using BlazorAppAlejandroChR.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5044") });

builder.Services.AddScoped<LbroService>();

builder.Services.AddScoped<TipoLibroService>();

builder.Services.AddScoped<AutorService>();

builder.Services.AddScoped<UtilService>();  

await builder.Build().RunAsync();
