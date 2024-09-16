using Core.Base.Command.List;
using Core.Base.Filter;
using CourseStudyService.StudentAttendance.StudentAttendanceList.Convertor;
using CourseStudyService.StudentAttendance.StudentAttendanceList.Dto;
using Model.Edu.AttendanceStudent;
using Repository.AttendanceStudent;

namespace CourseStudyService.StudentAttendance.StudentAttendanceList.Command
{
    public class StudentAttendanceListCommand : BaseListCommand<StudentAttendanceDbo, IAttendanceStudentRepository, StudentAttendanceListDto, IStudentAttendanceListConvertor, RequestFilter>, IStudentAttendanceListCommand
    {
        public StudentAttendanceListCommand(IAttendanceStudentRepository repository, IStudentAttendanceListConvertor convertor) : base(repository, convertor)
        {
        }
    }
}
