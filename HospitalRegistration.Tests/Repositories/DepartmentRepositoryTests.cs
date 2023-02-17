using FluentAssertions;
using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Entities;
using HospitalRegistration.DataAccess.Interfaces;
using HospitalRegistration.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace HospitalRegistration.Tests.Repositories
{
    [TestClass]
    public class DepartmentRepositoryTests
    {
        protected Mock<UnitOfWork> unitOfWorkMock;
        protected Mock<DatabaseContext> databaseContextMock;
        protected DepartmentRepository departmentRepository;
        protected Mock<DbSet<Department>> dbSetMock;
        protected DbContextOptions<DatabaseContext> dbContextoptions;

        public DepartmentRepositoryTests()
        {
            unitOfWorkMock = new Mock<UnitOfWork>();
            databaseContextMock = new Mock<DatabaseContext>();
            departmentRepository = new DepartmentRepository(databaseContextMock.Object);
            dbSetMock = new Mock<DbSet<Department>>();
        }

        private DatabaseContext GetContext()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "HospitalDb").Options;
            return new DatabaseContext(options);
        }

        [TestMethod]
        public async void ItShould_GetDepartmentFromDatabase()
        {
            //Arrange
            var context = GetContext();
            var department = new Department("xxx");
            context.Departments.Add(department);
            context.SaveChanges();
            DepartmentRepository dr = new DepartmentRepository(context);

            //Act
            var result = dr.GetDepartmentAsync(department.Id);

            //Assert
            Assert.AreEqual(department, result);//isidemeti
        }

        [TestMethod]
        public async void ItShould_ReturnAllDoctorsFromDepartment()
        {

            //Arrange
            var context = GetContext();
            var department = new Department("Radiology");
            var doctor1 = new Doctor("Kaulas", "Kauliukas");
            var doctor2 = new Doctor("Puodas", "Puodziunas");
            department.Doctors.Add(doctor1);
            department.Doctors.Add(doctor2);
            context.Departments.Add(department);
            context.SaveChanges();
            DepartmentRepository dr = new DepartmentRepository(context);

            //Act
            var doctors = dr.GetAllDoctorsOfDepartmentAsync(department.Id);

            //Assert
            Assert.AreEqual(doctors.Result, 2);
        }

        [TestMethod]
        public async Task ItShould_ReturnAllPatientsInDepartment()
        {
            //Arrange

            //Act

            //Assert
        }

    } 
}
