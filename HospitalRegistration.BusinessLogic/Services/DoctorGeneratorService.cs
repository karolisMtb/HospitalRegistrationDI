using HospitalRegistration.DataAccess.Entities;
using HospitalRegistration.DataAccess.Interfaces;
using Newtonsoft.Json;

namespace HospitalRegistration.BusinessLogic.Services
{
    public class DoctorGeneratorService : IGeneratorService<Doctor>
    {
        public List<Doctor> Doctors { get; set; }
        public JsonTempObject<Doctor> JsonDoctorsObject { get; private set; }
        public DoctorGeneratorService(JsonTempObject<Doctor> jsonDoctorsObject)
        {
            JsonDoctorsObject = jsonDoctorsObject;
        }
        public List<Doctor> Generate()
        {
            Doctors = new List<Doctor>();
            string path = "C:\\Users\\Karolis\\source\\repos\\HospitalRegistrationApp\\HospitalRegistration.DataAccess\\Files\\Doctors.json";
            JsonTempObject<Doctor> JsonDoctors = JsonConvert.DeserializeObject<JsonTempObject<Doctor>>(path);
            Doctors = JsonDoctors.Objects;
            return Doctors;
        }
    }
}
