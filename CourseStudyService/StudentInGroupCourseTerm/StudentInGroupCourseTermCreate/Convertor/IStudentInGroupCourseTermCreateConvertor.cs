using Core.Base.Convertor;
using CourseStudyService.StudentInGroupCourseTerm.StudentInGroupCourseTermCreate.Dto;
using Model.Link;

namespace CourseStudyService.StudentInGroupCourseTerm.StudentInGroupCourseTermCreate.Convertor
{
    public interface IStudentInGroupCourseTermCreateConvertor
        : IBaseCreateConvertor<StudentInGroupCourseTermDbo, StudentInGroupCourseTermCreateDto>
    { }
}
