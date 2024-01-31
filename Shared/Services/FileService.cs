using Application.Common.Interfaces;
using Application.DTOs;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace Shared.Services
{
    public class FileService : IFileService
    {
        public string UploadFile(ImageDTO file, string route)
        {
            var folderName = Path.Combine("Resources", route);
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            string fileRoute = "";

            if (!Directory.Exists(pathToSave))
                Directory.CreateDirectory(pathToSave);
            try
            {
                if (file != null)
                {
                    var fileName = file.ImageName;
                    var fullPath = Path.Combine(pathToSave, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        // Convert the base64 string to a byte array
                        var imageBytes = Convert.FromBase64String(file.ImageBytes);

                        // Write the byte array to the stream to create the image file
                        stream.Write(imageBytes, 0, imageBytes.Length);
                        fileRoute = Path.Combine(folderName, fileName);
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            
            return fileRoute;
        }
    }
}
