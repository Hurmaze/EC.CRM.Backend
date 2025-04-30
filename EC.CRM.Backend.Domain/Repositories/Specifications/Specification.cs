using System.Linq.Expressions;

namespace EC.CRM.Backend.Domain.Repositories.Specifications
{
    public abstract class Specification<T>
    {
        public Expression<Func<T, bool>>? Criteria { get; private set; }
        public List<Expression<Func<T, object>>> IncludeExpressions { get; private set; } = new();
        public Expression<Func<T, object>>? OrderByExpression { get; private set; }
        public Expression<Func<T, object>>? OrderByDescExpression { get; private set; }
        public bool IsSplitQuery { get; protected set; }
        protected Specification(Expression<Func<T, bool>> criteria) => Criteria = criteria;
        protected Specification() { }

        protected Specification<T> AddCriteria(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
            return this;
        }

        public Specification<T> Include(Expression<Func<T, object>> includeExpression)
        {
            IncludeExpressions.Add(includeExpression);
            return this;
        }

        public Specification<T> OrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderByExpression = orderByExpression;
            return this;
        }

        public Specification<T> OrderByDescending(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDescExpression = orderByDescExpression;
            return this;
        }
    }
}
