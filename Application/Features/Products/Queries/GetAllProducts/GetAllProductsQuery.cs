using Application.Common.Interfaces;
using Application.Common.Wrappers;
using AutoMapper;
using Domain.Entities.Products;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery : PaginationProductParameters, IRequest<PagedResponse<List<ProductDTO>>>
    {
        //public int PageNumber { get; set; }
        //public int PageSize { get; set; }
        //public string? ProductName { get; set; }
        //public string? Description { get; set; }
        //public double? Rating { get; set; }
        //public int? CategoryId { get; set; }
    }

    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, PagedResponse<List<ProductDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        //private readonly IDistributedCache _distributedCache;

        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<PagedResponse<List<ProductDTO>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var listAllProducts = await _unitOfWork.Repository<Product>().ListAsync(new ProductSpecification(request));
            var totalRecords = await _unitOfWork.Repository<Product>().CountAsync();
            var result = _mapper.Map<List<ProductDTO>>(listAllProducts);

            var baseUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Value}";

            // Agregar la URL base a cada imagen
            foreach (var product in result)
            {
                if (product.ProductFiles != null)
                {
                    foreach (var file in product.ProductFiles)
                    {
                        file.UrlImage = $"{baseUrl}\\{file.UrlImage}";
                    }
                }
            }


            return new PagedResponse<List<ProductDTO>>(result, request.PageNumber, request.PageSize, totalRecords);
        }
    }
}
