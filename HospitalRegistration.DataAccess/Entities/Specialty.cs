using System.Text.Json.Serialization;

namespace HospitalRegistration.DataAccess.Entities
{
    public class Specialty
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Doctor> Doctors { get; set; }

        public Specialty(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Doctors = new List<Doctor>();
        }
    }
}
