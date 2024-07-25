using Core.Base.Dto;
using Core.DataTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.CourseTerm.Dto;
using Services.CourseTermTimeTable.Dto;
using Services.CourseTermTimeTable.Service;
using Services.OrganizationRole.Service;
using System;
using System.Threading.Tasks;

namespace EduApi.Controllers.ClientZone.CourseTermTimeTable
{
    public class CourseTermTimeTableController : BaseClientZoneController
    {
        private readonly ICourseTermTimeTableService _courseTermTimeTableService;

        public CourseTermTimeTableController(
            ICourseTermTimeTableService courseTermTimeTableService,
            ILogger<CourseTermTimeTableController> logger,
            IOrganizationRoleService organizationRoleService
        )
            : base(logger, organizationRoleService)
        {
            _courseTermTimeTableService = courseTermTimeTableService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Create(CourseTermTimeTableGenerateDto generateTimeTableDto)
        {
            try
            {
                await CheckOrganizationPermition(await _courseTermTimeTableService.GetOrganizationIdByObjectId(generateTimeTableDto.CourseTermId));
                return await SendResponse(await _courseTermTimeTableService.GenerateTimeTable(generateTimeTableDto.CourseTermId));
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(CourseTermDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> List([FromQuery] ListRequestDto requestDto)
        {
            await CheckOrganizationPermition(await _courseTermTimeTableService.GetOrganizationIdByObjectId(requestDto.ParentId));
            return await SendResponse(await _courseTermTimeTableService.GetTimeTable(requestDto.ParentId, GetClientCulture()));
        }

        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> CancelCourseTerm(CourseTermTimeTableCancelDto cancelCourseTermDto)
        {
            try
            {
                await CheckOrganizationPermition(await _courseTermTimeTableService.GetOrganizationIdByObjectId(cancelCourseTermDto.CourseTermId));
                return await SendResponse(await _courseTermTimeTableService.CancelCourseTerm(cancelCourseTermDto.Id));
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
        public async Task<ActionResult> RestoreCourseTerm(CourseTermTimeTableRestoreDto restoreCourseTermDto)
        {
            try
            {
                await CheckOrganizationPermition(await _courseTermTimeTableService.GetOrganizationIdByObjectId(restoreCourseTermDto.CourseTermId));
                return await SendResponse(await _courseTermTimeTableService.Restore(restoreCourseTermDto.Id));
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }
    }
}
