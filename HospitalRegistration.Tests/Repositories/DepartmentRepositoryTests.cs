using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Entities;
using HospitalRegistration.DataAccess.Interfaces;
using HospitalRegistration.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;

namespace HospitalRegistration.Tests.Repositories
{
    [TestClass]
    public class DepartmentRepositoryTests
    {
        protected Mock<IUnitOfWork> unitOfWorkMock;
        protected Mock<DatabaseContext> databaseContextMock;
        protected DepartmentRepository departmentRepository;
        protected Mock<DbSet<Department>> dbSetMock;
        protected DbContextOptions<DatabaseContext> dbContextoptions;

        [SetUp]
        public void SetUp()
        {
            unitOfWorkMock = new Mock<IUnitOfWork>();
            databaseContextMock = new Mock<DatabaseContext>();
            departmentRepository = new DepartmentRepository(databaseContextMock.Object);
            dbSetMock = new Mock<DbSet<Department>>();
        }

        [TestMethod]
        public void ItShould_GetDepartmentFromDatabase()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "HospitalDb").Options;
            var context = new DatabaseContext(options);
            var department = new Department("xxx");
            context.Departments.Add(department);
            context.SaveChanges();
            DepartmentRepository dr = new DepartmentRepository(context);

            //Act
            var result = dr.GetDepartment(department);

            //Assert
            department.Equals(result);
        }

        [TestMethod]
        public void ItShould_ReturnAllDoctorsFromDepartment()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "HospitalDb").Options;
            var context = new DatabaseContext(options);
            var department = new Department("Radiology");
            var doctor1 = new Doctor("Kaulas", "Kauliukas");
            var doctor2 = new Doctor("Puodas", "Puodziunas");
            department.Doctors.Add(doctor1);
            department.Doctors.Add(doctor2);
            context.Departments.Add(department);
            context.SaveChanges();
            DepartmentRepository dr = new DepartmentRepository(context);

            //Act
            var doctors = dr.GetAllDoctorsOfDepartment(department);

            //Assert
            doctors.Count().Equals(2);
        }

        [TestMethod]
        public void ItShould_ReturnAllPatientsInDepartment()
        {

        }

    } 
}
