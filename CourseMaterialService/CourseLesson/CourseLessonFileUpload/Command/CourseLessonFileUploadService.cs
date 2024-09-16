using Core.Base.Command.FileUpload;
using Core.Base.Repository.CodeBookRepository;
using Core.Base.Repository.FileRepository;
using Model.CodeBook;
using Model.Edu.CourseLesson;
using Repository.CourseLesson;

namespace CourseMaterialService.CourseLesson.CourseLessonFileUpload.Command
{
    public class CourseLessonFileUploadService : BaseServiceCommand<CourseLessonFileRepositoryDbo>, ICourseLessonFileUploadService
    {
        private readonly ICourseLessonRepository _courseLessonRepository;

        public CourseLessonFileUploadService(
            ICourseLessonRepository courseLessonRepository,
            IFileUploadRepository<CourseLessonFileRepositoryDbo> fileRepository,
            ICodeBookRepository<CultureDbo> cultureRespository
        )
            : base(fileRepository, cultureRespository)
        {
            _courseLessonRepository = courseLessonRepository;
        }

        public override Task<Guid> GetOrganizationIdByObjectId(Guid objectId)
        {
            return _courseLessonRepository.GetOrganizationId(objectId);
        }
    }
}
