using Application.Common.Interfaces;
using Application.Common.Wrappers;
using Application.Features.Products.Commands.CreateProductCommand;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductComments.Commands.CreateCommentCommand
{
    public class CreateCommentCommand : IRequest<Response<Guid>>
    {
        public string? CustomerName { get; set; }
        public string? Content { get; set; }
        public string? CustomerImage { get; set; }
        public string? Pros { get; set; }
        public string? Cons { get; set; }
        public int Rating { get; set; }
        public Guid ProductId { get; set; }
    }

    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Response<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var newComment = _mapper.Map<Comment>(request);

            await _unitOfWork.Repository<Comment>().AddAsync(newComment);

            //newComment.AddDomainEvent(new CommentCreatedEvent(newComment));

            await _unitOfWork.Save(cancellationToken);

            return new Response<Guid>(newComment.Id);
        }
    }
}
