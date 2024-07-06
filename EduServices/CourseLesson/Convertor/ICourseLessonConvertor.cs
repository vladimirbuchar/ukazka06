﻿using Core.Base.Convertor;
using EduServices.CourseLesson.Dto;
using Model.Edu.CourseLesson;

namespace EduServices.CourseLesson.Convertor
{
    public interface ICourseLessonConvertor : IBaseConvertor<CourseLessonDbo, CourseLessonCreateDto, CourseLessonListDto, CourseLessonDetailDto, CourseLessonUpdateDto> { }
}
