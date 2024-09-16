using CourseStudyService.StudentAttendance.StudentAttendanceList.Dto;
using Model.Edu.AttendanceStudent;

namespace CourseStudyService.StudentAttendance.StudentAttendanceList.Convertor
{
    public class StudentAttendanceListConvertor : IStudentAttendanceListConvertor
    {
        public Task<List<StudentAttendanceListDto>> ConvertToWebModel(List<StudentAttendanceDbo> list, List<string> culture)
        {
            return Task.FromResult(list.Select(x => new StudentAttendanceListDto()).ToList());
        }
    }
}
