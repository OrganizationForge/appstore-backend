using Application.Common.Interfaces;
using Application.Common.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Queries
{
    public class GetAllCategoriesQuery : IRequest<Response<List<CategoryDTO>>>{}

    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, Response<List<CategoryDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        //private readonly IDistributedCache _distributedCache;

        public GetAllCategoriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<List<CategoryDTO>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var listCategories = await _unitOfWork.Repository<Category>().ListAsync(new CategorySpecification(),cancellationToken);

            var result = _mapper.Map<List<CategoryDTO>>(listCategories);

            return new Response<List<CategoryDTO>>(result);
        }
    }
}
