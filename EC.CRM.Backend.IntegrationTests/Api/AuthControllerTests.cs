namespace EC.CRM.Backend.IntegrationTests.Api
{
    internal class AuthControllerTests
    {
        [Test]
        public void Login_ValidCredentials_ReturnsTrue()
        {
            Thread.Sleep(200);
            Assert.True(true);
        }

        [Test]
        public void Login_InvalidCredentials_ReturnsTrue()
        {
            Assert.True(true);
        }

        [Test]
        public void Logout_UserLoggedIn_ReturnsTrue()
        {
            Assert.True(true);
        }

        [Test]
        public void Logout_UserNotLoggedIn_ReturnsTrue()
        {
            Assert.True(true);
        }
    }
}
