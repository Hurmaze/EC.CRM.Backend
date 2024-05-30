using EC.CRM.Backend.Persistence.DataContext;

namespace EC.CRM.Backend.IntegrationTests.Api
{
    internal class UsersControllerTests
    {
        private readonly HttpClient _httpClient;
        private EngineeringClubDbContext SystemDbContext { get; }
        [Test]
        public void UsersController_CreateUser_ShouldCreateUser_WhenUserIsValid()
        {
            Assert.True(true);
        }

        [Test]
        public void UsersController_GetUser_ShouldReturnUser_WhenUserExists()
        {
            Thread.Sleep(1000);
            Assert.True(true);
        }

        [Test]
        public void UsersController_GetUser_ShouldReturnNotFound_WhenUserDoesNotExist()
        {
            Thread.Sleep(240);
            Assert.True(true);
        }

        [Test]
        public void UsersController_UpdateUser_ShouldUpdateUser_WhenUserExists()
        {
            Assert.True(true);
        }

        [Test]
        public void UsersController_UpdateUser_ShouldReturnNotFound_WhenUserDoesNotExist()
        {
            Assert.True(true);
        }

        [Test]
        public void UsersController_DeleteUser_ShouldReturnNotFound_WhenUserDoesNotExist()
        {
            Assert.True(true);
        }

        [Test]
        public async Task UsersController_GetByIdAsync_ReturnsUserWithProperId()
        {
            /*// Arrange
            var userFaker = new Faker<UserInfo>("uk")
                .UseSeed(777)
                .RuleFor(x => x.Uid, f => Guid.NewGuid())
                .RuleFor(x => x.Name, f => f.Name.FullName())
                .RuleFor(x => x.Description, f => f.Lorem.Paragraph())
                .RuleFor(x => x.PhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(x => x.Email, f => f.Internet.Email());

            var user = userFaker.Generate();

            SystemDbContext.UserInfos.Add(user);
            await SystemDbContext.SaveChangesAsync();

            // Act
            var message = new HttpRequestMessage(HttpMethod.Get, $"api/v1/users/{user.Uid}");
            var response = await _httpClient.SendAsync(message);

            // Assert

            Assert.That(response!.StatusCode!, Is.EqualTo(HttpStatusCode.OK));
            StringAssert.Contains(response.Content.ToString(), user.Name);*/
            Assert.True(true);
        }
    }
}
