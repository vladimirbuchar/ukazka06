using Core.DataTypes;
using EduApi.Controllers.ClientZone.Certificate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Organization.Dto;
using Services.OrganizationRole.Service;
using Services.StudentEvaluation.Dto;
using Services.User.Dto;
using Services.UserProfile.Dto;
using Services.UserProfile.Service;
using System;
using System.Collections.Generic;

namespace EduApi.Controllers.ClientZone.UserProfile
{
    [ApiExplorerSettings(GroupName = "User")]
    public class UserProfileController : BaseClientZoneController
    {
        private readonly IUserProfileService _userProfileService;

        public UserProfileController(
            IUserProfileService userProfileService,
            ILogger<CertificateController> logger,
            IOrganizationRoleService organizationRoleService
        )
            : base(logger, organizationRoleService)
        {
            _userProfileService = userProfileService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MyCertificateListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetMyCertificate()
        {
            try
            {
                return SendResponse(_userProfileService.GetMyCertificate(GetLoggedUserId()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MyCourseListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetMyCourse([FromQuery] bool hideFinishCourse)
        {
            try
            {
                return SendResponse(_userProfileService.GetMyCourse(GetLoggedUserId(), hideFinishCourse, GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<MyTimeTableListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetMyTimeTable()
        {
            try
            {

                return SendResponse(_userProfileService.GetMyTimeTable(GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<MyAttendanceListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetMyAttendance()
        {
            try
            {

                return SendResponse(_userProfileService.GetMyAttendance(GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MyOrganizationListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetMyOrganizations()
        {
            try
            {
                return SendResponse(_userProfileService.GetMyOrganization(GetLoggedUserId()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ManagedCourseListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetManagedCourse()
        {
            try
            {
                return SendResponse(_userProfileService.GetManagedCourse(GetLoggedUserId()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
        [HttpGet]
        [ProducesResponseType(typeof(HashSet<MyEvaluationListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetMyEvaluation([FromQuery] Guid userId)
        {
            try
            {
                return SendResponse(_userProfileService.GetMyEvaluation(GetLoggedUserId()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
