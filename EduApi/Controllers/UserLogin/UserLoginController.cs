using CodebookService.CultureDetail.Command;
using Core.Base.Controller;
using Core.Constants;
using Core.DataTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OrganizationService.SendMail.SendMailCreate.Command;
using OrganizationService.SendMail.SendMailCreate.Dto;
using Services.Email.EmailDetail.Command;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.LinkLifeTime.LinkLifeTimeCreate.Command;
using UserService.LinkLifeTime.LinkLifeTimeCreate.Dto;
using UserService.LinkLifeTime.LinkLifeTimeDelete.Command;
using UserService.LinkLifeTime.LinkLifeTimeDetail.Command;
using UserService.LinkLifeTime.LinkLifeTimeDetail.Dto;
using UserService.Role.RoleDetail.Command;
using UserService.User.ActivateUser.Command;
using UserService.User.ActivateUser.Dto;
using UserService.User.GeneratePassword.Command;
using UserService.User.GeneratePasswordResetEmail.Dto;
using UserService.User.GetUserToken.Command;
using UserService.User.GetUserToken.Dto;
using UserService.User.GetUserTokenAdmin.Command;
using UserService.User.GetUserTokenAdmin.Dto;
using UserService.User.GetUserTokenBysocialNetwork.Command;
using UserService.User.GetUserTokenBysocialNetwork.Dto;
using UserService.User.RegisterUser.Command;
using UserService.User.RegisterUser.Dto;
using UserService.User.SetNewPassword.Command;
using UserService.User.SetNewPassword.Dto;
using UserService.User.UserDetail.Command;

namespace PublicApi.Controllers.UserLogin
{
    [AllowAnonymous]
    public class UserLoginController : BaseWebController
    {
        private readonly IGetUserTokenService _getUserTokenService;
        private readonly IGetUserTokenAdminService _getUserTokenAdmin;
        private readonly IGetUserTokenBysocialNetworkService _getUserTokenBysocialNetwork;
        private readonly IActivateUserService _activateUserService;
        private readonly ISetNewPasswordService _setNewPassword;
        private readonly IRegisterUserService _registerUser;
        private readonly IUserDetailService _userDetailService;
        private readonly IGeneratePasswordService _generatePasswordService;
        private readonly IRoleDetailService _roleDetailService;
        private readonly ILinkLifeTimeServiceDetailService _linkLifeTimeServiceDetailService;
        private readonly ILinkLifeTimeDeleteService _linkLifeTimeDeleteService;
        private readonly ILinkLifeTimeServiceCreateService _linkLifeTimeServiceCreateService;
        private readonly IConfiguration _configuration;
        private readonly IEmailDetailService _emailDetailService;
        private readonly ISendMailCreateService _sendMailCreateService;
        private readonly ICultureDetailCommand _cultureDetailCommand;

