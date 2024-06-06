using Microsoft.AspNetCore.Http;
using Model;
using System;

namespace Core.Base.Repository.FileRepository
{
    public interface IFileUploadRepository<Model> : IBaseRepository<Model>
        where Model : FileRepositoryModel
    {
        Model FileUpload(Model model, Guid parentId, IFormFile file, Guid userId);
        void CreateFileRepository(Guid objectOwner);
    }
}
