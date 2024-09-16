using Core.Base.Command.Detail;
using Model.Edu.Organization;
using OrganizationService.Organization.OrganizationWebDetail.Convertor;
using OrganizationService.Organization.OrganizationWebDetail.Dto;
using Repository.Organization;

namespace OrganizationService.Organization.OrganizationWebDetail.Command
{
    public class OrganizationWebDetail
        : BaseDetailCommand<OrganizationDbo, IOrganizationRepository, OrganizationDetailWebDto, IOrganizationWebDetailConvertor>,
            IOrganizationWebDetail
    {
        public OrganizationWebDetail(IOrganizationRepository repository, IOrganizationWebDetailConvertor convertor)
            : base(repository, convertor) { }
    }
}
