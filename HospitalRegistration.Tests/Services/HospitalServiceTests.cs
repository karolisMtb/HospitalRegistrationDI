using NUnit.Framework;
using Moq;
using HospitalRegistration.BusinessLogic.Services;
using HospitalRegistration.DataAccess.Interfaces;
using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Entities;
using FluentAssertions;
using System.Runtime.CompilerServices;
using HospitalRegistration.DataAccess.Exceptions;
using HospitalRegistration.DataAccess.Repositories;

namespace HospitalRegistration.Tests.Services
{
    public class HospitalServiceTests
    {
        protected Mock<IDepartmentRepository> DepartmentRepositoryMock;
        protected Mock<IUnitOfWork> UnitOfWorkMock;
        protected Mock<DatabaseContext> DatabaseContextMock;
        protected HospitalService Service;
        protected Mock<ISpecialtyRepository> SpecialtyRepositoryMock;
        protected Mock<IPatientRepository> PatientRepositoryMock;
        protected Mock<IDoctorPatientRepository> DoctorPatientRepositoryMock;
        protected Mock<IDoctorRepository> DoctorRepositoryMock;

        public HospitalServiceTests()
        {
            DepartmentRepositoryMock = new Mock<IDepartmentRepository>();
            UnitOfWorkMock = new Mock<IUnitOfWork>();
            DatabaseContextMock = new Mock<DatabaseContext>();
            DoctorRepositoryMock = new Mock<IDoctorRepository>();
            SpecialtyRepositoryMock = new Mock<ISpecialtyRepository>();
            PatientRepositoryMock = new Mock<IPatientRepository>();
            DoctorPatientRepositoryMock = new Mock<IDoctorPatientRepository>();

            Service = new HospitalService(
                DepartmentRepositoryMock.Object, 
                UnitOfWorkMock.Object, 
                DoctorRepositoryMock.Object, 
                PatientRepositoryMock.Object, 
                SpecialtyRepositoryMock.Object, 
                DoctorPatientRepositoryMock.Object);
        }

        [Test]
        public async Task ItShould_AssignSpecialtyToDoctor()
        {
            //Arrange
            var doctor = new Doctor("Gezas", "Gezelis");
            var specialty = new Specialty("Chirurgas");
            doctor.Specialties.Add(specialty);

            //Act
            Service.AsignSpecialtyToDoctorAsync(doctor.Id, specialty.Id);

            //Assert
            doctor.Specialties.Should().HaveCount(1);
            UnitOfWorkMock.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Test]
        public async Task ItShould_AsignDoctorToDepartment()
        {
            //Arrange
            Doctor doctor = new("Baba", "Usorius");
            Department department = new("Emergency");
            DepartmentRepositoryMock.Setup(x => x.GetDepartmentAsync(department.Id)).ReturnsAsync(department);
            DoctorRepositoryMock.Setup(x => x.GetDoctorAsync(doctor.Id)).ReturnsAsync(doctor);

            //Act
            Service.AsignDoctorToDepartmentAsync(doctor.Id, department.Id);

            //Assert
            department.Doctors.Should().HaveCount(1);
            UnitOfWorkMock.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Test]
        public async Task ItShould_RegisterNewDoctor()
        {
            //Arrange
            Doctor doctor = new("Pieras", "Pieriokas");

            //Act
            await Service.RegisterNewDoctorAsync(doctor.Name, doctor.LastName);

            //Assert
            UnitOfWorkMock.Verify(x => x.SaveChanges(), Times.Once());
        }

        [Test]
        public async Task CheckPatientSignedOut_DischargePatient_PatientSignedOut_IllnessesNull()
        {
            //Arrange
            Patient patient = new Patient("Gezas", "Gezelis", new DateTime(1999, 05, 10));
            patient.SignedIn = new DateTime(2023, 02, 03, 16, 33, 42);

            Illness illness = new("Headache");
            PatientIllness patientIllness = new();

            patientIllness.Patient = patient;
            patientIllness.Illness = illness;

            PatientRepositoryMock.Setup(x => x.GetPatientAsync(patient.Id)).ReturnsAsync(patient);
            PatientRepositoryMock.Setup(x => x.DischargeAsync(patient.Id));

            //Act
            await Service.DischargePatientAsync(patient.Id);

            //Assert
            PatientRepositoryMock.Verify(x => x.DischargeAsync(patient.Id), Times.Once());
            UnitOfWorkMock.Verify(x => x.SaveChanges(), Times.Once());
        }

        [Test]
        public async Task ItShould_RegisterNewPatient_ReturnsIfSuccessfull()
        {
            //Arrange
            Patient patient = new Patient("Gezas", "Gezelis", new DateTime(1999, 05, 10));

            //Act


            //Assert
        }
    }
}
