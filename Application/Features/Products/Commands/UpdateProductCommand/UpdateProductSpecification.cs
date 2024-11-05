using Ardalis.Specification;
using Domain.Entities.Checkout;
using Domain.Entities.Products;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.UpdateProductCommand
{
    public class UpdateProductSpecification : Specification<Product>, ISingleResultSpecification<Product>
    {
        public UpdateProductSpecification(Guid id)
        {

            Query.Where(p => p.Id == id);
        }
    }
}
