using Core.Base.Service;
using System;

namespace Services.SystemService.FileUpload
{
    public interface IFileUploadService : IBaseService
    {
        Guid SaveFilePngFile(string img, string directory);
    }
}
