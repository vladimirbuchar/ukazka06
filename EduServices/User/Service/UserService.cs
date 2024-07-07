using Core.Base.Service;
using Core.Constants;
using Core.DataTypes;
using Core.Extension;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model.Edu.LinkLifeTime;
using Model.Edu.User;
using Model.Link;
using Newtonsoft.Json;
using Repository.LinkLifeTimeRepository;
using Repository.OrganizationRepository;
using Repository.RoleRepository;
using Repository.UserInOrganizationRepository;
using Repository.UserRepository;
using Services.Organization.Convertor;
using Services.Organization.Dto;
using Services.Organization.Validator;
using Services.SystemService.SendMailService;
using Services.User.Convertor;
using Services.User.Dto;
using Services.User.Validator;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Services.User.Service
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
                new Claim(Constants.USER_ORGANIZATION_ROLE,JsonConvert.SerializeObject(user.OrganizationRole))
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
            UserDbo loginUser = _repository.GetEntity(false, x => x.UserEmail == loginData.UserEmail && x.UserPassword == loginData.UserPassword.GetHashString() && x.IsActive == true && x.AllowCLassicLogin == true);
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
                    if (loginData.OrganizationId != null)
                    {
                        roles = roles.Where(x => x.OrganizationId == loginData.OrganizationId).ToHashSet();
                    }
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
                LinkLifeTimeDbo link = _linkLifeTimeRepository.GetEntity(activateUser.LinkId);
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

        public Result ChangePassword(Guid userId, string newPassword)
        {
            UserDbo user = _repository.GetEntity(userId);
            if (user != null)
            {
                user.UserPassword = newPassword.GetHashString();
                _ = _repository.UpdateEntity(user, userId);
            }
            return new Result();
        }

        private Result SetPassword(Guid userId, string newPassword)
        {
            UserDbo user = _repository.GetEntity(userId);
            if (user != null && user.AllowCLassicLogin == false)
            {
                user.UserPassword = newPassword.GetHashString();
                user.AllowCLassicLogin = true;
                _ = _repository.UpdateEntity(user, userId);
            }
            return new Result();
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
                if (_userInOrganizationRepository.GetEntity(false, x => x.UserId == detail.Id && x.OrganizationId == loginSocialNetwork.OrganizationId) == null)
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

        public Result GeneratePasswordResetEmail(GeneratePasswordResetEmailDto generatePasswordResetEmailDto, string clientCulture)
        {
            UserDbo userDetail = _repository.GetEntity(false, x => x.UserEmail == generatePasswordResetEmailDto.UserEmail);

            if (userDetail != null)
            {
                Guid id = _linkLifeTimeRepository.CreateEntity(new LinkLifeTimeDbo() { UserId = userDetail.Id, EndTime = DateTime.Now.AddMinutes(30) }, userDetail.Id).Id;
                Dictionary<string, string> replace =
                    new() { { ConfigValue.PASSWORD_RESET_LINK, string.Format("{0}/?id={1}", _configuration.GetSection(ConfigValue.CLIENT_URL_RESET_PASSWORD).Value, id) } };

                _sendMailService.AddEmailToQueue(EduEmail.PASSWORD_RESET, clientCulture, new EmailAddress() { Email = userDetail.UserEmail }, replace);
            }
            return new Result();
        }

        public Result SetNewPassword(SetNewPasswordDto setNewPasswordDto)
        {
            Result validate = _validator.IsValidSetNewPassword(setNewPasswordDto);
            if (validate.IsOk)
            {
                LinkLifeTimeDbo link = _linkLifeTimeRepository.GetEntity(setNewPasswordDto.LinkId);
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
                _ = ChangePassword(changePassword.UserId, changePassword.NewUserPassword);
            }
            return validate;
        }

        public Result SetPassword(SetPasswordDto setPasswordDto)
        {
            Result validate = _validator.SetPasswordValidate(setPasswordDto);
            if (validate.IsOk)
            {
                _ = SetPassword(setPasswordDto.UserId, setPasswordDto.NewUserPassword);
            }
            return validate;
        }

        public UserTokenDto LoginUser(LoginUserAdminDto loginData)
        {
            UserDbo loginUser = _repository.GetEntity(false, x => x.UserEmail == loginData.UserEmail && x.UserPassword == loginData.UserPassword.GetHashString() && x.IsActive == true && x.AllowCLassicLogin == true);
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
        public override Result DeleteObject(Guid objectId, Guid userId)
        {
            if (_userInOrganizationRepository.GetEntity(false, x => x.UserId == objectId && x.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.ORGANIZATION_OWNER) == null)
            {
                return base.DeleteObject(objectId, userId);
            }
            Result result = new();
            result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.USER, MessageItem.CAN_NOT_DELETE));
            return result;
        }




    }
}
