using CourseMaterialService.CourseMaterial.CourseMaterialCreate.Dto;
using Model.Edu.CourseMaterial;

namespace CourseMaterialService.CourseMaterial.CourseMaterialCreate.Convertor
{
    public class CourseMaterialCreateConvertor : ICourseMaterialCreateConvertor
    {
        public Task<CourseMaterialDbo> ConvertToBussinessEntity(CourseMaterialCreateDto create, string culture)
        {
            CourseMaterialDbo material = new() { OrganizationId = create.OrganizationId };
            material.CourseMaterialTranslation = material.CourseMaterialTranslation.PrepareTranslation(
                create.Name,
                create.Description,
                create.CultureId
            );
            return Task.FromResult(material);
        }
    }
}
