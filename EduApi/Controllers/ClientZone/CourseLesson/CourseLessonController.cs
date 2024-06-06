using Core.Base.Dto;
using Core.DataTypes;
using EduServices.CourseLesson.Dto;
using EduServices.CourseLesson.Service;
using EduServices.OrganizationRole.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EduApi.Controllers.ClientZone.CourseLesson
{
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
        public ActionResult Create(CourseLessonCreateDto addCourseLessonDto)
        {
            try
            {
                CheckPermition(GetOrganizationByCourseMaterial(addCourseLessonDto.MaterialId));
                return SendResponse(_courseLessonService.AddObject(addCourseLessonDto, GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CourseLessonListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult List([FromQuery] ListDeletedRequestDto request)
        {
            try
            {
                CheckPermition(GetOrganizationByCourseMaterial(request.ParentId));
                return SendResponse(_courseLessonService.GetList(x => x.CourseMaterialId == request.ParentId, request.IsDeleted, GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(CourseLessonDetailDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult Detail([FromQuery] DetailRequestDto request)
        {
            try
            {
                CheckPermition(GetOrganizationByCourseLesson(request.Id));
                return SendResponse(_courseLessonService.GetDetail(request.Id, GetClientCulture()));
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
        public ActionResult Update(CourseLessonUpdateDto updateCourseLessonDto)
        {
            try
            {
                CheckPermition(GetOrganizationByCourseLesson(updateCourseLessonDto.Id));
                return SendResponse(_courseLessonService.UpdateObject(updateCourseLessonDto, GetLoggedUserId(), GetClientCulture()));
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
                CheckPermition(GetOrganizationByCourseLesson(request.Id));
                _courseLessonService.DeleteObject(request.Id, GetLoggedUserId());
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
                CheckPermition(GetOrganizationByCourseLesson(request.Id));
                _courseLessonService.RestoreObject(request.Id, GetLoggedUserId());
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
                CheckPermition(GetOrganizationByCourseLesson(request.Id));
                _courseLessonService.FileUpload(
                    request.Id,
                    GetClientCulture(),
                    GetLoggedUserId(),
                    new List<IFormFile>() { file },
                    new Model.Tables.Edu.CourseLesson.CourseLessonFileRepositoryDbo() { CourseLessonId = request.Id, },
                    x => x.CourseLessonId == request.Id && x.Culture.SystemIdentificator == GetClientCulture()
                );
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
        public ActionResult UpdatePositionCourseLesson(CourseLessonUpdatePositionDto updatePositionCourseLesson)
        {
            try
            {
                CheckPermition(GetOrganizationByCourseLesson(Guid.Parse(updatePositionCourseLesson.Ids.First())));
                _courseLessonService.UpdatePositionCourseLesson(updatePositionCourseLesson, GetLoggedUserId());
                return SendResponse();
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
