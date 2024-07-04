using Core.Base.Dto;
using Core.DataTypes;
using EduApi.Controllers.ClientZone.Course;
using EduServices.CourseStudy.Dto;
using EduServices.CourseStudy.Service;
using EduServices.OrganizationRole.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace EduApi.Controllers.ClientZone.CourseStudy
{
    [ApiExplorerSettings(GroupName = "StudyZone")]
    public class CourseStudyController : BaseClientZoneController
    {
        private readonly ICourseStudyService _courseStudyService;

        public CourseStudyController(
            ICourseStudyService courseService,
            ILogger<CourseController> logger,
            IOrganizationRoleService organizationRoleService
        )
            : base(logger, organizationRoleService)
        {
            _courseStudyService = courseService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CourseMenuItemDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetCourseMenu([FromQuery] ListDeletedRequestDto request)
        {
            try
            {
                return SendResponse(_courseStudyService.GetCourseMenu(request.ParentId, GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SlideIdListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetAllSlideId([FromQuery] ListDeletedRequestDto request)
        {
            try
            {
                return SendResponse(_courseStudyService.GetAllSlideId(request.ParentId, GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CourseLessonStudyDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult CourseMaterialBrowse(Guid courseId)
        {
            try
            {

                return SendResponse(_courseStudyService.CourseMaterialBrowse(courseId, GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(CourseLessonStudyDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GoToSlide(Guid slideId, Guid courseId)
        {
            try
            {
                return SendResponse(_courseStudyService.GoToSlide(slideId, GetLoggedUserId(), courseId, GetClientCulture()));
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
        public ActionResult StartTest(StartTestDto startTestDto)
        {
            try
            {
                return SendResponse(_courseStudyService.StartTest(startTestDto.CourseLessonId, GetLoggedUserId(), startTestDto.CourseId));
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
        public ActionResult EvaluateTest(EvaluateTestDto evaluateTestDto)
        {
            try
            {
                return SendResponse(_courseStudyService.EvaluateTest(evaluateTestDto.UserTestSummaryId ?? Guid.Empty, evaluateTestDto.EvaluateQuestions, evaluateTestDto.CourseLessonId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(HashSet<ShowTestResultDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult ShowTestResult(Guid userTestSummaryId)
        {
            try
            {
                return SendResponse(_courseStudyService.ShowTestResult(userTestSummaryId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(HashSet<StudentTestListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetStudentTest()
        {
            try
            {
                return SendResponse(_courseStudyService.GetStudentTest(GetLoggedUserId(), GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(FinishCourseDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult FinishCourse(Guid courseStudentId, Guid courseId)
        {
            try
            {
                return SendResponse(_courseStudyService.FinishCourse(GetLoggedUserId(), courseStudentId, courseId, _courseStudyService.GetOrganizationIdByObjectId(courseId), GetClientCulture()));
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
        public ActionResult ResetCourse(ResetCourseDto resetCourseDto)
        {
            try
            {
                return SendResponse(_courseStudyService.ResetCourse(resetCourseDto.StudentTermId));
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
        public ActionResult UpdateActualTable(ActualTableUpdateDto updateActualTableDto)
        {
            try
            {
                return SendResponse(_courseStudyService.UpdateActualTable(updateActualTableDto));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetActualTable([FromQuery] Guid courseTermId)
        {
            try
            {
                return SendResponse(_courseStudyService.GetActualTable(courseTermId));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(StudentTestResultListDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult GetAllStudentTestResult([FromQuery] Guid courseId)
        {
            try
            {
                CheckOrganizationPermition(_courseStudyService.GetOrganizationIdByObjectId(courseId));
                return SendResponse(_courseStudyService.GetAllStudentTestResult(courseId, GetClientCulture()));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(ShowStudentAnswerDto), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public ActionResult ShowStudentAnswer([FromQuery] Guid courseId, [FromQuery] Guid studentTestResultId)
        {
            try
            {
                CheckOrganizationPermition(_courseStudyService.GetOrganizationIdByObjectId(courseId));
                return SendResponse(_courseStudyService.ShowStudentAnswer(studentTestResultId));
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
        public ActionResult SetLectorControl(SetLectorControlDto setLectorControlDto)
        {
            try
            {
                CheckOrganizationPermition(setLectorControlDto.Id);
                return SendResponse(_courseStudyService.SetLectorControl(setLectorControlDto));
            }
            catch (Exception e)
            {
                return SendSystemError(e);
            }
        }
    }
}
