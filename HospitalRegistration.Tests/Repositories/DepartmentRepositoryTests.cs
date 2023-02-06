using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Entities;
using HospitalRegistration.DataAccess.Interfaces;
using HospitalRegistration.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Rest.ClientRuntime.Azure.Authentication.Utilities;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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


        private DatabaseContext GetInMemoryMockDB()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "InMEmoryDB")
                .Options;

            var dbContextoptions = new DatabaseContext(options);
            dbContextoptions.Database.EnsureCreated();
            dbContextoptions.Departments.Add(new("Priimamasis"));
            return dbContextoptions;
        }



        [SetUp]
        public void SetUp()
        {
            unitOfWorkMock = new Mock<IUnitOfWork>();
            databaseContextMock = new Mock<DatabaseContext>();
            departmentRepository = new DepartmentRepository(databaseContextMock.Object);
            dbSetMock = new Mock<DbSet<Department>>();
            dbContextoptions = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "HospitalDb").Options;
        }

        [TestMethod]
        public void ItShould_GetDepartmentFromDatabase()
        {
            //Arrange
            var context = new DatabaseContext(dbContextoptions);
            var department = new Department("xxx");
            context.Departments.Add(department);
            context.SaveChanges();
            DepartmentRepository dr = new DepartmentRepository(context);

            //Act
            var result = dr.GetDepartment(department);

            //Assert
            department.Equals(result);
        }
    } 
}
