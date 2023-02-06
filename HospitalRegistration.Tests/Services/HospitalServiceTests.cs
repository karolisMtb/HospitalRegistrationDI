using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using HospitalRegistration.BusinessLogic.Services;
using HospitalRegistration.DataAccess.Interfaces;
using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace HospitalRegistration.Tests.Services
{
    public class HospitalServiceTests
    {
        protected Mock<IDepartmentRepository> DepartmentRepositoryMock;
        protected Mock<IUnitOfWork> UnitOfWorkMock;
        protected Mock<DatabaseContext> DatabaseContext;
        protected HospitalService Service;

        [SetUp]
        public void Setup()
        {
            DepartmentRepositoryMock = new Mock<IDepartmentRepository>();
            UnitOfWorkMock = new Mock<IUnitOfWork>();
            DatabaseContext = new Mock<DatabaseContext>();
            Service = new HospitalService(DepartmentRepositoryMock.Object, UnitOfWorkMock.Object, DatabaseContext.Object);
        }

        [Test]
        public void ItShould_AssignSpecialtyToDoctor()
        {
            //Arrange
            var doctor = new Doctor("Gezas", "Gezelis");
            var specialty = new Specialty("Chirurgas");

            UnitOfWorkMock.Setup(x => x.DoctorRepository.GetDoctor(It.IsAny<Doctor>())).Returns(doctor);
            UnitOfWorkMock.Setup(x=> x.SpecialtyRepository.GetSpecialty(It.IsAny<Specialty>())).Returns(specialty);

            //Act
            Service.AsignSpecialtyToDoctor(doctor, specialty);

            //Assert
            doctor.Specialties.Should().HaveCount(1);
            UnitOfWorkMock.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Test]
        public void ItShould_AsignDoctorToDepartment()
        {
            //Arrange
            Doctor doctor = new("Baba", "Usorius");
            Department department = new("Emergency");

            UnitOfWorkMock.Setup(x => x.DoctorRepository.GetDoctor(It.IsAny<Doctor>())).Returns(doctor);
            UnitOfWorkMock.Setup(x => x.DepartmentRepository.GetDepartment(It.IsAny<Department>())).Returns(department);

            //Act
            Service.AsignDoctorToDepartment(doctor, department);

            //Assert
            department.Doctors.Should().HaveCount(1);
            UnitOfWorkMock.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
