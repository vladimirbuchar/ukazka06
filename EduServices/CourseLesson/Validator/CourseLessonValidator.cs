using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using EduRepository.CourseLessonRepository;
using EduRepository.CourseMaterialRepository;
using EduServices.CourseLesson.Dto;
using Model.Edu.CourseLesson;

namespace EduServices.CourseLesson.Validator
{
    public class CourseLessonValidator(ICourseMaterialRepository courseMaterialRepository, ICourseLessonRepository repository)
        : BaseValidator<CourseLessonDbo, ICourseLessonRepository, CourseLessonCreateDto, CourseLessonDetailDto, CourseLessonUpdateDto>(repository),
            ICourseLessonValidator
    {
        private readonly ICourseMaterialRepository _courseMaterialRepository = courseMaterialRepository;

        public override Result<CourseLessonDetailDto> IsValid(CourseLessonCreateDto create)
        {
            Result<CourseLessonDetailDto> result = new();
            IsValidString(create.Name, result, Category.COURSE_LESSON, GlobalValue.STRING_IS_EMPTY);
            if (_courseMaterialRepository.GetEntity(create.MaterialId) == null)
            {
                result.AddResultStatus(new ValidationMessage(MessageType.ERROR, Category.COURSE_MATERIAL, GlobalValue.NOT_EXISTS));
            }
            return result;
        }

        public override Result<CourseLessonDetailDto> IsValid(CourseLessonUpdateDto update)
        {
            Result<CourseLessonDetailDto> result = new();
            IsValidString(update.Name, result, Category.COURSE_LESSON, GlobalValue.STRING_IS_EMPTY);
            return result;
        }
    }
}
