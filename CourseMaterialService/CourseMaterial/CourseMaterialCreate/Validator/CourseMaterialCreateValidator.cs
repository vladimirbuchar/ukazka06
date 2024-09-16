using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using CourseMaterialService.CourseMaterial.CourseMaterialCreate.Dto;
using Model.Edu.CourseMaterial;
using Repository.CourseMaterial;

namespace CourseMaterialService.CourseMaterial.CourseMaterialCreate.Validator
{
    public class CourseMaterialCreateValidator
        : BaseCreateValidator<CourseMaterialDbo, ICourseMaterialRepository, CourseMaterialCreateDto>,
            ICourseMaterialCreateValidator
    {
        public CourseMaterialCreateValidator(ICourseMaterialRepository repository)
            : base(repository) { }

        public override async Task<ResultInsert> IsValid(CourseMaterialCreateDto create)
        {
            ResultInsert result = new();
            IsValidString(create.Name, result, MessageCategory.COURSE_MATERIAL, MessageItem.STRING_IS_EMPTY);
            return await Task.FromResult(result);
        }
    }
}
