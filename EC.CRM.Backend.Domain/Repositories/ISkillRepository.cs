using System.Linq.Expressions;
using EC.CRM.Backend.Domain.Entities;

namespace EC.CRM.Backend.Domain.Repositories
{
    public interface ISkillRepository
    {
        Task<List<Skill>> GetAllAsync(Expression<Func<Skill, bool>>? predicate = null);
    }
}
