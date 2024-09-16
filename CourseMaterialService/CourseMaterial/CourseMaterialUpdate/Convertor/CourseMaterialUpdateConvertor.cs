using CourseMaterialService.CourseMaterial.CourseMaterialUpdate.Dto;
using Model.Edu.CourseMaterial;

namespace CourseMaterialService.CourseMaterial.CourseMaterialUpdate.Convertor
{
    public class CourseMaterialUpdateConvertor : ICourseMaterialUpdateConvertor
    {
        public Task<CourseMaterialDbo> ConvertToBussinessEntity(CourseMaterialUpdateDto update, CourseMaterialDbo entity, string culture)
        {
            entity.CourseMaterialTranslation = entity.CourseMaterialTranslation.PrepareTranslation(update.Name, update.Description, update.CultureId);
            return Task.FromResult(entity);
        }
    }
}
