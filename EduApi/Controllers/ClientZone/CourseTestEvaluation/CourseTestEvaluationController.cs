using Core.Base.Dto;
using Core.DataTypes;
using EduServices.CourseTestEvaluation.Dto;
using EduServices.CourseTestEvaluation.Service;
using EduServices.OrganizationRole.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace EduApi.Controllers.ClientZone.CourseTestEvaluation
{
    public class CourseTestEvaluationController : BaseClientZoneController
    {
        private readonly ICourseTestEvaluationService _courseTestEvaluationService;

        public CourseTestEvaluationController(
            ILogger<CourseTestEvaluationController> logger,
            ICourseTestEvaluationService courseTestEvaluationService,
            IOrganizationRoleService organizationRoleService
        )
            : base(logger, organizationRoleService)
        {
            _courseTestEvaluationService = courseTestEvaluationService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult Create(CourseTestEvaluationCreateDto addEvaluationTest)
        {
            try
            {
                CheckOrganizationPermition(_courseTestEvaluationService.GetOrganizationIdByObjectId(addEvaluationTest.MaterialId));
                return SendResponse(_courseTestEvaluationService.AddObject(addEvaluationTest, GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(CourseTestEvaluationListDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult List([FromQuery] ListDeletedRequestDto list)
        {
            try
            {
                CheckOrganizationPermition(_courseTestEvaluationService.GetOrganizationIdByObjectId(list.ParentId));
                return SendResponse(_courseTestEvaluationService.GetList(x => x.CourseTestId == list.ParentId, list.IsDeleted));
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
        public ActionResult Update(CourseTestEvaluationUpdateDto updateEvaluationTestDto)
        {
            try
            {
                CheckOrganizationPermition(_courseTestEvaluationService.GetOrganizationIdByObjectId(updateEvaluationTestDto.Id));
                return SendResponse(_courseTestEvaluationService.UpdateObject(updateEvaluationTestDto, GetLoggedUserId(), GetClientCulture()));
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
        public ActionResult Delete([FromQuery] DeleteDto delete)
        {
            try
            {
                return SendResponse(_courseTestEvaluationService.DeleteObject(delete.Id, GetLoggedUserId()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
