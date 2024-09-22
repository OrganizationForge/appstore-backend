using Application.Common.Interfaces;
using Application.Common.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.QuantityTypes.Queries.GetAllQuentityTypes
{
    public class GetAllQuentityTypesQuery : IRequest<Response<List<QuantityTypeDTO>>> { }

    public class GetAllQuentityTypesQueryHandler : IRequestHandler<GetAllQuentityTypesQuery, Response<List<QuantityTypeDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        //private readonly IDistributedCache _distributedCache;

        public GetAllQuentityTypesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<List<QuantityTypeDTO>>> Handle(GetAllQuentityTypesQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork.Repository<QuantityType>().ListAsync(cancellationToken);

            var result = _mapper.Map<List<QuantityTypeDTO>>(list);

            return new Response<List<QuantityTypeDTO>>(result);
        }
    }
}
