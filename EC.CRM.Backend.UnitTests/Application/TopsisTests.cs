using EC.CRM.Backend.Application.Services.Implementation.TOPSIS;

namespace EC.CRM.Backend.UnitTests.Application
{
    public class TopsisTests
    {
        [Test]
        public void TopsisTest()
        {
            // Arrange
            double[,] decisionMatrix =
            {
                {5, 8, 4},
                {7, 6, 8},
                {8, 8, 6},
                {7, 4, 6}
            };

            double[] weights = { 0.3, 0.4, 0.3 };
            bool[] isBeneficial = { true, true, true, true };

            var topsis = new TopsisAlgorithm();

            var expectedKeys = new[] { 3, 2, 1, 4 };
            var expectedValues = new[]
            {
                0.7482486599406238,
                0.6580847719618138,
                0.5037196585795188,
                0.333997436943342,
            };

            // Act
            var actualResult = topsis.Calculate(decisionMatrix, weights, isBeneficial);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.Equals(actualResult.Keys.OrderDescending(), expectedKeys);
                Assert.Equals(actualResult.Values, expectedValues);
            });
        }
    }
}
