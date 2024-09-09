using Application.Features.Brands.Commands.CreateBrandCommand;
using Application.Features.Brands.Queries;
using Application.Features.Categories.Queries;
using Application.Features.ProductComments.Commands.CreateCommentCommand;
using Application.Features.ProductComments.Queries;
using Application.Features.Products.Commands.CreateProductCommand;
using Application.Features.Products.Queries;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Products;

namespace Application.Common.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region DTOs
            CreateMap<Product, ProductDTO>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<Brand, BrandDTO>();
            CreateMap<ProductFile, ProductFileDTO>();
            CreateMap<Comment, CommentDTO>();



            #endregion

            #region Commands
            CreateMap<CreateProductCommand, Product>()
                .ForMember(dest => dest.ProductFiles, opt => opt.Ignore());
            CreateMap<CreateBrandCommand, Brand>();
            CreateMap<CreateCommentCommand, Comment>();

            #endregion
        }
    }
}
