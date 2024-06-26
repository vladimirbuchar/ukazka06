﻿using Core.Base.Dto;
using Core.DataTypes;
using EduServices.Course.Service;
using EduServices.CourseTerm.Dto;
using EduServices.CourseTerm.Service;
using EduServices.OrganizationRole.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace EduApi.Controllers.ClientZone.CourseTerm
{
    public class CourseTermController : BaseClientZoneController
    {
        private readonly ICourseTermService _courseTermService;
        private readonly ICourseService _courseService;

        public CourseTermController(
            ICourseTermService courseTermService,
            ILogger<CourseTermController> logger,
            IOrganizationRoleService organizationRoleService,
            ICourseService courseService
        )
            : base(logger, organizationRoleService)
        {
            _courseTermService = courseTermService;
            _courseService = courseService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult Create(CourseTermCreateDto addCourseTermDto)
        {
            try
            {
                CheckPermition(_courseService.GetOrganizationIdByObjectId(addCourseTermDto.CourseId));
                return SendResponse(_courseTermService.AddObject(addCourseTermDto, GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CourseTermListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult List([FromQuery] ListDeletedRequestDto request)
        {
            try
            {
                CheckPermition(_courseService.GetOrganizationIdByObjectId(request.ParentId));
                return SendResponse(_courseTermService.GetList(x => x.CourseId == request.ParentId, request.IsDeleted, GetClientCulture()));
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
        public ActionResult Detail([FromQuery] DetailRequestDto request)
        {
            try
            {
                CheckPermition(_courseTermService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_courseTermService.GetDetail(request.Id, GetClientCulture()));
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
        public ActionResult Update(CourseTermUpdateDto updateCourseTermDto)
        {
            try
            {
                CheckPermition(_courseTermService.GetOrganizationIdByObjectId(updateCourseTermDto.Id));
                return SendResponse(_courseTermService.UpdateObject(updateCourseTermDto, GetLoggedUserId(), GetClientCulture()));
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
        public ActionResult Delete([FromQuery] DeleteDto request)
        {
            try
            {
                CheckPermition(_courseTermService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_courseTermService.DeleteObject(request.Id, GetLoggedUserId()));
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
        public ActionResult Restore([FromQuery] RestoreDto request)
        {
            try
            {
                CheckPermition(_courseTermService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_courseTermService.RestoreObject(request.Id, GetLoggedUserId()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
