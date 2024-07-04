using Core.DataTypes;
using EduServices.User.Dto;
using EduServices.User.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;


namespace EduApi.Controllers.Web.UserLogin
{
    [AllowAnonymous]
    public class UserLoginController : BaseWebController
    {
        private readonly IUserService _userService;

        public UserLoginController(IUserService userService, ILogger<UserLoginController> logger)
            : base(logger)
        {
            _userService = userService;
        }

        /// <summary>
        /// https://dev.azure.com/flexisoftware/MyEduGit/_wiki/wikis/MyEduGit.wiki?wikiVersion=GBwikiMaster&pagePath=%2FU%C5%BEivatelsk%C3%A9%20%C3%BA%C4%8Dty%2FREST%20slu%C5%BEby%2FCreateNewUser&pageId=72
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [AllowAnonymous]
        public ActionResult Register(UserCreateDto addUserDto)
        {
            try
            {
                addUserDto.SendActivateEmail = true;
                return SendResponse(_userService.AddObject(addUserDto, Guid.Empty, GetClientCulture()));
            }
            catch (Exception ex)
            {
                return SendSystemError(ex);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(LoginUserDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        public ActionResult LoginUser([FromQuery] LoginUserDto getUserTokenDto)
        {
            try
            {
                return SendResponse(_userService.LoginUser(getUserTokenDto));
            }
            catch (Exception ex)
            {
                return SendSystemError(ex);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(LoginUserDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        public ActionResult LoginUserAdmin([FromQuery] LoginUserAdminDto getUserTokenDto)
        {
            try
            {
                return SendResponse(_userService.LoginUser(getUserTokenDto));
            }
            catch (Exception ex)
            {
                return SendSystemError(ex);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(LoginUserDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        public ActionResult LoginUserSocialNetwork([FromQuery] LoginUserSocialNetworkDto getUserTokenDto)
        {
            try
            {
                return SendResponse(_userService.LoginSocialNetwork(getUserTokenDto, GetClientCulture()));
            }
            catch (Exception ex)
            {
                return SendSystemError(ex);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        public ActionResult ActivateUser(ActivateUserDto activateUserDto)
        {
            try
            {
                return SendResponse(_userService.ActivateUser(activateUserDto));
            }
            catch (Exception ex)
            {
                return SendSystemError(ex);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        public ActionResult GeneratePasswordResetEmail(GeneratePasswordResetEmailDto generatePasswordResetEmailDto)
        {
            try
            {
                return SendResponse(_userService.GeneratePasswordResetEmail(generatePasswordResetEmailDto, GetClientCulture()));
            }
            catch (Exception ex)
            {
                return SendSystemError(ex);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        public ActionResult SetNewPassword(SetNewPasswordDto setNewPasswordDto)
        {
            try
            {
                return SendResponse(_userService.SetNewPassword(setNewPasswordDto));
            }
            catch (Exception ex)
            {
                return SendSystemError(ex);
            }
        }
    }
}
