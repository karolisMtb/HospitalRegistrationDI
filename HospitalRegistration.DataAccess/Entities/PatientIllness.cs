using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRegistration.DataAccess.Entities
{
    public class PatientIllness
    {
        public Guid PatientId { get; set; }
        public Guid IlnessId { get; set; }
        public Patient Patient { get; set; }
        public Illness Illness { get; set; }
        public int Count { get; set; }

    }
}
