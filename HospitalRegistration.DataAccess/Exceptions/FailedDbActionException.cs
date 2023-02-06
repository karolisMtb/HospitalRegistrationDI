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
