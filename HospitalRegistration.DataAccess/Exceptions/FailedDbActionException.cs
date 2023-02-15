namespace HospitalRegistration.DataAccess.Exceptions
{
    public class FailedDbActionException : Exception
    {
        protected string Message { get; }
        public FailedDbActionException(string message) : base(message)
        {
            Message = message;
        }
    }
}
