using WAS.Client.Models;
using WAS.Client.Pages;
using WAS.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WAS.Components.Account;
using WAS.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");;

builder.Services.AddDbContext<WASContext>(options => options.UseSqlServer(connectionString));

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

builder.Services.AddCascadingAuthenticationState();

builder.Services.AddScoped<IdentityUserAccessor>();

builder.Services.AddScoped<IdentityRedirectManager>();

builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

builder.Services.AddIdentityCore<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<WASContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<AppUser>, IdentityNoOpEmailSender>();

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

app.MapAdditionalIdentityEndpoints();;

app.Run();
