using Core.Base.Command.DropDown;
using Model.Edu.OrganizationStudyHour;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourDropDown.Dto;

namespace OrganizationService.OrganizationStudyHour.OrganizationStudyHourDropDown.Service
{
    public interface IOrganizationStudyHourDropDownService : IBaseDropDownCommand<OrganizationStudyHourDbo, OrganizationStudyHourDropDownDto>
    {
    }
}