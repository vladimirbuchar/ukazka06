using System;
using Core.Base.Dto;
using Core.DataTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.CourseTerm.Dto;
using Services.CourseTermTimeTable.Dto;
using Services.CourseTermTimeTable.Service;
using Services.OrganizationRole.Service;

namespace EduApi.Controllers.ClientZone.CourseTermTimeTable
{
    public class CourseTermTimeTableController : BaseClientZoneController
    {
        private readonly ICourseTermTimeTableService _courseTermTimeTableService;

        public CourseTermTimeTableController(ICourseTermTimeTableService courseTermTimeTableService, ILogger<CourseTermTimeTableController> logger, IOrganizationRoleService organizationRoleService)
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
        public ActionResult Create(CourseTermTimeTableGenerateDto generateTimeTableDto)
        {
            try
            {
                CheckOrganizationPermition(_courseTermTimeTableService.GetOrganizationIdByObjectId(generateTimeTableDto.CourseTermId));
                return SendResponse(_courseTermTimeTableService.GenerateTimeTable(generateTimeTableDto.CourseTermId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(CourseTermDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult List([FromQuery] ListRequestDto requestDto)
        {
            CheckOrganizationPermition(_courseTermTimeTableService.GetOrganizationIdByObjectId(requestDto.ParentId));
            return SendResponse(_courseTermTimeTableService.GetTimeTable(requestDto.ParentId, GetClientCulture()));
        }

        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult CancelCourseTerm(CourseTermTimeTableCancelDto cancelCourseTermDto)
        {
            try
            {
                CheckOrganizationPermition(_courseTermTimeTableService.GetOrganizationIdByObjectId(cancelCourseTermDto.CourseTermId));
                return SendResponse(_courseTermTimeTableService.CancelCourseTerm(cancelCourseTermDto.Id));
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
        public ActionResult RestoreCourseTerm(CourseTermTimeTableRestoreDto restoreCourseTermDto)
        {
            try
            {
                CheckOrganizationPermition(_courseTermTimeTableService.GetOrganizationIdByObjectId(restoreCourseTermDto.CourseTermId));
                return SendResponse(_courseTermTimeTableService.Restore(restoreCourseTermDto.Id));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
