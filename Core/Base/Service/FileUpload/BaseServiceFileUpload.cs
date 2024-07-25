using Core.Base.Repository.CodeBookRepository;
using Core.Base.Repository.FileRepository;
using Core.DataTypes;
using Microsoft.AspNetCore.Http;
using Model;
using Model.CodeBook;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Base.Service.FileUpload
{
    public class BaseServiceFileUpload<FileModel> : IBaseServiceFileUpload<FileModel>
                where FileModel : FileRepositoryModel
    {
        protected readonly IFileUploadRepository<FileModel> _fileRepository;
        private ICodeBookRepository<CultureDbo> Culture { get; set; }
        public BaseServiceFileUpload(IFileUploadRepository<FileModel> fileRepository, ICodeBookRepository<CultureDbo> cultureRespository)
        {
            _fileRepository = fileRepository;
            Culture = cultureRespository;
        }
        /// <summary>
        /// file upload
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="culture"></param>
        /// <param name="userId"></param>
        /// <param name="files"></param>
        /// <param name="model"></param>
        /// <param name="deleteFiles"></param>
        public virtual async Task<Result> Execute(
            Guid parentId,
            string culture,
            Guid userId,
            List<IFormFile> files,
            FileModel model,
            Expression<Func<FileModel, bool>> deleteFiles = null
        )
        {
            _fileRepository.CreateFileRepository(parentId);
            if (deleteFiles != null)
            {
                List<FileModel> fileDelete = await _fileRepository.GetEntities(false, deleteFiles);
                foreach (FileModel item in fileDelete)
                {
                    await _fileRepository.DeleteEntity(item, userId);
                }
            }
            Guid cultureId = (await Culture.GetEntity(false, x => x.SystemIdentificator == culture)).Id;
            model.CultureId = cultureId;
            foreach (IFormFile file in files)
            {
                _ = await _fileRepository.FileUpload(model, parentId, file, userId);
            }
            return new Result();
        }

        /// <summary>
        /// file delete
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        public virtual async Task<Result> Execute(Guid id, Guid userId)
        {
            await _fileRepository.DeleteEntity(id, userId);
            return new Result();
        }
    }
}
