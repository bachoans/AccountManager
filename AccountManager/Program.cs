using AccountManager.Components;
using AccountManager.Shared.Interfaces;
using AccountManager.Shared.Services;
using AccountManager.Data;
using AccountManager.Data.Interfaces;
using AccountManager.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using AccountManager.Client.Services;

var builder = WebApplication.CreateBuilder(args);

// ------------------------------
// 🔧 Configure Services
// ------------------------------

// Database
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    // Or use SQLite: options.UseSqlite("Data Source=account.db");
});

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7101")
});


builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();
builder.Services.AddScoped<IAccountLogService, AccountLogService>();

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountSubscriptionRepository, AccountSubscriptionRepository>();
builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
builder.Services.AddScoped<IAccountChangesLogRepository, AccountChangesLogRepository>();

builder.Services.AddScoped<AccountApiService>();
builder.Services.AddScoped<SubscriptionApiService>();

builder.Services.AddHttpClient();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
