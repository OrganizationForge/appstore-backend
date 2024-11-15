﻿using Application.Common.Interfaces;
using Application.DTOs;
using Domain.Common;
using Domain.Entities.Products;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Products.Commands.CreateProductCommand
{
    public class ProductCreatedEvent : DomainEvent
    {
        public Product Product { get; }
        public ICollection<FileUpload> FormFiles { get; }

        public ProductCreatedEvent(Product product, ICollection<FileUpload> formFiles)
        {
            Product = product;
            FormFiles = formFiles;
        }
    }

    public class ProductCreatedEventHandler : INotificationHandler<ProductCreatedEvent>
    {
        private readonly IFileService _fileService;
        private readonly IUnitOfWork _unitOfWork;

        public ProductCreatedEventHandler(IFileService fileService, IUnitOfWork unitOfWork)
        {
            _fileService = fileService;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(ProductCreatedEvent notification, CancellationToken cancellationToken)
        {

            if (notification.FormFiles != null)
            {
                List<ProductFile> productFiles = new List<ProductFile>();

                foreach (var file in notification.FormFiles)
                {
                    var newFile = new ProductFile
                    {
                        NameImage = file.Name,
                        UrlImage = _fileService.UploadFile(file, notification.Product.Id.ToString()),
                        //UrlImage = _fileService.UploadFile(file, @"Images\" + notification.Product.Id),
                        ProductId = notification.Product.Id
                    };

                    await _unitOfWork.Repository<ProductFile>().AddAsync(newFile);
                }

                await _unitOfWork.Save(cancellationToken);
            }
        }
    }
}
