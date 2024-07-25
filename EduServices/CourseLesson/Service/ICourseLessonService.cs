using Core.Base.Filter;
using Core.Base.Service;
using Core.DataTypes;
using Model.Edu.CourseLesson;
using Services.CourseLesson.Dto;
using System;
using System.Threading.Tasks;

namespace Services.CourseLesson.Service
{
    public interface ICourseLessonService
        : IBaseService<
            CourseLessonDbo,
            CourseLessonCreateDto,
            CourseLessonListDto,
            CourseLessonDetailDto,
            CourseLessonUpdateDto,
            CourseLessonFileRepositoryDbo,
            FilterRequest
        >
    {
        Task<Result> UpdatePositionCourseLesson(CourseLessonUpdatePositionDto updatePositionCourseLesson, Guid userId);
    }
}
