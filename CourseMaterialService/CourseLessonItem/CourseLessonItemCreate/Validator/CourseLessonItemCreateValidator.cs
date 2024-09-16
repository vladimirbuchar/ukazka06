using Core.Base.Repository.CodeBookRepository;
using Core.Base.Validator;
using Core.Constants;
using Core.DataTypes;
using CourseMaterialService.CourseLessonItem.CourseLessonItemCreate.Dto;
using Model.CodeBook;
using Model.Edu.CourseLessonItem;
using Repository.CourseLessonItem;

namespace CourseMaterialService.CourseLessonItem.CourseLessonItemCreate.Validator
{
    public class CourseLessonItemCreateValidator
        : BaseCreateValidator<CourseLessonItemDbo, ICourseLessonItemRepository, CourseLessonItemCreateDto>,
            ICourseLessonItemCreateValidator
    {
        private readonly ICodeBookRepository<CourseLessonItemTemplateDbo> _courseLessonItemTemplates;

        public CourseLessonItemCreateValidator(
            ICourseLessonItemRepository repository,
            ICodeBookRepository<CourseLessonItemTemplateDbo> courseLessonItemTemplates
        )
            : base(repository)
        {
            _courseLessonItemTemplates = courseLessonItemTemplates;
        }

        public override async Task<ResultInsert> IsValid(CourseLessonItemCreateDto create)
        {
            ResultInsert result = new();
            IsValidString(create.Name, result, MessageCategory.COURSE_LESSON_ITEM, MessageItem.STRING_IS_EMPTY);
            await IsValidItemTemplate(create.TemplateId, result);
            return result;
        }

        private async Task IsValidItemTemplate(Guid templateId, Result result)
        {
            if (
                (await _courseLessonItemTemplates.GetEntity(false, x => x.Id == templateId)).SystemIdentificator
                == CodebookValue.CODEBOOK_SELECT_VALUE
            )
            {
                result.AddResultStatus(
                    new ValidationMessage(MessageType.ERROR, MessageCategory.COURSE_LESSON_ITEM, Constants.COURSE_LESSON_ITEM_TEMPLATE_IS_EMPTY)
                );
            }
        }
    }
}
