using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRegistration.DataAccess.Exceptions
{
    public class FailedDbActionException : Exception
    {
        public string Message { get; }
        public FailedDbActionException(string Message) : base(Message)
        {
            this.Message = Message;
        }
    }
}
