using Application.Common.Interfaces;
using Application.Common.Wrappers;
using AutoMapper;
using Domain.Entities.Products;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Products.Commands.CreateProductCommand
{
    public class CreateProductCommand : IRequest<Response<int>>
    {
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public double PriceBase { get; set; }
        public double Price { get; set; }
        public int BrandId { get; set; }
        public int AvailabilityId { get; set; }
        public int CategoryId { get; set; }
        public int? QuantityTypeId { get; set; }
        public string? Warranty { get; set; } = "1 año";
        public int Weight { get; set; }
        public int Review { get; set; } = 0;
        public double Rating { get; set; } = 0;
        public string? BarCode { get; set; }
        public double Stock { get; set; }
        public List<FileUpload>? ProductFiles { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Response<int>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var newProduct = _mapper.Map<Product>(request);

            await _unitOfWork.Repository<Product>().AddAsync(newProduct);

            newProduct.AddDomainEvent(new ProductCreatedEvent(newProduct, request.ImageFiles!));

            await _unitOfWork.Save(cancellationToken);

            return new Response<int>(newProduct.Id);
        }
    }
}
