using EduServices.StudentAttendance.Dto;
using Model.Edu.AttendanceStudent;
using System;
using System.Collections.Generic;

namespace EduServices.StudentAttendance.Convertor
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
