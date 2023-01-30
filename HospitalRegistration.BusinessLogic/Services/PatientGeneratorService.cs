using HospitalRegistration.DataAccess.Entities;
using HospitalRegistration.DataAccess.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HospitalRegistration.BusinessLogic.Services
{
    public class PatientGeneratorService : IGeneratorService<Patient>
    {
        public JsonTempObject<Patient> JsonPatientObjects { get; private set; }
        public List<Patient> Patients { get; private set; }
        public PatientGeneratorService(JsonTempObject<Patient> JsonPatientObjects)
        {
           this.JsonPatientObjects = JsonPatientObjects;
            Patients = new List<Patient>();
        }

        public List<Patient> Generate()
        {
            //TODO perkelti i appsettings.json
            string path = "C:\\Users\\Karolis\\source\\repos\\HospitalRegistrationApp\\HospitalRegistration.DataAccess\\Files\\Patients.json";
            JsonTempObject<Patient> JsonPatients = JsonConvert.DeserializeObject<JsonTempObject<Patient>>(path);
            Patients = JsonPatients.Objects;
            return Patients;
        }
    }
}
