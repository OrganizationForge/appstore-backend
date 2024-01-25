using Application.Common.Interfaces;
using Application.Common.Wrappers;
using AutoMapper;
using Domain.Entities.Products;
using MediatR;

namespace Application.Features.Products.Queries
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
        //private readonly IDistributedCache _distributedCache;

        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedResponse<List<ProductDTO>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var listAllProducts= await _unitOfWork.Repository<Product>().ListAsync(new ProductSpecification(request.PageSize, request.PageNumber, request.ProductName, request.Description, request.Rating, request.CategoryId));
            var totalRecords = await _unitOfWork.Repository<Product>().CountAsync();
            var result = _mapper.Map<List<ProductDTO>>(listAllProducts);
            return new PagedResponse<List<ProductDTO>>(result, request.PageNumber, request.PageSize, totalRecords);
        }
    }
}
