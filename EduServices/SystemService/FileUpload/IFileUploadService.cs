using System;
using Core.Base.Service;

namespace Services.SystemService.FileUpload
{
    public interface IFileUploadService : IBaseService
    {
        Guid SaveFilePngFile(string img, string directory);
    }
}
