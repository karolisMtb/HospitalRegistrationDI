using System.Text.Json.Serialization;

namespace HospitalRegistration.DataAccess.Entities
{
    public class Doctor
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        [JsonIgnore]
        public Guid? DepartmentId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public ICollection<Specialty> Specialties { get; set; }

        public ICollection<DoctorPatient> DoctorPatients { get; set; }

        public Doctor(string name, string lastName)
        {
            Id = Guid.NewGuid();
            Name = name;
            LastName = lastName;
            Specialties = new List<Specialty>();
            DoctorPatients = new List<DoctorPatient>();
        }
    }
}
