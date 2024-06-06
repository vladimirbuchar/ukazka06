using EduServices.StudentAttendance.Dto;
using Model.Tables.Edu.AttendanceStudent;
using System;
using System.Collections.Generic;

namespace EduServices.StudentAttendance.Convertor
{
    public class StudentAttendanceConvertor : IStudentAttendanceConvertor
    {
        public StudentAttendanceDbo ConvertToBussinessEntity(StudentAttendanceCreateDto create, string culture)
        {
            return new StudentAttendanceDbo()
            {
                CourseTermDateId = create.CourseTermDateId,
                CourseStudentId = create.StudentId,
                CourseTermId = create.CourseTermId,
            };
        }

        public HashSet<StudentAttendanceListDto> ConvertToWebModel(HashSet<StudentAttendanceDbo> list, string culture)
        {
            throw new NotImplementedException();
        }

        public StudentAttendanceDetailDto ConvertToWebModel(StudentAttendanceDbo detail, string culture)
        {
            return new StudentAttendanceDetailDto();
        }
    }
}
