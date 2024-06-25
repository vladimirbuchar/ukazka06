using Core.Base.Dto;
using Core.DataTypes;
using EduServices.CourseMaterial.Dto;
using EduServices.CourseMaterial.Service;
using EduServices.OrganizationRole.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace EduApi.Controllers.ClientZone.CourseMaterial
{
    public class CourseMaterialController : BaseClientZoneController
    {
        private readonly ICourseMaterialService _courseMaterialService;

        public CourseMaterialController(
            ICourseMaterialService courseMaterialService,
            ILogger<CourseMaterialController> logger,
            IOrganizationRoleService organizationRoleService
        )
            : base(logger, organizationRoleService)
        {
            _courseMaterialService = courseMaterialService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult Create(CourseMaterialCreateDto addCourseMaterialDto)
        {
            try
            {
                CheckPermition(addCourseMaterialDto.OrganizationId);
                return SendResponse(_courseMaterialService.AddObject(addCourseMaterialDto, GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CourseMaterialListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult List([FromQuery] ListDeletedRequestDto request)
        {
            try
            {
                CheckPermition(request.ParentId);
                return SendResponse(_courseMaterialService.GetList(x => x.OrganizationId == request.ParentId, request.IsDeleted, GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(CourseMaterialDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult Detail([FromQuery] DetailRequestDto request)
        {
            try
            {
                CheckPermition(_courseMaterialService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_courseMaterialService.GetDetail(request.Id, GetClientCulture()));
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
        public ActionResult Update(CourseMaterialUpdateDto updateCourseMaterialDto)
        {
            try
            {
                CheckPermition(_courseMaterialService.GetOrganizationIdByObjectId(updateCourseMaterialDto.Id));
                return SendResponse(_courseMaterialService.UpdateObject(updateCourseMaterialDto, GetLoggedUserId(), GetClientCulture()));
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
                CheckPermition(_courseMaterialService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_courseMaterialService.DeleteObject(request.Id, GetLoggedUserId()));
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
                CheckPermition(_courseMaterialService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_courseMaterialService.RestoreObject(request.Id, GetLoggedUserId()));
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
                CheckPermition(_courseMaterialService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_courseMaterialService.FileUpload(
                    request.Id,
                    GetClientCulture(),
                GetLoggedUserId(),
                    new List<IFormFile>() { file },
                    new Model.Tables.Edu.CourseMaterial.CourseMaterialFileRepositoryDbo() { CourseMaterialId = request.Id, }
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
        public ActionResult FileDelete([FromQuery] DeleteDto request)
        {
            try
            {
                CheckPermition(_courseMaterialService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_courseMaterialService.FileDelete(request.Id, GetLoggedUserId()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CourseMaterialFileListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetFiles([FromQuery] DetailRequestDto request)
        {
            try
            {
                CheckPermition(_courseMaterialService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_courseMaterialService.GetFiles(request.Id));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CourseMaterialFileListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetFilesStudent([FromQuery] DetailRequestDto request)
        {
            try
            {
                CheckPermition(_courseMaterialService.GetOrganizationIdByObjectId(request.Id));
                return SendResponse(_courseMaterialService.GetFilesStudent(request.Id));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
