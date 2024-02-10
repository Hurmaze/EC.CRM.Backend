namespace EC.CRM.Backend.Domain.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(Guid requestedUid)
            : base(String.Format("Entity with uid {0} does not exist.", requestedUid))
        {
        }
    }
}
