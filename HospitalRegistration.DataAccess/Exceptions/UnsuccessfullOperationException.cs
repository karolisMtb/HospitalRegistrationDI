using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRegistration.DataAccess.Exceptions
{
    public class UnsuccessfullOperationException : Exception
    {
        protected string Message;

        public UnsuccessfullOperationException(string message)
        {
            Message = message;
        }
    }
}
