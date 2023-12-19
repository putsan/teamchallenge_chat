using Ldis_Project_Reliz.Server.Repository;
using Ldis_Project_Reliz.Server.Services.Interfaces;
using Ldis_Project_Reliz.Server.Services.Realization;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LdisUnitTests
{
    public  class ReturnUrlOauthTEst
    {
      
        public void Test()
        {
            var moqAccessor = new Mock<IHttpContextAccessor>();
            moqAccessor.Setup(x => x.HttpContext);

            var moqRepo = new Mock<IRepository>();
            moqRepo.Setup(x => x.FindUserByEmailForDeletedTimer("illanazarov966@gmail.com"));
         /*   DeleteNoActivityUserTimer deleted = new DeleteNoActivityUserTimer(moqRepo.Object,moqAccessor.Object);
            deleted.Delete(1);
            Assert.True(1 == 1);*/
        }
    }
}
