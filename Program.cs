using RogersPizza.Data;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StoreContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("StoreContextSQLite")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddRazorPages();

WebApplication app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
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
app.UseAuthorization();
app.MapRazorPages();

app.Run();

// namespace RogersPizza
// {
//     public class Program
//     {
//         public static void Main(string[] args)
//         {
            //initialize application
            // WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            // builder.Services.AddEndpointsApiExplorer();
            // WebApplication app = builder.Build();
            // app.UseExceptionHandler();
            

            //configure database
            // builder.Services.AddScoped<DbContext, StoreContext>();
            // builder.Services.AddDbContext<StoreContext>(options => options.UseSqlServer(Configuration.GetConnectionString("")));
            // builder.Services.AddControllersWithViews();
            // app.UseRouting();
            // app.MapControllers();

            //initialize database
            // builder.Services.AddTransient<DbInitializer>();
            // IHost host = CreateHostBuilder(args).Build();
            // CreateDbIfNone(host);
            // host.Run();

            //set startup page
            // DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
            // defaultFilesOptions.DefaultFileNames.Clear();
            // defaultFilesOptions.DefaultFileNames.Add("index.html");
            // app.UseDefaultFiles(defaultFilesOptions);
            // app.UseStaticFiles();

            //run application
            // app.Run();
        // }

        // public static IHostBuilder CreateHostBuilder(string[] args) =>
        //            Host.CreateDefaultBuilder(args)
        //                .ConfigureWebHostDefaults(webBuilder =>
        //                {
        //                    webBuilder.UseStartup<Startup>();
        //                });
        
        // private static void CreateDbIfNone(IHost host)
        // {
        //     IServiceScope scope = host.Services.CreateScope();
        //     IServiceProvider provider = scope.ServiceProvider;
        //     try
        //     {
        //         StoreContext context = provider.GetRequiredService<StoreContext>();
        //         DbInitializer.Initialize(context);
        //     }
        //     catch (Exception ex)
        //     {
        //         ILogger logger = provider.GetRequiredService<ILogger<Program>>();
        //         logger.LogError(ex, "An error occurred creating the DB.");
        //         Console.WriteLine(ex.StackTrace);
        //     }
        // }
//     }
// }