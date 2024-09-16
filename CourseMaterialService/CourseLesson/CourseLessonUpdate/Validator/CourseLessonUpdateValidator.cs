using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using CourseMaterialService.CourseLesson.CourseLessonDetail.Dto;
using CourseMaterialService.CourseLesson.CourseLessonUpdate.Dto;
using Model.Edu.CourseLesson;
using Repository.CourseLesson;

namespace CourseMaterialService.CourseLesson.CourseLessonUpdate.Validator
{
    public class CourseLessonUpdateValidator
        : BaseUpdateValidator<CourseLessonDbo, ICourseLessonRepository, CourseLessonUpdateDto>,
            ICourseLessonUpdateValidator
    {
        public CourseLessonUpdateValidator(ICourseLessonRepository repository)
            : base(repository) { }

        public override async Task<Result> IsValid(CourseLessonUpdateDto update)
        {
            Result<CourseLessonDetailDto> result = new();
            IsValidString(update.Name, result, MessageCategory.COURSE_LESSON, MessageItem.STRING_IS_EMPTY);
            return await Task.FromResult(result);
        }
    }
}
