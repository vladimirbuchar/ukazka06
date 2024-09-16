using CourseStudyService.StudentAttendance.StudentAttendanceCreate.Dto;
using Model.Edu.AttendanceStudent;

namespace CourseStudyService.StudentAttendance.StudentAttendanceCreate.Convertor
{
    public class StudentAttendanceCreateConvertor : IStudentAttendanceCreateConvertor
    {
        public Task<StudentAttendanceDbo> ConvertToBussinessEntity(StudentAttendanceCreateDto create, string culture)
        {
            throw new NotImplementedException();
        }
    }
}
