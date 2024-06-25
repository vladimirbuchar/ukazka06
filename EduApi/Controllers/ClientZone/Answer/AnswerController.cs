using Core.Base.Dto;
using Core.DataTypes;
using EduServices.Answer.Dto;
using EduServices.Answer.Service;
using EduServices.OrganizationRole.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace EduApi.Controllers.ClientZone.Answer
{
    public class AnswerController : BaseClientZoneController
    {
        private readonly IAnswerService _answerService;

        public AnswerController(
            IAnswerService answerService,
            ILogger<AnswerController> logger,
            IOrganizationRoleService organizationRoleService
        )
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
        public ActionResult Create(AnswerCreateDto request)
        {
            try
            {
                CheckPermition(_answerService.GetOrganizationIdByObjectId(request.QuestionId));
                return SendResponse(_answerService.AddObject(request, GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AnswerListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult List([FromQuery] ListDeletedRequestDto request)
        {
            try
            {
                CheckPermition(_answerService.GetOrganizationIdByObjectId(request.ParentId));
                return SendResponse(_answerService.GetList(x => x.TestQuestionId == request.ParentId, request.IsDeleted, GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(AnswerDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult Detail([FromQuery] DetailRequestDto request)
        {
            try
            {
                CheckPermition(_answerService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_answerService.GetDetail(request.Id, GetClientCulture()));
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
        public ActionResult Update(AnswerUpdateDto request)
        {
            try
            {
                CheckPermition(_answerService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_answerService.UpdateObject(request, GetLoggedUserId(), GetClientCulture()));
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
                CheckPermition(_answerService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_answerService.DeleteObject(request.Id, GetLoggedUserId()));
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
                CheckPermition(_answerService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_answerService.RestoreObject(request.Id, GetLoggedUserId()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult FileUpload([FromQuery] DetailRequestDto request, IFormFile file)
        {
            try
            {
                CheckPermition(_answerService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_answerService.FileUpload(
                    request.Id,
                    GetClientCulture(),
                    GetLoggedUserId()
                    ,
                    new List<IFormFile>() { file },
                    new Model.Tables.Edu.Answer.AnswerFileRepositoryDbo() { AnswerId = request.Id, },
                    x => x.AnswerId == request.Id && x.Culture.SystemIdentificator == GetClientCulture()
                ));
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
        public ActionResult DeleteAnswerInQuestion([FromQuery] DeleteByParentIdDto request)
        {
            try
            {
                CheckPermition(_answerService.GetOrganizationIdByObjectId(request.ParentId));
                return SendResponse(_answerService.MultipleDelete(x => x.TestQuestionId == request.ParentId, GetLoggedUserId()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
