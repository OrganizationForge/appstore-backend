using Application.Common.Interfaces;
using Application.Common.Wrappers;
using AutoMapper;
using Domain.Entities.Library;
using MediatR;

namespace Application.Features.Language.Queries.GetAllLanguages
{
    public class GetAllIdiomsQuery : IRequest<PagedResponse<List<IdiomDTO>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
    }

    public class GetAllIdiomsQueryHandler : IRequestHandler<GetAllIdiomsQuery, PagedResponse<List<IdiomDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        //private readonly IDistributedCache _distributedCache;

        public GetAllIdiomsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedResponse<List<IdiomDTO>>> Handle(GetAllIdiomsQuery request, CancellationToken cancellationToken)
        {
            var listAllIdioms = await _unitOfWork.Repository<Idiom>().ListAsync(new IdiomSpecification(request.PageSize, request.PageNumber, request.Code, request.Description));

            var result = _mapper.Map<List<IdiomDTO>>(listAllIdioms);
            var totalRecords = await _unitOfWork.Repository<Idiom>().CountAsync();
            return new PagedResponse<List<IdiomDTO>>(result, request.PageNumber, request.PageSize, totalRecords);
        }
    }
}
