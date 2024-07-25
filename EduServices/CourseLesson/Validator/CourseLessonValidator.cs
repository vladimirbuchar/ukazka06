using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using Model.Edu.CourseLesson;
using Repository.CourseLessonRepository;
using Repository.CourseMaterialRepository;
using Services.CourseLesson.Dto;
using System.Threading.Tasks;

namespace Services.CourseLesson.Validator
{
    public class CourseLessonValidator(ICourseMaterialRepository courseMaterialRepository, ICourseLessonRepository repository)
        : BaseValidator<CourseLessonDbo, ICourseLessonRepository, CourseLessonCreateDto, CourseLessonDetailDto, CourseLessonUpdateDto>(repository),
            ICourseLessonValidator
    {
        private readonly ICourseMaterialRepository _courseMaterialRepository = courseMaterialRepository;

        public override async Task<Result> IsValid(CourseLessonCreateDto create)
        {
            Result<CourseLessonDetailDto> result = new();
            IsValidString(create.Name, result, MessageCategory.COURSE_LESSON, MessageItem.STRING_IS_EMPTY);
            if (await _courseMaterialRepository.GetEntity(create.MaterialId) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, MessageCategory.COURSE_MATERIAL, MessageItem.NOT_EXISTS));
            }
            return result;
        }

        public override async Task<Result<CourseLessonDetailDto>> IsValid(CourseLessonUpdateDto update)
        {
            Result<CourseLessonDetailDto> result = new();
            IsValidString(update.Name, result, MessageCategory.COURSE_LESSON, MessageItem.STRING_IS_EMPTY);
            return await Task.FromResult(result);
        }
    }
}
