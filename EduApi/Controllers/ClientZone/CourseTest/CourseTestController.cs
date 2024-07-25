using Core.Base.Dto;
using Core.DataTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.OrganizationRole.Service;
using Services.Test.Dto;
using Services.Test.Service;
using System;
using System.Threading.Tasks;

namespace EduApi.Controllers.ClientZone.CourseTest
{
    [ApiExplorerSettings(GroupName = "CourseMaterial")]
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
        public async Task<ActionResult> Create(CourseTestCreateDto addCourseTestDto)
        {
            try
            {
                await CheckOrganizationPermition(await _testService.GetOrganizationIdByObjectId(addCourseTestDto.CourseLesson.MaterialId));
                return await SendResponse(await _testService.AddCourseTest(addCourseTestDto, GetClientCulture()));
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(CourseTestDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Detail([FromQuery] DetailRequestDto request)
        {
            try
            {
                await CheckOrganizationPermition(await _testService.GetOrganizationIdByObjectId(request.Id));
                return await SendResponse(await _testService.GetCourseTestDetail(request.Id, GetClientCulture()));
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
        public async Task<ActionResult> Update(CourseTestUpdateDto updateCourseTestDto)
        {
            try
            {
                await CheckOrganizationPermition(await _testService.GetOrganizationIdByObjectId(updateCourseTestDto.Id));
                return await SendResponse(await _testService.UpdateCourseTest(updateCourseTestDto, GetClientCulture()));
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }
    }
}
