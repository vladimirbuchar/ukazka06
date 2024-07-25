using Core.Base.Dto;
using Core.DataTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Edu.CourseLessonItem;
using Services.CourseLessonItem.Dto;
using Services.CourseLessonItem.Service;
using Services.OrganizationRole.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduApi.Controllers.ClientZone.CourseLessonItem
{
    [ApiExplorerSettings(GroupName = "CourseMaterial")]
    public class CourseLessonItemController : BaseClientZoneController
    {
        private readonly ICourseLessonItemService _courseLessonItemService;

        public CourseLessonItemController(
            ILogger<CourseLessonItemController> logger,
            ICourseLessonItemService courseLessonItemSerice,
            IOrganizationRoleService organizationRoleService
        )
            : base(logger, organizationRoleService)
        {
            _courseLessonItemService = courseLessonItemSerice;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Create(CourseLessonItemCreateDto courseLessonItemCreateDto)
        {
            try
            {
                await CheckOrganizationPermition(await _courseLessonItemService.GetOrganizationIdByParentId(courseLessonItemCreateDto.CourseLessonId));
                var result = await _courseLessonItemService.AddObject(courseLessonItemCreateDto, GetLoggedUserId(), GetClientCulture());
                return await SendResponse(result);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CourseLessonItemListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> List([FromQuery] ListDeletedRequestDto request)
        {
            await CheckOrganizationPermition(await _courseLessonItemService.GetOrganizationIdByParentId(request.ParentId));
            var result = await _courseLessonItemService.GetList(x => x.CourseLessonId == request.ParentId, request.IsDeleted, GetClientCulture());
            return await SendResponse(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(CourseLessonItemDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Detail([FromQuery] DetailRequestDto request)
        {
            await CheckOrganizationPermition(await _courseLessonItemService.GetOrganizationIdByObjectId(request.Id));
            return await SendResponse(await _courseLessonItemService.GetDetail(request.Id, GetClientCulture()));
        }

        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Update(CourseLessonItemUpdateDto updateCourseLessonItemDto)
        {
            try
            {
                await CheckOrganizationPermition(await _courseLessonItemService.GetOrganizationIdByObjectId(updateCourseLessonItemDto.Id));
                var result = await _courseLessonItemService.UpdateObject(updateCourseLessonItemDto, GetLoggedUserId(), GetClientCulture());
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
                await CheckOrganizationPermition(await _courseLessonItemService.GetOrganizationIdByObjectId(request.Id));
                var result = await _courseLessonItemService.DeleteObject(request.Id, GetLoggedUserId());
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
                await CheckOrganizationPermition(await _courseLessonItemService.GetOrganizationIdByObjectId(request.Id));
                var result = await _courseLessonItemService.RestoreObject(request.Id, GetLoggedUserId());
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
                await CheckOrganizationPermition(await _courseLessonItemService.GetOrganizationIdByObjectId(request.Id));
                var result = await _courseLessonItemService.FileUpload(
                        request.Id,
                        GetClientCulture(),
                        GetLoggedUserId(),
                        new List<IFormFile>() { file },
                        new CourseLessonItemFileRepositoryDbo() { CourseLessonItemId = request.Id, }
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
                await CheckOrganizationPermition(await _courseLessonItemService.GetOrganizationIdBFileId(request.Id));
                var result = await _courseLessonItemService.FileDelete(request.Id, GetLoggedUserId());
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
        public async Task<ActionResult> UpdatePositionCourseLessonItem(CourseLessonItemUpdatePositionDto updatePositionCourseLessonItemDto)
        {
            try
            {
                await CheckOrganizationPermition(
                    await _courseLessonItemService.GetOrganizationIdByObjectId(Guid.Parse(updatePositionCourseLessonItemDto.Ids.First()))
                );
                var result = await _courseLessonItemService.UpdatePositionCourseLessonItem(updatePositionCourseLessonItemDto, GetLoggedUserId());
                return await SendResponse(result);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }
    }
}
