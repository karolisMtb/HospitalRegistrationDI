using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRegistration.DataAccess.Entities
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime SignedIn { get; set; }
        public DateTime? SignedOut { get; set; }
        public ICollection<DoctorPatient> DoctorPatients { get; set; }
        public Illness Illness { get; set; }

        public Patient(string name, string lastName, DateTime dateOfBirth)
        {
            Id = Guid.NewGuid();
            Name = name;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            SignedIn = DateTime.Now;
            DoctorPatients = new List<DoctorPatient>();
        }
    }
}
