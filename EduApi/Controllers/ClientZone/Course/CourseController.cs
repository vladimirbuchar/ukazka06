﻿using Core.Base.Dto;
using Core.Base.Paging;
using Core.DataTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Course.Dto;
using Services.Course.Filter;
using Services.Course.Service;
using Services.Course.Sort;
using Services.OrganizationRole.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace EduApi.Controllers.ClientZone.Course
{
    public class CourseController : BaseClientZoneController
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService, ILogger<CourseController> logger, IOrganizationRoleService organizationRoleService)
            : base(logger, organizationRoleService)
        {
            _courseService = courseService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Create(CourseCreateDto addCourseDto)
        {
            try
            {
                await CheckOrganizationPermition(addCourseDto.OrganizationId);
                var result = await _courseService.AddObject(addCourseDto, GetLoggedUserId(), GetClientCulture());
                return await SendResponse(result);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CourseListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> List([FromQuery] ListDeletedRequestDto request, [FromQuery] CourseFilter filter,
            [FromQuery] SortDirection sortDirection,
            [FromQuery] CourseSort sortColum,
            [FromQuery] BasePaging paging)
        {
            try
            {
                await CheckOrganizationPermition(request.ParentId);
                var result = await _courseService.GetList(x => x.OrganizationId == request.ParentId, request.IsDeleted, GetClientCulture(), filter, sortColum.ToString(), sortDirection, paging);
                return await SendResponse(result);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(CourseDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Detail([FromQuery] DetailRequestDto request)
        {
            try
            {
                await CheckOrganizationPermition(await _courseService.GetOrganizationIdByObjectId(request.Id));
                var result = await _courseService.GetDetail(request.Id, GetClientCulture());
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
        public async Task<ActionResult> Update(CourseUpdateDto updateCourseDto)
        {
            try
            {
                await CheckOrganizationPermition(await _courseService.GetOrganizationIdByObjectId(updateCourseDto.Id));
                var result = await _courseService.UpdateObject(updateCourseDto, GetLoggedUserId(), GetClientCulture());
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
                await CheckOrganizationPermition(await _courseService.GetOrganizationIdByObjectId(request.Id));
                var result = await _courseService.DeleteObject(request.Id, GetLoggedUserId());
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
                await CheckOrganizationPermition(await _courseService.GetOrganizationIdByObjectId(request.Id));
                var result = await _courseService.RestoreObject(request.Id, GetLoggedUserId());
                return await SendResponse(result);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }
    }
}
