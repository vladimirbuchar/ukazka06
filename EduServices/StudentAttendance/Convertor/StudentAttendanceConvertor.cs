using Model.Edu.AttendanceStudent;
using Services.StudentAttendance.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.StudentAttendance.Convertor
{
    public class StudentAttendanceConvertor : IStudentAttendanceConvertor
    {
        public Task<AttendanceStudentDbo> ConvertToBussinessEntity(StudentAttendanceCreateDto create, string culture)
        {
            return Task.FromResult(new AttendanceStudentDbo()
            {
                CourseTermDateId = create.CourseTermDateId,
                CourseStudentId = create.StudentId,
                CourseTermId = create.CourseTermId,
            });
        }

        public Task<List<StudentAttendanceListDto>> ConvertToWebModel(List<AttendanceStudentDbo> list, string culture)
        {
            throw new NotImplementedException();
        }

        public Task<StudentAttendanceDetailDto> ConvertToWebModel(AttendanceStudentDbo detail, string culture)
        {
            return Task.FromResult(new StudentAttendanceDetailDto() { });
        }
    }
}
