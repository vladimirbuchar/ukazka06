using Core.Constants;
using Core.Exceptions;
using EduServices.OrganizationRole.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace EduApi.Controllers.ClientZone
{
    [Route("api/clientzone/[controller]/[action]")]
    [Authorize(Policy = "ClientPolicy")]
    [ApiExplorerSettings(GroupName = "ClientZone")]
    public class BaseClientZoneController : BaseController
    {
        private readonly IOrganizationRoleService _organizationRoleService;
        public BaseClientZoneController(ILogger<BaseClientZoneController> logger, IOrganizationRoleService organizationRoleService)
            : base(logger)
        {
            _organizationRoleService = organizationRoleService;
        }

        private Dictionary<Guid, List<string>> GetUserRoleInOrganization()
        {
            var handler = new JwtSecurityTokenHandler();
            string authHeader = Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value;
            if (authHeader == null)
            {
                return new Dictionary<Guid, List<string>>();
            }
            authHeader = authHeader.Replace("Bearer ", "");
            var jsonToken = handler.ReadToken(authHeader);
            var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;
            return JsonConvert.DeserializeObject<Dictionary<Guid, List<string>>>(tokenS.Claims.FirstOrDefault(x => x.Type == Constants.UserOrganizationRole).Value);
        }

        /// <summary>
        /// check user permition in organization
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="organizationId"></param>
        /// <param name="operationType"></param>
        protected void CheckPermition(Guid organizationId)
        {
            if (_organizationRoleService != null && !_organizationRoleService.CheckPermition(GetLoggedUserId(), organizationId, Request.Path, GetUserRoleInOrganization().GetValueOrDefault(organizationId)))
            {
                throw new PermitionDeniedException();
            }
        }

        /// <summary>
        /// return organization guid by branch id
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns></returns>
        protected Guid GetOrganizationIdByBranch(Guid branchId)
        {
            return _organizationRoleService.GetOrganizationIdByBranch(branchId);
        }

        /// <summary>
        /// return organization guid by classroom guid
        /// </summary>
        /// <param name="classRoomId"></param>
        /// <returns></returns>
        protected Guid GetOrganizationIdByClassRoom(Guid classRoomId)
        {
            return _organizationRoleService.GetOrganizationIdByClassRoom(classRoomId);
        }

        /// <summary>
        /// get organization guid by course guid
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        protected Guid GetOrganizationIdByCourse(Guid courseId)
        {
            return _organizationRoleService.GetOrganizationIdByCourseId(courseId);
        }

        protected Guid GetOrganizationIdByBankOfQuestion(Guid courseId)
        {
            return _organizationRoleService.GetOrganizationIdByBankOfQuestion(courseId);
        }

        protected Guid GetOrganizationByCertificate(Guid certificateId)
        {
            return _organizationRoleService.GetOrganizationByCertificateId(certificateId);
        }

        protected Guid GetOrganizationBySendMessage(Guid sendMessageId)
        {
            return _organizationRoleService.GetOrganizationBySendMessage(sendMessageId);
        }

        protected Guid GetOrganizationByCourseLesson(Guid courseLessonId)
        {
            return _organizationRoleService.GetOrganizationByCourseLesson(courseLessonId);
        }

        protected Guid GetOrganizationByCourseLessonItem(Guid courseLessonItemId)
        {
            return _organizationRoleService.GetOrganizationByCourseLessonItem(courseLessonItemId);
        }

        protected Guid GetOrganizationByAnswer(Guid answerId)
        {
            return _organizationRoleService.GetOrganizationByAnswer(answerId);
        }

        protected Guid GetOrganizationByOrganizationStudyHour(Guid answerId)
        {
            return _organizationRoleService.GetOrganizationByOrganizationStudyHour(answerId);
        }

        protected Guid GetOrganizationByOrganizationCulture(Guid organizationCultureId)
        {
            return _organizationRoleService.GetOrganizationByOrganizationCulture(organizationCultureId);
        }

        protected Guid GetOrganizationByQuestion(Guid questionId)
        {
            return _organizationRoleService.GetOrganizationIdByQuestion(questionId);
        }

        protected Guid GetOrganizationIdByCourseTerm(Guid courseTermtermId)
        {
            return _organizationRoleService.GetOrganizationIdByTermId(courseTermtermId);
        }

        protected Guid GetOrganizationByStudentId(Guid studentId)
        {
            return _organizationRoleService.GetOrganizationByStudentId(studentId);
        }

        protected Guid GetOrganizationByStudentGroupId(Guid studentGroupId)
        {
            return _organizationRoleService.GetOrganizationByStudentGroupId(studentGroupId);
        }

        protected Guid GetOrganizationByUserInOrganization(Guid id)
        {
            return _organizationRoleService.GetOrganizationByUserInOrganization(id);
        }

        protected Guid GetOrganizationByCourseMaterial(Guid courseMaterialId)
        {
            return _organizationRoleService.GetOrganizationByCourseMaterial(courseMaterialId);
        }

    }
}
