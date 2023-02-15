using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRegistration.DataAccess.Exceptions
{
    public class ObjectNotFoundException : Exception
    {
        protected string Message;
        public ObjectNotFoundException(string message) : base(message)
        {
            Message = message;
        }
    }
}
