using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRegistration.DataAccess.Entities
{
    public class Illness
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Patient> Patients { get; set; }

        public Illness(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Patients = new List<Patient>();
        }
    }
}
