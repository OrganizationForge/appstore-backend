using Application.Common.Interfaces;
using Application.Common.Wrappers;
using Application.Features.Orders;
using Application.Features.Orders.Commands.UpdateOrderCommand;
using Application.Features.Orders.Queries.GetOrderById;
using Application.Features.Products.Queries.GetProductById;
using Application.Features.Shipping.Queries;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Checkout;
using Domain.Entities.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.UpdateProductCommand
{
    public class UpdateProductCommand : IRequest<Response<string>>
    {
        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public decimal PriceBase { get; set; }
        public decimal Price { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? BrandId { get; set; }
        public Guid? AvailabilityId { get; set; }
        public Guid? QuantityTypeId { get; set; }
        public string? Warranty { get; set; }
        public int? Weight { get; set; }
        public string? BarCode { get; set; }
        public decimal Stock { get; set; }

    }
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Response<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Response<string>> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            DateTime fechaActual = DateTime.Now;


            var product = await _unitOfWork.Repository<Product>().FirstOrDefaultAsync(new UpdateProductSpecification(command.ProductId), cancellationToken);

            if (product is null) {

                return new Response<string>("Producto no encontrado");
            }

            //_mapper.Map<Product>(command);

            _mapper.Map(command, product);

            product.ModifiedBy = _currentUserService.User.Id; 
            product.ModifiedDate = fechaActual;


            await _unitOfWork.Repository<Product>().UpdateAsync(product!);
            await _unitOfWork.Repository<Product>().SaveChangesAsync(cancellationToken);



            return new Response<string>("Successfully updated");
        }

    }
}