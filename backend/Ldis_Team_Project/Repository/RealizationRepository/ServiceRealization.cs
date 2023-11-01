using Dapper;
using Ldis_Team_Project.DbContextApplicationFolder;
using Ldis_Team_Project.Models;
using Ldis_Team_Project.Repository.Services;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Serilog;
using System.Collections.ObjectModel;
using System.Data;

namespace Ldis_Team_Project.Repository.RealizationRepository
{
    public class ServiceRealization : IRepositoryService
    {
        private readonly DbContextApplication _Context;
        private readonly IHttpContextAccessor _ContedxtAccessor;
        public const string EmailKeySession = "KeyEmail";
         private IMemoryCache _Cache;
        public ServiceRealization(DbContextApplication context,IHttpContextAccessor contextAccessor,IMemoryCache cache)
        {
            _Cache = cache;
            _ContedxtAccessor = contextAccessor;
            _Context = context;
        }
        public async Task CreateUser(string Email, string Code, string UserName, string ImageLink)
        {
            var UserInstance = new User
            {
                UserName = UserName,
                Password = Code,
                Email = Email,
                Actual = 1,
                Status = "Online",
                ImageAvatarLink = ImageLink
            };
            _Context.Add(UserInstance);
            _Context.SaveChanges();
        }
        public async Task<bool> FindUserLogin(string UserName, string Password)
        {
            var User = await _Context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.UserName == UserName &&  x.Password == Password);
            if (User == null)
            {
                return false;
            }
            else
            {
                string Email = User.Email;
                _ContedxtAccessor.HttpContext.Session.SetString(EmailKeySession, Email);
                return true;
            }
        }
        public async Task<bool> FindUserByEmail(string Email)
        {
            var User = await _Context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == Email);
            if (User == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public async Task<bool> FindUserRegistration(string Email, string Password)
        {
            var User = await _Context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == Email || Password == Password);
            if (User != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public async Task AddPrivateMessage(int IdPrivateUser,int IdUser)
        {
            var PrivateUser = await _Context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == IdPrivateUser);
            var User = await _Context.NoRegisterUsers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == IdUser);
            User.PersonalMessageId.Add(PrivateUser);
            _Context.SaveChanges();
        }
        public void CreateAnonymousUser(string UserName)
        {
            var AnonymousUserInstance = new NoRegisterUser
            { 
              UserName = UserName
            };

            _Context.Add(AnonymousUserInstance);
            _Context.SaveChanges();
        }
        public async Task ChangeStatus(string Email,string Action)
        {
            var User = await _Context.Users.FirstOrDefaultAsync(x => x.Email == Email);
            if (Action == "Connected")
            {
                User.Status = "Online";
            }
            else if (Action == "Disconnected")
            {
                User.Status = "Ofline";
            }
            _Context.SaveChanges();
        }
        public async Task DeleteUserFromGroup(string Email,string ChatName)
        {
            var User = await _Context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == Email);
            var Chats = await _Context.Chats.FirstOrDefaultAsync(x => x.ChatName == ChatName);

            var ConfigurationFile = new ConfigurationBuilder().AddUserSecrets<ServiceRealization>().Build();
            string ConnectionString = ConfigurationFile.GetConnectionString("DataBaseConnect");
            
            using (IDbConnection db = new SqliteConnection())
            {
                var sqlquery = $"DELETE FROM ChatUser WHERE ChatsId = {Chats.Id} AND UsersId = {User.Id}";
                db.Execute(sqlquery);
            }
            _Context.SaveChanges();
        }
        public async Task AddUserToGroup(string Email, string GroupName)
        {
            var User = await _Context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == Email);
            var Chat = await _Context.Chats.FirstOrDefaultAsync(x => x.ChatName == GroupName);

            Chat.Users.Add(User);
            User.Chats.Add(Chat);
            _Context.SaveChanges();
        }
        public async void AddMessage(string message, string groupName, string userName)
        {
            var User = await _Context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            var Chat = await _Context.Chats.FirstOrDefaultAsync(x => x.ChatName == groupName);

            var MessageInstance = new Message
            {
                DateSend = DateTime.Now,
                Text = message,
                Actual = 1,
                UserId = new List<User> {User},
                ChatId = new List<Chat> {Chat}
            };
            await _Context.AddAsync(MessageInstance);
             _Context.SaveChanges();
        }
    }
}