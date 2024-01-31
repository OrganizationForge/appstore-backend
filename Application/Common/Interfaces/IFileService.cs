using Application.DTOs;

namespace Application.Common.Interfaces
{
    public interface IFileService
    {
        string UploadFile(ImageDTO file, string route);
    }
}
