using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T,bool>> criteria{get;}
        List<Expression<Func<T,Object>>> Inculde{get;}
        
    }
}