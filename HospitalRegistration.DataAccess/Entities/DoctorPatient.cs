namespace HospitalRegistration.DataAccess.Entities
{
    public class DoctorPatient
    {
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public int Count { get; set; }
    }
}
