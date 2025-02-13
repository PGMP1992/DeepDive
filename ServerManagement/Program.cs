using Microsoft.EntityFrameworkCore;
using ServerManagement.Data;
using ServerManagement.Components;
using ServerManagement.Models;
using ServerManagement.StateStore;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using ServerManagement.Components.Account;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IServerRepos,ServerRepos>();
builder.Services.AddScoped<TorontoServersStore>();

// 
// Identity, Authentication and Authorization ------------------------- 
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
    .AddEntityFrameworkStores<AppDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

// Adding Policies for Authorization
builder.Services.AddAuthorizationCore(options =>
{
    options.AddPolicy("Manager", policy => policy.RequireClaim("Role", "Manager"));
});

builder.Services.AddSingleton<IEmailSender<AppUser>, IdentityNoOpEmailSender>();
// End of 
// Identity, Authentication and Authorization ------------------------- 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>().
    AddInteractiveServerRenderMode();

app.MapAdditionalIdentityEndpoints();;

app.Run();
