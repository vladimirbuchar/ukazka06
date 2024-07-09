﻿using System;
using System.Collections.Generic;
using Core.Base.Dto;
using Core.DataTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.OrganizationRole.Service;
using Services.StudentEvaluation.Dto;
using Services.StudentEvaluation.Service;

namespace EduApi.Controllers.ClientZone.StudentEvaluation
{
    [ApiExplorerSettings(GroupName = "StudyZone")]
    public class StudentEvaluationController : BaseClientZoneController
    {
        private readonly IStudentEvaluationService _studentEvaluationService;

        public StudentEvaluationController(
            IStudentEvaluationService studentEvaluationService,
            ILogger<StudentEvaluationController> logger,
            IOrganizationRoleService organizationRoleService
        )
            : base(logger, organizationRoleService)
        {
            _studentEvaluationService = studentEvaluationService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult Create(StudentEvaluationCreateDto addStudentEvaluationDto)
        {
            try
            {
                return SendResponse(_studentEvaluationService.AddObject(addStudentEvaluationDto, GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(HashSet<StudentEvaluationListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult List([FromQuery] ListRequestDto request)
        {
            try
            {
                return SendResponse(_studentEvaluationService.GetList(x => x.CourseTermId == request.ParentId));
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
        public ActionResult Delete([FromQuery] Guid studentEvaluationId, [FromQuery] Guid courseTermId)
        {
            try
            {
                return SendResponse(_studentEvaluationService.DeleteObject(studentEvaluationId, GetLoggedUserId()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
