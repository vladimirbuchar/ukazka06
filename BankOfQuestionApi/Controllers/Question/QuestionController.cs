using BankOfQuestionService.Question.QuestionCreate.Command;
using BankOfQuestionService.Question.QuestionCreate.Dto;
using BankOfQuestionService.Question.QuestionDelete.Command;
using BankOfQuestionService.Question.QuestionDetail.Command;
using BankOfQuestionService.Question.QuestionDetail.Dto;
using BankOfQuestionService.Question.QuestionFileUpload.Command;
using BankOfQuestionService.Question.QuestionList.Command;
using BankOfQuestionService.Question.QuestionList.Dto;
using BankOfQuestionService.Question.QuestionList.Filter;
using BankOfQuestionService.Question.QuestionList.Sort;
using BankOfQuestionService.Question.QuestionRestore.Command;
using BankOfQuestionService.Question.QuestionUpdate.Command;
using BankOfQuestionService.Question.QuestionUpdate.Dto;
using Core.Base.Controller;
using Core.Base.Dto;
using Core.Base.Paging;
using Core.DataTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using Model.Edu.Question;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace EduApi.Controllers.ClientZone.Question
{
    [ApiExplorerSettings(GroupName = "BankOfQuestion")]
    public class QuestionController : BaseClientZoneController
    {
        private readonly IQuestionCreateService _questionCreateService;
        private readonly IQuestionListService _questionListService;
        private readonly IQuestionDetailService _questionDetailService;
        private readonly IQuestionUpdateService _questionUpdateService;
        private readonly IQuestionDeleteService _questionDeleteService;
        private readonly IQuestionRestoreService _questionRestoreService;
        private readonly IQuestionFileUploadFileUploadService _questionFileUploadFileUploadService;

        public QuestionController(
            ILogger<QuestionController> logger,
            EduDbContext organizationRoleService,
            IQuestionListService questionListService,
            IQuestionCreateService questionCreateService,
            IQuestionDetailService questionDetailService,
            IQuestionUpdateService questionUpdateService,
            IQuestionDeleteService questionDeleteService,
            IQuestionRestoreService questionRestoreService,
            IQuestionFileUploadFileUploadService questionFileUploadFileUploadService
        )
            : base(logger, organizationRoleService)
        {
            _questionCreateService = questionCreateService;
            _questionListService = questionListService;
            _questionDetailService = questionDetailService;
            _questionUpdateService = questionUpdateService;
            _questionDeleteService = questionDeleteService;
            _questionRestoreService = questionRestoreService;
            _questionFileUploadFileUploadService = questionFileUploadFileUploadService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Create(QuestionCreateDto addQuestionDto)
        {
            try
            {
                await CheckOrganizationPermition(await _questionCreateService.GetOrganizationIdByParentId(addQuestionDto.BankOfQuestionId));
                return await SendResponse(await _questionCreateService.Execute(addQuestionDto, GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<QuestionListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> List(
            [FromQuery] ListDeletedRequestDto request,
            [FromQuery] QuestionFilter filter,
            [FromQuery] SortDirection sortDirection,
            [FromQuery] QuestionSort sortColum,
            [FromQuery] BasePaging paging
        )
        {
            try
            {
                await CheckOrganizationPermition(await _questionListService.GetOrganizationIdByParentId(request.ParentId));
                var result = await _questionListService.Execute(
                    x => x.BankOfQuestionId == request.ParentId,
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
        [ProducesResponseType(typeof(QuestionDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Detail([FromQuery] DetailRequestDto request)
        {
            try
            {
                await CheckOrganizationPermition(await _questionDetailService.GetOrganizationIdByObjectId(request.Id));
                return await SendResponse(await _questionDetailService.Execute(request.Id, new List<string>() { GetClientCulture() }));
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
        public async Task<ActionResult> Update(QuestionUpdateDto updateQuestionDto)
        {
            try
            {
                await CheckOrganizationPermition(await _questionUpdateService.GetOrganizationIdByObjectId(updateQuestionDto.Id));
                return await SendResponse(await _questionUpdateService.Execute(updateQuestionDto, GetLoggedUserId(), GetClientCulture(), null));
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
                await CheckOrganizationPermition(await _questionDeleteService.GetOrganizationIdByObjectId(request.Id));
                return await SendResponse(await _questionDeleteService.Execute(request.Id, GetLoggedUserId()));
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
                await CheckOrganizationPermition(await _questionRestoreService.GetOrganizationIdByObjectId(request.Id));
                return await SendResponse(await _questionRestoreService.Execute(request.Id, GetLoggedUserId()));
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
                await CheckOrganizationPermition(await _questionFileUploadFileUploadService.GetOrganizationIdByObjectId(request.Id));
                return await SendResponse(
                    await _questionFileUploadFileUploadService.Execute(
                        request.Id,
                        GetClientCulture(),
                        GetLoggedUserId(),
                        new List<IFormFile>() { file },
                        new QuestionFileRepositoryDbo() { QuestionId = request.Id, },
                        x => x.QuestionId == request.Id && x.Culture.SystemIdentificator == GetClientCulture()
                    )
                );
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }
    }
}
