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

        protected Mock<IDoctorRepository> DoctorRepositoryMock;

        public HospitalServiceTests()
        {
            DepartmentRepositoryMock = new Mock<IDepartmentRepository>();
            UnitOfWorkMock = new Mock<IUnitOfWork>();
            DatabaseContextMock = new Mock<DatabaseContext>();
            DoctorRepositoryMock = new Mock<IDoctorRepository>();
            Service = new HospitalService(DepartmentRepositoryMock.Object, UnitOfWorkMock.Object, DoctorRepositoryMock.Object);
            SpecialtyRepositoryMock = new Mock<ISpecialtyRepository>();
        }

        [Test]
        public async Task ItShould_AssignSpecialtyToDoctor()
        {
            //Arrange
            var doctor = new Doctor("Gezas", "Gezelis");
            var specialty = new Specialty("Chirurgas");
            doctor.Specialties.Add(specialty);


            DoctorRepositoryMock.Setup(x => x.GetDoctorAsync(doctor.Id)).ReturnsAsync(doctor);

            //DoctorRepositoryMock.Setup(x => x.GetDoctorAsync(It.IsAny<Doctor>().Id)).ReturnsAsync(doctor);
            //UnitOfWorkMock.Setup(x => x.SpecialtyRepository.GetSpecialtyAsync(It.IsAny<Specialty>().Id)).ReturnsAsync(specialty);

            //Act
            Service.AsignSpecialtyToDoctorAsync(doctor.Id, specialty.Id);

            //Assert
            doctor.Specialties.Should().HaveCount(1);
            UnitOfWorkMock.Verify(x => x.SaveChanges(), Times.Once);
            //verify ar visi repo metodai buvo iskviesti
        }

        [Test]
        public async Task ItShould_AsignDoctorToDepartment()
        {
            ////Arrange
            //Doctor doctor = new("Baba", "Usorius");
            //Department department = new("Emergency");

            //UnitOfWorkMock.Setup(x => x.DepartmentRepository.GetDepartmentAsync(It.IsAny<Department>().Id)).ReturnsAsync(department);
            //UnitOfWorkMock.Setup(x => x.DoctorRepository.GetDoctorAsync(It.IsAny<Doctor>().Id)).ReturnsAsync(doctor);

            ////Act
            //Service.AsignDoctorToDepartmentAsync(doctor.Id, department.Id);

            ////Assert
            //department.Doctors.Should().HaveCount(1);
            //UnitOfWorkMock.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Test]
        public async Task ItShould_RegisterNewDoctor()
        {
            //Arrange
            Doctor doctor = new("Pieras", "Pieriokas");

            //Act
            await Service.RegisterNewDoctorAsync(doctor.Name, doctor.LastName);

            //Assert
            UnitOfWorkMock.Verify(x => x.AddToDoctorRepository(It.IsAny<Doctor>()), Times.Once());
            UnitOfWorkMock.Verify(x => x.SaveChanges(), Times.Once());
        }
    }
}
