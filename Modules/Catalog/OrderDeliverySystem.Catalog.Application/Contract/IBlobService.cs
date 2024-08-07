using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Catalog.Application.Contract
{
    public interface IBlobService
    {
        public Task<string> UploadPhotoAsync(IFormFile file);
        public Task<string> UploadAsync(Stream stream, string contentType, CancellationToken cancellationToken = default);
        public Task<FileResponce> DownloadAsync(Guid fileId, CancellationToken cancellationToken = default);
        public Task DeleteAsync(Guid fileId, CancellationToken cancellationToken = default);
    }
}
