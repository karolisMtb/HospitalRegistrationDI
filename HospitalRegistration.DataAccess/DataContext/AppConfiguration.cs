﻿using System;
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
        protected readonly IConfiguration _configuration;
        public string SqlConnectionString { get; set; }

        public AppConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection() // pridejau
        {
            SqlConnectionString = _configuration.GetConnectionString("DefaultConnection");
            return SqlConnectionString;
        }
    }
}
