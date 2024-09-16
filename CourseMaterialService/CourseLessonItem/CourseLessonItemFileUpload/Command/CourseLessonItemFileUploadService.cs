using Core.Base.Command.FileUpload;
using Core.Base.Repository.CodeBookRepository;
using Core.Base.Repository.FileRepository;
using Model.CodeBook;
using Model.Edu.CourseLessonItem;
using Repository.CourseLessonItem;

namespace CourseMaterialService.CourseLessonItem.CourseLessonItemFileUpload.Command
{
    public class CourseLessonItemFileUploadService : BaseServiceCommand<CourseLessonItemFileRepositoryDbo>, ICourseLessonItemFileUploadService
    {
        private readonly ICourseLessonItemRepository _courseLessonItemRepository;

        public CourseLessonItemFileUploadService(
            ICourseLessonItemRepository courseLessonItemRepository,
            IFileUploadRepository<CourseLessonItemFileRepositoryDbo> fileRepository,
            ICodeBookRepository<CultureDbo> cultureRespository
        )
            : base(fileRepository, cultureRespository)
        {
            _courseLessonItemRepository = courseLessonItemRepository;
        }

        public override async Task<Guid> GetOrganizationIdByObjectId(Guid objectId)
        {
            return await _courseLessonItemRepository.GetOrganizationId(objectId);
        }
    }
}
