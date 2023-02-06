namespace HospitalRegistration.DataAccess.Entities
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Doctor> Doctors { get; set; }

        public Department(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Doctors = new List<Doctor>();
        }
    }
}
