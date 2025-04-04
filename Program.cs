using RogersPizza.Data;
using Microsoft.EntityFrameworkCore;

//initialize application
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseExceptionHandler();
builder.Services.AddEndpointsApiExplorer();

//configure database
builder.Services.AddScoped<DbContext, StoreContext>();
builder.Services.AddControllersWithViews();
app.UseRouting();
app.MapControllers();

//set startup page
DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
defaultFilesOptions.DefaultFileNames.Clear();
defaultFilesOptions.DefaultFileNames.Add("index.html");
app.UseDefaultFiles(defaultFilesOptions);
app.UseStaticFiles();

//run application
app.Run();