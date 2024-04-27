namespace EC.CRM.Backend.Application.Exceptions
{
    public class WrongPasswordException : ApplicationException
    {
        public WrongPasswordException() : base("Inputed password did not match with existing.") { }
    }
}
