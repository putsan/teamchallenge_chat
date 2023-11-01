using Ldis_Team_Project.DbContextApplicationFolder;
using Ldis_Team_Project.Models.BusinesModels;
using Ldis_Team_Project.ServiceExtensionCollection;
using Ldis_Team_Project.SignalR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
builder.Services.AddDbContext<DbContextApplication>();
builder.Services.AddHttpClient();
builder.Services.AddSignalR();
builder.Services.AddCors();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(5);
});
builder.Services.AddCors(options =>
{
     options.AddPolicy("ClientPermission", policy =>
    {
        policy.AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("http://localhost:5173")
            .AllowCredentials();
    });
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
app.UseCors("ClientPermission");
app.MapHub<GroupChatHub>("/groupchat");
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
