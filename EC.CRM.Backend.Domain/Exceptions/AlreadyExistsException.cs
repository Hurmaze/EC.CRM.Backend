namespace EC.CRM.Backend.Domain.Exceptions
{
    public class AlreadyExistsException : ApplicationException
    {
        public AlreadyExistsException(string entityName, string uniqueValue)
            : base(String.Format("{0} with {1} already exists.", entityName, uniqueValue))
        {

        }
    }
}

