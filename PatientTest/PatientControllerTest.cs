using Moq;
using Patient.Application;
using Patient.Domain.Entities;
using Patient.Presentation.Controllers;

namespace PatientTest
{
    public class PatientControllerTest
    {
        private readonly Mock<IPatientService> patientService;

        public PatientControllerTest()
        {
            patientService = new Mock<IPatientService>();
        }


        [Fact]
        public async void Get_PatientBy_ID()  
        {
            //arrange
            var patientList = GetPatientsData().ToList();
            patientService.Setup(x => x.GetByPatientId("P9851001"))
                .ReturnsAsync(patientList[0]);

            var patientController = new PatientController(patientService.Object);

            //act
            var patientResult = await patientController.GetByPatientId("P9851001");

            //assert
            Assert.NotNull(patientResult);
            Assert.Equal(patientList[0].PatientId, patientResult.PatientId);
            Assert.True(patientList[0].PatientId == patientResult.PatientId);
        }

        private List<Patients> GetPatientsData()
        {
            List<Patients> productsData = new List<Patients>
            {
                new Patients
                {
                    PatientId = "P9851001",
                    Name = "James",
                    PhoneNumber = "+91 8056166215",
                    DiseaseName = "Too much coding",
                    DateOfBirth = DateTime.Now,
                },
                 new Patients
                {
                    PatientId = "P6790262",
                    Name = "David",
                    PhoneNumber = "+91 8056166215",
                    DiseaseName = "Too much testing",
                    DateOfBirth = DateTime.Now,
                }              
            };
            return productsData;
        }
    }
}