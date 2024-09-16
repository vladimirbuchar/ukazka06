using Model.Edu.OrganizationStudyHour;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourUpdate.Dto;

namespace OrganizationService.OrganizationStudyHour.OrganizationStudyHourUpdate.Convertor
{
    public class OrganizationStudyHourUpdateConvertor : IOrganizationStudyHourUpdateConvertor
    {
        public Task<OrganizationStudyHourDbo> ConvertToBussinessEntity(StudyHourUpdateDto update, OrganizationStudyHourDbo entity, string culture)
        {
            entity.ActiveFromId = update.ActiveFromId;
            entity.ActiveToId = update.ActiveToId;
            entity.Id = update.Id;
            entity.Position = update.Position;
            entity.ActiveFrom = null;
            entity.ActiveTo = null;
            return Task.FromResult(entity);
        }
    }
}
