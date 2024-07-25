using Core.Base.Dto;
using Core.Base.Paging;
using Core.DataTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Edu.Answer;
using Services.Answer.Dto;
using Services.Answer.Filter;
using Services.Answer.Service;
using Services.Answer.Sort;
using Services.OrganizationRole.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace EduApi.Controllers.ClientZone.Answer
{
    [ApiExplorerSettings(GroupName = "BankOfQuestion")]
    public class AnswerController : BaseClientZoneController
    {
        private readonly IAnswerService _answerService;

        public AnswerController(IAnswerService answerService, ILogger<AnswerController> logger, IOrganizationRoleService organizationRoleService)
            : base(logger, organizationRoleService)
        {
            this._answerService = answerService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Create(AnswerCreateDto request)
        {
            try
            {
                Guid orgasnizationId = await _answerService.GetOrganizationIdByParentId(request.QuestionId);
                await CheckOrganizationPermition(orgasnizationId);
                var result = await _answerService.AddObject(request, GetLoggedUserId(), GetClientCulture());
                return await SendResponse(result);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AnswerListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> List(
            [FromQuery] ListDeletedRequestDto request,
            [FromQuery] AnswerFilter filter,
            [FromQuery] SortDirection sortDirection,
            [FromQuery] AnswerSort sortColum,
            [FromQuery] BasePaging paging
        )
        {
            try
            {
                Guid organizationId = await _answerService.GetOrganizationIdByParentId(request.ParentId);
                await CheckOrganizationPermition(organizationId);
                var result = await _answerService.GetList(
                        x => x.TestQuestionId == request.ParentId,
                        request.IsDeleted,
                        GetClientCulture(),
                        filter,
                        sortColum.ToString(),
                        sortDirection,
                        paging
                    );
                return await SendResponse(
                    result
                );
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(AnswerDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Detail([FromQuery] DetailRequestDto request)
        {
            try
            {
                Guid organizationId = await _answerService.GetOrganizationIdByObjectId(request.Id);
                await CheckOrganizationPermition(organizationId);
                var result = await _answerService.GetDetail(request.Id, GetClientCulture());
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
        public async Task<ActionResult> Update(AnswerUpdateDto request)
        {
            try
            {
                Guid organizationId = await _answerService.GetOrganizationIdByObjectId(request.Id);
                await CheckOrganizationPermition(organizationId);
                var result = await _answerService.UpdateObject(request, GetLoggedUserId(), GetClientCulture());
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
                await CheckOrganizationPermition(await _answerService.GetOrganizationIdByObjectId(request.Id));
                var result = await _answerService.DeleteObject(request.Id, GetLoggedUserId());
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
                await CheckOrganizationPermition(await _answerService.GetOrganizationIdByObjectId(request.Id));
                var result = await _answerService.RestoreObject(request.Id, GetLoggedUserId());
                return await SendResponse(result);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> FileUpload([FromQuery] DetailRequestDto request, IFormFile file)
        {
            try
            {
                await CheckOrganizationPermition(await _answerService.GetOrganizationIdByObjectId(request.Id));
                var result = await _answerService.FileUpload(
                        request.Id,
                        GetClientCulture(),
                        GetLoggedUserId(),
                        new List<IFormFile>() { file },
                        new AnswerFileRepositoryDbo() { AnswerId = request.Id, },
                        x => x.AnswerId == request.Id && x.Culture.SystemIdentificator == GetClientCulture()
                    );
                return await SendResponse(
                    result
                );
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
        public async Task<ActionResult> DeleteAnswerInQuestion([FromQuery] DeleteByParentIdDto request)
        {
            try
            {
                await CheckOrganizationPermition(await _answerService.GetOrganizationIdByParentId(request.ParentId));
                var result = await _answerService.MultipleDelete(x => x.TestQuestionId == request.ParentId, GetLoggedUserId());
                return await SendResponse(result);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }
    }
}
