using Core.Base.Command.Create;
using Core.Base.Repository.CodeBookRepository;
using CourseMaterialService.CourseMaterial.CourseMaterialCreate.Convertor;
using CourseMaterialService.CourseMaterial.CourseMaterialCreate.Dto;
using CourseMaterialService.CourseMaterial.CourseMaterialCreate.Validator;
using Model.CodeBook;
using Model.Edu.CourseMaterial;
using Repository.CourseMaterial;

namespace CourseMaterialService.CourseMaterial.CourseMaterialCreate.Command
{
    public class CourseMaterialCreateService
        : BaseCreateCommand<
            CourseMaterialDbo,
            ICourseMaterialRepository,
            CourseMaterialCreateDto,
            ICourseMaterialCreateConvertor,
            ICourseMaterialCreateValidator
        >,
            ICourseMaterialCreateService
    {
        public CourseMaterialCreateService(
            ICourseMaterialRepository repository,
            ICourseMaterialCreateConvertor convertor,
            ICourseMaterialCreateValidator validator,
            ICodeBookRepository<CultureDbo> culture
        )
            : base(repository, convertor, validator, culture) { }
    }
}
