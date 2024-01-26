using Application.Features.Brands.Queries;
using Application.Features.Categories.Queries;
using Application.Features.Language.Commands.CreateLanguageCommand;
using Application.Features.Language.Queries.GetAllLanguages;
using Application.Features.Products.Commands.CreateProductCommand;
using Application.Features.Products.Queries;
using AutoMapper;
using Domain.Entities;
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
            CreateMap<Category, CategoryDTO>();
            CreateMap<Brand, BrandDTO>();
            #endregion

            #region Commands
            CreateMap<CreateIdiomCommand, Idiom>();
            CreateMap<CreateProductCommand, Product>();
            #endregion
        }
    }
}
