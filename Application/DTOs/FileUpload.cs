using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
<<<<<<<< HEAD:Application/DTOs/FileUpload.cs
    public class FileUpload
========
    public class FileDTO
>>>>>>>> feature-products:Application/DTOs/FileDTO.cs
    {
        public string? Filename { get; set; }
        public string?  Base64Content { get; set; }

    }

    public class FileUploadRequest
    {
        public string Name { get; set; } = default!;
        public string Extension { get; set; } = default!;
        public string Data { get; set; } = default!;
    }

}
