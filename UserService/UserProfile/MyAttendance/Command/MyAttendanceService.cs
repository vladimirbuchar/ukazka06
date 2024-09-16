using Core.Base.Command.List;
using Core.Base.Filter;
using Core.Base.Paging;
using Core.DataTypes;
using Model.Edu.AttendanceStudent;
using Model.Link;
using Repository.AttendanceStudent;
using Repository.CourseStudent;
using System.Linq.Expressions;
using System.Web.Helpers;
using UserService.UserProfile.MyAttendance.Convertor;
using UserService.UserProfile.MyAttendance.Dto;

namespace UserService.UserProfile.MyAttendance.Command
{
    public class MyAttendanceService
        : BaseListCommand<CourseStudentDbo, ICourseStudentRepository, MyAttendanceListDto, IMyAttendanceConvertor, RequestFilter>,
            IMyAttendanceService
    {
        private readonly IAttendanceStudentRepository _attendanceStudentRepository;

        public MyAttendanceService(
            IAttendanceStudentRepository attendanceStudentRepository,
            ICourseStudentRepository repository,
            IMyAttendanceConvertor convertor
        )
            : base(repository, convertor)
        {
            _attendanceStudentRepository = attendanceStudentRepository;
        }

        public override async Task<ResultTable<MyAttendanceListDto>> Execute(
            Expression<Func<CourseStudentDbo, bool>>? predicate = null,
            bool deleted = false,
            List<string>? culture = null,
            RequestFilter? filter = null,
            string sortColumn = "",
            SortDirection sortDirection = SortDirection.Ascending,
            BasePaging? paging = null
        )
        {
            List<CourseStudentDbo> myCourse = await _repository.GetEntities(false, predicate);

            foreach (CourseStudentDbo course in myCourse)
            {
                List<StudentAttendanceDbo> getStudentAttendances = course
                    .AttendanceStudents.Where(x =>
                        x.CourseTermId == course.CourseTermId && x.CourseStudentId == course.UserInOrganizationId && x.IsDeleted == false
                    )
                    .ToList();
                foreach (StudentAttendanceDbo item in getStudentAttendances)
                {
                    item.MyAttendance.Add(
                        await _attendanceStudentRepository.GetEntity(
                            false,
                            x => x.CourseStudentId == item.CourseStudentId && x.CourseTermDateId == item.CourseTermDateId
                        )
                    );
                }
            }
            List<MyAttendanceListDto> data = await _convertor.ConvertToWebModel(myCourse, culture);
            return new ResultTable<MyAttendanceListDto>() { Data = data, TotalCount = await _repository.GetTotalCount(false, predicate) };
        }
    }
}
