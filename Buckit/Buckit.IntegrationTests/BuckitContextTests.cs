using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Buckit.Data;

namespace Buckit.IntegrationTests
{
    public class BuckitContextTests
    {
        [Fact]
        public async Task Db_CreatedSunccessfully()
        {
            var optionsBuilder = new DbContextOptions<buckitdbContext>();
            //optionsBuilder.UseInMemoryDatabase("MyShuttleTestDb");
            var context = new buckitdbContext(optionsBuilder);
            //var databaseCreated = await context.Database.EnsureCreatedAsync();
            //Assert.True(databaseCreated);
            //var databaseDeleted = await context.Database.EnsureDeletedAsync();
            //Assert.True(databaseDeleted);
        }
    }
}
