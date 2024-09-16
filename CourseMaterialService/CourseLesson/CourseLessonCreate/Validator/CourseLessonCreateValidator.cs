using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using CourseMaterialService.CourseLesson.CourseLessonCreate.Dto;
using Model.Edu.CourseLesson;
using Repository.CourseLesson;

namespace CourseMaterialService.CourseLesson.CourseLessonCreate.Validator
{
    public class CourseLessonCreateValidator
        : BaseCreateValidator<CourseLessonDbo, ICourseLessonRepository, CourseLessonCreateDto>,
            ICourseLessonCreateValidator
    {
        public CourseLessonCreateValidator(ICourseLessonRepository repository)
            : base(repository) { }

        public override async Task<ResultInsert> IsValid(CourseLessonCreateDto create)
        {
            ResultInsert result = new();
            IsValidString(create.Name, result, MessageCategory.COURSE_LESSON, MessageItem.STRING_IS_EMPTY);
            if (!CourseLessonType.VALIDATE.Contains(create.Type))
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.COURSE_LESSON, MessageItem.INVALID_VALUE));
            }
            return await Task.FromResult(result);
        }
    }
}
