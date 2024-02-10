using EC.CRM.Backend.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;

namespace EC.CRM.Backend.UnitTests.Persistence
{
    internal class BasePersistenceTest
    {
        public static DbContextOptions<EngineeringClubDbContext> GetDbOptions()
        {
            var options = new DbContextOptionsBuilder<EngineeringClubDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return options;
        }
    }
}
