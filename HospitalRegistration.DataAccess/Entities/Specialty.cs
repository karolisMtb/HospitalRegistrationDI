using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRegistration.DataAccess.Entities
{
    public class Specialty
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Doctor> Doctors { get; set; }

        public Specialty(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
