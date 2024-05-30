using EC.CRM.Backend.Domain.Entities;
using EC.CRM.Backend.Domain.Exceptions;
using EC.CRM.Backend.Persistence.DataContext;
using EC.CRM.Backend.Persistence.Repositories;

namespace EC.CRM.Backend.UnitTests.Persistence
{
    internal class StudyFieldReposiotiryTests : BasePersistenceTest
    {
        [Test]
        public void UpdateLocationTest_NotExistingUid_ShouldThrowException()
        {
            using var dbContext = new EngineeringClubDbContext(GetDbOptions());
            var repository = new LocationRepository(dbContext);

            var location = new Location { Address = "AA", City = "BB", Uid = Guid.NewGuid() };

            Assert.ThrowsAsync<NotFoundException>(async () => await repository.UpdateAsync(location));
        }

        [Test]
        public async Task UpdateLocationTest_ExistingUid_ShouldUpdate()
        {
            // Arrange
            using var dbContext = new EngineeringClubDbContext(GetDbOptions());
            var repository = new LocationRepository(dbContext);
            var location = new Location { Address = "AA", City = "BB", Uid = locations[0].Uid };

            // Act
            await repository.UpdateAsync(location);

            // Assert
            var updatedEntity = await repository.GetAsync(locations[0].Uid);
            Assert.Multiple(() =>
            {
                Assert.That(updatedEntity, Is.Not.Null);
                Assert.That(updatedEntity!.City, Is.EqualTo(location.City));
                Assert.That(updatedEntity.Address, Is.EqualTo(location.Address));
            });
        }

        [Test]
        public async Task AddLocation_ShouldAddLocation()
        {
            // Arrange
            using var dbContext = new EngineeringClubDbContext(GetDbOptions());
            var repository = new LocationRepository(dbContext);
            var location = new Location { Address = "AA", City = "BB" };

            // Act
            var createdEntity = await repository.CreateAsync(location);

            // Assert
            var updatedEntity = await repository.GetAsync(createdEntity.Uid);
            Assert.NotNull(updatedEntity);
            Assert.Multiple(() =>
            {
                Assert.That(updatedEntity.Uid, Is.Not.EqualTo(Guid.Empty));
                Assert.That(updatedEntity!.City, Is.EqualTo(location.City));
                Assert.That(updatedEntity.Address, Is.EqualTo(location.Address));
            });
        }

        [Test]
        public async Task GetAll_ShouldReturnAllLocations()
        {
            // Arrange
            using var dbContext = new EngineeringClubDbContext(GetDbOptions());
            var repository = new LocationRepository(dbContext);

            // Act
            var allEntitites = await repository.GetAllAsync();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(allEntitites.Count, Is.EqualTo(locations.Count));
                Assert.That(allEntitites[0].Uid, Is.EqualTo(locations[0].Uid));
                Assert.That(allEntitites[1].Uid, Is.EqualTo(locations[1].Uid));
            });
        }

        [Test]
        public async Task GetById_ShouldReturnProperLocation()
        {
            // Arrange
            using var dbContext = new EngineeringClubDbContext(GetDbOptions());
            var repository = new LocationRepository(dbContext);

            // Act
            var entity = await repository.GetAsync(locations[0].Uid);

            // Assert
            Assert.NotNull(entity);
            Assert.Multiple(() =>
            {
                Assert.That(entity.Uid, Is.EqualTo(locations[0].Uid));
                Assert.That(entity!.City, Is.EqualTo(locations[0].City));
                Assert.That(entity.Address, Is.EqualTo(locations[0].Address));
            });
        }

        [Test]
        public async Task GetById_ShouldReturnNull()
        {
            // Arrange
            using var dbContext = new EngineeringClubDbContext(GetDbOptions());
            var repository = new LocationRepository(dbContext);

            // Act
            var entity = await repository.GetAsync(Guid.NewGuid());

            // Assert
            Assert.IsNull(entity); ;
        }

        [Test]
        public async Task DeleteById_ShouldDeleteEntity()
        {
            // Arrange
            using var dbContext = new EngineeringClubDbContext(GetDbOptions());
            var repository = new LocationRepository(dbContext);

            // Act
            await repository.DeleteAsync(locations[0].Uid);

            // Assert
            var allEntitites = await repository.GetAllAsync();
            Assert.Multiple(() =>
            {
                Assert.That(allEntitites.Count, Is.EqualTo(locations.Count - 1));
                CollectionAssert.DoesNotContain(allEntitites.Select(x => x.Uid), locations[0].Uid);
            });
        }

        [Test]
        public void DeleteById_ShouldReturnNull()
        {
            // Arrange
            using var dbContext = new EngineeringClubDbContext(GetDbOptions());
            var repository = new LocationRepository(dbContext);

            // Act
            // Assert;
            Assert.ThrowsAsync<NotFoundException>(async () => await repository.DeleteAsync(Guid.NewGuid()));
        }
    }
}
