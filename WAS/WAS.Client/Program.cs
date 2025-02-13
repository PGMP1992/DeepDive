using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WAS.Client;
using WAS.Client.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddHttpClient("ServersAPI", client =>
{
    client.BaseAddress = new Uri("https://webassembly-demo-f237e-default-rtdb.europe-west1.firebasedatabase.app/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});
builder.Services.AddTransient<IServersRepos, ServersAPIRepos>();
await builder.Build().RunAsync();
