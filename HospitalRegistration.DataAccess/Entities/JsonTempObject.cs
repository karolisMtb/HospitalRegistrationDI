using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRegistration.DataAccess.Entities
{
    public class JsonTempObject<T> where T : class
    {
        public List<T> Objects { get; set; }
        public int Count { get; set; }
    }
}
