using Application.Common.Interfaces;
using Application.Common.Wrappers;
using Application.Features.Language.Commands.CreateLanguageCommand;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Library;
using MediatR;

namespace Application.Features.Brands.Commands.CreateBrandCommand
{
    public class CreateBrandCommand : IRequest<Response<int>>
    {
        public string? Description { get; set; }
    }

    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, Response<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBrandCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateBrandCommand command, CancellationToken cancellationToken)
        {
            var newBrand = _mapper.Map<Brand>(command);

            await _unitOfWork.Repository<Brand>().AddAsync(newBrand);

            newBrand.AddDomainEvent(new BrandCreateEvent(newBrand));

            await _unitOfWork.Save(cancellationToken);

            return new Response<int>(newBrand.Id);
        }
    }

}
