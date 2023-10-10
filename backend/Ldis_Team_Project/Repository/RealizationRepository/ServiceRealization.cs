using Ldis_Team_Project.DbContextApplicationFolder;
using Ldis_Team_Project.Models;
using Ldis_Team_Project.Repository.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Ldis_Team_Project.Repository.RealizationRepository
{
    public class ServiceRealization : IRepositoryService
    {
        private readonly DbContextApplication _Context;
        public ServiceRealization(DbContextApplication context)
        {
            _Context = context;
        }

        public void CreateUser(string Email, string Code, string UserName)
        {
            var UserInstance = new User
            {
                UserName = UserName,
                Password = Code,
                Email = Email,
                Actual = 1,
                Status = "Online"
            };
            _Context.Add(UserInstance);
            _Context.SaveChanges();
        }

        public async Task<bool> FindUser(string UserName, string Password)
        {
            var User = await _Context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.UserName == UserName &&  x.Password == Password);
            if (User == null)
            {
                return false;
            }
            else
            {
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
    }
}
