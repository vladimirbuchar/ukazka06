using Core.Base.Dto;
using Core.DataTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Edu.CourseMaterial;
using Services.CourseMaterial.Dto;
using Services.CourseMaterial.Service;
using Services.OrganizationRole.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduApi.Controllers.ClientZone.CourseMaterial
{
    [ApiExplorerSettings(GroupName = "CourseMaterial")]
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
        public async Task<ActionResult> Create(CourseMaterialCreateDto addCourseMaterialDto)
        {
            try
            {
                await CheckOrganizationPermition(addCourseMaterialDto.OrganizationId);
                var response = await _courseMaterialService.AddObject(addCourseMaterialDto, GetLoggedUserId(), GetClientCulture());
                return await SendResponse(response);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CourseMaterialListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> List([FromQuery] ListDeletedRequestDto request)
        {
            try
            {
                await CheckOrganizationPermition(request.ParentId);
                var result = await _courseMaterialService.GetList(x => x.OrganizationId == request.ParentId, request.IsDeleted, GetClientCulture());
                return await SendResponse(result);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(CourseMaterialDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Detail([FromQuery] DetailRequestDto request)
        {
            try
            {
                await CheckOrganizationPermition(await _courseMaterialService.GetOrganizationIdByObjectId(request.Id));
                var result = await _courseMaterialService.GetDetail(request.Id, GetClientCulture());
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
        public async Task<ActionResult> Update(CourseMaterialUpdateDto updateCourseMaterialDto)
        {
            try
            {
                await CheckOrganizationPermition(await _courseMaterialService.GetOrganizationIdByObjectId(updateCourseMaterialDto.Id));
                var response = await _courseMaterialService.UpdateObject(updateCourseMaterialDto, GetLoggedUserId(), GetClientCulture());
                return await SendResponse(response);
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
                await CheckOrganizationPermition(await _courseMaterialService.GetOrganizationIdByObjectId(request.Id));
                var result = await _courseMaterialService.DeleteObject(request.Id, GetLoggedUserId());
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
                await CheckOrganizationPermition(await _courseMaterialService.GetOrganizationIdByObjectId(request.Id));
                var response = await _courseMaterialService.RestoreObject(request.Id, GetLoggedUserId());
                return await SendResponse(response);
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
                await CheckOrganizationPermition(await _courseMaterialService.GetOrganizationIdByObjectId(request.Id));
                var response = await _courseMaterialService.FileUpload(
                        request.Id,
                        GetClientCulture(),
                        GetLoggedUserId(),
                        new List<IFormFile>() { file },
                        new CourseMaterialFileRepositoryDbo() { CourseMaterialId = request.Id, }
                    );
                return await SendResponse(
                    response
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
        public async Task<ActionResult> FileDelete([FromQuery] DeleteDto request)
        {
            try
            {
                await CheckOrganizationPermition(await _courseMaterialService.GetOrganizationIdBFileId(request.Id));
                var result = await _courseMaterialService.FileDelete(request.Id, GetLoggedUserId());
                return await SendResponse(result);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CourseMaterialFileListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> GetFiles([FromQuery] DetailRequestDto request)
        {
            try
            {
                await CheckOrganizationPermition(await _courseMaterialService.GetOrganizationIdByObjectId(request.Id));
                var response = await _courseMaterialService.GetFiles(request.Id);
                return await SendResponse(response);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CourseMaterialFileListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> GetFilesStudent([FromQuery] DetailRequestDto request)
        {
            try
            {
                await CheckOrganizationPermition(await _courseMaterialService.GetOrganizationIdByObjectId(request.Id));
                var result = await _courseMaterialService.GetFilesStudent(request.Id);
                return await SendResponse(result);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }
    }
}
