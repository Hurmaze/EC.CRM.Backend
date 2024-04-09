namespace EC.CRM.Backend.Application.Services.Interfaces
{
    public interface ICriteriaService
    {
        Task RegisterCriteriasAsync(int criteriasCount, Stream criteriasStream);
    }
}
