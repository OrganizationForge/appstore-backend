using Application.DTOs;
using Microsoft.AspNetCore.Http;

namespace Application.Common.Interfaces
{
    public interface IFileService
    {
        string UploadFile(FileUpload file, string route);
        string UploadFile(IFormFile file, string route);
        Task<byte[]> ConvertHtmlToPdfAsync(string htmlContent);
    }
}
