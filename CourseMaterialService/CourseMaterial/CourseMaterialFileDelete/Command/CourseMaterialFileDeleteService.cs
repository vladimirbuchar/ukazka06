using Core.Base.Command.FileDelete;
using Core.Base.Repository.FileRepository;
using Model.Edu.CourseMaterial;

namespace CourseMaterialService.CourseMaterial.CourseMaterialFileDelete.Command
{
    public class CourseMaterialFileDeleteService : BaseFileDeleteCommand<CourseMaterialFileRepositoryDbo>, ICourseMaterialFileDeleteService
    {
        public CourseMaterialFileDeleteService(IFileUploadRepository<CourseMaterialFileRepositoryDbo> fileRepository)
            : base(fileRepository) { }
    }
}
