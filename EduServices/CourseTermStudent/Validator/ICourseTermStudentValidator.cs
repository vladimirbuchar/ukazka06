using Core.Base.Validator;
using Model.Link;
using Repository.CourseStudentRepository;
using Services.CourseTermStudent.Dto;

namespace Services.CourseTermStudent.Validator
{
    public interface ICourseTermStudentValidator
        : IBaseValidatorCreate<CourseStudentDbo, ICourseStudentRepository, CourseTermStudentCreateDto>
    { }
}
