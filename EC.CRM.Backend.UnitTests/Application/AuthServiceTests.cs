using System.Security.Cryptography;

namespace EC.CRM.Backend.UnitTests.Application
{
    public class AuthServiceTests
    {
        [Test]
        public void AuthCreateHash()
        {
            var password = "admin";
            byte[] passwordHash;
            byte[] passwordSalt;
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