        public UserLoginController(
            IUserDetailService userDetailService,
            IRegisterUserService registerUser,
            ISetNewPasswordService setNewPassword,
            IActivateUserService activateUser,
            IGetUserTokenBysocialNetworkService getUserTokenBysocialNetwork,
            IGetUserTokenService getUserTokenService,
            IGetUserTokenAdminService getUserTokenAdmin,
            IGeneratePasswordService generatePasswordService,
            IRoleDetailService roleDetailService,
            ILinkLifeTimeServiceDetailService linkLifeTimeServiceDetailService,
            ILinkLifeTimeDeleteService linkLifeTimeDeleteService,
            ILinkLifeTimeServiceCreateService linkLifeTimeServiceCreateService,
            IConfiguration configuration,
            IEmailDetailService emailDetailService,
            ISendMailCreateService sendMailCreateService,
            ICultureDetailCommand cultureDetailCommand,

            ILogger<UserLoginController> logger
        )
            : base(logger)
        {
            _getUserTokenService = getUserTokenService;
            _getUserTokenAdmin = getUserTokenAdmin;
            _getUserTokenBysocialNetwork = getUserTokenBysocialNetwork;
            _activateUserService = activateUser;
            _setNewPassword = setNewPassword;
            _registerUser = registerUser;
            _userDetailService = userDetailService;
            _generatePasswordService = generatePasswordService;
            _roleDetailService = roleDetailService;
            _linkLifeTimeServiceDetailService = linkLifeTimeServiceDetailService;
            _linkLifeTimeDeleteService = linkLifeTimeDeleteService;
            _configuration = configuration;
            _emailDetailService = emailDetailService;
            _cultureDetailCommand = cultureDetailCommand;
            _linkLifeTimeServiceCreateService = linkLifeTimeServiceCreateService;
            _sendMailCreateService = sendMailCreateService;
        }


        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [AllowAnonymous]
        public async Task<ActionResult> Register(UserCreateDto addUserDto)
        {
            try
            {
                Result isValidUser = await _registerUser.IsValid(addUserDto);
                if (isValidUser.IsOk)
                {
                    Guid roleId = (await _roleDetailService.Execute(x => x.SystemIdentificator == UserRole.REGISTERED_USER, new List<string>() { GetClientCulture() })).Id;
                    addUserDto.RoleId = roleId;
                    addUserDto.AllowClassicLogin = true;
                    var user = await _registerUser.Execute(addUserDto, Guid.Empty, GetClientCulture());
                    Guid linkId = (await _linkLifeTimeServiceCreateService.Execute(new LinkLifeTimeServiceCreateDto()
                    {
                        UserId = user.InsertedId,
                        EndTime = DateTime.Now.AddMinutes(30)
                    }, GetLoggedUserId(), GetClientCulture())).InsertedId;

                    Dictionary<string, object> replaceData =
                        new()
                        {
                            {
                                ConfigValue.ACTIVATION_LINK,
                                string.Format("{0}/?id={1}", _configuration.GetSection(ConfigValue.CLIENT_URL_ACTIVATE).Value, linkId)
                            }
                        };

                    var emailDetail = await _emailDetailService.Execute(x => x.EmailType.SystemIdentificator == EduEmail.REGISTRATION_USER, new List<string>() { GetClientCulture() }, replaceData);
                    await _sendMailCreateService.Execute(new SendMailCreateDto()
                    {
                        Body = emailDetail.EmailBodyHtml,
                        EmailFrom = emailDetail.From,
                        IsHtml = emailDetail.IsHtml,
                        Subject = emailDetail.Subject,
                        PlainTextBody = emailDetail.EmailBodyPlainText,
                        EmailTo = addUserDto.UserEmail,
                        EmailToName = addUserDto.Person.FullName,
                        Reply = "",
                        CultureId = (await _cultureDetailCommand.Execute(x => x.SystemIdentificator == GetClientCulture(), new List<string>() { GetClientCulture() })).Id,
                        OrganizationId = null,
                    }, GetLoggedUserId(), GetClientCulture());
                    return await SendResponse(user);
                }
                return await SendResponse(isValidUser);
            }
            catch (Exception ex)
            {
                return await SendSystemError(ex);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetUserTokenDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        public async Task<ActionResult> LoginUser([FromQuery] GetUserTokenDto getUserTokenDto)
        {
            try
            {
                return await SendResponse(await _getUserTokenService.Execute(getUserTokenDto));
            }
            catch (Exception ex)
            {
                return await SendSystemError(ex);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetUserTokenDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        public async Task<ActionResult> LoginUserAdmin([FromQuery] LoginUserAdminDto getUserTokenDto)
        {
            try
            {
                return await SendResponse(await _getUserTokenAdmin.Execute(getUserTokenDto));
            }
            catch (Exception ex)
            {
                return await SendSystemError(ex);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetUserTokenDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        public async Task<ActionResult> LoginUserSocialNetwork([FromQuery] LoginUserSocialNetworkDto getUserTokenDto)
        {
            try
            {
                return await SendResponse(await _getUserTokenBysocialNetwork.Execute(getUserTokenDto, GetClientCulture()));
            }
            catch (Exception ex)
            {
                return await SendSystemError(ex);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        public async Task<ActionResult> ActivateUser(ActivateUserDto activateUserDto)
        {
            try
            {
                LinkLifeTimeServiceDetailDto linkDetail = await _linkLifeTimeServiceDetailService.Execute(x => x.Id == activateUserDto.LinkId && x.EndTime >= DateTime.Now, new List<string>() { GetClientCulture() });
                Result result = new Result();
                if (linkDetail == null)
                {
                    result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.USER, Constants.LINK_IS_NOT_VALID));
                }
                if (result.IsOk)
                {
                    await _activateUserService.Execute(new ChangeUserActiveDto()
                    {
                        Id = linkDetail.UserId,
                        IsActive = true
                    }, GetLoggedUserId(), GetClientCulture(), null);
                    await _linkLifeTimeDeleteService.Execute(linkDetail.Id, GetLoggedUserId());
                }
                return await SendResponse(result);
            }
            catch (Exception ex)
            {
                return await SendSystemError(ex);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        public async Task<ActionResult> GeneratePasswordResetEmail(GeneratePasswordResetEmailDto generatePasswordResetEmailDto)
        {
            try
            {
                var user = await _userDetailService.Execute(x => x.UserEmail == generatePasswordResetEmailDto.UserEmail, new List<string>() { GetClientCulture() });
                if (user != null)
                {
                    Guid linkId = (await _linkLifeTimeServiceCreateService.Execute(new LinkLifeTimeServiceCreateDto()
                    {
                        EndTime = DateTime.Now.AddMinutes(30),
                        UserId = user.Id,
                    }, GetLoggedUserId(), GetClientCulture())).InsertedId;


                    Dictionary<string, object> replace =
                    new()
                    {
                        {
                            ConfigValue.PASSWORD_RESET_LINK,
                            string.Format("{0}/?id={1}", _configuration.GetSection(ConfigValue.CLIENT_URL_RESET_PASSWORD).Value, linkId)
                        }
                    };
                    var emailDetail = await _emailDetailService.Execute(x => x.EmailType.SystemIdentificator == EduEmail.PASSWORD_RESET, new List<string>() { GetClientCulture() }, replace);
                    return await SendResponse(await _sendMailCreateService.Execute(new SendMailCreateDto()
                    {
                        Body = emailDetail.EmailBodyHtml,
                        EmailFrom = emailDetail.From,
                        IsHtml = emailDetail.IsHtml,
                        Subject = emailDetail.Subject,
                        PlainTextBody = emailDetail.EmailBodyPlainText,
                        EmailTo = generatePasswordResetEmailDto.UserEmail,
                        EmailToName = user.Person.FullName,
                        Reply = "",
                        CultureId = (await _cultureDetailCommand.Execute(x => x.SystemIdentificator == GetClientCulture(), new List<string>() { GetClientCulture() })).Id
                    }, GetLoggedUserId(), GetClientCulture()));

                }
                return await SendResponse(new Result());

            }
            catch (Exception ex)
            {
                return await SendSystemError(ex);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        public async Task<ActionResult> SetNewPassword(SetNewPasswordDto setNewPasswordDto)
        {
            try
            {
                return await SendResponse(await _setNewPassword.Execute(setNewPasswordDto));
            }
            catch (Exception ex)
            {
                return await SendSystemError(ex);
            }
        }
    }
}
