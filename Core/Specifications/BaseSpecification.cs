
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
            this.Criteria = Criteria;
        }

        public Expression<Func<T, bool>> Criteria{get;}

        public List<Expression<Func<T, object>>> Inculde {get;} = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy {get;private set;}

        public Expression<Func<T, object>> OrderByDescending {get;private set;}

        protected void AddIncludes(Expression<Func<T, Object>> includeExpression){
            Inculde.Add(includeExpression);
        }
         protected void AddOrderBy(Expression<Func<T, Object>> oderbyByExpression){
            OrderBy = oderbyByExpression;
        }
         protected void AddOrderByDescending(Expression<Func<T, Object>> oderbyByDscExpression){
            OrderByDescending = oderbyByDscExpression;
        }

    }
}