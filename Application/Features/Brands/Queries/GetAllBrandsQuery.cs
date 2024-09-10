using Application.Common.Interfaces;
using Application.Common.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Queries
{
    public class GetAllBrandsQuery : IRequest<Response<List<BrandDTO>>> { }

    public class GetAllBrandQueryHandler : IRequestHandler<GetAllBrandsQuery, Response<List<BrandDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        //private readonly IDistributedCache _distributedCache;

        public GetAllBrandQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        async Task<Response<List<BrandDTO>>> IRequestHandler<GetAllBrandsQuery, Response<List<BrandDTO>>>.Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            var listBrands = await _unitOfWork.Repository<Brand>().ListAsync(cancellationToken);

            var result = _mapper.Map<List<BrandDTO>>(listBrands);

            return new Response<List<BrandDTO>>(result);
        }
    }
}
