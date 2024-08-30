using Application.Features.Brands.Commands.CreateBrandCommand;
using Application.Features.Brands.Queries;
using Application.Features.Categories.Queries;
using Application.Features.Language.Commands.CreateLanguageCommand;
using Application.Features.Language.Queries.GetAllLanguages;
using Application.Features.ProductComments.Commands.CreateCommentCommand;
using Application.Features.ProductComments.Queries;
using Application.Features.Products.Commands.CreateProductCommand;
using Application.Features.Products.Queries;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Library;
using Domain.Entities.Products;
using System.Net;

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
            CreateMap<ProductFile, ProductFileDTO>();
            CreateMap<Comment, CommentDTO>();



            #endregion

            #region Commands
            CreateMap<CreateIdiomCommand, Idiom>();
            CreateMap<CreateProductCommand, Product>()
                .ForMember(dest => dest.ProductFiles, opt => opt.Ignore());
            CreateMap<CreateBrandCommand, Brand>();
            CreateMap<CreateCommentCommand, Comment>();

            #endregion
        }
    }
}
