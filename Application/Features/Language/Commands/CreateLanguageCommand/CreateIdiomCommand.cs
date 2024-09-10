using Application.Common.Interfaces;
using Application.Common.Wrappers;
using AutoMapper;
using Domain.Entities.Library;
using MediatR;

namespace Application.Features.Language.Commands.CreateLanguageCommand
{
    public class CreateIdiomCommand : IRequest<Response<Guid>>
    {
        public string? Code { get; set; }
        public string? Description { get; set; }
    }

    public class CreateIdiomCommandHandler : IRequestHandler<CreateIdiomCommand, Response<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateIdiomCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(CreateIdiomCommand request, CancellationToken cancellationToken)
        {
            var newLanguage = _mapper.Map<Idiom>(request);

            await _unitOfWork.Repository<Idiom>().AddAsync(newLanguage);

            //Aca podemos agregar a la lista todos los eventos que necesitemos, ya sea 
            //enviar mails, notificaciones, modificaciones de otras clases que no sean la 
            //de Idiom directamente
            newLanguage.AddDomainEvent(new IdiomCreateEvent(newLanguage));

            await _unitOfWork.Save(cancellationToken);

            return new Response<Guid>(newLanguage.Id);
        }
    }
}
