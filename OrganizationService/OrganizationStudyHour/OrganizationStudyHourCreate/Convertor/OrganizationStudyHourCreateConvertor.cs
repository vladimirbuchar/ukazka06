using Model.Edu.OrganizationStudyHour;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourCreate.Dto;

namespace OrganizationService.OrganizationStudyHour.OrganizationStudyHourCreate.Convertor
{
    public class OrganizationStudyHourCreateConvertor : IOrganizationStudyHourCreateConvertor
    {
        public Task<OrganizationStudyHourDbo> ConvertToBussinessEntity(StudyHourCreateDto create, string culture)
        {
            return Task.FromResult(
                new OrganizationStudyHourDbo()
                {
                    ActiveFromId = create.ActiveFromId,
                    ActiveToId = create.ActiveToId.Value,
                    OrganizationId = create.OrganizationId,
                    Position = create.Position,
                }
            );
        }
    }
}
