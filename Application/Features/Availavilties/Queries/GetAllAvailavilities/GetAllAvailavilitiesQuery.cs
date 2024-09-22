using Application.Common.Interfaces;
using Application.Common.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Availavilities.Queries.GetAllAvailavilities
{
    public class GetAllAvailavilitiesQuery : IRequest<Response<List<AvailavilityDTO>>> { }
    public class GetAllAvailavilitiesQueryHandler : IRequestHandler<GetAllAvailavilitiesQuery, Response<List<AvailavilityDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        //private readonly IDistributedCache _distributedCache;

        public GetAllAvailavilitiesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<List<AvailavilityDTO>>> Handle(GetAllAvailavilitiesQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork.Repository<Availability>().ListAsync(cancellationToken);

            var result = _mapper.Map<List<AvailavilityDTO>>(list);

            return new Response<List<AvailavilityDTO>>(result);
        }
    }
}
