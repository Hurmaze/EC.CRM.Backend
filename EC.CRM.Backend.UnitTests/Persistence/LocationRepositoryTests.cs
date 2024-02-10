using EC.CRM.Backend.Domain.Entities;
using EC.CRM.Backend.Domain.Exceptions;
using EC.CRM.Backend.Persistence.DataContext;
using EC.CRM.Backend.Persistence.Repositories;

namespace EC.CRM.Backend.UnitTests.Persistence
{
    internal class LocationRepositoryTests : BasePersistenceTest
    {
        [Test]
        public void UpdateLocationTest()
        {
            var dbContext = new EngineeringClubDbContext(GetDbOptions());
            var repository = new LocationRepository(dbContext);

            var location = new Location { Address = "AA", City = "BB", };

            Assert.ThrowsAsync<NotFoundException>(async () => await repository.UpdateAsync(Guid.NewGuid(), location));
        }
    }
}
