using Application.Common.Interfaces;
using Application.Common.Wrappers;
using Application.Features.Categories.Commands.DeleteCategoryByIdCommand;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Checkout;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Commands.UpdateOrderStatusCommand
{
    public class UpdateOrderStatusCommand : IRequest<Response<string>>
    {
        public Guid OrderId { get; set; }
        public int Status { get; set; }
    }


    public class UpdateOrderStatusCommandHandler : IRequestHandler<UpdateOrderStatusCommand, Response<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public UpdateOrderStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<Response<string>> Handle(UpdateOrderStatusCommand command, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.Repository<Order>().GetByIdAsync(command.OrderId);

            if (order is null)
            {
                return new Response<string>("Orden no encontrada.");
            }
            _mapper.Map(command, order);

            await _unitOfWork.Repository<Order>().UpdateAsync(order);


            await _unitOfWork.Save(cancellationToken);

            return new Response<string>("Successfully deleted");

        }
    }
}
