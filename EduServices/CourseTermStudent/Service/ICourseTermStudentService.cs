using Core.Base.Service;
using Model.Link;
using Services.CourseTermStudent.Dto;
using System;
using System.Collections.Generic;

namespace Services.CourseTermStudent.Service
{
    public interface ICourseTermStudentService : IBaseService<CourseStudentDbo, CourseTermStudentCreateDto, CourseTermStudentListDto, CourseTermStudentDetailDto>
    {
        HashSet<CourseTermStudentListDto> GetAllStudentInCourseTerm(Guid courseTermId);
    }
}
