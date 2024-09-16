using Core.Base.Controller;
using Core.DataTypes;
using CourseStudyService.Lector.LectorCourseList.Command;
using CourseStudyService.Lector.LectorCourseList.Dto;
using CourseStudyService.Student.StudentCourseList.Command;
using CourseStudyService.Student.StudentCourseList.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.UserProfile.ManagedCourse.Command;
using UserService.UserProfile.ManagedCourse.Dto;
using UserService.UserProfile.MyAttendance.Command;
using UserService.UserProfile.MyAttendance.Dto;
using UserService.UserProfile.MyCertificate.Command;
using UserService.UserProfile.MyCertificate.Dto;
using UserService.UserProfile.MyCourseList.Dto;
using UserService.UserProfile.MyEvaluation.Command;
using UserService.UserProfile.MyEvaluation.Dto;
using UserService.UserProfile.MyOrganization.Command;
using UserService.UserProfile.MyOrganization.Dto;
using UserService.UserProfile.MyTimeTable.Command;
using UserService.UserProfile.MyTimeTable.Dto;

namespace EduApi.Controllers.ClientZone.UserProfile
{
    [ApiExplorerSettings(GroupName = "User")]
    public class UserProfileController : BaseClientZoneController
    {

        private readonly IMyOrganizationService _myOrganizationService;
        private readonly IMyCertificateService _myCertificateService;
        private readonly IMyEvaluationService _myEvaluationService;
        private readonly IManagedCourseService _managedCourseService;
        private readonly IMyAttendanceService _myAttendanceService;
        private readonly IStudentCourseListCommand _studentCourseListCommand;
        private readonly ILectorCourseListCommand _lectorCourseListCommand;
        private readonly IMyTimeTableCommand _myTimeTableCommand;

        public IMyEvaluationService MyEvaluationService => _myEvaluationService;

