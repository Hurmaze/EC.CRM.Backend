using EC.CRM.Backend.Domain.Repositories.Specifications;
using Microsoft.EntityFrameworkCore;

namespace EC.CRM.Backend.Persistence
{
    public static class SpecificationEvaluator
    {
        public static IQueryable<T> GetQuery<T>(
            IQueryable<T> inputQuery,
            Specification<T> specification) where T : class
        {
            if (specification.IsSplitQuery)
            {
                inputQuery = inputQuery.AsSplitQuery();
            }

            if (specification.Criteria is not null)
            {
                inputQuery = inputQuery.Where(specification.Criteria);
            }

            if (specification.OrderByExpression is not null)
            {
                inputQuery = inputQuery.OrderBy(specification.OrderByExpression);
            }

            if (specification.OrderByDescExpression is not null)
            {
                inputQuery = inputQuery.OrderByDescending(specification.OrderByDescExpression);
            }

            if (specification.IncludeExpressions.Count > 0)
            {
                inputQuery = specification.IncludeExpressions
                    .Aggregate(inputQuery, (current, include) => current.Include(include));
            }

            return inputQuery;
        }
    }
}
