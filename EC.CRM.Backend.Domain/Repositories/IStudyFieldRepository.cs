using System.Linq.Expressions;
using EC.CRM.Backend.Domain.Entities;

namespace EC.CRM.Backend.Domain.Repositories
{
    public interface IStudyFieldRepository
    {
        Task<List<StudyField>> GetAllAsync(Expression<Func<StudyField, bool>>? predicate = null);
    }
}
