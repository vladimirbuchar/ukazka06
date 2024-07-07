using Core.Base.Convertor;
using Model.Edu.CourseLesson;
using Services.CourseLesson.Dto;

namespace Services.CourseLesson.Convertor
{
    public interface ICourseLessonConvertor : IBaseConvertor<CourseLessonDbo, CourseLessonCreateDto, CourseLessonListDto, CourseLessonDetailDto, CourseLessonUpdateDto> { }
}
