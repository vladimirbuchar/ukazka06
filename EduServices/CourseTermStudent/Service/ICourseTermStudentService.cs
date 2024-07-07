using System;
using System.Collections.Generic;
using Core.Base.Service;
using Model.Link;
using Services.CourseTermStudent.Dto;

namespace Services.CourseTermStudent.Service
{
    public interface ICourseTermStudentService : IBaseService<CourseStudentDbo, CourseTermStudentCreateDto, CourseTermStudentListDto, CourseTermStudentDetailDto>
    {
        HashSet<CourseTermStudentListDto> GetAllStudentInCourseTerm(Guid courseTermId);
    }
}
