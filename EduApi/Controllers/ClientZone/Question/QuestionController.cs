using Core.Base.Dto;
using Core.DataTypes;

//using EduServices.Answer.Permission;
using EduServices.OrganizationRole.Service;
using EduServices.Question.Dto;
using EduServices.Question.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace EduApi.Controllers.ClientZone.Question
{
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
        public ActionResult Create(QuestionCreateDto addQuestionDto)
        {
            try
            {
                CheckPermition(GetOrganizationIdByBankOfQuestion(addQuestionDto.BankOfQuestionId));
                return SendResponse(_questionService.AddObject(addQuestionDto, GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<QuestionListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult List([FromQuery] ListDeletedRequestDto request)
        {
            try
            {
                CheckPermition(GetOrganizationIdByBankOfQuestion(request.ParentId));
                return SendResponse(_questionService.GetList(x => x.BankOfQuestionId == request.ParentId, request.IsDeleted, GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(QuestionDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult Detail([FromQuery] DetailRequestDto request)
        {
            try
            {
                CheckPermition(GetOrganizationByQuestion(request.Id));
                return SendResponse(_questionService.GetDetail(request.Id, GetClientCulture()));
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
        public ActionResult Update(QuestionUpdateDto updateQuestionDto)
        {
            try
            {
                CheckPermition(GetOrganizationByQuestion(updateQuestionDto.Id));
                return SendResponse(_questionService.UpdateObject(updateQuestionDto, GetLoggedUserId(), GetClientCulture()));
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
                CheckPermition(GetOrganizationByQuestion(request.Id));
                _questionService.DeleteObject(request.Id, GetLoggedUserId());
                return SendResponse();
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
                CheckPermition(GetOrganizationByQuestion(request.Id));
                _questionService.RestoreObject(request.Id, GetLoggedUserId());
                return SendResponse();
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
                CheckPermition(GetOrganizationByQuestion(request.Id));
                _questionService.FileUpload(
                    request.Id,
                    GetClientCulture(),
                    GetLoggedUserId(),
                    new List<IFormFile>() { file },
                    new Model.Tables.Edu.TestQuestion.QuestionFileRepositoryDbo() { QuestionId = request.Id, },
                    x => x.QuestionId == request.Id && x.Culture.SystemIdentificator == GetClientCulture()
                );
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
