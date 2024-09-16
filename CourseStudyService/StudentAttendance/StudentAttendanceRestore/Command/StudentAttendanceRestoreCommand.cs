using Core.Base.Command.Restore;
using Model.Edu.AttendanceStudent;
using Repository.AttendanceStudent;

namespace CourseStudyService.StudentAttendance.StudentAttendanceRestore.Command
{
    public class StudentAttendanceRestoreCommand : BaseRestoreCommand<StudentAttendanceDbo, IAttendanceStudentRepository>, IStudentAttendanceRestoreCommand
    {
        public StudentAttendanceRestoreCommand(IAttendanceStudentRepository repository) : base(repository)
        {
        }
    }
}
