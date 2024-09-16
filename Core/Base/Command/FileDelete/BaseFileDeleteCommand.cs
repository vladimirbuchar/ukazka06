using Core.Base.Repository.FileRepository;
using Core.DataTypes;
using Model;
using System;
using System.Threading.Tasks;

namespace Core.Base.Command.FileDelete
{
    public class BaseFileDeleteCommand<TFileModel> : IBaseFileDeleteCommand
        where TFileModel : FileRepositoryModel
    {
        protected readonly IFileUploadRepository<TFileModel> _fileRepository;

        public BaseFileDeleteCommand(IFileUploadRepository<TFileModel> fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public async Task<Result> Execute(Guid id, Guid userId)
        {
            await _fileRepository.DeleteEntity(id, userId);
            return new Result();
        }

        public virtual async Task<Guid> GetOrganizationIdByFileId(Guid objectId)
        {
            return await _fileRepository.GetOrganizationByFileId(objectId);
        }
    }
}
