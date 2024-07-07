using System;
using System.Collections.Generic;
using Model.Edu.AttendanceStudent;
using Services.StudentAttendance.Dto;

namespace Services.StudentAttendance.Convertor
{
    public class StudentAttendanceConvertor : IStudentAttendanceConvertor
    {
        public AttendanceStudentDbo ConvertToBussinessEntity(StudentAttendanceCreateDto create, string culture)
        {
            return new AttendanceStudentDbo()
            {
                CourseTermDateId = create.CourseTermDateId,
                CourseStudentId = create.StudentId,
                CourseTermId = create.CourseTermId,
            };
        }

        public HashSet<StudentAttendanceListDto> ConvertToWebModel(HashSet<AttendanceStudentDbo> list, string culture)
        {
            throw new NotImplementedException();
        }

        public StudentAttendanceDetailDto ConvertToWebModel(AttendanceStudentDbo detail, string culture)
        {
            return new StudentAttendanceDetailDto();
        }
    }
}
