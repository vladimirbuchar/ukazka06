using Core.Base.Convertor;
using Model.Link;
using Services.CourseTermStudent.Dto;

namespace Services.CourseTermStudent.Convertor
{
    public interface ICourseTermStudentConvertor
        : IBaseConvertor<CourseStudentDbo, CourseTermStudentCreateDto, CourseTermStudentListDto, CourseTermStudentDetailDto> { }
}
