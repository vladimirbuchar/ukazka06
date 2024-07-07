using Core.Base.Validator;
using Model.Link;
using Repository.UserInOrganizationRepository;
using Services.UserInOrganization.Dto;

namespace Services.UserInOrganization.Validator
{
    public interface IUserInOrganizationValidator
        : IBaseValidator<UserInOrganizationDbo, IUserInOrganizationRepository, UserInOrganizationCreateDto, UserInOrganizationDetailDto, UserInOrganizationUpdateDto> { }
}
