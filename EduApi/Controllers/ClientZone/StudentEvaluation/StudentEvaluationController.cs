using Core.Base.Dto;
using Core.DataTypes;
using EduServices.OrganizationRole.Service;
using EduServices.StudentEvaluation.Dto;
using EduServices.StudentEvaluation.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

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

        [HttpGet]
        [ProducesResponseType(typeof(HashSet<MyEvaluationListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetMyEvaluation([FromQuery] Guid userId)
        {
            try
            {
                return SendResponse(_studentEvaluationService.GetMyEvaluation(GetLoggedUserId()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
