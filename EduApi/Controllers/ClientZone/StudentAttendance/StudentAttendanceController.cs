using Core.Base.Dto;
using Core.DataTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.OrganizationRole.Service;
using Services.StudentAttendance.Dto;
using Services.StudentAttendance.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduApi.Controllers.ClientZone.StudentAttendance
{
    [ApiExplorerSettings(GroupName = "StudyZone")]
    public class StudentAttendanceController : BaseClientZoneController
    {
        private readonly IStudentAttendanceService _studentAttendanceService;

        public StudentAttendanceController(
            IStudentAttendanceService studentAttendanceService,
            ILogger<StudentAttendanceController> logger,
            IOrganizationRoleService organizationRoleService
        )
            : base(logger, organizationRoleService)
        {
            _studentAttendanceService = studentAttendanceService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public Task<ActionResult> Create(StudentAttendanceCreateDto saveStudentAttendanceDto)
        {
            try
            {
                return SendResponse(_studentAttendanceService.AddObject(saveStudentAttendanceDto, GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(HashSet<StudentAttendanceListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> List([FromQuery] ListRequestDto request)
        {
            try
            {
                var result = await _studentAttendanceService.GetList(x => x.CourseTermId == request.ParentId);
                return await SendResponse(result);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpDelete]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Delete([FromQuery] DeleteDto request)
        {
            try
            {
                await CheckOrganizationPermition(await _studentAttendanceService.GetOrganizationIdByObjectId(request.Id));
                return await SendResponse(await _studentAttendanceService.DeleteObject(request.Id, GetLoggedUserId()));
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
        public async Task<ActionResult> Restore([FromQuery] RestoreDto request)
        {
            try
            {
                await CheckOrganizationPermition(await _studentAttendanceService.GetOrganizationIdByObjectId(request.Id));
                return await SendResponse(await _studentAttendanceService.RestoreObject(request.Id, GetLoggedUserId()));
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }
    }
}
