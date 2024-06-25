using Core.Base.Dto;
using Core.DataTypes;
using EduServices.OrganizationRole.Service;
using EduServices.User.Dto;
using EduServices.User.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace EduApi.Controllers.ClientZone.User
{
    [ApiExplorerSettings(GroupName = "User")]
    public class UserController : BaseClientZoneController
    {
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService, IOrganizationRoleService organizationRoleService)
            : base(logger, organizationRoleService)
        {
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(UserDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult Detail()
        {
            try
            {
                return SendResponse(_userService.GetDetail(GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult RefreshToken()
        {
            try
            {
                return SendResponse(_userService.RefreshToken(GetLoggedUserId()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult Update(UserUpdateDto updateUserDto)
        {
            try
            {
                return SendResponse(_userService.UpdateObject(updateUserDto, GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpDelete]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult Delete([FromQuery] DeleteDto request)
        {
            try
            {
                return SendResponse(_userService.DeleteObject(request.Id, GetLoggedUserId()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult ChangePassword(ChangePasswordDto changePasswordDto)
        {
            try
            {
                changePasswordDto.UserId = GetLoggedUserId();
                return SendResponse(_userService.ChangePassword(changePasswordDto));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult SetPassword(SetPasswordDto setPasswordDto)
        {
            try
            {
                setPasswordDto.UserId = GetLoggedUserId();
                return SendResponse(_userService.SetPassword(setPasswordDto));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
