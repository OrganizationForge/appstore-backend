using Application.DTOs;
using Microsoft.AspNetCore.Http;

namespace Application.Common.Interfaces
{
    public interface IFileService
    {
        string UploadFile(IFormFile file, string route);
        string UploadBase64File(FileDTO file, string route);
    }
}
