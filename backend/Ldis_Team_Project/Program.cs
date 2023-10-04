using Ldis_Team_Project.DbContextApplicationFolder;
using Ldis_Team_Project.Models.BusinesModels;
using Ldis_Team_Project.ServiceExtensionCollection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
builder.Services.AddDbContext<DbContextApplication>();
builder.Services.AddCors();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(5);
});
ServiceDependencyCollection.AddDIContainerServices(builder.Services);
Log.Logger = new LoggerConfiguration().MinimumLevel
    .Information().WriteTo
    .File("/Ldis_Team_Project/LoggsFile/Loggs.txt", rollingInterval:RollingInterval.Day).CreateLogger();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors(
    builder
     => builder.AllowAnyOrigin()
    );
app.UseRouting();
app.UseSession();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
