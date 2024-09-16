using Core.Base.Validator;
using CourseStudyService.Lector.LectorCreate.Dto;
using Model.Link;
using Repository.CourseLector;

namespace CourseStudyService.Lector.LectorCreate.Validator
{
    public class LectorCreateValidator : BaseCreateValidator<CourseLectorDbo, ICourseLectorRepository, LectorCreateDto>, ILectorCreateValidator
    {
        public LectorCreateValidator(ICourseLectorRepository repository)
            : base(repository) { }
    }
}
