using Core.Base.Dto;
using Core.DataTypes;
using EduServices.OrganizationRole.Service;
using EduServices.Test.Dto;
using EduServices.Test.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace EduApi.Controllers.ClientZone.CourseTest
{
    public class CourseTestController : BaseClientZoneController
    {
        private readonly ITestService _testService;

        public CourseTestController(
            ILogger<CourseTestController> logger,
            ITestService testService,
            IOrganizationRoleService organizationRoleService
        )
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
                CheckPermition(GetOrganizationByCourseMaterial(addCourseTestDto.CourseLesson.MaterialId));
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
                CheckPermition(GetOrganizationByCourseLesson(request.Id));
                return SendResponse(_testService.GetCourseTestDetail(request.Id));
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
                CheckPermition(GetOrganizationByCourseLesson(updateCourseTestDto.Id));
                return SendResponse(_testService.UpdateCourseTest(updateCourseTestDto, GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
