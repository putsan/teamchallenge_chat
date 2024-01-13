using Microsoft.Extensions.Caching.Memory;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LdisUnitTests
{
    public class testProgram
    {
        [Fact]
        public void TestProgram ()
        {
            var mock = new Mock<IMemoryCache>();
            mock.Setup(x => x.Set("a","illanazarov966@gmail.com"));
            var DeletedActiv = new Program(mock.Object);
            DeletedActiv.Started();

        }
/*        [Fact]
        public void TestProgramTwo()
        {
            var mock = new Mock<IMemoryCache>();
            mock.Setup(x => x.Get("a"));
            var DeletedActiv = new DeleteNoActivityUserTimer(mock.Object);
            DeletedActiv.Delete(1);
        }*/
    }
}
