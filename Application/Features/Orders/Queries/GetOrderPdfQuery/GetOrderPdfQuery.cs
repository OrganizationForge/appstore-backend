using Application.Common.Interfaces;
using Application.Features.Orders.Queries.GetOrderPdfQuery.ViewModels;
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
        private readonly IRazorViewToStringRenderer _razorRenderer;
        private readonly IFileService _fileService;

        public GetOrderPdfCommandHandler(IUnitOfWork unitOfWork, IRazorViewToStringRenderer razorRenderer, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _razorRenderer = razorRenderer;
            _fileService = fileService;
        }

        public async Task<byte[]> Handle(GetOrderPdfQuery request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.Repository<Order>().GetByIdAsync(request.Id, cancellationToken);

            if (order == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con id {request.Id}");
            }

            var viewModel = new OrderViewModel
            {
                // Mapea los datos de la orden al ViewModel
            };

            var htmlContent = await _razorRenderer.RenderViewToStringAsync("/Views/Orders/OrderTemplate.cshtml", viewModel);

            var pdf = _fileService.ConvertHtmlToPdf(htmlContent);

            return pdf;
        }
    }
}
