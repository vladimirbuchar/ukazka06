using System;
using System.Collections.Generic;
using Core.Base.Service;
using EduServices.CourseTermStudent.Dto;
using Model.Link;

namespace EduServices.CourseTermStudent.Service
{
    public interface ICourseTermStudentService : IBaseService<CourseStudentDbo, CourseTermStudentCreateDto, CourseTermStudentListDto, CourseTermStudentDetailDto>
    {
        HashSet<CourseTermStudentListDto> GetAllStudentInCourseTerm(Guid courseTermId);
    }
}
