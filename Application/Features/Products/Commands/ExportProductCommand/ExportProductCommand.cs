using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities.Products;
using MediatR;

namespace Application.Features.Products.Commands.ExportProductCommand
{
    public class ExportProductCommand : IRequest<Stream>
    {
        public decimal? MinimumRate { get; set; }
        public decimal? MaximumRate { get; set; }
    }

    public class ExportProductCommandHandler : IRequestHandler<ExportProductCommand, Stream>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IExcelWriterService _excelWriterService;

        public ExportProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IExcelWriterService excelWriterService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _excelWriterService = excelWriterService;
        }

        public async Task<Stream> Handle(ExportProductCommand request, CancellationToken cancellationToken)
        {
            var spec = new ExportProductSpecification(request);

            var listAllProducts = await _unitOfWork.Repository<Product>().ListAsync(spec, cancellationToken);

            return _excelWriterService.WriteToStream(listAllProducts);
        }
    }
}
