using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specifications
{
    public class ProductFilterPaginatedSpecification : Specification<Product>
    {
        public ProductFilterPaginatedSpecification(int? categoryId, int? brandId, int skip, int take) : base()
        {
            Query.Where(x => (!categoryId.HasValue || x.CategoryId == categoryId) && (!brandId.HasValue || x.BrandId == brandId))
                .Skip(skip).Take(take);


        }
    }
}
