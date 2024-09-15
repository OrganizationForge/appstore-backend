using Application.Features.Brands.Commands.CreateBrandCommand;
using Application.Features.Brands.Queries;
using Application.Features.Categories.Queries;
using Application.Features.Orders;
using Application.Features.Orders.Commands.CreateOrderCommand;
using Application.Features.ProductComments.Commands.CreateCommentCommand;
using Application.Features.ProductComments.Queries;
using Application.Features.Products.Commands.CreateProductCommand;
using Application.Features.Products.Queries;
using Application.Features.Shipping.Commands.CreateShippingMethod;
using Application.Features.Shipping.Queries;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Checkout;
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
            CreateMap<ShippingMethod, ShippingMethodDTO>();
            CreateMap<ShippingDTO, Shipping>()
                .ReverseMap();
            CreateMap<OrderItemDTO, OrderItem>()
                .ReverseMap();


            #endregion

            #region Commands
            CreateMap<CreateProductCommand, Product>()
                .ForMember(dest => dest.ProductFiles, opt => opt.Ignore());
            CreateMap<CreateBrandCommand, Brand>();
            CreateMap<CreateCommentCommand, Comment>();
            CreateMap<CreateShippingMethodCommand, ShippingMethod>();
            CreateMap<CreateOrderCommand, Order>()
                .ForMember(dest => dest.Shipping, opt => opt.MapFrom(x => x.Shipping))
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(x => x.OrderItems))
                .ForMember(dest =>  dest.Status, opt => opt.MapFrom(x => OrderStatus.New));
            #endregion
        }
    }
}
