using WAS.Client.Models;
using WAS.Client.Pages;
using WAS.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents() // Add this line for server-side interactivity for Counter.razor
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddHttpClient("ServersAPI", client =>
{
    client.BaseAddress = new Uri("https://webassembly-demo-f237e-default-rtdb.europe-west1.firebasedatabase.app/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});
builder.Services.AddTransient<IServersRepos, ServersAPIRepos>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode() // Add this line for server-side interactivity for Counter.razor
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(WAS.Client._Imports).Assembly);

app.Run();
