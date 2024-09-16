using Core.Base.Command.FileUpload;
using Core.Base.Repository.CodeBookRepository;
using Core.Base.Repository.FileRepository;
using Model.CodeBook;
using Model.Edu.CourseMaterial;
using Repository.CourseMaterial;

namespace CourseMaterialService.CourseMaterial.CourseMaterialFileUpload.Command
{
    public class CourseMaterialFileUploadService : BaseServiceCommand<CourseMaterialFileRepositoryDbo>, ICourseMaterialFileUploadService
    {
        private readonly ICourseMaterialRepository _courseMaterialRepository;

        public CourseMaterialFileUploadService(
            ICourseMaterialRepository courseMaterialRepository,
            IFileUploadRepository<CourseMaterialFileRepositoryDbo> fileRepository,
            ICodeBookRepository<CultureDbo> cultureRespository
        )
            : base(fileRepository, cultureRespository)
        {
            _courseMaterialRepository = courseMaterialRepository;
        }
    }
}
