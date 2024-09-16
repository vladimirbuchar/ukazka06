using BankOfQuestionService.BankOfQuestion.BankOfQuestionCreate.Command;
using BankOfQuestionService.BankOfQuestion.BankOfQuestionCreate.Dto;
using BankOfQuestionService.BankOfQuestion.BankOfQuestionDelete.Command;
using BankOfQuestionService.BankOfQuestion.BankOfQuestionDetail.Command;
using BankOfQuestionService.BankOfQuestion.BankOfQuestionDetail.Dto;
using BankOfQuestionService.BankOfQuestion.BankOfQuestionDropDown.Service;
using BankOfQuestionService.BankOfQuestion.BankOfQuestionList.Command;
using BankOfQuestionService.BankOfQuestion.BankOfQuestionList.Dto;
using BankOfQuestionService.BankOfQuestion.BankOfQuestionList.Filter;
using BankOfQuestionService.BankOfQuestion.BankOfQuestionList.Sort;
using BankOfQuestionService.BankOfQuestion.BankOfQuestionRestore.Command;
using BankOfQuestionService.BankOfQuestion.BankOfQuestionUpdate.Command;
using BankOfQuestionService.BankOfQuestion.BankOfQuestionUpdate.Dto;
using Core.Base.Controller;
using Core.Base.DropDownFilter;
using Core.Base.Dto;
using Core.Base.Paging;
using Core.DataTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace EduApi.Controllers.ClientZone.BankOfQuestion
{
    [ApiExplorerSettings(GroupName = "BankOfQuestion")]
    public class BankOfQuestionController : BaseClientZoneController
    {
        private readonly IBankOfQuestionCreateService _bankOfQuestionCreateService;
        private readonly IBankOfQuestionListService _bankOfQuestionListService;
        private readonly IBankOfQuestionDetailService _bankOfQuestionDetailService;
        private readonly IBankOfQuestionUpdateService _bankOfQuestionUpdateService;
        private readonly IBankOfQuestionDeleteService _bankOfQuestionDeleteService;
        private readonly IBankOfQuestionRestoreService _bankOfQuestionRestoreService;
        private readonly IBankOfQuestionDropDownService _bankOfQuestionDropDownService;

        public BankOfQuestionController(
            ILogger<BankOfQuestionController> logger,
            IBankOfQuestionCreateService bankOfQuestionCreateService,
            IBankOfQuestionListService bankOfQuestionListService,
            IBankOfQuestionDetailService bankOfQuestionDetailService,
            IBankOfQuestionUpdateService bankOfQuestionUpdateService,
            EduDbContext organizationRoleService,
            IBankOfQuestionDeleteService bankOfQuestionDeleteService,
            IBankOfQuestionRestoreService bankOfQuestionRestoreService,
            IBankOfQuestionDropDownService bankOfQuestionDropDownService
        )
            : base(logger, organizationRoleService)
        {
            _bankOfQuestionCreateService = bankOfQuestionCreateService;
            _bankOfQuestionListService = bankOfQuestionListService;
            _bankOfQuestionDetailService = bankOfQuestionDetailService;
            _bankOfQuestionUpdateService = bankOfQuestionUpdateService;
            _bankOfQuestionDeleteService = bankOfQuestionDeleteService;
            _bankOfQuestionRestoreService = bankOfQuestionRestoreService;
            _bankOfQuestionDropDownService = bankOfQuestionDropDownService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Create(BankOfQuestionCreateDto addBankOfQuestionDto)
        {
            try
            {
                await CheckOrganizationPermition(addBankOfQuestionDto.OrganizationId);
                var result = await _bankOfQuestionCreateService.Execute(addBankOfQuestionDto, GetLoggedUserId(), GetClientCulture());
                return await SendResponse(result);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BankOfQuestionListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> List(
            [FromQuery] ListDeletedRequestDto request,
            [FromQuery] BankOfQuestionFilter filter,
            [FromQuery] SortDirection sortDirection,
            [FromQuery] BankOfQuestionSort sortColum,
            [FromQuery] BasePaging paging
        )
        {
            try
            {
                await CheckOrganizationPermition(request.ParentId);
                var result = await _bankOfQuestionListService.Execute(
                    x => x.OrganizationId == request.ParentId,
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
        [ProducesResponseType(typeof(IEnumerable<BankOfQuestionListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> DropDown(
            [FromQuery] ListDeletedRequestDto request,
            [FromQuery] DropDownFilter filter
            )
        {
            try
            {
                await CheckOrganizationPermition(request.ParentId);
                var result = await _bankOfQuestionDropDownService.Execute(
                    x => x.OrganizationId == request.ParentId,
                    request.IsDeleted,
                    new List<string>() { GetClientCulture() },
                    new List<Core.Base.Sort.BaseSort<Model.Edu.BankOfQuestions.BankOfQuestionDbo>>()
                    {

                        new Core.Base.Sort.BaseSort<Model.Edu.BankOfQuestions.BankOfQuestionDbo>()
                        {
                            Sort  = x=>x.IsDefault,
                            SortDirection = SortDirection.Descending
                        },
                        new Core.Base.Sort.BaseSort<Model.Edu.BankOfQuestions.BankOfQuestionDbo>()
                        {
                            Sort  = x=>x.BankOfQuestionsTranslations.First(x=>x.Culture.SystemIdentificator ==GetClientCulture()).Name,
                            SortDirection = SortDirection.Ascending
                        }
                    }, false
                );
                return await SendResponse(result);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(BankOfQuestionDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Detail([FromQuery] DetailRequestDto request)
        {
            try
            {
                await CheckOrganizationPermition(await _bankOfQuestionDetailService.GetOrganizationIdByObjectId(request.Id));
                var result = await _bankOfQuestionDetailService.Execute(request.Id, new List<string>() { GetClientCulture() });
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
        public async Task<ActionResult> Update(BankOfQuestionUpdateDto request)
        {
            try
            {
                await CheckOrganizationPermition(await _bankOfQuestionUpdateService.GetOrganizationIdByObjectId(request.Id));
                var result = await _bankOfQuestionUpdateService.Execute(request, GetLoggedUserId(), GetClientCulture(), null);
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
                await CheckOrganizationPermition(await _bankOfQuestionDeleteService.GetOrganizationIdByObjectId(request.Id));
                var result = await _bankOfQuestionDeleteService.Execute(request.Id, GetLoggedUserId());
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
                await CheckOrganizationPermition(await _bankOfQuestionRestoreService.GetOrganizationIdByObjectId(request.Id));
                var result = await _bankOfQuestionRestoreService.Execute(request.Id, GetLoggedUserId());
                return await SendResponse(result);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }
    }
}
