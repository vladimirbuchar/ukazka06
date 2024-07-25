using Core.Base.Dto;
using Core.DataTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Edu.CourseLesson;
using Services.CourseLesson.Dto;
using Services.CourseLesson.Service;
using Services.OrganizationRole.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduApi.Controllers.ClientZone.CourseLesson
{

    [ApiExplorerSettings(GroupName = "CourseMaterial")]
    public class CourseLessonController : BaseClientZoneController
    {
        private readonly ICourseLessonService _courseLessonService;

        public CourseLessonController(
            ILogger<CourseLessonController> logger,
            ICourseLessonService courseLessonService,
            IOrganizationRoleService organizationRoleService
        )
            : base(logger, organizationRoleService)
        {
            _courseLessonService = courseLessonService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Create(CourseLessonCreateDto addCourseLessonDto)
        {
            try
            {
                await CheckOrganizationPermition(await _courseLessonService.GetOrganizationIdByParentId(addCourseLessonDto.MaterialId));
                var result = await _courseLessonService.AddObject(addCourseLessonDto, GetLoggedUserId(), GetClientCulture());
                return await SendResponse(result);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CourseLessonListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> List([FromQuery] ListDeletedRequestDto request)
        {
            try
            {
                await CheckOrganizationPermition(await _courseLessonService.GetOrganizationIdByParentId(request.ParentId));
                var result = await _courseLessonService.GetList(x => x.CourseMaterialId == request.ParentId, request.IsDeleted, GetClientCulture());
                return await SendResponse(result);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(CourseLessonDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> Detail([FromQuery] DetailRequestDto request)
        {
            try
            {
                await CheckOrganizationPermition(await _courseLessonService.GetOrganizationIdByObjectId(request.Id));
                var result = await _courseLessonService.GetDetail(request.Id, GetClientCulture());
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
        public async Task<ActionResult> Update(CourseLessonUpdateDto updateCourseLessonDto)
        {
            try
            {
                await CheckOrganizationPermition(await _courseLessonService.GetOrganizationIdByObjectId(updateCourseLessonDto.Id));
                var result = await _courseLessonService.UpdateObject(updateCourseLessonDto, GetLoggedUserId(), GetClientCulture());
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
                await CheckOrganizationPermition(await _courseLessonService.GetOrganizationIdByObjectId(request.Id));
                var result = await _courseLessonService.DeleteObject(request.Id, GetLoggedUserId());
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
                await CheckOrganizationPermition(await _courseLessonService.GetOrganizationIdByObjectId(request.Id));
                var result = await _courseLessonService.RestoreObject(request.Id, GetLoggedUserId());
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
                await CheckOrganizationPermition(await _courseLessonService.GetOrganizationIdByObjectId(request.Id));
                var result = await _courseLessonService.FileUpload(
                        request.Id,
                        GetClientCulture(),
                        GetLoggedUserId(),
                        new List<IFormFile>() { file },
                        new CourseLessonFileRepositoryDbo() { CourseLessonId = request.Id, },
                        x => x.CourseLessonId == request.Id && x.Culture.SystemIdentificator == GetClientCulture()
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

        [HttpPut]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> UpdatePositionCourseLesson(CourseLessonUpdatePositionDto updatePositionCourseLesson)
        {
            try
            {
                await CheckOrganizationPermition(await _courseLessonService.GetOrganizationIdByObjectId(Guid.Parse(updatePositionCourseLesson.Ids.First())));
                var result = await _courseLessonService.UpdatePositionCourseLesson(updatePositionCourseLesson, GetLoggedUserId());
                return await SendResponse(result);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }
    }
}
