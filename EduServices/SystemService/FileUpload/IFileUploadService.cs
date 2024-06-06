using System;
using Core.Base.Service;

namespace EduServices.SystemService.FileUpload
{
    public interface IFileUploadService : IBaseService
    {
        Guid SaveFilePngFile(string img, string directory);
    }
}
