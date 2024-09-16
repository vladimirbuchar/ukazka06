using Core.Base.Command.Create;
using CourseStudyService.Lector.LectorCreate.Convertor;
using CourseStudyService.Lector.LectorCreate.Dto;
using CourseStudyService.Lector.LectorCreate.Validator;
using Model.Link;
using Repository.CourseLector;

namespace CourseStudyService.Lector.LectorCreate.Command
{
    public class LectorCreateService
        : BaseCreateCommand<CourseLectorDbo, ICourseLectorRepository, LectorCreateDto, ILectorCreateConvertor, ILectorCreateValidator>,
            ILectorCreateService
    {
        public LectorCreateService(ICourseLectorRepository repository, ILectorCreateConvertor convertor, ILectorCreateValidator validator)
            : base(repository, convertor, validator) { }
    }
}
