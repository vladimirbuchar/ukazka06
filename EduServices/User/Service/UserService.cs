using Core.Base.Service;
using Core.Constants;
using Core.DataTypes;
using Core.Extension;
using EduRepository.LinkLifeTimeRepository;
using EduRepository.OrganizationRepository;
using EduRepository.RoleRepository;
using EduRepository.UserInOrganizationRepository;
using EduRepository.UserRepository;
using EduServices.Organization.Convertor;
using EduServices.Organization.Dto;
using EduServices.Organization.Validator;
using EduServices.SystemService.SendMailService;
using EduServices.User.Convertor;
using EduServices.User.Dto;
using EduServices.User.Validator;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model.Tables.Edu.LinkLifeTime;
using Model.Tables.Edu.User;
using Model.Tables.Link;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EduServices.User.Service
{
    public class UserService(
        IUserRepository userRepository,
        IUserConvertor userConvertor,
        ILinkLifeTimeRepository linkLifeTimeRepository,
        IOrganizationRepository organizationRepository,
        IUserValidator validator,
        IOrganizationConvertor organizationConvertor,
        ISendMailService sendMailService,
        IConfiguration configuration,
        IRoleRepository roleRepository,
        IOrganizationValidator organizationValidator,
        IUserInOrganizationRepository userInOrganizationRepository
    ) : BaseService<IUserRepository, UserDbo, IUserConvertor, IUserValidator, UserCreateDto, UserListDto, UserDetailDto, UserUpdateDto>(userRepository, userConvertor, validator), IUserService
    {
        private readonly ISendMailService _sendMailService = sendMailService;
        private readonly IConfiguration _configuration = configuration;
        private readonly ILinkLifeTimeRepository _linkLifeTimeRepository = linkLifeTimeRepository;
        private readonly IOrganizationRepository _organizationRepository = organizationRepository;
        private readonly IOrganizationConvertor _organizationConvertor = organizationConvertor;
        private readonly IRoleRepository _roleRepository = roleRepository;
        private readonly IOrganizationValidator _organizationValidator = organizationValidator;
        private readonly IUserInOrganizationRepository _userInOrganizationRepository = userInOrganizationRepository;

        public override Result<UserDetailDto> AddObject(UserCreateDto addObject, Guid userId, string culture)
        {
            Result<UserDetailDto> result = _validator.IsValid(addObject);
            OrganizationCreateDto org = _organizationConvertor.ConvertToWebModelWebForUser(addObject.Organization);
            if (addObject.CreateNewOrganization)
            {
                _organizationValidator.ValidateUser = false;
                Result<OrganizationDetailDto> resultOrganization = _organizationValidator.IsValid(org);
                result.AddResultStatus(resultOrganization.Errors);

            }
            if (result.IsOk)
            {
                UserDbo entity = _convertor.ConvertToBussinessEntity(addObject, culture);
                entity.IsActive = false;
                entity.AllowCLassicLogin = true;
                entity.UserRoleId = _roleRepository.GetEntity(false, x => x.SystemIdentificator == UserRole.REGISTERED_USER).Id;
                entity = _repository.CreateEntity(entity, userId);

                if (addObject.CreateNewOrganization)
                {
                    org.UserId = entity.Id;
                    _ = _organizationRepository.CreateEntity(_organizationConvertor.ConvertToBussinessEntity(org, culture), entity.Id);
                }

                if (addObject.SendActivateEmail)
                {
                    Guid id = _linkLifeTimeRepository.CreateEntity(new LinkLifeTimeDbo() { UserId = entity.Id, EndTime = DateTime.Now.AddMinutes(30) }, Guid.Empty).Id;
                    Dictionary<string, string> replaceData =
                        new() { { ConfigValue.ACTIVATION_LINK, string.Format("{0}/?id={1}", _configuration.GetSection(ConfigValue.CLIENT_URL_ACTIVATE).Value, id) } };
                    _sendMailService.AddEmailToQueue(
                        EduEmail.REGISTRATION_USER,
                        culture,
                        new EmailAddress() { Email = addObject.UserEmail, Name = addObject.Person.FullName },
                        replaceData,
                        null,
                        ""
                    );
                }
                else
                {
                    entity.IsActive = true;
                    _ = _repository.UpdateEntity(entity, entity.Id);
                }

                result.Data = _convertor.ConvertToWebModel(entity, culture);
                return result;
            }
            return result;
        }

        private string GenerateJWTToken(UserTokenDto user)
        {
            JwtSecurityTokenHandler tokenHandler = new();
            byte[] key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("JWTKey"));

            SymmetricSecurityKey signingKey = new(key);
            SigningCredentials signingCredentials = new(signingKey, SecurityAlgorithms.HmacSha256Signature);

            JwtHeader header = new(signingCredentials)
            {
                ["kid"] = _configuration.GetValue<string>("JWTKid")
            };

            Claim[] claims =
            [
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.UserRole),
                new Claim(ClaimTypes.Email, user.UserEmail),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(Constants.UserOrganizationRole,JsonConvert.SerializeObject(user.OrganizationRole))
            ];



            JwtPayload payload = new(
                issuer: _configuration.GetValue<string>("JWTIssuer"),
                audience: _configuration.GetValue<string>("JWTAudience"),
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddHours(1)
            );

            JwtSecurityToken token = new(header, payload);
            return tokenHandler.WriteToken(token);
        }


        public string RefreshToken(Guid userId)
        {
            return GenerateJWTToken(_convertor.ConvertToWebModel(_repository.GetEntity(userId)));
        }
        public UserTokenDto LoginUser(LoginUserDto loginData)
        {
            UserDbo loginUser = _repository.LoginUser(loginData.UserEmail, loginData.UserPassword.GetHashString());
            if (loginUser != null)
            {
                if (loginData.OrganizationId != null && _userInOrganizationRepository.GetEntity(false, x => x.UserId == loginUser.Id && x.OrganizationId == loginData.OrganizationId) == null)
                {
                    return null;
                }

                UserTokenDto user = _convertor.ConvertToWebModel(loginUser);
                if (user.UserRole == UserRole.REGISTERED_USER)
                {
                    HashSet<UserInOrganizationDbo> roles = _userInOrganizationRepository.GetEntities(false, x => x.UserId == loginUser.Id);
                    foreach (UserInOrganizationDbo role in roles)
                    {
                        if (!user.OrganizationRole.TryGetValue(role.OrganizationId, out List<string> value))
                        {
                            user.OrganizationRole.Add(role.OrganizationId, [role.OrganizationRole.SystemIdentificator]);
                        }
                        else
                        {
                            value.Add(role.OrganizationRole.SystemIdentificator);
                        }
                    }
                }
                user.Token = GenerateJWTToken(user);
                return user;
            }
            return null;
        }

        public Result ActivateUser(ActivateUserDto activateUser)
        {
            Result validate = _validator.IsValidActivateUser(activateUser);
            if (validate.IsOk)
            {
                LinkLifeTimeDbo link = _linkLifeTimeRepository.GetLinkWithUser(activateUser.LinkId);
                UserDbo user = link.User;
                if (user != null)
                {
                    user.IsActive = true;
                    _ = _repository.UpdateEntity(user, user.Id);
                    _linkLifeTimeRepository.DeleteEntity(link, user.Id);
                }
            }
            return validate;
        }

        public void ChangePassword(Guid userId, string newPassword)
        {
            UserDbo user = _repository.GetEntity(userId);
            if (user != null)
            {
                user.UserPassword = newPassword.GetHashString();
                _ = _repository.UpdateEntity(user, userId);
            }
        }

        private void SetPassword(Guid userId, string newPassword)
        {
            UserDbo user = _repository.GetEntity(userId);
            if (user != null && user.AllowCLassicLogin == false)
            {
                user.UserPassword = newPassword.GetHashString();
                user.AllowCLassicLogin = true;
                _ = _repository.UpdateEntity(user, userId);
            }
        }

        public UserTokenDto LoginSocialNetwork(LoginUserSocialNetworkDto loginSocialNetwork, string culture)
        {
            if (loginSocialNetwork.UserEmail.IsNullOrEmptyWithTrim() || loginSocialNetwork.Id.IsNullOrEmptyWithTrim())
            {
                return null;
            }
            UserDbo detail = _repository.GetEntity(false, x => x.UserEmail == loginSocialNetwork.UserEmail);
            UserDbo loginUser = new();
            if (detail == null)
            {
                string password = string.Format("{0}#{1}#{2}", loginSocialNetwork.Id, loginSocialNetwork.Type, loginSocialNetwork.UserEmail);
                _ = AddObject(
                    new UserCreateDto()
                    {
                        UserEmail = loginSocialNetwork.UserEmail,
                        UserPassword = password,
                        UserPassword2 = password,
                        Person = new PersonDto()
                        {
                            Address = [],
                            FirstName = loginSocialNetwork.FirstName,
                            LastName = loginSocialNetwork.LastName.Trim().Trim(',').Trim(),
                            SecondName = "",
                            AvatarUrl = loginSocialNetwork.Avatar
                        },
                        OrganizationId = loginSocialNetwork.OrganizationId.Value,
                        SendActivateEmail = false,
                        AllowClassicLogin = false
                    },
                    Guid.Empty,
                    culture
                );
                detail = _repository.GetEntity(false, x => x.UserEmail == loginSocialNetwork.UserEmail);
            }
            if (loginSocialNetwork.OrganizationId != null)
            {
                if (_userInOrganizationRepository.GetEntity(false, x => x.IsDeleted == false && x.UserId == detail.Id && x.OrganizationId == loginSocialNetwork.OrganizationId) == null)
                {
                    return null;
                }
            }
            if (loginSocialNetwork.Type == Constants.GOOGLE)
            {
                loginUser = _repository.GetEntity(false, x => x.Id == detail.Id);
                loginUser.GoogleId = loginSocialNetwork.Id;
                loginUser.Person.AvatarUrl = loginSocialNetwork.Avatar;
                _ = _repository.UpdateEntity(loginUser, Guid.Empty);
                loginUser = _repository.GetEntity(false, x => x.Id == detail.Id && x.GoogleId == loginSocialNetwork.Id);
            }
            if (loginSocialNetwork.Type == Constants.FACEBOOK)
            {
                loginUser = _repository.GetEntity(false, x => x.Id == detail.Id);
                loginUser.FacebookId = loginSocialNetwork.Id;
                loginUser.Person.AvatarUrl = loginSocialNetwork.Avatar;
                _ = _repository.UpdateEntity(loginUser, Guid.Empty);
                loginUser = _repository.GetEntity(false, x => x.Id == detail.Id && x.FacebookId == loginSocialNetwork.Id);
            }
            UserTokenDto userTokenDto = _convertor.ConvertToWebModel(loginUser);
            userTokenDto.Token = GenerateJWTToken(userTokenDto);
            return userTokenDto;
        }

        public void GeneratePasswordResetEmail(GeneratePasswordResetEmailDto generatePasswordResetEmailDto, string clientCulture)
        {
            UserDbo userDetail = _repository.GetEntity(false, x => x.UserEmail == generatePasswordResetEmailDto.UserEmail);

            if (userDetail != null)
            {
                Guid id = _linkLifeTimeRepository.CreateEntity(new LinkLifeTimeDbo() { UserId = userDetail.Id, EndTime = DateTime.Now.AddMinutes(30) }, userDetail.Id).Id;
                Dictionary<string, string> replace =
                    new() { { ConfigValue.PASSWORD_RESET_LINK, string.Format("{0}/?id={1}", _configuration.GetSection(ConfigValue.CLIENT_URL_RESET_PASSWORD).Value, id) } };

                _sendMailService.AddEmailToQueue(EduEmail.PASSWORD_RESET, clientCulture, new EmailAddress() { Email = userDetail.UserEmail }, replace);
            }
        }

        public Result SetNewPassword(SetNewPasswordDto setNewPasswordDto)
        {
            Result validate = _validator.IsValidSetNewPassword(setNewPasswordDto);
            if (validate.IsOk)
            {
                LinkLifeTimeDbo link = _linkLifeTimeRepository.GetLinkWithUser(setNewPasswordDto.LinkId);
                UserDbo user = link.User;
                if (user != null)
                {
                    user.UserPassword = setNewPasswordDto.Password1.GetHashString();
                    _ = _repository.UpdateEntity(user, user.Id);
                    _linkLifeTimeRepository.DeleteEntity(link, user.Id);
                }
            }
            return validate;
        }

        public Result ChangePassword(ChangePasswordDto changePassword)
        {
            Result validate = _validator.ChangePasswordValidate(changePassword);
            if (validate.IsOk)
            {
                ChangePassword(changePassword.UserId, changePassword.NewUserPassword);
            }
            return validate;
        }

        public Result SetPassword(SetPasswordDto setPasswordDto)
        {
            Result validate = _validator.SetPasswordValidate(setPasswordDto);
            if (validate.IsOk)
            {
                SetPassword(setPasswordDto.UserId, setPasswordDto.NewUserPassword);
            }
            return validate;
        }

        public UserTokenDto LoginUser(LoginUserAdminDto loginData)
        {
            UserDbo loginUser = _repository.LoginUser(loginData.UserEmail, loginData.UserPassword.GetHashString());
            if (loginUser != null)
            {
                UserTokenDto user = _convertor.ConvertToWebModel(loginUser);
                if (user.UserRole != UserRole.ADMINISTRATOR)
                {
                    return null;
                }
                user.Token = GenerateJWTToken(user);
                return user;
            }
            return null;
        }
    }
}
