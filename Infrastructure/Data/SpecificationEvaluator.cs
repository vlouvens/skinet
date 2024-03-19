
using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,
         ISpecification<TEntity> spec){
            var query = inputQuery;
            if(spec.criteria != null){
                query= query.Where(spec.criteria);
            }
            query = spec.Inculde.Aggregate(query,(current,include)=>current.Include(include));
            return query;
        }
    }
}