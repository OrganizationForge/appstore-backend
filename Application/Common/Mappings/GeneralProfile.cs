using Application.Features.Language.Commands.CreateLanguageCommand;
using Application.Features.Language.Queries;
using AutoMapper;
using Domain.Entities.Library;

namespace Application.Common.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region DTOs
            CreateMap<Idiom, IdiomDTO>();

            #endregion

            #region Commands
            CreateMap<CreateIdiomCommand, Idiom>();
            #endregion
        }
    }
}
