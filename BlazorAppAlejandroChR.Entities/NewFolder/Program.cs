using AlejandroChRProyecto.Client;
using AlejandroChRProyecto.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5276") });//url Api

builder.Services.AddScoped<EventoService>();

builder.Services.AddScoped<TipoEventoService>();

builder.Services.AddScoped<ClienteService>();

builder.Services.AddScoped<UtilService>();

await builder.Build().RunAsync();
