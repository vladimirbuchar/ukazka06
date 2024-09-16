using Core.Base.Validator;
using CourseStudyService.Lector.LectorCreate.Dto;
using Model.Link;

namespace CourseStudyService.Lector.LectorCreate.Validator
{
    public interface ILectorCreateValidator : IBaseCreateValidator<CourseLectorDbo, LectorCreateDto> { }
}
