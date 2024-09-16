using Microsoft.AspNetCore.Http;
using Model;
using System;
using System.Threading.Tasks;

namespace Core.Base.Repository.FileRepository
{
    public interface IFileUploadRepository<Model> : IBaseRepository<Model>
        where Model : FileRepositoryModel
    {
        Task<Model> FileUpload(Model model, Guid parentId, IFormFile file, Guid userId);
        void CreateFileRepository(Guid objectOwner);
    }
}
