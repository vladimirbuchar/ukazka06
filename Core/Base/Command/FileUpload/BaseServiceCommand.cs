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

namespace Core.Base.Command.FileUpload
{
    public class BaseServiceCommand<TFileModel> : IBaseServiceCommand<TFileModel>
        where TFileModel : FileRepositoryModel
    {
        protected readonly IFileUploadRepository<TFileModel> _fileRepository;
        private ICodeBookRepository<CultureDbo> Culture { get; set; }

        public BaseServiceCommand(IFileUploadRepository<TFileModel> fileRepository, ICodeBookRepository<CultureDbo> cultureRespository)
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
            TFileModel model,
            Expression<Func<TFileModel, bool>> deleteFiles = null
        )
        {
            _fileRepository.CreateFileRepository(parentId);
            if (deleteFiles != null)
            {
                List<TFileModel> fileDelete = await _fileRepository.GetEntities(false, deleteFiles);
                foreach (TFileModel item in fileDelete)
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

        public virtual async Task<Guid> GetOrganizationIdByObjectId(Guid objectId)
        {
            return await Task.FromResult(Guid.Empty);
        }
    }
}
