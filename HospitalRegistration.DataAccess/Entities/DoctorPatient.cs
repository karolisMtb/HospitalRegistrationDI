﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRegistration.DataAccess.Entities
{
    public class DoctorPatient
    {
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
    }
}
