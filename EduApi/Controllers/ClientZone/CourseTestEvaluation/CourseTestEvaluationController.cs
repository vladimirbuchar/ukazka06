using Core.Base.Dto;
using Core.DataTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.CourseTestEvaluation.Dto;
using Services.CourseTestEvaluation.Service;
using Services.OrganizationRole.Service;
using System;
using System.Threading.Tasks;

namespace EduApi.Controllers.ClientZone.CourseTestEvaluation
{
    [ApiExplorerSettings(GroupName = "CourseMaterial")]
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
        public async Task<ActionResult> Create(CourseTestEvaluationCreateDto addEvaluationTest)
        {
            try
            {
                await CheckOrganizationPermition(await _courseTestEvaluationService.GetOrganizationIdByObjectId(addEvaluationTest.MaterialId));
                return await SendResponse(await _courseTestEvaluationService.AddObject(addEvaluationTest, GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(CourseTestEvaluationListDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> List([FromQuery] ListDeletedRequestDto list)
        {
            try
            {
                await CheckOrganizationPermition(await _courseTestEvaluationService.GetOrganizationIdByObjectId(list.ParentId));
                var result = await _courseTestEvaluationService.GetList(x => x.CourseTestId == list.ParentId, list.IsDeleted);
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
        public async Task<ActionResult> Update(CourseTestEvaluationUpdateDto updateEvaluationTestDto)
        {
            try
            {
                await CheckOrganizationPermition(await _courseTestEvaluationService.GetOrganizationIdByObjectId(updateEvaluationTestDto.Id));
                return await SendResponse(await _courseTestEvaluationService.UpdateObject(updateEvaluationTestDto, GetLoggedUserId(), GetClientCulture()));
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
        public Task<ActionResult> Delete([FromQuery] DeleteDto delete)
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
