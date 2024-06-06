using Core.Base.Convertor;
using EduServices.CourseTermStudent.Dto;
using Model.Tables.Link;

namespace EduServices.CourseTermStudent.Convertor
{
    public interface ICourseTermStudentConvertor : IBaseConvertor<CourseStudentDbo, CourseTermStudentCreateDto, CourseTermStudentListDto, CourseTermStudentDetailDto> { }
}
