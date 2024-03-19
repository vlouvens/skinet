
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
            
        }
        public BaseSpecification(Expression<Func<T, bool>> Criteria)
        {
            criteria = Criteria;
        }

        public Expression<Func<T, bool>> criteria{get;}

        public List<Expression<Func<T, object>>> Inculde {get;} = new List<Expression<Func<T, object>>>();

        protected void AddIncludes(Expression<Func<T, Object>> includeExpression){
            Inculde.Add(includeExpression);
        }

    }
}