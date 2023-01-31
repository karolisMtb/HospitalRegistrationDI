using System.Text.Json.Serialization;

namespace HospitalRegistration.DataAccess.Entities
{
    public class Patient
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [JsonIgnore]
        public DateTime SignedIn { get; set; }
        [JsonIgnore]
        public DateTime? SignedOut { get; set; }
        public ICollection<DoctorPatient> DoctorPatients { get; set; }
        public ICollection<PatientIllness> PatientIllnesses { get; set; }

        public Patient(string name, string lastName, DateTime dateOfBirth)
        {
            Id = Guid.NewGuid();
            Name = name;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            SignedIn = DateTime.Now;
            DoctorPatients = new List<DoctorPatient>();
            PatientIllnesses = new List<PatientIllness>();
        }
    }
}
