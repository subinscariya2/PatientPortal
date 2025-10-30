using Moq;
using PatientPortal.Models;
using PatientPortal.Repository;
using PatientPortal.Service;

namespace PatientPortalTest
{
    public class PatientServiceTests
    {
        private readonly Mock<IPatientRepository> _mockRepo;
        private readonly PatientService _service;

        public PatientServiceTests()
        {
            _mockRepo = new Mock<IPatientRepository>();
            _service = new PatientService(_mockRepo.Object);
        }

        [Fact]
        public void GetPatientById_ShouldReturnPatient_WhenPatientExists()
        {
            // Arrange
            var patient = new Patient { Id = 1, NHSNumber = "1800", Name = "George" };
            _mockRepo.Setup(r => r.GetPatientRecord(1)).Returns(patient);

            // Act
            var result = _service.GetPatientDatabyId(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("1800", result.NHSNumber);
        }

        [Fact]
        public void GetPatientById_ShouldReturnNull_WhenPatientDoesNotExist()
        {
            // Arrange
            _mockRepo.Setup(r => r.GetPatientRecord(It.IsAny<int>())).Returns((Patient?)null);

            // Act
            var result = _service.GetPatientDatabyId(10);

            // Assert using xUnit
            Assert.Null(result);
        }

        [Fact]
        public void GetPatientById_ShouldThrowException_WhenNHSNumberIsMissing()
        {
            var patient = new Patient { Id = 2, NHSNumber = "", Name = "John" };
            _mockRepo.Setup(r => r.GetPatientRecord(2)).Returns(patient);

            var ex = Assert.Throws<ArgumentException>(() => _service.GetPatientDatabyId(2));
            Assert.Equal("NHS Number is required.", ex.Message);
        }

        [Fact]
        public void GetPatientById_ShouldThrowException_WhenNameIsMissing()
        {
            var patient = new Patient { Id = 3, NHSNumber = "2000", Name = "" };
            _mockRepo.Setup(r => r.GetPatientRecord(3)).Returns(patient);

            var ex = Assert.Throws<ArgumentException>(() => _service.GetPatientDatabyId(3));
            Assert.Equal("Patient name is required.", ex.Message);
        }

        [Fact]
        public void GetPatientById_ShouldThrowException_WhenDateOfBirthIsInFuture()
        {
            var patient = new Patient { Id = 4, NHSNumber = "3000", Name = "Alice", DateOfBirth = DateTime.Today.AddDays(1) };
            _mockRepo.Setup(r => r.GetPatientRecord(4)).Returns(patient);

            var ex = Assert.Throws<ArgumentException>(() => _service.GetPatientDatabyId(4));
            Assert.Equal("Date of birth cannot be in the future.", ex.Message);
        }


    }
}
