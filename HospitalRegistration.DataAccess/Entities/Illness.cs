using System.Text.Json.Serialization;

namespace HospitalRegistration.DataAccess.Entities
{
    public class Illness
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<PatientIllness> PatientIllnesses { get; set; }

        public Illness(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            PatientIllnesses = new List<PatientIllness>();
        }
    }
}
