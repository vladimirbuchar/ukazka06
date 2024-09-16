
using BankOfQuestionService.Answer.AnswerCreate.Command;
using BankOfQuestionService.Answer.AnswerCreate.Dto;
using BankOfQuestionService.Answer.AnswerDelete.Command;
using BankOfQuestionService.Answer.AnswerDetail.Command;
using BankOfQuestionService.Answer.AnswerDetail.Dto;
using BankOfQuestionService.Answer.AnswerFileUpload.Command;
using BankOfQuestionService.Answer.AnswerList.Command;
using BankOfQuestionService.Answer.AnswerList.Dto;
using BankOfQuestionService.Answer.AnswerList.Filter;
using BankOfQuestionService.Answer.AnswerList.Sort;
using BankOfQuestionService.Answer.AnswerRestore.Command;
using BankOfQuestionService.Answer.AnswerUpdate.Command;
using BankOfQuestionService.Answer.AnswerUpdate.Dto;
using BankOfQuestionService.Answer.DeleteAnswerInQuestion.Command;
using Core.Base.Controller;
using Core.Base.Dto;
using Core.Base.Paging;
using Core.DataTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using Model.Edu.Answer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace EduApi.Controllers.ClientZone.Answer
{
    [ApiExplorerSettings(GroupName = "BankOfQuestion")]
    public class AnswerController : BaseClientZoneController
    {
        private readonly IAnswerCreateCommand _answerCreateService;
        private readonly IAnswerListCommand _answerListService;
        private readonly IAnswerDetailCommand _answerDetailService;
        private readonly IAnswerUpdateService _answerUpdateService;
        private readonly IAnswerDeleteCommand _answerDeleteService;
        private readonly IAnswerRestoreCommand _answerRestoreService;
        private readonly IAnswerFileUploadCommand _answerFileUploadService;
        private readonly IDeleteAnswerInQuestionCommnad _deleteAnswerInQuestionService;

        public AnswerController(
            IAnswerCreateCommand answerCreateService,
            IAnswerListCommand answerListService,
            IAnswerDetailCommand answerDetailService,
            IAnswerUpdateService answerUpdateService,
            IAnswerDeleteCommand answerDeleteService,
            IAnswerRestoreCommand answerRestoreService,
            IAnswerFileUploadCommand answerFileUploadService,
            IDeleteAnswerInQuestionCommnad deleteAnswerInQuestionService,
            ILogger<AnswerController> logger,
            EduDbContext organizationRoleService
        )
            : base(logger, organizationRoleService)
        {
            _answerCreateService = answerCreateService;
            _answerListService = answerListService;
            _answerDetailService = answerDetailService;
            _answerUpdateService = answerUpdateService;
            _answerDeleteService = answerDeleteService;
            _answerRestoreService = answerRestoreService;
            _answerFileUploadService = answerFileUploadService;
            _deleteAnswerInQuestionService = deleteAnswerInQuestionService;
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
                Guid orgasnizationId = await _answerCreateService.GetOrganizationIdByParentId(request.QuestionId);
                await CheckOrganizationPermition(orgasnizationId);
                var result = await _answerCreateService.Execute(request, GetLoggedUserId(), GetClientCulture());
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
                Guid organizationId = await _answerListService.GetOrganizationIdByParentId(request.ParentId);
                await CheckOrganizationPermition(organizationId);
                var result = await _answerListService.Execute(
                    x => x.QuestionId == request.ParentId,
                    request.IsDeleted,
                    new List<string>() { GetClientCulture() },
                    filter,
                    sortColum.ToString(),
                    sortDirection,
                    paging
                );
                return await SendResponse(result);
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
                Guid organizationId = await _answerDetailService.GetOrganizationIdByObjectId(request.Id);
                await CheckOrganizationPermition(organizationId);
                var result = await _answerDetailService.Execute(request.Id, new List<string>() { GetClientCulture() });
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
                Guid organizationId = await _answerUpdateService.GetOrganizationIdByObjectId(request.Id);
                await CheckOrganizationPermition(organizationId);
                var result = await _answerUpdateService.Execute(request, GetLoggedUserId(), GetClientCulture(), null);
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
                await CheckOrganizationPermition(await _answerDeleteService.GetOrganizationIdByObjectId(request.Id));
                var result = await _answerDeleteService.Execute(request.Id, GetLoggedUserId());
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
                await CheckOrganizationPermition(await _answerRestoreService.GetOrganizationIdByObjectId(request.Id));
                var result = await _answerRestoreService.Execute(request.Id, GetLoggedUserId());
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
                await CheckOrganizationPermition(await _answerFileUploadService.GetOrganizationIdByObjectId(request.Id));
                var result = await _answerFileUploadService.Execute(
                    request.Id,
                    GetClientCulture(),
                    GetLoggedUserId(),
                    new List<IFormFile>() { file },
                    new AnswerFileRepositoryDbo() { AnswerId = request.Id, },
                    x => x.AnswerId == request.Id && x.Culture.SystemIdentificator == GetClientCulture()
                );
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
        public async Task<ActionResult> DeleteAnswerInQuestion([FromQuery] DeleteByParentIdDto request)
        {
            try
            {
                await CheckOrganizationPermition(await _deleteAnswerInQuestionService.GetOrganizationIdByParentId(request.ParentId));
                var result = await _deleteAnswerInQuestionService.Execute(x => x.QuestionId == request.ParentId, GetLoggedUserId());
                return await SendResponse(result);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }
    }
}
