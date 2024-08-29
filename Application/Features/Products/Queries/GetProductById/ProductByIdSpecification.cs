using Ardalis.Specification;
using Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.GetProductById
{
    public  class ProductByIdSpecification : Specification<Product>, ISingleResultSpecification<Product>
    {
        public ProductByIdSpecification(int id) {

            Query.Where(p => p.Id == id)
                .Include(p => p.Brand)
                .Include(p => p.ProductFiles);
        }
    }
}
