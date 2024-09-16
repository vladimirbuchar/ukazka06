using Core.Base.Command.FileUpload;
using Model.Edu.CourseLessonItem;

namespace CourseMaterialService.CourseLessonItem.CourseLessonItemFileUpload.Command
{
    public interface ICourseLessonItemFileUploadService : IBaseServiceCommand<CourseLessonItemFileRepositoryDbo> { }
}
