using Core.Base.Command.DropDown;
using Model.Edu.OrganizationStudyHour;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourDropDown.Convertor;
using OrganizationService.OrganizationStudyHour.OrganizationStudyHourDropDown.Dto;
using Repository.OrganizationHoursRepository;

namespace OrganizationService.OrganizationStudyHour.OrganizationStudyHourDropDown.Service
{
    public class OrganizationStudyHourDropDownService : BaseDropDownCommand<OrganizationStudyHourDbo, IOrganizationStudyHourRepository, OrganizationStudyHourDropDownDto, IOrganizationStudyHourDropDownConvertor>, IOrganizationStudyHourDropDownService
    {
        public OrganizationStudyHourDropDownService(IOrganizationStudyHourRepository repository, IOrganizationStudyHourDropDownConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
