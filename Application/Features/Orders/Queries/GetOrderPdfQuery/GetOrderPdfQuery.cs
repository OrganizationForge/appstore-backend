using Application.Common.Interfaces;
using Application.Features.Orders.Queries.GetOrderById;
using Application.Features.Payments.Queries;
using Application.Features.Payments.Queries.GetAllPaymentMethodsQuery;
using Application.Features.Products.Queries;
using Application.Features.Shippings.Queries;
using AutoMapper;
using Domain.Entities.Checkout;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Queries.GetOrderPdfQuery
{
    public class GetOrderPdfQuery : IRequest<byte[]>
    {
        public Guid Id { get; set; }
    }

    public class GetOrderPdfCommandHandler : IRequestHandler<GetOrderPdfQuery, byte[]>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRazorViewRenderer _razorRenderer;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;

        public GetOrderPdfCommandHandler(IUnitOfWork unitOfWork, IRazorViewRenderer razorRenderer, IFileService fileService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _razorRenderer = razorRenderer;
            _fileService = fileService;
            _mapper = mapper;
        }


        public async Task<byte[]> Handle(GetOrderPdfQuery request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.Repository<Order>().FirstOrDefaultAsync(new OrderByIdSpecification(request.Id), cancellationToken);
            var orderDTO = _mapper.Map<OrderDTO>(order);

            if (order == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con id {request.Id}");
            }



            var viewModel = new OrderDTO
            {
                Id = orderDTO.Id,
                Status = orderDTO.Status,  // Asegúrate de que Status se puede convertir a string sin problemas
                CreatedDate = orderDTO.CreatedDate,
                Total = orderDTO.Total,
                Payment = orderDTO.Payment != null ? new PaymentDTO
                {
                    Amount = orderDTO.Payment.Amount,
                    Status = orderDTO.Payment.Status?.ToString() ?? "N/A", // Usa null-coalescing para evitar errores
                    PaymentMethod = orderDTO.Payment.PaymentMethod != null ? new PaymentMethodDTO
                    {
                        Description = orderDTO.Payment.PaymentMethod.Description ?? "No Description"
                    } : null
                } : null,
                Shipping = orderDTO.Shipping != null ? new ShippingDTO
                {
                    ShippingAddress = orderDTO.Shipping.ShippingAddress ?? "No Address",
                    ShippingMethod = orderDTO.Shipping.ShippingMethod != null ? new ShippingMethodDTO
                    {
                        Title = orderDTO.Shipping.ShippingMethod.Title ?? "No Title",
                        Description = orderDTO.Shipping.ShippingMethod.Description ?? "No Description",
                        Price = orderDTO.Shipping.ShippingMethod.Price
                    } : null
                } : null,
                OrderItems = orderDTO.OrderItems?.Select(item => new OrderItemDTO
                {
                    Product = item.Product != null ? new ProductDTO
                    {
                        Id = item.Product.Id,
                        Price = item.Product.Price,
                        Brand = item.Product.Brand,
                        Description = item.Product.Description,
                        ProductName = item.Product.ProductName
                    }: null,
                    Quantity = item.Quantity,
                    Price = item.Price
                }).ToList()
            };

            var htmlContent = await _razorRenderer.RenderViewAsync("~/Views/Orders/OrderTemplate.cshtml", viewModel);

            var pdf = await _fileService.ConvertHtmlToPdfAsync(htmlContent);

            return pdf;
        }
    }
}
