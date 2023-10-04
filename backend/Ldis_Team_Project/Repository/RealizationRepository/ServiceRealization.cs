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

        public bool FindUserByEmail(string Email)
        {
            var User = _Context.Users.AsNoTracking().FirstOrDefault(x => x.Email == Email);
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
