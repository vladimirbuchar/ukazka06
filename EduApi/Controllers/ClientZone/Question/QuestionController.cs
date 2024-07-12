using System;
using System.Collections.Generic;
using System.Web.Helpers;
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
        public ActionResult Create(QuestionCreateDto addQuestionDto)
        {
            try
            {
                CheckOrganizationPermition(_questionService.GetOrganizationIdByParentId(addQuestionDto.BankOfQuestionId));
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
        public ActionResult List(
            [FromQuery] ListDeletedRequestDto request,
            [FromQuery] QuestionFilter filter,
            [FromQuery] SortDirection sortDirection,
            [FromQuery] QuestionSort sortColum,
            [FromQuery] BasePaging paging
        )
        {
            try
            {
                CheckOrganizationPermition(_questionService.GetOrganizationIdByParentId(request.ParentId));
                return SendResponse(
                    _questionService.GetList(
                        x => x.BankOfQuestionId == request.ParentId,
                        request.IsDeleted,
                        GetClientCulture(),
                        filter,
                        sortColum.ToString(),
                        sortDirection,
                        paging
                    )
                );
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
                CheckOrganizationPermition(_questionService.GetOrganizationIdByObjectId(request.Id));
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
                CheckOrganizationPermition(_questionService.GetOrganizationIdByObjectId(updateQuestionDto.Id));
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
                CheckOrganizationPermition(_questionService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_questionService.DeleteObject(request.Id, GetLoggedUserId()));
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
                CheckOrganizationPermition(_questionService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_questionService.RestoreObject(request.Id, GetLoggedUserId()));
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
                CheckOrganizationPermition(_questionService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(
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
                return SendSystemError(e);
            }
        }
    }
}
