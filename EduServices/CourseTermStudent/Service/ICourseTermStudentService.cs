using Core.Base.Filter;
using Core.Base.Service;
using Model.Link;
using Services.CourseTermStudent.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.CourseTermStudent.Service
{
    public interface ICourseTermStudentService
        : IBaseService<CourseStudentDbo, CourseTermStudentCreateDto, CourseTermStudentListDto, CourseTermStudentDetailDto, FilterRequest>
    {
        Task<List<CourseTermStudentListDto>> GetAllStudentInCourseTerm(Guid courseTermId);
    }
}
