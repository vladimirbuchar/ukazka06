using Core.Base.Command.FileUpload;
using Model.Edu.CourseLesson;

namespace CourseMaterialService.CourseLesson.CourseLessonFileUpload.Command
{
    public interface ICourseLessonFileUploadService : IBaseServiceCommand<CourseLessonFileRepositoryDbo> { }
}
