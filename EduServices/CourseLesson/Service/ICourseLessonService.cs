using Core.Base.Service;
using EduServices.CourseLesson.Dto;
using Model.Tables.Edu.CourseLesson;
using System;

namespace EduServices.CourseLesson.Service
{
    public interface ICourseLessonService : IBaseService<CourseLessonDbo, CourseLessonCreateDto, CourseLessonListDto, CourseLessonDetailDto, CourseLessonUpdateDto, CourseLessonFileRepositoryDbo>
    {
        void UpdatePositionCourseLesson(CourseLessonUpdatePositionDto updatePositionCourseLesson, Guid userId);
    }
}
