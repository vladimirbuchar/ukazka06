using Core.Base.Command.Detail;
using Model.Edu.Organization;
using OrganizationService.Organization.OrganizationDetail.Convertor;
using OrganizationService.Organization.OrganizationDetail.Dto;
using Repository.Organization;

namespace OrganizationService.Organization.OrganizationDetail.Command
{
    public class OrganizationDetailService
        : BaseDetailCommand<OrganizationDbo, IOrganizationRepository, OrganizationDetailDto, IOrganizationDetailConvertor>,
            IOrganizationDetailService
    {
        public OrganizationDetailService(IOrganizationRepository repository, IOrganizationDetailConvertor convertor)
            : base(repository, convertor) { }
    }
}
