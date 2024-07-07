using System;
using Core.Base.Dto;
using Core.DataTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.OrganizationRole.Service;
using Services.Test.Dto;
using Services.Test.Service;

namespace EduApi.Controllers.ClientZone.CourseTest
{
    public class CourseTestController : BaseClientZoneController
    {
        private readonly ITestService _testService;

        public CourseTestController(ILogger<CourseTestController> logger, ITestService testService, IOrganizationRoleService organizationRoleService)
            : base(logger, organizationRoleService)
        {
            _testService = testService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult Create(CourseTestCreateDto addCourseTestDto)
        {
            try
            {
                CheckOrganizationPermition(_testService.GetOrganizationIdByObjectId(addCourseTestDto.CourseLesson.MaterialId));
                return SendResponse(_testService.AddCourseTest(addCourseTestDto, GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(CourseTestDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult Detail([FromQuery] DetailRequestDto request)
        {
            try
            {
                CheckOrganizationPermition(_testService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_testService.GetCourseTestDetail(request.Id, GetClientCulture()));
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
        public ActionResult Update(CourseTestUpdateDto updateCourseTestDto)
        {
            try
            {
                CheckOrganizationPermition(_testService.GetOrganizationIdByObjectId(updateCourseTestDto.Id));
                return SendResponse(_testService.UpdateCourseTest(updateCourseTestDto, GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