        public UserProfileController(
            ILogger<UserProfileController> logger,
            EduDbContext organizationRoleService,
            IMyOrganizationService myOrganizationService,
            IMyCertificateService myCertificateService,
            IMyEvaluationService myEvaluationService,
            IManagedCourseService managedCourseService,
            IMyAttendanceService myAttendanceService,
            IStudentCourseListCommand studentCourseListCommand,
            ILectorCourseListCommand lectorCourseListCommand,
            IMyTimeTableCommand myTimeTableCommand
        )
            : base(logger, organizationRoleService)
        {
            _myOrganizationService = myOrganizationService;
            _myCertificateService = myCertificateService;
            _myEvaluationService = myEvaluationService;
            _managedCourseService = managedCourseService;
            _myAttendanceService = myAttendanceService;
            _studentCourseListCommand = studentCourseListCommand;
            _lectorCourseListCommand = lectorCourseListCommand;
            _myTimeTableCommand = myTimeTableCommand;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MyCertificateListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> GetMyCertificate()
        {
            try
            {
                return await SendResponse(
                    await _myCertificateService.Execute(
                        x => x.UserId == GetLoggedUserId(),
                        false,
                        new List<string>() { GetClientCulture() },
                        null,
                        "ActiveFrom",
                        System.Web.Helpers.SortDirection.Ascending
                    )
                );
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MyCourseListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]

        public async Task<ActionResult> GetMyCourse([FromQuery] bool hideFinishCourse)
        {
            try
            {
                List<MyCourseListDto> myCourse = [];
                List<StudentCourseListDto> study = (await _studentCourseListCommand.Execute(x => hideFinishCourse ? (x.UserInOrganization.UserId == GetLoggedUserId() && x.CourseFinish == false) : (x.UserInOrganization.UserId == GetLoggedUserId()), false, new List<string>()
                {
                    GetClientCulture()
                })).Data;

                foreach (StudentCourseListDto item in study)
                {
                    myCourse.Add(new MyCourseListDto()
                    {
                        ActiveFrom = item.ActiveFrom,
                        ActiveTo = item.ActiveTo,
                        BranchName = item.BranchName,
                        ClassRoom = item.ClassRoom,
                        CourseFinish = item.CourseFinish,
                        CourseName = item.CourseName,
                        CourseTermId = item.CourseTermId,
                        Friday = item.Friday,
                        Id = item.Id,
                        IsLector = false,
                        IsStudent = true,
                        Monday = item.Monday,
                        OrganizationName = item.OrganizationName,
                        Saturday = item.Saturday,
                        Sunday = item.Sunday,
                        Thursday = item.Thursday,
                        TimeFrom = item.TimeFrom,
                        TimeTo = item.TimeTo,
                        Tuesday = item.Tuesday,
                        UserId = item.UserId,
                        Wednesday = item.Wednesday
                    });
                }


                List<LectorCourseListDto> lector = (await _lectorCourseListCommand.Execute(x => x.UserInOrganization.UserId == GetLoggedUserId(), false, new List<string>() { GetClientCulture() })).Data;
                foreach (LectorCourseListDto item in lector)
                {
                    myCourse.Add(new MyCourseListDto()
                    {
                        ActiveFrom = item.ActiveFrom,
                        ActiveTo = item.ActiveTo,
                        BranchName = item.BranchName,
                        ClassRoom = item.ClassRoom,
                        CourseFinish = item.CourseFinish,
                        CourseName = item.CourseName,
                        CourseTermId = item.CourseTermId,
                        Friday = item.Friday,
                        Id = item.Id,
                        IsLector = true,
                        IsStudent = false,
                        Monday = item.Monday,
                        OrganizationName = item.OrganizationName,
                        Saturday = item.Saturday,
                        Sunday = item.Sunday,
                        Thursday = item.Thursday,
                        TimeFrom = item.TimeFrom,
                        TimeTo = item.TimeTo,
                        Tuesday = item.Tuesday,
                        UserId = item.UserId,
                        Wednesday = item.Wednesday
                    });
                }
                return await SendResponse(myCourse);
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<MyTimeTableListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]

        public async Task<ActionResult> GetMyTimeTable()
        {
            try
            {
                return await SendResponse(await _myTimeTableCommand.Execute(GetLoggedUserId(), new List<string>() { GetClientCulture() }));
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<MyAttendanceListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> GetMyAttendance()
        {
            try
            {
                return await SendResponse(
                    await _myAttendanceService.Execute(
                        x => x.UserInOrganization.UserId == GetLoggedUserId() && x.CourseFinish == true,
                        false,
                        new List<string>() { GetClientCulture() }
                    )
                );
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MyOrganizationListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> GetMyOrganizations()
        {
            try
            {
                return await SendResponse(
                    await _myOrganizationService.Execute(
                        x => x.UserId == GetLoggedUserId(),
                        false,
                        new List<string>() { GetClientCulture() },
                        null,
                        "",
                        System.Web.Helpers.SortDirection.Ascending
                    )
                );
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ManagedCourseListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> GetManagedCourse()
        {
            try
            {
                return await SendResponse(
                    await _managedCourseService.Execute(
                        x =>
                            x.UserId == GetLoggedUserId()
                            && (
                                x.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.ORGANIZATION_OWNER
                                || x.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.ORGANIZATION_ADMINISTRATOR
                                || x.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.COURSE_EDITOR
                                || x.OrganizationRole.SystemIdentificator == Core.Constants.OrganizationRole.COURSE_ADMINISTATOR
                            ),
                        false,
                        new List<string>() { GetClientCulture() }
                    )
                );
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(HashSet<MyEvaluationListDto>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [ProducesResponseType(typeof(SystemError), 500)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(void), 403)]
        public async Task<ActionResult> GetMyEvaluation()
        {
            try
            {
                return await SendResponse(
                    await MyEvaluationService.Execute(
                        x => x.CourseStudent.UserInOrganization.UserId == GetLoggedUserId(),
                        false,
                        new List<string>() { GetClientCulture() },
                        null
                    )
                );
            }
            catch (Exception e)
            {
                return await SendSystemError(e);
            }
        }
    }
}
