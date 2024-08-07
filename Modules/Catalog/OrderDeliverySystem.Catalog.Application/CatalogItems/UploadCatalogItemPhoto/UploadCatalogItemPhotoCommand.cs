using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Application.CatalogItems.UploadCatalogItemPhoto
{
    public class UploadCatalogItemPhotoCommand : IRequest<Result<UploadPhotoResponce>>
    {
        public IFormFile File { get; set; }
    }
}
