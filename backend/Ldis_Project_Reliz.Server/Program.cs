using Ldis_Project_Reliz.Server.LdisDbContext;
using Ldis_Project_Reliz.Server.ServiceCollectionInjectExtension;
using Ldis_Project_Reliz.Server.SignalR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
builder.Services.AddDbContext<DbContextApplication>();
builder.Services.AddSwaggerGen();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();
builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
    options.AddPolicy("ClientPermission", policy =>
    {
        policy.AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("http://localhost:5174")
            .AllowCredentials();
    });
});
builder.Services.AddSession(setting =>
    {
        setting.IdleTimeout = TimeSpan.FromMinutes(5);
    });
    ServiceInjectCollection.ServiceCollection(builder.Services);
    Log.Logger = new LoggerConfiguration().MinimumLevel.Information().WriteTo.File("/Ldis_Project_Reliz/Ldis_Project_Reliz.Server/Loggs/LoggsFile.txt", rollingInterval: RollingInterval.Day).CreateLogger();
    var app = builder.Build();

    app.UseDefaultFiles();
    app.UseStaticFiles();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseCors("ClientPermission");
    app.UseAuthorization();
    app.MapHub<ChatHub>("/groupchat");
    app.MapControllers();
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");

    app.MapFallbackToFile("/index.html");

    app.Run();

