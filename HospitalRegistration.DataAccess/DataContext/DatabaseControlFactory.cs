using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace HospitalRegistration.DataAccess.DataContext
{
    public class DatabaseControlFactory : IDesignTimeDbContextFactory<DatabaseContext> // client
    {

        public DatabaseContext CreateDbContext(string[] args) // client using AppConfiguration ir new DbContextOptionsBuilder<DatabaseContext>();
        {
            AppConfiguration appConfiguration = new AppConfiguration();
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseSqlServer(appConfiguration.SqlConnectionString);
            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}
