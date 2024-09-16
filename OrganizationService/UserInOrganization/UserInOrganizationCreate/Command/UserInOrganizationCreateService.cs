using Core.Base.Command.Create;
using Core.DataTypes;
using Model.Link;
using OrganizationService.UserInOrganization.UserInOrganizationCreate.Dto;
using OrganizationService.UserInOrganization.UserInOrganizationCreate.Validator;
using Repository.UserInOrganization;

namespace OrganizationService.UserInOrganization.UserInOrganizationCreate.Command
{
    public class UserInOrganizationCreateService(IUserInOrganizationRepository repository, IUserInOrganizationCreateValidator validator)
                : BaseCreateCommand<UserInOrganizationDbo, IUserInOrganizationRepository, AddUserToOrganization, IUserInOrganizationCreateValidator>(repository, validator),
            IUserInOrganizationCreateService
    {
        public override async Task<ResultInsert> Execute(AddUserToOrganization addObject, Guid userId, string culture)
        {
            ResultInsert resultInsert = new();
            foreach (Guid role in addObject.OrganizationRoleId)
            {
                ResultInsert isValid = await _validator.IsValid(addObject);
                if (isValid.IsOk)
                {
                    UserInOrganizationDbo entity = await _repository.CreateEntity(
                        new UserInOrganizationDbo()
                        {
                            OrganizationId = addObject.OrganizationId,
                            OrganizationRoleId = role,
                            UserId = addObject.UserId
                        },
                        userId
                    );
                    resultInsert.InsertedId = entity.Id;
                }
                resultInsert.AddResultStatus(isValid.Errors);
            }
            return resultInsert;
        }
    }
}
