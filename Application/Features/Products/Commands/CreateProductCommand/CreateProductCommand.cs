using Application.Common.Interfaces;
using Application.Common.Wrappers;
using Application.DTOs;
using AutoMapper;
using Domain.Entities.Products;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Products.Commands.CreateProductCommand
{
    public class CreateProductCommand : IRequest<Response<Guid>>
    {
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public double PriceBase { get; set; }
        public double Price { get; set; }
        public Guid BrandId { get; set; }
        public Guid AvailabilityId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid QuantityTypeId { get; set; }
        public string? Warranty { get; set; } = "1 año";
        public int Weight { get; set; }
        public int Review { get; set; } = 0;
        public double Rating { get; set; } = 0;
        public string? BarCode { get; set; }
        public double Stock { get; set; }
        public List<FileUpload>? ProductFiles { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Response<Guid>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _fileService = fileService;
        }

        public async Task<Response<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var newProduct = _mapper.Map<Product>(request);

            await _unitOfWork.Repository<Product>().AddAsync(newProduct);

            List<ProductFile> productFiles = new List<ProductFile>();

            foreach (var file in request.ProductFiles!)
            {
                var newFile = new ProductFile
                {
                    NameImage = file.Name,
                    UrlImage = _fileService.UploadFile(file,newProduct.Id.ToString()),
                    // UrlImage = _fileService.UploadFile(file, @"Images\" + newProduct.Id),
                    ProductId = newProduct.Id
                };

                await _unitOfWork.Repository<ProductFile>().AddAsync(newFile);
            }

            //newProduct.AddDomainEvent(new ProductCreatedEvent(newProduct, request.ProductFiles!));

            await _unitOfWork.Save(cancellationToken);

            return new Response<Guid>(newProduct.Id);
        }
    }
}
