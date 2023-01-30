using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalRegistration.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HospitalRegistration.DataAccess.DataContext
{
    public class DatabaseContext : DbContext 
    {
        public AppConfiguration AppConfiguration { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer($@"Data Source = LAZYBASTARD\; Initial Catalog = HospitalDB; Integrated Security = True"); // object not set to instance o.a.o

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DoctorPatient>().HasKey(x => new
            {
                x.PatientId,
                x.DoctorId
            });

            modelBuilder.Entity<Patient>().HasMany(x => x.DoctorPatients).WithOne(x => x.Patient).HasForeignKey(x => x.PatientId);
            modelBuilder.Entity<Doctor>().HasMany(x => x.DoctorPatients).WithOne(x => x.Doctor).HasForeignKey(x => x.DoctorId);
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        //DBsets go here
        public DbSet<Department> Departments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorPatient> DoctorPatients { get; set; }
        public DbSet<Illness> Illnesses { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Specialty> DoctorSpecialties { get; set; }
    }
}
