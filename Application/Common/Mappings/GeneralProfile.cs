using Application.Features.Language.Commands.CreateLanguageCommand;
using Application.Features.Language.Queries;
using Application.Features.Products;
using AutoMapper;
using Domain.Entities.Library;
using Domain.Entities.Products;

namespace Application.Common.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region DTOs
            CreateMap<Idiom, IdiomDTO>();
            CreateMap<Product, ProductDTO>();
            #endregion

            #region Commands
            CreateMap<CreateIdiomCommand, Idiom>();
            #endregion
        }
    }
}
