using Application.Common.Interfaces;
using Application.Common.Wrappers;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Products;
using MediatR;

namespace Application.Features.Categories.Commands.DeleteCategoryByIdCommand
{
    public class DeleteCategoryByIdCommand : IRequest<Response<string>>
    {
        public Guid Id { get; set; }
    }

    public class DeleteCategoryByIdCommandHandler : IRequestHandler<DeleteCategoryByIdCommand, Response<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public DeleteCategoryByIdCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Response<string>> Handle(DeleteCategoryByIdCommand command, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.Repository<Category>().GetByIdAsync(command.Id); 

            if (category is null)
            {
                return new Response<string>("Categoria no encontrada.");
            }



           // category.DeletedBy = _currentUserService.User.Id;

            await _unitOfWork.Repository<Category>().DeleteAsync(category);


            await _unitOfWork.Save(cancellationToken);

            return new Response<string>("Successfully deleted");

        }
    }
}
