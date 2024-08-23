using Application.Common.Interfaces;
using Application.Common.Wrappers;
using Ardalis.Specification;
using AutoMapper;
using Domain.Entities.Products;
using MediatR;

namespace Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<Response<ProductDTO>>
    {
        public int Id { get; set; }
    }

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Response<ProductDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
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
                return new Response<ProductDTO>(result);
            }
        }
    }
}
