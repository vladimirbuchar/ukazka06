using Core.Base.Dto;
using Core.DataTypes;
using EduServices.CourseTerm.Dto;
using EduServices.CourseTermTimeTable.Dto;
using EduServices.CourseTermTimeTable.Service;
using EduServices.OrganizationRole.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

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
        public ActionResult Create(CourseTermTimeTableGenerateDto generateTimeTableDto)
        {
            try
            {
                CheckPermition(GetOrganizationIdByCourseTerm(generateTimeTableDto.CourseTermId));
                _courseTermTimeTableService.GenerateTimeTable(generateTimeTableDto.CourseTermId);
                return SendResponse();
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
            CheckPermition(GetOrganizationIdByCourseTerm(requestDto.ParentId));
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
                CheckPermition(GetOrganizationIdByCourseTerm(cancelCourseTermDto.CourseTermId));
                _courseTermTimeTableService.CancelCourseTerm(cancelCourseTermDto.Id);
                return SendResponse();
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
                CheckPermition(GetOrganizationIdByCourseTerm(restoreCourseTermDto.CourseTermId));
                _courseTermTimeTableService.Restore(restoreCourseTermDto.Id);
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
