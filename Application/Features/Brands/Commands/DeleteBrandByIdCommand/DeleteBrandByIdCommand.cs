using Application.Common.Interfaces;
using Application.Common.Wrappers;
using Application.Features.Categories.Commands.DeleteCategoryByIdCommand;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.DeleteBrandByIdCommand
{
    public class DeleteBrandByIdCommand : IRequest<Response<string>>
    {
        public Guid Id { get; set; }
    }


    public class DeleteBrandByIdCommandHandler : IRequestHandler<DeleteBrandByIdCommand, Response<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public DeleteBrandByIdCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Response<string>> Handle(DeleteBrandByIdCommand command, CancellationToken cancellationToken)
        {
            var brand = await _unitOfWork.Repository<Brand>().GetByIdAsync(command.Id);

            if (brand is null)
            {
                return new Response<string>("Marca no encontrada.");
            }

            await _unitOfWork.Repository<Brand>().DeleteAsync(brand);


            await _unitOfWork.Save(cancellationToken);

            return new Response<string>("Successfully deleted");

        }
    }
}
