using Core.Base.Command.Detail;
using CourseStudyService.Student.StudentCourseDetail.Dto;
using Model.Link;

namespace CourseStudyService.Student.StudentCourseDetail.Command
{
    public interface IStudentCourseDetailCommand : IBaseDetailCommand<CourseStudentDbo, StudentCourseDetailDto>
    {
    }
}