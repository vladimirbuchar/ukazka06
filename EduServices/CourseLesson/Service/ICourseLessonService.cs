using Core.Base.Service;
using Core.DataTypes;
using Model.Edu.CourseLesson;
using Services.CourseLesson.Dto;
using System;

namespace Services.CourseLesson.Service
{
    public interface ICourseLessonService : IBaseService<CourseLessonDbo, CourseLessonCreateDto, CourseLessonListDto, CourseLessonDetailDto, CourseLessonUpdateDto, CourseLessonFileRepositoryDbo>
    {
        Result UpdatePositionCourseLesson(CourseLessonUpdatePositionDto updatePositionCourseLesson, Guid userId);
    }
}
