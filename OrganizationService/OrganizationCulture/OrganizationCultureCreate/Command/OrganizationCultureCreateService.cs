using Core.Base.Command.Create;
using Core.DataTypes;
using Model.Link;
using OrganizationService.OrganizationCulture.OrganizationCultureCreate.Convertor;
using OrganizationService.OrganizationCulture.OrganizationCultureCreate.Dto;
using OrganizationService.OrganizationCulture.OrganizationCultureCreate.Validator;
using Repository.OrganizationCulture;

namespace OrganizationService.OrganizationCulture.OrganizationCultureCreate.Command
{
    public class OrganizationCultureCreateService
        : BaseCreateCommand<
            OrganizationCultureDbo,
            IOrganizationCultureRepository,
            OrganizationCultureCreateDto,
            IOrganizationCultureCreateConvertor,
            IOrganizationCultureCreateValidator
        >,
            IOrganizationCultureCreateService
    {
        public OrganizationCultureCreateService(
            IOrganizationCultureRepository repository,
            IOrganizationCultureCreateConvertor convertor,
            IOrganizationCultureCreateValidator validator
        )
            : base(repository, convertor, validator) { }

        public override async Task<ResultInsert> Execute(OrganizationCultureCreateDto addObject, Guid userId, string culture)
        {
            Result result = await _validator.IsValid(addObject);
            if (result.IsOk)
            {
                if (addObject.IsDefault == true)
                {
                    OrganizationCultureDbo organizationCultureDbo = await _repository.GetEntity(
                        false,
                        x => x.OrganizationId == addObject.OrganizationId && x.IsDefault == true
                    );
                    organizationCultureDbo.IsDefault = false;
                    _ = await _repository.UpdateEntity(organizationCultureDbo, userId);
                }
            }
            return await base.Execute(addObject, userId, culture);
        }
    }
}
