namespace EC.CRM.Backend.Domain.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string enitityName, object requestedPropertyValue)
            : base(String.Format("{0} with uid {1} does not exist.", enitityName, requestedPropertyValue))
        {
        }
    }
}
