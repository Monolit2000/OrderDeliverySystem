using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Http;
using OrderDeliverySystem.Catalog.Application.Contract;
using Microsoft.AspNetCore.Hosting;


namespace OrderDeliverySystem.Catalog.Infrastructure.Services
{
    public class BlobService : IBlobService
    {

        private readonly StorageClient _storageClient;
        private readonly string _bucketName = "touchlunch-81db1.appspot.com";
        private readonly string _adminsdkPath; /*= "C:\\Users\\СТО\\source\\repos\\OrderDeliverySystem\\OrderDeliverySystem.API\\Properties\\touchlunch-81db1-firebase-adminsdk-1zzyy-cd4413028dNEW.json";*/

        public BlobService(IHostingEnvironment env)
        {
            _adminsdkPath = Path.Combine(env.ContentRootPath, "Properties", "touchlunch-81db1-firebase-adminsdk-1zzyy-cd4413028dNEW.json");

            //if (FirebaseApp.DefaultInstance == null)
            //{
            //    FirebaseApp.Create(new AppOptions()
            //    {
            //        Credential = GoogleCredential.FromFile(_adminsdkPath)
            //    });
            //}
            _storageClient = StorageClient.Create(GoogleCredential.FromFile(_adminsdkPath));
        }

        public async Task<string> UploadPhotoAsync(IFormFile file)
        {
            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var contentType = file.ContentType ?? "image/png"; 

            using (var stream = file.OpenReadStream())
            {
                var uploadOptions = new UploadObjectOptions
                {
                    PredefinedAcl = PredefinedObjectAcl.PublicRead 
                };

              var storageObject = await _storageClient.UploadObjectAsync(
                   _bucketName,
                   fileName,
                   contentType,
                   stream,
                   uploadOptions
               );

                Console.WriteLine($"Uploaded object {storageObject.Name} with URL: {storageObject.MediaLink}");

                //return storageObject.MediaLink; 
            }
            return $"https://storage.googleapis.com/{_bucketName}/{fileName}";
        }


        public Task<string> UploadAsync(Stream stream, string contentType, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid fileId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<FileResponce> DownloadAsync(Guid fileId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

    }
}
