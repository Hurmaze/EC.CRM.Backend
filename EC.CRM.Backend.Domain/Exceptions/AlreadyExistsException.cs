namespace EC.CRM.Backend.Domain.Exceptions
{
    public class AlreadyExistsException : ApplicationException
    {
        public AlreadyExistsException(string uniqueValue)
            : base(String.Format("Entity with {requestedUid} already exists.", uniqueValue))
        {

        }
    }
}

