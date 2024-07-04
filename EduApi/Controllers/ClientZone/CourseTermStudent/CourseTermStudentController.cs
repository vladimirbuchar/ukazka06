using Core.Base.Dto;
using Core.DataTypes;
using EduServices.CourseTerm.Service;
using EduServices.CourseTermStudent.Dto;
using EduServices.CourseTermStudent.Service;
using EduServices.OrganizationRole.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace EduApi.Controllers.ClientZone.CourseTermStudent
{
    public class CourseTermStudentController : BaseClientZoneController
    {
        private readonly ICourseTermStudentService _courseStudentService;
        private readonly ICourseTermService _courseTermService;

        public CourseTermStudentController(
            ILogger<CourseTermStudentController> logger,
            ICourseTermStudentService courseStudentService,
            IOrganizationRoleService organizationRoleService,
            ICourseTermService courseTermService
        )
            : base(logger, organizationRoleService)
        {
            _courseTermService = courseTermService;
            _courseStudentService = courseStudentService;
        }

        /// <summary>
        /// https://dev.azure.com/flexisoftware/MyEdu/_wiki/wikis/MyEdu.wiki?wikiVersion=GBwikiMaster&pagePath=%2FModuly%2FKlientsk%C3%A1%20z%C3%B3na%2FSpr%C3%A1va%20organizac%C3%AD%2FREST%20slu%C5%BEby%2FREST%3A%20AddOrganization&pageId=2
        /// </summary>

        /// <param name="create"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult Create(CourseTermStudentCreateDto addStudentToCourseDto)
        {
            try
            {
                Guid organizationId = _courseTermService.GetOrganizationIdByObjectId(addStudentToCourseDto.CourseTermId);
                CheckOrganizationPermition(organizationId);
                addStudentToCourseDto.OrganizationId = organizationId;
                return SendResponse(_courseStudentService.AddObject(addStudentToCourseDto, GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CourseTermStudentListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult List([FromQuery] ListRequestDto request)
        {
            try
            {
                CheckOrganizationPermition(_courseTermService.GetOrganizationIdByObjectId(request.ParentId));
                return SendResponse(_courseStudentService.GetAllStudentInCourseTerm(request.ParentId));
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
        public ActionResult Delete(DeleteDto request)
        {
            try
            {
                CheckOrganizationPermition(_courseStudentService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_courseStudentService.DeleteObject(request.Id, GetLoggedUserId()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
