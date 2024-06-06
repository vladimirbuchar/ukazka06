using Core.Base.Dto;
using Core.Constants;
using Core.DataTypes;
using EduServices.Course.Service;
using EduServices.OrganizationRole.Dto;
using EduServices.OrganizationRole.Service;
using EduServices.UserInOrganization.Dto;
using EduServices.UserInOrganization.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace EduApi.Controllers.ClientZone.UserInOrganization
{
    [ApiExplorerSettings(GroupName = "Organization")]
    public class UserInOrganizationController : BaseClientZoneController
    {
        private readonly IUserInOrganizationService _userInOrganizationService;

        public UserInOrganizationController(
            ILogger<UserInOrganizationController> logger,
            IUserInOrganizationService organizationSettingService,
            IOrganizationRoleService organizationRoleService,
            ICourseService courseService
        )
            : base(logger, organizationRoleService)
        {
            _userInOrganizationService = organizationSettingService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult Create(UserInOrganizationCreateDto addUserToOrganizationDto)
        {
            try
            {
                CheckPermition(addUserToOrganizationDto.OrganizationId);
                return SendResponse(_userInOrganizationService.AddObject(addUserToOrganizationDto, GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<UserInOrganizationListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult List([FromQuery] ListDeletedRequestDto list)
        {
            try
            {
                CheckPermition(list.ParentId);
                return SendResponse(_userInOrganizationService.GetList(x => x.OrganizationId == list.ParentId, list.IsDeleted));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(UserInOrganizationDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult Detail(Guid userId, Guid organizationId)
        {
            try
            {
                CheckPermition(organizationId);
                return SendResponse(_userInOrganizationService.GetDetail(x => x.UserId == userId && x.OrganizationId == organizationId, GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(void), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult Update(UserInOrganizationUpdateDto updateUserInOrganizationRoleDto)
        {
            try
            {
                CheckPermition(updateUserInOrganizationRoleDto.OrganizationId);
                return SendResponse(_userInOrganizationService.UpdateObject(updateUserInOrganizationRoleDto, GetLoggedUserId(), GetClientCulture()));
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
        public ActionResult Delete(Guid userId, Guid organizationId)
        {
            try
            {
                CheckPermition(organizationId);
                _userInOrganizationService.MultipleDelete(
                    x => x.UserId == userId && x.OrganizationId == organizationId && x.SystemIdentificator != OrganizationRole.ORGANIZATION_OWNER,
                    GetLoggedUserId()
                );
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(UserOrganizationRoleDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult Check([FromQuery] Guid objectId, [FromQuery] string type)
        {
            try
            {
                if (type == "branch")
                {
                    objectId = GetOrganizationIdByBranch(objectId);
                }
                else if (type == "classroom")
                {
                    objectId = GetOrganizationIdByClassRoom(objectId);
                }
                else if (type == "userinorganization")
                {
                    objectId = GetOrganizationByUserInOrganization(objectId);
                }
                else if (type == "question")
                {
                    objectId = GetOrganizationByQuestion(objectId);
                }
                else if (type == "answer")
                {
                    objectId = GetOrganizationByAnswer(objectId);
                }
                else if (type == "bankOfQuestion")
                {
                    objectId = GetOrganizationIdByBankOfQuestion(objectId);
                }
                else if (type == "course")
                {
                    objectId = GetOrganizationIdByCourse(objectId);
                }
                else if (type == "courseLesson")
                {
                    objectId = GetOrganizationByCourseLesson(objectId);
                }
                else if (type == "courseLessonItem")
                {
                    objectId = GetOrganizationByCourseLessonItem(objectId);
                }
                else if (type == "courseTerm")
                {
                    objectId = GetOrganizationIdByCourseTerm(objectId);
                }
                else if (type == "question")
                {
                    objectId = GetOrganizationByQuestion(objectId);
                }
                else if (type == "certificate")
                {
                    objectId = GetOrganizationByCertificate(objectId);
                }
                else if (type == "sendmessage")
                {
                    objectId = GetOrganizationBySendMessage(objectId);
                }
                else if (type == "studentgroup")
                {
                    objectId = GetOrganizationByStudentGroupId(objectId);
                }
                else if (type == "coursematerialedit")
                {
                    objectId = GetOrganizationByCourseMaterial(objectId);
                }
                else if (type == "courseBrowse")
                {
                    return SendResponse(_userInOrganizationService.CanCourseBrowse(objectId, GetLoggedUserId()));
                }
                else if (type == "showStudentTestResult")
                {
                    return SendResponse(_userInOrganizationService.CanShowStudentTestResult(objectId, GetLoggedUserId()));
                }
                return SendResponse(_userInOrganizationService.GetDetail(x => x.UserId == GetLoggedUserId() && x.OrganizationId == objectId, GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<OrganizationRoleListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetOrganizationRoles()
        {
            try
            {
                return SendResponse(_userInOrganizationService.GetOrganizationRoles());
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
