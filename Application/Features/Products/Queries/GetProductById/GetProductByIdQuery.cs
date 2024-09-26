using Application.Common.Interfaces;
using Application.Common.Wrappers;
using Ardalis.Specification;
using AutoMapper;
using Domain.Entities.Products;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<Response<ProductDTO>>
    {
        public Guid Id { get; set; }
    }

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Response<ProductDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetProductByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Response<ProductDTO>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Repository<Product>().FirstOrDefaultAsync(new ProductByIdSpecification(request.Id), cancellationToken);
            //var product = await _unitOfWork.Repository<Product>().GetByIdAsync(request.Id, cancellationToken);

            if (product == null)
                throw new KeyNotFoundException($"Registro no encontrado con id {request.Id}");
            else
            {
                var result = _mapper.Map<ProductDTO>(product);
                // var baseUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Value}";
                var baseUrl = "http://149.50.144.77:81";

                if (result.ProductFiles != null)
                {
                    foreach (var file in result.ProductFiles!)
                    {
                        file.UrlImage = $"{baseUrl}\\{file.UrlImage}";
                    }
                }


                return new Response<ProductDTO>(result);
            }
        }
    }
}
