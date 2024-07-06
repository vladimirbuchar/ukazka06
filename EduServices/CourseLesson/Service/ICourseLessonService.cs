using Core.Base.Service;
using Core.DataTypes;
using EduServices.CourseLesson.Dto;
using Model.Edu.CourseLesson;
using System;

namespace EduServices.CourseLesson.Service
{
    public interface ICourseLessonService : IBaseService<CourseLessonDbo, CourseLessonCreateDto, CourseLessonListDto, CourseLessonDetailDto, CourseLessonUpdateDto, CourseLessonFileRepositoryDbo>
    {
        Result UpdatePositionCourseLesson(CourseLessonUpdatePositionDto updatePositionCourseLesson, Guid userId);
    }
}
