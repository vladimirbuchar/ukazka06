using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using CourseMaterialService.CourseMaterial.CourseMaterialDetail.Dto;
using CourseMaterialService.CourseMaterial.CourseMaterialUpdate.Dto;
using Model.Edu.CourseMaterial;
using Repository.CourseMaterial;

namespace CourseMaterialService.CourseMaterial.CourseMaterialUpdate.Validate
{
    public class CourseMaterialUpdateValidator
        : BaseUpdateValidator<CourseMaterialDbo, ICourseMaterialRepository, CourseMaterialUpdateDto>,
            ICourseMaterialUpdateValidator
    {
        public CourseMaterialUpdateValidator(ICourseMaterialRepository repository)
            : base(repository) { }

        public override async Task<Result> IsValid(CourseMaterialUpdateDto update)
        {
            Result<CourseMaterialDetailDto> result = new();
            IsValidString(update.Name, result, MessageCategory.COURSE_MATERIAL, MessageItem.STRING_IS_EMPTY);
            return await Task.FromResult(result);
        }
    }
}
