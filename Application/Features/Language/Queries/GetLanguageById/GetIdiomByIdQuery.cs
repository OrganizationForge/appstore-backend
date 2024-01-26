using Application.Common.Interfaces;
using Application.Common.Wrappers;
using Application.Features.Language.Queries.GetAllLanguages;
using AutoMapper;
using Domain.Entities.Library;
using MediatR;

namespace Application.Features.Language.Queries.GetLanguageById
{
    public class GetIdiomByIdQuery : IRequest<Response<IdiomDTO>>
    {
        public int Id { get; set; }
    }

    public class GetIdiomByIdQueryHandler : IRequestHandler<GetIdiomByIdQuery, Response<IdiomDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetIdiomByIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<IdiomDTO>> Handle(GetIdiomByIdQuery request, CancellationToken cancellationToken)
        {
            var idiom = await _unitOfWork.Repository<Idiom>().GetByIdAsync(request.Id);

            //Aca si no existe un Idiom con el id recibido, genera una excepcion customizada
            //Que es atrapada por el Middleware de excepciones
            if (idiom == null)
                throw new KeyNotFoundException($"Registro no encontrado con id {request.Id}");
            else
            {
                var result = _mapper.Map<IdiomDTO>(idiom);
                return new Response<IdiomDTO>(result);
            }
        }
    }
}
