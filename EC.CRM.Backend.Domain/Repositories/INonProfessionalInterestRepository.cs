using System.Linq.Expressions;
using EC.CRM.Backend.Domain.Entities;

namespace EC.CRM.Backend.Domain.Repositories
{
    public interface INonProfessionalInterestRepository
    {
        Task<List<NonProfessionalInterest>> GetAllAsync(Expression<Func<NonProfessionalInterest, bool>>? predicate = null);
    }
}
