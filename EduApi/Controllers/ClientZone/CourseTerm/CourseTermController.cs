using Core.Base.Dto;
using Core.Base.Paging;
using Core.DataTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Course.Service;
using Services.CourseTerm.Dto;
using Services.CourseTerm.Filter;
using Services.CourseTerm.Service;
using Services.CourseTerm.Sort;
using Services.OrganizationRole.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace EduApi.Controllers.ClientZone.CourseTerm
{
    public class CourseTermController : BaseClientZoneController
    {
        private readonly ICourseTermService _courseTermService;
        public CourseTermController(
            ICourseTermService courseTermService,
            ILogger<CourseTermController> logger,
            IOrganizationRoleService organizationRoleService,
            ICourseService courseService
        )
            : base(logger, organizationRoleService)
        {
            _courseTermService = courseTermService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Create(CourseTermCreateDto addCourseTermDto)
        {
            try
            {
                addCourseTermDto.OrganizationId = await _courseTermService.GetOrganizationIdByParentId(addCourseTermDto.CourseId);
                await CheckOrganizationPermition(addCourseTermDto.OrganizationId);
                var result = await _courseTermService.AddObject(addCourseTermDto, GetLoggedUserId(), GetClientCulture());
                return await SendResponse(result);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CourseTermListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> List([FromQuery] ListDeletedRequestDto request, [FromQuery] CourseTermFilter filter,
            [FromQuery] SortDirection sortDirection,
            [FromQuery] CourseTermSort sortColum,
            [FromQuery] BasePaging paging)
        {
            try
            {
                await CheckOrganizationPermition(await _courseTermService.GetOrganizationIdByParentId(request.ParentId));
                var result = _courseTermService.GetList(x => x.CourseId == request.ParentId, request.IsDeleted, GetClientCulture(), filter, sortColum.ToString(), sortDirection, paging);
                return await SendResponse(result);
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
        public async Task<ActionResult> Detail([FromQuery] DetailRequestDto request)
        {
            try
            {
                await CheckOrganizationPermition(await _courseTermService.GetOrganizationIdByObjectId(request.Id));
                var result = await _courseTermService.GetDetail(request.Id, GetClientCulture());
                return await SendResponse(result);
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
        public async Task<ActionResult> Update(CourseTermUpdateDto updateCourseTermDto)
        {
            try
            {
                Guid organizationId = await _courseTermService.GetOrganizationIdByObjectId(updateCourseTermDto.Id);
                updateCourseTermDto.OrganizationId = organizationId;
                await CheckOrganizationPermition(organizationId);
                var result = await _courseTermService.UpdateObject(updateCourseTermDto, GetLoggedUserId(), GetClientCulture());
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
                await CheckOrganizationPermition(await _courseTermService.GetOrganizationIdByObjectId(request.Id));
                var result = await _courseTermService.DeleteObject(request.Id, GetLoggedUserId());
                return await SendResponse(result);
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
                await CheckOrganizationPermition(await _courseTermService.GetOrganizationIdByObjectId(request.Id));
                var result = await _courseTermService.RestoreObject(request.Id, GetLoggedUserId());
                return await SendResponse(result);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }
    }
}
