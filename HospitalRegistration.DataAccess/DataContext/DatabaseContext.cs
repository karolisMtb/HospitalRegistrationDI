using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalRegistration.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalRegistration.DataAccess.DataContext
{
    public class DatabaseContext : DbContext
    {
        private AppConfiguration _settings { get; set; } // connection string obtained
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(_settings.SqlConnectionString);

        public DatabaseContext(AppConfiguration settings)
        {
            _settings = settings;
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        //DBsets go here
        public DbSet<Department> Departments { get; set; } 
    }
}
