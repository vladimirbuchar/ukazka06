using Core.Base.Command.Detail;
using CourseStudyService.Student.StudentCourseDetail.Convertor;
using CourseStudyService.Student.StudentCourseDetail.Dto;
using Model.Link;
using Repository.CourseStudent;

namespace CourseStudyService.Student.StudentCourseDetail.Command
{
    public class StudentCourseDetailCommand : BaseDetailCommand<CourseStudentDbo, ICourseStudentRepository, StudentCourseDetailDto, IStudentCourseDetailConvertor>, IStudentCourseDetailCommand
    {
        public StudentCourseDetailCommand(ICourseStudentRepository repository, IStudentCourseDetailConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
