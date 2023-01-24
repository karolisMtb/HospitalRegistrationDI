using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HospitalRegistration.DataAccess.DataContext
{
    public class DatabaseContext : DbContext
    {
        public class OptionsBuild // allows to initiate database connection along with its entities
        {

            public static OptionsBuild options = new OptionsBuild();
            public OptionsBuild() // sitas metodas depends on new AppConfiguration(); ir new DbContextOptionsBuilder<DatabaseContext>();
            {
                settings = new AppConfiguration();
                optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
                optionsBuilder.UseSqlServer(settings.SqlConnectionString);
                dbOptions = optionsBuilder.Options;
            }

            public DbContextOptionsBuilder<DatabaseContext> optionsBuilder { get; set; } // this is api that allows us to configure the connection to our database
            public DbContextOptions<DatabaseContext> dbOptions { get; set; } // this allows us obtain and hold db configuration information
            private AppConfiguration settings { get; set; } // obtains a connection string from json file
        }


        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
    }
}
