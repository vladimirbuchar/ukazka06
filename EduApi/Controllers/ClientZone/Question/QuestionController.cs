using Core.Base.Dto;
using Core.Base.Paging;
using Core.DataTypes;
//using EduServices.Answer.Permission;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Edu.Question;
using Services.OrganizationRole.Service;
using Services.Question.Dto;
using Services.Question.Filter;
using Services.Question.Service;
using Services.Question.Sort;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace EduApi.Controllers.ClientZone.Question
{
    [ApiExplorerSettings(GroupName = "BankOfQuestion")]
    public class QuestionController : BaseClientZoneController
    {
        private readonly IQuestionService _questionService;

        public QuestionController(
            IQuestionService questionService,
            ILogger<QuestionController> logger,
            IOrganizationRoleService organizationRoleService
        )
            : base(logger, organizationRoleService)
        {
            _questionService = questionService;
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
                await CheckOrganizationPermition(await _questionService.GetOrganizationIdByParentId(addQuestionDto.BankOfQuestionId));
                return await SendResponse(await _questionService.AddObject(addQuestionDto, GetLoggedUserId(), GetClientCulture()));
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
                await CheckOrganizationPermition(await _questionService.GetOrganizationIdByParentId(request.ParentId));
                var result = await _questionService.GetList(
                        x => x.BankOfQuestionId == request.ParentId,
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
        [ProducesResponseType(typeof(QuestionDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Detail([FromQuery] DetailRequestDto request)
        {
            try
            {
                await CheckOrganizationPermition(await _questionService.GetOrganizationIdByObjectId(request.Id));
                return await SendResponse(await _questionService.GetDetail(request.Id, GetClientCulture()));
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
                await CheckOrganizationPermition(await _questionService.GetOrganizationIdByObjectId(updateQuestionDto.Id));
                return await SendResponse(await _questionService.UpdateObject(updateQuestionDto, GetLoggedUserId(), GetClientCulture()));
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
                await CheckOrganizationPermition(await _questionService.GetOrganizationIdByObjectId(request.Id));
                return await SendResponse(await _questionService.DeleteObject(request.Id, GetLoggedUserId()));
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
                await CheckOrganizationPermition(await _questionService.GetOrganizationIdByObjectId(request.Id));
                return await SendResponse(await _questionService.RestoreObject(request.Id, GetLoggedUserId()));
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
                await CheckOrganizationPermition(await _questionService.GetOrganizationIdByObjectId(request.Id));
                return await SendResponse(await
                    _questionService.FileUpload(
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
