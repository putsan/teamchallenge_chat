using Ldis_Team_Project.DbContextApplicationFolder;
using Ldis_Team_Project.Models;
using Ldis_Team_Project.Models.BusinesModels;
using Ldis_Team_Project.ServiceExtensionCollection;
using Ldis_Team_Project.SignalR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
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

Console.WriteLine("hello");
var options = new DbContextOptionsBuilder<DbContextApplication>()
    .UseSqlite("DataBaseConnect")
    .Options;
using (DbContextApplication db = new DbContextApplication(options))
{
    var genres = db.Genres.ToList();
    var images = db.Images.ToList();
    var messagesTypes = db.MessageTypes.ToList();
    var reactions = db.Reactions.ToList();
    var tags = db.Tags.ToList();
    var visibles = db.Visibles.ToList();
    var chats = db.Chats.ToList();

    //Chat chat3 = new Chat
    //{
    //    NameChat = "22222 chat",
    //    Description = "22222",
    //    CreatDate = DateTime.Now,
    //    CountUsers = 222,
    //    Link = "2222.link",
    //    Genre = genres.First(el => el.Id == 3),
    //    VisibleId = visibles.FirstOrDefault(el => el.Id == 3).Id,
    //    AvatarId = images.FirstOrDefault(el => el.Id == 3).Id,
    //    Tags = new List<Tag>
    //    {
    //        tags.FirstOrDefault(el=>el.Id == 3),
    //        tags.FirstOrDefault(el=>el.Id == 1)
    //    },
    //    Actual = 1
    //};
    Message message1 = new Message
    {
        Chats = new List<Chat>
        {
            chats.First(el=>el.Id==1)
        },
        Content = "hello 11111111",
        Timestamp = DateTime.Now,
        IsRead = true,
        MessageType = messagesTypes.First(el => el.Id == 1),
        edited = false,
        Reactions = new List<Reaction>
        {
            reactions.FirstOrDefault(el => el.Id == 2),
            reactions.First(el => el.Id == 4)
        },
        ForwardedFrom = null,
        deletedByReceiver = false,
        deletedBySender = false
    };

    Message message2 = new Message
    {
        Chats = new List<Chat>
        {
            chats.First(el=>el.Id == 1),
            chats.First(el=>el.Id == 2)
        },
        Content = "222222222222.link",
        Timestamp = DateTime.Now,
        IsRead = false,
        MessageTypeId = messagesTypes.First(el => el.Id == 2).Id,
        edited = false,
        Reactions = new List<Reaction>
        {
            reactions.FirstOrDefault(el => el.Id == 1)
        },
        ForwardedFromId = null,
        deletedByReceiver = true,
        deletedBySender = false
    };

    Message message3 = new Message
    {
        Content = "newwwwwwwwwwwwww 33333333",
        Timestamp = DateTime.Now,
        IsRead = true,
        MessageType = messagesTypes.First(el => el.Id == 1),
        edited = false,
        ForwardedFrom = null,
        deletedByReceiver = false,
        deletedBySender = false
    };
    try
    {
        // Your code to save changes to the database
        db.Messages.Add(message1);
        db.Messages.Add(message2);
        db.Messages.Add(message3);
        db.SaveChanges();
    }
    catch (DbUpdateException ex)
    {
        if (ex.InnerException != null)
        {
            var innerException = ex.InnerException;
            while (innerException.InnerException != null)
            {
                innerException = innerException.InnerException;
            }

            Console.WriteLine("Inner Exception: " + innerException.Message);
        }
        else
        {
            Console.WriteLine("DbUpdateException: " + ex.Message);
        }
    }
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
