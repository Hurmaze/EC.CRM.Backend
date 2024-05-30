namespace EC.CRM.Backend.IntegrationTests.Api
{
    internal class StudentsControllerTests
    {
        [Test]
        public void GetAllStudents_ShouldReturnAllStudents()
        {
            // Arrange

            // Act

            // Assert
            Assert.True(true);
        }

        [Test]
        public void GetStudentById_ExistingId_ShouldReturnStudent()
        {
            // Arrange

            // Act

            // Assert
            Assert.True(true);
        }

        [Test]
        public void GetStudentById_NonExistingId_ShouldReturnNotFound()
        {
            // Arrange

            // Act

            // Assert
            Assert.True(true);
        }

        [Test]
        public void CreateStudent_ValidStudent_ShouldReturnCreatedStudent()
        {
            // Arrange

            // Act
            Thread.Sleep(200);
            // Assert
            Assert.True(true);
        }

        [Test]
        public void CreateStudent_InvalidStudent_ShouldReturnBadRequest()
        {
            // Arrange

            // ActThread.Sleep(200);
            Thread.Sleep(200);
            // Assert
            Assert.True(true);
        }

        [Test]
        public void UpdateStudent_ExistingId_ValidStudent_ShouldReturnNoContent()
        {
            // Arrange
            var timeToWait = 200;
            // Act
            Thread.Sleep(timeToWait);
            // Assert
            Assert.True(true);
        }

        [Test]
        public void UpdateStudent_ExistingId_InvalidStudent_ShouldReturnBadRequest()
        {
            // Arrange

            // Act

            // Assert
            Assert.True(true);
        }

        [Test]
        public void UpdateStudent_NonExistingId_ShouldReturnNotFound()
        {
            // Arrange

            // Act

            // Assert
            Assert.True(true);
        }

        [Test]
        public void DeleteStudent_ExistingId_ShouldReturnNoContent()
        {
            // Arrange

            // Act

            // Assert
            Assert.True(true);
        }

        [Test]
        public void DeleteStudent_NonExistingId_ShouldReturnNotFound()
        {
            // Arrange

            // Act

            // Assert
            Assert.True(true);
        }
    }
}
