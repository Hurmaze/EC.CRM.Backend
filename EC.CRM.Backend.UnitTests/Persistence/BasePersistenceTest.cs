using EC.CRM.Backend.Domain.Entities;
using EC.CRM.Backend.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;

namespace EC.CRM.Backend.UnitTests.Persistence
{
    internal class BasePersistenceTest
    {
        protected List<Role> roles = new()
        {
            new Role { Name = "Mentor", Uid = Guid.Parse("136418AE-FEBC-4981-B748-7423DF8DA8B2")},
            new Role { Name = "Student", Uid = Guid.Parse("FF378AAA-094A-4C36-999E-530BC38F6897")},
        };

        protected List<Location> locations = new()
        {
            new Location { Address = "Address1", City = "City1", Uid = Guid.Parse("E33421CE-D2E2-40BD-B4BB-643C7E3B9B32")},
            new Location { Address = "Address2", City = "City2",  Uid = Guid.Parse("7517032E-5C62-4166-A1DB-870EF7B8BCE7")},
        };

        public DbContextOptions<EngineeringClubDbContext> GetDbOptions()
        {
            var options = new DbContextOptionsBuilder<EngineeringClubDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using var dbContext = new EngineeringClubDbContext(options);

            Seed(dbContext);

            return options;
        }

        private void Seed(EngineeringClubDbContext dbContext)
        {
            dbContext.Roles.AddRange(roles);
            dbContext.SaveChanges();

            dbContext.Locations.AddRange(locations);
            dbContext.SaveChanges();
        }
    }
}
