using Core.Base.Command.FileDelete;
using Core.Base.Repository.FileRepository;
using Model.Edu.CourseLessonItem;
using Repository.CourseLessonItem;

namespace CourseMaterialService.CourseLessonItem.CourseLessonItemFileDelete.Command
{
    public class CourseLessonItemFileDeleteService : BaseFileDeleteCommand<CourseLessonItemFileRepositoryDbo>, ICourseLessonItemFileDeleteService
    {
        private readonly ICourseLessonItemRepository _courseLessonItemRepository;

        public CourseLessonItemFileDeleteService(
            ICourseLessonItemRepository courseLessonItemRepository,
            IFileUploadRepository<CourseLessonItemFileRepositoryDbo> fileRepository
        )
            : base(fileRepository)
        {
            _courseLessonItemRepository = courseLessonItemRepository;
        }

        public override Task<Guid> GetOrganizationIdByFileId(Guid objectId)
        {
            return _courseLessonItemRepository.GetOrganizationByFileId(objectId);
        }
    }
}
