﻿using E_CommerceAPI.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace E_CommerceAPI.Application.Features.Commands.ProductImageFile.RemoveProdcutImage
{
    public class RemoveProductImageCommandHandler : IRequestHandler<RemoveProductImageCommandRequest, RemoveProductImageCommandResponce>
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IProductWriteRepository _productWriteRepository;

        public RemoveProductImageCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        public  async Task<RemoveProductImageCommandResponce> Handle(RemoveProductImageCommandRequest request, CancellationToken cancellationToken)
        {
          Domain.Entities.Product? product = await _productReadRepository.Table.Include(p => p.ProductImagesFile).FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));

            Domain.Entities.ProductImageFile? productImageFile = product?.ProductImagesFile.FirstOrDefault(p => p.Id == Guid.Parse(request.ImageId));

            if (productImageFile != null)
            product?.ProductImagesFile.Remove(productImageFile);

           await _productWriteRepository.SaveAsync();

            return new();
        }
    }
}
