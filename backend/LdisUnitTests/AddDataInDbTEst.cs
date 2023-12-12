using Ldis_Project_Reliz.Server.LdisDbContext;
using Ldis_Project_Reliz.Server.Repository;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LdisUnitTests
{
    public class AddDataInDbTEst
    {
        [Fact]
        public void Add ()
        {
            DbContextOptions<DbContextApplication> options = new DbContextOptions<DbContextApplication>();
            DbContextApplication context = new DbContextApplication(options);
            RepositoryRealization realization = new RepositoryRealization(context);
            realization.AddToGroup("Alex","Car","illanazarov966@gmail.com");
            realization.AddToGroup("Alex", "Ship", "illanazarov966@gmail.com");
            realization.AddToGroup("Alex", "Shone", "illanazarov966@gmail.com");
            realization.AddToGroup("Alex", "Basket", "illanazarov966@gmail.com");
            realization.AddToGroup("Alex", "Game", "illanazarov966@gmail.com");
            realization.AddToGroup("Alex", "TV", "illanazarov966@gmail.com");
            Assert.True(1 == 1);
        }

    }
}
