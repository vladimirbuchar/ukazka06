using Core.Constants;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Model;
using Model.Edu.CourseMaterial;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Core.Base.Repository.FileRepository
{
    public class FileUploadRepository<Model> : BaseRepository<Model>, IFileUploadRepository<Model>
        where Model : FileRepositoryModel
    {
        private readonly string _fileRepositoryPath;

        public FileUploadRepository(
            IWebHostEnvironment hostingEnvironment,
            EduDbContext dbContext,
            IMemoryCache memoryCache,
            IConfiguration configuration
        )
            : base(dbContext, memoryCache)
        {
            string projectRootPath = hostingEnvironment.ContentRootPath;

            string parent = Directory.GetParent(projectRootPath).FullName;
            _fileRepositoryPath = string.Format("{0}{1}", parent, configuration.GetSection(ConfigValue.FILE_REPOSITORY).Value);
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
        public async Task<Model> FileUpload(Model model, Guid parentId, IFormFile file, Guid userId)
        {
            string extesion = Path.GetExtension(file.FileName);
            string fileName = string.Format("{0}{1}", Guid.NewGuid().ToString(), extesion);
            string filePath = string.Format("{0}{1}/{2}", _fileRepositoryPath, parentId, fileName);
            if (File.Exists(filePath))
            {
                return await FileUpload(model, parentId, file, userId);
            }
            using FileStream localFile = File.OpenWrite(filePath);
            using Stream uploadedFile = file.OpenReadStream();
            uploadedFile.CopyTo(localFile);
            model.OriginalFileName = file.FileName;
            model.FileName = fileName;
            model.FileSize = localFile.Length;
            localFile.Close();
            return await CreateEntity(model, userId);
        }

        public override async Task<Guid> GetOrganizationId(Guid objectId)
        {
            Guid result = Guid.Empty;
            result =
                typeof(Model) == typeof(CourseMaterialFileRepositoryDbo)
                    ? (await _dbContext.Set<CourseMaterialDbo>().FirstOrDefaultAsync(x => x.Id == objectId)).OrganizationId
                    : await base.GetOrganizationId(objectId);
            return result;
        }

        public override async Task<Guid> GetOrganizationByFileId(Guid objectId)
        {
            Guid result = Guid.Empty;
            result =
                typeof(Model) == typeof(CourseMaterialFileRepositoryDbo)
                    ? (
                        await _dbContext
                            .Set<CourseMaterialFileRepositoryDbo>()
                            .Include(x => x.CourseMaterial)
                            .FirstOrDefaultAsync(x => x.Id == objectId)
                    )
                        .CourseMaterial
                        .OrganizationId
                    : await base.GetOrganizationId(objectId);
            return result;
        }
    }
}
