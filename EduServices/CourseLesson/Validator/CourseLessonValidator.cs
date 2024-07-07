using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.Edu.CourseLesson;
using Repository.CourseLessonRepository;
using Repository.CourseMaterialRepository;
using Services.CourseLesson.Dto;

namespace Services.CourseLesson.Validator
{
    public class CourseLessonValidator(ICourseMaterialRepository courseMaterialRepository, ICourseLessonRepository repository)
        : BaseValidator<CourseLessonDbo, ICourseLessonRepository, CourseLessonCreateDto, CourseLessonDetailDto, CourseLessonUpdateDto>(repository),
            ICourseLessonValidator
    {
        private readonly ICourseMaterialRepository _courseMaterialRepository = courseMaterialRepository;

        public override Result<CourseLessonDetailDto> IsValid(CourseLessonCreateDto create)
        {
            Result<CourseLessonDetailDto> result = new();
            IsValidString(create.Name, result, MessageCategory.COURSE_LESSON, MessageItem.STRING_IS_EMPTY);
            if (_courseMaterialRepository.GetEntity(create.MaterialId) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.COURSE_MATERIAL, MessageItem.NOT_EXISTS));
            }
            return result;
        }

        public override Result<CourseLessonDetailDto> IsValid(CourseLessonUpdateDto update)
        {
            Result<CourseLessonDetailDto> result = new();
            IsValidString(update.Name, result, MessageCategory.COURSE_LESSON, MessageItem.STRING_IS_EMPTY);
            return result;
        }
    }
}
