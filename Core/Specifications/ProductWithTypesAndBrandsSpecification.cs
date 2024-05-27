using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithTypesAndBrandsSpecification : BaseSpecification<Products>
    {

        public ProductWithTypesAndBrandsSpecification(string sort)
        {
            AddIncludes(x => x.ProductType);
            AddIncludes(x => x.ProductBrand);
            AddOrderBy(x => x.Name);
            if(!string.IsNullOrEmpty(sort))
            {
                switch(sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default :
                        AddOrderBy(n => n.Name);
                        break;
                }

            }
        }
        public ProductWithTypesAndBrandsSpecification(int id):base( x => x.Id == id)
        {
            AddIncludes(x => x.ProductType);
            AddIncludes(x => x.ProductBrand);
        }
    }
}