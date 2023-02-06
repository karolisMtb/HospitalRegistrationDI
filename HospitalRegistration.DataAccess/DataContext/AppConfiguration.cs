using Microsoft.Extensions.Configuration;
using HospitalRegistration.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace HospitalRegistration.DataAccess.DataContext
{
    public class AppConfiguration : IAppConfiguration
    {
        protected readonly IConfiguration _configuration;

        public AppConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void GetConnection(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(_configuration.GetConnectionString("SQLServer")));
        }
    }
}
