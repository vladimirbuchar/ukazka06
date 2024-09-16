using Core.Base.Controller;
using Core.Base.Dto;
using Core.DataTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.User.ChangePassword.Command;
using UserService.User.ChangePassword.Dto;
using UserService.User.RefreshToken.Command;
using UserService.User.SetPassword.Command;
using UserService.User.SetPassword.Dto;
using UserService.User.UserDelete.Command;
using UserService.User.UserDetail.Command;
using UserService.User.UserDetail.Dto;
using UserService.User.UserUpdate.Dto;
using UserService.User.UserUpdate.Service;

namespace EduApi.Controllers.ClientZone.User
{
    [ApiExplorerSettings(GroupName = "User")]
    public class UserController : BaseClientZoneController
    {
        private readonly IRefreshTokenService _refreshToken;
        private readonly IUserDetailService _userDetailService;
        private readonly IUserUpdateService _updateUserService;
        private readonly IUserDeleteService _userDeleteService;
        private readonly IChangePasswordService _changePasswordService;
        private readonly ISetPasswordService _setPasswordService;

        public UserController(
            ISetPasswordService setPasswordService,
            IChangePasswordService changePasswordService,
            IUserDeleteService userDeleteService,
            IUserUpdateService updateUserService,
            IUserDetailService userDetailService,
            IRefreshTokenService refreshToken,
            ILogger<UserController> logger,
            EduDbContext organizationRoleService
        )
            : base(logger, organizationRoleService)
        {
            _refreshToken = refreshToken;
            _userDetailService = userDetailService;
            _updateUserService = updateUserService;
            _userDeleteService = userDeleteService;
            _changePasswordService = changePasswordService;
            _setPasswordService = setPasswordService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(UserDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Detail()
        {
            try
            {
                return await SendResponse(await _userDetailService.Execute(GetLoggedUserId(), new List<string>() { GetClientCulture() }));
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> RefreshToken()
        {
            try
            {
                return await SendResponse(await _refreshToken.Execute(GetLoggedUserId()));
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Update(UserUpdateDto updateUserDto)
        {
            try
            {
                return await SendResponse(await _updateUserService.Execute(updateUserDto, GetLoggedUserId(), GetClientCulture(), null));
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpDelete]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Delete([FromQuery] DeleteDto request)
        {
            try
            {
                return await SendResponse(await _userDeleteService.Execute(request.Id, GetLoggedUserId()));
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> ChangePassword(ChangePasswordDto changePasswordDto)
        {
            try
            {
                changePasswordDto.Id = GetLoggedUserId();
                return await SendResponse(await _changePasswordService.Execute(changePasswordDto, GetLoggedUserId(), GetClientCulture(), null));
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> SetPassword(SetPasswordDto setPasswordDto)
        {
            try
            {
                setPasswordDto.Id = GetLoggedUserId();
                return await SendResponse(await _setPasswordService.Execute(setPasswordDto, GetLoggedUserId(), GetClientCulture(), null));
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }
    }
}
