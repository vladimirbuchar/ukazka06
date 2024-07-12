using System;
using Core.Base.Filter;
using Core.Base.Service;
using Core.DataTypes;
using Model.Edu.CourseLesson;
using Services.CourseLesson.Dto;

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
        Result UpdatePositionCourseLesson(CourseLessonUpdatePositionDto updatePositionCourseLesson, Guid userId);
    }
}
