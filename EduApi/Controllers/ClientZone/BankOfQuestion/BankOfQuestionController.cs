using Core.Base.Dto;
using Core.DataTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.BankOfQuestion.Dto;
using Services.BankOfQuestion.Service;
using Services.OrganizationRole.Service;
using System;
using System.Collections.Generic;

namespace EduApi.Controllers.ClientZone.BankOfQuestion
{
    public class BankOfQuestionController : BaseClientZoneController
    {
        private readonly IBankOfQuestionService _bankOfQuestionService;

        public BankOfQuestionController(
            IBankOfQuestionService bankOfQuestionService,
            ILogger<BankOfQuestionController> logger,
            IOrganizationRoleService organizationRoleService
        )
            : base(logger, organizationRoleService) => _bankOfQuestionService = bankOfQuestionService;

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult Create(BankOfQuestionCreateDto addBankOfQuestionDto)
        {
            try
            {
                CheckOrganizationPermition(addBankOfQuestionDto.OrganizationId);
                return SendResponse(_bankOfQuestionService.AddObject(addBankOfQuestionDto, GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BankOfQuestionListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult List([FromQuery] ListDeletedRequestDto request)
        {
            try
            {
                CheckOrganizationPermition(request.ParentId);
                return SendResponse(_bankOfQuestionService.GetList(x => x.OrganizationId == request.ParentId, request.IsDeleted, GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(BankOfQuestionDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult Detail([FromQuery] DetailRequestDto request)
        {
            try
            {
                CheckOrganizationPermition(_bankOfQuestionService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_bankOfQuestionService.GetDetail(request.Id, GetClientCulture()));
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
        public ActionResult Update(BankOfQuestionUpdateDto request)
        {
            try
            {
                CheckOrganizationPermition(_bankOfQuestionService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_bankOfQuestionService.UpdateObject(request, GetLoggedUserId(), GetClientCulture()));
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
                CheckOrganizationPermition(_bankOfQuestionService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_bankOfQuestionService.DeleteObject(request.Id, GetLoggedUserId()));
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
                CheckOrganizationPermition(_bankOfQuestionService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_bankOfQuestionService.RestoreObject(request.Id, GetLoggedUserId()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
