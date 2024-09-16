using Core.Base.Command.Delete;
using Model.Edu.AttendanceStudent;
using Repository.AttendanceStudent;

namespace CourseStudyService.StudentAttendance.StudentAttendanceDelete.Command
{
    public class StudentAttendanceDeleteCommand : BaseDeleteCommand<StudentAttendanceDbo, IAttendanceStudentRepository>, IStudentAttendanceDeleteCommand
    {
        public StudentAttendanceDeleteCommand(IAttendanceStudentRepository repository) : base(repository)
        {
        }
    }
}
