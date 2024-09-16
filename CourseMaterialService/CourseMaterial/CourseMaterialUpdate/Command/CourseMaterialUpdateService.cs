using Core.Base.Command.Update;
using CourseMaterialService.CourseMaterial.CourseMaterialUpdate.Convertor;
using CourseMaterialService.CourseMaterial.CourseMaterialUpdate.Dto;
using CourseMaterialService.CourseMaterial.CourseMaterialUpdate.Validate;
using Model.Edu.CourseMaterial;
using Repository.CourseMaterial;

namespace CourseMaterialService.CourseMaterial.CourseMaterialUpdate.Command
{
    public class CourseMaterialUpdateService
        : BaseUpdateCommand<
            CourseMaterialDbo,
            ICourseMaterialRepository,
            CourseMaterialUpdateDto,
            ICourseMaterialUpdateConvertor,
            ICourseMaterialUpdateValidator
        >,
            ICourseMaterialUpdateService
    {
        public CourseMaterialUpdateService(
            ICourseMaterialRepository repository,
            ICourseMaterialUpdateConvertor convertor,
            ICourseMaterialUpdateValidator validator
        )
            : base(repository, convertor, validator) { }
    }
}
