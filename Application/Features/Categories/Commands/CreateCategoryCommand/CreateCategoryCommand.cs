using Application.Common.Interfaces;
using Application.Common.Wrappers;
using Application.Features.Orders.Commands.CreateOrderCommand;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Checkout;
using MediatR;

namespace Application.Features.Categories.Commands.CreateCategoryCommand
{
    public class CreateCategoryCommand : IRequest<Response<Guid>>
    {
        public string? Description { get; set; }
        public string? UrlImage { get; set; }
        public Guid? ParentId { get; set; }
    }
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Response<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Response<Guid>> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            var newCategory = _mapper.Map<Category>(command);

            newCategory.CreatedBy = _currentUserService.User.Id;

            await _unitOfWork.Repository<Category>().AddAsync(newCategory);

            newCategory.AddDomainEvent(new CategoryCreateEvent(newCategory));

            await _unitOfWork.Save(cancellationToken);

            return new Response<Guid>(newCategory.Id);

        }
    }
}

