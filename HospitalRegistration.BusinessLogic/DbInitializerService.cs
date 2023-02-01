using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Entities;
using HospitalRegistration.DataAccess.Interfaces;
using HospitalRegistration.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRegistration.BusinessLogic
{
    public class DbInitializerService
    {
        private IUnitOfWork unitOfWork;
        public DbInitializerService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void Initialize(DatabaseContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
            dbContext.Database.EnsureCreated();
            if (dbContext.Illnesses.Any()) return;

            var illnesses = new Illness[]
            {
                new Illness("vejaraupiai")
            };

            foreach (var illness in illnesses)
            {
                dbContext.Illnesses.Add(illness);
            }
            unitOfWork.SaveChanges();      
        }
    }
}
