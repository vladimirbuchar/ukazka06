using System;
using Core.Base.Repository.CodeBookRepository;
using Core.Base.Repository.FileRepository;
using Core.Base.Service;
using Model.CodeBook;
using Model.Edu.Organization;
using Repository.OrganizationRepository;
using Services.Organization.Convertor;
using Services.Organization.Dto;
using Services.Organization.Validator;

namespace Services.Organization.Service
{
    public class OrganizationService(
        IOrganizationRepository organizationRepository,
        IOrganizationConvertor organizationConvertor,
        IOrganizationValidator validator,
        IFileUploadRepository<OrganizationFileRepositoryDbo> fileRepositoryDbo,
        ICodeBookRepository<CultureDbo> culture
    )
        : BaseService<
            IOrganizationRepository,
            OrganizationDbo,
            IOrganizationConvertor,
            IOrganizationValidator,
            OrganizationCreateDto,
            OrganizationListDto,
            OrganizationDetailDto,
            OrganizationUpdateDto,
            OrganizationFileRepositoryDbo
        >(organizationRepository, organizationConvertor, validator, fileRepositoryDbo, culture),
            IOrganizationService
    {
        public OrganizationDetailWebDto GetOrganizationDetailWeb(Guid organizationId)
        {
            return _convertor.ConvertToWebModelWeb(_repository.GetEntity(organizationId));
        }

        protected override bool IsChanged(OrganizationDbo oldVersion, OrganizationUpdateDto newVersion, string culture)
        {
            return oldVersion.Email != newVersion.Email || oldVersion.PhoneNumber != newVersion.PhoneNumber || oldVersion.WWW != newVersion.WWW || oldVersion.Name != newVersion.Name;
        }
    }
}
