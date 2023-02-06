using HospitalRegistration.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalRegistration.DataAccess.DataContext
{
    public class DatabaseContext : DbContext 
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorPatient> DoctorPatients { get; set; }
        public DbSet<Illness> Illnesses { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Specialty> DoctorSpecialties { get; set; }
        public DbSet<PatientIllness> PatientIllnesses { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DoctorPatient>().HasKey(x => new
            {
                x.PatientId,
                x.DoctorId
            });

            modelBuilder.Entity<Patient>()
                .HasMany(x => x.DoctorPatients)
                .WithOne(x => x.Patient)
                .HasForeignKey(x => x.PatientId);

            modelBuilder.Entity<Doctor>()
                .HasMany(x => x.DoctorPatients)
                .WithOne(x => x.Doctor)
                .HasForeignKey(x => x.DoctorId);

            modelBuilder.Entity<PatientIllness>().HasKey(x => new
            {
                x.PatientId,
                x.IlnessId
            });

            modelBuilder.Entity<Patient>()
                .HasMany(x => x.PatientIllnesses)
                .WithOne(x => x.Patient)
                .HasForeignKey(x => x.PatientId);

            modelBuilder.Entity<Illness>()
                .HasMany(x => x.PatientIllnesses)
                .WithOne(x => x.Illness)
                .HasForeignKey(x => x.IlnessId);
        }
    }
}
