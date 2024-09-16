using Core.Base.Command.Create;
using CourseStudyService.StudentAttendance.StudentAttendanceCreate.Convertor;
using CourseStudyService.StudentAttendance.StudentAttendanceCreate.Dto;
using CourseStudyService.StudentAttendance.StudentAttendanceCreate.Validator;
using Model.Edu.AttendanceStudent;
using Repository.AttendanceStudent;

namespace CourseStudyService.StudentAttendance.StudentAttendanceCreate.Command
{
    public class StudentAttendanceCreateCommand : BaseCreateCommand<StudentAttendanceDbo, IAttendanceStudentRepository, StudentAttendanceCreateDto, IStudentAttendanceCreateConvertor, IStudentAttendanceCreateValidator>, IStudentAttendanceCreateCommand
    {
        public StudentAttendanceCreateCommand(IAttendanceStudentRepository repository, IStudentAttendanceCreateConvertor convertor, IStudentAttendanceCreateValidator validator) : base(repository, convertor, validator)
        {
        }
    }
}
