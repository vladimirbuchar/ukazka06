using Core.Constants;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using System;
using System.IO;

namespace Core.Base.Repository.FileRepository
{
    public class FileUploadRepository<Model> : BaseRepository<Model>, IFileUploadRepository<Model>
        where Model : FileRepositoryModel
    {
        private readonly string _fileRepositoryPath;
        public FileUploadRepository(IWebHostEnvironment hostingEnvironment, EduDbContext dbContext, IMemoryCache memoryCache, IConfiguration configuration)
            : base(dbContext, memoryCache)
        {
            string projectRootPath = hostingEnvironment.ContentRootPath;

            string parent = Directory.GetParent(projectRootPath).FullName;
            _fileRepositoryPath = string.Format("{0}{1}", parent, configuration.GetSection(ConfigValue.FileRepository).Value);
        }
        /// <summary>
        /// create file repository
        /// </summary>
        /// <param name="objectOwner"></param>
        public void CreateFileRepository(Guid objectOwner)
        {
            string path = string.Format("{0}{1}", _fileRepositoryPath, objectOwner);
            if (!Directory.Exists(path))
            {
                _ = Directory.CreateDirectory(path);
            }
        }
        /// <summary>
        /// file upload
        /// </summary>
        /// <param name="model"></param>
        /// <param name="parentId"></param>
        /// <param name="file"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Model FileUpload(Model model, Guid parentId, IFormFile file, Guid userId)
        {
            string extesion = Path.GetExtension(file.FileName);
            string fileName = string.Format("{0}{1}", Guid.NewGuid().ToString(), extesion);
            string filePath = string.Format("{0}{1}/{2}", _fileRepositoryPath, parentId, fileName);
            if (File.Exists(filePath))
            {
                return FileUpload(model, parentId, file, userId);
            }
            using FileStream localFile = File.OpenWrite(filePath);
            using Stream uploadedFile = file.OpenReadStream();
            uploadedFile.CopyTo(localFile);
            model.OriginalFileName = file.FileName;
            model.FileName = fileName;
            long fileSize = localFile.Length;
            localFile.Close();
            if ((fileSize / 1048576.0) <= 10)
            {
                model.FileContent = File.ReadAllBytes(filePath);
            }

            return CreateEntity(model, userId);
        }
    }
}
