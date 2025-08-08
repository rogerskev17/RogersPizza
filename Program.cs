using Microsoft.EntityFrameworkCore;
using RogersPizza.Data;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.Configure(builder.Configuration.GetSection("Kestrel"));
});
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();
// builder.Logging.SetMinimumLevel(LogLevel.Debug);
// builder.Logging.AddFilter("Microsoft.AspNetCore.Antiforgery", LogLevel.Debug);
// builder.Logging.AddFilter("Microsoft.AspNetCore.Routing", LogLevel.Debug);
// builder.Logging.AddFilter("Microsoft.AspNetCore.Mvc", LogLevel.Debug);
// builder.Logging.AddFilter("Microsoft.AspNetCore.Diagnostics", LogLevel.Debug);


builder.Services.AddDbContext<StoreContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("StoreContextSQLite")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddAntiforgery();

WebApplication app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseDeveloperExceptionPage();
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

IServiceScope scope = app.Services.CreateScope();
IServiceProvider provider = scope.ServiceProvider;
StoreContext context = provider.GetRequiredService<StoreContext>();
context.Database.EnsureCreated();
DbInitializer.Initialize(context);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.MapRazorPages();
app.MapControllers();

app.Run();