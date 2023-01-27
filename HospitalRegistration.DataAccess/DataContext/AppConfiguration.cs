using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Configuration;
using HospitalRegistration.DataAccess.Interfaces;

namespace HospitalRegistration.DataAccess.DataContext
{
    public class AppConfiguration : IAppConfiguration
    {
        public string SqlConnectionString { get; set; }
        public AppConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder(); // is used to obtain configuration settings. from json file
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);
            var root = configurationBuilder.Build();
            var appSetting = root.GetSection("ConnectionStrings:DefaultConnection");
            SqlConnectionString = appSetting.Value;
        }

        
    }
}
