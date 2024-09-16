using Core.Base.Command.List;
using Core.Base.Filter;
using CourseStudyService.Student.StudentCourseList.Convertor;
using CourseStudyService.Student.StudentCourseList.Dto;
using Model.Link;
using Repository.CourseStudent;

namespace CourseStudyService.Student.StudentCourseList.Command
{
    public class StudentCourseListCommand : BaseListCommand<CourseStudentDbo, ICourseStudentRepository, StudentCourseListDto, IStudentCourseListConvertor, RequestFilter>, IStudentCourseListCommand
    {
        public StudentCourseListCommand(ICourseStudentRepository repository, IStudentCourseListConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
