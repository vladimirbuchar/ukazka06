using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model.Edu.AttendanceStudent;
using Services.StudentAttendance.Dto;
using Services.StudentAttendance.Commands.StudentAttendanceCreate.Dto;

namespace Services.StudentAttendance.Convertor
{
    public class StudentAttendanceConvertor : IStudentAttendanceConvertor
    {
        public Task<StudentAttendanceDbo> ConvertToBussinessEntity(StudentAttendanceCreateDto create, string culture)
        {
            return Task.FromResult(
                new StudentAttendanceDbo()
                {
                    CourseTermDateId = create.CourseTermDateId,
                    CourseStudentId = create.StudentId,
                    CourseTermId = create.CourseTermId,
                }
            );
        }

        public Task<List<StudentAttendanceListDto>> ConvertToWebModel(List<StudentAttendanceDbo> list, string culture)
        {
            throw new NotImplementedException();
        }

        public Task<StudentAttendanceDetailDto> ConvertToWebModel(StudentAttendanceDbo detail, string culture)
        {
            return Task.FromResult(new StudentAttendanceDetailDto() { });
        }
    }
}
